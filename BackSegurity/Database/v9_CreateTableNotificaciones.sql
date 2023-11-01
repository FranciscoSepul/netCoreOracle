
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
    plan VARCHAR2
    (100),
    contacto VARCHAR2
    (255),
    caso_activo CHAR
    (1)
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
        (1, '19557236', '4', 'Francisco', 'Sepulveda', 949694538, 'franciscosepul96@gmail.com', 'Chileno', 1, 0, 1, 1);

    INSERT INTO Trabajadores
        (id,RUN,DVRUT,nombre,APELLIDO,FONO_USUARIO,CORREO,NACIONALIDAD,IDEMPRESA,ISDELETE,IDDIRECCION,IDACTIVIDADDETRABAJO)
    VALUES
        (2, '29557236', '4', 'Francisco', 'Sepulveda', 949694538, 'wwwvisualkei@gmail.com', 'Chileno', 1, 0, 1, 1);


    INSERT INTO Trabajadores
        (id,RUN,DVRUT,nombre,APELLIDO,FONO_USUARIO,CORREO,NACIONALIDAD,IDEMPRESA,ISDELETE,IDDIRECCION,IDACTIVIDADDETRABAJO)
    VALUES
        (3, '19557236', '4', 'Francisco', 'Sepulveda', 949694538, 'franciscosepul96@gmail.com', 'Chileno', 2, 0, 1, 1);

    INSERT INTO Trabajadores
        (id,RUN,DVRUT,nombre,APELLIDO,FONO_USUARIO,CORREO,NACIONALIDAD,IDEMPRESA,ISDELETE,IDDIRECCION,IDACTIVIDADDETRABAJO)
    VALUES
        (4, '19557236', '4', 'Francisco', 'Sepulveda', 949694538, 'franciscosepul96@gmail.com', 'Chileno', 3, 0, 1, 1);


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

    ---Here new modification
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


    update usuario set FONO_USUARIO=949694538
    ;
    update usuario set CORREO='franciscosepul96@gmail.com'
    ;


    CREATE TABLE PropiedadEmpresa
    (
        Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );

    INSERT INTO PropiedadEmpresa
        (id,nombre)
    VALUES
        (1, 'Publica');
    INSERT INTO PropiedadEmpresa
        (id,nombre)
    VALUES
        (2, 'Privada');

    CREATE TABLE TipoDeEmpresa
    (
        Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );

    INSERT INTO TipoDeEmpresa
        (id,nombre)
    VALUES
        (1, 'Principal');
    INSERT INTO TipoDeEmpresa
        (id,nombre)
    VALUES
        (2, 'Contratista');
    INSERT INTO TipoDeEmpresa
        (id,nombre)
    VALUES
        (3, 'Subcontratista');
    INSERT INTO TipoDeEmpresa
        (id,nombre)
    VALUES
        (4, 'De Servicio Transitorio');

    ALTER TABLE Empresa 
    ADD NumeroTelefonico number;
    ALTER TABLE Empresa 
    ADD ActividadEconomica VARCHAR(250);
    ALTER TABLE Empresa 
    ADD IdPropiedadEmpresa number;
    ALTER TABLE Empresa 
    ADD idTipoDeEmpresa number;

    INSERT INTO EMPRESA
        (id_empresa, nom_empresa,Rut,DvRut,fechaCreacion,fechaFinContrato,IsDelete,ImageBase64,Correo,IdDireccion,NumeroTelefonico,ActividadEconomica,IdPropiedadEmpresa,idTipoDeEmpresa)
    VALUES
        (1, 'Codelco', '11111111', 'k', '01-01-2023', '01-01-2025', 0, null, 'Codelco@gmail.com', 1, 949694538, 'Mineria', 2, 1);
    INSERT INTO EMPRESA
        (id_empresa, nom_empresa,Rut,DvRut,fechaCreacion,fechaFinContrato,IsDelete,ImageBase64,Correo,IdDireccion,NumeroTelefonico,ActividadEconomica,IdPropiedadEmpresa,idTipoDeEmpresa)
    VALUES
        (2, 'BCI', '22222222', 'k', '02-02-2023', '01/03-2026', 0, null, 'Bci@gmail.com', 2, 949694538, 'Bancaria', 2, 1);
    INSERT INTO EMPRESA
        (id_empresa, nom_empresa,Rut,DvRut,fechaCreacion,fechaFinContrato,IsDelete,ImageBase64,Correo,IdDireccion,NumeroTelefonico,ActividadEconomica,IdPropiedadEmpresa,idTipoDeEmpresa)
    VALUES
        (3, 'Sonda', '33333333', 'k', '03-03-2023', '01-02-2024', 0, null, 'Sonda@gmail.com', 3, 949694538, 'Tecnologia', 2, 1);
    INSERT INTO EMPRESA
        (id_empresa, nom_empresa,Rut,DvRut,fechaCreacion,fechaFinContrato,IsDelete,ImageBase64,Correo,IdDireccion,NumeroTelefonico,ActividadEconomica,IdPropiedadEmpresa,idTipoDeEmpresa)
    VALUES
        (4, 'Todos', '44444444', 'k', '04-04-2023', '01-04-2024', 0, null, 'NoMasAccidentes@gmail.com', 4, 949694538, '', 2, 1);


    ALTER TABLE trabajadores 
    ADD sexo number;

    ALTER TABLE trabajadores 
    ADD HoraIngreso VARCHAR2(250);
    ALTER TABLE trabajadores 
    ADD HoraSalida VARCHAR2(250);

    update trabajadores set HoraIngreso='08:30';
    update trabajadores set HoraSalida='06:00';
    update trabajadores set sexo=1;

    ALTER TABLE trabajadores 
 ADD FechaNacimiento VARCHAR2(250);
    update trabajadores set FechaNacimiento='15-09-1996';

    ALTER TABLE trabajadores 
  ADD PuebloOriginario VARCHAR2(250);
    update trabajadores set PuebloOriginario='Ninguno';


    ALTER TABLE trabajadores 
    ADD Profesion VARCHAR2(250);
    update trabajadores set Profesion='Programador';

    ALTER TABLE trabajadores 
    ADD fechaContrato VARCHAR2(250);
    update trabajadores set fechaContrato='01-01-2020';

    ALTER TABLE trabajadores 
    ADD TipoDeContrato VARCHAR2(250);
    update trabajadores set TipoDeContrato='Indefinido';

    CREATE TABLE CategoriaOcupacional
    (
        Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );

    INSERT INTO CategoriaOcupacional
        (id,nombre)
    VALUES
        (1, 'Empleador');
    INSERT INTO CategoriaOcupacional
        (id,nombre)
    VALUES
        (2, 'Trabajador Independiente');
    INSERT INTO CategoriaOcupacional
        (id,nombre)
    VALUES
        (3, 'Trabajador Dependiente');
    INSERT INTO CategoriaOcupacional
        (id,nombre)
    VALUES
        (4, 'Familiar No Remunerado');
    INSERT INTO CategoriaOcupacional
        (id,nombre)
    VALUES
        (5, 'Trabajador Voluntario');

    ALTER TABLE trabajadores 
    ADD idCategoriaOcupacional int;
    update trabajadores set idCategoriaOcupacional=2;

    CREATE TABLE TipoDeIngreso
    (
        Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );

    INSERT INTO TipoDeIngreso
        (id,nombre)
    VALUES
        (1, 'Remuneración fija');
    INSERT INTO TipoDeIngreso
        (id,nombre)
    VALUES
        (2, 'Remuneración variable');
    INSERT INTO TipoDeIngreso
        (id,nombre)
    VALUES
        (3, 'Honorarios');

    ALTER TABLE trabajadores 
    ADD IdTipoDeIngreso VARCHAR2(250);
    update trabajadores set IdTipoDeIngreso=1;


    CREATE TABLE LugarDeAccidente
    (
        Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );

    INSERT INTO LugarDeAccidente
        (id,nombre)
    VALUES
        (1, 'Trabajo');
    INSERT INTO LugarDeAccidente
        (id,nombre)
    VALUES
        (2, 'Trajecto');


    ALTER TABLE Accidente 
    ADD IdLugarDeAccidente int;
    update Accidente set IdLugarDeAccidente=1;

    CREATE TABLE MedioDePrueba
    (
        Id NUMBER PRIMARY KEY,
        Nombre VARCHAR2 (250)
    );

    INSERT INTO MedioDePrueba
        (id,nombre)
    VALUES
        (1, 'Parte de Carabineros');
    INSERT INTO MedioDePrueba
        (id,nombre)
    VALUES
        (2, 'Declaración');
    INSERT INTO MedioDePrueba
        (id,nombre)
    VALUES
        (3, 'Testigos');
    INSERT INTO MedioDePrueba
        (id,nombre)
    VALUES
        (4, 'Otro');

    ALTER TABLE Accidente 
    ADD IdMedioDePrueba int;
    update Accidente set IdMedioDePrueba=2;

    ALTER TABLE Empresa 
    ADD CantidadDeEmpleadosPorContrato number;
    update Empresa set CantidadDeEmpleadosPorContrato=50;


    CREATE TABLE PreciosPorEmpresa
    (
        Id NUMBER PRIMARY KEY,
        IdEmpresa number,
        CostoPorAccidente number,
        CostoPorCharla number,
        CostoPorVisita number,
        CostoBase number,
        CostoPorAsesoria number,
        CostoPorAsesoriaEspecial number,
        CostoPorPersonaExtra number
    );

     INSERT INTO PreciosPorEmpresa
        (Id,IdEmpresa ,CostoPorAccidente , CostoPorCharla ,CostoPorVisita ,CostoBase ,
        CostoPorAsesoria ,CostoPorAsesoriaEspecial ,CostoPorPersonaExtra )
    VALUES
        (1, 1,10000,10000,10000,10000,10000,10000,10000);
         INSERT INTO PreciosPorEmpresa
        (Id,IdEmpresa ,CostoPorAccidente , CostoPorCharla ,CostoPorVisita ,CostoBase ,
        CostoPorAsesoria ,CostoPorAsesoriaEspecial ,CostoPorPersonaExtra )
    VALUES
        (2, 2,10000,10000,10000,10000,10000,10000,10000);
         INSERT INTO PreciosPorEmpresa
        (Id,IdEmpresa ,CostoPorAccidente , CostoPorCharla ,CostoPorVisita ,CostoBase ,
        CostoPorAsesoria ,CostoPorAsesoriaEspecial ,CostoPorPersonaExtra )
    VALUES
        (3, 3,10000,10000,10000,10000,10000,10000,10000);


        update trabajadores set FechaNacimiento='09/15/1996 00:00:00';