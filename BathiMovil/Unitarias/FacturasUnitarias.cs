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
    public class FacturasUnitaria
    {
        private IConexion? iConexion;
        private Facturas? entidad;
        private Clientes? entidadCliente;
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
            var lista = iConexion.Facturas!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidadCliente = new Clientes()
            {
                //Tipo_Cliente = Clientes.CategoriaCliente.Constructora,
                Razon_Social = "Mucha razon",

                Nit_CC = "121434",
                Direccion_Fiscal = "Carrera 55",
                Cedula = "4535345656",
                Nombre = "Tomas",
                Correo = "asjdhkajds@gmail.com",
                Telefono = "2312312312"
            };
            this.iConexion.Clientes!.Add(this.entidadCliente!);
            this.iConexion.SaveChanges();

            this.entidad = new Facturas()
            {

        Numero = "12121212",
        Fecha_Emision = DateTime.Now,
            Total = 121212,
        Impuesto_Iva = 12, 
        Cliente = entidadCliente.Id_Persona
    };
            this.iConexion.Facturas!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Factura != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Numero = "1290890";

            var entry = this.iConexion!.Entry<Facturas>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Factura != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Facturas!.Remove(this.entidad!); 
            this.iConexion.Clientes!.Remove(this.entidadCliente!);
            this.iConexion.SaveChanges();
        }
    }
}
