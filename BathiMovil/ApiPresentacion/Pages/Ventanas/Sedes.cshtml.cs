using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class SedesModel : PageModel
    {
        private ISedesPresentacion? ISedes_Presentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Sedes>? Lista { get; set; }
        [BindProperty] public Sedes? Sede { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public SedesModel()
        {
            ISedes_Presentacion = new SedesPresentacion();
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
                if (ISedes_Presentacion == null)
                    return;
                Lista = ISedes_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista sedes", usuario);
                Sede = null;
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
                Sede = Lista!.FirstOrDefault(x => x.Id_Sede == data);
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
                if (Sede == null)
                    return;
                if (Sede.Id_Sede == 0)
                {
                    Sede = ISedes_Presentacion!.Guardar(Sede!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado una Sede", usuario);
                }
                else
                    Sede = ISedes_Presentacion!.Modificar(Sede!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un Sede", usuario);
                if (Sede.Id_Sede == 0)
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
                if (Sede == null)
                    return;
                Sede = ISedes_Presentacion!.Eliminar(Sede!);
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado una Sede", usuario);
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
                Sede = Lista!.FirstOrDefault(x => x.Id_Sede == data);
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
