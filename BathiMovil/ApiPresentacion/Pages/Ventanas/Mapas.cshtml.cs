using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text.Json;

namespace ApiPresentacion.Pages.Ventanas
{
    public class MapaModel : PageModel
    {
        public string UbicacionesJson { get; set; } = "[]";
        public string? FiltroSerial { get; set; }

        public void OnGet(int? portatilId)
        {
            try
            {
                var svcUbicaciones = new UbicacionesPresentacion();
                var svcPortatiles = new PortatilesPresentacion();

                var ubicaciones = svcUbicaciones.Consultar();
                var portatiles = svcPortatiles.Consultar();

                if (portatilId.HasValue)
                {
                    ubicaciones = ubicaciones
                        .Where(u => u.Portatil == portatilId.Value)
                        .ToList();

                    var p = portatiles.FirstOrDefault(x => x.Id_Portatil == portatilId.Value);
                    FiltroSerial = p?.Numero_Serial ?? portatilId.Value.ToString();
                }

                // Geocodificar cada ubicación en tiempo real
                using var http = new HttpClient();
                http.DefaultRequestHeaders.Add("User-Agent", "BathiMovil/1.0");

                var datos = new List<object>();

                foreach (var u in ubicaciones)
                {
                    try
                    {
                        var query = Uri.EscapeDataString(
                            $"{u.Direccion}, {u.Ciudad}, Colombia");

                        var url = $"https://nominatim.openstreetmap.org/search" +
                                  $"?q={query}&format=json&limit=1";

                        var task = http.GetStringAsync(url);
                        task.Wait();

                        using var doc = JsonDocument.Parse(task.Result);
                        var root = doc.RootElement;

                        if (root.GetArrayLength() == 0) continue;

                        var r = root[0];
                        var lat = double.Parse(r.GetProperty("lat").GetString()!,
                                  System.Globalization.CultureInfo.InvariantCulture);
                        var lon = double.Parse(r.GetProperty("lon").GetString()!,
                                  System.Globalization.CultureInfo.InvariantCulture);

                        var portatil = portatiles.FirstOrDefault(x => x.Id_Portatil == u.Portatil);

                        datos.Add(new
                        {
                            latitud = lat,
                            longitud = lon,
                            serial = portatil?.Numero_Serial ?? u.Portatil.ToString(),
                            ciudad = u.Ciudad ?? "",
                            direccion = u.Direccion ?? ""
                        });
                    }
                    catch { /* si una dirección falla, se omite ese pin */ }
                }

                UbicacionesJson = JsonSerializer.Serialize(datos);
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                UbicacionesJson = "[]";
            }
        }
    }
}