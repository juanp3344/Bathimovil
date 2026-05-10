using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;


namespace BibliotecaServicios.Implementaciones
{
    public class FacturasServicios: IFacturasServicios
    {
        private IConexion? iConexion;

        public List<Facturas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Facturas!.ToList();
            return lista;
        }

        public Facturas Guardar(Facturas entidad)
        {
            if (entidad.Id_Factura != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Facturas!.Add(entidad!);
            var lista = iConexion.Facturas!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Facturas Modificar(Facturas entidad)
        {
            if (entidad.Id_Factura == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Facturas>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Facturas!.ToList();

            return entidad;
        }
        public Facturas Eliminar(Facturas entidad)
        {
            if (entidad.Id_Factura == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Facturas!.Remove(entidad!);

            return entidad;
        }
    }
}
