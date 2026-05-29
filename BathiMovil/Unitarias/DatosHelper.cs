using BibliotecaServicios.Entidades;
using BibliotecaServicios.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Unitarias
{
    public static class DatosHelper
    {
        // ─────────────────────────────────────────
        // Sin FK — se pueden crear solos
        // ─────────────────────────────────────────

        public static Auditorias CrearAuditoria(IConexion conexion)
        {
            var e = new Auditorias()
            {
<<<<<<< HEAD
                HoraAccion = DateTime.Now.ToString("HH:mm:ss"),
                Nivel_Cambio = "bajo",
                Operacion = "reviso una entidad",
                Nombre = "tester"
            };
=======

                HoraAccion = "12:00",
                Nivel_Cambio = "2",
                Nombre = "Auditor",
                Operacion = "1"
    };
>>>>>>> d48d689a7c11055b80cf8ff769397ff8c99b15b1
            conexion.Auditorias!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Roles CrearRol(IConexion conexion)
        {
            var e = new Roles()
            {
                Nombre_Rol = "Supervisor",
                Descripcion_Rol = "Rol de prueba",
                Salario_Empleado = 3_000_000m
            };
            conexion.Roles!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Clientes CrearCliente(IConexion conexion)
        {
            var e = new Clientes()
            {
                Cedula = $"900{DateTime.Now.Ticks}",
                Nombre = "Cliente Test",
                Correo = "cliente@test.com",
                Telefono = "3201234567",
                Razon_Social = "Empresa Test S.A.S",
                Nit_CC = $"NIT{DateTime.Now.Ticks}",
                Direccion_Fiscal = "Carrera 1 # 10-20"
            };
            conexion.Clientes!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Empleados CrearEmpleado(IConexion conexion)
        {
            var e = new Empleados()
            {
                Cedula = $"100{DateTime.Now.Ticks}",
                Nombre = "Empleado Test",
                Correo = "empleado@test.com",
                Telefono = "3101234567",
                Fecha_Ingreso = DateTime.Now.AddYears(-1),
                Salario_Base = 3_000_000m
            };
            conexion.Empleados!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Sedes CrearSede(IConexion conexion)
        {
            var e = new Sedes()
            {
                Nombre = "Sede Test",
                Direccion = "Calle 10 # 20-30",
                Ciudad = "Medellín",
                Telefono_Contacto = "6041234567"
            };
            conexion.Sedes!.Add(e);
            conexion.SaveChanges();
            return e;
        }
        public static Personas CrearPersona(IConexion conexion)
        {
            var e = new Personas()
            {
                Cedula = $"PER{DateTime.Now.Ticks}",
                Nombre = "Persona Test",
                Correo = "persona@test.com",
                Telefono = "3001234567"
            };
            conexion.Personas!.Add(e);
            conexion.SaveChanges();
            return e;
        }
        public static Tipos_Portatiles CrearTipo_Portatil(IConexion conexion)
        {
            var e = new Tipos_Portatiles()
            {
                Nombre = "Tipo Portátil Test",
                Descripcion = "Portátil estándar de prueba",
                Precio_Actual = 1212312,
                ImagenUrl= "Imagen",
                Altura = 25,
                Ancho = 35,
                Largo = 5
            };
            conexion.Tipos_Portatiles!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Tipos_Implementos CrearTipo_Implemento(IConexion conexion)
        {
            var e = new Tipos_Implementos()
            {
                Nombre = "Tipo Implemento Test",
                Descripcion = "Implemento de prueba",
                Ancho = 10m,
                Largo = 20m,
                Altura = 5m
            };
            conexion.Tipos_Implementos!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Tipo_Aseo_Elementos CrearTipo_Aseo_Elemento(IConexion conexion)
        {
            var e = new Tipo_Aseo_Elementos()
            {
                Uso = "Limpieza de pantalla",
                Instrucciones_Uso = "Aplicar con paño suave",
                Medida_Litros = 0.5m,
                Toxicidad = "Baja"
            };
            conexion.Tipo_Aseo_Elementos!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        // ─────────────────────────────────────────
        // Con FK — reciben el ID del padre
        // ─────────────────────────────────────────

        public static Permisos CrearPermiso(IConexion conexion, int idRol)
        {
            var e = new Permisos()
            {
                Nombre_Permiso = "Permiso Test",
                Rol = idRol
            };
            conexion.Permisos!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Usuarios CrearUsuario(IConexion conexion, int idPersona, int idRol)
        {
            var e = new Usuarios()
            {
                Username = $"user{DateTime.Now.Ticks}",
                Password_Hash = "hash_de_prueba",
                Activo = true,
                Fecha_Ultimo_Acceso = DateTime.Now.AddDays(-1),
                Persona = idPersona,
                Rol = idRol
            };
            conexion.Usuarios!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Contratos CrearContrato(IConexion conexion, int idCliente)
        {
            var e = new Contratos()
            {
                Fecha_Firma = DateTime.Now.AddMonths(-3),
                Terminos = "Términos de prueba",
                Fecha_Expiracion = DateTime.Now.AddMonths(9),
                Cliente = idCliente
            };
            conexion.Contratos!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Compras CrearCompra(IConexion conexion, int idContrato)
        {
            var e = new Compras()
            {
                Fecha_Compra = DateTime.Now.AddMonths(-6),
                Monto_Total = 15_000_000m,
                Metodo_Pago = "Transferencia",
                Garantia_Meses = 12,
                Contrato = idContrato
            };
            conexion.Compras!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Bodegas CrearBodega(IConexion conexion, int idSede, int idEmpleado)
        {
            var e = new Bodegas()
            {
                Nombre = "Bodega Test",
                Ubicacion = "Bloque A",
                Capacidad_Maxima = 100,
                Sede = idSede,
                Empleado = idEmpleado
            };
            conexion.Bodegas!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Portatiles CrearPortatil(IConexion conexion, int idTipo, int idSede, int idCompra)
        {
            var e = new Portatiles()
            {
                Numero_Serial = $"SN-{DateTime.Now.Ticks}",
                Fecha_Fabricacion = DateTime.Now.AddYears(-2),
                Estado_Actual = "Disponible",
                Tipo_Portatil = idTipo,
                Sede = idSede,
                Compra = idCompra
            };
            conexion.Portatiles!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Implementos CrearImplemento(IConexion conexion, int idPortatil, int idBodega, int idTipo)
        {
            var e = new Implementos()
            {
                Vida_Util = 36,
                Estado = "Activo",
                fecha_fabricacion = DateTime.Now.AddYears(-1),
                Marca = "MarcaTest",
                Costo = 500_000m,
                Portatil = idPortatil,
                Bodega = idBodega,
                Tipo_Implemento = idTipo
            };
            conexion.Implementos!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Historial_Precios CrearHistorial_Precio(IConexion conexion, int idTipo)
        {
            var e = new Historial_Precios()
            {
                Valor = 3_500_000m,
                Fecha_Inicio = DateTime.Now.AddMonths(-12),
                Fecha_Fin = DateTime.Now.AddMonths(-1),
                Motivo_Cambio = "Actualización de mercado",
                Tipo_Portatil = idTipo
            };
            conexion.Historial_Precios!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Tipos_Intermedia CrearTipos_Intermedia(IConexion conexion, int idTipoImplemento, int idTipoPortatil)
        {
            var e = new Tipos_Intermedia()
            {
                Posicion_Montaje = "Frontal",
                Tipo_Implemento = idTipoImplemento,
                Tipo_Portatil = idTipoPortatil
            };
            conexion.Tipos_Intermedia!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Prestamos CrearPrestamo(IConexion conexion, int idContrato)
        {
            var e = new Prestamos()
            {
                Fecha_Inicio = DateTime.Now.AddMonths(-1),
                Fecha_Fin_Prevista = DateTime.Now.AddMonths(2),
                Estado_Prestamo = true,
                Contrato = idContrato
            };
            conexion.Prestamos!.Add(e);
            conexion.SaveChanges();
            return e;
        }


        public static Mantenimientos CrearMantenimiento(IConexion conexion, int idPrestamo, int idEmpleado, int idPortatil)
        {
            var e = new Mantenimientos()
            {
                Fecha_Servicio = DateTime.Now.AddDays(-10),
                Tipo_Mantenimiento = "Preventivo",
                Descripcion_Trabajo = "Limpieza y revisión general",
                Costo_Mano_Obra = 150_000m,
                Prestamo = idPrestamo,
                Empleado = idEmpleado,
                Portatil = idPortatil
            };
            conexion.Mantenimientos!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Aseo_Elementos CrearAseo_Elemento(IConexion conexion, int idTipo, int idMantenimiento)
        {
            var e = new Aseo_Elementos()
            {
                Fecha_Vencimiento = DateTime.Now.AddMonths(6),
                Cantidad = 5,
                Marca = "CleanPro",
                Costo = 25_000m,
                Tipo_Aseo_Elemento = idTipo,
                Mantenimiento = idMantenimiento
            };
            conexion.Aseo_Elementos!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Envios CrearEnvio(IConexion conexion, int idContrato, int idEmpleado)
        {
            var e = new Envios()
            {
                Fecha_Salida = DateTime.Now.AddDays(-2),
                Destino = "Bogotá, Colombia",
                Costo_Envio = 80_000m,
                Fecha_Entrega_Estimada = DateTime.Now.AddDays(1),
                Contrato = idContrato,
                Empleado = idEmpleado
            };
            conexion.Envios!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Facturas CrearFactura(IConexion conexion, int idCliente)
        {
            var e = new Facturas()
            {
                Numero = $"FAC-{DateTime.Now.Ticks}",
                Fecha_Emision = DateTime.Now,
                Total = 5_000_000m,
                Impuesto_Iva = 950_000m,
                Cliente = idCliente
            };
            conexion.Facturas!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Detalle_Facturas CrearDetalle_Factura(IConexion conexion, int idFactura)
        {
            var e = new Detalle_Facturas()
            {
                Cantidad = 2,
                Costo_Unitario = 2_000_000m,
                Descuento_Aplicado = 100_000m,
                Subtotal = 3_900_000m,
                Factura = idFactura
            };
            conexion.Detalle_Facturas!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Pagos CrearPago(IConexion conexion, int idFactura)
        {
            var e = new Pagos()
            {
                Total_Pagado = 5_000_000m,
                Fecha_Pago = DateTime.Now,
                Referencia_Bancaria = $"REF-{DateTime.Now.Ticks}",
                Metodo_Pago = "Transferencia",
                Factura = idFactura
            };
            conexion.Pagos!.Add(e);
            conexion.SaveChanges();
            return e;
        }

        public static Ubicaciones CrearUbicacion(IConexion conexion, int idPortatil)
        {
            var e = new Ubicaciones()
            {
                Ciudad = "Medellín",
                Direccion = $"Calle {DateTime.Now.Second} # {DateTime.Now.Millisecond}-10",
                Portatil = idPortatil
            };
            conexion.Ubicaciones!.Add(e);
            conexion.SaveChanges();
            return e;
        }
    }

}