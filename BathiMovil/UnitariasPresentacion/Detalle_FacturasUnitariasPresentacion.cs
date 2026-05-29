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
    public class Detalle_FacturasUnitariasPresentacion
    {
        private IDetalle_FacturasPresentacion iPresentacion = new Detalle_FacturasPresentacion();
        private IConexion? iConexion;
        private Detalle_Facturas? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            Facturas entidadFactura = DatosHelper.CrearFactura(this.iConexion, entidadCliente.Id_Persona);

            this.entidad = DatosHelper.CrearDetalle_Factura(this.iConexion, entidadFactura.Id_Factura);
            if (this.entidad!.Id_Detalle != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Detalle_Facturas> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Cantidad = 9;
            Detalle_Facturas resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Detalle != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Detalle_Facturas resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
