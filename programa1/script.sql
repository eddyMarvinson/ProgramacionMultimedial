CREATE DATABASE academico;
USE academico;

CREATE TABLE IDENTIFICADOR
(
	ci int PRIMARY KEY,
	nombreCompleto varchar(40),
	fechaNacimiento datetime,
	lugarResidencia varchar(2)
);

CREATE TABLE USUARIO
(
	ci int,
	clave varchar(40),
    FOREIGN KEY (ci) REFERENCES IDENTIFICADOR(ci)
);

CREATE TABLE MATERIA
(
	id_mat int PRIMARY KEY,
	nom_materia varchar(40)
);


CREATE TABLE NOTA
(
	ci int,
	id_mat int,
	nota int,
	FOREIGN KEY (ci) REFERENCES IDENTIFICADOR(ci),
	FOREIGN KEY (id_mat) REFERENCES MATERIA(id_mat)
);

-- CREA CUENTA DE USUARIO PARA MANIPULAR LAS BASES DE DATOS
-- user: adminAcademico pass: 123456
-- GRANT SELECT, INSERT, UPDATE, DELETE, CREATE, DROP, RELOAD, SHUTDOWN, PROCESS, FILE, REFERENCES, INDEX, ALTER, SHOW DATABASES, SUPER, CREATE TEMPORARY TABLES, LOCK TABLES, EXECUTE, REPLICATION SLAVE, REPLICATION CLIENT, CREATE VIEW, SHOW VIEW, CREATE ROUTINE, ALTER ROUTINE, CREATE USER, EVENT, TRIGGER, CREATE TABLESPACE, CREATE ROLE, DROP ROLE ON *.* TO `adminAcademico`@`localhost` WITH GRANT OPTION;
-- GRANT APPLICATION_PASSWORD_ADMIN,AUDIT_ADMIN,BACKUP_ADMIN,BINLOG_ADMIN,BINLOG_ENCRYPTION_ADMIN,CLONE_ADMIN,CONNECTION_ADMIN,ENCRYPTION_KEY_ADMIN,GROUP_REPLICATION_ADMIN,INNODB_REDO_LOG_ARCHIVE,PERSIST_RO_VARIABLES_ADMIN,REPLICATION_APPLIER,REPLICATION_SLAVE_ADMIN,RESOURCE_GROUP_ADMIN,RESOURCE_GROUP_USER,ROLE_ADMIN,SERVICE_CONNECTION_ADMIN,SESSION_VARIABLES_ADMIN,SET_USER_ID,SYSTEM_USER,SYSTEM_VARIABLES_ADMIN,TABLE_ENCRYPTION_ADMIN,XA_RECOVER_ADMIN ON *.* TO `adminAcademico`@`localhost` WITH GRANT OPTION;

insert into IDENTIFICADOR(ci, nombreCompleto, fechaNacimiento, lugarResidencia) values(1000, 'Juan Perez', '1999-11-11', '01');
insert into IDENTIFICADOR(ci, nombreCompleto, fechaNacimiento, lugarResidencia) values(1001, 'Marco Apaza', '2000-10-21', '01');
insert into IDENTIFICADOR(ci, nombreCompleto, fechaNacimiento, lugarResidencia) values(1002, 'Carlos Lazarte', '2001-05-26', '02');
insert into IDENTIFICADOR(ci, nombreCompleto, fechaNacimiento, lugarResidencia) values(1003, 'Fernando Revollo', '1998-07-15', '03');
insert into IDENTIFICADOR(ci, nombreCompleto, fechaNacimiento, lugarResidencia) values(1004, 'Juana Poma', '1996-04-07', '04');

insert into USUARIO(ci, clave) values(1000, '1234');
insert into USUARIO(ci, clave) values(1001, '1234');
insert into USUARIO(ci, clave) values(1002, '1234');
insert into USUARIO(ci, clave) values(1003, '1234');
insert into USUARIO(ci, clave) values(1004, '1234');

insert into MATERIA(id_mat, nom_materia) values(1, 'INF-111');
insert into MATERIA(id_mat, nom_materia) values(2, 'INF-121');
insert into MATERIA(id_mat, nom_materia) values(3, 'INF-131');
insert into MATERIA(id_mat, nom_materia) values(4, 'INF-143');
insert into MATERIA(id_mat, nom_materia) values(5, 'LAB-111');
insert into MATERIA(id_mat, nom_materia) values(6, 'LAB-121');
insert into MATERIA(id_mat, nom_materia) values(7, 'LAB-131');

insert into NOTA(ci, id_mat, nota) values(1000, 1, 51);
insert into NOTA(ci, id_mat, nota) values(1000, 5, 60);
insert into NOTA(ci, id_mat, nota) values(1001, 2, 80);
insert into NOTA(ci, id_mat, nota) values(1001, 6, 40);
insert into NOTA(ci, id_mat, nota) values(1002, 3, 80);
insert into NOTA(ci, id_mat, nota) values(1003, 4, 80);
insert into NOTA(ci, id_mat, nota) values(1004, 7, 80);
insert into NOTA(ci, id_mat, nota) values(1000, 2, 51);
insert into NOTA(ci, id_mat, nota) values(1000, 3, 51);
insert into NOTA(ci, id_mat, nota) values(1000, 4, 51);
insert into NOTA(ci, id_mat, nota) values(1004, 1, 10);
insert into NOTA(ci, id_mat, nota) values(1004, 2, 10);
insert into NOTA(ci, id_mat, nota) values(1004, 3, 10);
insert into NOTA(ci, id_mat, nota) values(1004, 4, 10);
insert into NOTA(ci, id_mat, nota) values(1004, 5, 10);
insert into NOTA(ci, id_mat, nota) values(1004, 6, 10);
insert into NOTA(ci, id_mat, nota) values(1001, 1, 55);
insert into NOTA(ci, id_mat, nota) values(1001, 7, 55);


-- MOSTRAR APROBADOS y REPROBADOS POR DEPARTAMENTO ESPECIFICANDO MATERIA
SELECT case i.lugarResidencia
			when '01' then 'CHUQUISACA'
			when '02' then 'LA PAZ' 
			when '03' then 'COCHABAMBA' 
			when '04' then 'ORURO' 
			when '05' then 'POTOSI' 
			when '06' then 'TARIJA' 
			when '07' then 'SANTA CRUZ' 
			when '08' then 'BENI' 
			when '09' then 'PANDO' 
			else 'OTRO' end as departamento,
sum(n.nota >= 51) as aprobado,
sum(n.nota < 51) as reprobado
FROM identificador i, nota n, materia m 
WHERE i.ci = n.ci and n.id_mat = m.id_mat and m.id_mat = 2
GROUP BY lugarResidencia

-- MOSTRAR APROBADOS POR DEPARTAMENTO (MUESTRA MATERIA)
SELECT m.nom_materia,
sum(n.nota >= 51 and i.lugarResidencia = '01') as CH,
sum(n.nota >= 51 and i.lugarResidencia = '02') as LP,
sum(n.nota >= 51 and i.lugarResidencia = '03') as CB,
sum(n.nota >= 51 and i.lugarResidencia = '04') as ORU,
sum(n.nota >= 51 and i.lugarResidencia = '05') as PT,
sum(n.nota >= 51 and i.lugarResidencia = '06') as TJ,
sum(n.nota >= 51 and i.lugarResidencia = '07') as SC,
sum(n.nota >= 51 and i.lugarResidencia = '08') as BE,
sum(n.nota >= 51 and i.lugarResidencia = '09') as PD,
sum(n.nota >= 51) as TOTAL
FROM identificador i, nota n, materia m 
WHERE i.ci = n.ci and n.id_mat = m.id_mat
GROUP BY M.nom_materia


-- MOSTRAR FILA UNICA DE APROBADO POR DEPARTAMENTO
SELECT
sum(n.nota >= 51 and i.lugarResidencia = '01') as CH,
sum(n.nota >= 51 and i.lugarResidencia = '02') as LP,
sum(n.nota >= 51 and i.lugarResidencia = '03') as CB,
sum(n.nota >= 51 and i.lugarResidencia = '04') as ORU,
sum(n.nota >= 51 and i.lugarResidencia = '05') as PT,
sum(n.nota >= 51 and i.lugarResidencia = '06') as TJ,
sum(n.nota >= 51 and i.lugarResidencia = '07') as SC,
sum(n.nota >= 51 and i.lugarResidencia = '08') as BE,
sum(n.nota >= 51 and i.lugarResidencia = '09') as PD,
sum(n.nota >= 51) as TOTAL
FROM identificador i, nota n, materia m 
WHERE i.ci = n.ci and n.id_mat = m.id_mat