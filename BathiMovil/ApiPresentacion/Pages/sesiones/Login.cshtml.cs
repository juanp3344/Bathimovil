using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ApiPresentacion.Pages
{
    public class LoginModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Username { get; set; }
        [BindProperty] public string? Password_Hash { get; set; }
        [BindProperty] public bool EstaRegistrandose { get; set; } = false;
        [BindProperty] public bool Siguiente { get; set; } = false;
        [BindProperty] public Usuarios? Usuario { get; set; }
        [BindProperty] public Clientes? Cliente { get; set; }
        [BindProperty] public int EsCliente { get; set; } 

        private IUsuariosPresentacion? IUsuarios_Presentacion;
        private IClientesPresentacion? IClientesPresentacion;

        public void OnGet()
        {  
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public LoginModel()
        {
            IUsuarios_Presentacion = new UsuariosPresentacion();
            IClientesPresentacion = new ClientesPresentacion();
        }


        public void OnPostBtRegistrar()
        {
            try
            {
                if (Usuario == null)
                    return;
                if (Usuario.Id_Usuario == 0)
                {
                    if(EsCliente == 2)
                    {
                        Cliente!.Nombre = "Empresa";
                    }
                    
                    Usuario.Rol = 3;
                    Usuario.Fecha_Ultimo_Acceso = DateTime.Now;
                    Usuario.Activo = true;
                    Cliente = IClientesPresentacion!.Guardar(Cliente!);
                    Usuario.Persona = Cliente!.Id_Persona;
                    Usuario = IUsuarios_Presentacion!.Guardar(Usuario!);
                    Usuario = null;
                    Cliente = null;
                    Siguiente = false;
                    EstaRegistrandose = false;
                    return;
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }
        public void OnPostBtSeguirCliente()
        {
            EsCliente = 1;
            Siguiente = true;
        }

        public void OnPostBtSeguirEmpresarial()
        {
            EsCliente = 2;
            Siguiente = true;
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear(); // o tu lógica de logout
            return RedirectToPage("/sesiones/Login");
        }

        public void OnPostBtClean()
        {
            try
            {
                Username = string.Empty;
                Password_Hash = string.Empty;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public IActionResult OnPostBtEnter()
        {
            try
            {
                if (string.IsNullOrEmpty(Username) &&
                    string.IsNullOrEmpty(Password_Hash))
                {
                    OnPostBtClean();
                    return Page();
                }


                Usuario = new Usuarios()
                {
                    Username = Username,
                    Password_Hash = Password_Hash
                };

                var comprobar = IUsuarios_Presentacion!.CosultarCredenciales(Usuario);

                if (comprobar == null)
                {
                    OnPostBtClean();
                    ViewData["Mensaje"] = "Usuario no esta registrado";
                    return Page();
                }

                HttpContext.Session.SetString("Usuario", Username!);
                HttpContext.Session.SetInt32("Rol", comprobar.Rol);

                // Admin se queda aquí (el panel ES esta página)
                if (comprobar.Rol == 1 || comprobar.Rol ==2)
                {
                    EstaLogueado = true;
                    OnPostBtClean();
                    return Page();
                }
                else
                {
                    // Cualquier otro rol va a Ventas
                    IClientesPresentacion? IClientesPresentacion;
                    IClientesPresentacion = new ClientesPresentacion();
                    var Cliente = IClientesPresentacion.Consultar().FirstOrDefault(p => p.Id_Persona == comprobar.Persona);
                    HttpContext.Session.SetInt32("Id_Cliente", Cliente!.Id_Persona);
                    return RedirectToPage("/Ventanas/Ventas");
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return Page();
            }
        }

        public void OnPostBtRegistrarse()
        {
            EstaRegistrandose = true;
        }
        public void OnPostBtClose()
        {
            try
            {
                HttpContext.Session.Clear();
                HttpContext.Response.Redirect("/");
                EstaLogueado = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }
    }
}