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
    public class ImplementosController : ControllerBase
    {
        private IImplementosServicios? iImplementosServicios;



        public ImplementosController()
        {
            this.iImplementosServicios = new ImplementosServicios();
        }

        [HttpGet("Consultar")]
        public List<Implementos> Consultar()
        {
            if (this.iImplementosServicios == null)
                throw new Exception("No implementado");
            return this.iImplementosServicios!.Consultar();
        }

        [HttpPost]
        public Implementos Guardar(Implementos entidad)
        {
            if (this.iImplementosServicios == null)
                throw new Exception("No implementado");
            return this.iImplementosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Implementos Modificar(Implementos id)
        {
            if (this.iImplementosServicios == null)
                throw new Exception("No implementado");
            return this.iImplementosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Implementos Eliminar(Implementos id)
        {
            if (this.iImplementosServicios == null)
                throw new Exception("No implementado");
            return this.iImplementosServicios!.Eliminar(id);
        }

    }
}
