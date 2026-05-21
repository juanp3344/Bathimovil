using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class RolesServicios : IRolesServicios
    {
        private IConexion? iConexion;

        public List<Roles> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Roles!.ToList();
            return lista;
        }

        public Roles Guardar(Roles entidad)
        {
            if (entidad.Id_Rol != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Roles!.Add(entidad!);
            var lista = iConexion.Roles!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Roles Modificar(Roles entidad)
        {
            if (entidad.Id_Rol == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Roles>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Roles!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Roles Eliminar(Roles entidad)
        {
            if (entidad.Id_Rol == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Roles!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}