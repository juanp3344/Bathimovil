using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitarias
{
    [TestClass]
    public class MantenimientosUnitariasPresentacion
    {
        private IMantenimientosPresentacion iPresentacion = new MantenimientosPresentacion();
        private IConexion? iConexion;
        private Mantenimientos? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            Contratos entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);
            Compras entidadCompra = DatosHelper.CrearCompra(this.iConexion, entidadContrato.Id_Contrato);
            Sedes entidadSede = DatosHelper.CrearSede(this.iConexion);
            Tipos_Portatiles entidadTipo = DatosHelper.CrearTipo_Portatil(this.iConexion);
            Portatiles entidadPortatil = DatosHelper.CrearPortatil(this.iConexion, entidadTipo.Id_Tipo_Portatil, entidadSede.Id_Sede, entidadCompra.Id_Compra);
            Empleados entidadEmpleado = DatosHelper.CrearEmpleado(this.iConexion);
            Prestamos entidadPrestamo = DatosHelper.CrearPrestamo(this.iConexion, entidadContrato.Id_Contrato);

            this.entidad = DatosHelper.CrearMantenimiento(this.iConexion, entidadPrestamo.Id_Prestamo, entidadEmpleado.Id_Persona, entidadPortatil.Id_Portatil);
            if (this.entidad!.Id_Mantenimiento != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Mantenimientos> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Tipo_Mantenimiento = "Chowder";
            Mantenimientos resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Mantenimiento != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Mantenimientos resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
