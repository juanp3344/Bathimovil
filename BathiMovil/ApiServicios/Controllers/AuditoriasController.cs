using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControllerBase
    {
        private IAuditoriasServicios? IAuditoriasServicios;
        private readonly IPdfServicios _pdfServicio;

        public AuditoriasController()
        {
            this.IAuditoriasServicios = new AuditoriasServicios();
            this._pdfServicio = new PdfServicios();
        }

        [HttpPost]
        public Auditorias Guardar(Auditorias entidad)
        {
            if (this.IAuditoriasServicios == null)
                throw new Exception("No implementado");
            return this.IAuditoriasServicios!.Guardar(entidad);
        }

        [HttpGet]
        public List<Auditorias> Consultar()
        {
            if (this.IAuditoriasServicios == null)
                throw new Exception("No implementado");
            return this.IAuditoriasServicios!.Consultar();
        }

        [HttpGet]
        public IActionResult ExportarPdf()
        {
            var lista = IAuditoriasServicios!.Consultar();

            var pdf = _pdfServicio.GenerarPdf(lista, "Reporte auditorias");

            return File(
                pdf,
                "application/pdf",
                "Auditorias.pdf"
            );
        }

    }
}
