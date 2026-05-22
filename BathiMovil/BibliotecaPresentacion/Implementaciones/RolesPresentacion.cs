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

        public List<Roles> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Roles>();

            return JsonConvert.DeserializeObject<List<Roles>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles Guardar(Roles entidad)
        {
            if (entidad.Id_Rol != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles();

            return JsonConvert.DeserializeObject<Roles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles Modificar(Roles entidad)
        {
            if (entidad.Id_Rol == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles();

            return JsonConvert.DeserializeObject<Roles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Roles Eliminar(Roles entidad)
        {
            if (entidad.Id_Rol == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Roles/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Roles();

            return JsonConvert.DeserializeObject<Roles>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
