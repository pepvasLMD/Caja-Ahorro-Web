--CREATE TABLE dtusuarios(idusuario int identity(1, 1) primary key, nombre nchar(200),
--email nchar(100), password varchar(max), tipo nchar(50));


--CREATE table dtusertokens(idusertoken int identity(1,1) primary key, usertokens nchar(50), passworktokens nchar(100))


--CREATE TABLE dtcuenta(idcuenta int identity(1, 1) primary key, idusuario int, dinero decimal(18,2),
--disponible decimal(18,2));


--CREATE TABLE dtproceso(idproceso int identity(1,1) primary key, idcuenta int, fecha datetime, monto decimal(18,2), tipo nchar(20), mensaje nchar(200), descripcion varchar(max))

CREATE TABLE dtprestamo(idprestamo int identity(1,1) primary key, idcuenta int, interes decimal(18,2), cantidad decimal(18,2), deuda decimal(18,2), finicion datetime, ffin datetime)

--CREATE TABLE dtpago(idpago int identity(1,1) primary key, idprestamo int, fecha datetime, cantidad decimal(18,2))




--Insert into dtproceso values(0, GETDATE(), 10000, 'Deposito', 'SUCCESS', 'Saldo Inicial')