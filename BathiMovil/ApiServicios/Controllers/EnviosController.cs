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
    public class EnviosController : ControllerBase
    {
        private IEnviosServicios? IEnviosServicios;

       

        public EnviosController()
        {
            this.IEnviosServicios = new EnviosServicios();
        }

        [HttpGet("Consultar")]
        public List<Envios> Consultar()
        {
            if (this.IEnviosServicios == null)
                throw new Exception("No implementado");
            return this.IEnviosServicios!.Consultar();
        }

        [HttpPost]
        public Envios Guardar(Envios entidad)
        {
            if (this.IEnviosServicios == null)
                throw new Exception("No implementado");
            return this.IEnviosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Envios Modificar(Envios id)
        {
            if (this.IEnviosServicios == null)
                throw new Exception("No implementado");
            return this.IEnviosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Envios Eliminar(Envios id)
        {
            if (this.IEnviosServicios == null)
                throw new Exception("No implementado");
            return this.IEnviosServicios!.Eliminar(id);
        }

    }
}
