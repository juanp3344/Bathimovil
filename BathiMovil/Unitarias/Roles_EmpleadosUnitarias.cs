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
    public class Roles_EmpleadosUnitaria
    {
        private IConexion? iConexion;
        private Roles_Empleados? entidad;

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Consultar();
            Modificar();
            Borrar();
        }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Roles_Empleados!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = new Roles_Empleados()
            {
        // Permisos = Roles_Empleados.Niveles_Acceso.superadmin,
         Nombre_Rol = "Benson",
         Descripcion_Rol= "Regañar a Mordecai y a Rigby",
         Salario_Base = 12000000m
    };
            this.iConexion.Roles_Empleados!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Rol != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Nombre_Rol = "Chowder";

            var entry = this.iConexion!.Entry<Roles_Empleados>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Rol != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Roles_Empleados!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
