using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class PagosModel : PageModel
    {
        private PagosPresentacion? IPagos_Presentacion;
        [BindProperty] public List<Pagos>? Lista { get; set; }
        [BindProperty] public Pagos? Pago { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public PagosModel()
        {
            IPagos_Presentacion = new PagosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IPagos_Presentacion == null)
                    return;
                Lista = IPagos_Presentacion.Consultar();
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
                if (Pago == null)
                    return;
                if (Pago.Id_Pago == 0)
                    Pago = IPagos_Presentacion!.Guardar(Pago!);
                else
                    Pago = IPagos_Presentacion!.Modificar(Pago!);
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
