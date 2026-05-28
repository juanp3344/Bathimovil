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
    public class PrestamosUnitariasPresentacion
    {
        private IPrestamosPresentacion iPresentacion = new PrestamosPresentacion();
        private IConexion? iConexion;
        private Prestamos? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            Contratos entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);

            this.entidad = DatosHelper.CrearPrestamo(this.iConexion, entidadContrato.Id_Contrato);
            if (this.entidad!.Id_Prestamo != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Prestamos> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Estado_Prestamo = false;
            Prestamos resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Prestamo != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Prestamos resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}

