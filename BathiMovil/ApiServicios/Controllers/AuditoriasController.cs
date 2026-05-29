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
    public class AuditoriasController : ControllerBase
    {
        private IAuditoriasServicios? IAuditoriasServicios;


        public AuditoriasController()
        {
            this.IAuditoriasServicios = new AuditoriasServicios();
        }

        [HttpPost]
        public Auditorias Guardar(Auditorias entidad)
        {
            if (this.IAuditoriasServicios == null)
                throw new Exception("No implementado");
            return this.IAuditoriasServicios!.Guardar(entidad);
        }

    }
}
