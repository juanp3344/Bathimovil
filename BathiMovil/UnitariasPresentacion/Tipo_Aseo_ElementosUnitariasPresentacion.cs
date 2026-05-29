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
    public class Tipo_Aseo_ElementosUnitariasPresentacion
    {
        private ITipo_Aseo_ElementosPresentacion iPresentacion = new Tipo_Aseo_ElementosPresentacion();
        private IConexion? iConexion;
        private Tipo_Aseo_Elementos? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = DatosHelper.CrearTipo_Aseo_Elemento(this.iConexion);
            if (this.entidad!.Id_Tipo_Aseo_Elemento != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Tipo_Aseo_Elementos> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Uso = "Chowder";
            Tipo_Aseo_Elementos resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Tipo_Aseo_Elemento != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Tipo_Aseo_Elementos resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
