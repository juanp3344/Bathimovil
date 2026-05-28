using BibliotecaPresentacion.Implementaciones;
using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using BibliotecaServicios.Implementaciones;
using BibliotecaServicios.Interfaces;
using BibliotecaServicios.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Unitarias;

namespace UnitariasPresentacion
{
    [TestClass]
    public class ComunicacionesUnitariasPresentacion
    {
        private IComunicaciones iComunicaciones = new Comunicaciones();

        [TestMethod]
        public void Ejecutar() { EjecutarGet(); EjecutarPost(); EjecutarPut(); EjecutarDelete(); }

        private void EjecutarGet()
        {
            var datos = new Dictionary<string, object> { ["Url"] = "http://localhost:5010/Roles/Consultar" };
            var task = this.iComunicaciones.Ejecutar(datos); task.Wait();
            if (task.Result.ContainsKey("Valor")) return;
            throw new Exception("");
        }

        private void EjecutarPost()
        {
            var datos = new Dictionary<string, object>
            {
                ["Url"] = "http://localhost:5010/Roles/Guardar",
                ["Entidad"] = new Roles { Nombre_Rol = "RolTest", Descripcion_Rol = "Test", Salario_Empleado = 3_000_000m }
            };
            var task = this.iComunicaciones.EjecutarPost(datos); task.Wait();
            if (task.Result.ContainsKey("Valor")) return;
            throw new Exception("");
        }

        private void EjecutarPut()
        {
            var pres = new RolesPresentacion();
            var lista = pres.Consultar();
            if (lista.Count == 0) throw new Exception("");
            var rol = lista.First(); rol.Nombre_Rol = "RolModificado";
            var datos = new Dictionary<string, object> { ["Url"] = "http://localhost:5010/Roles/Modificar", ["Entidad"] = rol };
            var task = this.iComunicaciones.EjecutarPut(datos); task.Wait();
            if (task.Result.ContainsKey("Valor")) return;
            throw new Exception("");
        }

        private void EjecutarDelete()
        {
            var pres = new RolesPresentacion();
            var lista = pres.Consultar();
            if (lista.Count == 0) throw new Exception("");
            var rol = lista.Last();
            var datos = new Dictionary<string, object> { ["Url"] = "http://localhost:5010/Roles/Eliminar", ["Entidad"] = rol };
            var task = this.iComunicaciones.EjecutarDelete(datos); task.Wait();
            if (task.Result.ContainsKey("Valor")) return;
            throw new Exception("");
        }
    }
}
