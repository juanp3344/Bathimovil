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
    public class Tipos_PortatilesUnitaria
    {
        private IConexion? iConexion;
        private Tipos_Portatiles? entidad;

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
            var lista = iConexion.Tipos_Portatiles!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = new Tipos_Portatiles()
            {

             Nombre = "Andrés",
             Descripcion = "Ajá",
             Altura = 3,
             Ancho = 2,
             Largo = 1

    };
            this.iConexion.Tipos_Portatiles!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Tipo_Portatil != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Altura = 1.90;

            var entry = this.iConexion!.Entry<Tipos_Portatiles>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Tipo_Portatil != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Tipos_Portatiles!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
