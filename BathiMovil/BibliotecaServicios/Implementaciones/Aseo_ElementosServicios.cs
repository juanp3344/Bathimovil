
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class Aseo_ElementosServicios: IAseo_ElementosServicios
    {
        private IConexion? iConexion;

        public List<Aseo_Elementos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Aseo_Elementos!.ToList();
            

            return lista;
        }

        public Aseo_Elementos Guardar(Aseo_Elementos entidad)
        {
            if (entidad.Id_Aseo_Elemento != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Aseo_Elementos!.Add(entidad!);
            var lista = iConexion.Aseo_Elementos!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }

        public Aseo_Elementos Modificar(Aseo_Elementos entidad)
        {
            if (entidad.Id_Aseo_Elemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Aseo_Elementos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Aseo_Elementos!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Aseo_Elementos Eliminar(Aseo_Elementos entidad)
        {
            if (entidad.Id_Aseo_Elemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Aseo_Elementos!.Remove(entidad!);
            var lista = iConexion.Aseo_Elementos!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
