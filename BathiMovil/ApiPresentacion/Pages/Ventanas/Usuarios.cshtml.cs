using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class UsuariosModel : PageModel
    {
        private IRolesPresentacion? IRoles_Presentacion;
        private IUsuariosPresentacion? IUsuarios_Presentacion;
        private IPersonasPresentacion? IPersonasPresentacion;
        private IClientesPresentacion? IClientesPresentacion;
        [BindProperty] public List<Usuarios>? Lista { get; set; }
        [BindProperty] public Usuarios? Usuario { get; set; }
        [BindProperty] public List<Roles>? rolesLista { get; set; }
        [BindProperty] public List<Personas>? Personas { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public bool Escliente { get; set; } = false;

        public UsuariosModel()
        {
            IUsuarios_Presentacion = new UsuariosPresentacion();
            IPersonasPresentacion = new PersonasPresentacion();
            IRoles_Presentacion = new RolesPresentacion();
            IClientesPresentacion = new ClientesPresentacion();
        }

        public void OnGet()
        {


            OnPostBtRefrescar();
        }

        public List<Personas> CargarPersonas()
        {
            return Personas = IPersonasPresentacion!.Consultar();
        }

        public List<Roles> CargarRoles()
        {
            return rolesLista = IRoles_Presentacion!.Consultar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IUsuarios_Presentacion == null)
                    return;
                Lista = IUsuarios_Presentacion.Consultar();
                Usuario = null;
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
                Usuario = Lista!.FirstOrDefault(x => x.Id_Usuario == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public IActionResult BtSeguirRegistrando()
        {
            return Page();
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Usuario == null)
                    return;
                if (Usuario.Id_Usuario == 0)
                {
                    if (Usuario.Rol == 1 || Usuario.Rol == 2)
                    {
                        var id = new Clientes()
                        {
                            Id_Persona = Usuario.Persona
                        };
                        var cliente = IClientesPresentacion!.BuscarPorId(id);
                        if (cliente != null)
                        {
                            Escliente = true;
                            return;
                        }
                    }
                    Usuario = IUsuarios_Presentacion!.Guardar(Usuario!);
                }
                else
                    Usuario = IUsuarios_Presentacion!.Modificar(Usuario!);
                if (Usuario.Id_Usuario == 0)
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
                if (Usuario == null)
                    return;
                Usuario = IUsuarios_Presentacion!.Eliminar(Usuario!);
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
                Usuario = Lista!.FirstOrDefault(x => x.Id_Usuario == data);
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
