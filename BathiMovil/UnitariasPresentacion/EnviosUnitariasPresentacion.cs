using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitarias
{
    [TestClass]
    public class EnviosUnitariasPresentacion
    {
        private IEnviosPresentacion iPresentacion = new EnviosPresentacion();
        private IConexion? iConexion;
        private Envios? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            Contratos entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);
            Empleados entidadEmpleado = DatosHelper.CrearEmpleado(this.iConexion);

            this.entidad = DatosHelper.CrearEnvio(this.iConexion, entidadContrato.Id_Contrato, entidadEmpleado.Id_Persona);
            if (this.entidad!.Id_Envio != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Envios> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Destino = "Chowder";
            Envios resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Envio != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Envios resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
