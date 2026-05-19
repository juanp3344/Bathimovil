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
    public class Historial_PreciosUnitaria
    {
        private IConexion? iConexion;
        private Historial_Precios? entidad;
        private Tipos_Portatiles? entidadTPortatl;
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
            var lista = iConexion.Historial_Precios!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidadTPortatl = new Tipos_Portatiles()
            {

                Nombre = "Andrés",
                Descripcion = "Ajá",
                Altura = 3,
                Ancho = 2,
                Largo = 1

            };
            this.iConexion.Tipos_Portatiles!.Add(this.entidadTPortatl!);
            this.iConexion.SaveChanges();

            this.entidad = new Historial_Precios()
            {

        Valor = 12000,
         Fecha_Inicio =DateTime.Now,
        Fecha_Fin =DateTime.Now,
        Motivo_Cambio = "Porque si",
        Tipo_Portatil = entidadTPortatl.Id_Tipo_Portatil
    };
            this.iConexion.Historial_Precios!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Historial != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Motivo_Cambio = "Porque me dio la gana";

            var entry = this.iConexion!.Entry<Historial_Precios>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Historial != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Historial_Precios!.Remove(this.entidad!);
            this.iConexion.Tipos_Portatiles!.Remove(this.entidadTPortatl!);
            this.iConexion.SaveChanges();
        }
    }
}
