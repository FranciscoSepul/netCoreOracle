CREATE TABLE MotivoAsesoria
(
  id NUMBER PRIMARY KEY,
  nombre VARCHAR2(210) NOT NULL
);

    INSERT INTO MotivoAsesoria (id,nombre)VALUES
	(1,'Contra Incendio');
    INSERT INTO MotivoAsesoria (id,nombre)VALUES
	(2,'Seguridad');
    INSERT INTO MotivoAsesoria (id,nombre)VALUES
	(3,'Evacuacion');
    INSERT INTO MotivoAsesoria (id,nombre)VALUES
	(4,'Certificaciones');
    INSERT INTO MotivoAsesoria (id,nombre)VALUES
	(5,'Emergencias');
    INSERT INTO MotivoAsesoria (id,nombre)VALUES
	(6,'Accidentes');

ALTER TABLE ASESORIA 
ADD IdMotivoAsesoria int;

ALTER TABLE ASESORIA 
ADD IdCompany int;


CREATE TABLE TipoAsesoria
(
  id NUMBER PRIMARY KEY,
  nombre VARCHAR2(210) NOT NULL
);

    INSERT INTO TipoAsesoria (id,nombre)VALUES
	(1,'Normal');
     INSERT INTO TipoAsesoria (id,nombre)VALUES
	(2,'Especial');


ALTER TABLE ASESORIA 
ADD IdTipoDeAsesoria int;

INSERT INTO ASESORIA (idasesoria,fecha_asesoria,profesional,IdMotivoAsesoria,IdCompany,IdTipoDeAsesoria )VALUES
	(1,'09/11/2023 00:00:00',1,1,1,1);

 

ALTER TABLE Capacitacion 
ADD IdUsuariosCapacitacion varchar(500);

ALTER TABLE Capacitacion 
ADD IdImplementosCapacitacion varchar(500);

 delete Implementos where id =1


 CREATE TABLE factura
(
    id NUMBER PRIMARY KEY,
    fechaemision varchar2(250),
    fechacobro  varchar2(250),
    fechapago  varchar2(250),
    estado number,
    idDetalleFactura number,
    HabilitadoPago number,
    IdCompany number,
    MesEmision number,
    AnoEmision number,
    DiaEmision number
);

CREATE TABLE DetalleFactura
(
    id NUMBER PRIMARY KEY,
    costoBase number,
    costoPorCharla number,
    costoPorVisita number,
    costoPorAsesoria number,
    costoPorAsesoriaEspecial number,
    costoPorPersonaExtra number,
    totalPorPersonaExtra number,
    totalPorCharla number,
    totalPorVisita number,
    totalPorAsesoria number,
    totalPorAsesoriaEspecial number,
    MesalizacionValores number,
    AnoalizacionValores number,
    DiaalizacionValores number
);