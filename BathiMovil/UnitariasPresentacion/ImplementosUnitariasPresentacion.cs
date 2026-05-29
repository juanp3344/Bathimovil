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
    public class ImplementosUnitariasPresentacion
    {
        private IImplementosPresentacion iPresentacion = new ImplementosPresentacion();
        private IConexion? iConexion;
        private Implementos? entidad;

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
            Tipos_Portatiles entidadTipoPor = DatosHelper.CrearTipo_Portatil(this.iConexion);
            Portatiles entidadPortatil = DatosHelper.CrearPortatil(this.iConexion, entidadTipoPor.Id_Tipo_Portatil, entidadSede.Id_Sede, entidadCompra.Id_Compra);
            Empleados entidadEmpleado = DatosHelper.CrearEmpleado(this.iConexion);
            Bodegas entidadBodega = DatosHelper.CrearBodega(this.iConexion, entidadSede.Id_Sede, entidadEmpleado.Id_Persona);
            Tipos_Implementos entidadTipoImpl = DatosHelper.CrearTipo_Implemento(this.iConexion);

            this.entidad = DatosHelper.CrearImplemento(this.iConexion, entidadPortatil.Id_Portatil, entidadBodega.Id_Bodega, entidadTipoImpl.Id_Tipo_Implemento);
            if (this.entidad!.Id_Implemento != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Implementos> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Estado = "Chowder";
            Implementos resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Implemento != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Implementos resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
