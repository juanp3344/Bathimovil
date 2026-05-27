using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            if(HttpContext!.Session.GetString("Usuario") == null || HttpContext.Session.GetInt32("Rol") == 3)
            {
                return RedirectToPage("/Ventanas/Ventas");
            }

            return RedirectToPage("/sesiones/Login");
        }
    }
}
