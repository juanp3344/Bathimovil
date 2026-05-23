using BibliotecaPresentacion.Implementaciones;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApiPresentacion.Pages
{
    public class MantenimientosModel : PageModel
    {
        private MantenimientosPresentacion? IMantenimientos_Presentacion;
        [BindProperty] public List<Mantenimientos>? Lista { get; set; }
        [BindProperty] public Mantenimientos? Mantenimiento { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public MantenimientosModel()
        {
            IMantenimientos_Presentacion = new MantenimientosPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IMantenimientos_Presentacion == null)
                    return;
                Lista = IMantenimientos_Presentacion.Consultar();
                Mantenimiento = null;
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
                if (Mantenimiento == null)
                    return;
                if (Mantenimiento.Id_Mantenimiento == 0)
                    Mantenimiento = IMantenimientos_Presentacion!.Guardar(Mantenimiento!);
                else
                    Mantenimiento = IMantenimientos_Presentacion!.Modificar(Mantenimiento!);
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
