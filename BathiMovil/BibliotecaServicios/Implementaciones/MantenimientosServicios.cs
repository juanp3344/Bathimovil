using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class MantenimientosServicios : IMantenimientosServicios
    {
        private IConexion? iConexion;

        public List<Mantenimientos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Mantenimientos!.ToList();
            return lista;
        }

        public Mantenimientos Guardar(Mantenimientos entidad)
        {
            if (entidad.Id_Mantenimiento != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Mantenimientos!.Add(entidad!);
            var lista = iConexion.Mantenimientos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Mantenimientos Modificar(Mantenimientos entidad)
        {
            if (entidad.Id_Mantenimientos == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Mantenimientos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Mantenimientos!.ToList();

            return entidad;
        }
        public Mantenimientos Eliminar(Mantenimientos entidad)
        {
            if (entidad.Id_Mantenimientos == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Mantenimientos!.Remove(entidad!);

            return entidad;
        }
    }
}