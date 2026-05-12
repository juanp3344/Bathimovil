using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class Tipo_Aseo_ElementosServicios : ITipo_Aseo_ElementosServicios
    {
        private IConexion? iConexion;

        public List<Tipo_Aseo_Elementos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Tipo_Aseo_Elementos!.ToList();
            return lista;
        }

        public Tipo_Aseo_Elementos Guardar(Tipo_Aseo_Elementos entidad)
        {
            if (entidad.Id_Tipo_Aseo_Elemento != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Tipo_Aseo_Elementos!.Add(entidad!);
            var lista = iConexion.Tipo_Aseo_Elementos!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Tipo_Aseo_Elementos Modificar(Tipo_Aseo_Elementos entidad)
        {
            if (entidad.Id_Tipo_Aseo_Elemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Tipo_Aseo_Elementos>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Tipo_Aseo_Elementos!.ToList();

            return entidad;
        }
        public Tipo_Aseo_Elementos Eliminar(Tipo_Aseo_Elementos entidad)
        {
            if (entidad.Id_Tipo_Aseo_Elemento == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Tipo_Aseo_Elementos!.Remove(entidad!);

            return entidad;
        }
}
