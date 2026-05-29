using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class MantenimientosModel : PageModel
    {
        private IMantenimientosPresentacion? IMantenimientos_Presentacion;
        private IPortatilesPresentacion? IPortatilesPresentacion;
        private IEmpleadosPresentacion? IEmpleadosPresentacion;
        private IPrestamosPresentacion? IPrestamosPresentacion;
        private IPermisosPresentacion? IPermisosPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;

        [BindProperty] public List<Mantenimientos>? Lista { get; set; }
        [BindProperty] public Mantenimientos? Mantenimiento { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public bool ErrorRol { get; set; }


        public MantenimientosModel()
        {
            IMantenimientos_Presentacion = new MantenimientosPresentacion();
            IPortatilesPresentacion = new PortatilesPresentacion();
            IEmpleadosPresentacion = new EmpleadosPresentacion();
            IPrestamosPresentacion = new PrestamosPresentacion();
            IPermisosPresentacion = new PermisosPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }
        public List<Portatiles> CargarPortatiles()
        {

            return IPortatilesPresentacion!.Consultar();
        }
        public List<Prestamos> CargarPrestamos()
        {
            return IPrestamosPresentacion!.Consultar();
        }
        public List<Empleados> CargarEmpleados()
        {
            return IEmpleadosPresentacion!.Consultar();

        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IMantenimientos_Presentacion == null)
                    return;
                Lista = IMantenimientos_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista mantenimientos", usuario);
                Mantenimiento = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtVolver()
        {
            OnPostBtRefrescar();
        }

    

        public void OnPostBtModificar(int data)
        {
            try
            {
                var permiso = new Permisos
                {
                    Nombre_Permiso = "MODIFICAR_MANTENIMIENTO"
                };
                var Permiso = IPermisosPresentacion!.ComprobarPermiso(permiso);
                var id_rol = HttpContext.Session.GetInt32("Rol");
                if (Permiso.Rol != id_rol)
                {
                    ErrorRol = true;
                    return;
                }
                OnPostBtRefrescar();
                Mantenimiento = Lista!.FirstOrDefault(x => x.Id_Mantenimiento == data);
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
                if (Mantenimiento == null)
                    return;
                if (Mantenimiento.Id_Mantenimiento == 0)
                {
                   
                    Mantenimiento = IMantenimientos_Presentacion!.Guardar(Mantenimiento!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un Mantenimiento", usuario);

                }
                else
                    Mantenimiento = IMantenimientos_Presentacion!.Modificar(Mantenimiento!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un Mantenimiento", usuario);

                if (Mantenimiento.Id_Mantenimiento == 0)
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
                if (Mantenimiento == null)
                    return;
                Mantenimiento = IMantenimientos_Presentacion!.Eliminar(Mantenimiento!);
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un Mantenimiento", usuario);
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
                var permiso = new Permisos
                {
                    Nombre_Permiso = "ELIMINAR_MANTENIMIENTO"
                };
                var Permiso = IPermisosPresentacion!.ComprobarPermiso(permiso);
                var id_rol = HttpContext.Session.GetInt32("Rol");
                if (Permiso.Rol != id_rol)
                {
                    ErrorRol = true;
                    return;
                }
                OnPostBtRefrescar();
                Mantenimiento = Lista!.FirstOrDefault(x => x.Id_Mantenimiento == data);
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
