using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Prestamos_PortatilesController : ControllerBase
    {
        private IPrestamos_PortatilesServicios? IPrestamos_PortatilesServicios;



        public Prestamos_PortatilesController()
        {
            this.IPrestamos_PortatilesServicios = new Prestamos_PortatilesServicios();
        }

        [HttpGet]
        public List<Prestamos_Portatiles> Consultar()
        {
            if (this.IPrestamos_PortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPrestamos_PortatilesServicios!.Consultar();
        }

        [HttpPost]
        public Prestamos_Portatiles Guardar(Prestamos_Portatiles entidad)
        {
            if (this.IPrestamos_PortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPrestamos_PortatilesServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Prestamos_Portatiles Modificar(Prestamos_Portatiles id)
        {
            if (this.IPrestamos_PortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPrestamos_PortatilesServicios!.Modificar(id);
        }

        [HttpDelete]
        public Prestamos_Portatiles Eliminar(Prestamos_Portatiles id)
        {
            if (this.IPrestamos_PortatilesServicios == null)
                throw new Exception("No implementado");
            return this.IPrestamos_PortatilesServicios!.Eliminar(id);
        }

    }
}
