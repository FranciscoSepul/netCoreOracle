
CREATE TABLE factura (
    idfactura NUMBER PRIMARY KEY,
    fechaemision DATE,
    fechacobro DATE,
    fechapago DATE
);

CREATE TABLE item (
    iditem NUMBER PRIMARY KEY,
    nombreitem VARCHAR2(255),
    cantidad NUMBER,
    precio NUMBER
);


CREATE TABLE visitaterreno (
    idvisitaterreno NUMBER PRIMARY KEY,
    razon VARCHAR2(255),
    descripcion VARCHAR2(1000),
    fechaplazo DATE,
    status VARCHAR2(50),
    comentario VARCHAR2(1000),
    costo NUMBER
);

CREATE TABLE checklist (
    idchecklist NUMBER PRIMARY KEY,
    checkdescrip VARCHAR2(2),
    checkstatus VARCHAR2(2),
    checkcomen VARCHAR2(1000)
);

CREATE TABLE Solicitudasesoria (
    idsolicitud NUMBER PRIMARY KEY,
    fechasolicitud DATE,
    fechaagendada DATE,
    motivo VARCHAR2(255),
    preferen_horario VARCHAR2(255),
    status_soli VARCHAR2(50),
    lugar VARCHAR2(255),
    contacto VARCHAR2(255),
    detalle VARCHAR2(1000)
);

CREATE TABLE casoasesoria (
    idcaso NUMBER PRIMARY KEY,
    cod_contrato VARCHAR2(50),
    plan VARCHAR2(100),
    contacto VARCHAR2(255),
    caso_activo CHAR(1)
);

CREATE TABLE asesoria (
    idasesoria NUMBER PRIMARY KEY,
    fecha_asesoria DATE,
    profesional VARCHAR2(255),
    lugar VARCHAR2(255),
    comentario VARCHAR2(1000)
);

CREATE TABLE TemaCapacitacion (
    IdCapacitacion NUMBER PRIMARY KEY,
    Capacitacion VARCHAR2(50)
);


INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(1,'Seguridad en el lugar de trabajo');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(2,'Manipulación de objetos muy pesados');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(3,'Reducir el riesgo de caída o deslizamiento');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(4,'Cómo apilar mercancías, cajas y otros objetos');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(5,'Uso correcto de los equipos de trabajo');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(6,'Riesgos silenciosos');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(7,'Medidas contra condiciones ambientales extremas');
 INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(8,'Prevención de incendios');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(9,'¿Cómo notificar accidentes y documentar incidentes?');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(10,'Trabajo en equipo');
     INSERT INTO TemaCapacitacion (IdCapacitacion, Capacitacion)VALUES
	(11,'Primeros auxilios');

CREATE TABLE Capacitacion
(
    Id NUMBER PRIMARY KEY,
    Tema NUMBER,
    IdProfesionalACargo NUMBER,
    IdCompany NUMBER,
    Descripcion VARCHAR2 (250),
    fechaProgramacion VARCHAR2(50) ,
    horaProgramacion VARCHAR2(50),
    isDelete NUMBER
);
 
  INSERT INTO Capacitacion (Id, Tema,IdProfesionalACargo,IdCompany,Descripcion,fechaProgramacion,horaProgramacion,isDelete)VALUES
	(1,1,1,1,'Primeros auxilios','01-10-2023','11:00',0);
    
--https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/asesoria/
--https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/casoasesoria/
--https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/checklist/
--https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/factura/
--https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/item/
--https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/solicitudasesoria/
--https://ge00e075da0ccb1-nomasaccidentes.adb.sa-santiago-1.oraclecloudapps.com/ords/admin/visitaterreno/


CREATE TABLE ActividadDeTrabajo
(
  id NUMBER PRIMARY KEY,
  nombre VARCHAR2(210) NOT NULL
);

    INSERT INTO ActividadDeTrabajo (id,nombre)VALUES
	(1,'técnicas');
    INSERT INTO ActividadDeTrabajo (id,nombre)VALUES
	(2,'comerciales');
    INSERT INTO ActividadDeTrabajo (id,nombre)VALUES
	(3,'financieras');
    INSERT INTO ActividadDeTrabajo (id,nombre)VALUES
	(4,'seguridad');
    INSERT INTO ActividadDeTrabajo (id,nombre)VALUES
	(5,'contables');
    INSERT INTO ActividadDeTrabajo (id,nombre)VALUES
	(6,'administrativas');

CREATE TABLE Trabajadores
(
  id NUMBER PRIMARY KEY,
  run VARCHAR2(10) NOT NULL,
  DvRut VARCHAR2 (5),
  nombre VARCHAR2(40) NOT NULL,
  apellido VARCHAR2 (50), 
  fono_usuario NUMBER(15) NOT NULL,
  Correo VARCHAR2 (50) ,
  nacionalidad VARCHAR2(20) NOT NULL,
  idempresa NUMBER,
  IsDelete number ,
  IdDireccion number,
  idActividadDeTrabajo number
);

INSERT INTO Trabajadores (id,RUN,DVRUT,nombre,APELLIDO,FONO_USUARIO,CORREO,NACIONALIDAD,IDEMPRESA,ISDELETE,IDDIRECCION,IDACTIVIDADDETRABAJO)VALUES
(1,'17116112','1','Camilo','loyola',111111111,'correofalso@gmail.com','Chileno',1,0,1,1);