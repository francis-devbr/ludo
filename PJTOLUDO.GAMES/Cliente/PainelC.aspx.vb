Imports System.Data.SqlClient

Public Class PainelC
    Inherits System.Web.UI.Page
    Dim objClsCliente As New clnCliente
    Dim objClsPedido As New clnPedido
    Dim drDados As SqlDataReader

    Private Sub PreencheDadosPessoais()

        Dim Nome As String = Protege.Descriptografar(Request.Cookies("pDados")("Nome"))
        Dim Sobrenome As String = Protege.Descriptografar(Request.Cookies("pDados")("Sobrenome"))
        Dim Email As String = Protege.Descriptografar(Request.Cookies("pDados")("Email"))

        lblOla.Text = Nome
        firstname.Text = Nome
        lastname.Text = Sobrenome
        email_address.Text = Email

        ltDadosPessoais.Text = Nome & " "
        ltDadosPessoais.Text = ltDadosPessoais.Text & Sobrenome & "<br/>"
        ltDadosPessoais.Text = ltDadosPessoais.Text & Email & "<br/><br/>"


    End Sub
    Private Sub PreencheEndereco(ByVal idpad As Integer, idCEnd As Integer)
        

        Dim id As Integer = Protege.Descriptografar(Request.Cookies("pDados")("ID"))

        drDados = objClsCliente.LEndPadrao(id, idpad, idCEnd)
        If drDados.HasRows Then
            While drDados.Read()
                Session("idEndereco") = drDados.Item("idCliEnd")
                txtPNomeDest.Text = drDados.Item("PNomeDest")
                txtUNomeDest.Text = drDados.Item("UNomeDest")
                txtDDD.Text = drDados.Item("DDD")
                txtTelefone.Text = drDados.Item("Telefone")
                txtCep.Text = drDados.Item("noCEP")
                txtNo.Text = drDados.Item("noLog")
                txtComplemento.Text = drDados.Item("Complemento")
                primary_shipping.Checked = drDados.Item("PEntrega")
                txtLogradouro.Text = drDados.Item("Logradouro")
                txtBairro.Text = drDados.Item("Bairro")
                txtCidade.Text = drDados.Item("Cidade")
                txtUF.Text = drDados.Item("UF")
            End While
            primary_shipping.Visible = True
            ltEndPad.Visible = False
        Else
            ltEndPad.Text = "Não há Endereço de Entrega Padrão Cadastrado no Momento"
            Session("idEndereco") = Nothing
            primary_shipping.Visible = False
        End If

    End Sub
    Private Sub PreencherDTlistEnder(ByVal idpad As Integer)

        Dim id As Integer = Protege.Descriptografar(Request.Cookies("pDados")("ID"))

        If idpad = 0 Then
            dtEnderecos.DataSource = objClsCliente.LEndDataList(id, idpad)
            dtEnderecos.DataBind()
            If dtEnderecos.Items.Count = 0 Then
                ltOutrosEndVazio.Text = "Não há Outros Endereços de Entrega Cadastrados no Momento"
            Else
                ltOutrosEndVazio.Text = ""
            End If
        ElseIf idpad = 1 Then

            dtPadrao.DataSource = objClsCliente.LEndDataList(id, idpad)
            dtPadrao.DataBind()

            If dtPadrao.Items.Count = 0 Then
                ltEndPadVazio.Text = "Não há Endereço de Entrega Padrão Cadastrado no Momento"
            Else
                ltEndPadVazio.Text = ""
            End If

            DtLEPadraoPrincipal.DataSource = objClsCliente.LEndDataList(id, idpad)
            DtLEPadraoPrincipal.DataBind()

            If DtLEPadraoPrincipal.Items.Count = 0 Then
                ltEndPad.Text = "Não há Endereço de Entrega Padrão Cadastrado no Momento"
            Else
                ltEndPad.Text = ""
            End If
            
        End If

    End Sub
    Private Sub CarregarDados()
        PreencherDTlistEnder(0)
        PreencherDTlistEnder(1)
        PreencheDadosPessoais()
    End Sub
    Private Sub PreencherPDV(ByVal idpdv As Integer)


        gvDetPDV.DataSource = objClsPedido.LstDetPed(idpdv)
        gvDetPDV.DataBind()
        dtPDV.DataSource = objClsPedido.LstPed(idpdv)
        dtPDV.DataBind()

    End Sub

    Private Sub PreencherGeralPDV()

        Dim id As Integer = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        gvGeralPDV.DataSource = objClsPedido.LstGeralPed(id)
        gvGeralPDV.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CarregarDados()
        End If

    End Sub

    Protected Sub lbPainel_Click(sender As Object, e As EventArgs) Handles lbPainel.Click
        mvPainelControle.ActiveViewIndex = 0
    End Sub

    Protected Sub lbInfoConta_Click(sender As Object, e As EventArgs) Handles lbInfoConta.Click, lbEditInfoCont.Click
        mvPainelControle.ActiveViewIndex = 1
    End Sub

    Protected Sub lbEndereco_Click(sender As Object, e As EventArgs) Handles lbEndereco.Click, lbGerEnder.Click
        mvPainelControle.ActiveViewIndex = 2
    End Sub

    Protected Sub lbPedido_Click(sender As Object, e As EventArgs) Handles lbPedido.Click
        mvPainelControle.ActiveViewIndex = 4
    End Sub
    Public Sub Limpar(ByVal controlP As Control)

        Dim ctl As Control

        For Each ctl In controlP.Controls

            If TypeOf ctl Is TextBox Then

                DirectCast(ctl, TextBox).Text = String.Empty

            ElseIf ctl.Controls.Count > 0 Then

                Limpar(ctl)

            End If

        Next

    End Sub

    Protected Sub btnAddEnder_Click(sender As Object, e As EventArgs) Handles btnAddEnder.Click
        mvPainelControle.ActiveViewIndex = 3
        ltEndereco.Text = "<b><b>Adicionar</b></b> Novo Endereço"
        txtPNomeDest.Focus()
        Me.Limpar(Me)
        Button1.Text = "Enviar"
        Me.ddEstado.DataSource = Protege.CarregaUF.Tables(0)
        Me.ddEstado.DataTextField = "sgUF"
        Me.ddEstado.DataValueField = "sgUF"
        Me.ddEstado.DataBind()
    End Sub

    Protected Sub lbMudarSenha_Click(sender As Object, e As EventArgs) Handles lbMudarSenha.Click
        change_password.Checked = True
        Panel1.Visible = True
        mvPainelControle.ActiveViewIndex = 1
        current_password.Focus()

    End Sub

    Protected Sub change_password_CheckedChanged(sender As Object, e As EventArgs) Handles change_password.CheckedChanged
        If change_password.Checked = True Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub

    Private Sub vInfoConta_Deactivate(sender As Object, e As System.EventArgs) Handles vInfoConta.Deactivate
        Panel1.Visible = False
        change_password.Checked = False
        ltInfoConta.Text = ""
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim IdCliente As String = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        If Button1.Text <> "Salvar Alterações" Then
            With objClsCliente
                .IdCliente = IdCliente
                .PNomeDest = txtPNomeDest.Text.ToString.Trim
                .UNomeDest = txtUNomeDest.Text.ToString.Trim
                .DDD = txtDDD.Text.ToString.Trim
                .Telefone = txtTelefone.Text.ToString.Trim
                .NoCEP = txtCep.Text.ToString.Trim
                .Logradouro = txtLogradouro.Text.ToString.Trim
                .Bairro = txtBairro.Text.ToString.Trim
                .Cidade = txtCidade.Text.ToString.Trim
                .UF = txtUF.Text
                .NoLog = txtNo.Text.ToString.Trim
                .Complemento = txtComplemento.Text.ToString.Trim
                .DtCad = DateAndTime.Now
                .Ativo = 1
                If Session("idEndereco") Is Nothing Then
                    .PEntrega = 1
                    .AddCliEnd()
                Else

                    If primary_shipping.Checked = True Then
                        .PEntrega = 0
                        .AtualizaCliEnd(" idCliente = '" & IdCliente & "'")
                        .PEntrega = 1
                        .AddCliEnd()
                    Else
                        .PEntrega = 0
                        .AddCliEnd()
                    End If
                End If

            End With

            ltMensagem.Text = "<ul class='messages'><li class='success-msg'><ul><li><span>O endereço foi salvo.</span></li></ul></li></ul>"
        Else
            With objClsCliente
                .IdCliente = IdCliente
                .PNomeDest = txtPNomeDest.Text.ToString.Trim
                .UNomeDest = txtUNomeDest.Text.ToString.Trim
                .DDD = txtDDD.Text.ToString.Trim
                .Telefone = txtTelefone.Text.ToString.Trim
                .NoCEP = txtCep.Text.ToString.Trim
                .Logradouro = txtLogradouro.Text.ToString.Trim
                .Bairro = txtBairro.Text.ToString.Trim
                .Cidade = txtCidade.Text.ToString.Trim
                .UF = txtUF.Text
                .NoLog = txtNo.Text.ToString.Trim
                .Complemento = txtComplemento.Text.ToString.Trim
                .Ativo = 1

                If primary_shipping.Checked = True Then
                    .PEntrega = 0
                    .AtualizaCliEnd("idCliente = '" & IdCliente & "'")
                    .PEntrega = 1
                    .AtualizaCliEndDados(" idCliEnd=" & Session("idEndCli"))

                Else
                    .PEntrega = 0
                    .AtualizaCliEndDados(" idCliEnd=" & Session("idEndCli"))
                End If

                ltMensagem.Text = "<ul class='messages'><li class='success-msg'><ul><li><span>O endereço foi alterado com sucesso.</span></li></ul></li></ul>"

            End With
        End If

        CarregarDados()
        mvPainelControle.ActiveViewIndex = 2

    End Sub

    Private Sub vLEnder_Deactivate(sender As Object, e As System.EventArgs) Handles vLEnder.Deactivate
        ltMensagem.Text = Nothing
    End Sub

    Protected Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
      
        Dim IdCliente As String = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        drDados = objClsCliente.ValidarUsuario2(IdCliente, Protege.GeraHash(current_password.Text.Trim))
        If drDados.HasRows Then
            With objClsCliente
                .IdCliente = IdCliente
                .PNome = firstname.Text.ToString.Trim
                .UNome = lastname.Text.ToString.Trim
                .Email = email_address.Text.ToString.Trim
                .Ativo = 1
                If change_password.Checked = True Then
                    .Senha = Protege.GeraHash(password.Text.ToString.Trim)
                Else
                    .Senha = Protege.GeraHash(current_password.Text.ToString.Trim)
                End If
                .UpdtCliente()
            End With

            lblOla.Text = firstname.Text.ToString.Trim
            ltDadosPessoais.Text = firstname.Text.ToString.Trim & " "
            ltDadosPessoais.Text = ltDadosPessoais.Text & lastname.Text.ToString.Trim & "<br/>"
            ltDadosPessoais.Text = ltDadosPessoais.Text & email_address.Text.ToString & "<br/><br/>"

            Response.Cookies("pDados")("ID") = Protege.Criptografar(IdCliente)
            Response.Cookies("pDados")("Nome") = Protege.Criptografar(firstname.Text.ToString.Trim)
            Response.Cookies("pDados")("Sobrenome") = Protege.Criptografar(lastname.Text.ToString.Trim)
            Response.Cookies("pDados")("Email") = Protege.Criptografar(email_address.Text.ToString.Trim)

            ltInfoConta.Text = "<ul class='messages'><li class='success-msg'><ul><li><span>Dados Atualizados com Sucesso</span></li></ul></li></ul>"
            Panel1.Visible = False
            change_password.Checked = False
        Else
            ltInfoConta.Text = "<ul class='messages'><li class='error-msg'><ul><li><span>Senha Atual incorreta</span></li></ul></li></ul>"
        End If
    End Sub

    Private Sub dtEnderecos_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtEnderecos.ItemCommand
        Select Case e.CommandName
            Case Is = "Editar"
                PreencheEndereco(0, e.CommandArgument)
                mvPainelControle.ActiveViewIndex = 3
                ltEndereco.Text = "<b><b>Editar</b></b> Endereço"
                Button1.Text = "Salvar Alterações"
                Session("idEndCli") = e.CommandArgument
            Case Is = "Deletar"
                objClsCliente.ApagaEndereco(e.CommandArgument)
                CarregarDados()
                ltMensagem.Text = "<ul class='messages'><li class='success-msg'><ul><li><span>O endereço foi excluido com sucesso.</span></li></ul></li></ul>"

        End Select
    End Sub

    Private Sub dtPadrao_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtPadrao.ItemCommand
        Select Case e.CommandName
            Case Is = "AltEEPadrao"
                PreencheEndereco(1, e.CommandArgument)
                mvPainelControle.ActiveViewIndex = 3
                ltEndereco.Text = "<b><b>Editar</b></b> Endereço de Entrega Padrão"
                Button1.Text = "Salvar Alterações"
                Session("idEndCli") = e.CommandArgument
        End Select
    End Sub

    Private Sub vPedidos_Load(sender As Object, e As System.EventArgs) Handles vPedidos.Load
        PreencherGeralPDV()
    End Sub

    Private Sub gvGeralPDV_DataBound(sender As Object, e As System.EventArgs) Handles gvGeralPDV.DataBound
       
    End Sub

    Private Sub gvGeralPDV_RowCommand(sender As Object, e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvGeralPDV.RowCommand
        If e.CommandName = "VerPDV" Then

            PreencherPDV(e.CommandArgument)
            mvPainelControle.ActiveViewIndex = 5
        End If
    End Sub

    Protected Sub txtCep_TextChanged(sender As Object, e As EventArgs) Handles txtCep.TextChanged
        BuscaCEP()

    End Sub

    Private Sub BuscaCEP()

        If Len(txtCep.Text) = 8 Then

            drDados = Protege.BuscaCEPBD(txtCep.Text)
            If drDados.HasRows Then
                While drDados.Read()
                    txtLogradouro.Text = drDados.Item("nmLogradouro")
                    txtBairro.Text = drDados.Item("nmBairro")
                    txtCidade.Text = drDados.Item("nmCidade")
                    txtUF.Text = drDados.Item("sgUF")

                End While
            Else
                If Protege.ExisteConexaoInternet("http://cep.republicavirtual.com.br") = True Then
                    Dim dt As DataTable = Protege.BuscaCep(txtCep.Text).Tables(0)
                    Dim row As DataRow = dt.Rows.Item(0)
                    Dim resultado As String = row("resultado")

                    Select Case resultado
                        Case "1"
                            lblTpLog.Text = row("tipo_logradouro")
                            txtLogradouro.Text = row("logradouro")
                            txtBairro.Text = row("bairro")
                            txtCidade.Text = row("cidade")
                            txtUF.Text = row("uf")
                            txtNo.Focus()
                        Case "2"
                            lblTpLog.Text = row("tipo_logradouro")
                            txtCidade.Text = row("cidade")
                            txtUF.Text = row("uf")
                            txtLogradouro.Focus()
                        Case "0"
                            lblTpLog.Enabled = True
                            txtLogradouro.Enabled = True
                            txtBairro.Enabled = True
                            txtCidade.Enabled = True
                            ddEstado.Enabled = True
                            ddEstado.Visible = True
                            txtUF.Visible = False
                            txtLogradouro.Focus()
                    End Select

                Else
                    lblTpLog.Enabled = True
                    txtLogradouro.Enabled = True
                    txtBairro.Enabled = True
                    txtCidade.Enabled = True
                    ddEstado.Enabled = True
                    ddEstado.Visible = True
                    txtUF.Visible = False
                    txtLogradouro.Focus()
                End If

            End If

        End If

    End Sub

    Private Sub gvDetPDV_DataBound(sender As Object, e As System.EventArgs) Handles gvDetPDV.DataBound
        Dim ValorTotal As Decimal = 0

        For Each row As GridViewRow In gvDetPDV.Rows

            If row.RowType <> DataControlRowType.Header AndAlso row.RowType <> DataControlRowType.Footer Then
                If row.Cells(3).Text IsNot Nothing AndAlso row.Cells(3).Text <> String.Empty Then
                    ValorTotal += Convert.ToDecimal(FormatNumber(row.Cells(3).Text))
                End If
            End If
        Next

        lblTotalPedido.Text = String.Format("{0:c}", ValorTotal)
    End Sub
End Class