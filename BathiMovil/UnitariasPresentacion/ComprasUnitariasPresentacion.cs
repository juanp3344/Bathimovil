using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitarias
{
    [TestClass]
    public class ComprasUnitariasPresentacion
    {
        private IComprasPresentacion iPresentacion = new ComprasPresentacion();
        private IConexion? iConexion;
        private Compras? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            Contratos entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);

            this.entidad = DatosHelper.CrearCompra(this.iConexion, entidadContrato.Id_Contrato);
            if (this.entidad!.Id_Compra != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Compras> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Metodo_Pago = "Chowder";
            Compras resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Compra != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Compras resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
