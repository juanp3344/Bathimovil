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
    public class BodegasUnitariasPresentacion
    {
        private IBodegasPresentacion iPresentacion = new BodegasPresentacion();
        private IConexion? iConexion;
        private Bodegas? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Sedes entidadSede = DatosHelper.CrearSede(this.iConexion);
            Empleados entidadEmpleado = DatosHelper.CrearEmpleado(this.iConexion);

            this.entidad = DatosHelper.CrearBodega(this.iConexion, entidadSede.Id_Sede, entidadEmpleado.Id_Persona);
            if (this.entidad!.Id_Bodega != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Bodegas> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Nombre = "Chowder";
            Bodegas resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Bodega != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Bodegas resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
