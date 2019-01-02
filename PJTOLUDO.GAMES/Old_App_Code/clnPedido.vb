Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class clnPedido


    Private mIdUsuario As Integer
    Public Property IdUsuario As Integer
        Get
            Return mIdUsuario
        End Get
        Set(ByVal value As Integer)
            mIdUsuario = value
        End Set
    End Property

    Private mIdCliente As Integer
    Public Property IdCliente As Integer
        Get
            Return mIdCliente
        End Get
        Set(ByVal value As Integer)
            mIdCliente = value
        End Set
    End Property

    Private mIdCEndereco As Integer
    Public Property IdCEndereco As Integer
        Get
            Return mIdCEndereco
        End Get
        Set(ByVal value As Integer)
            mIdCEndereco = value
        End Set
    End Property

    Private mIdSituacao As Integer
    Public Property IdSituacao As Integer
        Get
            Return mIdSituacao
        End Get
        Set(ByVal value As Integer)
            mIdSituacao = value
        End Set
    End Property

    Private mDtPedido As Date
    Public Property DtPedido As Date
        Get
            Return mDtPedido
        End Get
        Set(ByVal value As Date)
            mDtPedido = value
        End Set
    End Property

    Private mDtEnvio As Date
    Public Property DtEnvio As Date
        Get
            Return mDtEnvio
        End Get
        Set(ByVal value As Date)
            mDtEnvio = value
        End Set
    End Property

    Private mTxEnvio As String
    Public Property TxEnvio As String
        Get
            Return mTxEnvio
        End Get
        Set(ByVal value As String)
            mTxEnvio = value
        End Set
    End Property

    Private mObs As String
    Public Property Obs As String
        Get
            Return mObs
        End Get
        Set(ByVal value As String)
            mObs = value
        End Set
    End Property

    Private mIdTPvenda As Integer
    Public Property IdTPvenda As Integer
        Get
            Return mIdTPvenda
        End Get
        Set(ByVal value As Integer)
            mIdTPvenda = value
        End Set
    End Property

    Private mIdFormaPgto As Integer
    Public Property idFormaPgto As Integer
        Get
            Return mIdFormaPgto
        End Get
        Set(ByVal value As Integer)
            mIdFormaPgto = value
        End Set
    End Property

    Public Sub ADDPDV()
        Dim objCldBD As New cldBD
        Dim prmParametro = New SqlParameter(9) {}
        prmParametro(0) = New SqlParameter("@idUsuario", mIdUsuario)
        prmParametro(1) = New SqlParameter("@idCliente", mIdCliente)
        prmParametro(2) = New SqlParameter("@idCliEnd", mIdCEndereco)
        prmParametro(3) = New SqlParameter("@idSituacao", mIdSituacao)
        prmParametro(4) = New SqlParameter("@dtPedido", mDtPedido)
        prmParametro(5) = New SqlParameter("@dtEnvio", mDtEnvio)
        prmParametro(6) = New SqlParameter("@txEnvio", mTxEnvio)
        prmParametro(7) = New SqlParameter("@obs", mObs)
        prmParametro(8) = New SqlParameter("@idTPvenda", mIdTPvenda)
        prmParametro(9) = New SqlParameter("@idFormaPgto", mIdFormaPgto)

        Dim strQuery As New StringBuilder
        strQuery.Append("SP_ADDPDV")
        objCldBD.ExecutaComandoProcedure(strQuery.ToString, prmParametro)

    End Sub

    Public Function RetornoIdPDV(ByVal id As String, dt As String) As SqlDataReader
        Dim prmParametro = New SqlParameter(1) {}
        prmParametro(0) = New SqlParameter("@idCliente", id)
        prmParametro(1) = New SqlParameter("@dtPedido", dt)
        Dim strQuery As String
        strQuery = "SP_RetornoIdPDV"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataReaderProcedure(strQuery, prmParametro)
    End Function

    Private mIdPDV As Integer
    Public Property IdPDV As Integer
        Get
            Return mIdPDV
        End Get
        Set(ByVal value As Integer)
            mIdPDV = value
        End Set
    End Property

    Private mIdProduto As Integer
    Public Property IdProduto As Integer
        Get
            Return mIdProduto
        End Get
        Set(ByVal value As Integer)
            mIdProduto = value
        End Set
    End Property

    Private mQTDE As Integer
    Public Property QTDE As Integer
        Get
            Return mQTDE
        End Get
        Set(ByVal value As Integer)
            mQTDE = value
        End Set
    End Property

    Private mSubTotal As String
    Public Property SubTotal As String
        Get
            Return mSubTotal
        End Get
        Set(ByVal value As String)
            mSubTotal = value
        End Set
    End Property

    Public Sub ADDDET_PDV()
        Dim objCldBD As New cldBD
        Dim prmParametro = New SqlParameter(3) {}
        prmParametro(0) = New SqlParameter("@idPDV", mIdPDV)
        prmParametro(1) = New SqlParameter("@idProduto", mIdProduto)
        prmParametro(2) = New SqlParameter("@QTDE", mQTDE)
        prmParametro(3) = New SqlParameter("@SubTotal", mSubTotal)

        Dim strQuery As New StringBuilder
        strQuery.Append("SP_ADDDET_PDV")
        objCldBD.ExecutaComandoProcedure(strQuery.ToString, prmParametro)

    End Sub

    Public Function LItemReserva(ByVal id As String, dt As String) As DataSet
        Dim prmParametro = New SqlParameter(1) {}
        prmParametro(0) = New SqlParameter("@idCliente", id)
        prmParametro(1) = New SqlParameter("@dtMovEst", dt)
        Dim strQuery As String
        strQuery = "LItemReserva"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataSETProcedure(strQuery, prmParametro)
    End Function

    Public Function LstDetPed(ByVal idpdv) As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT PRODUTO.nmCompleto, DET_PDV.idDetPDV, DET_PDV.idPDV, DET_PDV.idProduto, DET_PDV.QTDE,  DET_PDV.SubTotal    ")
        strQuery.Append(" FROM PRODUTO, DET_PDV ")
        strQuery.Append(" WHERE PRODUTO.idProduto = DET_PDV.idProduto AND DET_PDV.idPDV = '" & idpdv & "'")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function LstPed(ByVal idpdv) As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" select PDV.idPDV, SITUACAO.nmSituacao, PDV.dtPedido,")
        strQuery.Append("CLIENTE_ENDERECO.PNomeDest, CLIENTE_ENDERECO.UNomeDest, CLIENTE_ENDERECO.DDD,")
        strQuery.Append("CLIENTE_ENDERECO.Telefone, CLIENTE_ENDERECO.noCEP, CLIENTE_ENDERECO.Logradouro, CLIENTE_ENDERECO.Bairro, CLIENTE_ENDERECO.Cidade, CLIENTE_ENDERECO.UF, CLIENTE_ENDERECO.noLog, CLIENTE_ENDERECO.Complemento")
        strQuery.Append(" FROM CLIENTE_ENDERECO, PDV, SITUACAO ")
        strQuery.Append(" WHERE  CLIENTE_ENDERECO.idCliEnd = PDV.idCliEnd AND PDV.idSituacao=SITUACAO.idSituacao AND PDV.idPDV = '" & idpdv & "'")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function LstGeralPed(ByVal id) As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT CLIENTE_ENDERECO.PNomeDest, PDV.idCliente, CLIENTE_ENDERECO.UNomeDest, PDV.idPDV, PDV.dtPedido , SITUACAO.nmSituacao ")
        strQuery.Append(" FROM CLIENTE_ENDERECO, PDV, SITUACAO ")
        strQuery.Append(" WHERE CLIENTE_ENDERECO.idCliEnd = PDV.idCliEnd AND PDV.idSituacao=SITUACAO.idSituacao and PDV.idCliente = '" & id & "'")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function LstFormaPgto() As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT *    ")
        strQuery.Append(" FROM FORMAPGTO ")
        strQuery.Append(" WHERE FORMAPGTO.idFormaPgto > 1")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

End Class
