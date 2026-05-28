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
    public class Tipos_IntermediaUnitaria
    {
        private IConexion? iConexion;
        private Tipos_Intermedia? entidad;
        private Tipos_Portatiles? entidadTipoPortatil;
        private Tipos_Implementos? entidadTipoImplemento;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Borrar(); }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Tipos_Intermedia!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidadTipoPortatil = DatosHelper.CrearTipo_Portatil(this.iConexion);
            this.entidadTipoImplemento = DatosHelper.CrearTipo_Implemento(this.iConexion);
            this.entidad = DatosHelper.CrearTipos_Intermedia(this.iConexion, entidadTipoImplemento.Id_Tipo_Implemento, entidadTipoPortatil.Id_Tipo_Portatil);
            if (this.entidad!.Id_Tipos_Intermedia != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Posicion_Montaje = "Chowder";
            var entry = this.iConexion!.Entry<Tipos_Intermedia>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            if (entidad!.Id_Tipos_Intermedia != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Tipos_Intermedia!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            this.iConexion.Tipos_Portatiles!.Remove(this.entidadTipoPortatil!);
            this.iConexion.Tipos_Implementos!.Remove(this.entidadTipoImplemento!);
            this.iConexion.SaveChanges();
        }
    }
}
