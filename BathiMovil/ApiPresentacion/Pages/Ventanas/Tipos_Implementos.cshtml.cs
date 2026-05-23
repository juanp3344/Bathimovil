using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class Tipos_ImplementosModel : PageModel
    {
        private Tipos_ImplementosPresentacion? ITipos_Implementos_Presentacion;
        [BindProperty] public List<Tipos_Implementos>? Lista { get; set; }
        [BindProperty] public Tipos_Implementos? Tipos_Implemento { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public Tipos_ImplementosModel()
        {
            ITipos_Implementos_Presentacion = new Tipos_ImplementosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (ITipos_Implementos_Presentacion == null)
                    return;
                Lista = ITipos_Implementos_Presentacion.Consultar();
                Tipos_Implemento = null;
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
                Tipos_Implemento = Lista!.FirstOrDefault(x => x.Id_Tipo_Implemento == data);
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
                if (Tipos_Implemento == null)
                    return;
                if (Tipos_Implemento.Id_Tipo_Implemento == 0)
                    Tipos_Implemento = ITipos_Implementos_Presentacion!.Guardar(Tipos_Implemento!);
                else
                    Tipos_Implemento = ITipos_Implementos_Presentacion!.Modificar(Tipos_Implemento!);
                if (Tipos_Implemento.Id_Tipo_Implemento == 0)
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
                if (Tipos_Implemento == null)
                    return;
                Tipos_Implemento = ITipos_Implementos_Presentacion!.Eliminar(Tipos_Implemento!);
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
                Tipos_Implemento = Lista!.FirstOrDefault(x => x.Id_Tipo_Implemento == data);
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
