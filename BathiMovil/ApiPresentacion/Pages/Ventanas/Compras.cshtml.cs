using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class ComprasModel : PageModel
    {
        private ComprasPresentacion? ICompras_Presentacion;
        [BindProperty] public List<Compras>? Lista { get; set; }
        [BindProperty] public Compras? Compra { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public ComprasModel()
        {
            ICompras_Presentacion = new ComprasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
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
    }
}
