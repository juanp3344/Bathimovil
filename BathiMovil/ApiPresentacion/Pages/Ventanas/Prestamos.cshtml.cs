using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class PrestamosModel : PageModel
    {
        private PrestamosPresentacion? IPrestamos_Presentacion;
        [BindProperty] public List<Prestamos>? Lista { get; set; }
        [BindProperty] public Prestamos? Prestamo { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public PrestamosModel()
        {
            IPrestamos_Presentacion = new PrestamosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IPrestamos_Presentacion == null)
                    return;
                Lista = IPrestamos_Presentacion.Consultar();
                Prestamo = null;
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
                Prestamo = Lista!.FirstOrDefault(x => x.Id_Prestamo == data);
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
                if (Prestamo == null)
                    return;
                if (Prestamo.Id_Prestamo == 0)
                    Prestamo = IPrestamos_Presentacion!.Guardar(Prestamo!);
                else
                    Prestamo = IPrestamos_Presentacion!.Modificar(Prestamo!);
                if (Prestamo.Id_Prestamo == 0)
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
                if (Prestamo == null)
                    return;
                Prestamo = IPrestamos_Presentacion!.Eliminar(Prestamo!);
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
                Prestamo = Lista!.FirstOrDefault(x => x.Id_Prestamo == data);
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
