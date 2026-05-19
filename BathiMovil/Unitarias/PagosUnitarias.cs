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
    public class PagosUnitaria
    {
        private IConexion? iConexion;
        private Pagos? entidad;
        private Clientes? entidadCliente;
        private Facturas? entidadFactura;
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
            var lista = iConexion.Pagos!.ToList();
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
                Cedula = "857847684",
                Nombre = "Tomas",
                Correo = "asjdhkajds@gmail.com",
                Telefono = "2312312312"
            };
            this.iConexion.Clientes!.Add(this.entidadCliente!);
            this.iConexion.SaveChanges();

            this.entidadFactura = new Facturas()
            {

                Numero = "12121212",
                Fecha_Emision = DateTime.Now,
                Total = 121212,
                Impuesto_Iva = 12,
                Cliente = entidadCliente.Id_Persona
            };
            this.iConexion.Facturas!.Add(this.entidadFactura!);
            this.iConexion.SaveChanges();

            this.entidad = new Pagos()
            {

        Total_Pagado = 123123,
         Fecha_Pago = DateTime.Now,
        Referencia_Bancaria = "Bancolombia",
        Metodo_Pago = "Tarjeta", 
        Factura = entidadFactura.Id_Factura
            };
            this.iConexion.Pagos!.Add(this.entidad!);
            this.iConexion.SaveChanges();



            if (this.entidad!.Id_Pago != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Referencia_Bancaria = "Davivienda";

            var entry = this.iConexion!.Entry<Pagos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Pago != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Pagos!.Remove(this.entidad!);
            this.iConexion.Facturas!.Remove(this.entidadFactura!);
            this.iConexion.Clientes!.Remove(this.entidadCliente!);
            this.iConexion.SaveChanges();
        }
    }
}
