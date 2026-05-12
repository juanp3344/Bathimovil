using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class MantenimientoServicios : IMantenimientoServicios
    {
        private IConexion? iConexion;

        public List<Mantenimiento> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Mantenimiento!.ToList();
            return lista;
        }

        public Mantenimiento Guardar(Mantenimiento entidad)
        {
            if (entidad.Id_Mantenimiento != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Mantenimiento!.Add(entidad!);
            var lista = iConexion.Mantenimiento!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Mantenimiento Modificar(Mantenimiento entidad)
        {
            if (entidad.Id_Mantenimiento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Mantenimiento>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Mantenimiento!.ToList();

            return entidad;
        }
        public Mantenimiento Eliminar(Mantenimiento entidad)
        {
            if (entidad.Id_Mantenimiento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Mantenimiento!.Remove(entidad!);

            return entidad;
        }
    }
}