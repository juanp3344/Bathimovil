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
    public class Tipos_IntermediaUnitaria
    {
        private IConexion? iConexion;
        private Tipos_Intermedia? entidad;
        private Tipos_Implementos? entidad2;
        private Tipos_Portatiles? entidad3;
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
            var lista = iConexion.Tipos_Intermedia!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad2 = new Tipos_Implementos()
            {
                Nombre = "Escoba",
                Descripcion = "Barre",
                Ancho = 12m,
                Largo = 12m,
                Altura = 12m
            };
            this.iConexion.Tipos_Implementos!.Add(this.entidad2!);
            this.iConexion.SaveChanges();
            this.entidad3 = new Tipos_Portatiles()
            {

                Nombre = "Andrés",
                Descripcion = "Ajá",
                Altura = 3,
                Ancho = 2,
                Largo = 1

            };
            this.iConexion.Tipos_Portatiles!.Add(this.entidad3!);
            this.iConexion.SaveChanges();
            this.entidad = new Tipos_Intermedia()
            {
                Tipo_Implemento = entidad2.Id_Tipo_Implemento,
                Posicion_Montaje = "Arribita",
                Tipo_Portatil = entidad3.Id_Tipo_Portatil

            };

            
            this.iConexion.Tipos_Intermedia!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Tipos_Intermedia != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Posicion_Montaje = "Abajo del espejo";

            var entry = this.iConexion!.Entry<Tipos_Intermedia>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Tipos_Intermedia != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            
            this.iConexion.Tipos_Intermedia!.Remove(this.entidad!);
            this.iConexion.Tipos_Implementos!.Remove(this.entidad2!);
            this.iConexion.Tipos_Portatiles!.Remove(this.entidad3!);
            this.iConexion.SaveChanges();
        }
    }
}
