CREATE TABLE person (
	id bigint IDENTITY(1,1) NOT NULL,
	firstName varchar(50) NOT NULL,
	secondName varchar(50) NOT NULL,
	age int NOT NULL,
	cpf varchar(11) NOT NULL,
	gender char(1) NOT NULL
	CONSTRAINT PK_person PRIMARY KEY (id)
)