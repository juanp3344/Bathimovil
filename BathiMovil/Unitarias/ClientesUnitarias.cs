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
    public class ClientesUnitaria
    {
        private IConexion? iConexion;
        private Clientes? entidad;

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
            var lista = iConexion.Clientes!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = new Clientes()
            {
                 Tipo_Cliente = Clientes.CategoriaCliente.Constructora,
                 Razon_Social = "Mucha razon",
           
                 Nit_CC = "121434",
                 Direccion_Fiscal = "Carrera 55",
    };
            this.iConexion.Clientes!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Persona != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Razon_Social = "Ninguna";

            var entry = this.iConexion!.Entry<Clientes>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Persona != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Clientes!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
