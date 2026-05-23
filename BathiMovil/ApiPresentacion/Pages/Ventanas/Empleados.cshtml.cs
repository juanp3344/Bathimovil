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
        [BindProperty] public List<Empleados>? Lista { get; set; }
        [BindProperty] public Empleados? Empleado { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public EmpleadosModel()
        {
            IEmpleadosPresentacion = new EmpleadosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IEmpleadosPresentacion == null)
                    return;
                Lista = IEmpleadosPresentacion.Consultar();
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
                if (Empleado == null)
                    return;
                if (Empleado.Id_Persona == 0)
                    Empleado = IEmpleadosPresentacion!.Guardar(Empleado!);
                else
                    Empleado = IEmpleadosPresentacion!.Modificar(Empleado!);
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