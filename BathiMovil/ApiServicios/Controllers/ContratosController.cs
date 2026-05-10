using Biblioteca.Entidades;
using Biblioteca.Implementaciones;
using Biblioteca.Interfaces;
using Biblioteca.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContratosController : ControllerBase
    {
        private IContratosServicios? IContratosServicios;

        public ContratosController()
        {
            this.IContratosServicios = new ContratosServicios();
        }

        [HttpGet("Consultar")]
        public List<Contratos> Consultar()
        {
            if (this.IContratosServicios == null)
                throw new Exception("No implementado");
            return this.IContratosServicios!.Consultar();
        }

        [HttpPost]
        public Contratos Guardar(Contratos entidad)
        {
            if (this.IContratosServicios == null)
                throw new Exception("No implementado");
            return this.IContratosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Contratos Modificar(Contratos id)
        {
            if (this.IContratosServicios == null)
                throw new Exception("No implementado");
            return this.IContratosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Contratos Eliminar(Contratos id)
        {
            if (this.IContratosServicios == null)
                throw new Exception("No implementado");
            return this.IContratosServicios!.Eliminar(id);
        }

    }
}
