using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages.Ventanas
{
    public class UbicacionesModel : PageModel
    {
        private UbicacionesServicios? svc;


        [BindProperty] public List<Ubicaciones>? Lista { get; set; }
        [BindProperty] public Ubicaciones? Ubicacion { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        // Para el combo de portátiles
        public List<Portatiles> ListaPortatiles { get; set; } = new();

        public UbicacionesModel()
        {
            svc = new UbicacionesServicios();
        }

        public void OnGet() => OnPostBtRefrescar();

        public void OnPostBtRefrescar()
        {
            try
            {
                Lista = svc!.Consultar();
                Ubicacion = null;
                CargarPortatiles();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtNuevo()
        {
            Ubicacion = new Ubicaciones();
            Lista = null;
            Borrando = false;
            CargarPortatiles();
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Ubicacion = Lista!.FirstOrDefault(x => x.Id_Ubicacion == data);
                Lista = null;
                Borrando = false;
                CargarPortatiles();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtBorrar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Ubicacion = Lista!.FirstOrDefault(x => x.Id_Ubicacion == data);
                Lista = null;
                Borrando = true;
                CargarPortatiles();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Ubicacion!.Id_Ubicacion == 0)
                    svc!.Guardar(Ubicacion);
                else
                    svc!.Modificar(Ubicacion);

                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        public void OnPostBtEliminar()
        {
            try
            {
                svc!.Eliminar(Ubicacion!);
                OnPostBtRefrescar();
            }
            catch (Exception ex) { ViewData["Mensaje"] = ex.Message; }
        }

        private void CargarPortatiles()
        {
            var pSvc = new PortatilesServicios();
            ListaPortatiles = pSvc.Consultar();
        }
    }
}