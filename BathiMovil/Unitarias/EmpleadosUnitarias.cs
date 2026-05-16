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
    public class EmpleadosUnitaria
    {
        private IConexion? iConexion;
        private Empleados? entidad;
        private Roles_Empleados? entidad2;

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
            var lista = iConexion.Empleados!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad2 = new Roles_Empleados()
            {
                // Permisos = Roles_Empleados.Niveles_Acceso.superadmin,
                Nombre_Rol = "Benson",
                Descripcion_Rol = "Regañar a Mordecai y a Rigby",
                Salario_Base = 12000000m
            };
            this.iConexion.Roles_Empleados!.Add(this.entidad2!);
            this.iConexion.SaveChanges();

            this.entidad = new Empleados()
            {
               Fecha_Ingreso  = DateTime.Now,
                Cedula = "7483238",
                Nombre = "Tomas",
                Correo = "asjdhkajds@gmail.com",
                Telefono = "2312312312",
                Id_Rol = entidad2.Id_Rol

            };
            this.iConexion.Empleados!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Persona != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Fecha_Ingreso = DateTime.UtcNow;

            var entry = this.iConexion!.Entry<Empleados>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Persona != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Empleados!.Remove(this.entidad!);
            this.iConexion.Roles_Empleados!.Remove(this.entidad2!);
            this.iConexion.SaveChanges();
        }
    }
}
