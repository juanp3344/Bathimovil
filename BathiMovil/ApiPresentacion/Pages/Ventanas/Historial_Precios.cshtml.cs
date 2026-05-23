using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class HistorialPreciosModel : PageModel
    {
        private Historial_PreciosPresentacion? IHistorialPrecios_Presentacion;
        [BindProperty] public List<Historial_Precios>? Lista { get; set; }
        [BindProperty] public Historial_Precios? Historial_Precio { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public HistorialPreciosModel()
        {
            IHistorialPrecios_Presentacion = new Historial_PreciosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IHistorialPrecios_Presentacion == null)
                    return;
                Lista = IHistorialPrecios_Presentacion.Consultar();
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
                if (Historial_Precio == null)
                    return;
                if (Historial_Precio.Id_Historial == 0)
                    Historial_Precio = IHistorialPrecios_Presentacion!.Guardar(Historial_Precio!);
                else
                    Historial_Precio = IHistorialPrecios_Presentacion!.Modificar(Historial_Precio!);
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
