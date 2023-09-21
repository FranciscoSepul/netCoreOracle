delete from Empresa;

ALTER TABLE Empresa 
ADD Rut VARCHAR2 (50);

ALTER TABLE Empresa 
ADD DvRut VARCHAR2 (5);

ALTER TABLE Empresa 
ADD fechaCreacion VARCHAR2 (50);

ALTER TABLE Empresa 
ADD fechaFinContrato VARCHAR2 (50); 

ALTER TABLE Empresa 
ADD IsDelete number;

ALTER TABLE Empresa 
ADD ImageBase64 VARCHAR2 (50);

ALTER TABLE Empresa 
ADD Correo VARCHAR2 (50);

ALTER TABLE Empresa 
ADD IdDireccion number;

INSERT INTO EMPRESA (id_empresa, nom_empresa,Rut,DvRut,fechaCreacion,fechaFinContrato,IsDelete,ImageBase64,Correo,IdDireccion) VALUES (1, 'Codelco','11111111','k','01-01-2023','01-01-2025',0,null,'Codelco@gmail.com',1);
INSERT INTO EMPRESA (id_empresa, nom_empresa,Rut,DvRut,fechaCreacion,fechaFinContrato,IsDelete,ImageBase64,Correo,IdDireccion) VALUES (2, 'BCI','22222222','k','02-02-2023','01/03-2026',0,null,'Bci@gmail.com',2);
INSERT INTO EMPRESA (id_empresa, nom_empresa,Rut,DvRut,fechaCreacion,fechaFinContrato,IsDelete,ImageBase64,Correo,IdDireccion) VALUES (3, 'Sonda','33333333','k','03-03-2023','01-02-2024',0,null,'Sonda@gmail.com',3);
INSERT INTO EMPRESA (id_empresa, nom_empresa,Rut,DvRut,fechaCreacion,fechaFinContrato,IsDelete,ImageBase64,Correo,IdDireccion) VALUES (4, 'Todos','44444444','k','04-04-2023','01-04-2024',0,null,'NoMasAccidentes@gmail.com',4);
