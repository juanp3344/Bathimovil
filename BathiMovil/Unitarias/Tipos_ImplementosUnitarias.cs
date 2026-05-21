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
    public class Tipos_ImplementosUnitaria
    {
        private IConexion? iConexion;
        private Tipos_Implementos? entidad;

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
            var lista = iConexion.Tipos_Implementos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = new Tipos_Implementos()
            {
       Nombre = "Escoba",
         Descripcion= "Barre",
         Ancho = 12m,
         Largo = 12m,
        Altura = 12m
    };
            this.iConexion.Tipos_Implementos!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Tipo_Implemento != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Nombre = "Lil Pump";

            var entry = this.iConexion!.Entry<Tipos_Implementos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Tipo_Implemento != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Tipos_Implementos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
