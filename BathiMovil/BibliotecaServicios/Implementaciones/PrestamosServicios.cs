using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class PrestamosServicios
    {
        private IConexion? iConexion;

        public List<Prestamos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Prestamos!.ToList();
            return lista;
        }

        public Prestamos Guardar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Prestamos!.Add(entidad!);
            var lista = iConexion.Prestamos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Prestamos Modificar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Prestamos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Prestamos!.ToList();

            return entidad;
        }
        public Prestamos Eliminar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Prestamos!.Remove(entidad!);

            return entidad;
        }
    }
}