using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class Detalle_FacturasServicios: IDetalle_FacturasServicios
    {
        private IConexion? iConexion;

        public List<Detalle_Facturas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Detalle_Facturas!.ToList();
            return lista;
        }

        public Detalle_Facturas Guardar(Detalle_Facturas entidad)
        {
            if (entidad.Id_Detalle != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Detalle_Facturas!.Add(entidad!);
            var lista = iConexion.Detalle_Facturas!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Detalle_Facturas Modificar(Detalle_Facturas entidad)
        {
            if (entidad.Id_Detalle == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Detalle_Facturas>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Detalle_Facturas!.ToList();
            iConexion.SaveChanges();
            return entidad;
        }
        public Detalle_Facturas Eliminar(Detalle_Facturas entidad)
        {
            if (entidad.Id_Detalle == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Detalle_Facturas!.Remove(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }
    }
}
