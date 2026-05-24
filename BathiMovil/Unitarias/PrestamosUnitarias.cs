using System;
using System.Collections.Generic;
using System.Text;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Nucleo;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Unitarias
{
    [TestClass]
    public class PrestamosUnitaria
    {
        private IConexion? iConexion;
        private Prestamos? entidad;
        private Contratos? entidadContrato;
        private Clientes? entidadCliente;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Borrar(); }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Prestamos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            this.entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);
            this.entidad = DatosHelper.CrearPrestamo(this.iConexion, entidadContrato.Id_Contrato);
            if (this.entidad!.Id_Prestamo != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Estado_Prestamo = false;
            var entry = this.iConexion!.Entry<Prestamos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            if (entidad!.Id_Prestamo != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Prestamos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            this.iConexion.Contratos!.Remove(this.entidadContrato!);
            this.iConexion.SaveChanges();
            this.iConexion.Clientes!.Remove(this.entidadCliente!);
            this.iConexion.SaveChanges();
        }
    }
}

