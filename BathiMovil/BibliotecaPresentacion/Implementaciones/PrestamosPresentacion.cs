using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class PrestamosPresentacion : IPrestamosPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Prestamos> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Prestamos/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Prestamos>();

            return JsonConvert.DeserializeObject<List<Prestamos>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Prestamos Guardar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Prestamos/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Prestamos();

            return JsonConvert.DeserializeObject<Prestamos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Prestamos Modificar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Prestamos/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Prestamos();

            return JsonConvert.DeserializeObject<Prestamos>(
                respuesta["Valor"].ToString()!)!;
        }

        public Prestamos Eliminar(Prestamos entidad)
        {
            if (entidad.Id_Prestamo == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Prestamos/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Prestamos();

            return JsonConvert.DeserializeObject<Prestamos>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
