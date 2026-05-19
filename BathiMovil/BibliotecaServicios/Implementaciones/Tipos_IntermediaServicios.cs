using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class Tipos_IntermediaServicios
    {
        private IConexion? iConexion;

        public List<Tipos_Intermedia> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Tipos_Intermedia!.ToList();
            return lista;
        }

        public Tipos_Intermedia Guardar(Tipos_Intermedia entidad)
        {
            if (entidad.Id_Tipos_Intermedia != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Tipos_Intermedia!.Add(entidad!);
            var lista = iConexion.Tipos_Intermedia!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Tipos_Intermedia Modificar(Tipos_Intermedia entidad)
        {
            if (entidad.Id_Tipos_Intermedia == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Tipos_Intermedia>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Tipos_Intermedia!.ToList();

            return entidad;
        }
        public Tipos_Intermedia Eliminar(Tipos_Intermedia entidad)
        {
            if (entidad.Id_Tipos_Intermedia == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Tipos_Intermedia!.Remove(entidad!);

            return entidad;
        }
    }
}