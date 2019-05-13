USE DESAFIO_PLUFT;

INSERT INTO LOGRADOUROS
VALUES	('Rua Ficticia, n 10','01234567','Centro','São Paulo','São Paulo')
		,('Rua Ficticia, n 5','01234567','Centro','São Paulo','São Paulo');

INSERT INTO AREAS_ATIVIDADE
VALUES	('Saúde e Beleza')
		,('Alimentação')
		,('Lazer');

INSERT INTO CAPACIDADES
VALUES	('Quantidade de mesas livres','10')
		,('Capacidade de pessoas na sala de espera do salão','15')
		,('Capacidade de pessoas no local da festa','100');

INSERT INTO STATUS_AGENDAMENTO
VALUES	('Agendado')
		,('Cancelado')
		,('Realizado');

INSERT INTO VALORES
VALUES	('35,00')
		,('50,00')
		,('60,00');

INSERT INTO SERVICOS
VALUES	('Reserva de mesas','Reserva para comemoração de aniversário',2,1)
		,('Corte de cabelo','Corte, escova e hidratação',3,2)
		,('Festa','Aluguel de local para festa de aniversário',1,3);

INSERT INTO INSTITUICOES
VALUES	('Ristorant La Francois','Griezman Ltda','00012345678900','1139201234',2,1)
		,('Saloom´s','Vovó Mafalda Ltda','12345678900123','1138265412',1,2)
		,('Holding Eventos','E-corp ltda','00012345123666','1166612345',3,1);

INSERT INTO TIPO_USUARIOS
VALUES	('Administrador')
		,('Lojista')
		,('Cliente');

INSERT INTO USUARIOS
VALUES	('Admin','1111111111','11111111111','admin@admin.com','admin','1111111111',1,1)
		,('Usuario X','2222222222','22222222222','usuariox@email.com','222222','11922222222',3,2);

INSERT INTO LOJISTAS
VALUES	('José Carlos','0000000000','00000000000','zecarlos@lafrancois.com','012345','11900000000',2,1,2)
		,('Mafalda Lima','3333333333','33333333333','mafalda@salooms.com','012345','11933333333',2,2,1)
		,('Tyrel Wellick','4444444444','44444444444','tyrelbolado@holding.com','012345','11944444444',2,3,2);

INSERT INTO AGENDAMENTOS
VALUES	('15/05/2019','12:00',2,1,1,1)
		,('20/05/2019','14:00',2,2,2,1)
		,('23/05/2019','16:00',2,3,3,1);


