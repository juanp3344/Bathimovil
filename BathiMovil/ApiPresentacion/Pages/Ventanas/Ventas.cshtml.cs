using BibliotecaPresentacion.Implementaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class VentasModel : PageModel
    {
        [BindProperty] public bool IrComprar { get; set; } 
        public IActionResult OnPostBtComprarPortatilPersonal()
        {
            return RedirectToPage("/Ventanas/Compras", new { nuevo = true, dato = 2 });
        }


    }

}
