using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FacturasController : ControllerBase
    {
        private IFacturasServicios? IFacturasServicios;

       

        public FacturasController()
        {
            this.IFacturasServicios = new FacturasServicios();
        }

        [HttpGet]
        public List<Facturas> Consultar()
        {
            if (this.IFacturasServicios == null)
                throw new Exception("No implementado");
            return this.IFacturasServicios!.Consultar();
        }

        [HttpPost]
        public Facturas Guardar(Facturas entidad)
        {
            if (this.IFacturasServicios == null)
                throw new Exception("No implementado");
            return this.IFacturasServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Facturas Modificar(Facturas id)
        {
            if (this.IFacturasServicios == null)
                throw new Exception("No implementado");
            return this.IFacturasServicios!.Modificar(id);
        }

        [HttpDelete]

        public Facturas Eliminar(Facturas id)
        {
            if (this.IFacturasServicios == null)
                throw new Exception("No implementado");
            return this.IFacturasServicios!.Eliminar(id);
        }

    }
}
