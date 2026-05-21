using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RolesController : ControllerBase
    {
        private IRolesServicios? IRolesServicios;



        public RolesController()
        {
            this.IRolesServicios = new RolesServicios();
        }

        [HttpGet]
        public List<Roles> Consultar()
        {
            if (this.IRolesServicios == null)
                throw new Exception("No implementado");
            return this.IRolesServicios!.Consultar();
        }

        [HttpPost]
        public Roles Guardar(Roles entidad)
        {
            if (this.IRolesServicios == null)
                throw new Exception("No implementado");
            return this.IRolesServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Roles Modificar(Roles id)
        {
            if (this.IRolesServicios == null)
                throw new Exception("No implementado");
            return this.IRolesServicios!.Modificar(id);
        }

        [HttpDelete]

        public Roles Eliminar(Roles id)
        {
            if (this.IRolesServicios == null)
                throw new Exception("No implementado");
            return this.IRolesServicios!.Eliminar(id);
        }

    }
}
