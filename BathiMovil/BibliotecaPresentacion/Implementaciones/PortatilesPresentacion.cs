using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class PortatilesPresentacion : IPortatilesPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Portatiles> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Portatiles/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Portatiles>();

            return JsonConvert.DeserializeObject<List<Portatiles>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Portatiles Guardar(Portatiles entidad)
        {
            if (entidad.Id_Portatil != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Portatiles/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Portatiles();

            return JsonConvert.DeserializeObject<Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Portatiles Modificar(Portatiles entidad)
        {
            if (entidad.Id_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Portatiles/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Portatiles();

            return JsonConvert.DeserializeObject<Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Portatiles Eliminar(Portatiles entidad)
        {
            if (entidad.Id_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Portatiles/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Portatiles();

            return JsonConvert.DeserializeObject<Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
