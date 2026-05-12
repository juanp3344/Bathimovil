using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiServicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tipo_Aseo_ElementosController : ControllerBase
    {
        private ITipo_Aseo_ElementosServicios? ITipo_Aseo_ElementosServicios;



        public Tipo_Aseo_ElementosController()
        {
            this.ITipo_Aseo_ElementosServicios = new Tipo_Aseo_ElementosServicios();
        }

        [HttpGet]
        public List<Tipo_Aseo_Elementos> Consultar()
        {
            if (this.ITipo_Aseo_ElementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipo_Aseo_ElementosServicios!.Consultar();
        }

        [HttpPost]
        public Tipo_Aseo_Elementos Guardar(Tipo_Aseo_Elementos entidad)
        {
            if (this.ITipo_Aseo_ElementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipo_Aseo_ElementosServicios!.Guardar(entidad);
        }


        [HttpPut]
        public Tipo_Aseo_Elementos Modificar(Tipo_Aseo_Elementos id)
        {
            if (this.ITipo_Aseo_ElementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipo_Aseo_ElementosServicios!.Modificar(id);
        }

        [HttpDelete]

        public Tipo_Aseo_Elementos Eliminar(Tipo_Aseo_Elementos id)
        {
            if (this.ITipo_Aseo_ElementosServicios == null)
                throw new Exception("No implementado");
            return this.ITipo_Aseo_ElementosServicios!.Eliminar(id);
        }

    }
}
