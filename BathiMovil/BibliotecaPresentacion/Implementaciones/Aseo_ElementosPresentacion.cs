using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class Aseo_ElementosPresentacion: IAseo_ElementosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Aseo_Elementos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Aseo_Elementos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Aseo_Elementos>();

            return JsonConvert.DeserializeObject<List<Aseo_Elementos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Aseo_Elementos Guardar(Aseo_Elementos entidad)
        {
            if (entidad.Id_Aseo_Elemento != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Aseo_Elementos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Aseo_Elementos();

            return JsonConvert.DeserializeObject<Aseo_Elementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Aseo_Elementos Modificar(Aseo_Elementos entidad)
        {
            if (entidad.Id_Aseo_Elemento == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Aseo_Elementos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Aseo_Elementos();

            return JsonConvert.DeserializeObject<Aseo_Elementos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Aseo_Elementos Eliminar(Aseo_Elementos entidad)
        {
            if (entidad.Id_Aseo_Elemento == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Aseo_Elementos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Aseo_Elementos();

            return JsonConvert.DeserializeObject<Aseo_Elementos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
