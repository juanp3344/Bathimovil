using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class VentasModel : PageModel
    {
        [BindProperty] public bool ConfirmarCantidad { get; set; }

        //Pa Prestar--------
        [BindProperty] public bool ConfirmarCantidadPrestamo { get; set; }
        //------------------

        [BindProperty] public bool NoEstaLogeado { get; set; } = false;
        [BindProperty] public bool ErrorRol { get; set; } = false;
        [BindProperty] public int? Cantidad { get; set; }
        [BindProperty] public int? Id { get; set; }
        [BindProperty] public List<Tipos_Portatiles>? ListaTPortatiles { get; set; }


        // ── COMPRAR ───────────────────────────────────────────────────────────────
        public void OnPostBtComprarPortatil()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                NoEstaLogeado = true;
                return;
            }
            else if (HttpContext.Session.GetInt32("Rol") == 1 || HttpContext.Session.GetInt32("Rol") == 2)
            {
                ErrorRol = true;
                return;
            }
            ConfirmarCantidad = true;
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

        // ── PRESTAR ───────────────────────────────────────────────────────────────

        public void OnPostBtPrestarPortatil()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                NoEstaLogeado = true;
                OnGet();
                return;
            }
            if (HttpContext.Session.GetInt32("Rol") == 1 || HttpContext.Session.GetInt32("Rol") == 2)
            {
                ErrorRol = true;
                OnGet();
                return;
            }
            OnGet();
            ConfirmarCantidadPrestamo = true;   // abre el modal morado de préstamo
        }

        public IActionResult OnPostBtAceptarPrestamo()
        {
            if (Cantidad == null || Cantidad <= 0)
            {
                ModelState.AddModelError("Cantidad", "No puedes ingresar valores incorrectos");
                ConfirmarCantidadPrestamo = true;
                OnGet();
                return Page();
            }

            PortatilesPresentacion IPortatiles_Presentacion = new PortatilesPresentacion();
            Tipos_PortatilesPresentacion ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion();

            var Tportatil = ITiposPortatiles_Presentacion.Consultar()
                .FirstOrDefault(p => p.Id_Tipo_Portatil == Id);

            IClientesPresentacion IClientesPresentacion = new ClientesPresentacion();
            int? idCliente = HttpContext.Session.GetInt32("Id_Cliente");
            var Cliente = IClientesPresentacion.Consultar()
                .FirstOrDefault(p => p.Id_Persona == idCliente);

            var disponibles = IPortatiles_Presentacion.ComprobarTamanio(Tportatil!).Count;
            if (disponibles < Cantidad)
            {
                ModelState.AddModelError("Cantidad", "No existe esa cantidad para esos baños portatiles");
                ConfirmarCantidadPrestamo = true;
                OnGet();
                return Page();
            }

            // igual que compra pero con EnPrestamo en vez de EnCompra
            TempData["Id_Cliente"] = Cliente!.Id_Persona;
            TempData["TDCantidad"] = Cantidad;
            TempData["Id_Portatil"] = Tportatil!.Id_Tipo_Portatil;
            TempData["EnPrestamo"] = true;
            return RedirectToPage("/Ventanas/Contratos");
        }

        //--------------------------------------------------------------------------------- Fin Prestar
    
    
    }
}