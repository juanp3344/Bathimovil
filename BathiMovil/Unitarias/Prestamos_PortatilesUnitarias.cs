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
    public class Prestamos_PortatilesUnitaria
    {
        private IConexion? iConexion;
        private Prestamos_Portatiles? entidad;
        private Portatiles? entidadPortatiles;
        private Tipos_Portatiles? entidadTPortatiles;
        private Sedes? entidadSedes;
        private Clientes? entidadClientes;
        private Contratos? entidadContratos;
        private Compras? entidadCompras;


        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Consultar();
            Modificar();
            Borrar();
        }

        public void Cargarportatil()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            //////////////////////////////// portatiles

            this.entidadTPortatiles = new Tipos_Portatiles()
            {

                Nombre = "Andrés",
                Descripcion = "Ajá",
                Altura = 3,
                Ancho = 2,
                Largo = 1

            };
            this.iConexion.Tipos_Portatiles!.Add(this.entidadTPortatiles!);
            this.iConexion.SaveChanges();

            ///////////////////////////////////
            ///

            ////////////////////////7 SEDES

            this.entidadSedes = new Sedes()
            {
                Nombre = "Robledo",
                Direccion = "Calle 45-c",
                Ciudad = "Medellín",
                Telefono_Contacto = "312802222"

            };
            this.iConexion.Sedes!.Add(this.entidadSedes!);
            this.iConexion.SaveChanges();
            ///////////////
            ///

            //////////////////////// COMPRAS

            this.entidadClientes = new Clientes()
            {
                //Tipo_Cliente = Clientes.CategoriaCliente.Constructora,
                Razon_Social = "Mucha razon",

                Nit_CC = "121434",
                Direccion_Fiscal = "Carrera 55",
                Cedula = "5468954654",
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

            this.entidadCompras = new Compras()
            {

                Fecha_Compra = DateTime.Now,
                Monto_Total = 121212,
                Metodo_Pago = "Nequi",
                Garantia_Meses = 12,
                Contrato = entidadContratos.Id_Contrato
            };
            this.iConexion.Compras!.Add(this.entidadCompras!);
            this.iConexion.SaveChanges();

            //////77777

            this.entidadPortatiles = new Portatiles()
            {

                Numero_Serial = "12342",
                Fecha_Fabricacion = DateTime.Now,
                Estado_Actual = "Bueno",
                Tipo_Portatil = entidadTPortatiles.Id_Tipo_Portatil,
                Sede = entidadSedes.Id_Sede,
                Compra = entidadCompras.Id_Compra
            };
            this.iConexion.Portatiles!.Add(this.entidadPortatiles!);
            this.iConexion.SaveChanges();

        }
        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            var lista = iConexion.Prestamos_Portatiles!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            var portatil = new PortatilesUnitaria();

            this.entidad = new Prestamos_Portatiles()
            {


        Prestamo = 1,
        Portatil = 2
    };
            this.iConexion.Prestamos_Portatiles!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Prestamo_Portatil != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Prestamo = 2;

            var entry = this.iConexion!.Entry<Prestamos_Portatiles>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Prestamo_Portatil != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Prestamos_Portatiles!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
