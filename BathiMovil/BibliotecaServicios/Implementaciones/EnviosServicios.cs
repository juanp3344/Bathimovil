
using Biblioteca.Entidades;
using Biblioteca.Interfaces;
using Biblioteca.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Implementaciones
{
    public class EnviosServicios: IEnviosServicios
    {
        private IConexion? iConexion;

        public List<Envios> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Envios!.ToList();
            return lista;
        }

        public Envios Guardar(Envios entidad)
        {
            if (entidad.Id_Envio != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Envios!.Add(entidad!);
            var lista = iConexion.Envios!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Envios Modificar(Envios entidad)
        {
            if (entidad.Id_Envio == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Envios>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Envios!.ToList();

            return entidad;
        }
        public Envios Eliminar(Envios entidad)
        {
            if (entidad.Id_Envio == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Envios!.Remove(entidad!);

            return entidad;
        }
    }
}
