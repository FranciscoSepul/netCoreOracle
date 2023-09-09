INSERT INTO empresa (id_empresa, nom_empresa) VALUES (1, 'Codelco');
INSERT INTO empresa (id_empresa, nom_empresa) VALUES (2, 'BCI');
INSERT INTO empresa (id_empresa, nom_empresa) VALUES (3, 'Sonda');
INSERT INTO empresa (id_empresa, nom_empresa) VALUES (4, 'Todos');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario, nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (1, '25487120', 'Marcelo', 1 , 'Indefinido', 992315822, 'Colombia',12345,4,'02/09/2023',0,'Administrador Web','CorreoFalso@gmail.com','Soto','K');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (2, '18647120', 'Manuel', 1 , 'Indefinido', 965487231, 'Colombia',16485,4,'01/10/2023',0,'Profesional','Manuel485@gmail.com','Montilla','6');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (3, '25998225', 'Marcel', 2 , 'Indefinido', 978551203, 'Bolivia',45687,2,'02/07/2023',0,'Administrador Web','Marcel.s@gmail.com','Soto','K');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (4, '14587999', 'Bastian', 1 , 'Plazo fijo', 998556478, 'Bolivia',14253,1,'01/05/2023',0,'Profesional','Bastian524@gmail.com','Muller','4');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (5, '20132654', 'Jordi', 1 , 'Indefinido', 921365987, 'Chile',45623,3,'03/01/2023',0,'Administrador Web','Jordirtg@gmail.com','Lopez','7');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (6, '18663215', 'Raul', 2 , 'Indefinido', 998775462, 'Colombia',48756,4,'15/09/2023',0,'Profesional','125Raul@gmail.com','Venegas','3');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (7, '25487222', 'Marcela', 1 , 'Plazo fijo', 998562310, 'Chile',21548,4,'09/04/2023',0,'Profesional','Marcela.7.12.8456@gmail.com','Restrepo','1');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (8, '24512848', 'Carolina', 2 , 'Indefinido', 956874123, 'Chile',48565,2,'02/11/2023',0,'Profesional','Carolina6953@gmail.com','Mejias','K');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (9, '19486111', 'Jhon', 1 , 'Indefinido', 965884128, 'Mexico',96325,1,'02/12/2023',0,'Profesional','Jhon.j123@gmail.com','Alonso','8');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (10, '25555880', 'Nicolas', 1 , 'Plazo fijo', 910325478, 'Chile',14578,4,'04/03/2023',0,'Profesional','Nicolas@gmail.com','Sanchez','4');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario,nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (11, '20321456', 'Jose', 1 , 'Indefinido', 995663322, 'Chile',98651,3,'01/12/2023',0,'Profesional','Joselete@gmail.com','Blanco','K');

INSERT INTO funcion (id_fun, nom_fun) VALUES (3, 'Empresa');

ALTER TABLE ADMIN.USUARIO 
    ADD CONSTRAINT USUARIO_PK PRIMARY KEY ( 
    ID_USUARIO  
    ) 
--USING INDEX LOGGING