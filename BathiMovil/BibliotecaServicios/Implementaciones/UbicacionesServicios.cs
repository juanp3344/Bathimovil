using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class UbicacionesServicios : IUbicacionesServicios
    {
        private IConexion? iConexion;

        public List<Ubicaciones> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Ubicaciones!.ToList();
            return lista;
        }

        public Ubicaciones Guardar(Ubicaciones entidad)
        {
            if (entidad.Id_Ubicacion != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Ubicaciones!.Add(entidad!);
            var lista = iConexion.Ubicaciones!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Ubicaciones Modificar(Ubicaciones entidad)
        {
            if (entidad.Id_Ubicacion == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Ubicaciones>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Ubicaciones!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Ubicaciones Eliminar(Ubicaciones entidad)
        {
            if (entidad.Id_Ubicacion == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Ubicaciones!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}