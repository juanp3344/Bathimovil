using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class RolesPresentacion : IRolesPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Roles_Empleados> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles_Empleados/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Roles_Empleados>();

            return JsonConvert.DeserializeObject<List<Roles_Empleados>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles_Empleados Guardar(Roles_Empleados entidad)
        {
            if (entidad.Id_Roles_Empleado != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles_Empleados/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles_Empleados();

            return JsonConvert.DeserializeObject<Roles_Empleados>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles_Empleados Modificar(Roles_Empleados entidad)
        {
            if (entidad.Id_Roles_Empleado == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles_Empleados/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles_Empleados();

            return JsonConvert.DeserializeObject<Roles_Empleados>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles_Empleados Eliminar(Roles_Empleados entidad)
        {
            if (entidad.Id_Roles_Empleado == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles_Empleados/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles_Empleados();

            return JsonConvert.DeserializeObject<Roles_Empleados>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
