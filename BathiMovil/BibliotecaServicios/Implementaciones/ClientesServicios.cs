

using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class ClientesServicios: IClientesServicios
    {
        private IConexion? iConexion;

        public List<Clientes> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Clientes!.ToList();
            return lista;
        }

        public Clientes Guardar(Clientes entidad)
        {
            if (entidad.Id_Persona != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Clientes!.Add(entidad!);
            var lista = iConexion.Clientes!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Clientes Modificar(Clientes entidad)
        {
            if (entidad.Id_Persona == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Clientes>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Clientes!.ToList();

            return entidad;
        }
        public Clientes Eliminar(Clientes entidad)
        {
            if (entidad.Id_Persona == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Clientes!.Remove(entidad!);

            return entidad;
        }
    }
}
