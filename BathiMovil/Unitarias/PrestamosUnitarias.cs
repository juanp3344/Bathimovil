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
    public class PrestamosUnitaria
    {
        private IConexion? iConexion;
        private Prestamos? entidad;
        private Clientes? entidadClientes;
        private Contratos? entidadContratos;
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
            var lista = iConexion.Prestamos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            //Contrato
            this.entidadClientes = new Clientes()
            {
                //Tipo_Cliente = Clientes.CategoriaCliente.Constructora,
                Razon_Social = "Mucha razon",

                Nit_CC = "54645646",
                Direccion_Fiscal = "Carrera 55",
                Cedula = "543543556",
                Nombre = "Tomas",
                Correo = "asjdhkajds@gmail.com",
                Telefono = "2312312312"
            };
            this.iConexion.Clientes!.Add(this.entidadClientes!);
            this.iConexion.SaveChanges();

            this.entidadContratos = new Contratos()
            {
                Fecha_Firma = DateTime.Now,
                Terminos = "Me lo trae o le mando a los de la moto",
                Fecha_Expiracion = DateTime.Now,
                Cliente = entidadClientes.Id_Persona
            };
            this.iConexion.Contratos!.Add(this.entidadContratos!);
            this.iConexion.SaveChanges();

            ////////////////////////////////////////////////////////////////////////////7777
            this.entidad = new Prestamos()
            {

             Fecha_Inicio = DateTime.Now,
                Fecha_Fin_Prevista = DateTime.Now,
                 Estado_Prestamo = true ,
                 Contrato = entidadContratos.Id_Contrato,
                 
    };
            this.iConexion.Prestamos!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Prestamo != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Estado_Prestamo = false;

            var entry = this.iConexion!.Entry<Prestamos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Prestamo != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Prestamos!.Remove(this.entidad!);
            this.iConexion.Clientes!.Remove(this.entidadClientes!);
            this.iConexion.Contratos!.Remove(this.entidadContratos!);
            this.iConexion.SaveChanges();
        }
    }
 }

