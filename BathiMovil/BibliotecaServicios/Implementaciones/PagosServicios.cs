using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{

    public class PagosServicios: IPagosServicios

    {
        private IConexion? iConexion;

        public List<Pagos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Pagos!.ToList();
            return lista;
        }

        public Pagos Guardar(Pagos entidad)
        {
            if (entidad.Id_Pago != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Pagos!.Add(entidad!);
            var lista = iConexion.Pagos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Pagos Modificar(Pagos entidad)
        {
            if (entidad.Id_Pago == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Pagos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Pagos!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Pagos Eliminar(Pagos entidad)
        {
            if (entidad.Id_Pago == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Pagos!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}