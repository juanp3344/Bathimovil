using BibliotecaPresentacion.Intefaces;
using BibliotecaServicios.Entidades;
using Newtonsoft.Json;
namespace BibliotecaPresentacion.Implementaciones
{
    public class Detalle_FacturasPresentacion: IDetalle_FacturasPresentacion
    {
        private IComunicaciones? iComunicaciones;

        public List<Detalle_Facturas> Consultar()
        {
            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Detalle_Facturas/Consultar";

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.Ejecutar(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new List<Detalle_Facturas>();

            return JsonConvert.DeserializeObject<List<Detalle_Facturas>>(
                respuesta["Valor"].ToString()!)!;
        }

        public Detalle_Facturas Guardar(Detalle_Facturas entidad)
        {
            if (entidad.Id_Detalle != 0)
                throw new Exception("Ya se guardo");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Detalle_Facturas/Guardar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPost(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Detalle_Facturas();

            return JsonConvert.DeserializeObject<Detalle_Facturas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Detalle_Facturas Modificar(Detalle_Facturas entidad)
        {
            if (entidad.Id_Detalle == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Detalle_Facturas/Modificar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarPut(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Detalle_Facturas();

            return JsonConvert.DeserializeObject<Detalle_Facturas>(
                respuesta["Valor"].ToString()!)!;
        }

        public Detalle_Facturas Eliminar(Detalle_Facturas entidad)
        {
            if (entidad.Id_Detalle == 0)
                throw new Exception("No se ha guardado");

            this.iComunicaciones = new Comunicaciones();

            var datos = new Dictionary<string, object>();
            datos["Url"] = "http://localhost:5010/Detalle_Facturas/Eliminar";
            datos["Entidad"] = entidad;

            this.iComunicaciones = new Comunicaciones();
            var task = this.iComunicaciones.EjecutarDelete(datos)!;
            task.Wait();
            var respuesta = task.Result;

            if (!respuesta.ContainsKey("Valor"))
                return new Detalle_Facturas();

            return JsonConvert.DeserializeObject<Detalle_Facturas>(
                respuesta["Valor"].ToString()!)!;
        }
    }
}
