using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Roles_EmpleadosController : ControllerBase
    {
        private IRoles_EmpleadosServicios? IRoles_EmpleadosServicios;



        public Roles_EmpleadosController()
        {
            this.IRoles_EmpleadosServicios = new Roles_EmpleadosServicios();
        }

        [HttpGet]
        public List<Roles_Empleados> Consultar()
        {
            if (this.IRoles_EmpleadosServicios == null)
                throw new Exception("No implementado");
            return this.IRoles_EmpleadosServicios!.Consultar();
        }

        [HttpPost]
        public Roles_Empleados Guardar(Roles_Empleados entidad)
        {
            if (this.IRoles_EmpleadosServicios == null)
                throw new Exception("No implementado");
            return this.IRoles_EmpleadosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Roles_Empleados Modificar(Roles_Empleados id)
        {
            if (this.IRoles_EmpleadosServicios == null)
                throw new Exception("No implementado");
            return this.IRoles_EmpleadosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Roles_Empleados Eliminar(Roles_Empleados id)
        {
            if (this.IRoles_EmpleadosServicios == null)
                throw new Exception("No implementado");
            return this.IRoles_EmpleadosServicios!.Eliminar(id);
        }

    }
}
