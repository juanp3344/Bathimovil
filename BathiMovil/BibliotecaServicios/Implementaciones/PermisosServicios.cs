

using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class PermisosServicios: IPermisosServicios

    {
        private IConexion? iConexion;

        public List<Permisos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Permisos!.ToList();
            return lista;
        }

        public Permisos Guardar(Permisos entidad)
        {
            if (entidad.Id_Permiso != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Permisos!.Add(entidad!);
            var lista = iConexion.Permisos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Permisos Modificar(Permisos entidad)
        {
            if (entidad.Id_Permiso == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Permisos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Permisos!.ToList();

            iConexion.SaveChanges();
            return entidad;
        }
        public Permisos Eliminar(Permisos entidad)
        {
            if (entidad.Id_Permiso == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Permisos!.Remove(entidad!);

            iConexion.SaveChanges();
            return entidad;
        }

        public Permisos ComprobarPermiso(Permisos entidad)
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = Consultar().FirstOrDefault(p => p.Nombre_Permiso == entidad.Nombre_Permiso);

            return lista!;
        }
    }
}