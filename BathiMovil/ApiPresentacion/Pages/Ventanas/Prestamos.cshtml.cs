using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class PrestamosModel : PageModel
    {
        private IPrestamosPresentacion? IPrestamos_Presentacion;
        private IContratosPresentacion? IContratosPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        [BindProperty] public List<Prestamos>? Lista { get; set; }
        [BindProperty] public Prestamos? Prestamo { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public PrestamosModel()
        {
            IPrestamos_Presentacion = new PrestamosPresentacion();
            IContratosPresentacion = new ContratosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public List<Contratos> CargarContratos()
        {
            return IContratosPresentacion!.Consultar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IPrestamos_Presentacion == null)
                    return;
                Lista = IPrestamos_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista Prestamos", usuario);

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
                var usuario = HttpContext.Session.GetString("Usuario");

                if (Prestamo == null)
                    return;
                if (Prestamo.Id_Prestamo == 0)
                {
                    Prestamo = IPrestamos_Presentacion!.Guardar(Prestamo!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un Prestamo", usuario);
                }
                else
                    Prestamo = IPrestamos_Presentacion!.Modificar(Prestamo!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un Prestamo", usuario);

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
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un cliente", usuario);
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
