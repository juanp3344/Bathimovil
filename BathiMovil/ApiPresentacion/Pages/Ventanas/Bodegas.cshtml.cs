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
        private IEmpleadosPresentacion? IEmpleadosPresentacion;
        private ISedesPresentacion? ISedesPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        [BindProperty] public List<Bodegas>? Lista { get; set; }
        [BindProperty] public List<Empleados>? Empleados { get; set; }
        [BindProperty] public List<Sedes>? Sedes { get; set; }
        [BindProperty] public Bodegas? Bodega { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public BodegasModel()
        {
            IBodegasPresentacion = new BodegasPresentacion();
            ISedesPresentacion = new SedesPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public List<Empleados> CargarEmpleados()
        {
            return Empleados = IEmpleadosPresentacion!.Consultar();
        }

        public List<Sedes> CargarSedes()
        {
            return Sedes = ISedesPresentacion!.Consultar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IBodegasPresentacion == null)
                    return;
                Lista = IBodegasPresentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista bodegas", usuario);

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
                var usuario = HttpContext.Session.GetString("Usuario");
                if (Bodega == null)
                    return;
                if (Bodega.Id_Bodega == 0)
                {
                    Bodega = IBodegasPresentacion!.Guardar(Bodega!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado una bodega", usuario);
                }
                else
                    Bodega = IBodegasPresentacion!.Modificar(Bodega!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a una bodega", usuario);
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
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado una bodega", usuario);
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