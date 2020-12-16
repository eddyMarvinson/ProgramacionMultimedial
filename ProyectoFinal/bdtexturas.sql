CREATE DATABASE bdtexturas;

create table color(
	name varchar(40) NOT NULL,
	red int NOT NULL,
	green int NOT NULL,
	blue int NOT NULL,
);

insert into color (name, red, green, blue) values ('Agua',0,0,0);
insert into color (name, red, green, blue) values ('Agua',0,0,128);
insert into color (name, red, green, blue) values ('Agua',0,0,139);
insert into color (name, red, green, blue) values ('Agua',0,0,205);
insert into color (name, red, green, blue) values ('Agua',0,0,255);

insert into color (name, red, green, blue) values ('Bosque',0,100,0);
insert into color (name, red, green, blue) values ('Bosque',0,128,0);
insert into color (name, red, green, blue) values ('Bosque',0,128,128);
insert into color (name, red, green, blue) values ('Bosque',0,139,139);

insert into color (name, red, green, blue) values ('Incendio',255,99,71);
insert into color (name, red, green, blue) values ('Incendio',255,127,80);
insert into color (name, red, green, blue) values ('Incendio',255,140,0);
insert into color (name, red, green, blue) values ('Incendio',255,160,122);
insert into color (name, red, green, blue) values ('Incendio',255,165,0);

insert into color (name, red, green, blue) values ('Nevado',255,240,245);
insert into color (name, red, green, blue) values ('Nevado',255,245,238);
insert into color (name, red, green, blue) values ('Nevado',255,248,220);
insert into color (name, red, green, blue) values ('Nevado',255,250,205);
insert into color (name, red, green, blue) values ('Nevado',255,250,240);
insert into color (name, red, green, blue) values ('Nevado',255,250,250);

insert into color (name, red, green, blue) values ('Tierra',205,92,92);
insert into color (name, red, green, blue) values ('Tierra',205,133,63);
insert into color (name, red, green, blue) values ('Tierra',210,105,30);
insert into color (name, red, green, blue) values ('Tierra',210,180,140);

--delete from color where name = 'Agua';