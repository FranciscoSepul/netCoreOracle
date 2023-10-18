
CREATE TABLE factura
(
    idfactura NUMBER PRIMARY KEY,
    fechaemision DATE,
    fechacobro DATE,
    fechapago DATE
);

CREATE TABLE item
(
    iditem NUMBER PRIMARY KEY,
    nombreitem VARCHAR2(255),
    cantidad NUMBER,
    precio NUMBER
);

CREATE TABLE visitaterreno
(
    idvisitaterreno NUMBER PRIMARY KEY,
    razon VARCHAR2(255),
    descripcion VARCHAR2(1000),
    fechaplazo DATE,
    status VARCHAR2(50),
    comentario VARCHAR2(1000),
    costo NUMBER
);

CREATE TABLE checklist
(
    idchecklist NUMBER PRIMARY KEY,
    checkdescrip VARCHAR2(2),
    checkstatus VARCHAR2(2),
    checkcomen VARCHAR2(1000)
);

CREATE TABLE Solicitudasesoria
(
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

CREATE TABLE casoasesoria
(
    idcaso NUMBER PRIMARY KEY,
    cod_contrato VARCHAR2(50),
    plan VARCHAR2(100),
    contacto VARCHAR2(255),
    caso_activo CHAR(1)
);

    CREATE TABLE asesoria
    (
        idasesoria NUMBER PRIMARY KEY,
        fecha_asesoria DATE,
        profesional VARCHAR2(255),
        lugar VARCHAR2(255),
        comentario VARCHAR2(1000)
    );

    CREATE TABLE TemaCapacitacion
    (
        IdCapacitacion NUMBER PRIMARY KEY,
        Capacitacion VARCHAR2(50)
    );


    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (1, 'Seguridad en el lugar de trabajo');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (2, 'Manipulación de objetos muy pesados');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (3, 'Reducir el riesgo de caída o deslizamiento');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (4, 'Cómo apilar mercancías, cajas y otros objetos');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (5, 'Uso correcto de los equipos de trabajo');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (6, 'Riesgos silenciosos');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (7, 'Medidas contra condiciones ambientales extremas');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (8, 'Prevención de incendios');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (9, '¿Cómo notificar accidentes y documentar incidentes?');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (10, 'Trabajo en equipo');
    INSERT INTO TemaCapacitacion
        (IdCapacitacion, Capacitacion)
    VALUES
        (11, 'Primeros auxilios');

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

    INSERT INTO Capacitacion
        (Id, Tema,IdProfesionalACargo,IdCompany,Descripcion,fechaProgramacion,horaProgramacion,isDelete)
    VALUES
        (1, 1, 1, 1, 'Primeros auxilios', '01-10-2023', '11:00', 0);

    CREATE TABLE ActividadDeTrabajo
    (
        id NUMBER PRIMARY KEY,
        nombre VARCHAR2(210) NOT NULL
    );

    INSERT INTO ActividadDeTrabajo
        (id,nombre)
    VALUES
        (1, 'técnicas');
    INSERT INTO ActividadDeTrabajo
        (id,nombre)
    VALUES
        (2, 'comerciales');
    INSERT INTO ActividadDeTrabajo
        (id,nombre)
    VALUES
        (3, 'financieras');
    INSERT INTO ActividadDeTrabajo
        (id,nombre)
    VALUES
        (4, 'seguridad');
    INSERT INTO ActividadDeTrabajo
        (id,nombre)
    VALUES
        (5, 'contables');
    INSERT INTO ActividadDeTrabajo
        (id,nombre)
    VALUES
        (6, 'administrativas');

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

    INSERT INTO Trabajadores
        (id,RUN,DVRUT,nombre,APELLIDO,FONO_USUARIO,CORREO,NACIONALIDAD,IDEMPRESA,ISDELETE,IDDIRECCION,IDACTIVIDADDETRABAJO)
    VALUES
        (1, '17116112', '1', 'Camilo', 'loyola', 111111111, 'correofalso@gmail.com', 'Chileno', 1, 0, 1, 1);


    ---Here new modification
    ALTER TABLE Capacitacion 
    ADD Idtrabajador NUMBER ;

    ALTER TABLE Capacitacion 
    ADD IdImplementos NUMBER ;

    CREATE TABLE Implementos
    (
        Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );

    INSERT INTO Implementos
        (id,nombre)
    VALUES
        (1, 'Todo');
    INSERT INTO Implementos
        (id,nombre)
    VALUES
        (2, 'Proyector');
    INSERT INTO Implementos
        (id,nombre)
    VALUES
        (3, 'Pizarra');
    INSERT INTO Implementos
        (id,nombre)
    VALUES
        (4, 'computadores');
    INSERT INTO Implementos
        (id,nombre)
    VALUES
        (5, 'Impresora');
    INSERT INTO Implementos
        (id,nombre)
    VALUES
        (6, 'Lapiz y papel');
    INSERT INTO Implementos
        (id,nombre)
    VALUES
        (7, 'Implementos de primeros auxilios');
    INSERT INTO Implementos
        (id,nombre)
    VALUES
        (8, 'Implementos control de incendios');


    CREATE TABLE Notification
    (
        id NUMBER PRIMARY KEY,
        idTipoNotificacion NUMBER,
        idNotificacionDirigida NUMBER,
        Titulo VARCHAR2(255),
        Cuerpo VARCHAR2(255),
        FechaProgramacion VARCHAR2(1000),
        idCompany number,
        idTrabajador number,
        status number
    );

    CREATE TABLE TipoNotification
    (
         Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );
     INSERT INTO TipoNotification
        (id,nombre)
    VALUES
        (1, 'Todas');
         INSERT INTO TipoNotification
        (id,nombre)
    VALUES
        (2, 'Correo');
         INSERT INTO TipoNotification
        (id,nombre)
    VALUES
        (3, 'SMS');
         INSERT INTO TipoNotification
        (id,nombre)
    VALUES
        (4, 'Notificacion');

    CREATE TABLE NotificationDirigida
    (
         Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );

    INSERT INTO NotificationDirigida
        (id,nombre)
    VALUES
        (1, 'Empresa');
        INSERT INTO NotificationDirigida
        (id,nombre)
    VALUES
        (2, 'Trabajador');
        INSERT INTO NotificationDirigida
        (id,nombre)
    VALUES
        (3, 'Profesional');