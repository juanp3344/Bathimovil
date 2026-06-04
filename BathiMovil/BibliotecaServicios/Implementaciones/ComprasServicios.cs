
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaServicios.Implementaciones
{
    public class ComprasServicios: IComprasServicios
    {
        private IConexion? iConexion;

        public List<Compras> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Compras!.ToList();
            return lista;
        }

        public Compras Guardar(Compras entidad)
        {
            if (entidad.Id_Compra != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            // Ensure Metodo_Pago always has a value to avoid DB NOT NULL errors
            if (string.IsNullOrWhiteSpace(entidad.Metodo_Pago))
                entidad.Metodo_Pago = "Transferencia";

            iConexion.Compras!.Add(entidad!);
            var lista = iConexion.Compras!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Compras Modificar(Compras entidad)
        {
            if (entidad.Id_Compra == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Ensure Metodo_Pago is not set to null/empty before updating
            if (string.IsNullOrWhiteSpace(entidad.Metodo_Pago))
                entidad.Metodo_Pago = "Transferencia";

            var entry = this.iConexion!.Entry<Compras>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Compras!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Compras Eliminar(Compras entidad)
        {
            if (entidad.Id_Compra == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Compras!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
