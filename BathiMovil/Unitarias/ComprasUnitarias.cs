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
    public class ComprasUnitaria
    {
        private IConexion? iConexion;
        private Compras? entidad;
        private Clientes? entidadCliente;
        private Contratos? entidadContrato;


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
            var lista = iConexion.Compras!.ToList();
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
                Cedula = "4783484AC",
                Nombre = "Tomas",
                Correo = "asjdhkajds@gmail.com",
                Telefono = "2312312312"
            };
            this.iConexion.Clientes!.Add(this.entidadCliente!);
            this.iConexion.SaveChanges();

            this.entidadContrato = new Contratos()
            {
                Fecha_Firma = DateTime.Now,
                Terminos = "Me lo trae o le mando a los de la moto",
                Fecha_Expiracion = DateTime.Now,
                Cliente = entidadCliente.Id_Persona
            };
            this.iConexion.Contratos!.Add(this.entidadContrato!);
            this.iConexion.SaveChanges();

            this.entidad = new Compras()
            {

                Fecha_Compra = DateTime.Now,
                Monto_Total = 121212,
                Metodo_Pago = "Nequi",
                Garantia_Meses = 12,
                Contrato = entidadContrato.Id_Contrato
    };
            this.iConexion.Compras!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Compra != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Monto_Total = 12;

            var entry = this.iConexion!.Entry<Compras>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Compra != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Compras!.Remove(this.entidad!);
            this.iConexion.Contratos!.Remove(this.entidadContrato!);
            this.iConexion.Clientes!.Remove(this.entidadCliente!);

            this.iConexion.SaveChanges();
        }
    }
}
