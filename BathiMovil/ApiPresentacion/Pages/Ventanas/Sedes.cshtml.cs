using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class SedesModel : PageModel
    {
        private SedesPresentacion? ISedes_Presentacion;
        [BindProperty] public List<Sedes>? Lista { get; set; }
        [BindProperty] public Sedes? Sede { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public SedesModel()
        {
            ISedes_Presentacion = new SedesPresentacion();
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
                if (Sede == null)
                    return;
                if (Sede.Id_Sede == 0)
                    Sede = ISedes_Presentacion!.Guardar(Sede!);
                else
                    Sede = ISedes_Presentacion!.Modificar(Sede!);
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
