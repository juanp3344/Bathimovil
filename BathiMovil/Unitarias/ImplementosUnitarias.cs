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
    public class ImplementosUnitaria
    {
        private IConexion? iConexion;
        private Implementos? entidad;
        private Portatiles? entidadPortatil;
        private Bodegas? entidadBodega;
        private Tipos_Implementos? entidadTipoImplemento;
        private Tipos_Portatiles? entidadTipoPortatil;
        private Sedes? entidadSede;
        private Compras? entidadCompra;
        private Contratos? entidadContrato;
        private Clientes? entidadCliente;
        private Empleados? entidadEmpleado;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Borrar(); }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Implementos!.ToList();
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
            this.entidadBodega = DatosHelper.CrearBodega(this.iConexion, entidadSede.Id_Sede, entidadEmpleado.Id_Persona);
            this.entidadTipoImplemento = DatosHelper.CrearTipo_Implemento(this.iConexion);
            this.entidad = DatosHelper.CrearImplemento(this.iConexion, entidadPortatil.Id_Portatil, entidadBodega.Id_Bodega, entidadTipoImplemento.Id_Tipo_Implemento);
            if (this.entidad!.Id_Implemento != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Marca = "Chowder";
            var entry = this.iConexion!.Entry<Implementos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            if (entidad!.Id_Implemento != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Implementos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            this.iConexion.Bodegas!.Remove(this.entidadBodega!);
            this.iConexion.SaveChanges();
            this.iConexion.Portatiles!.Remove(this.entidadPortatil!);
            this.iConexion.SaveChanges();
            this.iConexion.Compras!.Remove(this.entidadCompra!);
            this.iConexion.SaveChanges();
            this.iConexion.Contratos!.Remove(this.entidadContrato!);
            this.iConexion.SaveChanges();
            this.iConexion.Tipos_Portatiles!.Remove(this.entidadTipoPortatil!);
            this.iConexion.Tipos_Implementos!.Remove(this.entidadTipoImplemento!);
            this.iConexion.Sedes!.Remove(this.entidadSede!);
            this.iConexion.Empleados!.Remove(this.entidadEmpleado!);
            this.iConexion.Clientes!.Remove(this.entidadCliente!);
            this.iConexion.SaveChanges();
        }
    }
}
