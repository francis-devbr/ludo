Imports System.Data.SqlClient
Public Class NovoUsuario
    Inherits System.Web.UI.Page
    Dim drDados As SqlDataReader
    Dim drDados2 As SqlDataReader

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim objClsCliente As New clnCliente

        drDados = objClsCliente.VerificaEmail(email_address.Text.Trim)
        drDados2 = objClsCliente.VerificaCPF(txtCPF.Text.Trim)
        If drDados2.HasRows Then
            ltInfoConta.Text = "<ul class='messages'><li class='error-msg'><ul><li><span>Este CPF já esta em uso</span></li></ul></li></ul>"
            txtCPF.Text = ""
            txtCPF.Focus()
            Exit Sub
        End If
        If drDados.HasRows Then
            ltInfoConta.Text = "<ul class='messages'><li class='error-msg'><ul><li><span>Este e-mail já esta em uso</span></li></ul></li></ul>"
            email_address.Text = ""
            email_address.Focus()
            Exit Sub
        Else
            With objClsCliente
                .PNome = Me.firstname.Text.ToString.Trim
                .UNome = Me.lastname.Text.ToString.Trim
                .CPF = Me.txtCPF.Text.ToString.Trim
                .Email = Me.email_address.Text.ToString.ToLower.Trim
                .Senha = Protege.GeraHash(Me.password.Text.Trim)
                .DtCad = DateTime.Now
                .Ativo = 1
                .AddCliente()
            End With

            drDados = objClsCliente.ValidarUsuario(email_address.Text.Trim, Protege.GeraHash(password.Text.Trim))

            If drDados.HasRows Then
                While drDados.Read()
                    FormsAuthentication.Initialize()

                    Dim strPerfil As String = "cliente"
                    Dim fat As FormsAuthenticationTicket = New FormsAuthenticationTicket(1, _
                                                                                email_address.Text, DateTime.Now, _
                                                                                DateTime.Now.AddMinutes(20), False, strPerfil, _
                                                                                FormsAuthentication.FormsCookiePath)
                    Response.Cookies.Add(New HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat)))
                    Response.Cookies("pDados")("ID") = Protege.Criptografar(drDados.Item("idCliente"))
                    Response.Cookies("pDados")("Nome") = Protege.Criptografar(drDados.Item("PNome"))
                    Response.Cookies("pDados")("Sobrenome") = Protege.Criptografar(drDados.Item("UNome"))
                    Response.Cookies("pDados")("CPF") = Protege.Criptografar(drDados.Item("CPF"))
                    Response.Cookies("pDados")("Email") = Protege.Criptografar(drDados.Item("Email"))
                    Session("Logado") = 1
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(email_address.Text, False))

                End While

            Else
                ltInfoConta.Text = "<ul class='messages'><li class='error-msg'><ul><li><span>Erro ao cadastrar</span></li></ul></li></ul>"
            End If
        End If

    End Sub
End Class