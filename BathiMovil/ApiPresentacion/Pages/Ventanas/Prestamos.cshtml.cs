using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class PrestamosModel : PageModel
    {
        private IPrestamosPresentacion? IPrestamos_Presentacion;
        private IContratosPresentacion? IContratosPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        private IPortatilesPresentacion? IPortatilesPresentacion;

        [BindProperty] public List<Prestamos>? Lista { get; set; }
        [BindProperty] public Prestamos? Prestamo { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public bool VienePorPrestamo { get; set; }
        [BindProperty] public bool ConfirmarPrestamo { get; set; }
        [BindProperty] public int Cantidad { get; set; }
        [BindProperty] public string? DireccionEntrega { get; set; }
        [BindProperty] public string? CiudadEntrega { get; set; }
        [TempData] public int TPortatil { get; set; }
        [TempData] public bool EnPrestamo { get; set; }

        public PrestamosModel()
        {
            IPrestamos_Presentacion = new PrestamosPresentacion();
            IContratosPresentacion = new ContratosPresentacion();
            IPortatilesPresentacion = new PortatilesPresentacion();
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
                    Fecha_Fin_Prevista = DateTime.Now.AddMonths(1),
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

        public List<Portatiles> CargarPortatiles()
        {
            return IPortatilesPresentacion!.Consultar()
                .Where(p => p.Estado_Actual == "Libre")
                .ToList();
        }

        public void OnPostBtPrestar()
        {
            try
            {
                var portatiles = IPortatilesPresentacion!.Consultar()
                    .Where(p => p.Tipo_Portatil == TPortatil && p.Estado_Actual == "Libre")
                    .Take(Cantidad)
                    .ToList();

                if (portatiles == null || portatiles.Count == 0)
                {
                    ViewData["Mensaje"] = "No hay portátiles libres para prestar.";
                    return;
                }

                // Assign a valid Portatil FK so the Prestamo save does not try to insert Portatil=0
                Prestamo ??= new Prestamos()
                {
                    Fecha_Inicio = DateTime.Now,
                    Fecha_Fin_Prevista = DateTime.Now.AddMonths(1),
                    Estado_Prestamo = true,
                    Contrato = Prestamo?.Contrato ?? 0
                };

                Prestamo.Portatil = portatiles.First().Id_Portatil;

                ConfirmarPrestamo = true;
                OnPostBtGuardar();

                foreach (var portatil in portatiles)
                {
                    portatil.Estado_Actual = "En préstamo";
                    // Do not assign Prestamo Id into Compra (Compra references Compras.Id_Compra)
                    IPortatilesPresentacion.Modificar(portatil);
                }

                if (!string.IsNullOrWhiteSpace(DireccionEntrega))
                {
                    var iUbicaciones = new UbicacionesPresentacion();
                    foreach (var portatil in portatiles)
                    {
                        iUbicaciones.Guardar(new Ubicaciones
                        {
                            Direccion = DireccionEntrega,
                            Ciudad = string.IsNullOrWhiteSpace(CiudadEntrega)
                                            ? "Colombia"
                                            : CiudadEntrega,
                            Portatil = portatil.Id_Portatil
                        });
                    }
                }

                ConfirmarPrestamo = true;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
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
                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado la lista de Prestamos", usuario);
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
                if (Prestamo.Id_Prestamo == 0)
                {
                    Prestamo = IPrestamos_Presentacion!.Guardar(Prestamo!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un Prestamo", usuario);
                }
                else
                    Prestamo = IPrestamos_Presentacion!.Modificar(Prestamo!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado un Prestamo", usuario);
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
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un Prestamo", usuario);
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
