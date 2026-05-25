using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;

namespace Unitarias
{
    [TestClass]
    public class UbicacionesUnitaria
    {
        private IConexion? iConexion;
        private Ubicaciones? entidad;
        private Portatiles? entidadPortatil;

        private Tipos_Portatiles? entidadTipo;
        private Sedes? entidadSede;
        private Compras? entidadCompra;
        private Contratos? entidadContrato;
        private Clientes? entidadCliente;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Borrar(); }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Ubicaciones!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("Lista vacía");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Crear dependencias necesarias
            this.entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            this.entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);
            this.entidadCompra = DatosHelper.CrearCompra(this.iConexion, entidadContrato.Id_Contrato);
            this.entidadTipo = DatosHelper.CrearTipo_Portatil(this.iConexion);
            this.entidadSede = DatosHelper.CrearSede(this.iConexion);
            this.entidadPortatil = DatosHelper.CrearPortatil(this.iConexion,
                entidadTipo.Id_Tipo_Portatil, entidadSede.Id_Sede, entidadCompra.Id_Compra);

            this.entidad = DatosHelper.CrearUbicacion(this.iConexion, entidadPortatil.Id_Portatil);

            if (this.entidad.Id_Ubicacion != 0) return;
            throw new Exception("No se guardó la ubicación");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Ciudad = "Bogotá";
            var entry = this.iConexion.Entry<Ubicaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            if (entidad.Id_Ubicacion != 0) return;
            throw new Exception("No se modificó");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Ubicaciones!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            this.iConexion.Portatiles!.Remove(this.entidadPortatil!);
            this.iConexion.SaveChanges();
            this.iConexion.Compras!.Remove(this.entidadCompra!);
            this.iConexion.SaveChanges();
            this.iConexion.Contratos!.Remove(this.entidadContrato!);
            this.iConexion.SaveChanges();
            this.iConexion.Tipos_Portatiles!.Remove(this.entidadTipo!);
            this.iConexion.Sedes!.Remove(this.entidadSede!);
            this.iConexion.Clientes!.Remove(this.entidadCliente!);
            this.iConexion.SaveChanges();
        }
    }
}
