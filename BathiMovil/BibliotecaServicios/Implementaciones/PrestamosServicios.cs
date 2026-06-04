using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BibliotecaServicios.Implementaciones
{
    public class PrestamosServicios : IPrestamosServicios
    {
        private IConexion? iConexion;

        public List<Prestamos> Consultar()
        {
            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var lista = iConexion.Prestamos!.ToList();
            return lista;
        }

        public Prestamos Guardar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo != 0)
                throw new Exception("Ya se guardo");

            iConexion = new Conexion();
            iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Log values for diagnosis
            Console.WriteLine($"[PrestamosServicios.Guardar] Portatil={entidad.Portatil}, NavPortatilId={entidad._Portatil?.Id_Portatil}, Contrato={entidad.Contrato}");

            // If navigation object for portatil is provided, normalize to FK
            if (entidad._Portatil != null)
            {
                entidad.Portatil = entidad._Portatil.Id_Portatil;
                entidad._Portatil = null; // avoid accidental insert of navigation object
            }

            // Validate foreign keys exist
            if (iConexion.Portatiles == null || !iConexion.Portatiles.Any(p => p.Id_Portatil == entidad.Portatil))
                throw new Exception($"El portatil referenciado (Id={entidad.Portatil}) no existe en la base de datos.");

            if (iConexion.Contratos == null || !iConexion.Contratos.Any(c => c.Id_Contrato == entidad.Contrato))
                throw new Exception($"El contrato referenciado (Id={entidad.Contrato}) no existe en la base de datos.");

            iConexion.Prestamos!.Add(entidad!);
            iConexion.SaveChanges();
            return entidad;
        }

        public Prestamos Modificar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Log values for diagnosis
            Console.WriteLine($"[PrestamosServicios.Modificar] Id={entidad.Id_Prestamo}, Portatil={entidad.Portatil}, NavPortatilId={entidad._Portatil?.Id_Portatil}, Contrato={entidad.Contrato}");

            // Normalize navigation if provided
            if (entidad._Portatil != null)
            {
                entidad.Portatil = entidad._Portatil.Id_Portatil;
                entidad._Portatil = null;
            }

            // Validate foreign keys exist
            if (this.iConexion.Portatiles == null || !this.iConexion.Portatiles.Any(p => p.Id_Portatil == entidad.Portatil))
                throw new Exception($"El portatil referenciado (Id={entidad.Portatil}) no existe en la base de datos.");

            if (this.iConexion.Contratos == null || !this.iConexion.Contratos.Any(c => c.Id_Contrato == entidad.Contrato))
                throw new Exception($"El contrato referenciado (Id={entidad.Contrato}) no existe en la base de datos.");

            var entry = this.iConexion!.Entry<Prestamos>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }
        public Prestamos Eliminar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo == 0)
                throw new Exception("No se ha guardado");

            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            // Ensure the record exists in DB before attempting remove
            var existente = this.iConexion.Prestamos!.FirstOrDefault(p => p.Id_Prestamo == entidad.Id_Prestamo);
            if (existente == null)
                throw new Exception($"El prestamo Id={entidad.Id_Prestamo} no existe en la base de datos.");

            this.iConexion.Prestamos!.Remove(existente);
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}