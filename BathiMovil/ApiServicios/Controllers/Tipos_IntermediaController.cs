using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Tipos_IntermediaController : ControllerBase
    {
        private ITipos_IntermediaServicios? ITipos_IntermediaServicios;



        public Tipos_IntermediaController()
        {
            this.ITipos_IntermediaServicios = new Tipos_IntermediaServicios();
        }

        [HttpGet("Consultar")]
        public List<Tipos_Intermedia> Consultar()
        {
            if (this.ITipos_IntermediaServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_IntermediaServicios!.Consultar();
        }

        [HttpPost]
        public Tipos_Intermedia Guardar(Tipos_Intermedia entidad)
        {
            if (this.ITipos_IntermediaServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_IntermediaServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Tipos_Intermedia Modificar(Tipos_Intermedia id)
        {
            if (this.ITipos_IntermediaServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_IntermediaServicios!.Modificar(id);
        }

        [HttpDelete]

        public Tipos_Intermedia Eliminar(Tipos_Intermedia id)
        {
            if (this.ITipos_IntermediaServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_IntermediaServicios!.Eliminar(id);
        }

    }
}
