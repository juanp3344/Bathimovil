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
    public class ContratosUnitariasPresentacion
    {
        private IContratosPresentacion iPresentacion = new ContratosPresentacion();
        private IConexion? iConexion;
        private Contratos? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);

            this.entidad = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);
            if (this.entidad!.Id_Contrato != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Contratos> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Terminos = "Chowder";
            Contratos resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Contrato != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Contratos resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
