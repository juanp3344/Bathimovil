using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Historial_PreciosController : ControllerBase
    {
        private IHistorial_PreciosServicios? IHistorial_PreciosServicios;

       

        public Historial_PreciosController()
        {
            this.IHistorial_PreciosServicios = new Historial_PreciosServicios();
        }

        [HttpGet("Consultar")]
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

    }
}
