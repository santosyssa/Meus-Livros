create database Livros;

use Livros;

------DDL------

create table genero(
	idGenero int primary key identity not null,
	nome varchar(500) unique not null
				  );

create table autor(
	idAutor int primary key identity not null,
	nome varchar(500) not null
				  );

create table editora(
	idEditora int primary key identity not null,
	nome varchar(500) not null
				  );

create table livro(
	idLivro int primary key identity not null,
	nome varchar(700) unique not null,
	data_Publi date,
	capa text not null,
	IdGenero int foreign key references genero (idGenero),
	IdAutor int foreign key references autor (idAutor),
	IdEditora int foreign key references editora (idEditora)
				  );

create table favorito(
	idFav int primary key identity not null,
	IdEditora int foreign key references editora  (idEditora),
				 	);


------DML------

insert into genero
	values ('ficcao'),
		   ('romance'),
		   ('fantasia');


insert into autor
	values ('Carolina Munhóz'),
		   ('Jay Asher'), 
		   ('Kiera Cass');


insert into editora 
	values ('Seguinte'),
	       ('Ática'),
		   ('Fantástica Rocco');

insert into livro (nome,data_Publi,capa,IdGenero,IdAutor,IdEditora) 
	values ('Os 13 Porques', '18/10/2007', 'sklskaksa', 1, 2, 2);

insert into favorito (IdEditora)
	values (4);

------DQL------

select* from genero order by idGenero asc;

select* from autor;

select nome from autor;

select* from editora;

select* from livro;

select* from favorito;

SELECT l.idLivro, l.nome, l.data_Publi, l.capa, g.nome, a.nome, e.nome
FROM livro AS l 
INNER JOIN genero AS g ON l.idGenero = g.IdGenero
INNER JOIN autor AS a ON l.idAutor = a.IdAutor
INNER JOIN editora AS e ON l.idEditora = e.IdEditora;

