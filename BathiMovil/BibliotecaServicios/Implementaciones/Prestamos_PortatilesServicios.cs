using System;
using System.Collections.Generic;
using System.Text;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
namespace BibliotecaServicios.Implementaciones
{
    public class Prestamos_PortatilesServicios : IPrestamos_PortatilesServicios
    {
        private IConexion? iConexion;

        public List<Prestamos_Portatiles> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Prestamos_Portatiles!.ToList();
            return lista;
        }

        public Prestamos_Portatiles Guardar(Prestamos_Portatiles entidad)
        {
            if (entidad.Id_Prestamo_Portatil != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Prestamos_Portatiles!.Add(entidad!);
            var lista = iConexion.Prestamos_Portatiles!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Prestamos_Portatiles Modificar(Prestamos_Portatiles entidad)
        {
            if (entidad.Id_Prestamo_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Prestamos_Portatiles>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Prestamos_Portatiles!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Prestamos_Portatiles Eliminar(Prestamos_Portatiles entidad)
        {
            if (entidad.Id_Prestamo_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Prestamos_Portatiles!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}