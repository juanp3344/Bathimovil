using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ApiPresentacion.Pages
{
    public class ComprasModel : PageModel
    {
        private IComprasPresentacion? ICompras_Presentacion;
        private IContratosPresentacion? IContratosPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Compras>? Lista { get; set; }
        [BindProperty] public Compras? Compra { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public bool VienePorCompra { get; set; }
        [BindProperty] public bool ConfirmarCompra{ get; set; }
        [BindProperty] public int Cantidad { get; set; }
        [TempData] public int TPortatil { get; set; }
        [TempData] public bool EnCompra { get; set; }


        public bool MostrarConfirmacionSalida { get; set; } = false;
        public ComprasModel()
        {
            ICompras_Presentacion = new ComprasPresentacion();
            IContratosPresentacion = new ContratosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();

        }

        public void OnGet() // por si viene de contrato para compra, entonces recibira estos valores 
        {
            if (EnCompra)
            {
                int idContrato = (int)TempData["Id_Contrato"]!;
                int cantidadCalculo = (int)TempData["TDCantidad"]!;
                int portatil = (int)TempData["Id_Portatil"]!;


                Cantidad = cantidadCalculo;

                TPortatil = portatil;

                Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
                ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion();

                var Tportatil = ITiposPortatiles_Presentacion.Consultar()
                    .FirstOrDefault(p => p.Id_Tipo_Portatil == portatil);

                var ValorTotal = cantidadCalculo * Tportatil!.Precio_Actual;

                VienePorCompra = true;
                Compra = new Compras()
                {
                    Fecha_Compra = DateTime.Now,
                    Monto_Total = ValorTotal,
                    Garantia_Meses = 12,
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


        public void OnPostBtComprar()
        {
            try
            {
                PortatilesPresentacion? IPortatiles_Presentacion;
                IPortatiles_Presentacion = new PortatilesPresentacion();

                // Traer todos los portátiles libres del tipo seleccionado
                var portatiles = IPortatiles_Presentacion.Consultar()
                    .Where(p => p.Tipo_Portatil == TPortatil && p.Estado_Actual == "Libre")
                    .Take(Cantidad)
                    .ToList();
                ConfirmarCompra = true;
                OnPostBtGuardar();
                // Cambiar estado a "en proceso"
                foreach (var portatil in portatiles)
                {
                    portatil.Estado_Actual = "en proceso";
                    portatil.Compra = Compra!.Id_Compra;
                    IPortatiles_Presentacion.Modificar(portatil);
                }

                
                ConfirmarCompra = true;
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
                if (ICompras_Presentacion == null)
                    return;
                Lista = ICompras_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista clientes", usuario);


                Compra = null;
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
                Compra = Lista!.FirstOrDefault(x => x.Id_Compra == data);
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

                if (Compra == null)
                    return;
                if (Compra.Id_Compra == 0)
                {
                    Compra = ICompras_Presentacion!.Guardar(Compra!);

                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado una compra", usuario);
                }

                else
                    Compra = ICompras_Presentacion!.Modificar(Compra!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a una compra", usuario);
                if (Compra.Id_Compra == 0)
                    return;
                if (ConfirmarCompra)
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
                if (Compra == null)
                    return;
                Compra = ICompras_Presentacion!.Eliminar(Compra!);
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un cliente", usuario);
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
                Compra = Lista!.FirstOrDefault(x => x.Id_Compra == data);
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
