Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class clnEstoque
    Private mIdCliente As Integer
    Public Property IdCliente As Integer
        Get
            Return mIdCliente
        End Get
        Set(ByVal value As Integer)
            mIdCliente = value
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

    Private mQtde As Integer
    Public Property Qtde As Integer
        Get
            Return mQtde
        End Get
        Set(ByVal value As Integer)
            mQtde = value
        End Set
    End Property

    Private mIdTPMe As Integer
    Public Property IdTPMe As Integer
        Get
            Return mIdTPMe
        End Get
        Set(ByVal value As Integer)
            mIdTPMe = value
        End Set
    End Property

    Private mIdDetMe As Integer
    Public Property IdDetMe As Integer
        Get
            Return mIdDetMe
        End Get
        Set(ByVal value As Integer)
            mIdDetMe = value
        End Set
    End Property

    Private mDtMovEst As String
    Public Property DtMovEst As String
        Get
            Return mDtMovEst
        End Get
        Set(ByVal value As String)
            mDtMovEst = value
        End Set
    End Property

    Private mDtMod As String
    Public Property DtMod As String
        Get
            Return mDtMod
        End Get
        Set(ByVal value As String)
            mDtMod = value
        End Set
    End Property

    Private mIdPDV As Integer
    Public Property IdPDV As Integer
        Get
            Return mIdPDV
        End Get
        Set(ByVal value As Integer)
            mIdPDV = value
        End Set
    End Property


    Public Sub ReservaPedido()
        Dim objCldBD As New cldBD
        Dim prmParametro = New SqlParameter(5) {}
        prmParametro(0) = New SqlParameter("@idCliente", mIdCliente)
        prmParametro(1) = New SqlParameter("@IdProduto", mIdProduto)
        prmParametro(2) = New SqlParameter("@Qtde", mQtde)
        prmParametro(3) = New SqlParameter("@IdTPMe", mIdTPMe)
        prmParametro(4) = New SqlParameter("@IdDetMe", mIdDetMe)
        prmParametro(5) = New SqlParameter("@DtMovEst", mDtMovEst)
        Dim strQuery As New StringBuilder
        strQuery.Append("SP_RsvPedidoNet")
        objCldBD.ExecutaComandoProcedure(strQuery.ToString, prmParametro)

    End Sub

    Public Sub AtualizaMovEst()
        Dim strQuery As New StringBuilder
        strQuery.Append("UPDATE MOV_EST")
        strQuery.Append(" SET ")
        strQuery.Append("idPDV = '" & mIdPDV & "'")
        strQuery.Append(", idTPMe = '" & mIdTPMe & "'")
        strQuery.Append(", dtMod = '" & mDtMod & "'")
        strQuery.Append("WHERE ")
        strQuery.Append("idCliente = '" & mIdCliente & "'")
        strQuery.Append(" AND dtMovEst = '" & mDtMovEst & "'")
        Dim objCldBD As New cldBD
        objCldBD.ExecutaComando(strQuery.ToString)
    End Sub


    Public Function RetornoIDReserva(ByVal id As Integer, ByVal dt As String) As SqlDataReader
        Dim prmParametro = New SqlParameter(1) {}
        prmParametro(0) = New SqlParameter("@idCliente", id)
        prmParametro(1) = New SqlParameter("@dtMovEst", dt)
        Dim strQuery As String
        strQuery = "sp_RetCodReserva"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataReaderProcedure(strQuery, prmParametro)
    End Function

    
End Class