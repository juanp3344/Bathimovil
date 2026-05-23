using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class ImplementosModel : PageModel
    {
        private ImplementosPresentacion? IImplementos_Presentacion;
        [BindProperty] public List<Implementos>? Lista { get; set; }
        [BindProperty] public Implementos? Implemento { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public ImplementosModel()
        {
            IImplementos_Presentacion = new ImplementosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IImplementos_Presentacion == null)
                    return;
                Lista = IImplementos_Presentacion.Consultar();
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
                if (Implemento == null)
                    return;
                if (Implemento.Id_Implemento == 0)
                    Implemento = IImplementos_Presentacion!.Guardar(Implemento!);
                else
                    Implemento = IImplementos_Presentacion!.Modificar(Implemento!);
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
