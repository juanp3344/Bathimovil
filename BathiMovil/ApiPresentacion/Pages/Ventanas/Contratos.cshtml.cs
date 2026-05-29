using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class ContratosModel : PageModel
    {
        private IContratosPresentacion? IContratosPresentacion;
        private IClientesPresentacion? IClientesPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        [BindProperty] public List<Contratos>? Lista { get; set; }
        [BindProperty] public Contratos? Contrato { get; set; }
        [BindProperty] public bool VienePorCompra { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public int? CantidadCalculo { get; set; }
        [BindProperty] public int? Portatil { get; set; }
        [TempData] public int? Id_Cliente { get; set; }
        [TempData] public int UltimoContratoId { get; set; }  // renombrados para no  


        public ContratosModel()
        {
            IContratosPresentacion = new ContratosPresentacion();
            IClientesPresentacion =  new ClientesPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {

            bool EnCompra = false;
            if (TempData.ContainsKey("EnCompra"))
            {
                EnCompra = (bool)TempData["EnCompra"]!;
            }


            if (EnCompra)
            {
                VienePorCompra = true;
                Contrato = new Contratos()
                {
                    Cliente = (int)Id_Cliente!,
                    Fecha_Firma = DateTime.Now,
                    Terminos = "Comprara el baño portatil programado a envio",
                    Fecha_Expiracion = DateTime.Now.AddMonths(12)

                };

                CantidadCalculo = (int)TempData["TDCantidad"]!;
                Portatil = (int)TempData["Id_Portatil"]!;

                return;
            }
            OnPostBtRefrescar();
        }


        public IActionResult OnPostBtFirmar()
        {
            OnPostBtGuardar();

            if (UltimoContratoId == 0)
            {
                ViewData["Mensaje"] = "Error al guardar el contrato";
                VienePorCompra = true;
                return Page();
            }

            
            TempData["TDCantidad"] = CantidadCalculo;
            TempData["Id_Portatil"] = Portatil;
            TempData["Id_Contrato"] = UltimoContratoId;
            TempData["EnCompra"] = true;

            return RedirectToPage("/Ventanas/Compras");
        }

        public List<Clientes> CargarClientes()
        {
            return IClientesPresentacion!.Consultar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IContratosPresentacion == null)
                    return;
                
                Lista = IContratosPresentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista contratos", usuario);

                Contrato = null;
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
                Contrato = Lista!.FirstOrDefault(x => x.Id_Contrato == data);
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

                if (Contrato == null)
                    return;
                if (Contrato.Id_Contrato == 0)
                {
                    Contrato = IContratosPresentacion!.Guardar(Contrato!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un contrato", usuario);
                }
                else
                    Contrato = IContratosPresentacion!.Modificar(Contrato!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un contrato", usuario);
                if (Contrato.Id_Contrato == 0)
                    return;
                UltimoContratoId = Contrato.Id_Contrato;
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
                if (Contrato == null)
                    return;
                Contrato = IContratosPresentacion!.Eliminar(Contrato!);
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un contrato", usuario);
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
                Contrato = Lista!.FirstOrDefault(x => x.Id_Contrato == data);
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