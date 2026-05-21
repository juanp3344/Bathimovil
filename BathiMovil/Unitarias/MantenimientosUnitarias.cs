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
    public class MantenimientosUnitaria
    {
        private IConexion? iConexion;
        private Mantenimientos? entidad;
        private Empleados? entidadEMPLEADO;
        private Roles? entidadROLES;

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
            var lista = iConexion.Mantenimientos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");
            // EMPLEADOS



            this.entidadROLES = new Roles()
            {
                // Permisos = Roles.Niveles_Acceso.superadmin,
                Nombre_Rol = "Benson",
                Descripcion_Rol = "Regañar a Mordecai y a Rigby",
                Salario_Base = 12000000m
            };
            this.iConexion.Roles!.Add(this.entidadROLES!);
            this.iConexion.SaveChanges();

            this.entidadEMPLEADO = new Empleados()
            {
                Fecha_Ingreso = DateTime.Now,
                Cedula = "7483238",
                Nombre = "Tomas",
                Correo = "asjdhkajds@gmail.com",
                Telefono = "2312312312",
                Id_Rol = entidadROLES.Id_Rol

            };
            this.iConexion.Empleados!.Add(this.entidadEMPLEADO!);
            this.iConexion.SaveChanges();
            //////////////////////////////////////////////////////////////////////////
            this.entidad = new Mantenimientos()
            {
      
        Fecha_Servicio =DateTime.Now,
         Tipo_Mantenimiento= "Duro",
         Descripcion_Trabajo= "Hay que limpiar el sanitario",
        Costo_Mano_Obra = 12121212,
        Empleado = entidadEMPLEADO.Id_Persona,
        
    };
            this.iConexion.Mantenimientos!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad!.Id_Mantenimiento != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.entidad!.Tipo_Mantenimiento = "Facil";

            var entry = this.iConexion!.Entry<Mantenimientos>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad!.Id_Mantenimiento != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.string_conexion = Configuraciones.obtener("string_conexion");

            this.iConexion.Mantenimientos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
