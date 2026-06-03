using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace ApiPresentacion.Pages
{
    public class AuditoriasModel : PageModel
    {
        private IAuditoriasPresentacion? IAuditoriasPresentacion;
        [BindProperty] public List<Auditorias>? Lista { get; set; }
        [BindProperty] public Auditorias? Auditoria { get; set; }
        [BindProperty] public bool Borrando { get; set; }

        public AuditoriasModel()
        {
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
                if (IAuditoriasPresentacion == null)
                    return;
                Lista = IAuditoriasPresentacion.Consultar();

                var usuario = HttpContext.Session.GetString("Usuario");

                IAuditoriasPresentacion!.Guardar("Bajo", "Se ha consultado a la lista de elementos de aseo", usuario);
                Auditoria = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }


        public async Task<IActionResult> OnPostExportarPdf()
        {
            var pdf = await IAuditoriasPresentacion!.ExportarPdf();

            return File(
                pdf,
                "application/pdf",
                "Auditorias.pdf"
            );
        }



    }
}