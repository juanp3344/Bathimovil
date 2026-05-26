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
        [BindProperty] public int? Cantidad { get; set; }
        [BindProperty] public int? Id { get; set; }
        [BindProperty] public List<Tipos_Portatiles>? ListaTPortatiles { get; set; }

        public void OnPostBtComprarPortatil()
        {
            ConfirmarCantidad = true;
            Id = 1;
        }

        public void OnGet()
        {
            Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
            ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion();
            ListaTPortatiles = ITiposPortatiles_Presentacion.Consultar();

            var variable_session = HttpContext.Session.GetString("Usuario");
            if (String.IsNullOrEmpty(variable_session))
            {
                HttpContext.Response.Redirect("/");
                return;
            }
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

          /*  var C = new Clientes()
            {
                Cedula = "2173897128912",
                Nombre = "Juan",
                Correo = "j@gmail.com",
                Telefono = "3820984930",
                Razon_Social = "2983908994AC",
                Nit_CC = "494545390AC",
                Direccion_Fiscal = "Medellin"
            };

            IClientesPresentacion.Guardar(C);*/

            var Cliente = IClientesPresentacion.Consultar().FirstOrDefault(p => p.Id_Persona == 1);

            var lista = IPortatiles_Presentacion.ComprobarTamanio(Tportatil!).Count; // hacemos el conteo ya con el tipo de portatil aquellos portatiles que son de aquel tipo y que esten disponibles
            if (lista < Cantidad) //si no existe la cantidad de ese tipo de portatiles que se quieren, tampoco lo dejara pasar
            {
                ModelState.AddModelError("Cantidad", "No existe esa cantidad para esos baños portatiles");
                ConfirmarCantidad = true;
                return Page();
            }

            return RedirectToPage("/Ventanas/Contratos", new { nuevo = true, Id_Cliente = Cliente!.Id_Persona , Cantidad = Cantidad, Id_Portatil = Tportatil!.Id_Tipo_Portatil }); //Con todo listo lo mandaremos a contrato para que rellene todo
        }

        
    }
}





