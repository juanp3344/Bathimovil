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
        [BindProperty] public List<Contratos>? Lista { get; set; }
        [BindProperty] public Contratos? Contrato { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public ContratosModel()
        {
            IContratosPresentacion = new ContratosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IContratosPresentacion == null)
                    return;
                Lista = IContratosPresentacion.Consultar();
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
                if (Contrato == null)
                    return;
                if (Contrato.Id_Contrato == 0)
                    Contrato = IContratosPresentacion!.Guardar(Contrato!);
                else
                    Contrato = IContratosPresentacion!.Modificar(Contrato!);
                if (Contrato.Id_Contrato == 0)
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
                if (Contrato == null)
                    return;
                Contrato = IContratosPresentacion!.Eliminar(Contrato!);
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