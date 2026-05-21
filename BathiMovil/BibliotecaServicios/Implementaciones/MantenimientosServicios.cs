using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class MantenimientosServicios : IMantenimientosServicios
    {
        private IConexion? iConexion;

        public List<Mantenimientos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Mantenimiento!.ToList();
            return lista;
        }

        public Mantenimientos Guardar(Mantenimientos entidad)
        {
            if (entidad.Id_Mantenimiento != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Mantenimiento!.Add(entidad!);
            var lista = iConexion.Mantenimiento!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Mantenimientos Modificar(Mantenimientos entidad)
        {
            if (entidad.Id_Mantenimiento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Mantenimientos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Mantenimiento!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Mantenimientos Eliminar(Mantenimientos entidad)
        {
            if (entidad.Id_Mantenimiento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Mantenimiento!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}