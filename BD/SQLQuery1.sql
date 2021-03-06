USE [master]
GO
CREATE DATABASE PJLUDOIV
GO
USE PJLUDOIV
GO

CREATE TABLE TPPRODUTO
(
	idTpProduto 		SMALLINT IDENTITY PRIMARY KEY,
	nmTpProduto			VARCHAR (70) NOT NULL,
	iconeTpProduto		VARCHAR (70) NOT NULL,
	Ativo				BIT NOT NULL
)

INSERT INTO TPPRODUTO VALUES ('Jogo','',1)
INSERT INTO TPPRODUTO VALUES ('Console','',1)
INSERT INTO TPPRODUTO VALUES ('Acessório','',1)

GO
CREATE TABLE DESENVOLVEDOR 
(
	idDesenvolvedor		SMALLINT IDENTITY PRIMARY KEY,
	nmDesenvolvedor		VARCHAR (70) NOT NULL,
	iconeDesenvolvedor	VARCHAR (70) NOT NULL,
	Ativo				BIT NOT NULL
)

INSERT INTO DESENVOLVEDOR VALUES ('UbiSoft','Ubisoft.png',1)
INSERT INTO DESENVOLVEDOR VALUES ('Electronic Arts','ea_logo.png',1)
INSERT INTO DESENVOLVEDOR VALUES ('Lucas Arts','lucasarts.png',1)
INSERT INTO DESENVOLVEDOR VALUES ('Disney','Disney_Interactive133_large.png',1)
INSERT INTO DESENVOLVEDOR VALUES ('DreamGear','Dreamgear_hotsite.jpg',1)
INSERT INTO DESENVOLVEDOR VALUES ('Bethesda Softworks','Bethesda_Softworks.png',1)
INSERT INTO DESENVOLVEDOR VALUES ('Team Bondi','Team_Bondi_logo.png',1)
INSERT INTO DESENVOLVEDOR VALUES ('Insomniac Games','insom_moon_bug_normal.png',1)
INSERT INTO DESENVOLVEDOR VALUES ('Capcom','',1)
INSERT INTO DESENVOLVEDOR VALUES ('Sony Computer Entertainment','sony_computer_entertainment_logo_091208.gif',1)
INSERT INTO DESENVOLVEDOR VALUES ('Nintendo','NintendoLogo.png',1)
INSERT INTO DESENVOLVEDOR VALUES ('Microsoft','microsoft-studios-stock-logo.png',1)


GO
CREATE TABLE PUBLICADOR
(
	idPublicador		SMALLINT IDENTITY PRIMARY KEY,
	nmPublicador		VARCHAR (70) NOT NULL,
	iconePublicador		VARCHAR (70) NOT NULL,
	Ativo				BIT NOT NULL
)

INSERT INTO PUBLICADOR VALUES ('UbiSoft','Ubisoft.png',1)
INSERT INTO PUBLICADOR VALUES ('Electronic Arts','ea_logo.png',1)
INSERT INTO PUBLICADOR VALUES ('Lucas Arts Entertainment','lucasarts.png',1)
INSERT INTO PUBLICADOR VALUES ('Disney Interactive','Disney_Interactive133_large.png',1)
INSERT INTO PUBLICADOR VALUES ('DreamGear','Dreamgear_hotsite.jpg',1)
INSERT INTO PUBLICADOR VALUES ('Bethesda Softworks','Bethesda_Softworks.png',1)
INSERT INTO PUBLICADOR VALUES ('Rockstar Games','Rockstar_Games_Logo.PNG',1)
INSERT INTO PUBLICADOR VALUES ('Sony Computer Entertainment','sony_computer_entertainment_logo_091208.gif',1)
INSERT INTO PUBLICADOR VALUES ('Capcom','',1)
INSERT INTO PUBLICADOR VALUES ('Nintendo of America','NintendoLogo.png',1)
INSERT INTO PUBLICADOR VALUES ('Microsoft','microsoft-studios-stock-logo.png',1)

GO
CREATE TABLE PLATAFORMA
(
	idPlataforma		SMALLINT IDENTITY PRIMARY KEY,
	nmPlataforma		VARCHAR (70) NOT NULL,
	iconePlataforma		VARCHAR (70) NOT NULL,
	Ativo				BIT NOT NULL
)

INSERT INTO PLATAFORMA VALUES ('Xbox 360','icon_Xbox_360.png',1)
INSERT INTO PLATAFORMA VALUES ('Playstation 3','sony-playstation-3-1336524977.png',1)
INSERT INTO PLATAFORMA VALUES ('Wii','nintendo-wii-1336524734.png',1)
INSERT INTO PLATAFORMA VALUES ('Wii U','nintendo-wii-u-1336524744.png',1)
INSERT INTO PLATAFORMA VALUES ('PC','pc-1336524756.png',1)
INSERT INTO PLATAFORMA VALUES ('3DS','nintendo-3ds-1344286647.png',1)
INSERT INTO PLATAFORMA VALUES ('PS Vita','sony-playstation-vita-1336524991.png',1)
INSERT INTO PLATAFORMA VALUES ('PSP','sony-psp-1336525006.png',1)
INSERT INTO PLATAFORMA VALUES ('PlayStation 2','',1)
INSERT INTO PLATAFORMA VALUES ('Xbox','',1)
INSERT INTO PLATAFORMA VALUES ('GameCube','',1)



GO
CREATE TABLE GENERO
(
	idGenero		SMALLINT IDENTITY PRIMARY KEY,
	nmGenero		VARCHAR (70) NOT NULL,
	iconeGenero		VARCHAR (70) NOT NULL,
	Ativo			BIT NOT NULL
)

INSERT INTO GENERO VALUES ('Aventura','',1)
INSERT INTO GENERO VALUES ('Criminal','',1)
INSERT INTO GENERO VALUES ('Voo','',1)
INSERT INTO GENERO VALUES ('Terror','',1)
INSERT INTO GENERO VALUES ('Plataforma','',1)
INSERT INTO GENERO VALUES ('Tática','',1)
INSERT INTO GENERO VALUES ('Ação Arcade','',1)
INSERT INTO GENERO VALUES ('RPG','',1)
INSERT INTO GENERO VALUES ('Dança','',1)
INSERT INTO GENERO VALUES ('Musica','',1)
INSERT INTO GENERO VALUES ('Cantar','',1)
INSERT INTO GENERO VALUES ('MMORPG','',1)
INSERT INTO GENERO VALUES ('Aviação','',1)
INSERT INTO GENERO VALUES ('Militar','',1)
INSERT INTO GENERO VALUES ('Social','',1)
INSERT INTO GENERO VALUES ('Direção','',1)
INSERT INTO GENERO VALUES ('Baseball','',1)
INSERT INTO GENERO VALUES ('BasketBall','',1)
INSERT INTO GENERO VALUES ('Billiards','',1)
INSERT INTO GENERO VALUES ('Boliche','',1)
INSERT INTO GENERO VALUES ('Pescaria','',1)
INSERT INTO GENERO VALUES ('Fitness','',1)
INSERT INTO GENERO VALUES ('Futebol Americano','',1)
INSERT INTO GENERO VALUES ('Golfe','',1)
INSERT INTO GENERO VALUES ('Hockey','',1)
INSERT INTO GENERO VALUES ('Caça','',1)
INSERT INTO GENERO VALUES ('Esporte Diversos','',1)
INSERT INTO GENERO VALUES ('Corrida','',1)
INSERT INTO GENERO VALUES ('Skate','',1)
INSERT INTO GENERO VALUES ('Snowboarding','',1)
INSERT INTO GENERO VALUES ('Futebol','',1)
INSERT INTO GENERO VALUES ('Surfe','',1)
INSERT INTO GENERO VALUES ('Tênis','',1)
INSERT INTO GENERO VALUES ('Wrestling','',1)



GO
CREATE TABLE ESRB
(
	idESRB 			TINYINT IDENTITY PRIMARY KEY,
	nmESRB			VARCHAR (70) NOT NULL,
	iconeESRB		VARCHAR (70) NOT NULL,
	Ativo			BIT NOT NULL
)
	
	INSERT INTO ESRB VALUES ('Infantil','ESRB_Early_Childhood.png',1)
	INSERT INTO ESRB VALUES ('Adolescente','ESRB_Teen.png',1)
	INSERT INTO ESRB VALUES ('Somente para Adultos 18+','ESRB_Adults_Only_18+.png',1)
	INSERT INTO ESRB VALUES ('Todos','ESRB_Everyone.png',1)	
	INSERT INTO ESRB VALUES ('Jovens 17+','ESRB_Mature_17+.png',1)
	INSERT INTO ESRB VALUES ('Classificação Pendente','ESRB_RP.png',1)

GO
CREATE TABLE MIDIA
(
	idMidia 		SMALLINT IDENTITY PRIMARY KEY,
	nmMidia 		VARCHAR (70) NOT NULL,
	iconeMidia		VARCHAR (70) NOT NULL,
	Ativo			BIT NOT NULL
)

INSERT INTO MIDIA VALUES ('Blu-ray Disc','bluray_disc_logo-300x201.png',1)
INSERT INTO MIDIA VALUES ('DVD','DVD.png',1)
INSERT INTO MIDIA VALUES ('CD-Rom','CDROM_System.png',1)
INSERT INTO MIDIA VALUES ('Cartucho','',1)
INSERT INTO MIDIA VALUES ('UMD','Umd Red.png',1)
INSERT INTO MIDIA VALUES ('Outros','',1)
INSERT INTO MIDIA VALUES ('Cartão PS Vita','',1)

GO
CREATE TABLE CATEGORIA
(
	idCategoria 		SMALLINT IDENTITY PRIMARY KEY,
	nmCategoria 		VARCHAR (70) NOT NULL,
	iconeCategoria		VARCHAR (70) NOT NULL,
	Ativo				BIT NOT NULL
	
)



INSERT INTO CATEGORIA VALUES ('3D','',1)
INSERT INTO CATEGORIA VALUES ('Ação','',1)
INSERT INTO CATEGORIA VALUES ('Casual','',1)
INSERT INTO CATEGORIA VALUES ('Luta','',1)
INSERT INTO CATEGORIA VALUES ('Move','',1)
INSERT INTO CATEGORIA VALUES ('Musica & Festa','',1)
INSERT INTO CATEGORIA VALUES ('Puzzle','',1)
INSERT INTO CATEGORIA VALUES ('RPG','',1)
INSERT INTO CATEGORIA VALUES ('Tiro','',1)
INSERT INTO CATEGORIA VALUES ('Simulação','',1)
INSERT INTO CATEGORIA VALUES ('Esportes','',1)
INSERT INTO CATEGORIA VALUES ('Estratégia','',1)
INSERT INTO CATEGORIA VALUES ('Baterias e Carregadores','',1)
INSERT INTO CATEGORIA VALUES ('Kinect','',1)
INSERT INTO CATEGORIA VALUES ('Game Hardware','',1)
INSERT INTO CATEGORIA VALUES ('Controles','',1)



GO
CREATE TABLE PRODUTO
(
	idProduto			INT IDENTITY PRIMARY KEY,
	nmCompleto			VARCHAR (70) NOT NULL,
	nmReduzido			VARCHAR (22),
	descrProduto		VARCHAR (1000)NOT NULL,
	descrProduto2		VARCHAR (8000) NULL,
	ftCapa				VARCHAR	(70) NULL,
	idDesenvolvedor		SMALLINT FOREIGN KEY REFERENCES	Desenvolvedor NULL,
	idPublicador		SMALLINT FOREIGN KEY REFERENCES	Publicador NULL,
	idPlataforma		SMALLINT FOREIGN KEY REFERENCES	Plataforma NULL,
	dtLancamento		DATE NULL,
	idESRB				TINYINT  FOREIGN KEY REFERENCES	ESRB NULL,
	idMidia				SMALLINT FOREIGN KEY REFERENCES	MIDIA NULL,
	idTpProduto			SMALLINT FOREIGN KEY REFERENCES	TPPRODUTO NULL,
	noPlayers			TINYINT NULL,
	Garantia			VARCHAR (22) NULL,
	noEstMin			SMALLINT NOT NULL,
	noEstMax			SMALLINT NOT NULL,
	noEstAlvo			SMALLINT NOT NULL,
	Ativo				BIT	 NOT NULL,
	dtCadastro			DATETIME NOT NULL,
	Margem				DECIMAL	 NULL,		
)
	
	
GO
CREATE TABLE SCREENSHOT
(
	nmScreen			 VARCHAR	(70) NOT NULL,
	idProduto			 INT FOREIGN KEY REFERENCES PRODUTO,
	Tipo				 VARCHAR	(30) NOT NULL,	
	CONSTRAINT	idScreen PRIMARY KEY (nmScreen, idProduto)
)

GO
CREATE TABLE EAN
(
	noEAN 		VARCHAR(14) UNIQUE,
	idProduto	INT FOREIGN KEY REFERENCES PRODUTO,
	CONSTRAINT	idEAN PRIMARY KEY (noEAN, idProduto)
)

GO
CREATE TABLE ITEMINCLUSO
(
	idItemIncluso	INT IDENTITY PRIMARY KEY,
	idProduto		INT FOREIGN KEY REFERENCES PRODUTO,
	nmItem          VARCHAR	(70) NOT NULL
)



GO	
CREATE TABLE PRODUTO_GENERO
(
	idProduto	INT FOREIGN KEY REFERENCES PRODUTO,
	idGenero	SMALLINT FOREIGN KEY REFERENCES GENERO,
	CONSTRAINT	idProd PRIMARY KEY (idGenero, idProduto)
)

GO
CREATE TABLE PRODUTO_CATEGORIA
(
	idProduto	INT FOREIGN KEY REFERENCES PRODUTO,
	idCategoria	SMALLINT FOREIGN KEY REFERENCES CATEGORIA,
	CONSTRAINT	idPCategoria PRIMARY KEY (idCategoria, idProduto)
)



GO
CREATE TABLE PRECO_PRODUTO
(
	idPreco_Prod	INT IDENTITY PRIMARY KEY,
	idProduto		INT FOREIGN KEY REFERENCES PRODUTO,
	vlCusto			SMALLMONEY NOT NULL,
	vlVendaLoja		SMALLMONEY NULL,
	vlVendaNet		SMALLMONEY NULL,
	DtAtualizacao	DATETIME NOT NULL
)



GO
CREATE TABLE FORNECEDOR
(
	idFornecedor	INT IDENTITY PRIMARY KEY,
	CNPJ 			CHAR    (14)  NOT NULL,
	RazaoSocial   	VARCHAR (70)  NOT NULL,
	NmFantasia    	VARCHAR (70)  NULL,
	noCEP 			CHAR    (8)   NOT NULL,
	noLog 			VARCHAR (8)   NOT NULL,
	dsComplemento 	VARCHAR (70)  NULL,
	noDDD 			CHAR    (2)   NOT NULL,
	noTelefone 		VARCHAR (9)   NOT NULL,
	nmHomePage 		VARCHAR (100) NULL,
	nmContato 		VARCHAR (70)  NULL,
	Email			VARCHAR (70)  NULL,
	noDDDCel		CHAR    (2)   NULL,
	noCelular	 	VARCHAR (9)   NULL,
	DtCad		    DATETIME      NOT NULL,
	Ativo			BIT           NOT NULL
)
GO
CREATE TABLE PROD_FORNE
(
	idProduto		INT FOREIGN KEY REFERENCES PRODUTO,
	idFornecedor 	INT FOREIGN KEY REFERENCES FORNECEDOR,
	CONSTRAINT		idProdForn PRIMARY KEY (idProduto, idFornecedor)
)

--GERENCIA USUARIOS DO SISTEMA

GO
CREATE TABLE  PERFIL_ACESSO
(
	idPerfil		 		TINYINT IDENTITY PRIMARY KEY,
	nmPerfil				VARCHAR(10) NOT NULL
)

INSERT INTO PERFIL_ACESSO VALUES ('Admin')
INSERT INTO PERFIL_ACESSO VALUES ('User')


 
GO
CREATE TABLE USUARIO
	( 
		idUsuario	INT IDENTITY PRIMARY KEY,
		PNome  		VARCHAR (40) NOT NULL,
		UNome		VARCHAR (70) NOT NULL,
		Senha		VARCHAR (8)  NOT NULL,
		idPerfil	TINYINT FOREIGN KEY REFERENCES PERFIL_ACESSO,
		dtCad		DATETIME NOT NULL,
		Ativo		BIT NOT NULL
	)
	


--GERENCIA SITUAÇÃO DOS PEDIDOS DE COMPRA E VENDA
	CREATE TABLE SITUACAO
	(
		idSituacao		SMALLINT IDENTITY PRIMARY KEY,
		nmSituacao 		VARCHAR (20) NOT NULL
	)

	INSERT INTO SITUACAO VALUES ('NOVO')
	INSERT INTO SITUACAO VALUES ('FATURADO')
	INSERT INTO SITUACAO VALUES ('ENVIADO')
	INSERT INTO SITUACAO VALUES ('FECHADO')
	INSERT INTO SITUACAO VALUES ('CANCELADO')

--GERENCIA PEDIDO DE COMPRA
GO
CREATE TABLE PDC
(
	idPDC			INT IDENTITY PRIMARY KEY,
	idUsuario		INT FOREIGN KEY REFERENCES USUARIO,
	idFornecedor 	INT FOREIGN KEY REFERENCES FORNECEDOR,
	idSituacao 		SMALLINT FOREIGN KEY REFERENCES SITUACAO,
	DtPedido	    DATE NOT NULL,
	DtEntrega	    DATE NULL,
)
GO
CREATE TABLE DET_PDC
(
	idDetPDC		INT IDENTITY PRIMARY KEY,
	idPDC 			INT FOREIGN KEY REFERENCES PDC,
	idProduto		INT FOREIGN KEY REFERENCES PRODUTO,
	QTDE 			SMALLINT NOT NULL,
	vlUnit			SMALLMONEY	NOT NULL,
	Entregue		BIT NOT NULL,
)

--GERENCIA ENTRADA DE NOTAS FISCAIS
GO
CREATE TABLE ENTNF
(
	idEntNF			INT IDENTITY PRIMARY KEY,
	idUsuario		INT FOREIGN KEY REFERENCES USUARIO,
	idPDC 			INT FOREIGN KEY REFERENCES PDC NULL,
	idFornecedor 	INT FOREIGN KEY REFERENCES FORNECEDOR,
	dtRecebimento	SMALLDATETIME,
	noNF			VARCHAR (15)NOT NULL,
	noSerie			VARCHAR (3) NULL,
	vlNF		  	MONEY NOT NULL, 
	dtEmissao		DATETIME,
	dtEntrada		DATETIME NOT NULL
)
GO
	CREATE  TABLE DET_ENTNF
(
	cdDetEntNF		INT IDENTITY PRIMARY KEY,
	cdEntNF 		INT FOREIGN KEY REFERENCES ENTNF,
	idProduto		INT FOREIGN KEY REFERENCES PRODUTO,
	QTDE 			SMALLINT	NOT NULL,
	vlUnit			SMALLMONEY	NOT NULL
)

--GERENCIA CADASTRO DE CLIENTES
GO
CREATE TABLE CLIENTE
	( 
		idCliente	INT IDENTITY PRIMARY KEY,
		PNome  		VARCHAR (40) NOT NULL,
		UNome		VARCHAR (70) NOT NULL,
		CPF		    CHAR (11) NOT NULL UNIQUE,
		Email		VARCHAR (70) UNIQUE,
		Senha		VARCHAR (8)  NOT NULL,
		dtCad		DATE NOT NULL,
		Ativo		BIT NOT NULL
		
	)

GO

CREATE TABLE UF
(
	cdUF 			INT PRIMARY KEY,
	sgUF 			CHAR (2),
	nmUF 			VARCHAR(50)
)
GO
CREATE TABLE CIDADE
(	
	cdUF 			INT FOREIGN KEY REFERENCES UF,
	cdCidade 		INT PRIMARY KEY , 
	nmCidade 		VARCHAR(100)
)
GO
CREATE TABLE BAIRRO
(
	cdBairro 		INT PRIMARY KEY, 
	nmBairro 		VARCHAR(100),
	cdCidade 		INT FOREIGN KEY REFERENCES CIDADE
)
GO
CREATE TABLE LOGRADOURO
(
	cdLogradouro 	INT PRIMARY KEY, 
	cdBairro		INT FOREIGN KEY REFERENCES BAIRRO,
	nmLogradouro	VARCHAR(300),
	noCEP 			VARCHAR(10)
) 

GO

CREATE TABLE CLIENTE_ENDERECO
(	
		idCliEnd		INT IDENTITY PRIMARY KEY,
		idCliente 		INT FOREIGN KEY REFERENCES CLIENTE,
		PNomeDest		VARCHAR (40),
		UNomeDest		VARCHAR (70),
		DDD				CHAR (2) ,
		Telefone		VARCHAR (9) ,
		noCEP 			CHAR (8) ,
		Logradouro		VARCHAR (100),
		Bairro			VARCHAR (100),
		Cidade			VARCHAR (100),
		UF				CHAR (2),
		noLog 			VARCHAR (8) ,
		Complemento		VARCHAR (70),
		PEntrega		BIT,
		DtCad			DATE,
		Ativo			BIT 
		
)

GO
CREATE TABLE COMENTARIO
	( 
		idComentario	INT IDENTITY PRIMARY KEY,
		idProduto		INT FOREIGN KEY REFERENCES PRODUTO,
		Comentario		VARCHAR (250) NOT NULL,
		dtComent		DATETIME NOT NULL,
		
	)

--GERENCIA PEDIDO DE VENDA


GO
CREATE TABLE TPVENDA
(
		idTPvenda 	TINYINT IDENTITY PRIMARY KEY,
		nmTPVenda 	VARCHAR (20) NOT NULL
)

	INSERT INTO TPVENDA VALUES ('Loja')
	INSERT INTO TPVENDA VALUES ('Internet')
	INSERT INTO TPVENDA VALUES ('Telefone')

GO
CREATE TABLE FORMAPGTO
(
		idFormaPgto TINYINT IDENTITY PRIMARY KEY,
		nmFormaPgto	VARCHAR (20) NOT NULL
)

INSERT INTO FORMAPGTO VALUES ('Dinheiro')
INSERT INTO FORMAPGTO VALUES ('Cartão')
INSERT INTO FORMAPGTO VALUES ('Boleto')
INSERT INTO FORMAPGTO VALUES ('Transferencia')
GO	
CREATE TABLE PDV
(
	idPDV 			INT IDENTITY PRIMARY KEY,
	idUsuario		INT,		
	idCliente 		INT FOREIGN KEY REFERENCES CLIENTE,
	idCliEnd 		INT FOREIGN KEY REFERENCES CLIENTE_ENDERECO,
	idSituacao 		SMALLINT FOREIGN KEY REFERENCES SITUACAO,
	dtPedido 		DATETIME NOT NULL,
	dtEnvio 		DATETIME NULL,
	txEnvio			MONEY NULL, 
	obs 			VARCHAR (300) NULL,
	idTPvenda 		TINYINT FOREIGN KEY REFERENCES TPVENDA ,
	idFormaPgto 	TINYINT FOREIGN KEY REFERENCES FORMAPGTO,
) 

GO
CREATE TABLE DET_PDV
(
	idDetPDV 		INT IDENTITY PRIMARY KEY,
	idPDV 			INT FOREIGN KEY REFERENCES PDV,
	idProduto		INT FOREIGN KEY REFERENCES PRODUTO,
	QTDE 			SMALLINT NOT NULL,
	SubTotal 		MONEY NOT NULL
)

 SELECT *     FROM DET_PDV  WHERE DET_PDV.idPDV = '4'

--GERENCIA ESTOQUE

GO
CREATE TABLE TIPO_ME
(
	idTPMe 		INT IDENTITY PRIMARY KEY,
	noDetME 	VARCHAR (30) NOT NULL,
)
GO
	INSERT INTO TIPO_ME VALUES ('ENTRADA')
	INSERT INTO TIPO_ME VALUES ('SAIDA')
	INSERT INTO TIPO_ME VALUES ('RESERVADO')
GO
CREATE TABLE DET_ME
(
	idDetMe 	INT IDENTITY PRIMARY KEY,
	noDetME 	VARCHAR (30) NOT NULL,
)
GO
	INSERT INTO DET_ME VALUES ('NF')
	INSERT INTO DET_ME VALUES ('VENDA')
	INSERT INTO DET_ME VALUES ('ACERTO ESTOQUE')
	INSERT INTO DET_ME VALUES ('INVENTARIO')
	
GO	
 create TABLE MOV_EST
(
	idMovEst	INT IDENTITY PRIMARY KEY,
	idUsuario	INT NULL,
	idCliente	INT NULL,
	idProduto	INT FOREIGN KEY REFERENCES PRODUTO,
	QTDE 		SMALLINT NOT NULL,
	idTPMe 		INT FOREIGN KEY REFERENCES TIPO_ME,
	idDetMe 	INT FOREIGN KEY REFERENCES DET_ME,
	dtMovEst	DATETIME NOT NULL,
	dtMod	 	DATETIME NULL,
	idPDV 		INT ,
	idEntNF		INT
)


