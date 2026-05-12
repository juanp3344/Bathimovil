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
    public class PagosController : ControllerBase
    {
        private IPagosServicios? IPagosServicios;



        public PagosController()
        {
            this.IPagosServicios = new PagosServicios();
        }

        [HttpGet]
        public List<Pagos> Consultar()
        {
            if (this.IPagosServicios == null)
                throw new Exception("No implementado");
            return this.IPagosServicios!.Consultar();
        }

        [HttpPost]
        public Pagos Guardar(Pagos entidad)
        {
            if (this.IPagosServicios == null)
                throw new Exception("No implementado");
            return this.IPagosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Pagos Modificar(Pagos id)
        {
            if (this.IPagosServicios == null)
                throw new Exception("No implementado");
            return this.IPagosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Pagos Eliminar(Pagos id)
        {
            if (this.IPagosServicios == null)
                throw new Exception("No implementado");
            return this.IPagosServicios!.Eliminar(id);
        }

    }
}
