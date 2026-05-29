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
using System.Text;

namespace Unitarias
{
    [TestClass]
    public class PermisosUnitariasPresentacion
    {
        private IPermisosPresentacion iPresentacion = new PermisosPresentacion();
        private IConexion? iConexion;
        private Permisos? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Roles entidadRol = DatosHelper.CrearRol(this.iConexion);

            this.entidad = DatosHelper.CrearPermiso(this.iConexion, entidadRol.Id_Rol);
            if (this.entidad!.Id_Permiso != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Permisos> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Nombre_Permiso = "Chowder";
            Permisos resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Permiso != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Permisos resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
