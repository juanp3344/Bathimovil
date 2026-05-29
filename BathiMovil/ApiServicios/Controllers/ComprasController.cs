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
    public class ComprasController : ControllerBase
    {
        private IComprasServicios? IComprasServicios;

        private readonly IPdfServicios _pdfServicio;

        public ComprasController()
        {
            this.IComprasServicios = new ComprasServicios();
            this._pdfServicio = new PdfServicios();
        }

        [HttpGet]
        public List<Compras> Consultar()
        {
            if (this.IComprasServicios == null)
                throw new Exception("No implementado");
            return this.IComprasServicios!.Consultar();
        }

        [HttpPost]
        public Compras Guardar(Compras entidad)
        {
            if (this.IComprasServicios == null)
                throw new Exception("No implementado");
            return this.IComprasServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Compras Modificar(Compras id)
        {
            if (this.IComprasServicios == null)
                throw new Exception("No implementado");
            return this.IComprasServicios!.Modificar(id);
        }

        [HttpDelete]

        public Compras Eliminar(Compras id)
        {
            if (this.IComprasServicios == null)
                throw new Exception("No implementado");
            return this.IComprasServicios!.Eliminar(id);
        }
        [HttpGet]
        public IActionResult ExportarPdf()
        {
            var lista = IComprasServicios!.Consultar();

            var pdf = _pdfServicio.GenerarPdf(lista, "Reporte Compras");

            return File(
                pdf,
                "application/pdf",
                "compras.pdf"
            );
        }

    }
}
