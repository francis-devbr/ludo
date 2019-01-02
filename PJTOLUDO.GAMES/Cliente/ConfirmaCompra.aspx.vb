Imports System.Data.SqlClient
Imports System.Net.Mail.SmtpClient
Imports System.Net.Mail
Imports BoletoNet
Imports System

Public Class ConfirmaCompra
    Inherits System.Web.UI.Page
    Dim objClsCliente As New clnCliente
    Dim objClsPedido As New clnPedido
    Dim drDados As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            PreencherDTlistEnder(1)
        End If
    End Sub

    Private Sub PreencherDTlistEnder(ByVal idpad As Integer)

        Dim id As Integer = Protege.Descriptografar(Request.Cookies("pDados")("ID"))

        If idpad = 0 Then
            dtLEndConfirma.DataSource = objClsCliente.LEndDataList(id, idpad)
            dtLEndConfirma.DataBind()
        ElseIf idpad = 1 Then
            dtLEndConfirma.DataSource = objClsCliente.LEndDataList(id, idpad)
            dtLEndConfirma.DataBind()
        Else

        End If

    End Sub

    Protected Sub Continue_Click(sender As Object, e As EventArgs) Handles [Continue].Click
        MultiView1.ActiveViewIndex = 1
        RadioButtonList1.DataSource = objClsPedido.LstFormaPgto
        RadioButtonList1.DataTextField = "nmFormaPgto"
        RadioButtonList1.DataValueField = "idFormaPgto"
        RadioButtonList1.DataBind()

    End Sub

    Protected Sub btnFinalizaCompra_Click(sender As Object, e As EventArgs) Handles btnFinalizaCompra.Click


        Dim data As String = DateTime.Now
        Dim idPDV As Integer
        Dim IdCliente As String = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        Dim IdEmail As String = Protege.Descriptografar(Request.Cookies("pDados")("Email"))
        Dim objClsPedido As New clnPedido
        Dim objClsEstoque As New clnEstoque

        With objClsPedido
            .IdUsuario = 999
            .IdCliente = IdCliente
            .IdCEndereco = Session("idCliEnd")
            .IdSituacao = 1
            .DtPedido = data
            .DtEnvio = " 01/01/1900"
            .TxEnvio = 0
            .Obs = ""
            .IdTPvenda = 2
            .idFormaPgto = RadioButtonList1.SelectedValue
            .ADDPDV()
        End With

        drDados = objClsPedido.RetornoIdPDV(IdCliente, data)
        If drDados.HasRows Then
            While drDados.Read()
                idPDV = drDados.Item("idPDV")
                Session("IDNPDV") = drDados.Item("idPDV")
            End While
        End If

        With objClsEstoque
            Dim row As DataRow
            For Each row In objClsPedido.LItemReserva(IdCliente, Session("dtReserva")).Tables(0).Rows
                With objClsPedido
                    .IdPDV = idPDV
                    .IdProduto = row("idProduto")
                    .QTDE = row("QTDE")
                    .SubTotal = Replace(row("QTDE") * CDbl(row("vlVendaLoja")), ",", ".")
                    .ADDDET_PDV()
                End With
            Next
        End With

        With objClsEstoque
            .IdPDV = idPDV
            .IdTPMe = 2
            .IdCliente = IdCliente
            .DtMod = data
            .DtMovEst = Session("dtReserva")
            .AtualizaMovEst()
        End With
        

        If Not Session("Cesta") Is Nothing Then
            Session("Cesta") = Nothing
        End If

        lblPedidoBoleto.Text = Session("IDNPDV")
        lblPedido.Text = Session("IDNPDV")
        lblEmail.Text = IdEmail

        If RadioButtonList1.SelectedValue = 3 Then
            Dim mailClient As New SmtpClient()
            If Protege.ExisteConexaoInternet("http://google.com.br") = True Then
                mailClient.EnableSsl = True
                mailClient.Send("fnolivei@gmail.com", IdEmail, "Pedido no. " & idPDV, montaTexto2)
            End If
            pnBoleto.Visible = True
            pnTransferencia.Visible = False


        ElseIf RadioButtonList1.SelectedValue = 4 Then
            Dim mailClient As New SmtpClient()
            If Protege.ExisteConexaoInternet("http://google.com.br") = True Then
                mailClient.EnableSsl = True
                mailClient.Send("fnolivei@gmail.com", IdEmail, "Pedido no. " & idPDV, montaTexto)
            End If
            pnBoleto.Visible = False
            pnTransferencia.Visible = True
        End If
        MultiView1.ActiveViewIndex = 2

    End Sub

    Private Sub ddEnderecos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddEnderecos.SelectedIndexChanged
        dtLEndConfirma.DataSource = objClsCliente.ListaEndFinal(ddEnderecos.SelectedValue)
        dtLEndConfirma.DataBind()
    End Sub

    Protected Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        Dim id As Integer = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        If CheckBox2.Checked = True Then
            ddEnderecos.DataSource = objClsCliente.LEndDataList(id, 0)
            ddEnderecos.DataValueField = "idCliEnd"
            ddEnderecos.DataTextField = "Dados"
            ddEnderecos.DataBind()
            ddEnderecos.Items.Add(New ListItem("Escolha o um endereço para Entrega", "0"))
            ddEnderecos.Visible = True
            ddEnderecos.SelectedValue = "0"

        Else
            ddEnderecos.Visible = False
            dtLEndConfirma.DataSource = objClsCliente.LEndDataList(ID, 1)
            dtLEndConfirma.DataBind()
        End If
    End Sub

    Private Sub dtLEndConfirma_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dtLEndConfirma.ItemDataBound
        Session("idCliEnd") = DirectCast(e.Item.FindControl("hfCliEnd"), HiddenField).Value
    End Sub

    Private Function montaTexto() As String
        Dim id As Integer = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        Dim texto As New StringBuilder(" Compra Efetuada com Sucesso")

        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Prezado(a) " & Session("nomeCliente"))
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Esta é a confirmação de que seu pedido de No.  " & Session("IDNPDV") & " foi finalizado com sucesso.")
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Data do Pedido : " & DateTime.Now)
        texto = texto.AppendLine
        texto = texto.Append("Valor total do pedido : " & String.Format("{0:c}", Session("Total")))
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Você deve efetuar o pagamento do pedido em um dos seguintes bancos: ")
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Banco do Brasil Agência: 0000-4 Conta: 00009-0 Variação=01 POUPANÇA")
        texto = texto.AppendLine
        texto = texto.Append("Banco Bradesco Agência: 0000-9 Conta: 0005-9 POUPANÇA")
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Após o pagamento envie um email para ludogames@pjludo.com informando o número do documento.")
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Seu pedido será enviado via correio ")
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("O prazo médio da entrega é 5 dias úteis após a confirmação do pagamento.")
        Return texto.ToString
    End Function

    Private Function montaTexto2() As String
        Dim id As Integer = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        Dim texto As New StringBuilder(" Compra Efetuada com Sucesso")

        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Prezado(a) " & Session("nomeCliente"))
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Esta é a confirmação de que seu pedido de No.  " & Session("IDNPDV") & " foi finalizado com sucesso.")
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Data do Pedido : " & DateTime.Now)
        texto = texto.AppendLine
        texto = texto.Append("Valor total do pedido : " & String.Format("{0:c}", Session("Total")))
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("Seu pedido será enviado via correio após a confirmação do pagamento do Boleto ")
        texto = texto.AppendLine
        texto = texto.AppendLine
        texto = texto.Append("O prazo médio da entrega é 5 dias úteis após a confirmação do pagamento.")
        Return texto.ToString
    End Function

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("~\Livre\index.aspx")
    End Sub

    Protected Sub btnAddEndereco_Click(sender As Object, e As EventArgs) Handles btnAddEndereco.Click
        pnCadEndereco.Visible = True
        pnEndereco.Visible = False
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        pnCadEndereco.Visible = False
        pnEndereco.Visible = True
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim IdCliente As String = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        
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
            .PEntrega = 0
            .AtualizaCliEnd(" idCliente = '" & IdCliente & "'")
            .PEntrega = 1
            .AddCliEnd()
        End With
        PreencherDTlistEnder(1)
        pnCadEndereco.Visible = False
        pnEndereco.Visible = True
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

    
End Class