CREATE TABLE TipoDeAccidente(
	id NUMBER PRIMARY KEY,
	accidente VARCHAR(250)
)

INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(1,'Caídas de personas');
INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(2,'Caídas de objetos');
INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(3,'Derrumbe');
INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(4,'Pisadas sobre objetos');
INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(5,'Atrapada por un objeto o entre objetos');
INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(6,'Esfuerzos excesivos o falsos movimientos');
INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(7,'Contacto con sustancias u objetos ardientes');
INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(8,'Exposición a radiaciones');
INSERT INTO TipoDeAccidente (id,accidente)VALUES
	(9,'Otras formas de accidente, no clasificadas');

CREATE TABLE Gravedad(
	id NUMBER PRIMARY KEY,
	gravedad VARCHAR(250)
)

INSERT INTO Gravedad (id,gravedad)VALUES
	(1,'Grave');
INSERT INTO Gravedad (id,gravedad)VALUES
	(2,'Fatal');
INSERT INTO Gravedad (id,gravedad)VALUES
	(3,'Otro');

CREATE table SucursalAchs(
	id NUMBER PRIMARY KEY,
	Nombre VARCHAR(250),
	IdRegion number NOT NULL,
	NumeroTelefonico number NOT NULL,
	Direccion VARCHAR(250)
)

INSERT INTO SucursalAchs (id,Nombre,IdRegion,NumeroTelefonico,Direccion)VALUES
	(1,'Centro Santiago Achs Salud',7,'830173812','Agustinas 1428, Santiago');
INSERT INTO SucursalAchs (id,Nombre,IdRegion,NumeroTelefonico,Direccion)VALUES
	(2,'Centro Arica Achs Salud',1,'90183099','Dr. Juan Noe 1367, Arica');
INSERT INTO SucursalAchs (id,Nombre,IdRegion,NumeroTelefonico,Direccion)VALUES
	(3,'Centro Iquique Achs Salud',2,'4312334234','Amunátegui 1517, Iquique');
INSERT INTO SucursalAchs (id,Nombre,IdRegion,NumeroTelefonico,Direccion)VALUES
	(4,'Centro Antofagasta Achs Salud',3,'5642342432','Avda. Grecia 840, Antofagasta');
INSERT INTO SucursalAchs (id,Nombre,IdRegion,NumeroTelefonico,Direccion)VALUES
	(5,'Centro Caldera Achs Salud',4,'854723312','Diego de Almeyda Nº130, Caldera');

CREATE TABLE accidente ( 
	id NUMBER PRIMARY KEY,
	descripcion VARCHAR(250),
    IdtipoAccidente number NOT NULL,
	IdEmpresa number NOT NULL,
	IdProfesional number NOT NULL,
	IdGravedad number NOT NULL,
	IdTrabajador number NOT NULL,
	FechaAccidente VARCHAR(250),
	FechaAlta VARCHAR(250),
	fono_emergencia NUMBER(30)
);

INSERT INTO accidente (id,descripcion,IdtipoAccidente,IdProfesional,IdGravedad,IdTrabajador,IdEmpresa,FechaAccidente,FechaAlta,fono_emergencia)VALUES
	(1,'caida desde altura ',1,1,1,1,1,'15-10-2023','20-10-2023','1231241412');


update accidente
set FechaAccidente='17/10/2023 21:08:14' where id=1