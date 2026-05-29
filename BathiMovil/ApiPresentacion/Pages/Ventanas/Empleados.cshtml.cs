using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class EmpleadosModel : PageModel
    {
        private IEmpleadosPresentacion? IEmpleadosPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        [BindProperty] public List<Empleados>? Lista { get; set; }
        [BindProperty] public Empleados? Empleado { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public EmpleadosModel()
        {
            IEmpleadosPresentacion = new EmpleadosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();

        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public async Task<IActionResult> OnPostExportarPdf()
        {
            var pdf = await IEmpleadosPresentacion!.ExportarPdf();

            return File(
                pdf,
                "application/pdf",
                "Empleados.pdf"
            );
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IEmpleadosPresentacion == null)
                    return;
                Lista = IEmpleadosPresentacion.Consultar();

                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista empleados", usuario);

                Empleado = null;
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
                Empleado = Lista!.FirstOrDefault(x => x.Id_Persona == data);
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

                if (Empleado == null)
                    return;
                if (Empleado.Id_Persona == 0)
                {
                    Empleado = IEmpleadosPresentacion!.Guardar(Empleado!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un empleado", usuario);
                }
                else
                    Empleado = IEmpleadosPresentacion!.Modificar(Empleado!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un empleado", usuario);
                if (Empleado.Id_Persona == 0)
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
                if (Empleado == null)
                    return;
                Empleado = IEmpleadosPresentacion!.Eliminar(Empleado!);
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un empleado", usuario);
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
                Empleado = Lista!.FirstOrDefault(x => x.Id_Persona == data);
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