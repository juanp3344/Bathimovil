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
    public class Historial_PreciosController : ControllerBase
    {
        private IHistorial_PreciosServicios? IHistorial_PreciosServicios;

        private readonly IPdfServicios _pdfServicio;

        public Historial_PreciosController()
        {
            this.IHistorial_PreciosServicios = new Historial_PreciosServicios();
            this._pdfServicio = new PdfServicios();
        }

        [HttpGet]
        public List<Historial_Precios> Consultar()
        {
            if (this.IHistorial_PreciosServicios == null)
                throw new Exception("No implementado");
            return this.IHistorial_PreciosServicios!.Consultar();
        }

        [HttpPost]
        public Historial_Precios Guardar(Historial_Precios entidad)
        {
            if (this.IHistorial_PreciosServicios == null)
                throw new Exception("No implementado");
            return this.IHistorial_PreciosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Historial_Precios Modificar(Historial_Precios id)
        {
            if (this.IHistorial_PreciosServicios == null)
                throw new Exception("No implementado");
            return this.IHistorial_PreciosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Historial_Precios Eliminar(Historial_Precios id)
        {
            if (this.IHistorial_PreciosServicios == null)
                throw new Exception("No implementado");
            return this.IHistorial_PreciosServicios!.Eliminar(id);
        }

        [HttpGet]
        public IActionResult ExportarPdf()
        {
            var lista = IHistorial_PreciosServicios!.Consultar();

            var pdf = _pdfServicio.GenerarPdf(lista, "Reporte Historial Precios");

            return File(
                pdf,
                "application/pdf",
                "Historial Precios.pdf"
            );
        }

    }
}
