USE PJLUDOIV
GO
CREATE PROCEDURE SP_LCategoria
			(
			@idPlataforma SMALLINT,
			@idTpProduto SMALLINT
			)
AS

BEGIN

	SELECT DISTINCT (CATEGORIA.nmCategoria),  CATEGORIA.idCategoria 
	FROM  CATEGORIA, PRODUTO, PRODUTO_CATEGORIA 
	WHERE CATEGORIA.idCategoria=PRODUTO_CATEGORIA.idCategoria 
		  AND PRODUTO_CATEGORIA.idProduto=PRODUTO.idProduto 
		  AND PRODUTO.idPlataforma=@idPlataforma
		  AND PRODUTO.idTpProduto=@idTpProduto
	END

GO
	
CREATE PROCEDURE SP_LTopProduto
			(
			@nmPlataforma VARCHAR (70),
			@idTpProduto SMALLINT
			)
AS

BEGIN

	SELECT TOP 10 (PRODUTO.idProduto), PRODUTO.dtLancamento, PRODUTO.nmCompleto, PRODUTO.ftCapa , PLATAFORMA.nmPLATAFORMA, PRECO_PRODUTO.vlVendaLoja,CATEGORIA.NMCATEGORIA
	FROM TPPRODUTO, PRODUTO, PLATAFORMA,PRECO_PRODUTO, CATEGORIA,PRODUTO_CATEGORIA
	WHERE TPPRODUTO.idTpProduto=PRODUTO.idTpProduto 
		AND PLATAFORMA.idPlataforma=PRODUTO.idPlataforma 
		AND PRODUTO.idProduto=PRECO_PRODUTO.idProduto
		AND CATEGORIA.IDCATEGORIA= PRODUTO_CATEGORIA.IDCATEGORIA 
		AND PRODUTO.idProduto=PRODUTO_CATEGORIA.idProduto
		AND	PLATAFORMA.nmPlataforma=@nmPlataforma
		AND	PRODUTO.idTpProduto=@idTpProduto
	ORDER BY PRODUTO.dtLancamento asc 
END
  
GO
  
 CREATE PROCEDURE SP_LGenero
		(
			@nmplataforma VARCHAR (70) 
		)
AS
BEGIN

	SELECT DISTINCT(nmGenero), produto_genero.idGenero 
	FROM  produto_genero, genero, plataforma 
	WHERE genero.idgenero=produto_genero.idgenero 
		  AND  nmplataforma=@nmplataforma
END

GO		
		
CREATE PROCEDURE SP_AddCliente
				(
				@PNome  	VARCHAR (40),
				@UNome		VARCHAR (70),
				@CPF		CHAR (11),	
				@Email		VARCHAR (70),
				@Senha		VARCHAR (8),
				@DtCad		DATE,
				@Ativo		BIT
				)				
		
AS
BEGIN
	INSERT INTO CLIENTE (PNome, UNome, CPF, Email, Senha, DtCad, Ativo ) 
	VALUES (@PNome, @UNome, @CPF, @Email, @Senha, @DtCad, @Ativo)
END

GO

CREATE PROCEDURE SP_AddCliEnd
				(
				@idCliente 		INT ,
				@PNomeDest  	VARCHAR (40),
				@UNomeDest		VARCHAR (70),
				@DDD			CHAR (2),
				@Telefone		VARCHAR (9),	
				@noCEP 			CHAR (8) ,
				@Logradouro		VARCHAR (100),
				@Bairro			VARCHAR (100),
				@Cidade			VARCHAR (100),
				@UF				CHAR (2),
				@noLog 			VARCHAR (8) ,
				@Complemento	VARCHAR (70),
				@PEntrega		BIT,
				@DtCad			DATE,
				@Ativo			BIT
				)				
	
AS
BEGIN
	INSERT INTO CLIENTE_ENDERECO (idCliente, PNomeDest, UNomeDest, DDD, Telefone, noCEP, Logradouro, Bairro, Cidade, UF, noLog, Complemento, PEntrega, DtCad, Ativo ) 
	VALUES (@idCliente, @PNomeDest, @UNomeDest, @DDD, @Telefone, @noCEP, @Logradouro, @Bairro, @Cidade, @UF, @noLog, @Complemento, @PEntrega, @DtCad, @Ativo)
END

GO

CREATE PROCEDURE SP_UpdtCliente
				(
				@idCliente 		INT,	
				@PNome  	VARCHAR (40),
				@UNome		VARCHAR (70),
				@Email		VARCHAR (70),
				@Senha		VARCHAR (8),
				@Ativo		BIT
				)				
		
AS
BEGIN
	UPDATE CLIENTE  SET PNome=@PNome, UNome=@UNome, Email=@Email, Senha=@Senha, Ativo=@Ativo 
	WHERE idCliente=@idCliente
END
	
GO

CREATE PROCEDURE SP_ValidaCliente
				(
				@Email VARCHAR (70),	
				@Senha VARCHAR (8)			
				)
	AS
	BEGIN

		SELECT idCliente, PNome, UNome, CPF, Email, Senha 
		FROM CLIENTE
		WHERE Email=@Email And Senha=@Senha

	END
GO

CREATE PROCEDURE SP_ValidaCliente2
			(
			@idCliente 		INT,		
			@Senha VARCHAR (8)			
			)
AS
BEGIN
	
	SELECT idCliente, PNome, UNome, Email, Senha 
	FROM CLIENTE
	WHERE idCliente=@idCliente And Senha=@Senha
END

GO

CREATE PROCEDURE SP_LEnd
		(
		@idCliente 		INT,	
		@PEntrega		BIT
		)
AS
BEGIN
	Select idCliEnd, idCliente, (PNomeDest + ' ' + UNomeDest + ' ' + 'CEP: ' + noCEP) as Dados, PNomeDest, UNomeDest,  DDD, Telefone, 
	Logradouro, Bairro, Cidade, UF, noCEP, noLog, Complemento, PEntrega, DtCad, ativo

	FROM  CLIENTE_ENDERECO
	WHERE idCliente=@idCliente AND PEntrega=@PEntrega
END

GO

CREATE PROCEDURE SP_LEndPadrao
		(
		@idCliente 		INT,
		@idCliEnd 		INT,	
		@PEntrega		BIT
		)
AS
BEGIN
	SELECT idCliEnd, idCliente, PNomeDest, UNomeDest, DDD, Telefone, noCEP, Logradouro, Bairro, Cidade, UF, noLog, Complemento, PEntrega, DtCad, Ativo
	FROM  CLIENTE_ENDERECO
	WHERE idCliente=@idCliente AND PEntrega=@PEntrega AND idCliEnd=@idCliEnd 
END

GO

CREATE PROCEDURE SP_RsvPedidoNet
				(
				@idCliente 		INT ,
				@IdProduto  	INT ,
				@Qtde 			INT ,
				@IdTPMe 		INT ,
				@IdDetMe		INT ,
				@DtMovEst 		DATETIME
				)				
		
AS
BEGIN
	INSERT INTO MOV_EST (idCliente, IdProduto, Qtde, IdTPMe, IdDetMe, DtMovEst) 
	VALUES (@idCliente, @IdProduto, @Qtde, @IdTPMe, @IdDetMe, @DtMovEst)
END

GO

CREATE PROCEDURE LItemReserva
				(
				@idCliente 			INT ,
				@dtMovEst			DATETIME 
				)
AS
BEGIN
	SELECT MOV_EST.idProduto, MOV_EST.QTDE, PRECO_PRODUTO.vlVendaLoja 
	FROM MOV_EST, PRECO_PRODUTO
	WHERE MOV_EST.idProduto=PRECO_PRODUTO.idProduto AND MOV_EST.dtMovEst=@dtMovEst AND  MOV_EST.idCliente=@idCliente
END 

GO

CREATE PROCEDURE SP_ADDPDV
				(
			
			@idUsuario		INT,		
			@idCliente 		INT,
			@idCliEnd 		INT,
			@idSituacao 		SMALLINT,
			@dtPedido 		DATETIME,
			@dtEnvio 		DATETIME,
			@txEnvio			MONEY, 
			@obs 			VARCHAR (300),
			@idTPvenda 		TINYINT,
			@idFormaPgto 	TINYINT
				)				
AS
BEGIN
	INSERT INTO PDV (idUsuario, idCliente, idCliEnd, idSituacao, dtPedido, dtEnvio, txEnvio, obs, idTPvenda, idFormaPgto) 
	VALUES (@idUsuario, @idCliente, @idCliEnd, @idSituacao, @dtPedido, @dtEnvio, @txEnvio, @obs, @idTPvenda, @idFormaPgto)
END

GO	

CREATE PROCEDURE SP_RetornoIdPDV
			(
			@idCliente 			INT ,
			@dtPedido			DATETIME 
			)
AS
BEGIN
	SELECT idPDV 
	FROM PDV
	WHERE dtPedido=@dtPedido AND  idCliente=@idCliente
END 

GO

CREATE PROCEDURE SP_ADDDET_PDV
				(
			
			@idPDV 			INT ,
			@idProduto		INT ,
			@QTDE 			SMALLINT ,
			@SubTotal 		MONEY
				)				
AS
BEGIN
	INSERT INTO DET_PDV (idPDV, idProduto, QTDE, SubTotal ) 
	VALUES			(@idPDV, @idProduto, @QTDE, @SubTotal)
END
