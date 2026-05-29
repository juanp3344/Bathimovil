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
        [BindProperty] public bool ConfirmarCantidadPrestamo { get; set; }  // popup separado para prestar
        [BindProperty] public bool NoEstaLogeado { get; set; } = false;
        [BindProperty] public bool ErrorRol { get; set; } = false;
        [BindProperty] public int? Cantidad { get; set; }
        [BindProperty] public int? CantidadPrestamo { get; set; }           // cantidad para prestar
        [BindProperty] public int? Id { get; set; }
        [BindProperty] public List<Tipos_Portatiles>? ListaTPortatiles { get; set; }

        // ── Botón Comprar: abre popup de cantidad para compra ──
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

        // ── Botón Prestar: abre popup de cantidad para préstamo ──
        public void OnPostBtPrestarPortatil()
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
            ConfirmarCantidadPrestamo = true;
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

        // ── Confirmar cantidad para COMPRA ──
        public IActionResult OnPostBtAceptar()
        {
            if (Cantidad == null || Cantidad <= 0)
            {
                ModelState.AddModelError("Cantidad", "No puedes ingresar valores incorrectos");
                ConfirmarCantidad = true;
                return Page();
            }

            PortatilesPresentacion? IPortatiles_Presentacion = new PortatilesPresentacion();
            Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion();

            var Tportatil = ITiposPortatiles_Presentacion.Consultar()
                .FirstOrDefault(p => p.Id_Tipo_Portatil == Id);

            IClientesPresentacion? IClientesPresentacion = new ClientesPresentacion();
            int? idCliente = HttpContext.Session.GetInt32("Id_Cliente");
            var Cliente = IClientesPresentacion.Consultar().FirstOrDefault(p => p.Id_Persona == idCliente);

            var lista = IPortatiles_Presentacion.ComprobarTamanio(Tportatil!).Count;
            if (lista < Cantidad)
            {
                ModelState.AddModelError("Cantidad", "No existe esa cantidad para esos baños portatiles");
                ConfirmarCantidad = true;
                return Page();
            }

            TempData["Id_Cliente"] = Cliente!.Id_Persona;
            TempData["TDCantidad"] = Cantidad;
            TempData["Id_Portatil"] = Tportatil!.Id_Tipo_Portatil;
            TempData["EnCompra"] = true;
            return RedirectToPage("/Ventanas/Contratos");
        }

        // ── Confirmar cantidad para PRÉSTAMO ──
        public IActionResult OnPostBtAceptarPrestamo()
        {
            if (CantidadPrestamo == null || CantidadPrestamo <= 0)
            {
                ModelState.AddModelError("CantidadPrestamo", "No puedes ingresar valores incorrectos");
                ConfirmarCantidadPrestamo = true;
                return Page();
            }

            PortatilesPresentacion? IPortatiles_Presentacion = new PortatilesPresentacion();
            Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion();

            var Tportatil = ITiposPortatiles_Presentacion.Consultar()
                .FirstOrDefault(p => p.Id_Tipo_Portatil == Id);

            IClientesPresentacion? IClientesPresentacion = new ClientesPresentacion();
            int? idCliente = HttpContext.Session.GetInt32("Id_Cliente");
            var Cliente = IClientesPresentacion.Consultar().FirstOrDefault(p => p.Id_Persona == idCliente);

            // Verificar disponibilidad igual que en compra
            var disponibles = IPortatiles_Presentacion.ComprobarTamanio(Tportatil!).Count;
            if (disponibles < CantidadPrestamo)
            {
                ModelState.AddModelError("CantidadPrestamo", "No existe esa cantidad disponible para préstamo");
                ConfirmarCantidadPrestamo = true;
                return Page();
            }

            TempData["Id_Cliente"] = Cliente!.Id_Persona;
            TempData["TDCantidad"] = CantidadPrestamo;
            TempData["Id_Portatil"] = Tportatil!.Id_Tipo_Portatil;
            TempData["EnPrestamo"] = true;
            return RedirectToPage("/Ventanas/Contratos");
        }
    }
}
