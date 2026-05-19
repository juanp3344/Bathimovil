using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaPresentacion.Implementaciones
{
    public class ComprasPresentacion: IComprasPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Compras> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Compras/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Compras>();

            return JsonConvert.DeserializeObject<List<Compras>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Compras Guardar(Compras entidad)
        {
            if (entidad.Id_Compra != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Compras/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Compras();

            return JsonConvert.DeserializeObject<Compras>(
                respuesta["Valor"].ToString()!)!;
        }

        public Compras Modificar(Compras entidad)
        {
            if (entidad.Id_Compra == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Compras/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Compras();

            return JsonConvert.DeserializeObject<Compras>(
                respuesta["Valor"].ToString()!)!;
        }

        public Compras Eliminar(Compras entidad)
        {
            if (entidad.Id_Compra == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Compras/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Compras();

            return JsonConvert.DeserializeObject<Compras>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
