using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class FacturasModel : PageModel
    {
        private IFacturasPresentacion? IFacturasPresentacion;
        private IClientesPresentacion? IClientesPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Facturas>? Lista { get; set; }
        [BindProperty] public List<Clientes>? Clientes { get; set; }
        [BindProperty] public Facturas? Factura { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public FacturasModel()
        {
            IFacturasPresentacion = new FacturasPresentacion();
            IClientesPresentacion = new ClientesPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();

        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public List<Clientes> CargarClientes()
        {
            return IClientesPresentacion!.Consultar();
        }



        public void OnPostBtRefrescar()
        {
            try
            {
                if (IFacturasPresentacion == null)
                    return;
                Lista = IFacturasPresentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista facturas", usuario);
                Factura = null;
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
                Factura = Lista!.FirstOrDefault(x => x.Id_Factura == data);
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

                if (Factura == null)
                    return;
                if (Factura.Id_Factura == 0)
                {
                    Factura = IFacturasPresentacion!.Guardar(Factura!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado una factura", usuario);

                }
                else
                    Factura = IFacturasPresentacion!.Modificar(Factura!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a una factura", usuario);

                if (Factura.Id_Factura == 0)
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
                if (Factura == null)
                    return;
                Factura = IFacturasPresentacion!.Eliminar(Factura!);
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado una Factura", usuario);
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
                Factura = Lista!.FirstOrDefault(x => x.Id_Factura == data);
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