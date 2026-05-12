using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tipos_PortatilesController : ControllerBase
    {
        private ITipos_PortatilesServicios? ITipos_PortatilesServicios;



        public Tipos_PortatilesController()
        {
            this.ITipos_PortatilesServicios = new Tipos_PortatilesServicios();
        }

        [HttpGet]
        public List<Tipos_Portatiles> Consultar()
        {
            if (this.ITipos_PortatilesServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_PortatilesServicios!.Consultar();
        }

        [HttpPost]
        public Tipos_Portatiles Guardar(Tipos_Portatiles entidad)
        {
            if (this.ITipos_PortatilesServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_PortatilesServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Tipos_Portatiles Modificar(Tipos_Portatiles id)
        {
            if (this.ITipos_PortatilesServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_PortatilesServicios!.Modificar(id);
        }

        [HttpDelete]

        public Tipos_Portatiles Eliminar(Tipos_Portatiles id)
        {
            if (this.ITipos_PortatilesServicios == null)
                throw new Exception("No implementado");
            return this.ITipos_PortatilesServicios!.Eliminar(id);
        }

    }
}
