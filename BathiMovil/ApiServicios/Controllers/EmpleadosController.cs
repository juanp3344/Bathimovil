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
    public class EmpleadosController : ControllerBase
    {
        private IEmpleadosServicios? IEmpleadosServicios;

       

        public EmpleadosController()
        {
            this.IEmpleadosServicios = new EmpleadosServicios();
        }

        [HttpGet("Consultar")]
        public List<Empleados> Consultar()
        {
            if (this.IEmpleadosServicios == null)
                throw new Exception("No implementado");
            return this.IEmpleadosServicios!.Consultar();
        }

        [HttpPost]
        public Empleados Guardar(Empleados entidad)
        {
            if (this.IEmpleadosServicios == null)
                throw new Exception("No implementado");
            return this.IEmpleadosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Empleados Modificar(Empleados id)
        {
            if (this.IEmpleadosServicios == null)
                throw new Exception("No implementado");
            return this.IEmpleadosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Empleados Eliminar(Empleados id)
        {
            if (this.IEmpleadosServicios == null)
                throw new Exception("No implementado");
            return this.IEmpleadosServicios!.Eliminar(id);
        }

    }
}
