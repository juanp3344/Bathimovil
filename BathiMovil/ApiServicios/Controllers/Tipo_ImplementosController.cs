using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tipo_ImplementosController : ControllerBase
    {
        private ITipo_ImplementosServicios? ITipo_ImplementosServicios;



        public Tipo_ImplementosController()
        {
            this.ITipo_ImplementosServicios = new Tipo_ImplementosServicios();
        }

        [HttpGet]
        public List<Tipo_Implementos> Consultar()
        {
            if (this.ITipo_ImplementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipo_ImplementosServicios!.Consultar();
        }

        [HttpPost]
        public Tipo_Implementos Guardar(Tipo_Implementos entidad)
        {
            if (this.ITipo_ImplementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipo_ImplementosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Tipo_Implementos Modificar(Tipo_Implementos id)
        {
            if (this.ITipo_ImplementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipo_ImplementosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Tipo_Implementos Eliminar(Tipo_Implementos id)
        {
            if (this.ITipo_ImplementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipo_ImplementosServicios!.Eliminar(id);
        }

    }
}
