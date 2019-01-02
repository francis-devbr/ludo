CREATE FUNCTION formatarCPF
(
		@cpf CHAR(11) 
)
		RETURNS CHAR(14) 
		
		AS
        BEGIN 
			DECLARE @retorno VARCHAR(14) 
			SET @retorno = SUBSTRING(@cpf,1,3) + '.' + SUBSTRING(@cpf,4,3) + '.' + SUBSTRING(@cpf,7,3) + '-' + SUBSTRING(@cpf,10,2)  
            RETURN @retorno 
       END
                
CREATE FUNCTION formatarCNPJ
(
		@cnpj CHAR(14)
)		
        RETURNS CHAR(18) 
        AS
        BEGIN 
            DECLARE @retorno VARCHAR(18) 
            SET @retorno = SUBSTRING(@cnpj,1,2) + '.' + SUBSTRING(@cnpj,3,3) + '.' + SUBSTRING(@cnpj,6,3) + '/' + SUBSTRING(@cnpj,9,4) + '-' + SUBSTRING(@cnpj,13,2) 
            RETURN @retorno 
        END


CREATE FUNCTION formatarIE
(
		@IE CHAR(12)
)	
        RETURNS CHAR(15) 
        AS
        BEGIN
            DECLARE @retorno VARCHAR(15) 
            SET @retorno = SUBSTRING(@IE,1,3) + '.' + SUBSTRING(@IE,4,3) + '.' + SUBSTRING(@IE,7,3) + '.' + SUBSTRING(@IE,10,3)  
            RETURN @retorno 
		END

CREATE FUNCTION formatarTel
(
		@Tel CHAR(12) 
)		
        RETURNS CHAR(15) 
        AS
        BEGIN
            DECLARE @retorno VARCHAR(15) 
			SET @retorno = SUBSTRING(@Tel,1,4) + '-' + SUBSTRING(@Tel,5,4)
			RETURN @retorno 
		END
		
CREATE FUNCTION formatarCEP
(
		@CEP CHAR(12) 
)		
        RETURNS CHAR(15) 
        AS
        BEGIN
            DECLARE @retorno VARCHAR(15) 
			SET @retorno = SUBSTRING(@CEP,1,5) + '-' + SUBSTRING(@CEP,6,3)
			RETURN @retorno 
		END