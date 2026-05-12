using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;


namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermisosController : ControllerBase
    {
        private IPermisosServicios? IPermisosServicios;



        public PermisosController()
        {
            this.IPermisosServicios = new PermisosServicios();
        }

        [HttpGet("Consultar")]
        public List<Permisos> Consultar()
        {
            if (this.IPermisosServicios == null)
                throw new Exception("No implementado");
            return this.IPermisosServicios!.Consultar();
        }

        [HttpPost]
        public Permisos Guardar(Permisos entidad)
        {
            if (this.IPermisosServicios == null)
                throw new Exception("No implementado");
            return this.IPermisosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Permisos Modificar(Permisos id)
        {
            if (this.IPermisosServicios == null)
                throw new Exception("No implementado");
            return this.IPermisosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Permisos Eliminar(Permisos id)
        {
            if (this.IPermisosServicios == null)
                throw new Exception("No implementado");
            return this.IPermisosServicios!.Eliminar(id);
        }

    }
}
