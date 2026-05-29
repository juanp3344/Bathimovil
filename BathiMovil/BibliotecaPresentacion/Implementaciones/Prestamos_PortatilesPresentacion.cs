using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class Prestamos_PortatilesPresentacion : IPrestamos_PortatilesPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Prestamos_Portatiles> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Prestamos_Portatiles/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Prestamos_Portatiles>();

            return JsonConvert.DeserializeObject<List<Prestamos_Portatiles>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Prestamos_Portatiles Guardar(Prestamos_Portatiles entidad)
        {
            if (entidad.Id_Prestamo_Portatil != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Prestamos_Portatiles/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Prestamos_Portatiles();

            return JsonConvert.DeserializeObject<Prestamos_Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Prestamos_Portatiles Modificar(Prestamos_Portatiles entidad)
        {
            if (entidad.Id_Prestamo_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Prestamos_Portatiles/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Prestamos_Portatiles();

            return JsonConvert.DeserializeObject<Prestamos_Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }

        public Prestamos_Portatiles Eliminar(Prestamos_Portatiles entidad)
        {
            if (entidad.Id_Prestamo_Portatil == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Prestamos_Portatiles/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Prestamos_Portatiles();

            return JsonConvert.DeserializeObject<Prestamos_Portatiles>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
