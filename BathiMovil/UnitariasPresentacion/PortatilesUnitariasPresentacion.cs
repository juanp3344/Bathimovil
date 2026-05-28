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
    public class PortatilesUnitariasPresentacion
    {
        private IPortatilesPresentacion iPresentacion = new PortatilesPresentacion();
        private IConexion? iConexion;
        private Portatiles? entidad;

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

            this.entidad = DatosHelper.CrearPortatil(this.iConexion, entidadTipo.Id_Tipo_Portatil, entidadSede.Id_Sede, entidadCompra.Id_Compra);
            if (this.entidad!.Id_Portatil != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Portatiles> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Estado_Actual = "Chowder";
            Portatiles resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Portatil != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Portatiles resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
