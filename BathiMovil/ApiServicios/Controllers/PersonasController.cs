using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;


namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PersonasController : ControllerBase
    {
        private IPersonasServicios? IPersonasServicios;



        public PersonasController()
        {
            this.IPersonasServicios = new PersonasServicios();
        }

        [HttpGet]
        public List<Personas> Consultar()
        {
            if (this.IPersonasServicios == null)
                throw new Exception("No implementado");
            return this.IPersonasServicios!.Consultar();
        }

        [HttpPost]
        public Personas Guardar(Personas entidad)
        {
            if (this.IPersonasServicios == null)
                throw new Exception("No implementado");
            return this.IPersonasServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Personas Modificar(Personas id)
        {
            if (this.IPersonasServicios == null)
                throw new Exception("No implementado");
            return this.IPersonasServicios!.Modificar(id);
        }

        [HttpDelete]

        public Personas Eliminar(Personas id)
        {
            if (this.IPersonasServicios == null)
                throw new Exception("No implementado");
            return this.IPersonasServicios!.Eliminar(id);
        }

    }
}
