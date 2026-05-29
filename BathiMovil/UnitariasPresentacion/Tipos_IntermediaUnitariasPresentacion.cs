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
    public class Tipos_IntermediaUnitariasPresentacion
    {
        private ITipos_IntermediaPresentacion iPresentacion = new Tipos_IntermediaPresentacion();
        private IConexion? iConexion;
        private Tipos_Intermedia? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Tipos_Implementos entidadTipoImplemento = DatosHelper.CrearTipo_Implemento(this.iConexion);
            Tipos_Portatiles entidadTipoPortatil = DatosHelper.CrearTipo_Portatil(this.iConexion);

            this.entidad = DatosHelper.CrearTipos_Intermedia(this.iConexion, entidadTipoImplemento.Id_Tipo_Implemento, entidadTipoPortatil.Id_Tipo_Portatil);
            if (this.entidad!.Id_Tipos_Intermedia != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Tipos_Intermedia> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Posicion_Montaje = "Chowder";
            Tipos_Intermedia resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Tipos_Intermedia != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Tipos_Intermedia resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
