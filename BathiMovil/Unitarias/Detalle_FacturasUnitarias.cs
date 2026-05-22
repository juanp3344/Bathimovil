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
public class Detalle_FacturasUnitaria
{
    private IConexion? iConexion;
    private Detalle_Facturas? entidad;

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
        var lista = iConexion.Detalle_Facturas!.ToList();
        if (lista.Count > 0)
            return;
        throw new Exception("");
    }

    private void Guardar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.entidad = new Detalle_Facturas()
        {

};
        this.iConexion.Detalle_Facturas!.Add(this.entidad!);
        this.iConexion.SaveChanges();

        if (this.entidad!.Id_Detalle != 0)
            return;
        throw new Exception("");
    }

    private void Modificar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.entidad!.Cantidad= 12;

        var entry = this.iConexion!.Entry<Detalle_Facturas>(this.entidad!);
        entry.State = EntityState.Modified;
        this.iConexion!.SaveChanges();

        if (entidad!.Id_Detalle != 0)
            return;
        throw new Exception("");
    }

    private void Borrar()
    {
        this.iConexion = new Conexion();
        this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

        this.iConexion.Detalle_Facturas!.Remove(this.entidad!);
        this.iConexion.SaveChanges();
    }
}
}
