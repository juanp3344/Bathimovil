using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class PrivacyModel : PageModel
    {
        public void OnGet()
        {
            var variable_session = HttpContext.Session.GetString("Usuario");
            if (String.IsNullOrEmpty(variable_session))
            {
                HttpContext.Response.Redirect("/");
                return;
            }
        }
    }

}
