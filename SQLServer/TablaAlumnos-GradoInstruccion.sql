create database SENATI
USE SENATI

create table Alumnos(
Id int Identity(1,1) not null PRIMARY KEY,
Nombres varchar(100) null,
Apellidos varchar(200)null,
Dni char(8),
Edad int,
Enabled bit
);

INSERT INTO Alumnos VALUES('José', 'Ramos', '08364728', 19, 1);
INSERT INTO Alumnos VALUES('Piero', 'Jimenez', '21937482', 18, 0);
INSERT INTO Alumnos VALUES('Juan', 'Martinez', '78512369', 21, 1);
 
SELECT * FROM Alumnos

--PROCEDIMIENTO ALMACENADO
-- Listar Alumnos
CREATE PROCEDURE ListarAlumnos
AS
BEGIN
SELECT * FROM Alumnos
end;

exec ListarAlumnos;

----------------------------------------
-- Insertar Alumnos
create PROCEDURE InsertarAlumnos
    @Nombres varchar(100),
    @Apellidos varchar(200),
    @Dni char(8),
    @Edad int,
	@Enabled bit
AS
BEGIN
    insert into Alumnos values(@Nombres, @Apellidos, @Dni, @Edad, @Enabled)
end

EXEC InsertarAlumnos 'Victor', 'Vasquez', '02846382', 18, 0

----------------------------------------
-- Update Alumnos
CREATE PROCEDURE UpdateAlumnos
	@Id int,
    @Nombres varchar(100),
    @Apellidos varchar(200),
    @Dni char(8),
    @Edad int,
	@Enabled bit
AS
BEGIN
	update Alumnos SET Nombres = @Nombres, Apellidos = @Apellidos, 
						Dni = @Dni, Edad = @Edad, Enabled = @Enabled
	where Id = @Id
end

exec UpdateAlumnos 4, 'Noe', 'Campos', '33728374', 34, 1 

-----------------------------------------
-- Delete Alumnos
CREATE PROCEDURE sp_DeleteAlumnos
    @Id INT
AS
BEGIN
    DELETE FROM Alumnos WHERE Id = @Id;
END;

EXEC sp_DeleteAlumnos 5;

-----------------------------------------
-- Update Enabled

CREATE PROCEDURE UpdateEnabled
	@Id int
AS
BEGIN
	update Alumnos SET Enabled = 0 WHERE Id =  @Id
end

exec UpdateEnabled 3

-----------------------------------------
-- creacion de usuario y password
-- Crear un nuevo inicio de sesión con el nombre 'alonso' y la contraseña '1234'
CREATE LOGIN alonso
WITH PASSWORD = '1234';

-- Cambiar al contexto de la base de datos donde se desea crear el usuario
USE SENATI;

-- Crear un nuevo usuario en la base de datos asociado con el inicio de sesión 'alonso'
CREATE USER alonso
FOR LOGIN alonso;

-- Otorgar permisos de lectura y escritura en la base de datos
ALTER ROLE db_datareader ADD MEMBER alonso;
ALTER ROLE db_datawriter ADD MEMBER alonso;

-- Permiso para ejecutar procedimientos almacenados
GRANT EXECUTE TO alonso;

-----------------------------------------

CREATE TABLE GradoInstruccion (
    Id int identity(1,1) NOT NULL PRIMARY KEY,
    Descripcion varchar(100) NOT NULL,
	Enabled bit
);

INSERT INTO GradoInstruccion VALUES('Primaria', 1);
INSERT INTO GradoInstruccion VALUES('Secundaria', 1);
INSERT INTO GradoInstruccion VALUES('Superior', 1);
INSERT INTO GradoInstruccion VALUES('Otros', 1);

SELECT * FROM GradoInstruccion

-- agregar nueva columna a la tabla Alumnos
alter table Alumnos add GradoInstruccionId int;

-- Agregar la clave foránea en la tabla Alumnos
ALTER TABLE Alumnos
ADD CONSTRAINT FK_Alumnos_GradoInstruccion
FOREIGN KEY (GradoInstruccionId) REFERENCES GradoInstruccion(Id);

----------------------------------------------------------

-- SP LISTAR DATOS DE AMBAS TABLAS Alumnos / GradoInstruccion
CREATE PROCEDURE ListarAlumnosGradoInstruccion
AS
BEGIN
    SELECT 
        a.Id AS AlumnoId,
        a.Nombres,
        a.Apellidos,
        a.Dni,
        a.Edad,
        a.Enabled AS AlumnoEnabled,
        g.Id AS GradoInstruccionId,
        g.Descripcion AS GradoInstruccionDescripcion,
        g.Enabled AS GradoInstruccionEnabled
    FROM 
        Alumnos a
    INNER JOIN 
        GradoInstruccion g ON a.GradoInstruccionId = g.Id;
END;

EXEC ListarAlumnosGradoInstruccion;















-------------------------------------------------------------
--SP DE LA TABLA GradoInstruccion

-- Insertar AlumnoGradoInstruccion

CREATE PROCEDURE InsertarGradoInstruccion
    @Descripcion VARCHAR(100),
    @Enabled BIT
AS
BEGIN
    INSERT INTO GradoInstruccion (Descripcion, Enabled)
    VALUES (@Descripcion, @Enabled);
END;

EXEC InsertarGradoInstruccion 'Secundaria', 1;

------------------------------------------------------------
-- Update AlumnoGradoInstruccion

CREATE PROCEDURE UpdateGradoInstruccion
    @Id INT,
    @Descripcion VARCHAR(100),
    @Enabled BIT
AS
BEGIN
    UPDATE GradoInstruccion
    SET 
        Descripcion = @Descripcion,
        Enabled = @Enabled
    WHERE 
        Id = @Id;
END;

EXEC UpdateGradoInstruccion 1, 'Primaria', 1;


------------------------------------------------------------------
-- Delete AlumnoGradoInstruccion

CREATE PROCEDURE DeleteGradoInstruccion
    @Id INT
AS
BEGIN
    DELETE FROM GradoInstruccion
    WHERE Id = @Id;
END;

EXEC DeleteGradoInstruccion 1;















--NUEVOS SP DE LA TABLA Alumnos

-- Insertar AlumnoGradoInstruccion

CREATE PROCEDURE InsertarAlumnosGradoInstruccion
    @Nombres VARCHAR(100),
    @Apellidos VARCHAR(200),
    @Dni CHAR(8),
    @Edad INT,
    @Enabled BIT,
    @GradoInstruccionId INT
AS
BEGIN
    BEGIN TRY
        -- Insertar en la tabla Alumnos
        INSERT INTO Alumnos (Nombres, Apellidos, Dni, Edad, Enabled, GradoInstruccionId)
        VALUES (@Nombres, @Apellidos, @Dni, @Edad, @Enabled, @GradoInstruccionId);
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        THROW;
    END CATCH
END;

EXEC InsertarAlumnosGradoInstruccion'Victor', 'Vasquez', '02846382', 18, 0, 4

----------------------------------------------------------

-- Update AlumnoGradoInstruccion

CREATE PROCEDURE UpdateAlumnosGradoInstruccion
    @Id INT,
    @Nombres VARCHAR(100),
    @Apellidos VARCHAR(200),
    @Dni CHAR(8),
    @Edad INT,
    @Enabled BIT,
    @GradoInstruccionId INT
AS
BEGIN
        -- Actualizar en la tabla Alumnos
        UPDATE Alumnos
        SET
            Nombres = @Nombres,
            Apellidos = @Apellidos,
            Dni = @Dni,
            Edad = @Edad,
            Enabled = @Enabled,
            GradoInstruccionId = @GradoInstruccionId
        WHERE Id = @Id;
END

exec UpdateAlumnosGradoInstruccion 4, 'Victor', 'Vasquez', '02846382', 18, 1, 2
2, 'Piero', 'Jimenez', '21937482', 18, 1, 1
3, 'Juan', 'Martinez', '78512369', 21, 1, 4


select * from Alumnos
---------------------------------------------------------

-- Delete AlumnoGradoInstruccion

CREATE PROCEDURE DeleteAlumnosGradoInstruccion
    @Id INT
AS
BEGIN
    BEGIN TRY
        -- Eliminar en la tabla Alumnos
        DELETE FROM Alumnos
        WHERE Id = @Id;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        THROW;
    END CATCH
END;

EXEC sp_DeleteAlumnosGradoInstruccion 5;         -- ID del alumno que deseas eliminar







DBCC CHECKIDENT ('Alumnos', RESEED, 3);

SELECT * FROM Alumnos

DELETE FROM Alumnos
