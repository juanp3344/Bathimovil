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
    public class Aseo_ElementosController : ControllerBase
    {
        private IAseo_ElementosServicios? IAseo_ElementosServicios;

       

        public Aseo_ElementosController()
        {
            this.IAseo_ElementosServicios = new Aseo_ElementosServicios();
        }

        [HttpGet("Consultar")]
        public List<Aseo_Elementos> Consultar()
        {
            if (this.IAseo_ElementosServicios == null)
                throw new Exception("No implementado");
            return this.IAseo_ElementosServicios!.Consultar();
        }

        [HttpPost]
        public Aseo_Elementos Guardar(Aseo_Elementos entidad)
        {
            if (this.IAseo_ElementosServicios == null)
                throw new Exception("No implementado");
            return this.IAseo_ElementosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Aseo_Elementos Modificar(Aseo_Elementos id)
        {
            if (this.IAseo_ElementosServicios == null)
                throw new Exception("No implementado");
            return this.IAseo_ElementosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Aseo_Elementos Eliminar(Aseo_Elementos id)
        {
            if (this.IAseo_ElementosServicios == null)
                throw new Exception("No implementado");
            return this.IAseo_ElementosServicios!.Eliminar(id);
        }

    }
}
