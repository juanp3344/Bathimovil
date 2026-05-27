CREATE DATABASE uPortatiles_db
GO
USE uPortatiles_db
GO



CREATE TABLE [Tipos_Portatiles]
(-- LISTA PORTATILES, HISTORIAL_PRECIOS, TIPOS_PRECIOS
[Id_Tipo_Portatil] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre] NVARCHAR(50) NOT NULL,
[Descripcion] NVARCHAR(50) NOT NULL,
[Precio_Actual] DECIMAL (10,2) NOT NULL,
[ImagenUrl] NVARCHAR(200) NOT NULL,
[Altura] DECIMAL (10,2) NOT NULL,
[Ancho] DECIMAL (10,2) NOT NULL,
[Largo] DECIMAL (10,2) NOT NULL
);

CREATE TABLE [Sedes]
(-- lista portatiles, bodega
[Id_Sede] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre] NVARCHAR(50) NOT NULL,
[Direccion] NVARCHAR(50) NOT NULL,
[Ciudad] NVARCHAR(50) NOT NULL,
[Telefono_Contacto] NVARCHAR(50) NOT NULL
);




CREATE TABLE [Tipo_Aseo_Elementos]
(-- LISTA ASEO_ELEMENTOS
[Id_Tipo_Aseo_Elemento] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Uso] NVARCHAR(50) NOT NULL,
[Instrucciones_Uso] NVARCHAR(50) NOT NULL,
[Medida_Litros] DECIMAL (10,2) NOT NULL,
[Toxicidad] NVARCHAR(50) NOT NULL
);



CREATE TABLE [Tipos_Implementos]
(-- LISTA Implementos, Tipos_Intermedia
[Id_Tipo_Implemento] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre] NVARCHAR(50) NOT NULL,
[Descripcion] NVARCHAR(50) NOT NULL,
[Altura] DECIMAL (10,2) NOT NULL,
[Ancho] DECIMAL (10,2) NOT NULL,
[Largo] DECIMAL (10,2) NOT NULL
);



CREATE TABLE [Personas]
(-- LISTA CONTRATOS Y FACTURAS
[Id_Persona] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Cedula] NVARCHAR(50)  NULL,
[Nombre] NVARCHAR(50)  NULL,
[Correo] NVARCHAR(50)  NULL,
[Telefono] NVARCHAR(50)  NULL
);


CREATE TABLE [Roles]
(
[Id_Rol] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre_Rol] NVARCHAR(50) NOT NULL ,
[Descripcion_Rol] NVARCHAR(100) NOT NULL,
[Salario_Empleado] DECIMAL(10,2) NULL
);


CREATE TABLE [Usuarios]
(
[Id_Usuario] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Username] NVARCHAR(50) NOT NULL UNIQUE,
[Password_Hash] NVARCHAR(50) NOT NULL,
[Activo] BIT NOT NULL,
[Fecha_Ultimo_Acceso] SMALLDATETIME NOT NULL,


[Rol] INT NOT NULL REFERENCES [Roles]([Id_Rol]),
[Persona] INT NOT NULL REFERENCES [Personas]([Id_Persona])
);




CREATE TABLE [Clientes]
(-- LISTA CONTRATOS Y FACTURAS
[Id_Persona] int NOT NULL PRIMARY KEY,
[Razon_Social] NVARCHAR(50)  NULL,
[Nit_CC] NVARCHAR(50)  NULL,
[Direccion_Fiscal] NVARCHAR(50)  NULL
CONSTRAINT FK_Clientes_Personas
    FOREIGN KEY ([Id_Persona])
    REFERENCES Personas([Id_Persona])
);



CREATE TABLE [Empleados]
(-- LISTA MANTENIMIENTO, ENVIOS
[Id_Persona] int NOT NULL PRIMARY KEY,
[Fecha_Ingreso] SMALLDATETIME NOT NULL,
[Salario_Base] DECIMAL (10,2) NULL,
CONSTRAINT FK_Empleados_Personas
    FOREIGN KEY ([Id_Persona])
    REFERENCES Personas([Id_Persona])
);



CREATE TABLE [Bodegas]
(-- LISTA E IMPLEMENTOS
[Id_Bodega] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre] NVARCHAR(50) NOT NULL,
[Ubicacion] NVARCHAR(50) NOT NULL,
[Capacidad_Maxima] INT NOT NULL,


[Sede] INT NOT NULL REFERENCES [Sedes]([Id_Sede]),
[Empleado] INT NOT NULL REFERENCES [Empleados]([Id_Persona])
);


CREATE TABLE [Contratos](

[Id_Contrato] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Fecha_Firma] SMALLDATETIME NOT NULL,
[Terminos] NVARCHAR(50) NOT NULL,
[Fecha_Expiracion] SMALLDATETIME NOT NULL,


[Cliente] INT NOT NULL REFERENCES [Clientes]([Id_Persona])
);




CREATE TABLE [Prestamos]
(-- LISTAS PRESTAMOS_PORTATILES, MANTENIMIENTO
[Id_Prestamo] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Fecha_Inicio] SMALLDATETIME NOT NULL,
[Fecha_Fin_Prevista] SMALLDATETIME NOT NULL,
[Estado_Prestamo] BIT NOT NULL,
[Contrato] INT NOT NULL REFERENCES [Contratos]([Id_Contrato])
);




CREATE TABLE [Compras]
(
[Id_Compra] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Fecha_Compra] SMALLDATETIME NOT NULL,
[Monto_Total] DECIMAL (10,2) NOT NULL,
[Metodo_Pago] NVARCHAR(50) NOT NULL,
[Garantia_Meses] INT NOT NULL,

[Contrato] INT NOT NULL REFERENCES [Contratos]([Id_Contrato]),
);






CREATE TABLE [Portatiles]
(
[Id_Portatil] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Numero_Serial] NVARCHAR(50) NOT NULL UNIQUE,
[Fecha_Fabricacion] SMALLDATETIME NOT NULL,
[Estado_Actual] NVARCHAR(50) NOT NULL,

[Tipo_Portatil] INT NOT NULL REFERENCES [Tipos_Portatiles]([Id_Tipo_Portatil]),
[Sede] INT NOT NULL REFERENCES [Sedes]([Id_Sede]),
[Compra] INT NULL REFERENCES [Compras]([Id_Compra])
);



CREATE TABLE [Implementos]
(
[Id_Implemento] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Vida_Util] int NOT NULL,
[Estado] NVARCHAR(50) NOT NULL,
[fecha_fabricacion] SMALLDATETIME NOT NULL,
[Marca] NVARCHAR(50) NOT NULL,
[Costo] DECIMAL (10,2) NOT NULL,

[Portatil] INT NOT NULL REFERENCES [Portatiles]([Id_Portatil]),
[Tipo_Implemento] INT NOT NULL REFERENCES [Tipos_Implementos]([Id_Tipo_Implemento]),
[Bodega] INT NOT NULL REFERENCES [Bodegas]([Id_Bodega])
);



CREATE TABLE [Mantenimientos]
(-- lista aseo_elementos
[Id_Mantenimiento] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Fecha_Servicio] SMALLDATETIME NOT NULL,
[Tipo_Mantenimiento] NVARCHAR(50) NOT NULL,
[Descripcion_Trabajo] NVARCHAR(50) NOT NULL,
[Costo_Mano_Obra] DECIMAL (10,2) NOT NULL,

[Prestamo] INT NOT NULL REFERENCES [Prestamos]([Id_Prestamo]),
[Empleado] INT NOT NULL REFERENCES [Empleados]([Id_Persona]),
[Portatil] INT NOT NULL REFERENCES [Portatiles]([Id_Portatil])
);




CREATE TABLE [Aseo_Elementos]
(-- Objeto Mantenimiento
[Id_Aseo_Elemento] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Fecha_Vencimiento] SMALLDATETIME NOT NULL,
[Cantidad] int NOT NULL,
[Marca] NVARCHAR(50) NOT NULL,
[Costo] DECIMAL (10,2) NOT NULL,

[Tipo_Aseo_Elemento] INT NOT NULL REFERENCES [Tipo_Aseo_Elementos]([Id_Tipo_Aseo_Elemento]),
[Mantenimiento] INT NOT NULL REFERENCES [Mantenimientos]([Id_Mantenimiento])

);




CREATE TABLE [Historial_Precios]
(
[Id_Historial] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Valor] DECIMAL (10,2) NOT NULL,
[Fecha_Inicio] SMALLDATETIME NOT NULL,
[Fecha_Fin] SMALLDATETIME NOT NULL,
[Motivo_Cambio] NVARCHAR(50) NOT NULL,

[Tipo_Portatil] INT NOT NULL REFERENCES [Tipos_Portatiles]([Id_Tipo_Portatil])
);



CREATE TABLE [Envios]
(
[Id_Envio] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Fecha_Salida] SMALLDATETIME NOT NULL,
[Destino] NVARCHAR(50) NOT NULL,
[Costo_Envio] DECIMAL (10,2) NOT NULL,
[Fecha_Entrega_Estimada] SMALLDATETIME NOT NULL,

[Empleado] INT NOT NULL REFERENCES [Empleados]([Id_Persona]),
[Contrato] INT NOT NULL REFERENCES [Contratos]([Id_Contrato])
);




CREATE TABLE [Facturas]
(-- Lista detalle_Factura, Pagos
[Id_Factura] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Numero] NVARCHAR(50) NOT NULL UNIQUE,
[Fecha_Emision] SMALLDATETIME NOT NULL,
[Total] DECIMAL (10,2) NOT NULL,
[Impuesto_Iva] DECIMAL (10,2) NOT NULL,

[Cliente] INT NOT NULL REFERENCES [Clientes]([Id_Persona])
);





CREATE TABLE [Detalle_Facturas]
(-- Lista detalle_Factura, Pagos 
[Id_Detalle] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Cantidad] INT NOT NULL,
[Costo_Unitario] DECIMAL (10,2) NOT NULL,
[Descuento_Aplicado] DECIMAL (10,2) NOT NULL,
[Subtotal] DECIMAL (10,2) NOT NULL,

[Factura] INT NOT NULL REFERENCES [Facturas]([Id_Factura])
);





CREATE TABLE [Pagos]
(
[Id_Pago] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Total_Pagado]  DECIMAL (10,2) NOT NULL,
[Fecha_Pago] SMALLDATETIME NOT NULL,
[Referencia_Bancaria] NVARCHAR(50) NOT NULL,
[Metodo_Pago] NVARCHAR(50) NOT NULL,

[Factura] INT NOT NULL REFERENCES [Facturas]([Id_Factura])
);





CREATE TABLE [Prestamos_Portatiles]
(
[Id_Prestamo_Portatil] int NOT NULL IDENTITY (1,1) PRIMARY KEY,

[Prestamo] INT NOT NULL REFERENCES [Prestamos]([Id_Prestamo]),
[Portatil] INT NOT NULL REFERENCES [Portatiles]([Id_Portatil])
);


CREATE TABLE [Tipos_Intermedia]
(
[Id_Tipos_Intermedia] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Posicion_Montaje] NVARCHAR(50) NOT NULL,

[Tipo_Implemento] INT NOT NULL REFERENCES [Tipos_Implementos]([Id_Tipo_Implemento]),
[Tipo_Portatil] INT NOT NULL REFERENCES [Tipos_Portatiles]([Id_Tipo_Portatil])
);

CREATE TABLE [Auditorias]
(
[Id_Auditoria] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Fecha] SMALLDATETIME NOT NULL,
[Descripcion] NVARCHAR(50) NOT NULL,
[Nombre_Ejecutor] NVARCHAR(50) NOT NULL
);

CREATE TABLE [Permisos]
(
[Id_Permiso] int NOT NULL IDENTITY (1,1) PRIMARY KEY,
[Nombre_Permiso] NVARCHAR(50) NOT NULL,

[Rol] INT NOT NULL REFERENCES [Roles]([Id_Rol])
);
CREATE TABLE [Ubicaciones] (
    [Id_Ubicacion]      INT IDENTITY(1,1) PRIMARY KEY,
    [Ciudad]            NVARCHAR(100),
    [Direccion]         NVARCHAR(200),
    [Portatil]          INT NOT NULL,
    FOREIGN KEY (Portatil) REFERENCES Portatiles(Id_Portatil)
);

INSERT INTO [Tipos_Portatiles]([Nombre],[Descripcion],[Precio_Actual],[ImagenUrl],[Altura],[Ancho],[Largo])VALUES('Portatil_Personal','Para clientes casuales',60000,'/global-azul.jpg', 12,10,4);
INSERT INTO [Tipos_Portatiles]([Nombre],[Descripcion],[Precio_Actual],[ImagenUrl],[Altura],[Ancho],[Largo])VALUES('Portatil_Empresarial','Para clientes Empresariales',120000,'/BPortatilP.jfif', 12,10,4);
INSERT INTO Sedes ([Nombre],[Direccion],[Ciudad],[Telefono_Contacto]) VALUES ('BathiMovil','Medellin','Medellin','834278497AC');

INSERT INTO [Portatiles]([Numero_Serial], [Fecha_Fabricacion], [Estado_Actual], [Tipo_Portatil], [Sede]) VALUES ('643278Y78E78327',GETDATE(),'Libre',2,1 )
INSERT INTO [Portatiles]([Numero_Serial], [Fecha_Fabricacion], [Estado_Actual], [Tipo_Portatil], [Sede]) VALUES ('3472478372848SF',GETDATE(),'Libre',2,1 )
INSERT INTO [Portatiles]([Numero_Serial], [Fecha_Fabricacion], [Estado_Actual], [Tipo_Portatil], [Sede]) VALUES ('54754897493AHDS',GETDATE(),'Libre',2,1 )
INSERT INTO [Portatiles]([Numero_Serial], [Fecha_Fabricacion], [Estado_Actual], [Tipo_Portatil], [Sede]) VALUES ('837482743274738',GETDATE(),'Libre',1,1 )


INSERT INTO [Roles] 
([Nombre_Rol], [Descripcion_Rol],[Salario_Empleado]) VALUES ('Administrador', 'Acceso completo del sistema', 40000000)

INSERT INTO [Roles] 
([Nombre_Rol], [Descripcion_Rol],[Salario_Empleado]) VALUES ('Mantenimiento', 'Acceso parcial del sistema', 20000000)

INSERT INTO [Roles] 
([Nombre_Rol], [Descripcion_Rol]) VALUES ('Cliente', 'Poco alcance  del sistema')



INSERT INTO [Personas]([Cedula], [Nombre], [Correo],[Telefono] ) VALUES ('3482748937', 'Juan Flores', 'J@gmail.com', '213787821')


INSERT INTO  [Empleados]([Id_Persona], [Fecha_Ingreso] ,[Salario_Base]) VALUES (1, GETDATE(), 4000000)


INSERT INTO [Usuarios]([Username],[Password_Hash],[Activo],[Fecha_Ultimo_Acceso],[Rol],[Persona]) VALUES ('Jairo','1234', 1, GETDATE(),1,1)
