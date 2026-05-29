using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MantenimientosController : ControllerBase
    {
        private IMantenimientosServicios? IMantenimientosServicios;

        private readonly IPdfServicios _pdfServicio;

        public MantenimientosController()
        {
            this.IMantenimientosServicios = new MantenimientosServicios();
            this._pdfServicio = new PdfServicios();
        }

        [HttpGet]
        public List<Mantenimientos> Consultar()
        {
            if (this.IMantenimientosServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientosServicios!.Consultar();
        }

        [HttpPost]
        public Mantenimientos Guardar(Mantenimientos entidad)
        {
            if (this.IMantenimientosServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Mantenimientos Modificar(Mantenimientos id)
        {
            if (this.IMantenimientosServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientosServicios!.Modificar(id);
        }

        [HttpDelete]
        public Mantenimientos Eliminar([FromBody] Mantenimientos id)
        {
            if (this.IMantenimientosServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientosServicios!.Eliminar(id);
        }

        [HttpGet]
        public IActionResult ExportarPdf()
        {
            var lista = IMantenimientosServicios!.Consultar();

            var pdf = _pdfServicio.GenerarPdf(lista, "Reporte Mantenimientos");

            return File(
                pdf,
                "application/pdf",
                "Mantenimientos.pdf"
            );
        }
    }
}
