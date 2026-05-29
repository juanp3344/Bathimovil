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
    public class FacturasUnitariasPresentacion
    {
        private IFacturasPresentacion iPresentacion = new FacturasPresentacion();
        private IConexion? iConexion;
        private Facturas? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);

            this.entidad = DatosHelper.CrearFactura(this.iConexion, entidadCliente.Id_Persona);
            if (this.entidad!.Id_Factura != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Facturas> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Total = 9_999_999m;
            Facturas resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Factura != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Facturas resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
