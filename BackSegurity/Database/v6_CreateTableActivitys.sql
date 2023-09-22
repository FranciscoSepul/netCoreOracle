CREATE TABLE ACTIVIDAD
(
    id_actividad NUMBER,
    nom_actividad VARCHAR2 (250) NOT NULL,
    nom_descripcion VARCHAR2 (250),
    idProfesionalACargo NUMBER,
    fechaCreacion VARCHAR2(50) ,
    fechaProgramacion VARCHAR2(50) ,
    horaProgramacion VARCHAR2(50),
    idCompania NUMBER,
    fechaCreacion VARCHAR2(50) ,
    isDelete NUMBER,
    CONSTRAINT actividad_pk PRIMARY KEY (id_actividad)
);