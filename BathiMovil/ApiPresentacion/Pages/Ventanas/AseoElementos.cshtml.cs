using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class AseoElementosModel : PageModel
    {
        private IAseo_ElementosPresentacion? IAseo_ElementosPresentacion;
        private ITipo_Aseo_ElementosPresentacion? ITipo_Aseo_ElementosPresentacion;
        private IMantenimientosPresentacion? IMantenimientosPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        [BindProperty] public List<Aseo_Elementos>? Lista { get; set; }
        [BindProperty] public Aseo_Elementos? Aseo_Elemento { get; set; }
        [BindProperty] public List<Tipo_Aseo_Elementos>? Tipo_Aseo_Elementos { get; set; }
        [BindProperty] public List<Mantenimientos>? Mantenimientos { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public AseoElementosModel()
        {
            IAseo_ElementosPresentacion = new Aseo_ElementosPresentacion();
            ITipo_Aseo_ElementosPresentacion = new Tipo_Aseo_ElementosPresentacion();
            IMantenimientosPresentacion = new MantenimientosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public List<Tipo_Aseo_Elementos> CargarTiposAseo()
        {
            return Tipo_Aseo_Elementos = ITipo_Aseo_ElementosPresentacion!.Consultar();
        }

        public List<Mantenimientos> CargarMantenimientos()
        {
            return Mantenimientos = IMantenimientosPresentacion!.Consultar();
        }




        public void OnPostBtRefrescar()
        {
            try
            {
                if (IAseo_ElementosPresentacion == null)
                    return;
                Lista = IAseo_ElementosPresentacion.Consultar();

                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista de elementos de aseo", usuario);
                Aseo_Elemento = null;
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
                Aseo_Elemento = Lista!.FirstOrDefault(x => x.Id_Aseo_Elemento == data);
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
                if (Aseo_Elemento == null)
                    return;
                if (Aseo_Elemento.Id_Aseo_Elemento == 0)
                {
                    Aseo_Elemento = IAseo_ElementosPresentacion!.Guardar(Aseo_Elemento!);
                    IAuditoriasPresentacion!.Guardar("Medi", "Se ha guardado un elemento de aseo", usuario);
                }
                else
                    Aseo_Elemento = IAseo_ElementosPresentacion!.Modificar(Aseo_Elemento!);
                    IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un elemento de aseo", usuario);
                if (Aseo_Elemento.Id_Aseo_Elemento == 0)
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
                if (Aseo_Elemento == null)
                    return;
                Aseo_Elemento = IAseo_ElementosPresentacion!.Eliminar(Aseo_Elemento!);
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un elemento de aseo", usuario);
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
                Aseo_Elemento = Lista!.FirstOrDefault(x => x.Id_Aseo_Elemento == data);
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