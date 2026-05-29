using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class PortatilesModel : PageModel
    {
        private IPortatilesPresentacion? IPortatiles_Presentacion;
        private ISedesPresentacion? ISedesPresentacion;
        private ITipos_PortatilesPresentacion? ITipos_PortatilesPresentacion;
        private IComprasPresentacion? IComprasPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        private IPermisosPresentacion? IPermisosPresentacion;

        [BindProperty] public List<Portatiles>? Lista { get; set; }
        [BindProperty] public Portatiles? Portatil { get; set; }
        [BindProperty] public bool Borrando { get; set; }
        [BindProperty] public bool ErrorRol { get; set; }

        public PortatilesModel()
        {
            IPortatiles_Presentacion = new PortatilesPresentacion();
            ISedesPresentacion = new SedesPresentacion();
            ITipos_PortatilesPresentacion = new Tipos_PortatilesPresentacion();
            IComprasPresentacion = new ComprasPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
            IPermisosPresentacion = new PermisosPresentacion();

        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }
        public void OnPostBtVolver()
        {
            OnPostBtRefrescar();
        }
        public List<Sedes> CargarSedes()
        {
            return ISedesPresentacion!.Consultar();
        }
        public List<Tipos_Portatiles> CargarTipos()
        {
            return ITipos_PortatilesPresentacion!.Consultar();
        }
        public List<Compras> CargarCompras()
        {
            return IComprasPresentacion!.Consultar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                if (IPortatiles_Presentacion == null)
                    return;
                Lista = IPortatiles_Presentacion.Consultar();
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista portatiles", usuario);
                Portatil = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            var permiso = new Permisos
            {
                Nombre_Permiso = "GUARDAR_PORTATILES"
            };
            var Permiso = IPermisosPresentacion!.ComprobarPermiso(permiso);
            var id_rol = HttpContext.Session.GetInt32("Rol");
            if (Permiso.Rol != id_rol)
            {
                ErrorRol = true;

            }

        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                var permiso = new Permisos
                {
                    Nombre_Permiso = "MODIFICAR_PORTATILES"
                };
                var Permiso = IPermisosPresentacion!.ComprobarPermiso(permiso);
                var id_rol = HttpContext.Session.GetInt32("Rol");
                if (Permiso.Rol != id_rol)
                {
                    ErrorRol = true;

                }
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
                var usuario = HttpContext.Session.GetString("Usuario");
                if (Portatil == null)
                    return;
                if (Portatil.Id_Portatil == 0)
                {
                    Portatil = IPortatiles_Presentacion!.Guardar(Portatil!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un baño Portatil", usuario);
                }
                else
                    Portatil = IPortatiles_Presentacion!.Modificar(Portatil!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un baño Portatil", usuario);
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

                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un baño Portatil", usuario);
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
                    Nombre_Permiso = "ELIMINAR_PORTATILES"
                };
                var Permiso = IPermisosPresentacion!.ComprobarPermiso(permiso);
                var id_rol = HttpContext.Session.GetInt32("Rol");
                if (Permiso.Rol != id_rol)
                {
                    ErrorRol = true;
                    return;
                }
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
