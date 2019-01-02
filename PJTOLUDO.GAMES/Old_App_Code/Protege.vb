Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class Protege
    Private Shared chave As Byte() = {}
    Private Shared iv As Byte() = {12, 34, 56, 78, 90, 102, 114, 126}
    Private Shared chaveCriptografia = "#!$a36?@"
    Public Shared Function GeraHash(ByVal texto As String) As String

        'Cria um objeto enconding para assegurar o padrão
        'de encondig para o texto origem
        Dim Ue As New UnicodeEncoding()
        'Retorna um byte array baseado no texto origem
        Dim ByteSourceText() As Byte = Ue.GetBytes(texto)
        'Instancia um objeto MD5
        Dim Md5 As New MD5CryptoServiceProvider()
        'Calcula o valor do hash para o texto origem
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        'Converte o valor obtido para o formato string
        Return Convert.ToBase64String(ByteHash)
    End Function
    Public Shared Function Criptografar(valor As String) As String
        Dim des As DESCryptoServiceProvider
        Dim ms As MemoryStream
        Dim cs As CryptoStream
        Dim input As Byte()

        Try
            des = New DESCryptoServiceProvider()
            ms = New MemoryStream()

            input = Encoding.UTF8.GetBytes(valor)
            chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8))

            cs = New CryptoStream(ms, des.CreateEncryptor(chave, iv), CryptoStreamMode.Write)
            cs.Write(input, 0, input.Length)
            cs.FlushFinalBlock()

            Return Convert.ToBase64String(ms.ToArray())
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function Descriptografar(valor As String) As String

        Dim des As DESCryptoServiceProvider
        Dim ms As MemoryStream
        Dim cs As CryptoStream
        Dim input As Byte()

        Try

            des = New DESCryptoServiceProvider()
            ms = New MemoryStream()

            input = New Byte(valor.Length - 1) {}
            input = Convert.FromBase64String(valor.Replace(" ", "+"))

            chave = Encoding.UTF8.GetBytes(chaveCriptografia.Substring(0, 8))

            cs = New CryptoStream(ms, des.CreateDecryptor(chave, iv), CryptoStreamMode.Write)
            cs.Write(input, 0, input.Length)
            cs.FlushFinalBlock()

            Return Encoding.UTF8.GetString(ms.ToArray())
        Catch ex As Exception
            Throw ex
        End Try

        
    End Function


    Public Shared Function BuscaCep(ByVal cep As String) As DataSet
        Dim ds As DataSet
        ds = New DataSet()
        ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep.Replace("-", "").Trim() + "&formato=xml")
        Return ds

    End Function
    Public Shared Function ExisteConexaoInternet(ByVal url As String) As Boolean
        'Define uma URL valida para consultar
        Dim HomePage As New System.Uri(url)
        'Monta a requisisão HTTP
        Dim req As System.Net.WebRequest

        req = System.Net.WebRequest.Create(HomePage)

        'Tenta fazer a requisisão
        Try
            Dim resp As System.Net.WebResponse
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            'Tudo certo... Temos conexão com a Internet
            Return True
        Catch

            req = Nothing

            'Não há conexão
            Return False

        End Try
    End Function

    Public Shared Function CarregaUF() As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT cdUF, sgUF ")
        strQuery.Append(" FROM UF ")
        strQuery.Append(" ORDER BY sgUF ")

        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)

    End Function

    Public Shared Function BuscaCEPBD(ByVal CEP As String) As SqlDataReader 'Retornar um DataReader com a pesquisa pelo código
        Dim strQuery As String
        strQuery = " SELECT noCEP, nmLogradouro, nmBairro,nmCidade, sgUF FROM (UF INNER JOIN CIDADE ON UF.cdUF = CIDADE.cdUF)INNER JOIN BAIRRO ON (CIDADE.cdCidade=BAIRRO.cdCidade) INNER JOIN LOGRADOURO ON (BAIRRO.cdBairro = LOGRADOURO.cdBairro) WHERE noCEP='" & CEP & "'"
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataReader(strQuery)

    End Function

End Class
