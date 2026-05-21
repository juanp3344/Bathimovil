using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class UsuariosServicios : IUsuariosServicios
    {
        private IConexion? iConexion;

        public List<Usuarios> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Usuarios!.ToList();
            return lista;
        }

        public Usuarios Guardar(Usuarios entidad)
        {
            if (entidad.Id_Usuario != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Usuarios!.Add(entidad!);
            var lista = iConexion.Usuarios!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Usuarios Modificar(Usuarios entidad)
        {
            if (entidad.Id_Usuario == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Usuarios>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Usuarios!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Usuarios Eliminar(Usuarios entidad)
        {
            if (entidad.Id_Usuario == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Usuarios!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}