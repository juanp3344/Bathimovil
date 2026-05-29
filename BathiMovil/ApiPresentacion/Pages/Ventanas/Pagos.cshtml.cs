using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class PagosModel : PageModel
    {
        private IPagosPresentacion? IPagos_Presentacion;
        private IFacturasPresentacion? IFacturasPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Pagos>? Lista { get; set; }
        [BindProperty] public Pagos? Pago { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public PagosModel()
        {
            IPagos_Presentacion = new PagosPresentacion();
            IFacturasPresentacion = new FacturasPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public List<Facturas> CargarFacturas()
        {
            return IFacturasPresentacion!.Consultar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IPagos_Presentacion == null)
                    return;
                Lista = IPagos_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista pagos", usuario);
                Pago = null;
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
                Pago = Lista!.FirstOrDefault(x => x.Id_Pago == data);
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
                if (Pago == null)
                    return;
                if (Pago.Id_Pago == 0)
                {
                    Pago = IPagos_Presentacion!.Guardar(Pago!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un Pago", usuario);
                }
                else
                    Pago = IPagos_Presentacion!.Modificar(Pago!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un Pago", usuario);

                if (Pago.Id_Pago == 0)
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
                if (Pago == null)
                    return;
                Pago = IPagos_Presentacion!.Eliminar(Pago!);
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un Pago", usuario);
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
                Pago = Lista!.FirstOrDefault(x => x.Id_Pago == data);
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
