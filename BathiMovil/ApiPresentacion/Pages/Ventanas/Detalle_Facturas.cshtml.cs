using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class Detalle_FacturasModel : PageModel
    {
        private IDetalle_FacturasPresentacion? IDetalle_FacturasPresentacion;
        private IFacturasPresentacion? IFacturasPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Detalle_Facturas>? Lista { get; set; }
        [BindProperty] public Detalle_Facturas? Detalle_Factura { get; set; }
        [BindProperty] public List<Facturas>? Facturas { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public Detalle_FacturasModel()
        {
            IDetalle_FacturasPresentacion = new Detalle_FacturasPresentacion();
            IFacturasPresentacion = new FacturasPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();

        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public List<Facturas> CargarFacturas()
        {
            return Facturas = IFacturasPresentacion!.Consultar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IDetalle_FacturasPresentacion == null)
                    return;
                Lista = IDetalle_FacturasPresentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista detalles factura", usuario);
                Detalle_Factura = null;
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
                Detalle_Factura = Lista!.FirstOrDefault(x => x.Id_Detalle == data);
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

                if (Detalle_Factura == null)
                    return;
                if (Detalle_Factura.Id_Detalle == 0)
                {
                    Detalle_Factura = IDetalle_FacturasPresentacion!.Guardar(Detalle_Factura!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un detalle factura", usuario);
                }
                else
                    Detalle_Factura = IDetalle_FacturasPresentacion!.Modificar(Detalle_Factura!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un cliente", usuario);
                if (Detalle_Factura.Id_Detalle == 0)
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
                if (Detalle_Factura == null)
                    return;
                Detalle_Factura = IDetalle_FacturasPresentacion!.Eliminar(Detalle_Factura!);
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un detalle factura", usuario);
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
                Detalle_Factura = Lista!.FirstOrDefault(x => x.Id_Detalle == data);
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