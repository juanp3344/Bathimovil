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
    public class PortatilesUnitaria
    {
        private IConexion? iConexion;
        private Portatiles? entidad;
        private Tipos_Portatiles? entidadTPortatil;
        private Sedes? entidadSEDES;
        private Compras?  entidadCompra;
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
            var lista = iConexion.Portatiles!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private Portatiles Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            //////////////////////////////// portatiles

            this.entidadTPortatil = new Tipos_Portatiles()
            {

                Nombre = "Andrés",
                Descripcion = "Ajá",
                Altura = 3,
                Ancho = 2,
                Largo = 1

            };
            this.iConexion.Tipos_Portatiles!.Add(this.entidadTPortatil!);
            this.iConexion.SaveChanges();

            ///////////////////////////////////
            ///

            ////////////////////////7 SEDES

            this.entidadSEDES = new Sedes()
            {
                Nombre = "Robledo",
                Direccion = "Calle 45-c",
                Ciudad = "Medellín",
                Telefono_Contacto = "312802222"

            };
            this.iConexion.Sedes!.Add(this.entidadSEDES!);
            this.iConexion.SaveChanges();
            ///////////////
            ///

            //////////////////////// COMPRAS

            this.entidadCliente = new Clientes()
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

            this.entidadCompra = new Compras()
            {

                Fecha_Compra = DateTime.Now,
                Monto_Total = 121212,
                Metodo_Pago = "Nequi",
                Garantia_Meses = 12,
                Contrato = entidadContrato.Id_Contrato
            };
            this.iConexion.Compras!.Add(this.entidadCompra!);
            this.iConexion.SaveChanges();

            //////77777

            this.entidad = new Portatiles()
            {

                Numero_Serial = "12342",
                Fecha_Fabricacion = DateTime.Now,
                Estado_Actual = "Bueno",
               Tipo_Portatil = entidadTPortatil.Id_Tipo_Portatil,
               Sede = entidadSEDES.Id_Sede,
               Compra = entidadCompra.Id_Compra
            };
            this.iConexion.Portatiles!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Portatil != 0)
                return entidad;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Estado_Actual = "Soporífero";

            var entry = this.iConexion!.Entry<Portatiles>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Portatil != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Portatiles!.Remove(this.entidad!);
            this.iConexion.Clientes!.Remove(this.entidadCliente!);
            this.iConexion.Compras!.Remove(this.entidadCompra!);
            this.iConexion.Contratos!.Remove(this.entidadContrato!);
            this.iConexion.Sedes!.Remove(this.entidadSEDES!);
            this.iConexion.Tipos_Portatiles!.Remove(this.entidadTPortatil!);
            this.iConexion.SaveChanges();
        }
    }
}
