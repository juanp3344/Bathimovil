using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class SedesServicios
    {
        private IConexion? iConexion;

        public List<Sedes> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Sedes!.ToList();
            return lista;
        }

        public Sedes Guardar(Sedes entidad)
        {
            if (entidad.Id_Sede != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Sedes!.Add(entidad!);
            var lista = iConexion.Sedes!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Sedes Modificar(Sedes entidad)
        {
            if (entidad.Id_Sede == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Sedes>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Sedes!.ToList();

            return entidad;
        }
        public Sedes Eliminar(Sedes entidad)
        {
            if (entidad.Id_Sede == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Sedes!.Remove(entidad!);

            return entidad;
        }
}
