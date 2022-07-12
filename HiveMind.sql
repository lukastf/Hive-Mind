create database HiveMind4
go

use HiveMind4
go

create table pessoas
(
	id_pessoa int not null primary key identity,
	nome varchar(50) not null,
	rg varchar(16) not null,
	cpf varchar(16) not null unique,
	telefone varchar(20) not null,
	endereco varchar(50) not null,
	email varchar(50) not null,
	usuario varchar(50) not null,
	senha varchar(50)
)
go


create table funcionarios
(
	id_pessoa int not null primary key references pessoas,
	dataAdmissao varchar(20) not null,
	dataDemissao varchar(20),
	statusAdmin bit
)
go

create table proprietarios
(
	id_pessoa int not null primary key references pessoas,
	informacao varchar(50)
)
go

create table moradores
(
	id_pessoa int not null primary key references pessoas,
	dataEntrada varchar(20),
	dataSaida varchar(20)
)
go

create table unidades
(
	id_unidade int not null primary key identity,
	id_morador int not null,
	id_proprietario int not null,
	localizacao varchar(50) not null,
	foreign key (id_morador) references pessoas (id_pessoa),
	foreign key (id_proprietario) references pessoas (id_pessoa)
)
go

create table sindicos
(
	id_pessoa int not null primary key references pessoas,
	informacao varchar(50)
)
go




create table boletos
(
	id_boleto int not null primary key identity,
	id_unidade int not null,	
	valor decimal(10,2) not null,
	dataGeracao varchar(20) not null,
	dataValidade varchar(20) not null,
	dataPagamento varchar(20),
	bancoReferente varchar(20) not null,
	foreign key (id_unidade) references unidades (id_unidade)
)
go

create table notificacoes
(
	id_notificacao int not null primary key identity,
	id_remetente int not null,
	id_destinatario int not null,
	assunto varchar(100) not null,
	conteudo varchar(1000) not null,
	dataEnvio datetime not null,
	foreign key (id_remetente) references pessoas (id_pessoa),
	foreign key (id_destinatario) references pessoas (id_pessoa)
)
go

--Procedures-----------------------------------------------------------------------------------
create procedure cadFuncionario
(
	@nome varchar(50),
	@rg varchar(16),
	@cpf varchar(16),
	@telefone varchar(20),
	@endereco varchar(50),
	@email varchar(50),
	@usuario varchar(50),
	@senha varchar(50),
	@dataAdmissao varchar(20),
	@dataDemissao varchar(20),
	@statusAdmin bit
)
as
begin
	begin transaction
	begin try
		insert into pessoas values(@nome,@rg,@cpf,@telefone,@endereco,@email,@usuario,@senha)
		insert into funcionarios values(@@IDENTITY,@dataAdmissao,@dataDemissao,@statusAdmin)
		commit
	end try
	begin catch
		rollback		
	end catch
end
go

insert into pessoas values('Admin','1234','1234','1234','aaaaabbbb','aaa@b.com','admin','admin')
insert into funcionarios values (@@IDENTITY,'1/1/1','2/2/2',1)
go

create procedure editFuncionario
(
	@id_pessoa int,
	@nome varchar(50),
	@rg varchar(16),
	@cpf varchar(16),
	@telefone varchar(20),
	@endereco varchar(50),
	@email varchar(50),
	@usuario varchar(50),
	@senha varchar(50),
	@dataAdmissao varchar(20),
	@dataDemissao varchar(20),
	@statusAdmin bit
)
as
begin
	begin transaction
		begin try
			update  pessoas set 
					nome = @nome,
					rg = @rg,
					cpf = @cpf,
					telefone = @telefone,
					endereco = @endereco,
					email = @email,
					usuario = @usuario,
					senha = @senha

			where id_pessoa = @id_pessoa
		
			update funcionarios set
					dataAdmissao = @dataAdmissao,
					dataDemissao = @dataDemissao,
					statusAdmin = @statusAdmin

			where id_pessoa = @id_pessoa
			commit
		end try
		begin catch
			rollback
		end catch
end
go
------------------------------------------------------------------------------------------------
create procedure cadProprietario
(
	@nome varchar(50),
	@rg varchar(16),
	@cpf varchar(16),
	@telefone varchar(20),
	@endereco varchar(50),
	@email varchar(50),
	@usuario varchar(50),
	@senha varchar(50),
	@informacao varchar(50)
)
as
begin
	begin transaction
	begin try
		insert into pessoas values(@nome,@rg,@cpf,@telefone,@endereco,@email,@usuario,@senha)
		insert into proprietarios values(@@IDENTITY,@informacao)
		commit
	end try
	begin catch
		rollback
	end catch
end
go

create procedure editProprietario
(
	@id_pessoa int,
	@nome varchar(50),
	@rg varchar(16),
	@cpf varchar(16),
	@telefone varchar(20),
	@endereco varchar(50),
	@email varchar(50),
	@usuario varchar(50),
	@senha varchar(50),
	@informacao varchar(50)
)
as
begin
	begin transaction
		begin try
			update pessoas set 
					nome = @nome,
					rg = @rg,
					cpf = @cpf,
					telefone = @telefone,
					endereco = @endereco,
					email = @email,
					usuario = @usuario,
					senha = @senha
			where id_pessoa = @id_pessoa

			update proprietarios set
					informacao = @informacao
			where id_pessoa = @id_pessoa

			commit
		end try
		begin catch
			rollback
		end catch
end
go
-----------------------------------------------------------------------------------------------------
--alter altera
create procedure cadMorador
(
	@nome varchar(50),
	@rg varchar(16),
	@cpf varchar(16),
	@telefone varchar(20),
	@endereco varchar(50),
	@email varchar(50),
	@usuario varchar(50),
	@senha varchar(50),
	@dataEntrada varchar(20),
	@dataSaida varchar(20)
)
as
begin
	begin transaction
	begin try
		insert into pessoas values(@nome,@rg,@cpf,@telefone,@endereco,@email,@usuario,@senha)
		insert into moradores values(@@IDENTITY,@dataEntrada,@dataSaida)
		commit
	end try
	begin catch
		rollback
	end catch
end
go

create procedure editMorador
(
	@id_pessoa int,
	@nome varchar(50),
	@rg varchar(16),
	@cpf varchar(16),
	@telefone varchar(20),
	@endereco varchar(50),
	@email varchar(50),
	@usuario varchar(50),
	@senha varchar(50),
	@dataEntrada varchar(20),
	@dataSaida varchar(20)
)
as
begin
	begin transaction
		begin try
			update pessoas set 
					nome = @nome,
					rg = @rg,
					cpf = @cpf,
					telefone = @telefone,
					endereco = @endereco,
					email = @email,
					usuario = @usuario,
					senha = @senha

			where id_pessoa = @id_pessoa
		
			update moradores set
					dataEntrada = @dataEntrada,
					dataSaida = @dataSaida

			where id_pessoa = @id_pessoa
			commit
		end try
		begin catch
			rollback
		end catch
end
go
------------------------------------------------------------------------------------------------------
create procedure cadSindico
(
	@nome varchar(50),
	@rg varchar(16),
	@cpf varchar(16),
	@telefone varchar(20),
	@endereco varchar(50),
	@email varchar(50),
	@usuario varchar(50),
	@senha varchar(50),
	@informacao varchar(50)
)
as
begin
	begin transaction
	begin try
		insert into pessoas values(@nome,@rg,@cpf,@telefone,@endereco,@email,@usuario,@senha)
		insert into sindicos values(@@IDENTITY,@informacao)
		commit
	end try
	begin catch
		rollback
	end catch
end
go

create procedure editSindico
(
	@id_pessoa int,
	@nome varchar(50),
	@rg varchar(16),
	@cpf varchar(16),
	@telefone varchar(20),
	@endereco varchar(50),
	@email varchar(50),
	@usuario varchar(50),
	@senha varchar(50),
	@informacao varchar(50)
)
as
begin
	begin transaction
		begin try
			update pessoas set 
					nome = @nome,
					rg = @rg,
					cpf = @cpf,
					telefone = @telefone,
					endereco = @endereco,
					email = @email,
					usuario = @usuario,
					senha = @senha

			where id_pessoa = @id_pessoa
		
			update sindicos set
					informacao = @informacao
			where id_pessoa = @id_pessoa
			commit
		end try
		begin catch
			rollback
		end catch
end
go
--------------------------------------------------------------------------------------------------------
create procedure addUnidade
(
	@id_morador int,
	@id_proprietario int,
	@localizacao varchar(50)
)
as
begin
	begin transaction
	begin try
		insert into unidades values (@id_morador,@id_proprietario,@localizacao)
		commit
	end try
	begin catch
		rollback
	end catch
end
go
select * from unidades
go
create procedure editUnidade
(
	@id_unidade int,
	@id_morador int,
	@id_proprietario int,
	@localizacao varchar(50)
)
as
begin
	begin transaction
		begin try
			update unidades set
	
					id_morador = @id_morador,
					id_proprietario = @id_proprietario,
					localizacao = @localizacao

			where id_unidade = @id_unidade
			commit
		end try
		begin catch
			rollback
		end catch
end
go

--------------------------------------------------------------------------------------------------------
create procedure addBoleto
(
	@id_unidade int,
	@valor decimal(10,2),
	@dataGeracao varchar(20),
	@dataValidade varchar(20),
	@dataPagamento varchar(20),
	@bancoReferente varchar(20)
)
as
begin
	begin transaction
	begin try
		insert into boletos values(@id_unidade, @valor,@dataGeracao,@dataValidade,@dataPagamento,@bancoReferente)
		commit
	end try
	begin catch
		rollback
	end catch
end
go

create procedure editBoleto
(
	@id_boleto int,
	@id_unidade int,
	@valor decimal(10,2),
	@dataGeracao varchar(20),
	@dataValidade varchar(20),
	@dataPagamento varchar(20),
	@bancoReferente varchar(20)
	
)
as
begin
	begin transaction
		begin try
			update boletos set 
				     id_unidade = @id_unidade,
					 valor = @valor,
					 dataGeracao = @dataGeracao,
					 dataValidade = @dataValidade,
					 dataPagamento = @dataPagamento,
					 bancoReferente = @bancoReferente

			where id_boleto = @id_boleto
			commit
		end try
		begin catch
			rollback
		end catch
end
go
--------------------------------------------------------------------------------------------------------------
create procedure addNotificacao
(
	@assunto varchar(100),
	@conteudo varchar(1000),
	@id_remetente int,
	@id_destinatario int
)
as
begin
	begin transaction
	begin try
		insert into notificacoes values(@id_remetente, @id_destinatario,@assunto,@conteudo,GETDATE())
		commit
	end try
	begin catch
		rollback
	end catch
end
go

--Views--------------------------------------------------------------------------------------------------------------------------

create view v_funcionarios
as
	select p.*, f.dataAdmissao, f.dataDemissao, f.statusAdmin
	from pessoas p, funcionarios f 
	where p.id_pessoa = f.id_pessoa
go

select * from v_funcionarios
go

create view v_proprietarios
as
	select p.*, pro.informacao
	from pessoas p, proprietarios pro
	where p.id_pessoa = pro.id_pessoa
go

select * from v_proprietarios
go

create view v_moradores
as
	select p.*, m.dataEntrada, m.dataSaida
	from pessoas p, moradores m
	where p.id_pessoa = m.id_pessoa
go

select * from v_moradores
go

create view v_sindicos
as
	select p.*, s.informacao
	from pessoas p, sindicos s
	where p.id_pessoa = s.id_pessoa
go

select * from v_sindicos
go

create view v_unidades
as
	select u.*
	from unidades u
go

select * from v_unidades
go

create view v_boletos
as
	select u.localizacao, b.*
	from boletos b, unidades u
go

select * from v_boletos
go

create view v_notificacoes
as
	select n.*
	from notificacoes n
go

select * from v_notificacoes
go

select nome from pessoas p, moradores m
where p.id_pessoa = m.id_pessoa
