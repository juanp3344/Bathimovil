using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ImplementosController : Controller
    {
        private IImplementosServicios? IImplementosServicios;

        public ImplementosController()
        {
            this.IImplementosServicios = new ImplementosServicios();
        }

        [HttpGet("Consultar")]
        public List<Historial_Precios> Consultar()
        {
            if (this.IImplementosServicios == null)
                throw new Exception("No implementado");
            return this.IImplementosServicios!.Consultar();
        }

        [HttpPost]
        public Historial_Precios Guardar(Historial_Precios entidad)
        {
            if (this.IImplementosServicios == null)
                throw new Exception("No implementado");
            return this.IImplementosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Historial_Precios Modificar(Historial_Precios id)
        {
            if (this.IImplementosServicios == null)
                throw new Exception("No implementado");
            return this.IImplementosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Historial_Precios Eliminar(Historial_Precios id)
        {
            if (this.IImplementosServicios == null)
                throw new Exception("No implementado");
            return this.IImplementosServicios!.Eliminar(id);
        }
    }
}
