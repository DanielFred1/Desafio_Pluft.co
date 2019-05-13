USE DESAFIO_PLUFT;

--Retorna dados do usuario, o tipo de usuario do mesmo e seu endere�o
SELECT U.NOME AS NOME_USUARIO, U.RG, U.CPF, U.EMAIL, U.SENHA, U.TELEFONE, T.NOME AS TIPO_USUARIO, L.RUA, L.CEP, L.BAIRRO, L.MUNICIPIO,
L.ESTADO FROM USUARIOS U
INNER JOIN TIPO_USUARIOS T ON U.ID_TIPO_USUARIO = T.ID
INNER JOIN LOGRADOUROS L ON U.ID_LOGRADOURO = L.ID

--Retorna dados do lojista, o tipo de usuario do mesmo, seu endere�o e as institui��es atreladas ao seu cadastro
SELECT L.NOME, L.RG, L.CPF, L.EMAIL, L.SENHA, L.TELEFONE, T.NOME AS USUARIO, E.RUA, E.CEP, E.BAIRRO, E.MUNICIPIO, E.ESTADO,
I.NOME_FANTASIA AS EMPREENDIMENTO, I.RAZAO_SOCIAL, I.CNPJ, I.TELEFONE FROM LOJISTAS L
INNER JOIN TIPO_USUARIOS T ON L.ID_TIPO_USUARIO = T.ID
INNER JOIN LOGRADOUROS E ON L.ID_LOGRADOURO = E.ID
INNER JOIN INSTITUICOES I ON L.ID_INSTITUICAO = I.ID

--Retorna dados do endere�o cadastrado no sistema, os usuarios e institui��es atrelados ao endere�o
SELECT L.RUA, L.CEP, L.BAIRRO, L.MUNICIPIO, L.ESTADO, U.NOME AS USUARIO, U.TELEFONE, I.NOME_FANTASIA AS EMPREENDIMENTO,
I.TELEFONE FROM LOGRADOUROS L
INNER JOIN USUARIOS U ON L.ID = U.ID_LOGRADOURO
INNER JOIN INSTITUICOES I ON L.ID = I.ID_LOGRADOURO

--Retorna dados da institui��o cadastrada no sistema, Lojistas, endere�o e area de atividade atrelados a mesma
SELECT I.NOME_FANTASIA AS EMPREENDIMENTO, I.RAZAO_SOCIAL, I.CNPJ, A.NOME AS AREA, I.TELEFONE,
L.NOME AS EMPREENDEDOR, L.EMAIL, L.TELEFONE AS TELEFONE_EMPREENDEDOR, E.RUA, E.CEP, E.BAIRRO, E.MUNICIPIO,
E.ESTADO FROM INSTITUICOES I
INNER JOIN LOJISTAS L ON I.ID = L.ID_INSTITUICAO
INNER JOIN LOGRADOUROS E ON I.ID_LOGRADOURO = E.ID
INNER JOIN AREAS_ATIVIDADE A ON I.ID_AREAS_ATIVIDADE = A.ID

--Retorna os servi�os cadastrados, os dados de agendamento, valores e capacidade de servi�o
SELECT S.NOME_SERVICO AS SERVICO, S.DESCRICAO, V.VALOR, C.DESCRICAO AS CAPACIDADE_SERVICO, C.QUANTIDADE,
A.DATA_AGENDAMENTO AS DIA, A.HORA_AGENDAMENTO AS HORARIO  FROM SERVICOS S
INNER JOIN AGENDAMENTOS A ON S.ID = A.ID_SERVICO
INNER JOIN VALORES V ON S.ID_VALORES = V.ID
INNER JOIN CAPACIDADES C ON S.ID_CAPACIDADES = C.ID

--Retorna os Agendamentos realizados, com dados dos clientes e das empresas
SELECT S.NOME_SERVICO, S.DESCRICAO, I.NOME_FANTASIA AS EMPREENDIMENTO, I.TELEFONE AS TELEFONE_EMPRESA, A.DATA_AGENDAMENTO AS DIA,
A.HORA_AGENDAMENTO AS HORARIO, U.NOME AS CLIENTE, U.TELEFONE AS TELEFONE_CLIENTE, C.NOME AS SITUACAO FROM AGENDAMENTOS A
INNER JOIN USUARIOS U ON A.ID_USUARIO = U.ID
INNER JOIN INSTITUICOES I ON A.ID_INSITUICAO = I.ID
INNER JOIN STATUS_AGENDAMENTO C ON A.ID_STATUS = C.ID
INNER JOIN SERVICOS S ON A.ID_SERVICO = S.ID

--Retorna as areas de atividade das empresas cadastradas
SELECT A.NOME AS AREA_ATIVIDADE, I.NOME_FANTASIA AS EMPREENDIMENTO, I.CNPJ, I.TELEFONE FROM AREAS_ATIVIDADE A
INNER JOIN INSTITUICOES I ON A.ID = I.ID_AREAS_ATIVIDADE

--Retorna os servi�os e seu gerenciamento de estrutura
SELECT S.NOME_SERVICO AS SERVICO, S.DESCRICAO , C.DESCRICAO AS CAPACIDADE_SERVICO, C.QUANTIDADE FROM CAPACIDADES C
INNER JOIN SERVICOS S ON C.ID = S.ID_CAPACIDADES


--IMPLEMENTA��O DE PROCEDURES

--Busca um agendamento por id
CREATE PROCEDURE BuscaAgendamento
@ID VARCHAR(8)
AS
SELECT S.NOME_SERVICO, S.DESCRICAO, A.DATA_AGENDAMENTO AS DIA, A.HORA_AGENDAMENTO AS HORARIO,
U.NOME AS CLIENTE, U.TELEFONE AS TELEFONE_CLIENTE, I.NOME_FANTASIA AS NOME_EMPREENDIMENTO, I.TELEFONE AS TELEFONE_EMPRESA,
C.NOME AS STATUS_AGENDAMENTO, V.VALOR FROM AGENDAMENTOS A
INNER JOIN SERVICOS S ON A.ID_SERVICO = S.ID
INNER JOIN USUARIOS U ON A.ID_USUARIO = U.ID
INNER JOIN INSTITUICOES I ON A.ID_INSITUICAO = I.ID
INNER JOIN STATUS_AGENDAMENTO C ON A.ID_STATUS = C.ID
INNER JOIN VALORES V ON A.ID_SERVICO = V.ID
WHERE A.ID = @ID
GO

--Busca um usuario por id
CREATE PROCEDURE BuscaUsuario
@ID VARCHAR(8)
AS
SELECT U.NOME AS NOME_USUARIO, U.RG, U.CPF, U.EMAIL, U.SENHA, U.TELEFONE, T.NOME AS TIPO_USUARIO, L.RUA, L.CEP, L.BAIRRO, L.MUNICIPIO,
L.ESTADO FROM USUARIOS U
INNER JOIN TIPO_USUARIOS T ON U.ID_TIPO_USUARIO = T.ID
INNER JOIN LOGRADOUROS L ON U.ID_LOGRADOURO = L.ID
WHERE U.ID = @ID
GO

--Busca um lojista por id
CREATE PROCEDURE BuscaLojista
@ID VARCHAR(8)
AS
SELECT L.NOME, L.RG, L.CPF, L.EMAIL, L.SENHA, L.TELEFONE, T.NOME AS USUARIO, E.RUA, E.CEP, E.BAIRRO, E.MUNICIPIO, E.ESTADO,
I.NOME_FANTASIA AS EMPREENDIMENTO, I.RAZAO_SOCIAL, I.CNPJ, I.TELEFONE FROM LOJISTAS L
INNER JOIN TIPO_USUARIOS T ON L.ID_TIPO_USUARIO = T.ID
INNER JOIN LOGRADOUROS E ON L.ID_LOGRADOURO = E.ID
INNER JOIN INSTITUICOES I ON L.ID_INSTITUICAO = I.ID
WHERE L.ID = @ID
GO

--Busca um endere�o por id
CREATE PROCEDURE BuscaEndereco
@ID VARCHAR(8)
AS
SELECT L.RUA, L.CEP, L.BAIRRO, L.MUNICIPIO, L.ESTADO, U.NOME AS USUARIO, U.TELEFONE, I.NOME_FANTASIA AS EMPREENDIMENTO,
I.TELEFONE FROM LOGRADOUROS L
INNER JOIN USUARIOS U ON L.ID = U.ID_LOGRADOURO
INNER JOIN INSTITUICOES I ON L.ID = I.ID_LOGRADOURO
WHERE L.ID = @ID
GO

--Busca um empreendimento por id
CREATE PROCEDURE BuscaInstituicao
@ID VARCHAR(8)
AS
SELECT I.NOME_FANTASIA AS EMPREENDIMENTO, I.RAZAO_SOCIAL, I.CNPJ, A.NOME AS AREA, I.TELEFONE,
L.NOME AS EMPREENDEDOR, L.EMAIL, L.TELEFONE AS TELEFONE_EMPREENDEDOR, E.RUA, E.CEP, E.BAIRRO, E.MUNICIPIO,
E.ESTADO FROM INSTITUICOES I
INNER JOIN LOJISTAS L ON I.ID = L.ID_INSTITUICAO
INNER JOIN LOGRADOUROS E ON I.ID_LOGRADOURO = E.ID
INNER JOIN AREAS_ATIVIDADE A ON I.ID_AREAS_ATIVIDADE = A.ID
WHERE I.ID = @ID
GO

--Busca servi�os por id
CREATE PROCEDURE BuscaServico
@ID VARCHAR(8)
AS
SELECT S.NOME_SERVICO AS SERVICO, S.DESCRICAO, V.VALOR, C.DESCRICAO AS CAPACIDADE_SERVICO, C.QUANTIDADE,
A.DATA_AGENDAMENTO AS DIA, A.HORA_AGENDAMENTO AS HORARIO  FROM SERVICOS S
INNER JOIN AGENDAMENTOS A ON S.ID = A.ID_SERVICO
INNER JOIN VALORES V ON S.ID_VALORES = V.ID
INNER JOIN CAPACIDADES C ON S.ID_CAPACIDADES = C.ID
WHERE S.ID = @ID
GO

--Busca areas de atua��o por id
CREATE PROCEDURE BuscaArea
@ID VARCHAR(8)
AS
SELECT A.NOME AS AREA_ATIVIDADE, I.NOME_FANTASIA AS EMPREENDIMENTO, I.CNPJ, I.TELEFONE FROM AREAS_ATIVIDADE A
INNER JOIN INSTITUICOES I ON A.ID = I.ID_AREAS_ATIVIDADE
WHERE A.ID = @ID
GO

--Busca capacidade de servi�os por id
CREATE PROCEDURE BuscaCapacidade
@ID VARCHAR(8)
AS
SELECT S.NOME_SERVICO AS SERVICO, S.DESCRICAO , C.DESCRICAO AS CAPACIDADE_SERVICO, C.QUANTIDADE FROM CAPACIDADES C
INNER JOIN SERVICOS S ON C.ID = S.ID_CAPACIDADES
WHERE C.ID = @ID
GO


EXEC BuscaCapacidade 1

EXEC BuscaAgendamento 1

EXEC BuscaUsuario 1

EXEC BuscaLojista 1

EXEC BuscaEndereco 2

EXEC BuscaInstituicao 1

EXEC BuscaServico 1

EXEC BuscaArea 2