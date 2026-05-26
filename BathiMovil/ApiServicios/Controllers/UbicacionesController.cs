using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UbicacionesController : ControllerBase
    {
        private IUbicacionesServicios? IUbicacionesServicios;



        public UbicacionesController()
        {
            this.IUbicacionesServicios = new UbicacionesServicios();
        }

        [HttpGet]
        public List<Ubicaciones> Consultar()
        {
            if (this.IUbicacionesServicios == null)
                throw new Exception("No implementado");
            return this.IUbicacionesServicios!.Consultar();
        }

        [HttpPost]
        public Ubicaciones Guardar(Ubicaciones entidad)
        {
            if (this.IUbicacionesServicios == null)
                throw new Exception("No implementado");
            return this.IUbicacionesServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Ubicaciones Modificar(Ubicaciones id)
        {
            if (this.IUbicacionesServicios == null)
                throw new Exception("No implementado");
            return this.IUbicacionesServicios!.Modificar(id);
        }

        [HttpDelete]

        public Ubicaciones Eliminar(Ubicaciones id)
        {
            if (this.IUbicacionesServicios == null)
                throw new Exception("No implementado");
            return this.IUbicacionesServicios!.Eliminar(id);
        }

    }
}
