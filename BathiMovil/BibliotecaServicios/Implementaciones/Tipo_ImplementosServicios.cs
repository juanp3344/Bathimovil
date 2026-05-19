using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class Tipo_ImplementosServicios
    {
        private IConexion? iConexion;

        public List<Tipo_Implementos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Tipo_Implementos!.ToList();
            return lista;
        }

        public Tipo_Implementos Guardar(Tipo_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Tipo_Implementos!.Add(entidad!);
            var lista = iConexion.Tipo_Implementos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Tipo_Implementos Modificar(Tipo_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Tipo_Implementos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Tipo_Implementos!.ToList();

            return entidad;
        }
        public Tipo_Implementos Eliminar(Tipo_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Tipo_Implementos!.Remove(entidad!);

            return entidad;
        }
    }
}