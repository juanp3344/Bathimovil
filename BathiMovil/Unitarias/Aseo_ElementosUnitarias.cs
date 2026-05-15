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
    public class Aseo_ElementosUnitaria
    {
        private IConexion? iConexion;
        private Aseo_Elementos? entidad;

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
            var lista = iConexion.Aseo_Elementos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad = new Aseo_Elementos()
            {

        Fecha_Vencimiento = DateTime.Now,
        Cantidad = 1,
        Marca = "De agua",
        Costo = 1000000000
    };
            this.iConexion.Aseo_Elementos!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Aseo_Elemento != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Costo = 10;

            var entry = this.iConexion!.Entry<Aseo_Elementos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Aseo_Elemento != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Aseo_Elementos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
