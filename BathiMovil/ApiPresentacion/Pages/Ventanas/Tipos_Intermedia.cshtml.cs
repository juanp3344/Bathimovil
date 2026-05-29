using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class Tipos_IntermediaModel : PageModel
    {
        private ITipos_IntermediaPresentacion? ITipos_Intermedia_Presentacion;
        private ITipo_ImplementosPresentacion? ITipo_ImplementosPresentacion;
        private ITipos_PortatilesPresentacion? ITipos_PortatilesPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Tipos_Intermedia>? Lista { get; set; }
        [BindProperty] public Tipos_Intermedia? Tipos_Intermedia { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public Tipos_IntermediaModel()
        {
            ITipos_Intermedia_Presentacion = new Tipos_IntermediaPresentacion();
            ITipos_PortatilesPresentacion = new Tipos_PortatilesPresentacion();
            ITipo_ImplementosPresentacion = new Tipos_ImplementosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();

        }


        public List<Tipos_Implementos> CargarTipos()
        {
            return ITipo_ImplementosPresentacion!.Consultar();
        }


        public List<Tipos_Portatiles> CargarTipoPorta()
        {
            return ITipos_PortatilesPresentacion!.Consultar();
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
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista T_Intermedia", usuario);
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
                var usuario = HttpContext.Session.GetString("Usuario");
                if (Tipos_Intermedia == null)
                    return;
                if (Tipos_Intermedia.Id_Tipos_Intermedia == 0)
                {
                    Tipos_Intermedia = ITipos_Intermedia_Presentacion!.Guardar(Tipos_Intermedia!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un T_Intermedia", usuario);
                }
                else
                    Tipos_Intermedia = ITipos_Intermedia_Presentacion!.Modificar(Tipos_Intermedia!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un T_Intermedia", usuario);
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
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un T_Intermedia", usuario);
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
