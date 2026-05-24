using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitarias
{

    [TestClass]
    public class BodegasUnitaria
    {
        private IConexion? iConexion;
        private Bodegas? entidad;
        private Sedes? entidadSede;
        private Empleados? entidadEmpleado;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Borrar(); }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Bodegas!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

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

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Nombre = "Chowder";
            var entry = this.iConexion!.Entry<Bodegas>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            if (entidad!.Id_Bodega != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Bodegas!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            this.iConexion.Sedes!.Remove(this.entidadSede!);
            this.iConexion.Empleados!.Remove(this.entidadEmpleado!);
            this.iConexion.SaveChanges();
        }
    }
}
