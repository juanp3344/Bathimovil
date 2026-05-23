using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class VentasModel : PageModel
    {
        [BindProperty] public bool IrComprar { get; set; } 
        public IActionResult OnPostBtComprar()
        {
            return RedirectToPage("/Ventanas/Compras", new { nuevo = true });
        }


    }

}
