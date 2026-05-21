using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class PagosPresentacion : IPagosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Pagos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Pagos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Pagos>();

            return JsonConvert.DeserializeObject<List<Pagos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Pagos Guardar(Pagos entidad)
        {
            if (entidad.Id_Pago != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Pagos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Pagos();

            return JsonConvert.DeserializeObject<Pagos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Pagos Modificar(Pagos entidad)
        {
            if (entidad.Id_Pago == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Pagos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Pagos();

            return JsonConvert.DeserializeObject<Pagos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Pagos Eliminar(Pagos entidad)
        {
            if (entidad.Id_Pago == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Pagos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Pagos();

            return JsonConvert.DeserializeObject<Pagos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
