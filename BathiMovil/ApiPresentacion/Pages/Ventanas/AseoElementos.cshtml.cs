using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class AseoElementosModel : PageModel
    {
        private IAseo_ElementosPresentacion? IAseo_ElementosPresentacion;
        [BindProperty] public List<Aseo_Elementos>? Lista { get; set; }
        [BindProperty] public Aseo_Elementos? Aseo_Elemento { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public AseoElementosModel()
        {
            IAseo_ElementosPresentacion = new Aseo_ElementosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IAseo_ElementosPresentacion == null)
                    return;
                Lista = IAseo_ElementosPresentacion.Consultar();
                Aseo_Elemento = null;
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
                Aseo_Elemento = Lista!.FirstOrDefault(x => x.Id_Aseo_Elemento == data);
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
                if (Aseo_Elemento == null)
                    return;
                if (Aseo_Elemento.Id_Aseo_Elemento == 0)
                    Aseo_Elemento = IAseo_ElementosPresentacion!.Guardar(Aseo_Elemento!);
                else
                    Aseo_Elemento = IAseo_ElementosPresentacion!.Modificar(Aseo_Elemento!);
                if (Aseo_Elemento.Id_Aseo_Elemento == 0)
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
                if (Aseo_Elemento == null)
                    return;
                Aseo_Elemento = IAseo_ElementosPresentacion!.Eliminar(Aseo_Elemento!);
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
                Aseo_Elemento = Lista!.FirstOrDefault(x => x.Id_Aseo_Elemento == data);
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