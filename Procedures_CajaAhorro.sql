--CREATE PROCEDURE usp_darAportacion ( @idusuario int, @dinero decimal(18,2))
--AS
--BEGIN
--	IF exists (SELECT * FROM dtcuenta WHERE idusuario = @idusuario)
--	BEGIN
--		DECLARE @idcuenta int
--		SET @idcuenta = (SELECT idcuenta from dtcuenta where idusuario = @idusuario)

--		IF @dinero > 0
--		BEGIN
--			UPDATE dtcuenta SET dinero = dinero + @dinero, disponible = disponible + @dinero WHERE idusuario = @idusuario
--			INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Aportacion', 'SUCCESS', 'Se agrego Aportacion a la cuenta')
--			select 'ok' response
--		END
--		ELSE
--		BEGIN
--			INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Aportacion', 'ERROR', 'El dinero aportado debe ser mayor a 0')
--			select 'El monto a insertar debe ser mayor a 0' response
--		END
--	END
--	ELSE
--	BEGIN
--		select 'La cuenta no existe' response
--	END
--END



--CREATE PROCEDURE usp_deposito(@idusuario int, @dinero decimal(18,2))
--AS
--BEGIN
--	IF EXISTS(SELECT * FROM dtcuenta WHERE idusuario = @idusuario)
--	BEGIN
--		DECLARE @idcuenta int

--		SET @idcuenta = (SELECT idcuenta from dtcuenta where idusuario = @idusuario)

--		IF @dinero > 0
--		BEGIN
--			UPDATE dtcuenta SET dinero = (dinero+@dinero), disponible = (disponible + @dinero) WHERE idusuario = @idusuario
--			INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Deposito', 'SUCCESS', 'El deposito se hizo correctamente')
--			SELECT 'ok' response
--		END
--		ELSE
--		BEGIN
--			INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Deposito', 'ERROR', 'El dinero a depositar debe ser mayor a 0')
--			select 'El monto a insertar debe ser mayor a 0' response
--		END
--	END
--	ELSE
--	BEGIN
--		SELECT 'No se pudo realizar el dep�sito' response
--	END
--END


--CREATE PROCEDURE usp_retiro(@idusuario int, @dinero decimal(18,2))
--AS
--BEGIN
--	IF EXISTS(SELECT * FROM dtcuenta WHERE @idusuario = idusuario)
--	BEGIN
--		IF EXISTS(SELECT * FROM dtcuenta where @idusuario = idusuario AND disponible >= @dinero)
--		BEGIN
	
--			DECLARE @idcuenta int
--			DECLARE @dinero_disponible decimal(18,2)

--			SET @idcuenta = (SELECT idcuenta from dtcuenta where idusuario = @idusuario)

--			SET @dinero_disponible = (select (select sum(monto) as retiro from dtproceso where mensaje = 'SUCCESS' and tipo <> 'Retiro' ) - 
--											   (select ISNULL(sum(monto), 0) as retiro from dtproceso where mensaje = 'SUCCESS' and tipo = 'Retiro') - 
--											   (select ISNULL(sum(monto), 0) as retiro from dtproceso where mensaje = 'SUCCESS' and tipo = 'Prestamo'))

--			IF (@dinero_disponible - @dinero) >= 0
--			BEGIN
--				IF @dinero > 0
--				BEGIN
--					UPDATE dtcuenta SET dinero = (dinero-@dinero), disponible = (disponible-@dinero) WHERE idusuario = @idusuario
--					INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Retiro', 'SUCCESS', 'El retiro se realizo correctamente')
--					SELECT 'ok' response
--				END
--				ELSE
--				BEGIN
--					INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Retiro', 'ERROR', 'El dinero a retirar debe ser mayor a 0')
--					select 'El monto a insertar debe ser mayor a 0' response
--				END
--			END
--			ELSE
--			BEGIN
--				INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Retiro', 'ERROR', 'No hay dinero suficiente en la caja')
--				SELECT 'No hay dinero suficiente en la caja' response
--			END
--		END
--		ELSE
--		BEGIN
--			INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Retiro', 'ERROR', 'No tienes disponible el dinero solicitado')
--			SELECT 'No dispones del efectivo suficiente' response
--		END
--	END
--	ELSE
--	BEGIN
--		SELECT 'No se pudo realizar el retiro' response
--	END
--END


--CREATE PROCEDURE usp_altaUsuario(
--@nombre nchar(200),
--@email varchar(max),
--@password varchar(max)
--)
--AS
--BEGIN
--	IF NOT EXISTS(SELECT * FROM dtusuarios WHERE nombre = @nombre)
--	BEGIN
--		IF NOT EXISTS(SELECT * FROM dtusuarios WHERE email = @email)
--		BEGIN
--			declare @lastid int
--			INSERT INTO dtusuarios VALUES(@nombre,@email,@password,'cliente')

--			SET @lastid = @@IDENTITY

--			INSERT INTO dtcuenta values(@lastid, 0, 0)
--			SELECT 'ok' response
--		END
--		ELSE
--		BEGIN
--			SELECT 'El email del usuario ya existe' response
--		END
--	END
--	ELSE
--	BEGIN
--		SELECT 'El nombre de usuario ya existe' response
--	END
--END

--CREATE PROCEDURE usp_ValidarUserToken
--(
--@usertoken nchar(50),
--@passwordtoken nchar(100)
--)
--AS
--BEGIN

--	IF NOT EXISTS(SELECT * FROM dtusertokens WHERE usertokens = @usertoken and passworktokens = @passwordtoken) 
--	BEGIN

--		SELECT 'ok' response

--	END
--	ELSE
--	BEGIN

--		SELECT 'Usuario o contrase�a del token no existe' response

--	END
--END


--CREATE PROCEDURE usp_obtenerEstadoCuentaUsuario
--(
--@idusuario int
--)
--AS
--BEGIN

	
--	DECLARE @idcuenta int
--	SET @idcuenta = (SELECT idcuenta from dtcuenta where idusuario = @idusuario)

--	IF EXISTS (SELECT * from dtprestamo where idcuenta = @idcuenta)
--	BEGIN

--		SELECT c.idcuenta, c.idusuario, c.dinero, c.disponible, sum(p.deuda) as deuda_total, 'ok' response FROM dtcuenta c
--		INNER JOIN dtprestamo p on p.idcuenta = c.idcuenta
--		WHERE c.idusuario = @idusuario GROUP BY c.idcuenta, c.idusuario, c.dinero, c.disponible
--	END
--	ELSE
--	BEGIN
--		SELECT c.idcuenta, c.idusuario, c.dinero, c.disponible, 0 deuda_total, 'ok' response FROM dtcuenta c
--		WHERE c.idcuenta = @idcuenta
--	END
--END


--CREATE PROCEDURE usp_listarProcesosDia
--AS
--BEGIN

--	DECLARE @fecha datetime
--	SELECT @fecha = GETDATE()

--	SELECT pr.*, u.nombre, u.email, u.password, u.tipo FROM dtproceso pr
--	INNER JOIN dtcuenta c on c.idcuenta = pr.idcuenta
--	INNER JOIN dtusuarios u on u.idusuario = c.idusuario
--	WHERE DATEDIFF(yy, pr.fecha, @fecha) = 0 and DATEDIFF(mm, pr.fecha, @fecha) = 0 and DATEDIFF(dd, pr.fecha, @fecha) = 0
--END

ALTER PROCEDURE usp_darPrestamo
(
@idusuario int,
@dinero decimal(18,2),
@opcion int
)
AS
BEGIN
	IF EXISTS(SELECT * FROM dtusuarios WHERE idusuario = @idusuario)
	BEGIN

		IF @dinero > 0
		BEGIN
			DECLARE @dinero_disponible decimal(18,2)
			SET @dinero_disponible = (select (select sum(monto) as retiro from dtproceso where mensaje = 'SUCCESS' and tipo <> 'Retiro' ) - 
											   (select ISNULL(sum(monto), 0) as retiro from dtproceso where mensaje = 'SUCCESS' and tipo = 'Retiro') - 
											   (select ISNULL(sum(monto), 0) as retiro from dtproceso where mensaje = 'SUCCESS' and tipo = 'Prestamo'))

			DECLARE @idcuenta int
			DECLARE @dinero_retenido decimal(18,2)
			DECLARE @deuda decimal(18,2)
			SET @idcuenta = (SELECT idcuenta from dtcuenta where idusuario = @idusuario)
			SET @deuda = @dinero + (@dinero * (@opcion/CONVERT(decimal(8,2), 100))) 

			SET @dinero_retenido = @dinero * 0.20

			IF EXISTS (SELECT * FROM dtcuenta where idcuenta = @idcuenta and disponible >= @dinero_retenido)
			BEGIN
				IF @dinero_disponible >= @dinero
				BEGIN
					IF @opcion = 8
					BEGIN
						INSERT INTO dtprestamo values(@idcuenta, @opcion, @dinero, @deuda, GETDATE(), DATEADD(MONTH, 3, GETDATE()))
					END

					IF @opcion = 4
					BEGIN
						INSERT INTO dtprestamo values(@idcuenta, @opcion, @dinero, @deuda, GETDATE(), DATEADD(MONTH, 6, GETDATE()))
					END

					IF @opcion = 2
					BEGIN
						INSERT INTO dtprestamo values(@idcuenta, @opcion, @dinero, @deuda, GETDATE(), DATEADD(MONTH, 9, GETDATE()))
						
					END

					UPDATE dtcuenta set disponible = disponible - @dinero_retenido where idcuenta = @idcuenta

					INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Prestamo', 'SUCCESS', 'Prestamo realizado')
					SELECT 'ok' response
				END
				ELSE
				BEGIN
					INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Prestamo', 'ERROR', 'No hay dinero suficiente en la caja')
					SELECT 'No hay dinero disponible en la caja' response
				END

			END
			ELSE
			BEGIN
				INSERT INTO dtproceso values(@idcuenta, GETDATE(), @dinero, 'Prestamo', 'ERROR', 'No cuenta con el recurso suficiente para efectuar un prestamo')
				SELECT 'No cuenta con el recurso suficiente para efectuar un prestamo' response
			END
		END
		ELSE
		BEGIN
			SELECT 'El prestamo debe ser mayor a 0' response
		END
	END
	ELSE
	BEGIN
		SELECT 'No se puede realizar el prestamo' response
	END

END


select * from dtprestamo
