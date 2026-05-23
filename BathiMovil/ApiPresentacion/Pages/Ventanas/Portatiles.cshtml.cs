using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class PortatilesModel : PageModel
    {
        private PortatilesPresentacion? IPortatiles_Presentacion;
        [BindProperty] public List<Portatiles>? Lista { get; set; }
        [BindProperty] public Portatiles? Portatil { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public PortatilesModel()
        {
            IPortatiles_Presentacion = new PortatilesPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IPortatiles_Presentacion == null)
                    return;
                Lista = IPortatiles_Presentacion.Consultar();
                Portatil = null;
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
                Portatil = Lista!.FirstOrDefault(x => x.Id_Portatil == data);
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
                if (Portatil == null)
                    return;
                if (Portatil.Id_Portatil == 0)
                    Portatil = IPortatiles_Presentacion!.Guardar(Portatil!);
                else
                    Portatil = IPortatiles_Presentacion!.Modificar(Portatil!);
                if (Portatil.Id_Portatil == 0)
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
                if (Portatil == null)
                    return;
                Portatil = IPortatiles_Presentacion!.Eliminar(Portatil!);
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
                Portatil = Lista!.FirstOrDefault(x => x.Id_Portatil == data);
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
