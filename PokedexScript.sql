create database Pokedex;
use Pokedex;
CREATE TABLE Tipos(
Id int not null primary key auto_increment,
Nombre varchar(100) not null
);
create table Entrenadores
(
Id int not null primary key auto_increment,
Nombre varchar(100) not null,
Edad tinyint not null,
Sexo char(1) not null
);
create table Pokemones
(
Id int not null primary key auto_increment,
Nombre varchar(100) not null,
Peso float not null,
Numero int not null,
Habilidad varchar(100) not null,
Descripcion text,
TipoId int not null,
EntrenadorId int not null,
constraint fk_Pokemones_Tipos foreign key(TipoId) references Tipos(Id) on delete cascade on update cascade,
constraint fk_Pokemones_Entrenadores foreign key(EntrenadorId) references Entrenadores(Id) on delete cascade on update cascade
);
CREATE TABLE AccionesEntrenadores
(
Id int not null primary key auto_increment,
Observacion varchar(100),
Usuario varchar(100),
Fecha datetime default Now()
);
-- SET FOREIGN_KEY_CHECKS = 0; 
-- TRUNCATE table entrenadores; 
-- SET FOREIGN_KEY_CHECKS = 1;
-- truncate table Pokemones;
-- truncate table accionesentrenadores;

insert into Entrenadores(Nombre,Edad,Sexo) values('Juan',10,'M'),('Lucia',15,'F'),('Alicia',20,'F'),('Edgar',50,'M'),('Jorge',25,'M'),('Pepe',25,'M')
,('Blanca',18,'F'),('Elizabeth',15,'F'),('Alberto',30,'M'),('Julian',45,'M'),('Daniel',17,'M')
,('Fernanda',13,'F'),('Ana',22,'F'),('Manuel',25,'M'),('Andres',45,'M');

insert into Tipos(Nombre)  values('Volador'),('Veneno'),('Tierra'),('Siniestro'),('Roca'),('Psíquico'),('Planta'),
('Normal'),('Lucha'),('Hielo'),('Hada'),('Fuego'),('Fantasma'),('Eléctrico'),('Dragón'),('Bicho'),('Agua'),('Acero');

insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Bulbasaur',6.9,1,'Esporas','Este Pokémon nace con una semilla en el lomo, que brota con el paso del tiempo.',7,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Ivysaur',13,2,'Esporas','Cuando le crece bastante el bulbo del lomo, pierde la capacidad de erguirse sobre las patas traseras.',7,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Venusaur',16,3,'Esporas','La planta florece cuando absorbe energía solar, lo cual le obliga a buscar siempre la luz del sol.',7,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Charmander',6.8,4,'Mar llamas','Prefiere las cosas calientes. Dicen que cuando llueve le sale vapor de la punta de la cola.',12,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Charizard ',10.5,6,'Mar llamas','Escupe un fuego tan caliente que funde las rocas. Causa incendios forestales sin querer.',12,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Blastoise',100.5,9,'Torrente','Para acabar con su enemigo, lo aplasta con el peso de su cuerpo. En momentos de apuro, se esconde en el caparazón.',17,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Caterpie',2.4,10,'Polvo escudo','Para protegerse, despide un hedor horrible por las antenas con el que repele a sus enemigos.',16,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Caterpie',2.4,10,'Polvo escudo','Para protegerse, despide un hedor horrible por las antenas con el que repele a sus enemigos.',16,2);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Pidgeot',24,18,'Vista lince','Este Pokémon vuela a una velocidad de 2 mach en busca de presas. Sus grandes garras son armas muy peligrosas.',1,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Arbok',65,24,'Mudar','Se han llegado a identificar hasta seis variaciones distintas de los espeluznantes dibujos de su piel.',2,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Pikachu',5,25,'Estatica','Cuando se enfada, este Pokémon descarga la energía que almacena en el interior de las bolsas de las mejillas.',14,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Raichu',35,26,'Estatica','Su cola actúa como toma de tierra y descarga electricidad al suelo, lo que le protege de los calambrazos.',14,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Nidoqueen',105,31,'Cola venenosa','Su defensa destaca sobre la capacidad ofensiva. Usa las escamas del cuerpo como una coraza para proteger a su prole de cualquier ataque.',2,1);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Nidoking',65,34,'Punto tóxico','Una vez que se desboca, no hay quien lo pare. Solo se calma ante Nidoqueen, su compañera de toda la vida.',2,5);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Persian',30,54,'Experto','Aunque es muy admirado por el pelaje, es difícil de entrenar como mascota porque enseguida suelta arañazos.',8,8);
insert into Pokemones(Nombre,Peso,Numero,Habilidad,Descripcion,TipoId,EntrenadorId) values('Arcanine',50,59,'Intimidación','Cuenta un antiguo pergamino que la gente se quedaba fascinada al verlo correr por las praderas.',12,10);

-- drop procedure spAgregarEntrenador;
DELIMITER $$
CREATE PROCEDURE spAgregarEntrenador(NombreP varchar(100), EdadP tinyint, SexoP char(1))
BEGIN
	insert into Entrenadores(Nombre,Edad,Sexo) values(NombreP,EdadP,SexoP);
	insert into AccionesEntrenadores(Observacion,Usuario) values(concat('Se inserto el entrenador: ', NombreP), current_user());
END;
$$
-- CALL spAgregarEntrenador('Gohan',23,'M');

-- drop procedure spEliminarEntrenador;
DELIMITER $$
CREATE PROCEDURE spEliminarEntrenador(idp int, NombreP varchar(100) )
BEGIN
	SET @existe = (select Count(*) from entrenadores where id = idp);
    IF(@existe = 1) THEN
    BEGIN
		delete from entrenadores where id = idp;
		insert into AccionesEntrenadores(Observacion,Usuario) values(concat('Se elimino el entrenador: ', NombreP), current_user());
	END;
  END IF;
END;
$$
-- CALL spEliminarEntrenador(10,(SELECT nombre from entrenadores where id = 10));
-- SELECT * FROM AccionesEntrenadores;