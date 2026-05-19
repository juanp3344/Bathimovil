using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaServicios.Implementaciones
{
    public class PersonasServicios: IPersonasServicios
    {
        private IConexion? iConexion;

        public List<Personas> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Personas!.ToList();
            return lista;
        }

        public Personas Guardar(Personas entidad)
        {
            if (entidad.Id_Persona != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            iConexion.Personas!.Add(entidad!);
            var lista = iConexion.Personas!.ToList();


            iConexion.SaveChanges();
            return entidad;
        }

        public Personas Modificar(Personas entidad)
        {
            if (entidad.Id_Persona == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var entry = this.iConexion!.Entry<Personas>(entidad!);
            entry.State = EntityState.Modified;
            var lista = iConexion.Personas!.ToList();

            return entidad;
        }
        public Personas Eliminar(Personas entidad)
        {
            if (entidad.Id_Persona == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Personas!.Remove(entidad!);

            return entidad;
        }
    }
}