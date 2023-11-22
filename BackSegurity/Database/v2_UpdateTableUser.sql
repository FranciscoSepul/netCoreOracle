
delete from usuario;
delete from empresa;

alter table usuario
drop cuenta;

ALTER TABLE usuario 
ADD IdTipoCuenta NUMBER ;

ALTER TABLE usuario 
ADD idempresa NUMBER ;

ALTER TABLE usuario 
ADD clave VARCHAR2 (50);

ALTER TABLE usuario 
ADD fechaCreacion VARCHAR2 (50) ;

ALTER TABLE usuario 
ADD IsDelete number ;

ALTER TABLE usuario 
ADD funcion VARCHAR2 (50) ;

ALTER TABLE usuario 
ADD Correo VARCHAR2 (50) ;

ALTER TABLE usuario 
ADD apellido VARCHAR2 (50) ;

ALTER TABLE usuario 
ADD DvRut VARCHAR2 (5) ;

