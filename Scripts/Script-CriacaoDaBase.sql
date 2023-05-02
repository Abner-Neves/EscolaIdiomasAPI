CREATE DATABASE dbEscola

USE dbEscola

CREATE TABLE Turmas
(
	id int identity primary key,
	Numero int not null,
	AnoLetivo int not null
)

CREATE TABLE Alunos
(
	id int identity primary key,
	Nome varchar(255) not null,
	Cpf varchar(255) not null,
	email varchar(255) not null
)
CREATE TABLE AlunosTurmas
(
	id int identity primary key,
	AlunoId int not null,
	TurmaId int not null

	constraint Fk_AlunosTurmas_Alunos_AlunoId Foreign key (AlunoId) References Alunos(Id),
	constraint Fk_AlunosTurmas_Turma_TurmaId Foreign key (TurmaId) References Turmas(Id)
)
