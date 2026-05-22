using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tipos_ImplementosController : ControllerBase
    {
        private ITipos_ImplementosServicios? ITipos_ImplementosServicios;



        public Tipos_ImplementosController()
        {
            this.ITipos_ImplementosServicios = new Tipos_ImplementosServicios();
        }

        [HttpGet]
        public List<Tipos_Implementos> Consultar()
        {
            if (this.ITipos_ImplementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_ImplementosServicios!.Consultar();
        }

        [HttpPost]
        public Tipos_Implementos Guardar(Tipos_Implementos entidad)
        {
            if (this.ITipos_ImplementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_ImplementosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Tipos_Implementos Modificar(Tipos_Implementos id)
        {
            if (this.ITipos_ImplementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_ImplementosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Tipos_Implementos Eliminar(Tipos_Implementos id)
        {
            if (this.ITipos_ImplementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_ImplementosServicios!.Eliminar(id);
        }

    }
}
