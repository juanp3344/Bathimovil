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
    public class Roles_PermisosUnitaria
    {
        private IConexion? iConexion;
        private Roles_Permisos? entidad;
        private Roles_Empleados? entidad2;
        private Permisos? entidad3;
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
            var lista = iConexion.Roles_Permisos!.ToList();
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

            this.entidad3 = new Permisos()
            {

                Nombre_Permiso = "oijoisdfj"
            };
            this.iConexion.Permisos!.Add(this.entidad3!);
            this.iConexion.SaveChanges();

            this.entidad = new Roles_Permisos()
            {

        Rol_Empleado=  entidad2.Id_Rol,
        Permiso = entidad3.Id_Permiso
    };
            this.iConexion.Roles_Permisos!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Rol_Permiso != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


            var entry = this.iConexion!.Entry<Roles_Permisos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Rol_Permiso != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Roles_Permisos!.Remove(this.entidad!);
            this.iConexion.Permisos!.Remove(this.entidad3!);
            this.iConexion.Roles_Empleados!.Remove(this.entidad2!);

            this.iConexion.SaveChanges();
        }
    }
}
