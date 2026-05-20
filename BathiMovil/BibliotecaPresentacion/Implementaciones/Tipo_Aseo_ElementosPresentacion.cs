using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class Tipo_Aseo_ElementosPresentacion : ITipo_Aseo_ElementosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Tipo_Aseo_Elementos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipo_Aseo_Elementos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Tipo_Aseo_Elementos>();

            return JsonConvert.DeserializeObject<List<Tipo_Aseo_Elementos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipo_Aseo_Elementos Guardar(Tipo_Aseo_Elementos entidad)
        {
            if (entidad.Id_Tipo_Aseo_Elemento != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipo_Aseo_Elementos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipo_Aseo_Elementos();

            return JsonConvert.DeserializeObject<Tipo_Aseo_Elementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipo_Aseo_Elementos Modificar(Tipo_Aseo_Elementos entidad)
        {
            if (entidad.Id_Tipo_Aseo_Elemento == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipo_Aseo_Elementos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipo_Aseo_Elementos();

            return JsonConvert.DeserializeObject<Tipo_Aseo_Elementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipo_Aseo_Elementos Eliminar(Tipo_Aseo_Elementos entidad)
        {
            if (entidad.Id_Tipo_Aseo_Elemento == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipo_Aseo_Elementos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipo_Aseo_Elementos();

            return JsonConvert.DeserializeObject<Tipo_Aseo_Elementos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
