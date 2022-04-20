use master;
GO

if exists (SELECT * FROM SysDataBases WHERE name='ProyectoFinal')
BEGIN
	DROP DATABASE ProyectoFinal
END
GO

CREATE DATABASE ProyectoFinal
GO

USE ProyectoFinal
GO

CREATE TABLE Usuario	
(
	NombreUsu varchar(30) NOT NULL PRIMARY KEY, 
	Nombre varchar (20) NOT NULL,
	Contrasenia varchar (20) NOT NULL
)
GO

CREATE TABLE Pais
(
	CodP varchar (3) NOT NULL PRIMARY KEY,
	NombreP varchar (25) NOT NULL
)
GO

CREATE TABLE Ciudad 
(
	CodC varchar (3) NOT NULL,
	CodP varchar (3) NOT NULL Foreign Key References Pais(CodP),
	NombreC varchar (25) NOT NULL,
	Primary Key(CodC, CodP)
)
GO

CREATE TABLE Pronostico
(
	CodIntP int IDENTITY (1, 1) PRIMARY KEY,
	FechaHora DateTime NOT NULL,
	Velocidad int NOT NULL,
	ProbL  int NOT NULL,
	ProbT  int NOT NULL,
	TipoCielo varchar (20) NOT NULL,
	Tmax int NOT NULL,
	Tmin int NOT NULL,
	CodC varchar (3) NOT NULL,
	CodP varchar (3) NOT NULL,
	NombreUsu varchar(30) NOT NULL FOREIGN KEY REFERENCES Usuario (NombreUsu),
	Foreign Key (CodC, CodP) References Ciudad(CodC, CodP)
)
GO

insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Jorge123', 'Jorge', 'Jorge1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Adelina123', 'Adelina', 'Adelina1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Vanesa123', 'Vanesa', 'Vanesa1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Lorena123', 'Lorena', 'Lorena1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Carla123', 'Carla', 'Carla1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Diego123', 'Diego', 'Diego1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Karina123', 'Karina', 'Karina1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Karen123', 'Karen', 'Karen1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Eduardo123', 'Eduardo', 'Eduardo1234')
insert Usuario (NombreUsu, Nombre, Contrasenia) Values ('Agustina123', 'Agustina', 'Agustina1234')
GO

insert Pais (CodP, Nombrep) Values ('AAA', 'Uruguay')
insert Pais (CodP, Nombrep) Values ('BBB', 'Argentina')
insert Pais (CodP, Nombrep) Values ('CCC', 'Alemania')
insert Pais (CodP, Nombrep) Values ('DDD', 'Brasil')
insert Pais (CodP, Nombrep) Values ('EEE', 'Inglaterra')
insert Pais (CodP, Nombrep) Values ('FFF', 'Panama')
insert Pais (CodP, Nombrep) Values ('GGG', 'Colombia')
insert Pais (CodP, Nombrep) Values ('HHH', 'Chile')
insert Pais (CodP, Nombrep) Values ('III', 'Paraguay')
insert Pais (CodP, Nombrep) Values ('JJJ', 'Venezuela')
insert Pais (CodP, Nombrep) Values ('VVV', 'Canadá')
GO

insert Ciudad(CodC, NombreC, CodP) Values ('KKK', 'Montevideo', 'AAA')
insert Ciudad(CodC, NombreC, CodP) Values ('LLL', 'Cordoba', 'BBB')
insert Ciudad(CodC, NombreC, CodP) Values ('MMM', 'Berlin', 'CCC')
insert Ciudad(CodC, NombreC, CodP) Values ('NNN', 'Brasilia', 'DDD')
insert Ciudad(CodC, NombreC, CodP) Values ('OOO', 'Londres', 'EEE')
insert Ciudad(CodC, NombreC, CodP) Values ('PPP', 'Panama', 'FFF')
insert Ciudad(CodC, NombreC, CodP) Values ('QQQ', 'Bogota', 'GGG')
insert Ciudad(CodC, NombreC, CodP) Values ('RRR', 'Santiago', 'HHH')
insert Ciudad(CodC, NombreC, CodP) Values ('SSS', 'Asuncion', 'III')
insert Ciudad(CodC, NombreC, CodP) Values ('TTT', 'Caracas', 'JJJ')
insert Ciudad(CodC, NombreC, CodP) Values ('UUU', 'Ottawa', 'VVV')
GO

insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220312', 110, 60, 10, 'Parcialmente Nuboso', 20, 10, 'KKK', 'AAA', 'Jorge123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220314', 90, 10, 30, 'Nuboso', 20, 10, 'LLL', 'BBB', 'Adelina123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220208', 80, 40, 25, 'Despejado', 20, 10, 'MMM', 'CCC', 'Vanesa123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220204', 125, 30, 40, 'Parcialmente Nuboso', 20, 10, 'NNN', 'DDD', 'Lorena123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220207', 120, 50, 20, 'Nuboso', 20, 10, 'OOO', 'EEE', 'Carla123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220206', 20, 60, 55, 'Despejado,', 20, 10, 'PPP', 'FFF', 'Diego123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220315', 10, 60, 80, 'Nuboso', 20, 10, 'QQQ', 'GGG', 'Karina123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220316', 40, 10, 50, 'Nuboso', 20, 10, 'RRR', 'HHH', 'Karen123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220317', 60, 20, 30, 'Despejado', 20, 10, 'SSS', 'III', 'Eduardo123')
insert Pronostico (FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, CodC, CodP, NombreUsu) values ('20220203', 130, 40, 40, 'Nuboso', 20, 10, 'TTT', 'JJJ', 'Agustina123')
GO
------------------------------------------------------------------------------------------------------------------------------------
-------------------------LOGUEO-------------------------
CREATE PROCEDURE Logueo @NombreUsu varchar(30), @Contrasenia varchar(10) AS
Begin
	Select *
	From Usuario U
	Where U.NombreUsu = @NombreUsu AND U.Contrasenia = @Contrasenia 
End
go


-------------------------ABM DE PAISES-------------------------


--Alta Pais
CREATE PROCEDURE AltaPais 
@CodP varchar(3), 
@NombreP varchar(25)

AS
BEGIN

	IF exists(select * from Pais where CodP = @CodP)
		return -1

	INSERT Pais values(@CodP, @NombreP)
	return 1
	
END
GO

-- Modificar Pais
CREATE PROCEDURE ModPais
@CodP varchar(3), 
@NombreP varchar(25)
AS
BEGIN
	
	IF NOT (exists (SELECT CodP FROM Pais WHERE CodP = @CodP) )
	RETURN -1 
	
	UPDATE Pais SET NombreP = @NombreP WHERE CodP = @CodP
	IF (@@ERROR = 0) 
			RETURN 1	
	ELSE
		RETURN 0 
END
GO

--Eliminar Pais
CREATE PROCEDURE BajaPais 
@CodP varchar(3)

AS
BEGIN
	IF NOT (exists (SELECT CodP FROM Pais WHERE CodP = @CodP) )
		return -1 
	
	IF exists(select CodP from Pronostico where CodP = @CodP)
		return -2 	
	
	BEGIN TRAN
	delete from Ciudad where CodP = @CodP
	if (@@ERROR != 0)
	begin
		Rollback Tran 
		return -3
	end
	

	delete from Pais where CodP = @CodP
	if (@@ERROR != 0)
	begin
		Rollback Tran 
		return -4
	end
	
	
	Commit Tran
	return 1
END
GO
CREATE PROCEDURE BuscarPais @CodP varchar(3) AS
Begin
	Select * From Pais Where CodP = @CodP
End
go


CREATE PROCEDURE ListarPais AS
Begin
	Select * From Pais
End
go
-------------------------ABM DE CIUDADES-------------------------

--Alta de Ciudad
CREATE PROCEDURE AltaCiudad 
@CodC  varchar(3), 
@CodP  varchar(3), 
@NombreC varchar (25) 

AS
BEGIN 
	IF exists(select * from Ciudad where CodC = @CodC AND CodP = @CodP)
		return -1 
	IF NOT exists(select * from Pais where CodP = @CodP)
		return -2
	
	INSERT Ciudad values(@CodC, @CodP, @NombreC)
	return 1
	
END
GO


Create Procedure BajaCiudad
@CodC  varchar(3),
@CodP  varchar(3)
AS
Begin
	
	IF NOT exists(select CodC, CodP from Ciudad where CodC = @CodC AND CodP = @CodP)
		return -1
			
	BEGIN TRAN
	delete from Pronostico where CodC = @CodC AND CodP = @CodP
	if (@@ERROR != 0)
	begin
		Rollback Tran 
		return -2
	end
	

	delete from Ciudad where CodC = @CodC AND CodP = @CodP
	if (@@ERROR != 0)
	begin
		Rollback Tran 
		return -3
	end
	
	
	Commit Tran
	return 1
End
Go

Create Procedure ModificarCiudad 
@CodC  varchar(3), 
@CodP  varchar(3), 
@NombreC varchar (25) 
AS
Begin
	
	IF NOT exists(select CodC, CodP from Ciudad where CodC = @CodC AND CodP = @CodP)
		return -1 
		
	UPDATE Ciudad
	Set NombreC = @NombreC
	where CodC = @CodC AND CodP = @CodP
	
	if (@@ERROR = 0)
		return 1
	else
		return -2

End
Go

CREATE PROCEDURE BuscarCiudad @CodC varchar (3), @CodP varchar (3)  AS
Begin
	Select * From Ciudad Where CodC = @CodC AND CodP = @CodP
End
go  

CREATE PROCEDURE ListarCiudad AS
Begin
	Select * From Ciudad
End
go

CREATE PROCEDURE ListarCxP @CodP varchar (3) AS
Begin
	Select *
	From Ciudad
	Where CodP = @CodP
End
go

-------------------------ABM DE USUARIOS-------------------------
CREATE PROCEDURE AltaUsuario
@NombreUsu varchar(30), 
@Nombre   varchar(20), 
@Contrasenia  varchar (10) 

AS
BEGIN 
	IF exists(select NombreUsu from Usuario where NombreUsu = @NombreUsu)
		return -1 
	
	INSERT Usuario values(@NombreUsu, @Nombre, @Contrasenia)
	return 1
	
END
GO


Create Procedure ModificarUsuario
@NombreUsu varchar(30), 
@Nombre   varchar(20), 
@Contrasenia  varchar (10) 
AS
Begin
	
	IF NOT exists(select * from Usuario where NombreUsu = @NombreUsu)
		return -1 

	UPDATE Usuario
	Set Nombre = @Nombre, Contrasenia = @Contrasenia
	where NombreUsu = @NombreUsu
	
	if (@@ERROR = 0)
		return 1
	else
		return -2

End
Go

Create Procedure BajaUsuario
@NombreUsu varchar(30)
AS
Begin
	
	IF NOT exists(select NombreUsu from Usuario where NombreUsu = @NombreUsu)
		return -1 
		
	IF exists(select NombreUsu from Pronostico where NombreUsu = @NombreUsu)
		return -2	

	delete from Usuario where  NombreUsu = @NombreUsu
		
	if (@@ERROR = 0)
		return 1
	else
		return -3
End
Go


CREATE PROCEDURE BuscarUsuario @NombreUsu varchar(30) AS
Begin
	Select * From Usuario Where NombreUsu = @NombreUsu 
End
go
-----REGISTRAR UN PRONOSTICO-----

CREATE PROCEDURE AltaPronostico
@FechaHora DateTime, 
@Velocidad  int, 
@ProbL  int,
@ProbT  int,
@TipoCielo varchar (20),
@Tmax int,
@Tmin int,
@NombreUsu int,
@CodC varchar (3),
@CodP varchar (3)
 
 
AS
BEGIN 
	IF NOT exists(select * from Ciudad where CodC = @CodC AND CodP = @CodP)
		return -1
	IF NOT exists(select * from Usuario where NombreUsu = @NombreUsu)
		return -2

IF exists(select * from Pronostico where CodC = @CodC AND CodP = @CodP AND FechaHora = @FechaHora)
		return -3
		
	INSERT Pronostico values(@FechaHora, @Velocidad, @ProbL, @ProbT, @TipoCielo, @Tmax, @Tmin, @CodC, @CodP, @NombreUsu)
	return 1
	
END
GO

-----LISTADO DE PRONOSTICOS POR CIUDAD-----
CREATE PROCEDURE ListarPronxCiudad @CodC varchar (3), @CodP varchar (3) AS
Begin
	Select CodIntP, FechaHora, Velocidad, ProbL, ProbT, TipoCielo, Tmax, Tmin, NombreUsu
	From  Pronostico   
	Where CodC  = @CodC AND CodP = @CodP
	ORDER BY FechaHora
End
go

-----LISTADO DE PRONOSTICOS PARA EL DIA-----
CREATE PROCEDURE ListarPronosticoxDia @FechaHora DateTime AS
BEGIN
select *
from Pronostico
where FechaHora= @FechaHora 
END
go

