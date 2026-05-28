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
    public class MantenimientosUnitaria
    {
        private IConexion? iConexion;
        private Mantenimientos? entidad;
        private Prestamos? entidadPrestamo;
        private Contratos? entidadContrato;
        private Clientes? entidadCliente;
        private Empleados? entidadEmpleado;
        private Portatiles? entidadPortatil;
        private Tipos_Portatiles? entidadTipoPortatil;
        private Sedes? entidadSede;
        private Compras? entidadCompra;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Borrar(); }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Mantenimientos!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            this.entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);
            this.entidadCompra = DatosHelper.CrearCompra(this.iConexion, entidadContrato.Id_Contrato);
            this.entidadTipoPortatil = DatosHelper.CrearTipo_Portatil(this.iConexion);
            this.entidadSede = DatosHelper.CrearSede(this.iConexion);
            this.entidadEmpleado = DatosHelper.CrearEmpleado(this.iConexion);
            this.entidadPortatil = DatosHelper.CrearPortatil(this.iConexion, entidadTipoPortatil.Id_Tipo_Portatil, entidadSede.Id_Sede, entidadCompra.Id_Compra);
            this.entidadPrestamo = DatosHelper.CrearPrestamo(this.iConexion, entidadContrato.Id_Contrato);
            this.entidad = DatosHelper.CrearMantenimiento(this.iConexion, entidadPrestamo.Id_Prestamo, entidadEmpleado.Id_Persona, entidadPortatil.Id_Portatil);
            if (this.entidad!.Id_Mantenimiento != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Descripcion_Trabajo = "Chowder";
            var entry = this.iConexion!.Entry<Mantenimientos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            if (entidad!.Id_Mantenimiento != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Mantenimientos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            this.iConexion.Prestamos!.Remove(this.entidadPrestamo!);
            this.iConexion.SaveChanges();
            this.iConexion.Portatiles!.Remove(this.entidadPortatil!);
            this.iConexion.SaveChanges();
            this.iConexion.Compras!.Remove(this.entidadCompra!);
            this.iConexion.SaveChanges();
            this.iConexion.Contratos!.Remove(this.entidadContrato!);
            this.iConexion.SaveChanges();
            this.iConexion.Tipos_Portatiles!.Remove(this.entidadTipoPortatil!);
            this.iConexion.Sedes!.Remove(this.entidadSede!);
            this.iConexion.Empleados!.Remove(this.entidadEmpleado!);
            this.iConexion.Clientes!.Remove(this.entidadCliente!);
            this.iConexion.SaveChanges();
        }
    }
}
