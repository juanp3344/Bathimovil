using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class VentasModel : PageModel
    {
        [BindProperty] public bool ConfirmarCantidad { get; set; }
        [BindProperty] public bool NoEstaLogeado { get; set; } = false;
        [BindProperty] public int? Cantidad { get; set; }
        [BindProperty] public int? Id { get; set; }
        [BindProperty] public List<Tipos_Portatiles>? ListaTPortatiles { get; set; }

        public void OnPostBtComprarPortatil()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                NoEstaLogeado = true;
                return;
            }
            ConfirmarCantidad = true;
            Id = 1;
        }

        public void OnPostBtCerrar()
        {
            OnGet();
        }

        public void OnGet()
        {
            Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
            ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion();
            ListaTPortatiles = ITiposPortatiles_Presentacion.Consultar();
        }


        public IActionResult OnPostBtAceptar()
        {
            if (Cantidad == null || Cantidad <= 0) //si ingresa valores negativos o nulos en el texto del popup no lo dejara pasar
            {
                ModelState.AddModelError("Cantidad", "No puedes ingresar valores incorrectos");
                ConfirmarCantidad = true;
                return Page();
            }

            PortatilesPresentacion? IPortatiles_Presentacion;
            IPortatiles_Presentacion = new PortatilesPresentacion();//llamamos a la presentacion de portatiles para el metodo logico

            Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
            ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion(); // necesitamos este para poder realizar el linq y ver de que tipo portatil necesitan comprobar su cantidad

            var Tportatil = ITiposPortatiles_Presentacion.Consultar().FirstOrDefault(p => p.Id_Tipo_Portatil == Id);//realizamos linq para el tipo

            IClientesPresentacion? IClientesPresentacion;
            IClientesPresentacion = new ClientesPresentacion();

            int? idCliente = HttpContext.Session.GetInt32("Id_Cliente");

            var Cliente = IClientesPresentacion.Consultar().FirstOrDefault(p => p.Id_Persona == idCliente);

            var lista = IPortatiles_Presentacion.ComprobarTamanio(Tportatil!).Count; // hacemos el conteo ya con el tipo de portatil aquellos portatiles que son de aquel tipo y que esten disponibles
            if (lista < Cantidad) //si no existe la cantidad de ese tipo de portatiles que se quieren, tampoco lo dejara pasar
            {
                ModelState.AddModelError("Cantidad", "No existe esa cantidad para esos baños portatiles");
                ConfirmarCantidad = true;
                return Page();
            }
            TempData["Id_Cliente"] = Cliente!.Id_Persona;
            TempData["TDCantidad"] = Cantidad;
            TempData["Id_Portatil"] = Tportatil!.Id_Tipo_Portatil;
            TempData["EnCompra"] = true;
            return RedirectToPage("/Ventanas/Contratos"); //Con todo listo lo mandaremos a contrato para que rellene todo
        }

        
    }
}





