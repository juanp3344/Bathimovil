using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class Tipos_ImplementosServicios : ITipos_ImplementosServicios
    {
        private IConexion? iConexion;

        public List<Tipos_Implementos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Tipos_Implementos!.ToList();
            return lista;
        }

        public Tipos_Implementos Guardar(Tipos_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Tipos_Implementos!.Add(entidad!);
            var lista = iConexion.Tipos_Implementos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Tipos_Implementos Modificar(Tipos_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Tipos_Implementos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Tipos_Implementos!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Tipos_Implementos Eliminar(Tipos_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Tipos_Implementos!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}