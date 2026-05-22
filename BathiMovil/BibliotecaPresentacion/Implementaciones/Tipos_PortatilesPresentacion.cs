using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class Tipos_PortatilesPresentacion : ITipos_PortatilesPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Tipos_Portatiles> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Portatiles/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Tipos_Portatiles>();

            return JsonConvert.DeserializeObject<List<Tipos_Portatiles>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Portatiles Guardar(Tipos_Portatiles entidad)
        {
            if (entidad.Id_Tipo_Portatil != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Portatiles/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Portatiles();

            return JsonConvert.DeserializeObject<Tipos_Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Portatiles Modificar(Tipos_Portatiles entidad)
        {
            if (entidad.Id_Tipo_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Portatiles/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Portatiles();

            return JsonConvert.DeserializeObject<Tipos_Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Tipos_Portatiles Eliminar(Tipos_Portatiles entidad)
        {
            if (entidad.Id_Tipo_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Tipos_Portatiles/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Tipos_Portatiles();

            return JsonConvert.DeserializeObject<Tipos_Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
