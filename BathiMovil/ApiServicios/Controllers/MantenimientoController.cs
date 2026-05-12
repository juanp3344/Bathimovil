using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MantenimientoController : ControllerBase
    {
        private IMantenimientoServicios? IMantenimientoServicios;



        public MantenimientoController()
        {
            this.IMantenimientoServicios = new MantenimientoServicios();
        }

        [HttpGet("Consultar")]
        public List<Mantenimiento> Consultar()
        {
            if (this.IMantenimientoServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientoServicios!.Consultar();
        }

        [HttpPost]
        public Mantenimiento Guardar(Mantenimiento entidad)
        {
            if (this.IMantenimientoServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientoServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Mantenimiento Modificar(Mantenimiento id)
        {
            if (this.IMantenimientoServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientoServicios!.Modificar(id);
        }

        [HttpDelete]

        public Mantenimiento Eliminar(Mantenimiento id)
        {
            if (this.IMantenimientoServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientoServicios!.Eliminar(id);
        }

    }
}
