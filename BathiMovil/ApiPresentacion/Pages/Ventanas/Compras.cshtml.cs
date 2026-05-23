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
        [BindProperty] public int? Cantidad { get; set; }
        [BindProperty] public int? id { get; set; }
        [BindProperty] public List<Compras>? Lista { get; set; }
        [BindProperty] public Compras? Compra { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public bool ConfirmarCantidad { get; set; }

        public ComprasModel()
        {
            ICompras_Presentacion = new ComprasPresentacion();
        }

        public void OnGet(bool nuevo, int dato)
        {
            OnPostBtRefrescar();


            if (nuevo)
            {
                Compra = new Compras();
                ConfirmarCantidad = true;
                id = dato;
            }

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

        public IActionResult OnPostBtAceptar()
        {

         PortatilesPresentacion? IPortatiles_Presentacion;
         IPortatiles_Presentacion = new PortatilesPresentacion();//llamamos a la presentacion de portatiles para el metodo logico

         Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
         ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion(); // necesitamos este para poder realizar el linq y ver de que tipo portatil necesitan comprobar su cantidad

         var Tportatil = ITiposPortatiles_Presentacion.Consultar().FirstOrDefault(p => p.Id_Tipo_Portatil == id); //realizamos linq para el tipo

            var lista = IPortatiles_Presentacion.ComprobarTamanio(Tportatil!).Count; // hacemos el conteo ya con el tipo de portatil aquellos portatiles que son de aquel tipo y que esten disponibles
            if (Cantidad == null || Cantidad <= 0) //si ingresa valores negativos o nulos en el texto del popup no lo dejara pasar
            {
                ModelState.AddModelError("Cantidad", "No puedes ingresar valores incorrectos");
                ConfirmarCantidad = true; 
                return Page();
            } else if(lista < Cantidad) //si no existe la cantidad de ese tipo de portatiles que se quieren, tampoco lo dejara pasar
            {
                ModelState.AddModelError("Cantidad", "No existe esa cantidad para esos baños portatiles");
                ConfirmarCantidad = true;
                return Page();
            }

            return Page(); //ya con todo verificado lo manda a la compra, aunque antes debera definirse el precio segun la cantidad, y el contrato que hace el cliente
        }
    }
}
