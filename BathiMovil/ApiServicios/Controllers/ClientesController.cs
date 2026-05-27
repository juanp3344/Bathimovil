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
    public class ClientesController : ControllerBase
    {
        private IClientesServicios? IClientesServicios;
        public ClientesController()
        {
            this.IClientesServicios = new ClientesServicios();
        }

        [HttpGet]
        public List<Clientes> Consultar()
        {
            if (this.IClientesServicios == null)
                throw new Exception("No implementado");
            return this.IClientesServicios!.Consultar();
        }

        [HttpPost]
        public Clientes Guardar(Clientes entidad)
        {
            if (this.IClientesServicios == null)
                throw new Exception("No implementado");
            return this.IClientesServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Clientes Modificar(Clientes id)
        {
            if (this.IClientesServicios == null)
                throw new Exception("No implementado");
            return this.IClientesServicios!.Modificar(id);
        }

        [HttpDelete]

        public Clientes Eliminar(Clientes id)
        {
            if (this.IClientesServicios == null)
                throw new Exception("No implementado");
            return this.IClientesServicios!.Eliminar(id);
        }

        [HttpPost]
        public Clientes BuscarPorId(Clientes Entidad)
        {
            if (this.IClientesServicios == null)
                throw new Exception("No implementado");

            return this.IClientesServicios!.BuscarPorId(Entidad);
        }
    }
}
