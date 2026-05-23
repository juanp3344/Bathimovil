using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class Tipo_Aseo_ElementosModel : PageModel
    {
        private Tipo_Aseo_ElementosPresentacion? ITipo_Aseo_Elementos_Presentacion;
        [BindProperty] public List<Tipo_Aseo_Elementos>? Lista { get; set; }
        [BindProperty] public Tipo_Aseo_Elementos? Tipo_Aseo_Elemento { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public Tipo_Aseo_ElementosModel()
        {
            ITipo_Aseo_Elementos_Presentacion = new Tipo_Aseo_ElementosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (ITipo_Aseo_Elementos_Presentacion == null)
                    return;
                Lista = ITipo_Aseo_Elementos_Presentacion.Consultar();
                Tipo_Aseo_Elemento = null;
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
                Tipo_Aseo_Elemento = Lista!.FirstOrDefault(x => x.Id_Tipo_Aseo_Elemento == data);
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
                if (Tipo_Aseo_Elemento == null)
                    return;
                if (Tipo_Aseo_Elemento.Id_Tipo_Aseo_Elemento == 0)
                    Tipo_Aseo_Elemento = ITipo_Aseo_Elementos_Presentacion!.Guardar(Tipo_Aseo_Elemento!);
                else
                    Tipo_Aseo_Elemento = ITipo_Aseo_Elementos_Presentacion!.Modificar(Tipo_Aseo_Elemento!);
                if (Tipo_Aseo_Elemento.Id_Tipo_Aseo_Elemento == 0)
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
                if (Tipo_Aseo_Elemento == null)
                    return;
                Tipo_Aseo_Elemento = ITipo_Aseo_Elementos_Presentacion!.Eliminar(Tipo_Aseo_Elemento!);
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
                Tipo_Aseo_Elemento = Lista!.FirstOrDefault(x => x.Id_Tipo_Aseo_Elemento == data);
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
