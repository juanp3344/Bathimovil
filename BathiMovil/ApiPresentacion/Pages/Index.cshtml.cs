using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ApiPresentacion.Pages
{
    public class IndexModel : PageModel
    {
        public bool EstaLogueado = false;
        [BindProperty] public string? Username { get; set; }
        [BindProperty] public string? Password_Hash { get; set; }

        [BindProperty] public Usuarios? entidad { get; set; }
        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (!String.IsNullOrEmpty(variable_session))
            {
                EstaLogueado = true;
                return;
            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear(); // o tu lógica de logout
            return RedirectToPage("/Index");
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

                UsuariosPresentacion? IUsuarios_Presentacion;
                IUsuarios_Presentacion = new UsuariosPresentacion();

                entidad = new Usuarios()
                {
                    Username = Username,
                    Password_Hash = Password_Hash
                };

                var comprobar = IUsuarios_Presentacion.CosultarCredenciales(entidad);

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
                    return RedirectToPage("/Ventanas/Ventas");
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return Page();
            }
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