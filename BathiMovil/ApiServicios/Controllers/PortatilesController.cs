using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BibliotecaServicios.Nucleo;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PortatilesController : ControllerBase
    {
        private IPortatilesServicios? IPortatilesServicios;



        public PortatilesController()
        {
            this.IPortatilesServicios = new PortatilesServicios();
        }

        [HttpGet]
        public List<Portatiles> Consultar()
        {
            if (this.IPortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPortatilesServicios!.Consultar();
        }

        [HttpPost]
        public Portatiles Guardar(Portatiles entidad)
        {
            if (this.IPortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPortatilesServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Portatiles Modificar(Portatiles id)
        {
            if (this.IPortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPortatilesServicios!.Modificar(id);
        }

        [HttpDelete]

        public Portatiles Eliminar(Portatiles id)
        {
            if (this.IPortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPortatilesServicios!.Eliminar(id);
        }

        [HttpPost]
        public List<Portatiles> ComprobarTamanio(Tipos_Portatiles Entidad)
        {
            if (this.IPortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPortatilesServicios!.ComprobarCantidad(Entidad);
        }
    }
}
