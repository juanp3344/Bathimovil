using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class Roles_PermisosServicios
    {
        private IConexion? iConexion;

        public List<Roles_Permisos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Roles_Permisos!.ToList();
            return lista;
        }

        public Roles_Permisos Guardar(Roles_Permisos entidad)
        {
            if (entidad.Id_Rol_Permiso != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Roles_Permisos!.Add(entidad!);
            var lista = iConexion.Roles_Permisos!.ToList();


            iConexion.SaveChanges();
            { }
            return entidad;
        }

        public Roles_Permisos Modificar(Roles_Permisos entidad)
        {
            if (entidad.Id_Rol_Permiso == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Roles_Permisos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Roles_Permisos!.ToList();

            return entidad;
        }
        public Roles_Permisos Eliminar(Roles_Permisos entidad)
        {
            if (entidad.Id_Rol_Permiso == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Roles_Permisos!.Remove(entidad!);

            return entidad;
        }
    }
}