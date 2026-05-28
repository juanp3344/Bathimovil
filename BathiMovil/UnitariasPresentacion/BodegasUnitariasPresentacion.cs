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
        private Sedes? entidadSede;
        private Empleados? entidadEmpleado;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidadSede = DatosHelper.CrearSede(this.iConexion);
            this.entidadEmpleado = DatosHelper.CrearEmpleado(this.iConexion);
            this.entidad = DatosHelper.CrearBodega(this.iConexion, entidadSede.Id_Sede, entidadEmpleado.Id_Persona);
            if (this.entidad!.Id_Bodega != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            var lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Nombre = "Chowder";
            var resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Bodega != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            var resultado = this.iPresentacion.Eliminar(this.entidad!);
            this.iConexion!.Sedes!.Remove(this.entidadSede!);
            this.iConexion!.Empleados!.Remove(this.entidadEmpleado!);
            this.iConexion!.SaveChanges();
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
