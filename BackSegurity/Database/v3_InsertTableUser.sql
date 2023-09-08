INSERT INTO empresa (id_empresa, nom_empresa) VALUES (1, 'Codelco');
INSERT INTO empresa (id_empresa, nom_empresa) VALUES (2, 'BCI');
INSERT INTO empresa (id_empresa, nom_empresa) VALUES (3, 'Sonda');
INSERT INTO empresa (id_empresa, nom_empresa) VALUES (4, 'Todos');

INSERT INTO usuario (id_usuario, run_usuario, nom_usuario, IDTIPOCUENTA, tipo_contrato, fono_usuario, nacionalidad,CLAVE,IDEMPRESA,FECHACREACION,ISDELETE,FUNCION,CORREO,APELLIDO,DVRUT)
VALUES (1, '25487120', 'Marcelo', 1 , 'Indefinido', 992315822, 'Colombiana',12345,4,'02/09/2023',0,'Administrador Web','CorreoFalso@gmail.com','Soto','K');



ALTER TABLE ADMIN.USUARIO 
    ADD CONSTRAINT USUARIO_PK PRIMARY KEY ( 
    ID_USUARIO  
    ) 
USING INDEX LOGGING