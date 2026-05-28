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
    public class UsuariosUnitariasPresentacion
    {
        private IUsuariosPresentacion iPresentacion = new UsuariosPresentacion();
        private IConexion? iConexion;
        private Usuarios? entidad;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Eliminar(); }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            Personas entidadPersona = DatosHelper.CrearPersona(this.iConexion);
            Roles entidadRol = DatosHelper.CrearRol(this.iConexion);

            this.entidad = DatosHelper.CrearUsuario(this.iConexion, entidadPersona.Id_Persona, entidadRol.Id_Rol);
            if (this.entidad!.Id_Usuario != 0) return;
            throw new Exception("");
        }

        private void Consultar()
        {
            List<Usuarios> lista = this.iPresentacion.Consultar();
            if (lista != null) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.entidad!.Username = "Chowder";
            Usuarios resultado = this.iPresentacion.Modificar(this.entidad!);
            if (resultado!.Id_Usuario != 0) return;
            throw new Exception("");
        }

        private void Eliminar()
        {
            Usuarios resultado = this.iPresentacion.Eliminar(this.entidad!);
            if (resultado != null) return;
            throw new Exception("");
        }
    }
}
