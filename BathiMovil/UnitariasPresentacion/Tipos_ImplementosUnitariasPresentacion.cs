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
    public class Tipos_ImplementosUnitariasPresentacion
    {
        private ITipos_ImplementosPresentacion iPresentacion = new Tipos_ImplementosPresentacion();
        private IConexion? iConexion;
        private Tipos_Implementos? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = DatosHelper.CrearTipo_Implemento(this.iConexion);
            if (this.entidad!.Id_Tipo_Implemento != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Tipos_Implementos> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Nombre = "Chowder";
            Tipos_Implementos resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Tipo_Implemento != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Tipos_Implementos resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
