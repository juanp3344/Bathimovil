using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class ImplementosServicios : IImplementosServicios
    {
        private IConexion? iConexion;

        public List<Implementos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Implementos!.ToList();
            return lista;
        }

        public Implementos Guardar(Implementos entidad)
        {
            if (entidad.Id_Implemento != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Implementos!.Add(entidad!);
            var lista = iConexion.Implementos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Implementos Modificar(Implementos entidad)
        {
            if (entidad.Id_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Implementos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Implementos!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Implementos Eliminar(Implementos entidad)
        {
            if (entidad.Id_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Implementos!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}