

using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class Historial_PreciosServicios: IHistorial_PreciosServicios
    {
        private IConexion? iConexion;

        public List<Historial_Precios> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Historial_Precios!.ToList();
            return lista;
        }

        public Historial_Precios Guardar(Historial_Precios entidad)
        {
            if (entidad.Id_Historial != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Historial_Precios!.Add(entidad!);
            var lista = iConexion.Historial_Precios!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Historial_Precios Modificar(Historial_Precios entidad)
        {
            if (entidad.Id_Historial == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Historial_Precios>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Historial_Precios!.ToList();

            return entidad;
        }
        public Historial_Precios Eliminar(Historial_Precios entidad)
        {
            if (entidad.Id_Historial == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Historial_Precios!.Remove(entidad!);

            return entidad;
        }
    }
}
