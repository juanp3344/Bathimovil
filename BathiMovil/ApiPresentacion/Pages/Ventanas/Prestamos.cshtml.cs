using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ApiPresentacion.Pages
{
    public class PrestamosModel : PageModel
    {
        private IPrestamosPresentacion? IPrestamos_Presentacion;
        private IContratosPresentacion? IContratosPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Prestamos>? Lista { get; set; }
        [BindProperty] public Prestamos? Prestamo { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public bool VienePorPrestamo { get; set; }
        [BindProperty] public bool ConfirmarPrestamo { get; set; }
        [BindProperty] public int Cantidad { get; set; }
        [TempData] public int TPortatil { get; set; }
        [TempData] public bool EnPrestamo { get; set; }

        public PrestamosModel()
        {
            IPrestamos_Presentacion = new PrestamosPresentacion();
            IContratosPresentacion = new ContratosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {
            if (EnPrestamo)
            {
                int idContrato = (int)TempData["Id_Contrato"]!;
                int cantidadCalculo = (int)TempData["TDCantidad"]!;
                int portatil = (int)TempData["Id_Portatil"]!;

                Cantidad = cantidadCalculo;
                TPortatil = portatil;

                VienePorPrestamo = true;
                Prestamo = new Prestamos()
                {
                    Fecha_Inicio = DateTime.Now,
                    Fecha_Fin_Prevista = DateTime.Now.AddDays(15), // 15 días estimados por defecto
                    Estado_Prestamo = true,
                    Contrato = idContrato
                };

                return;
            }
            OnPostBtRefrescar();
        }

        public List<Contratos> CargarContratos()
        {
            return IContratosPresentacion!.Consultar();
        }

        public void OnPostBtPrestar()
        {
            try
            {
                IPortatilesPresentacion? IPortatiles_Presentacion;
                IPortatiles_Presentacion = new PortatilesPresentacion();

                var portatiles = IPortatiles_Presentacion.Consultar()
                    .Where(p => p.Tipo_Portatil == TPortatil && p.Estado_Actual == "Libre")
                    .Take(Cantidad)
                    .ToList();

                ConfirmarPrestamo = true;
                OnPostBtGuardar();

                foreach (var portatil in portatiles)
                {
                    portatil.Estado_Actual = "Prestado";
                    portatil.Compra = null; // Nos aseguramos que no interfiera con compras

                    // Al mapear la nueva FK en la base de datos, guardamos el ID del préstamo actual en la tabla principal si es necesario, 
                    // o dejo que el registro de Préstamo apunte a él. Como puse la FK en Prestamos, el objeto 'Prestamo' ya tiene el Id_Portatil asignado en OnPostBtGuardar.

                    IPortatiles_Presentacion.Modificar(portatil);
                }

                ConfirmarPrestamo = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                return;
            }
        }

        public IActionResult OnPostBtTerminar()
        {
            return RedirectToPage("/Ventanas/Ventas");
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IPrestamos_Presentacion == null)
                    return;
                Lista = IPrestamos_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista prestamos", usuario);

                Prestamo = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Prestamo = Lista!.FirstOrDefault(x => x.Id_Prestamo == data);
                Lista = null;
                Borrando = false;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                var usuario = HttpContext.Session.GetString("Usuario");

                if (Prestamo == null)
                    return;

                // Asignamos el ID del portátil al objeto Préstamo antes de guardar
                Prestamo.Portatil = TPortatil;

                if (Prestamo.Id_Prestamo == 0)
                {
                    Prestamo = IPrestamos_Presentacion!.Guardar(Prestamo!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un prestamo", usuario);
                }
                else
                {
                    Prestamo = IPrestamos_Presentacion!.Modificar(Prestamo!);
                    IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado un prestamo", usuario);
                }

                if (Prestamo.Id_Prestamo == 0)
                    return;

                if (ConfirmarPrestamo)
                    return;

                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (Prestamo == null)
                    return;
                Prestamo = IPrestamos_Presentacion!.Eliminar(Prestamo!);
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un prestamo", usuario);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Prestamo = Lista!.FirstOrDefault(x => x.Id_Prestamo == data);
                Lista = null;
                Borrando = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtCerrar()
        {
            OnPostBtRefrescar();
            Borrando = false;
        }
    }
}