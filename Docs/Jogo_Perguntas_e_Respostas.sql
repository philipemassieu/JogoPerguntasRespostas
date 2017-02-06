create database db_PerguntasERespostas

use db_PerguntasERespostas

create table tb_Jogador(
	id int identity primary key,
	nome varchar(100) not null
)

select * from tb_jogador

insert into tb_Jogador(nome) values('Amanda')
insert into tb_Jogador(nome) values('Fernanda')



create table tb_Perguntas(
   id int identity primary key,
   pergunta	varchar(max),
   resposta_correta varchar(max),
   id_jogador int,
   data	datetime default getdate()
   )
   
   
  Alter Table tb_Perguntas Add tb_Jogador Int
   
   select * from tb_Perguntas
   
   insert into tb_Perguntas(pergunta, resposta_correta)
   values('Quanto é 2 + 2?','4')
   
   
   
   select * from tb_jogador join tb_Perguntas on tb_Jogador.id = tb_Perguntas.tb_jogador
      
      
    --retorna o ultimo valor identity inserido  
    select @@IDENTITY
    select @@SERVERNAME
    
   
   --deleta um id especifico na tabela--
   delete from tb_jogador where id > 4
   
   --insere um novo id na tabela--
   insert into tb_Jogador(nome) values('ramón')
   
   --deleta dados da tabela--
   delete from tb_jogador
   
   --limpa os dados da tabela e reinicia o campo identity
   truncate table tb_jogador

    
