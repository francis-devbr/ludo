Imports System.Data.SqlClient
Imports System.Web.Security
Imports System.Configuration
Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Enviar_Click(sender As Object, e As System.EventArgs) Handles Enviar.Click

        Dim objClsCliente As New clnCliente
        Dim drDados As SqlDataReader
        drDados = objClsCliente.ValidarUsuario(email.Text.Trim, Protege.GeraHash(pass.Text.Trim))

        If drDados.HasRows Then
            While drDados.Read()
                FormsAuthentication.Initialize()

                Dim strPerfil As String = "cliente"
                Dim fat As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, _
                                                                            email.Text, DateTime.Now, _
                                                                            DateTime.Now.AddMinutes(20), False, strPerfil, _
                                                                            FormsAuthentication.FormsCookiePath)
                Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat)))
                Response.Cookies("pDados")("ID") = Protege.Criptografar(drDados.Item("idCliente"))
                Response.Cookies("pDados")("Nome") = Protege.Criptografar(drDados.Item("PNome"))
                Response.Cookies("pDados")("Sobrenome") = Protege.Criptografar(drDados.Item("UNome"))
                Response.Cookies("pDados")("CPF") = Protege.Criptografar(drDados.Item("CPF"))
                Response.Cookies("pDados")("Email") = Protege.Criptografar(drDados.Item("Email"))
                Session("Logado") = 1
                Response.Redirect(FormsAuthentication.GetRedirectUrl(email.Text, False))

            End While

        Else
            Response.Redirect("~\Livre\NovoUsuario.aspx")
        End If

    End Sub

End Class