using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class Tipos_IntermediaModel : PageModel
    {
        private Tipos_IntermediaPresentacion? ITipos_Intermedia_Presentacion;
        [BindProperty] public List<Tipos_Intermedia>? Lista { get; set; }
        [BindProperty] public Tipos_Intermedia? Tipos_Intermedia { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public Tipos_IntermediaModel()
        {
            ITipos_Intermedia_Presentacion = new Tipos_IntermediaPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (ITipos_Intermedia_Presentacion == null)
                    return;
                Lista = ITipos_Intermedia_Presentacion.Consultar();
                Tipos_Intermedia = null;
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
                Tipos_Intermedia = Lista!.FirstOrDefault(x => x.Id_Tipos_Intermedia == data);
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
                if (Tipos_Intermedia == null)
                    return;
                if (Tipos_Intermedia.Id_Tipos_Intermedia == 0)
                    Tipos_Intermedia = ITipos_Intermedia_Presentacion!.Guardar(Tipos_Intermedia!);
                else
                    Tipos_Intermedia = ITipos_Intermedia_Presentacion!.Modificar(Tipos_Intermedia!);
                if (Tipos_Intermedia.Id_Tipos_Intermedia == 0)
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
                if (Tipos_Intermedia == null)
                    return;
                Tipos_Intermedia = ITipos_Intermedia_Presentacion!.Eliminar(Tipos_Intermedia!);
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
                Tipos_Intermedia = Lista!.FirstOrDefault(x => x.Id_Tipos_Intermedia == data);
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
