using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class HistorialPreciosModel : PageModel
    {
        private IHistorial_PreciosPresentacion? IHistorialPrecios_Presentacion;
        private ITipos_PortatilesPresentacion? ITipos_PortatilesPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Historial_Precios>? Lista { get; set; }
        [BindProperty] public Historial_Precios? Historial_Precio { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public HistorialPreciosModel()
        {
            IHistorialPrecios_Presentacion = new Historial_PreciosPresentacion();
            ITipos_PortatilesPresentacion = new Tipos_PortatilesPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();

        }

        public void OnGet()
        {
            OnPostBtRefrescar();

        }


        public List<Tipos_Portatiles> CargarTipo()
        {
            return ITipos_PortatilesPresentacion!.Consultar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IHistorialPrecios_Presentacion == null)
                    return;
                Lista = IHistorialPrecios_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista historial precios", usuario);
                Historial_Precio = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }



        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Historial_Precio = Lista!.FirstOrDefault(x => x.Id_Historial == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                var usuario = HttpContext.Session.GetString("Usuario");
                if (Historial_Precio == null)
                    return;
                if (Historial_Precio.Id_Historial == 0)
                {
                    Historial_Precio = IHistorialPrecios_Presentacion!.Guardar(Historial_Precio!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un precio del historial", usuario);

                }
                else
                    Historial_Precio = IHistorialPrecios_Presentacion!.Modificar(Historial_Precio!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un precio del historial", usuario);

                if (Historial_Precio.Id_Historial == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Historial_Precio == null)
                    return;
                Historial_Precio = IHistorialPrecios_Presentacion!.Eliminar(Historial_Precio!);
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un precio del historial", usuario);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Historial_Precio = Lista!.FirstOrDefault(x => x.Id_Historial == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}
