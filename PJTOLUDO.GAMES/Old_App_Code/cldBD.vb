Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class cldBD

    Public StringConexao As String = "Server=.;Database=PJLUDOIV;UID=sa;PWD=;"

    Public Function AbreBanco() As SqlConnection
        Dim Conn As New SqlConnection
        Try
            With Conn
                .ConnectionString = StringConexao
                .Open()
            End With
            Return Conn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub FechaBanco(ByVal Conn As SqlConnection)
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Public Sub ExecutaComando(ByVal strQuery As String)
        Dim Conn As New SqlConnection
        Try
            Conn = AbreBanco()

            Dim cmdComando As New SqlCommand
            With cmdComando
                .CommandText = strQuery
                .CommandType = CommandType.Text
                .Connection = Conn
                .ExecuteNonQuery()
            End With


            'Catch ex As SqlException

            'If ex.Number = 2627 Then
            'MsgBox(" Você inseriu um valor que já existe cadastro no banco" & Campo)
            'Exit Sub
            'End If
        Catch ex As Exception
            'Throw ex
            Throw New Exception("Erro na Camada1: " & ex.Message)
        Finally
            FechaBanco(Conn)
        End Try


    End Sub

    Public Function RetornaDataSet(ByVal strQuery As String) As DataSet 'Funcao para retornar um DataSet a partir de um Query SQL

        Dim Conn As New SqlConnection
        Try
            Conn = AbreBanco()
            Dim cmdComando As New SqlCommand
            With cmdComando
                .CommandText = strQuery
                .CommandType = CommandType.Text
                .Connection = Conn
            End With

            Dim daAdaptador As New SqlDataAdapter
            Dim dsDataSet As New DataSet
            daAdaptador.SelectCommand = cmdComando
            daAdaptador.Fill(dsDataSet)
            Return dsDataSet

        Catch ex As Exception
            Throw New Exception("Erro na Camada1: " & ex.Message)
        Finally
            FechaBanco(Conn)
        End Try
    End Function

    Public Function RetornaDataReader(ByVal strQuery As String) As SqlDataReader
        Dim Conn As New SqlConnection
        Try
            Conn = AbreBanco()
            Dim cmdComando As New SqlCommand
            With cmdComando
                .CommandText = strQuery
                .CommandType = CommandType.Text
                .Connection = Conn
            End With
            Return cmdComando.ExecuteReader
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub ExecutaComandoProcedure(ByVal strQuery As String, ByVal prmParametro As Array)
        Dim Conn As New SqlConnection
        Try
            Conn = AbreBanco()

            Dim cmdComando As New SqlCommand
            Dim p As SqlParameter
            For Each p In prmParametro
                cmdComando.Parameters.Add(p)
            Next
            With cmdComando
                .CommandText = strQuery
                .CommandType = CommandType.StoredProcedure
                .Connection = Conn
                .ExecuteNonQuery()
            End With


            'Catch ex As SqlException

            'If ex.Number = 2627 Then
            'MsgBox(" Você inseriu um valor que já existe cadastro no banco" & Campo)
            'Exit Sub
            'End If
        Catch ex As Exception
            'Throw ex
            Throw New Exception("Erro na Camada1: " & ex.Message)
        Finally
            FechaBanco(Conn)
        End Try


    End Sub
    Public Function RetornaDataReaderProcedure(ByVal strQuery As String, ByVal prmParametro As Array) As SqlDataReader
        Dim Conn As New SqlConnection
        Try
            Conn = AbreBanco()
            Dim cmdComando As New SqlCommand
            Dim p As SqlParameter
            For Each p In prmParametro
                cmdComando.Parameters.Add(p)
            Next
            With cmdComando
                .CommandText = strQuery
                .CommandType = CommandType.StoredProcedure
                .Connection = Conn
            End With
            Return cmdComando.ExecuteReader
        Catch ex As Exception
            Throw ex
        End Try
    End Function


    Public Function RetornaDataSETProcedure(ByVal strQuery As String, ByVal prmParametro As Array) As DataSet
        Dim Conn As New SqlConnection
        Try
            Conn = AbreBanco()
            Dim cmdComando As New SqlCommand
            Dim p As SqlParameter
            For Each p In prmParametro
                cmdComando.Parameters.Add(p)
            Next
            With cmdComando
                .CommandText = strQuery
                .CommandType = CommandType.StoredProcedure
                .Connection = Conn
            End With

            Dim daAdaptador As New SqlDataAdapter
            Dim dsDataSet As New DataSet
            daAdaptador.SelectCommand = cmdComando
            daAdaptador.Fill(dsDataSet)
            Return dsDataSet

        Catch ex As Exception
            Throw New Exception("Erro na Camada1: " & ex.Message)
        Finally
            FechaBanco(Conn)
        End Try
    End Function
End Class
