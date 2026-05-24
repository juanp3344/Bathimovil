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
    public class PermisosUnitaria
    {
        private IConexion? iConexion;
        private Permisos? entidad;
        private Roles? entidadRol;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Borrar(); }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Permisos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidadRol = DatosHelper.CrearRol(this.iConexion);
            this.entidad = DatosHelper.CrearPermiso(this.iConexion, entidadRol.Id_Rol);
            if (this.entidad!.Id_Permiso != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Nombre_Permiso = "Chowder";
            var entry = this.iConexion!.Entry<Permisos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            if (entidad!.Id_Permiso != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Permisos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            this.iConexion.Roles!.Remove(this.entidadRol!);
            this.iConexion.SaveChanges();
        }
    }
}
