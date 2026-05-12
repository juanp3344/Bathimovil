using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrestamosController : ControllerBase
    {
        private IPrestamosServicios? IPrestamosServicios;



        public PrestamosController()
        {
            this.IPrestamosServicios = new PrestamosServicios();
        }

        [HttpGet("Consultar")]
        public List<Prestamos> Consultar()
        {
            if (this.IPrestamosServicios == null)
                throw new Exception("No implementado");
            return this.IPrestamosServicios!.Consultar();
        }

        [HttpPost]
        public Prestamos Guardar(Prestamos entidad)
        {
            if (this.IPrestamosServicios == null)
                throw new Exception("No implementado");
            return this.IPrestamosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Prestamos Modificar(Prestamos id)
        {
            if (this.IPrestamosServicios == null)
                throw new Exception("No implementado");
            return this.IPrestamosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Prestamos Eliminar(Prestamos id)
        {
            if (this.IPrestamosServicios == null)
                throw new Exception("No implementado");
            return this.IPrestamosServicios!.Eliminar(id);
        }

    }
}
