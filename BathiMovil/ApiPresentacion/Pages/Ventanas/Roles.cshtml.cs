using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class RolesModel : PageModel
    {
        private RolesPresentacion? IRoles_Presentacion;
        [BindProperty] public List<Roles>? Lista { get; set; }
        [BindProperty] public Roles? Rol { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public RolesModel()
        {
            IRoles_Presentacion = new RolesPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IRoles_Presentacion == null)
                    return;
                Lista = IRoles_Presentacion.Consultar();
                Rol = null;
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
                Rol = Lista!.FirstOrDefault(x => x.Id_Rol == data);
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
                if (Rol == null)
                    return;
                if (Rol.Id_Rol == 0)
                    Rol = IRoles_Presentacion!.Guardar(Rol!);
                else
                    Rol = IRoles_Presentacion!.Modificar(Rol!);
                if (Rol.Id_Rol == 0)
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
                if (Rol == null)
                    return;
                Rol = IRoles_Presentacion!.Eliminar(Rol!);
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
                Rol = Lista!.FirstOrDefault(x => x.Id_Rol == data);
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
