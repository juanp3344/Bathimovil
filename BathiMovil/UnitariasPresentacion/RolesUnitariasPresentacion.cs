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
using System.Text;

namespace Unitarias
{
    [TestClass]
    public class RolesUnitariasPresentacion
    {
        private IRolesPresentacion? iPresentacion;
        private Roles? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Consultar()
        {
            this.iPresentacion = new RolesPresentacion();
            var lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iPresentacion = new RolesPresentacion();
            this.entidad = this.iPresentacion.Guardar(new Roles
            {
                Nombre_Rol = "Rol Test Integracion",
                Descripcion_Rol = "Prueba de integracion",
                Salario_Empleado = 2_000_000m
            });
            if (this.entidad!.Id_Rol != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iPresentacion = new RolesPresentacion();
            this.entidad!.Nombre_Rol = "Chowder";
            var resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Rol != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            this.iPresentacion = new RolesPresentacion();
            var resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
