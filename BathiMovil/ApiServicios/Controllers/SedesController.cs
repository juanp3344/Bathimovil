using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SedesController : ControllerBase
    {
        private ISedesServicios? ISedesServicios;



        public SedesController()
        {
            this.ISedesServicios = new SedesServicios();
        }

        [HttpGet]
        public List<Sedes> Consultar()
        {
            if (this.ISedesServicios == null)
                throw new Exception("No implementado");
            return this.ISedesServicios!.Consultar();
        }

        [HttpPost]
        public Sedes Guardar(Sedes entidad)
        {
            if (this.ISedesServicios == null)
                throw new Exception("No implementado");
            return this.ISedesServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Sedes Modificar(Sedes id)
        {
            if (this.ISedesServicios == null)
                throw new Exception("No implementado");
            return this.ISedesServicios!.Modificar(id);
        }

        [HttpDelete]

        public Sedes Eliminar(Sedes id)
        {
            if (this.ISedesServicios == null)
                throw new Exception("No implementado");
            return this.ISedesServicios!.Eliminar(id);
        }

    }
}
