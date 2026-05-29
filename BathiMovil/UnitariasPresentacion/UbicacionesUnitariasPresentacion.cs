using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using System;
using System.Collections.Generic;
using System.Text;
using Unitarias;

namespace UnitariasPresentacion
{
    [TestClass]
    public class UbicacionesUnitariasPresentacion
    {
        private IUbicacionesPresentacion iPresentacion = new UbicacionesPresentacion();
        private IConexion? iConexion;
        private Ubicaciones? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            Contratos entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);
            Compras entidadCompra = DatosHelper.CrearCompra(this.iConexion, entidadContrato.Id_Contrato);
            Sedes entidadSede = DatosHelper.CrearSede(this.iConexion);
            Tipos_Portatiles entidadTipo = DatosHelper.CrearTipo_Portatil(this.iConexion);
            Portatiles entidadPortatil = DatosHelper.CrearPortatil(this.iConexion, entidadTipo.Id_Tipo_Portatil, entidadSede.Id_Sede, entidadCompra.Id_Compra);

            this.entidad = DatosHelper.CrearUbicacion(this.iConexion, entidadPortatil.Id_Portatil);
            if (this.entidad!.Id_Ubicacion != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Ubicaciones> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Ciudad = "Chowder";
            Ubicaciones resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Ubicacion != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Ubicaciones resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
