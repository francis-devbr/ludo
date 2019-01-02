Imports System.Data
Imports System.Data.SqlClient
Imports System.Text

Public Class clnCliente
    Dim objCldBD As New cldBD
    Private mIdCliente As Integer
    Public Property IdCliente As Integer
        Get
            Return mIdCliente
        End Get
        Set(ByVal value As Integer)
            mIdCliente = value
        End Set
    End Property
    Private mPNome As String
    Public Property PNome As String
        Get
            Return mPNome
        End Get
        Set(ByVal value As String)
            mPNome = value
        End Set
    End Property
    Private mUNome As String
    Public Property UNome As String
        Get
            Return mUNome
        End Get
        Set(ByVal value As String)
            mUNome = value
        End Set
    End Property

    Private mCPF As String
    Public Property CPF As String
        Get
            Return mCPF
        End Get
        Set(ByVal value As String)
            mCPF = value
        End Set
    End Property

    Private mEmail As String
    Public Property Email As String
        Get
            Return mEmail
        End Get
        Set(ByVal value As String)
            mEmail = value
        End Set
    End Property
    Private mSenha As String
    Public Property Senha As String
        Get
            Return mSenha
        End Get
        Set(ByVal value As String)
            mSenha = value
        End Set
    End Property
    Private mDtCad As Date
    Public Property DtCad As Date
        Get
            Return mDtCad
        End Get
        Set(ByVal value As Date)
            mDtCad = value
        End Set
    End Property
    Private mAtivo As Boolean
    Public Property Ativo As Boolean
        Get
            Return mAtivo
        End Get
        Set(ByVal value As Boolean)
            mAtivo = value
        End Set
    End Property

    Public Sub AddCliente()
        Dim prmParametro = New SqlParameter(6) {}
        prmParametro(0) = New SqlParameter("@PNome", mPNome)
        prmParametro(1) = New SqlParameter("@UNome", mUNome)
        prmParametro(2) = New SqlParameter("@CPF", mCPF)
        prmParametro(3) = New SqlParameter("@Email", mEmail)
        prmParametro(4) = New SqlParameter("@Senha", mSenha)
        prmParametro(5) = New SqlParameter("@DtCad", mDtCad)
        prmParametro(6) = New SqlParameter("@Ativo", mAtivo)
        Dim strQuery As New StringBuilder
        strQuery.Append("SP_AddCliente")
        objCldBD.ExecutaComandoProcedure(strQuery.ToString, prmParametro)

    End Sub

    Public Function ValidarUsuario(ByVal Email As String, ByVal Senha As String) As SqlDataReader
        Dim prmParametro = New SqlParameter(1) {}
        prmParametro(0) = New SqlParameter("@Email", Email)
        prmParametro(1) = New SqlParameter("@Senha", Senha)

        Dim strQuery As String
        strQuery = "SP_ValidaCliente"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataReaderProcedure(strQuery, prmParametro)
    End Function

    Public Function ValidarUsuario2(ByVal id As String, ByVal Senha As String) As SqlDataReader
        Dim prmParametro = New SqlParameter(1) {}
        prmParametro(0) = New SqlParameter("@idCliente", id)
        prmParametro(1) = New SqlParameter("@Senha", Senha)

        Dim strQuery As String
        strQuery = "SP_ValidaCliente2"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataReaderProcedure(strQuery, prmParametro)
    End Function

    Public Sub UpdtCliente()
        Dim prmParametro = New SqlParameter(5) {}
        prmParametro(0) = New SqlParameter("@PNome", mPNome)
        prmParametro(1) = New SqlParameter("@UNome", mUNome)
        prmParametro(2) = New SqlParameter("@Email", mEmail)
        prmParametro(3) = New SqlParameter("@Senha", mSenha)
        prmParametro(4) = New SqlParameter("@idCliente", mIdCliente)
        prmParametro(5) = New SqlParameter("@Ativo", mAtivo)

        Dim strQuery As New StringBuilder
        strQuery.Append("SP_UpdtCliente")
        objCldBD.ExecutaComandoProcedure(strQuery.ToString, prmParametro)

    End Sub

   
    Private mPNomeDest As String
    Public Property PNomeDest As String
        Get
            Return mPNomeDest
        End Get
        Set(ByVal value As String)
            mPNomeDest = value
        End Set
    End Property

    Private mUNomeDest As String
    Public Property UNomeDest As String
        Get
            Return mUNomeDest
        End Get
        Set(ByVal value As String)
            mUNomeDest = value
        End Set
    End Property

    Private mDDD As String
    Public Property DDD As String
        Get
            Return mDDD
        End Get
        Set(ByVal value As String)
            mDDD = value
        End Set
    End Property

    Private mTelefone As String
    Public Property Telefone As String
        Get
            Return mTelefone
        End Get
        Set(ByVal value As String)
            mTelefone = value
        End Set
    End Property

    Private mNoCEP As String
    Public Property NoCEP As String
        Get
            Return mNoCEP
        End Get
        Set(ByVal value As String)
            mNoCEP = value
        End Set
    End Property

    Private mLogradouro As String
    Public Property Logradouro As String
        Get
            Return mLogradouro
        End Get
        Set(ByVal value As String)
            mLogradouro = value
        End Set
    End Property

    Private mBairro As String
    Public Property Bairro As String
        Get
            Return mBairro
        End Get
        Set(ByVal value As String)
            mBairro = value
        End Set
    End Property

    Private mCidade As String
    Public Property Cidade As String
        Get
            Return mCidade
        End Get
        Set(ByVal value As String)
            mCidade = value
        End Set
    End Property

    Private mUF As String
    Public Property UF As String
        Get
            Return mUF
        End Get
        Set(ByVal value As String)
            mUF = value
        End Set
    End Property

    Private mNoLog As String
    Public Property NoLog As String
        Get
            Return mNoLog
        End Get
        Set(ByVal value As String)
            mNoLog = value
        End Set
    End Property

    Private mComplemento As String
    Public Property Complemento As String
        Get
            Return mComplemento
        End Get
        Set(ByVal value As String)
            mComplemento = value
        End Set
    End Property

    Private mPEntrega As Boolean
    Public Property PEntrega As Boolean
        Get
            Return mPEntrega
        End Get
        Set(ByVal value As Boolean)
            mPEntrega = value
        End Set
    End Property

    Public Function LEndPadrao(ByVal id As String, ByVal pEnt As String, ByVal idCEnd As String) As SqlDataReader
        Dim prmParametro = New SqlParameter(2) {}
        prmParametro(0) = New SqlParameter("@idCliente", id)
        prmParametro(1) = New SqlParameter("@PEntrega", pEnt)
        prmParametro(2) = New SqlParameter("@idCliEnd", idCEnd)
        Dim strQuery As String
        strQuery = "SP_LEndPadrao"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataReaderProcedure(strQuery, prmParametro)
    End Function

    Public Function LEndDataList(ByVal id As String, ByVal pEnt As String) As SqlDataReader
        Dim prmParametro = New SqlParameter(1) {}
        prmParametro(0) = New SqlParameter("@idCliente", id)
        prmParametro(1) = New SqlParameter("@PEntrega", pEnt)
        Dim strQuery As String
        strQuery = "SP_LEnd"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataReaderProcedure(strQuery, prmParametro)
    End Function


    Public Sub AddCliEnd()
        Dim prmParametro = New SqlParameter(14) {}
        prmParametro(0) = New SqlParameter("@idCliente", mIdCliente)
        prmParametro(1) = New SqlParameter("@PNomeDest", mPNomeDest)
        prmParametro(2) = New SqlParameter("@UNomeDest", mUNomeDest)
        prmParametro(3) = New SqlParameter("@DDD", mDDD)
        prmParametro(4) = New SqlParameter("@Telefone", mTelefone)
        prmParametro(5) = New SqlParameter("@Logradouro", mLogradouro)
        prmParametro(6) = New SqlParameter("@Bairro", mBairro)
        prmParametro(7) = New SqlParameter("@Cidade", mCidade)
        prmParametro(8) = New SqlParameter("@UF", mUF)
        prmParametro(9) = New SqlParameter("@noLog", mNoLog)
        prmParametro(10) = New SqlParameter("@Complemento", mComplemento)
        prmParametro(11) = New SqlParameter("@PEntrega", mPEntrega)
        prmParametro(12) = New SqlParameter("@DtCad", mDtCad)
        prmParametro(13) = New SqlParameter("@Ativo", mAtivo)
        prmParametro(14) = New SqlParameter("@noCEP ", mNoCEP)
        Dim strQuery As New StringBuilder
        strQuery.Append("SP_AddCliEnd")
        objCldBD.ExecutaComandoProcedure(strQuery.ToString, prmParametro)

    End Sub

    Public Sub AtualizaCliEnd(Optional id = "")
        Dim strQuery As New StringBuilder
        strQuery.Append("UPDATE CLIENTE_ENDERECO")
        strQuery.Append(" SET ")
        strQuery.Append("PEntrega = '" & mPEntrega & "'")
        strQuery.Append("WHERE ")
        strQuery.Append(id)
        Dim objCldBD As New cldBD
        objCldBD.ExecutaComando(strQuery.ToString)
    End Sub

    Public Sub AtualizaCliEndDados(Optional id = "")
        Dim strQuery As New StringBuilder
        strQuery.Append("UPDATE CLIENTE_ENDERECO")
        strQuery.Append(" SET ")
        strQuery.Append("PNomeDest = '" & mPNomeDest & "'")
        strQuery.Append(" ,UNomeDest = '" & mUNomeDest & "'")
        strQuery.Append(" ,DDD = '" & mDDD & "'")
        strQuery.Append(" ,Telefone = '" & mTelefone & "'")
        strQuery.Append(" ,noCEP = '" & mNoCEP & "'")
        strQuery.Append(" ,Logradouro = '" & mLogradouro & "'")
        strQuery.Append(" ,Bairro = '" & mBairro & "'")
        strQuery.Append(" ,Cidade = '" & mCidade & "'")
        strQuery.Append(" ,UF = '" & mUF & "'")
        strQuery.Append(" ,noLog = '" & mNoLog & "'")
        strQuery.Append(" ,Complemento = '" & mComplemento & "'")
        strQuery.Append(" ,PEntrega = '" & mPEntrega & "'")
        strQuery.Append(" ,Ativo = '" & mAtivo & "'")
        strQuery.Append(" WHERE ")
        strQuery.Append(id)
        Dim objCldBD As New cldBD
        objCldBD.ExecutaComando(strQuery.ToString)
    End Sub

    Public Sub ApagaEndereco(ByVal idCliEnd As Integer)
        Dim strQuery As New StringBuilder
        strQuery.Append("DELETE FROM CLIENTE_ENDERECO")
        strQuery.Append(" WHERE idCliEnd = '" & idCliEnd & "'")
        Dim objCldBD As New cldBD
        objCldBD.ExecutaComando(strQuery.ToString)
    End Sub

    Public Function ListaEndFinal(ByVal idCliEnd As Integer) As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append("Select * FROM CLIENTE_ENDERECO")
        strQuery.Append(" WHERE idCliEnd = '" & idCliEnd & "'")
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function VerificaEmail(ByVal idemail As String) As SqlDataReader
        Dim strQuery As New StringBuilder
        strQuery.Append("SELECT idCliente, PNome, UNome, CPF, Email, Senha FROM CLIENTE")
        strQuery.Append(" WHERE Email = '" & idemail & "'")
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataReader(strQuery.ToString)
    End Function

    Public Function VerificaCPF(ByVal idCPF As String) As SqlDataReader
        Dim strQuery As New StringBuilder
        strQuery.Append("SELECT idCliente, PNome, UNome, CPF, Email, Senha FROM CLIENTE")
        strQuery.Append(" WHERE CPF = '" & idCPF & "'")
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataReader(strQuery.ToString)
    End Function


End Class
