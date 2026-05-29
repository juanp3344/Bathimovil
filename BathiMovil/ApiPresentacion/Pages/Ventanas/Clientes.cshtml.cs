using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class ClientesModel : PageModel
    {
        private IClientesPresentacion? IClientesPresentacion;
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        [BindProperty] public List<Clientes>? Lista { get; set; }
        [BindProperty] public Clientes? Cliente { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public ClientesModel()
        {
            IClientesPresentacion = new ClientesPresentacion();
            IAuditoriasPresentacion = new AuditoriasPresentacion();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                if (IClientesPresentacion == null)
                    return;
                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista clientes", usuario);
                Lista = IClientesPresentacion.Consultar();
                Cliente = null;
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
                Cliente = Lista!.FirstOrDefault(x => x.Id_Persona == data);
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
                if (Cliente == null)
                    return;
                if (Cliente.Id_Persona == 0)
                {
                    Cliente = IClientesPresentacion!.Guardar(Cliente!);
                    IAuditoriasPresentacion!.Guardar("Medio", "Se ha guardado un cliente", usuario);
                }
                else
                    Cliente = IClientesPresentacion!.Modificar(Cliente!);
                IAuditoriasPresentacion!.Guardar("Alto", "Se ha modificado a un cliente", usuario);
                if (Cliente.Id_Persona == 0)
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
                if (Cliente == null)
                    return;
                Cliente = IClientesPresentacion!.Eliminar(Cliente!);
                var usuario = HttpContext.Session.GetString("Usuario");
                IAuditoriasPresentacion!.Guardar("medio/alto", "Se ha eliminado un cliente", usuario);

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
                Cliente = Lista!.FirstOrDefault(x => x.Id_Persona == data);
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