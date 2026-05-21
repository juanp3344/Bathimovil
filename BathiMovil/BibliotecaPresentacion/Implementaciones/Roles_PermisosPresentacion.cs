using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class Roles_PermisosPresentacion : IRoles_PermisosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Roles_Permisos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles_Permisos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Roles_Permisos>();

            return JsonConvert.DeserializeObject<List<Roles_Permisos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles_Permisos Guardar(Roles_Permisos entidad)
        {
            if (entidad.Id_Roles_Permiso != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles_Permisos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles_Permisos();

            return JsonConvert.DeserializeObject<Roles_Permisos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles_Permisos Modificar(Roles_Permisos entidad)
        {
            if (entidad.Id_Roles_Permiso == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles_Permisos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles_Permisos();

            return JsonConvert.DeserializeObject<Roles_Permisos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles_Permisos Eliminar(Roles_Permisos entidad)
        {
            if (entidad.Id_Roles_Permiso == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles_Permisos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles_Permisos();

            return JsonConvert.DeserializeObject<Roles_Permisos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
