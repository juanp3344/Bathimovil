using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class TiposPortatilesModel : PageModel
    {
        private Tipos_PortatilesPresentacion? ITiposPortatiles_Presentacion;
        [BindProperty] public List<Tipos_Portatiles>? Lista { get; set; }
        [BindProperty] public Tipos_Portatiles? Tipos_Portatiles { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public TiposPortatilesModel()
        {
            ITiposPortatiles_Presentacion = new Tipos_PortatilesPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (ITiposPortatiles_Presentacion == null)
                    return;
                Lista = ITiposPortatiles_Presentacion.Consultar();
                Tipos_Portatiles = null;
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
                Tipos_Portatiles = Lista!.FirstOrDefault(x => x.Id_Tipo_Portatil == data);
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
                if (Tipos_Portatiles == null)
                    return;
                if (Tipos_Portatiles.Id_Tipo_Portatil == 0)
                    Tipos_Portatiles = ITiposPortatiles_Presentacion!.Guardar(Tipos_Portatiles!);
                else
                    Tipos_Portatiles = ITiposPortatiles_Presentacion!.Modificar(Tipos_Portatiles!);
                if (Tipos_Portatiles.Id_Tipo_Portatil == 0)
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
                if (Tipos_Portatiles == null)
                    return;
                Tipos_Portatiles = ITiposPortatiles_Presentacion!.Eliminar(Tipos_Portatiles!);
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
                Tipos_Portatiles = Lista!.FirstOrDefault(x => x.Id_Tipo_Portatil == data);
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
