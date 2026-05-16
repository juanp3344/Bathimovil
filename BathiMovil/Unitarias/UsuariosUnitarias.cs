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
        private Personas? entidad2;
        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Consultar();
            Modificar();
            Borrar();
        }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Usuarios!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");


            this.entidad2 = new Personas()
            {

                Cedula = "7483238",
                Nombre = "Tomas",
                Correo = "asjdhkajds@gmail.com",
                Telefono = "2312312312"
            };
            this.iConexion.Personas!.Add(this.entidad2!);
            this.iConexion.SaveChanges();

            this.entidad = new Usuarios()
            {
             Username = "Mano",
             Password_Hash = "Chachau",
             Activo = true,
             Fecha_Ultimo_Acceso = DateTime.Now,
             Persona = entidad2.Id_Persona
    };
            this.iConexion.Usuarios!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Usuario != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Activo = false;

            var entry = this.iConexion!.Entry<Usuarios>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Usuario != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Usuarios!.Remove(this.entidad!);
            this.iConexion.Personas!.Remove(this.entidad2!);
            this.iConexion.SaveChanges();
        }
    }
}
