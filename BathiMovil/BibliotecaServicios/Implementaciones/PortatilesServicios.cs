using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class PortatilesServicios : IPortatilesServicios
    {
        private IConexion? iConexion;

        public List<Portatiles> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Portatiles!.ToList();
            return lista;
        }

        public Portatiles Guardar(Portatiles entidad)
        {
            if (entidad.Id_Portatil != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Portatiles!.Add(entidad!);
            var lista = iConexion.Portatiles!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Portatiles Modificar(Portatiles entidad)
        {
            if (entidad.Id_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Portatiles>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Portatiles!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Portatiles Eliminar(Portatiles entidad)
        {
            if (entidad.Id_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Portatiles!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }

        public bool ComprobarCantidad (int Id_Tipo, int cantidad)
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var portatilesFiltrados = iConexion.Portatiles!
                .Where(p => p.Tipo_Portatil == Id_Tipo)
                .Where(p => p.Estado_Actual == "Disponible")  // <-- filtro añadido
                .ToList();

            return portatilesFiltrados.Count >= cantidad;
        }
    }
}