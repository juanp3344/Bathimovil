using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class SedesPresentacion : ISedesPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Sedes> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Sedes/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Sedes>();

            return JsonConvert.DeserializeObject<List<Sedes>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Sedes Guardar(Sedes entidad)
        {
            if (entidad.Id_Sede != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Sedes/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Sedes();

            return JsonConvert.DeserializeObject<Sedes>(
                respuesta["Valor"].ToString()!)!;
        }

        public Sedes Modificar(Sedes entidad)
        {
            if (entidad.Id_Sede == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Sedes/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Sedes();

            return JsonConvert.DeserializeObject<Sedes>(
                respuesta["Valor"].ToString()!)!;
        }

        public Sedes Eliminar(Sedes entidad)
        {
            if (entidad.Id_Sede == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Sedes/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Sedes();

            return JsonConvert.DeserializeObject<Sedes>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
