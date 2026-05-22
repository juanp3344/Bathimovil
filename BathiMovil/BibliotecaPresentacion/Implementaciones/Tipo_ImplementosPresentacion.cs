using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class Tipos_ImplementosPresentacion : ITipo_ImplementosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Tipos_Implementos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Implementos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Tipos_Implementos>();

            return JsonConvert.DeserializeObject<List<Tipos_Implementos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Implementos Guardar(Tipos_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Implementos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Implementos();

            return JsonConvert.DeserializeObject<Tipos_Implementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Implementos Modificar(Tipos_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Implementos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Implementos();

            return JsonConvert.DeserializeObject<Tipos_Implementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Implementos Eliminar(Tipos_Implementos entidad)
        {
            if (entidad.Id_Tipo_Implemento == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Implementos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Implementos();

            return JsonConvert.DeserializeObject<Tipos_Implementos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
