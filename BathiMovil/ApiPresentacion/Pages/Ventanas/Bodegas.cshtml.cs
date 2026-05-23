using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class BodegasModel : PageModel
    {
        private IBodegasPresentacion? IBodegasPresentacion;
        [BindProperty] public List<Bodegas>? Lista { get; set; }
        [BindProperty] public Bodegas? Bodega { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public BodegasModel()
        {
            IBodegasPresentacion = new BodegasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IBodegasPresentacion == null)
                    return;
                Lista = IBodegasPresentacion.Consultar();
                Bodega = null;
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
                Bodega = Lista!.FirstOrDefault(x => x.Id_Bodega == data);
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
                if (Bodega == null)
                    return;
                if (Bodega.Id_Bodega == 0)
                    Bodega = IBodegasPresentacion!.Guardar(Bodega!);
                else
                    Bodega = IBodegasPresentacion!.Modificar(Bodega!);
                if (Bodega.Id_Bodega == 0)
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
                if (Bodega == null)
                    return;
                Bodega = IBodegasPresentacion!.Eliminar(Bodega!);
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
                Bodega = Lista!.FirstOrDefault(x => x.Id_Bodega == data);
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