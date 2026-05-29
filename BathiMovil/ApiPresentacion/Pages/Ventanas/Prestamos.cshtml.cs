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
        private IPortatilesPresentacion? IPortatiles_Presentacion;
        private ITipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
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
            IPortatiles_Presentacion = new PortatilesPresentacion();
            ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion();
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

        public void OnPostBtPrestar()
        {
            try
            {
                ConfirmarPrestamo = true;
                OnPostBtGuardar();

                var portatiles = IPortatiles_Presentacion!.Consultar()
                    .Where(p => p.Tipo_Portatil == TPortatil && p.Estado_Actual == "Libre")
                    .Take(Cantidad)
                    .ToList();

                foreach (var portatil in portatiles)
                {
                    portatil.Estado_Actual = "En préstamo";
                    portatil.Compra = Prestamo!.Id_Prestamo;
                    IPortatiles_Presentacion.Modificar(portatil);
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
                if (Prestamo == null) return;

                if (Prestamo.Id_Prestamo == 0)
                {
                    Prestamo = IPrestamos_Presentacion!.Guardar(Prestamo!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un Prestamo", usuario);
                }
                else
                {
                    Prestamo = IPrestamos_Presentacion!.Modificar(Prestamo!);
                    IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado un Prestamo", usuario);
                }

                if (Prestamo.Id_Prestamo == 0) return;
                if (ConfirmarPrestamo) return;
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
                if (Prestamo == null) return;
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