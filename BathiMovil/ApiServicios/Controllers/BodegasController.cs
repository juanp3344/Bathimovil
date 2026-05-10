using Biblioteca.Entidades;
using Biblioteca.Implementaciones;
using Biblioteca.Interfaces;
using Biblioteca.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodegasController : ControllerBase
    {
        private IBodegasServicios? IBodegasServicios;


        public BodegasController()
        {
            this.IBodegasServicios = new BodegasServicios();
        }

        [HttpGet("Consultar")]
        public List<Bodegas> Consultar()
        {
            if (this.IBodegasServicios == null)
                throw new Exception("No implementado");
            return this.IBodegasServicios!.Consultar();
        }

        [HttpPost]
        public Bodegas Guardar(Bodegas entidad)
        {
            if (this.IBodegasServicios == null)
                throw new Exception("No implementado");
            return this.IBodegasServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Bodegas Modificar(Bodegas id)
        {
            if (this.IBodegasServicios == null)
                throw new Exception("No implementado");
            return this.IBodegasServicios!.Modificar(id);
        }

        [HttpDelete]

        public Bodegas Eliminar(Bodegas id)
        {
            if (this.IBodegasServicios == null)
                throw new Exception("No implementado");
            return this.IBodegasServicios!.Eliminar(id);
        }

    }
}
