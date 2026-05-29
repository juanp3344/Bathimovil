using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class Tipos_ImplementosModel : PageModel
    {
        private ITipo_ImplementosPresentacion? ITipos_Implementos_Presentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Tipos_Implementos>? Lista { get; set; }
        [BindProperty] public Tipos_Implementos? Tipos_Implemento { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public Tipos_ImplementosModel()
        {
            ITipos_Implementos_Presentacion = new Tipos_ImplementosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
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
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista T implemento", usuario);
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
                var usuario = HttpContext.Session.GetString("Usuario");

                if (Tipos_Implemento == null)
                    return;
                if (Tipos_Implemento.Id_Tipo_Implemento == 0)
                {
                    Tipos_Implemento = ITipos_Implementos_Presentacion!.Guardar(Tipos_Implemento!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un T implemento", usuario);
                }
                else
                    Tipos_Implemento = ITipos_Implementos_Presentacion!.Modificar(Tipos_Implemento!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un T implemento", usuario);
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
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un T implemento", usuario);
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
