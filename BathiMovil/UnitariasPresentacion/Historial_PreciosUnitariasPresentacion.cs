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
    public class Historial_PreciosUnitariasPresentacion
    {
        private IHistorial_PreciosPresentacion iPresentacion = new Historial_PreciosPresentacion();
        private IConexion? iConexion;
        private Historial_Precios? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Tipos_Portatiles entidadTipo = DatosHelper.CrearTipo_Portatil(this.iConexion);

            this.entidad = DatosHelper.CrearHistorial_Precio(this.iConexion, entidadTipo.Id_Tipo_Portatil);
            if (this.entidad!.Id_Historial != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Historial_Precios> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Motivo_Cambio = "Chowder";
            Historial_Precios resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Historial != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Historial_Precios resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
