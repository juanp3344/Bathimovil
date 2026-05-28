using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Unitarias
{
    [TestClass]
    public class SedesUnitariasPresentacion
    {
        private ISedesPresentacion iPresentacion = new SedesPresentacion();
        private IConexion? iConexion;
        private Sedes? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = DatosHelper.CrearSede(this.iConexion);
            if (this.entidad!.Id_Sede != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Sedes> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Nombre = "Chowder";
            Sedes resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Sede != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Sedes resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
