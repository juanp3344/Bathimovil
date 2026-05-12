using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class Tipos_PortatilesServicios : ITipos_PortatilesServicios
    {
        private IConexion? iConexion;

        public List<Tipos_Portatiles> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Tipos_Portatiles!.ToList();
            return lista;
        }

        public Tipos_Portatiles Guardar(Tipos_Portatiles entidad)
        {
            if (entidad.Id_Tipo_Portatil != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Tipos_Portatiles!.Add(entidad!);
            var lista = iConexion.Tipos_Portatiles!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Tipos_Portatiles Modificar(Tipos_Portatiles entidad)
        {
            if (entidad.Id_Tipo_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Tipos_Portatiles>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Tipos_Portatiles!.ToList();

            return entidad;
        }
        public Tipos_Portatiles Eliminar(Tipos_Portatiles entidad)
        {
            if (entidad.Id_Tipo_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Tipos_Portatiles!.Remove(entidad!);

            return entidad;
        }
    }
}