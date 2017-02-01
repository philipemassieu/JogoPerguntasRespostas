create database db_PerguntasERespostas

use db_PerguntasERespostas

create table tb_Jogador(
	id int identity primary key,
	nome varchar(100) not null
)

select * from tb_Jogador

insert into tb_Jogador(nome) values('Amanda')
insert into tb_Jogador(nome) values('Fernanda')

create table tb_Perguntas(
   id int identity primary key,
   pergunta	varchar(max),
   resposta_correta varchar(max),
   data	datetime default getdate()
   )
   
   select * from tb_Perguntas
   
   insert into tb_Perguntas(pergunta, resposta_correta)
   values('Quanto é 2 + 2?','4')
   
   
    
   
   select * from tb_Jogador
   
   delete from tb_jogador where id = 13
   
   insert into tb_Jogador(nome) values('ramón')
   
   delete from tb_jogador
   
   --limpa os dados da tabela e reinicia o campo identity
   truncate table tb_jogador