using BibliotecaServicios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unitarias
{
    public class DatosHelper
    {
        public static Tipos_Portatiles GetTipo_Portatil(int id = 1) => new Tipos_Portatiles
        {
            Id_Tipo_Portatil = id,
            Nombre = $"Tipo Portátil {id}",
            Descripcion = "Portátil estándar de prueba",
            Altura = 25,
            Ancho = 35,
            Largo = 5
        };

        public static Sedes GetSede(int id = 1) => new Sedes
        {
            Id_Sede = id,
            Nombre = $"Sede {id}",
            Direccion = $"Calle {id * 10} # 20-30",
            Ciudad = "Medellín",
            Telefono_Contacto = $"604{id:D7}"
        };

        public static Compras GetCompra(int id = 1, int idContrato = 1) => new Compras
        {
            Id_Compra = id,
            Fecha_Compra = DateTime.Now.AddMonths(-6),
            Monto_Total = 15_000_000m,
            Metodo_Pago = "Transferencia",
            Garantia_Meses = 12,
            Contrato = idContrato
        };

        public static Portatiles GetPortatil(int id = 1, int idTipo = 1, int idSede = 1, int idCompra = 1) => new Portatiles
        {
            Id_Portatil = id,
            Numero_Serial = $"SN-{id:D6}",
            Fecha_Fabricacion = DateTime.Now.AddYears(-2),
            Estado_Actual = "Disponible",
            Tipo_Portatil = idTipo,
            Sede = idSede,
            Compra = idCompra,
            _Tipo_Portatil = GetTipo_Portatil(idTipo),
            _Sede = GetSede(idSede),
            _Compra = GetCompra(idCompra)
        };

        public static Tipos_Implementos GetTipo_Implemento(int id = 1) => new Tipos_Implementos
        {
            Id_Tipo_Implemento = id,
            Nombre = $"Tipo Implemento {id}",
            Descripcion = "Implemento de prueba",
            Ancho = 10m,
            Largo = 20m,
            Altura = 5m
        };

        public static Bodegas GetBodega(int id = 1, int idSede = 1, int idEmpleado = 1) => new Bodegas
        {
            Id_Bodega = id,
            Nombre = $"Bodega {id}",
            Ubicacion = $"Bloque {id}",
            Capacidad_Maxima = 100,
            Sede = idSede,
            Empleado = idEmpleado
        };

        public static Implementos GetImplemento(int id = 1, int idPortatil = 1, int idBodega = 1, int idTipo = 1) => new Implementos
        {
            Id_Implemento = id,
            Vida_Util = 36,
            Estado = "Activo",
            fecha_fabricacion = DateTime.Now.AddYears(-1),
            Marca = "MarcaTest",
            Costo = 500_000m,
            Portatil = idPortatil,
            Bodega = idBodega,
            Tipo_Implemento = idTipo,
            _Portatil = GetPortatil(idPortatil),
            _Bodega = GetBodega(idBodega)
        };

        public static Tipo_Aseo_Elementos GetTipo_Aseo_Elemento(int id = 1) => new Tipo_Aseo_Elementos
        {
            Id_Tipo_Aseo_Elemento = id,
            Uso = "Limpieza de pantalla",
            Instrucciones_Uso = "Aplicar con paño suave",
            Medida_litros = 0.5m,
            Toxicidad = "Baja"
        };

        public static Historial_Precios GetHistorial_Precio(int id = 1, int idTipo = 1) => new Historial_Precios
        {
            Id_Historial = id,
            Valor = 3_500_000m,
            Fecha_Inicio = DateTime.Now.AddMonths(-12),
            Fecha_Fin = DateTime.Now.AddMonths(-1),
            Motivo_Cambio = "Actualización de mercado",
            Tipo_Portatil = idTipo,
            _Tipo_Portatiles = GetTipo_Portatil(idTipo)
        };

        public static Tipos_Intermedia GetTipos_Intermedia(int id = 1, int idTipoImpl = 1, int idTipoPort = 1) => new Tipos_Intermedia
        {
            Id_Tipos_Intermedia = id,
            Posicion_Montaje = "Frontal",
            Tipo_Implemento = idTipoImpl,
            Tipo_Portatil = idTipoPort,
            _Tipo_Portatil = GetTipo_Portatil(idTipoPort),
            _Tipo_Implemento = GetTipo_Implemento(idTipoImpl)
        };

        // ─────────────────────────────────────────
        // II. ACTORES Y ACCESO
        // ─────────────────────────────────────────

        public static Usuarios GetUsuario(int id = 1) => new Usuarios
        {
            Id_Usuario = id,
            Username = $"usuario{id}",
            Password_Hash = "hash_de_prueba",
            Activo = true,
            Fecha_Ultimo_Acceso = DateTime.Now.AddDays(-1),
            Persona = id
        };

        public static Roles GetRol(int id = 1) => new Roles
        {
            Id_Rol = id,
            Nombre_Rol = "Supervisor",
            Descripcion_Rol = "Rol de prueba",
            Salario_Empleado = 3_000_000m
        };

        public static Empleados GetEmpleado(int id = 1, int idRol = 1) => new Empleados
        {
            Id_Persona = id,
            Cedula = $"100{id:D6}",
            Nombre = $"Empleado Prueba {id}",
            Correo = $"empleado{id}@bathimovil.com",
            Telefono = $"310{id:D7}",
            Fecha_Ingreso = DateTime.Now.AddYears(-1),
        };

        public static Clientes GetCliente(int id = 1) => new Clientes
        {
            Id_Persona = id,
            Cedula = $"900{id:D6}",
            Nombre = $"Cliente Prueba {id}",
            Correo = $"cliente{id}@empresa.com",
            Telefono = $"320{id:D7}",
            Razon_Social = $"Empresa de Prueba {id} S.A.S",
            Nit_CC = $"900{id:D6}-1",
            Direccion_Fiscal = $"Carrera {id} # 10-20",
        };

        // ─────────────────────────────────────────
        // III. COMERCIAL Y OPERATIVO
        // ─────────────────────────────────────────

        public static Contratos GetContrato(int id = 1, int idCliente = 1) => new Contratos
        {
            Id_Contrato = id,
            Fecha_Firma = DateTime.Now.AddMonths(-3),
            Terminos = "Términos estándar de prueba",
            Fecha_Expiracion = DateTime.Now.AddMonths(9),
            Cliente = idCliente,
        };

        public static Prestamos GetPrestamo(int id = 1, int idContrato = 1) => new Prestamos
        {
            Id_Prestamo = id,
            Fecha_Inicio = DateTime.Now.AddMonths(-1),
            Fecha_Fin_Prevista = DateTime.Now.AddMonths(2),
            Estado_Prestamo = true,
            Contrato = idContrato,
            _Contrato = GetContrato(idContrato)
        };

        public static Mantenimientos GetMantenimiento(int id = 1, int idPrestamo = 1, int idEmpleado = 1, int idPortatil = 1) => new Mantenimientos
        {
            Id_Mantenimiento = id,
            Fecha_Servicio = DateTime.Now.AddDays(-10),
            Tipo_Mantenimiento = "Preventivo",
            Descripcion_Trabajo = "Limpieza y revisión general",
            Costo_Mano_Obra = 150_000m,
            Prestamo = idPrestamo,
            Empleado = idEmpleado,
            Portatil = idPortatil,
            _Prestamo = GetPrestamo(idPrestamo),
            _Empleado = GetEmpleado(idEmpleado),
            _Portatil = GetPortatil(idPortatil)
        };

        public static Aseo_Elementos GetAseo_Elemento(int id = 1, int idTipo = 1, int idMantenimiento = 1) => new Aseo_Elementos
        {
            Id_Aseo_Elemento = id,
            Fecha_Vencimiento = DateTime.Now.AddMonths(6),
            Cantidad = 5,
            Marca = "CleanPro",
            Costo = 25_000m,
            Tipo_Aseo_Elementos = idTipo,
            Mantenimiento = idMantenimiento,
            _Tipo_Aseo_Elemento = GetTipo_Aseo_Elemento(idTipo),
            _Mantenimiento = GetMantenimiento(idMantenimiento)
        };

        // ─────────────────────────────────────────
        // IV. LOGÍSTICA
        // ─────────────────────────────────────────

        public static Envios GetEnvio(int id = 1, int idContrato = 1, int idEmpleado = 1) => new Envios
        {
            Id_Envio = id,
            Fecha_Salida = DateTime.Now.AddDays(-2),
            Destino = "Bogotá, Colombia",
            Costo_Envio = 80_000m,
            Fecha_Entrega_Estimada = DateTime.Now.AddDays(1),
            Contrato = idContrato,
            Empleado = idEmpleado,
            _Contrato = GetContrato(idContrato),
            _Empleado = GetEmpleado(idEmpleado)
        };

        // ─────────────────────────────────────────
        // V. FINANZAS
        // ─────────────────────────────────────────

        public static Facturas GetFactura(int id = 1, int idCliente = 1) => new Facturas
        {
            Id_Factura = id,
            Numero = $"FAC-{id:D5}",
            Fecha_Emision = DateTime.Now,
            Total = 5_000_000m,
            Impuesto_Iva = 950_000m,
            Cliente = idCliente,
            _Cliente = GetCliente(idCliente)
        };

        public static Detalle_Facturas GetDetalle_Factura(int id = 1, int idFactura = 1, int idPortatil = 1) => new Detalle_Facturas
        {
            Id_Detalle = id,
            Cantidad = 2,
            Costo_Unitario = 2_000_000m,
            Descuento_Aplicado = 100_000m,
            Subtotal = 3_900_000m,
            Factura = idFactura,
            _Factura = GetFactura(idFactura),
        };

        public static Pagos GetPago(int id = 1, int idFactura = 1) => new Pagos
        {
            Id_Pago = id,
            Total_Pagado = 5_000_000m,
            Fecha_Pago = DateTime.Now,
            Referencia_Bancaria = $"REF-{id:D8}",
            Metodo_Pago = "Transferencia",
            Factura = idFactura,
            _Factura = GetFactura(idFactura)
        };

        // ─────────────────────────────────────────
        // VI. ENTIDADES INTERMEDIAS
        // ─────────────────────────────────────────

        public static Prestamos_Portatiles GetPrestamo_Portatil(int id = 1, int idPrestamo = 1, int idPortatil = 1) => new Prestamos_Portatiles
        {
            Id_Prestamo_Portatil = id,
            Prestamo = idPrestamo,
            Portatil = idPortatil,
            _Prestamo = GetPrestamo(idPrestamo),
            _Portatil = GetPortatil(idPortatil)
        };

        // ─────────────────────────────────────────
        // LISTAS (para pruebas con colecciones)
        // ─────────────────────────────────────────

        public static List<Portatiles> GetPortatiles(int cantidad = 3)
        {
            var lista = new List<Portatiles>();
            for (int i = 1; i <= cantidad; i++)
                lista.Add(GetPortatil(i));
            return lista;
        }

        public static List<Clientes> GetClientes(int cantidad = 3)
        {
            var lista = new List<Clientes>();
            for (int i = 1; i <= cantidad; i++)
                lista.Add(GetCliente(i));
            return lista;
        }

        public static List<Empleados> GetEmpleados(int cantidad = 3)
        {
            var lista = new List<Empleados>();
            for (int i = 1; i <= cantidad; i++)
                lista.Add(GetEmpleado(i));
            return lista;
        }

        public static List<Facturas> GetFacturas(int cantidad = 3)
        {
            var lista = new List<Facturas>();
            for (int i = 1; i <= cantidad; i++)
                lista.Add(GetFactura(i));
            return lista;
        }

        public static List<Prestamos> GetPrestamos(int cantidad = 3)
        {
            var lista = new List<Prestamos>();
            for (int i = 1; i <= cantidad; i++)
                lista.Add(GetPrestamo(i));
            return lista;
        }

        public static List<Mantenimientos> GetMantenimientos(int cantidad = 3)
        {
            var lista = new List<Mantenimientos>();
            for (int i = 1; i <= cantidad; i++)
                lista.Add(GetMantenimiento(i));
            return lista;
        }
    }
}
