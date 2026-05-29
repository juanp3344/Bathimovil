using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;
using Unitarias;

namespace Unitarias
{
    [TestClass]
    public class RolesUnitariasPresentacion
    {
        private IRolesPresentacion iPresentacion = new RolesPresentacion();
        private IConexion? iConexion;
        private Roles? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad = DatosHelper.CrearRol(this.iConexion);
            if (this.entidad!.Id_Rol != 0) return;
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
            this.entidad!.Nombre_Rol = "Chowder";
            var resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Rol != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            var resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}

   

