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
    public class Tipo_ImplementosUnitaria
    {
        private IConexion? iConexion;
        private Tipo_Implementos? entidad;

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
            var lista = iConexion.Tipo_Implementos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = new Tipo_Implementos()
            {
       Nombre = "Escoba",
         Descripcion= "Barre",
         Ancho = 12,
         Largo = 12,
        Alto = 12
    };
            this.iConexion.Tipo_Implementos!.Add(this.entidad!);
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

            var entry = this.iConexion!.Entry<Tipo_Implementos>(this.entidad!);
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

            this.iConexion.Tipo_Implementos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
