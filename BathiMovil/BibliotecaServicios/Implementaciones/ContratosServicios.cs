using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;


namespace BibliotecaServicios.Implementaciones
{
    public class ContratosServicios: IContratosServicios
    {
        private IConexion? iConexion;

        public List<Contratos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Contratos!.ToList();
            return lista;
        }

        public Contratos Guardar(Contratos entidad)
        {
            if (entidad.Id_Contrato != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Contratos!.Add(entidad!);
            var lista = iConexion.Contratos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Contratos Modificar(Contratos entidad)
        {
            if (entidad.Id_Contrato == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Contratos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Contratos!.ToList();

            return entidad;
        }
        public Contratos Eliminar(Contratos entidad)
        {
            if (entidad.Id_Contrato == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Contratos!.Remove(entidad!);

            return entidad;
        }
    }
}
