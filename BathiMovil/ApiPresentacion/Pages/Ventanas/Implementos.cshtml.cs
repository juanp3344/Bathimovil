using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class ImplementosModel : PageModel
    {
        private IImplementosPresentacion? IImplementos_Presentacion;
        private IPortatilesPresentacion? IPortatilesPresentacion;
        private IBodegasPresentacion? IBodegasPresentacion;
        private ITipo_ImplementosPresentacion? ITipo_ImplementosPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Implementos>? Lista { get; set; }
        [BindProperty] public Implementos? Implemento { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public ImplementosModel()
        {
            IImplementos_Presentacion = new ImplementosPresentacion();
            IPortatilesPresentacion = new PortatilesPresentacion();
            IBodegasPresentacion = new BodegasPresentacion();
            ITipo_ImplementosPresentacion = new Tipos_ImplementosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();

        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public List<Portatiles> CargarPortatiles()
        {
            return IPortatilesPresentacion!.Consultar();
        }

        public List<Bodegas> CargarBodegas()
        {
            return IBodegasPresentacion!.Consultar();
        }

        public List<Tipos_Implementos> CargarTipos()
        {
            return ITipo_ImplementosPresentacion!.Consultar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IImplementos_Presentacion == null)
                    return;
                Lista = IImplementos_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista implementos", usuario);
                Implemento = null;
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
                Implemento = Lista!.FirstOrDefault(x => x.Id_Implemento == data);
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
                if (Implemento == null)
                    return;
                if (Implemento.Id_Implemento == 0)
                {
                    Implemento = IImplementos_Presentacion!.Guardar(Implemento!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un Implemento", usuario);

                }
                else
                    Implemento = IImplementos_Presentacion!.Modificar(Implemento!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un Implemento", usuario);
                if (Implemento.Id_Implemento == 0)
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
                if (Implemento == null)
                    return;
                Implemento = IImplementos_Presentacion!.Eliminar(Implemento!);
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un Implemento", usuario);
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
                Implemento = Lista!.FirstOrDefault(x => x.Id_Implemento == data);
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
