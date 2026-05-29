using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using System;
using System.Collections.Generic;
using System.Text;
using Unitarias;

namespace UnitariasPresentacion
{
    [TestClass]
    public class Aseo_ElementosUnitariasPresentacion
    {
        private IAseo_ElementosPresentacion iPresentacion = new Aseo_ElementosPresentacion();
        private IConexion? iConexion;
        private Aseo_Elementos? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Tipo_Aseo_Elementos entidadTipo = DatosHelper.CrearTipo_Aseo_Elemento(this.iConexion);
            Clientes entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            Contratos entidadContrato = DatosHelper.CrearContrato(this.iConexion, entidadCliente.Id_Persona);
            Compras entidadCompra = DatosHelper.CrearCompra(this.iConexion, entidadContrato.Id_Contrato);
            Sedes entidadSede = DatosHelper.CrearSede(this.iConexion);
            Tipos_Portatiles entidadTipoPortatil = DatosHelper.CrearTipo_Portatil(this.iConexion);
            Portatiles entidadPortatil = DatosHelper.CrearPortatil(this.iConexion, entidadTipoPortatil.Id_Tipo_Portatil, entidadSede.Id_Sede, entidadCompra.Id_Compra);
            Empleados entidadEmpleado = DatosHelper.CrearEmpleado(this.iConexion);
            Prestamos entidadPrestamo = DatosHelper.CrearPrestamo(this.iConexion, entidadContrato.Id_Contrato);
            Mantenimientos entidadMantenimiento = DatosHelper.CrearMantenimiento(this.iConexion, entidadPrestamo.Id_Prestamo, entidadEmpleado.Id_Persona, entidadPortatil.Id_Portatil);

            this.entidad = DatosHelper.CrearAseo_Elemento(this.iConexion, entidadTipo.Id_Tipo_Aseo_Elemento, entidadMantenimiento.Id_Mantenimiento);
            if (this.entidad!.Id_Aseo_Elemento != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Aseo_Elementos> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Marca = "Chowder";
            Aseo_Elementos resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Aseo_Elemento != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Aseo_Elementos resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
