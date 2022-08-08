CREATE DATABASE System

--
DROP DATABASE System;

Use System


Create Table Choferes(
	Id int identity(1,1) Primary Key NOT NULL,
	IdBus int NOT NULL,
	IdRuta int NOT NULL,
	Nombre nvarchar(50) NOT NULL,
	Apellido nvarchar(70) NOT NULL,
	Fecha_nacimiento datetime NOT NULL,
	Cedula nvarchar(11) NOT NULL
);
--Insert Chofer--
INSERT INTO Choferes (IdBus, IdRuta, Nombre, Apellido, Fecha_nacimiento, Cedula)
values(1,1,'Juanito','Alcachofa','03-05-2000','001-5453210')

select*from Choferes;


----
Create Table Buses(
	Id int identity(1,1) Primary Key NOT NULL,
	Marca nvarchar(50) NOT NULL,
	Modelo nvarchar(10) NOT NULL,
	Placa varchar(8) NOT NULL,
	Color nvarchar(30) NOT NULL,
	Año nvarchar(4) NOT NULL
);
--Insert into Bus--
INSERT INTO Buses(Marca, Modelo, Placa, Color, Año)
values('Mercedes-Benz', '500 RS', 'A1A-602', 'Negro', '2009')

Select * From Buses;


----
Create table Rutas(
	Id int identity(1,1) Primary Key NOT NULL,
	Nombre_ruta nvarchar(50) NOT NULL
);
--Insert Ruta--
INSERT INTO Rutas(Nombre_ruta)
values('Villa Mella')

Select *  From Rutas;


--RELATIONS-- 
ALTER TABLE Choferes
ADD CONSTRAINT FK_ChoferBus
FOREIGN KEY (IdBus) REFERENCES Buses(Id);

ALTER TABLE Choferes
ADD CONSTRAINT FK_ChoferRuta
FOREIGN KEY (IdRuta) REFERENCES Rutas(Id);



--STORED PROCEDURE--
	--Choferes--
--To List--
CREATE PROCEDURE SP_Listar_Choferes
AS
BEGIN
Select * From Choferes
END;

--To Insert--
CREATE PROCEDURE SP_Crear_Chofer
@Idbus int, @idruta int, @nombre nvarchar(50), @apellido nvarchar(70), @fechaN datetime, @cedula nvarchar(11)
AS
BEGIN
INSERT INTO Choferes (IdBus, IdRuta, Nombre, Apellido, Fecha_nacimiento, Cedula)
VALUES (@idbus, @idruta, @nombre, @apellido, @fechaN, @cedula);
END;

--To Edit--
CREATE PROCEDURE SP_Edit_Chofer
@id int, @Idbus int, @idruta int, @nombre nvarchar(50), @apellido nvarchar(70), @fechaN datetime, @cedula nvarchar(11)
AS
BEGIN
UPDATE Choferes
SET IdBus =  @Idbus, IdRuta = @idruta, Nombre = @nombre, Apellido = @apellido, Fecha_nacimiento = @fechaN, Cedula = @cedula
WHERE Id = @id
END;

--To Delete--
CREATE PROCEDURE SP_Delete_Chofer
@id int
AS
BEGIN
DELETE FROM Choferes WHERE Id = @id
END;



--STORED PROCEDURE--
	--Buses--
--To List--
CREATE PROCEDURE SP_Listar_Buses
AS
BEGIN
Select * From Buses
END;

--To Insert--
CREATE PROCEDURE SP_Crear_Bus
@marca nvarchar(50), @modelo nvarchar(10), @placa nvarchar(8), @color nvarchar(30), @año nvarchar(4)
AS
BEGIN
INSERT INTO Buses (Marca, Modelo, Placa, Color, Año)
VALUES (@marca, @modelo, @placa, @color, @año);
END;


--To Edit--
CREATE PROCEDURE SP_Editar_Bus
@id int, @marca nvarchar(50), @modelo nvarchar(10), @placa nvarchar(8), @color nvarchar(30), @año nvarchar(4)
AS
BEGIN
UPDATE Buses
SET Marca = @marca, Modelo = @modelo, Placa = @placa, Color = @color, Año = @año
Where Id = @id
END;

--To Delete--
CREATE PROCEDURE SP_Eliminar_Bus
@id int
AS
BEGIN
DELETE FROM Buses WHERE Id = @id
END;




--STORED PROCEDURE--
	-- Rutas--
--To List--
CREATE PROCEDURE SP_Listar_Rutas
AS
BEGIN
Select * From Rutas
END;

--To Insert--
CREATE PROCEDURE SP_Crear_Ruta
@new_ruta nvarchar(50)
AS
BEGIN
INSERT INTO Rutas(Nombre_ruta)
VALUES (@new_ruta);
END;

--To Edit--
CREATE PROCEDURE SP_Editar_Rutas
@id int, @new_ruta nvarchar(50)
AS
BEGIN
UPDATE Rutas
SET Nombre_ruta = @new_ruta
Where Id = @id
END;

--To Delete--
CREATE PROCEDURE SP_Eliminar_Ruta
@id int
AS
BEGIN
DELETE FROM Rutas WHERE Id = @id
END;


					--LOAD COMBOBOX WITH BUS--

CREATE PROCEDURE SP_Cargar_ComboBus
AS
BEGIN
SELECT Id, Placa From Buses
END;

						
					--LOAD COMBOBOX WITH BUS--

CREATE PROCEDURE SP_Cargar_ComboRuta
AS
BEGIN
SELECT Id, Nombre_ruta FROM Rutas
END;



--Search--
CREATE PROCEDURE SP_Buscar
@bus int, @ruta int
AS
BEGIN
SELECT * FROM Choferes
WHERE IdBus = @bus and IdRuta = @ruta 
END;

exec SP_Buscar 1,1;



CREATE PROCEDURE SP_Buscar_Bus
@bus int
AS
BEGIN
SELECT * FROM Choferes
WHERE IdBus = @bus
END;


CREATE PROCEDURE SP_Buscar_Ruta
@ruta int
AS
BEGIN
SELECT * FROM Choferes
WHERE IdRuta = @ruta
END;

DROP PROCEDURE SP_Buscar;

-----LISTAR PRODUCTOS
--create proc ListarProductos
--as
--select IDPROD AS ID, CATEGORIAS.CATEGORIA,MARCAS.MARCA,DESCRIPCION,PRECIO
-- from PRODUCTOS 
--INNER JOIN CATEGORIAS ON PRODUCTOS.IDCATEGORIA=CATEGORIAS.IDCATEG
--INNER JOIN MARCAS ON PRODUCTOS.IDMARCA=MARCAS.IDMARCA


CREATE PROCEDURE SP_Listar_Asignacion
AS
BEGIN
SELECT IdBus AS IDB, IdRuta AS IDR, Buses.Placa, Rutas.Nombre_ruta, Nombre, Apellido, Fecha_nacimiento, Cedula
	from Choferes
INNER JOIN Buses on Choferes.IdBus = Buses.Id
INNER JOIN Rutas on Choferes.IdRuta = Rutas.Id
END;