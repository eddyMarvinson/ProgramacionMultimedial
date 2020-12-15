-- dbcolors
CREATE DATABASE dbcolors;

create table colorRGB(
	name varchar(40) NOT NULL,
	hex varchar(6) PRIMARY KEY NOT NULL,
	red int NOT NULL,
	green int NOT NULL,
	blue int NOT NULL,
	tipo int NOT NULL
);

# clasificador para 5 tipos de objetos
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Black','000000',0,0,0,1);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Navy','80',0,0,128,1);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkBlue','00008B',0,0,139,1);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumBlue','0000CD',0,0,205,1);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Blue','0000FF',0,0,255,1);

insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkGreen','6400',0,100,0,2);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Green','808080',0,128,0,2);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Teal','8080',0,128,128,2);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkCyan','008B8B',0,139,139,2);

insert into colorRGB (name, hex, red, green, blue, tipo) values ('Tomato','FF6347',255,99,71,3);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Coral','FF7F50',255,127,80,3);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkOrange','FF8C00',255,140,0,3);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightSalmon','FFA07A',255,160,122,3);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Orange','FFA500',255,165,0,3);

insert into colorRGB (name, hex, red, green, blue, tipo) values ('LavenderBlush','FFF0F5',255,240,245,4);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Seashell','FFF5EE',255,245,238,4);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Cornsilk','FFF8DC',255,248,220,4);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('LemonChiffon','FFFACD',255,250,205,4);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('FloralWhite','FFFAF0',255,250,240,4);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Snow','FFFAFA',255,250,250,4);

insert into colorRGB (name, hex, red, green, blue, tipo) values ('IndianRed','FF69B4',205,92,92,5);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Peru','CD853F',205,133,63,5);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Chocolate','D2691E',210,105,30,5);
insert into colorRGB (name, hex, red, green, blue, tipo) values ('Tan','D2B48C',210,180,140,5);

--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DeepSkyBlue','00BFFF',0,191,255,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkTurquoise','00CED1',0,206,209,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumSpringGreen','00FA9A',0,250,154,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('SpringGreen','00FF7F',0,255,127,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Aqua','00FFFF',0,255,255,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MidnightBlue','191970',25,25,112,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DodgerBlue','1E90FF',30,144,255,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Turquoise','40E0D0',64,224,208,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('RoyalBlue','41690',65,105,225,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('SteelBlue','4682B4',70,130,180,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumTurquoise','48D1CC',72,209,204,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('CornflowerBlue','6495ED',100,149,237,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumAquamarine','66CDAA',102,205,170,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('SkyBlue','87CEEB',135,206,235,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightSkyBlue','20B2AA',135,206,250,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightBlue','ADD8E6',173,216,230,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('PaleTurquoise','AFEEEE',175,238,238,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightSteelBlue','778899',176,196,222,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('PowderBlue','B0E0E6',176,224,230,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightCyan','E0FFFF',224,255,255,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('AliceBlue','F0F8FF',240,248,255,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('honeydew','ADFF2F',240,255,240,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Azure','F0FFFF',240,255,255,1);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightSeaGreen','FFA07A',32,178,170,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('ForestGreen','228B22',34,139,34,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('SeaGreen','2E8B57',46,139,87,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkSlateGray','2F4F4F',47,79,79,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumSeaGreen','3CB371',60,179,113,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkOliveGreen','556B2F',85,107,47,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('OliveDrab','6B8E23',107,142,35,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Olive','808000',128,128,0,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkSeaGreen','8FBC8F',143,188,143,2);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('YellowGreen','9ACD32',154,205,50,2);

--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Maroon','800000',128,0,0,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkRed','8B0000',139,0,0,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Sienna','A0522D',160,82,45,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Brown','A52A2A',165,42,42,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkGray','A9A9A9',169,169,169,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('FireBrick','B22222',178,34,34,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Goldenrod','FFD700',218,165,32,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('PalevioletRed','DB7093',219,112,147,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Crimson','DC143C',220,20,60,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Burlywood','DEB887',222,184,135,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Lightcoral','F08080',240,128,128,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('SandyBrown','F4A460',244,164,96,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Salmon','FA8072',250,128,114,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Red','FF0000',255,0,0,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('OrangeRed','FF4500',255,69,0,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightPink','FFB6C1',255,182,193,3);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Pink','FFC0CB',255,192,203,3);


--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DimGray','696969',105,105,105,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('SlateGray','708090',112,128,144,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightSlateGray','87CEFA',119,136,153,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Gray','DAA520',128,128,128,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Silver','C0C0C0',192,192,192,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Gainsboro','DCDCDC',220,220,220,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('WhiteSmoke','F5F5F5',245,245,245,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MintCream','F5FFFA',245,255,250,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('GhostWhite','F8F8FF',248,248,255,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightYellow','B0C4DE',255,255,224,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Ivory','FFFFF0',255,255,240,4);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('White','FFFFFF',255,255,255,4);

--insert into colorRGB (name, hex, red, green, blue, tipo) values ('SaddleBrown','8B4513',139,69,19,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkGoldenrod','B8860B',184,134,11,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('RosyBrown','BC8F8F',188,143,143,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkKhaki','BDB76B',189,183,107,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightGrey','D3D3D3',211,211,211,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkSalmon','E9967A',233,150,122,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('PaleGoldenrod','EEE8AA',238,232,170,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Khaki','F0E68C',240,230,140,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Wheat','F5DEB3',245,222,179,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Beige','F5F5DC',245,245,220,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('AntiqueWhite','FAEBD7',250,235,215,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Linen','32CD32',250,240,230,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightGoldenrodYellow','FAFAD2',250,250,210,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('OldLace','FDF5E6',253,245,230,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('PeachPuff','FFDAB9',255,218,185,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('NavajoWhite','FFDEAD',255,222,173,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Moccasin','FFE4B5',255,228,181,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Bisque','FFE4C4',255,228,196,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MistyRose','FFE4E1',255,228,225,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('BlanchedAlmond','FFEBCD',255,235,205,5);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('PapayaWhip','FFEFD5',255,239,213,5);

--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Black','000000',0,0,0,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Lime','FFFFE0',0,255,0,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LimeGreen','00FF00',50,205,50,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkSlateBlue','483D8B',72,61,139,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Indigo','4B0082',75,0,130,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('CadetBlue','5F9EA0',95,158,160,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('SlateBlue','6A5ACD',106,90,205,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumSlateBlue','7B68EE',123,104,238,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LawnGreen','7CFC00',124,252,0,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Aquamarine','7FFFD4',127,205,170,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Chartreuse','7FFF00',127,255,0,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Purple','800080',128,0,128,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('BlueViolet','8A2BE2',138,43,226,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkMagenta','8B008B',139,0,139,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('LightGreen','90EE90',144,238,144,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumPurple','9370DB',147,112,219,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkViolet','9400D3',148,0,211,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('PaleGreen','98FB98',152,251,152,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DarkOrchid','9932CC',153,50,204,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('GreenYellow','8000',173,255,47,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumOrchid','BA55D3',186,85,211,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('MediumvioletRed','C71585',199,21,133,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Thistle','D8BFD8',216,191,216,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Orchid','DA70D6',218,112,214,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Plum','DDA0DD',221,160,221,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Lavender','E6E6FA',230,230,250,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Violet','EE82EE',238,130,238,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Fuchsia','FF00FF',255,0,255,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Magenta','FAF0E6',255,0,255,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('DeepPink','FF1493',255,20,147,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('HotPink','F0FFF0',255,105,180,6);
--insert into colorRGB (name, hex, red, green, blue, tipo) values ('Yellow','FFFF00',255,255,0,6);
