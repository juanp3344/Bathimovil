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
    public class Detalle_FacturasController : ControllerBase
    {
        private IDetalle_FacturasServicios? IDetalle_FacturasServicios;


        public Detalle_FacturasController()
        {
            this.IDetalle_FacturasServicios = new Detalle_FacturasServicios();
        }

        [HttpGet]
        public List<Detalle_Facturas> Consultar()
        {
            if (this.IDetalle_FacturasServicios == null)
                throw new Exception("No implementado");
            return this.IDetalle_FacturasServicios!.Consultar();
        }

        [HttpPost]
        public Detalle_Facturas Guardar(Detalle_Facturas entidad)
        {
            if (this.IDetalle_FacturasServicios == null)
                throw new Exception("No implementado");
            return this.IDetalle_FacturasServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Detalle_Facturas Modificar(Detalle_Facturas id)
        {
            if (this.IDetalle_FacturasServicios == null)
                throw new Exception("No implementado");
            return this.IDetalle_FacturasServicios!.Modificar(id);
        }

        [HttpDelete]

        public Detalle_Facturas Eliminar(Detalle_Facturas id)
        {
            if (this.IDetalle_FacturasServicios == null)
                throw new Exception("No implementado");
            return this.IDetalle_FacturasServicios!.Eliminar(id);
        }

    }
}
