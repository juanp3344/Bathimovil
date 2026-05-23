using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class EnviosModel : PageModel
    {
        private IEnviosPresentacion? IEnviosPresentacion;
        [BindProperty] public List<Envios>? Lista { get; set; }
        [BindProperty] public Envios? Envio { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public EnviosModel()
        {
            IEnviosPresentacion = new EnviosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IEnviosPresentacion == null)
                    return;
                Lista = IEnviosPresentacion.Consultar();
                Envio = null;
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
                Envio = Lista!.FirstOrDefault(x => x.Id_Envio == data);
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
                if (Envio == null)
                    return;
                if (Envio.Id_Envio == 0)
                    Envio = IEnviosPresentacion!.Guardar(Envio!);
                else
                    Envio = IEnviosPresentacion!.Modificar(Envio!);
                if (Envio.Id_Envio == 0)
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
                if (Envio == null)
                    return;
                Envio = IEnviosPresentacion!.Eliminar(Envio!);
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
                Envio = Lista!.FirstOrDefault(x => x.Id_Envio == data);
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