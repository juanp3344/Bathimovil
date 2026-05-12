using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Roles_PermisosController : ControllerBase
    {
        private IRoles_PermisosServicios? IRoles_PermisosServicios;



        public Roles_PermisosController()
        {
            this.IRoles_PermisosServicios = new Roles_PermisosServicios();
        }

        [HttpGet]
        public List<Roles_Permisos> Consultar()
        {
            if (this.IRoles_PermisosServicios == null)
                throw new Exception("No implementado");
            return this.IRoles_PermisosServicios!.Consultar();
        }

        [HttpPost]
        public Roles_Permisos Guardar(Roles_Permisos entidad)
        {
            if (this.IRoles_PermisosServicios == null)
                throw new Exception("No implementado");
            return this.IRoles_PermisosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Roles_Permisos Modificar(Roles_Permisos id)
        {
            if (this.IRoles_PermisosServicios == null)
                throw new Exception("No implementado");
            return this.IRoles_PermisosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Roles_Permisos Eliminar(Roles_Permisos id)
        {
            if (this.IRoles_PermisosServicios == null)
                throw new Exception("No implementado");
            return this.IRoles_PermisosServicios!.Eliminar(id);
        }

    }
}
