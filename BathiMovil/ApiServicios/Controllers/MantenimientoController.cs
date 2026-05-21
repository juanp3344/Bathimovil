using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MantenimientossController : ControllerBase
    {
        private IMantenimientosServicios? IMantenimientosServicios;



        public MantenimientossController()
        {
            this.IMantenimientosServicios = new MantenimientosServicios();
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

        public Mantenimientos Eliminar(Mantenimientos id)
        {
            if (this.IMantenimientosServicios == null)
                throw new Exception("No implementado");
            return this.IMantenimientosServicios!.Eliminar(id);
        }

    }
}
