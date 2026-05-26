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
        private ComprasPresentacion? ICompras_Presentacion;
        [BindProperty] public List<Compras>? Lista { get; set; }
        [BindProperty] public Compras? Compra { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public bool VienePorCompra { get; set; }
        [BindProperty] public bool ConfirmarCompra{ get; set; }
        [BindProperty] public int Cantidad { get; set; }
        [BindProperty] public int TPortatil { get; set; }

        public bool MostrarConfirmacionSalida { get; set; } = false;
        public ComprasModel()
        {
            ICompras_Presentacion = new ComprasPresentacion();
        }

        public void OnGet(bool nuevo, int Id_Contrato, int CantidadCalculo, int Portatil) // por si viene de contrato para compra, entonces recibira estos valores 
        {

            Cantidad = CantidadCalculo;

            TPortatil = Portatil;

            if (nuevo)
            {
                Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
                ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion(); // necesitamos este para poder realizar el linq y ver de que tipo portatil necesitan comprobar su cantidad

                var Tportatil = ITiposPortatiles_Presentacion.Consultar().FirstOrDefault(p => p.Id_Tipo_Portatil == Portatil); 

                var ValorTotal = CantidadCalculo * Tportatil!.Precio_Actual; //realiza el calculo dependiendo de los portatiles que pidio  el cliente  el tipo que requirio

                VienePorCompra = nuevo;
                Compra = new Compras()
                {
                    Fecha_Compra = DateTime.Now,
                    Monto_Total = ValorTotal,
                    Garantia_Meses = 12,
                    Contrato = Id_Contrato

                };

                return;
            }
            OnPostBtRefrescar();

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
                if (Compra == null)
                    return;
                if (Compra.Id_Compra == 0)
                    Compra = ICompras_Presentacion!.Guardar(Compra!);
                else
                    Compra = ICompras_Presentacion!.Modificar(Compra!);
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
