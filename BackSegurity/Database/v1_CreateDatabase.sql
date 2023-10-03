
CREATE TABLE empresa 
(
  id_empresa NUMBER(10) NOT NULL, 
  nom_empresa VARCHAR2(35),
  CONSTRAINT EMPRESA_pk PRIMARY KEY (id_empresa)
);

CREATE TABLE usuario
(
  id_usuario NUMBER (10) NOT NULL,
  run_usuario VARCHAR2(10) NOT NULL,
  nom_usuario VARCHAR2(40) NOT NULL,
  tipo_contrato VARCHAR2(20) NOT NULL,
  fono_usuario NUMBER(15) NOT NULL,
  nacionalidad VARCHAR2(20) NOT NULL,
  CONSTRAINT usuario_pk PRIMARY KEY (id_usuario)
);


CREATE TABLE funcion 
(
    id_fun NUMBER PRIMARY KEY,
    nom_fun VARCHAR2(50) NOT NULL
);


CREATE TABLE direccion
(
    id_direccion NUMBER (10),
    nom_reg VARCHAR2 (50) NOT NULL,
    nom_com VARCHAR2(50) NOT NULL,
    CONSTRAINT direccion_pk PRIMARY KEY (id_direccion)
);


INSERT INTO empresa (id_empresa, nom_empresa) VALUES (1, 'Codelco');
INSERT INTO empresa (id_empresa, nom_empresa) VALUES (2, 'BCI');
INSERT INTO empresa (id_empresa, nom_empresa) VALUES (3, 'Sonda');


INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, cuenta, tipo_contrato, fono_usuario, nacionalidad)
VALUES (60, '15235888-4', 'Joaquin Soto', 'Administrador', 'Indefinido', 965874231, 'Chilena');
INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, cuenta, tipo_contrato, fono_usuario, nacionalidad)
VALUES (20, '23496020-2', 'Carlos Cruz', 'Profesional', 'Indefinido', 987654321, 'Argentina');
INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, cuenta, tipo_contrato, fono_usuario, nacionalidad)
VALUES (15, '19562144-K', 'Vicente Gomez', 'Profesional', 'Plazo Fijo', 965314478, 'Chilena');
INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, cuenta, tipo_contrato, fono_usuario, nacionalidad)
VALUES (40, '17620333-7', 'Juan Soto', 'Profesional', 'Plazo Fijo', 998565587, 'Chilena');
INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, cuenta, tipo_contrato, fono_usuario, nacionalidad)
VALUES (35, '25487120-K', 'Marcelo Moreno', 'Administrador', 'Indefinido', 992315822, 'Colombiana');


INSERT INTO funcion (id_fun, nom_fun) VALUES (1, 'Administrador');
INSERT INTO funcion (id_fun, nom_fun) VALUES (2, 'Profesional');


INSERT INTO direccion (id_direccion, nom_reg, nom_com)
VALUES (01, 'Region Metropolitana', 'Santiago');
INSERT INTO direccion (id_direccion, nom_reg, nom_com)
VALUES (2, 'Region Arica', 'Arica');
INSERT INTO direccion (id_direccion, nom_reg, nom_com)
VALUES (3, 'Region Maule', 'Talca');
INSERT INTO direccion (id_direccion, nom_reg, nom_com)
VALUES (4, 'Region Los Rios', 'Valdivia');
INSERT INTO direccion (id_direccion, nom_reg, nom_com)
VALUES (5, 'Region Los Lagos', 'Puerto Montt');