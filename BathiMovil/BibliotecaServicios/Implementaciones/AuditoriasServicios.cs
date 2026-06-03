
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;

namespace BibliotecaServicios.Implementaciones
{
    public class AuditoriasServicios: IAuditoriasServicios
    {
        private IConexion? iConexion;
        private IRolesServicios? IRolesServicios;
        public Auditorias Guardar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Auditorias!.Add(entidad!);
            var lista = iConexion.Auditorias!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public List<Auditorias> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Auditorias!.ToList();
            return lista;
        }
    }
}
