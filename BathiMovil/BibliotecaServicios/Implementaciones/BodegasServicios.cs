

using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class BodegasServicios: IBodegasServicios
    {
        private IConexion? iConexion;

        public List<Bodegas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Bodegas!.ToList();
            return lista;
        }

        public Bodegas Guardar(Bodegas entidad)
        {
            if (entidad.Id_Bodega != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Bodegas!.Add(entidad!);
            var lista = iConexion.Bodegas!.ToList();
            

            iConexion.SaveChanges();
            return entidad;
        }

        public Bodegas Modificar(Bodegas entidad)
        {
            if (entidad.Id_Bodega == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Bodegas>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Bodegas!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Bodegas Eliminar(Bodegas entidad)
        {
            if (entidad.Id_Bodega == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Bodegas!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}

