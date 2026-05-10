using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComprasController : ControllerBase
    {
        private IComprasServicios? IComprasServicios;

        

        public ComprasController()
        {
            this.IComprasServicios = new ComprasServicios();
        }

        [HttpGet("Consultar")]
        public List<Compras> Consultar()
        {
            if (this.IComprasServicios == null)
                throw new Exception("No implementado");
            return this.IComprasServicios!.Consultar();
        }

        [HttpPost]
        public Compras Guardar(Compras entidad)
        {
            if (this.IComprasServicios == null)
                throw new Exception("No implementado");
            return this.IComprasServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Compras Modificar(Compras id)
        {
            if (this.IComprasServicios == null)
                throw new Exception("No implementado");
            return this.IComprasServicios!.Modificar(id);
        }

        [HttpDelete]

        public Compras Eliminar(Compras id)
        {
            if (this.IComprasServicios == null)
                throw new Exception("No implementado");
            return this.IComprasServicios!.Eliminar(id);
        }

    }
}
