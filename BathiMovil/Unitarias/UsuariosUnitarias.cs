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
    public class UsuariosUnitaria
    {
        private IConexion? iConexion;
        private Usuarios? entidad;
        private Clientes? entidadCliente;
        private Roles? entidadRol;

        [TestMethod]
        public void Ejecutar() { Guardar(); Consultar(); Modificar(); Borrar(); }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Usuarios!.ToList();
            if (lista.Count > 0) return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidadCliente = DatosHelper.CrearCliente(this.iConexion);
            this.entidadRol = DatosHelper.CrearRol(this.iConexion);
            this.entidad = DatosHelper.CrearUsuario(this.iConexion, entidadCliente.Id_Persona, entidadRol.Id_Rol);
            if (this.entidad!.Id_Usuario != 0) return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.entidad!.Username = "Chowder";
            var entry = this.iConexion!.Entry<Usuarios>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            if (entidad!.Id_Usuario != 0) return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            this.iConexion.Usuarios!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            this.iConexion.Clientes!.Remove(this.entidadCliente!);
            this.iConexion.Roles!.Remove(this.entidadRol!);
            this.iConexion.SaveChanges();
        }
    }
}
