using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class Tipos_IntermediaPresentacion : ITipos_IntermediaPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Tipos_Intermedia> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Intermedia/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Tipos_Intermedia>();

            return JsonConvert.DeserializeObject<List<Tipos_Intermedia>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Intermedia Guardar(Tipos_Intermedia entidad)
        {
            if (entidad.Id_Tipos_Intermedia != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Intermedia/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Intermedia();

            return JsonConvert.DeserializeObject<Tipos_Intermedia>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Intermedia Modificar(Tipos_Intermedia entidad)
        {
            if (entidad.Id_Tipos_Intermedia == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Intermedia/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Intermedia();

            return JsonConvert.DeserializeObject<Tipos_Intermedia>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Intermedia Eliminar(Tipos_Intermedia entidad)
        {
            if (entidad.Id_Tipos_Intermedia == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Intermedia/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Intermedia();

            return JsonConvert.DeserializeObject<Tipos_Intermedia>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
