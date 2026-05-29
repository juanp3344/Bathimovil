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
    public class ClientesUnitariasPresentacion
    {
        private IClientesPresentacion iPresentacion = new ClientesPresentacion();
        private IConexion? iConexion;
        private Clientes? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = DatosHelper.CrearCliente(this.iConexion);
            if (this.entidad!.Id_Persona != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Clientes> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Nombre = "Chowder";
            Clientes resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Persona != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Clientes resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
