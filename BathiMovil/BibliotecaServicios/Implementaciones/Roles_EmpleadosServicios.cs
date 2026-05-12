using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class Roles_EmpleadosServicios : IRoles_EmpleadosServicios
    {
        private IConexion? iConexion;

        public List<Roles_Empleados> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Roles_Empleados!.ToList();
            return lista;
        }

        public Roles_Empleados Guardar(Roles_Empleados entidad)
        {
            if (entidad.Id_Rol != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Roles_Empleados!.Add(entidad!);
            var lista = iConexion.Roles_Empleados!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Roles_Empleados Modificar(Roles_Empleados entidad)
        {
            if (entidad.Id_Rol == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Roles_Empleados>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Roles_Empleados!.ToList();

            return entidad;
        }
        public Roles_Empleados Eliminar(Roles_Empleados entidad)
        {
            if (entidad.Id_Rol == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Roles_Empleados!.Remove(entidad!);

            return entidad;
        }
    }
}