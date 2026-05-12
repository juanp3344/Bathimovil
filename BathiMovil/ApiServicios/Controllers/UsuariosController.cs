using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosServicios? IUsuariosServicios;



        public UsuariosController()
        {
            this.IUsuariosServicios = new UsuariosServicios();
        }

        [HttpGet]
        public List<Usuarios> Consultar()
        {
            if (this.IUsuariosServicios == null)
                throw new Exception("No implementado");
            return this.IUsuariosServicios!.Consultar();
        }

        [HttpPost]
        public Usuarios Guardar(Usuarios entidad)
        {
            if (this.IUsuariosServicios == null)
                throw new Exception("No implementado");
            return this.IUsuariosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Usuarios Modificar(Usuarios id)
        {
            if (this.IUsuariosServicios == null)
                throw new Exception("No implementado");
            return this.IUsuariosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Usuarios Eliminar(Usuarios id)
        {
            if (this.IUsuariosServicios == null)
                throw new Exception("No implementado");
            return this.IUsuariosServicios!.Eliminar(id);
        }

    }
}
