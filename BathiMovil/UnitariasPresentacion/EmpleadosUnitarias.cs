using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Unitarias
{
    [TestClass]
    public class EmpleadosUnitariasPresentacion
    {
        private IEmpleadosPresentacion iPresentacion = new EmpleadosPresentacion();
        private IConexion? iConexion;
        private Empleados? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = DatosHelper.CrearEmpleado(this.iConexion);
            if (this.entidad!.Id_Persona != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Empleados> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Salario_Base = 9_999_999m;
            Empleados resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Persona != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Empleados resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
