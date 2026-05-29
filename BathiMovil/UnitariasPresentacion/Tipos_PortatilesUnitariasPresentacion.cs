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
    public class Tipos_PortatilesUnitariasPresentacion
    {
        private ITipos_PortatilesPresentacion iPresentacion = new Tipos_PortatilesPresentacion();
        private IConexion? iConexion;
        private Tipos_Portatiles? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = DatosHelper.CrearTipo_Portatil(this.iConexion);
            if (this.entidad!.Id_Tipo_Portatil != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Tipos_Portatiles> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Nombre = "Chowder";
            Tipos_Portatiles resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Tipo_Portatil != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Tipos_Portatiles resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
