Imports System.Web.Security
Public Class Master
    Inherits System.Web.UI.MasterPage
    Private mTela As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            carregarRptExterno()
        End If

        If Session("Tela") = "xbox360" Then
            Literal1.Text = "<div class='wrapper2'>"
        Else
            Literal1.Text = "<div class='wrapper1'>"
        End If

        If (Request.Cookies("pDados") Is Nothing) Then
            HyperLink7.Visible = True
            lblUsuario.Visible = False
            lblUsuario.Text = "Bemvindo a ludogames Online!"
            lbLog.Text = "Log In"
        Else
            HyperLink7.Visible = False
            lblUsuario.Visible = True
            lblUsuario.Text = "Bemvindo!, " & Protege.Descriptografar(Request.Cookies("pDados")("Nome"))
            lbLog.Text = "Logout"
        End If

        txtBusca.Attributes.Add("onfocus", String.Format("RecebeFoco('{0}');", txtBusca.ClientID))
        txtBusca.Attributes.Add("onblur", String.Format("PerdeFoco('{0}');", txtBusca.ClientID))
    End Sub

    Private Sub carregarRptExterno()

        Dim clsProduto As New clnProduto
        rptListaTipoXbox.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipoXbox.DataBind()
        rptListaTipoPS3.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipoPS3.DataBind()
        rptListaTipoWii.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipoWii.DataBind()
        rptListaTipoWiiU.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipoWiiU.DataBind()
        rptListaTipoPC.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipoPC.DataBind()
        rptListaTipo3DS.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipo3DS.DataBind()
        rptListaTipoPSVita.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipoPSVita.DataBind()
        rptListaTipoPSP.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipoPSP.DataBind()



        rptAcessXbox.DataSource = clsProduto.SLCategoria(1, 3)
        rptAcessXbox.DataBind()
        rptAcessPS3.DataSource = clsProduto.SLCategoria(2, 3)
        rptAcessPS3.DataBind()
        rptAcessWii.DataSource = clsProduto.SLCategoria(3, 3)
        rptAcessWii.DataBind()
        rptAcessWiiU.DataSource = clsProduto.SLCategoria(4, 3)
        rptAcessWiiU.DataBind()
        rptAcessPC.DataSource = clsProduto.SLCategoria(5, 3)
        rptAcessPC.DataBind()
        rptAcess3DS.DataSource = clsProduto.SLCategoria(6, 3)
        rptAcess3DS.DataBind()
        rptAcessPSVita.DataSource = clsProduto.SLCategoria(7, 3)
        rptAcessPSVita.DataBind()
        rptAcessPSP.DataSource = clsProduto.SLCategoria(8, 3)
        rptAcessPSP.DataBind()

        rptESRBXbox.DataSource = clsProduto.LstESRBIMenu
        rptESRBXbox.DataBind()
        rptESRBPS3.DataSource = clsProduto.LstESRBIMenu
        rptESRBPS3.DataBind()
        rptESRBWii.DataSource = clsProduto.LstESRBIMenu
        rptESRBWii.DataBind()
        rptESRBWiiU.DataSource = clsProduto.LstESRBIMenu
        rptESRBWiiU.DataBind()
        rptESRBPC.DataSource = clsProduto.LstESRBIMenu
        rptESRBPC.DataBind()
        rptESRB3DS.DataSource = clsProduto.LstESRBIMenu
        rptESRB3DS.DataBind()
        rptESRBPSVita.DataSource = clsProduto.LstESRBIMenu
        rptESRBPSVita.DataBind()
        rptESRBPSP.DataSource = clsProduto.LstESRBIMenu
        rptESRBPSP.DataBind()

        rptDestMesXbox.DataSource = clsProduto.ProdutoIndexMenuH(1, 1)
        rptDestMesXbox.DataBind()
        rptDestMesPS3.DataSource = clsProduto.ProdutoIndexMenuH(1, 2)
        rptDestMesPS3.DataBind()
        rptDestMesWii.DataSource = clsProduto.ProdutoIndexMenuH(1, 3)
        rptDestMesWii.DataBind()
        rptDestMesWiiU.DataSource = clsProduto.ProdutoIndexMenuH(1, 4)
        rptDestMesWiiU.DataBind()
        rptDestMesPC.DataSource = clsProduto.ProdutoIndexMenuH(1, 5)
        rptDestMesPC.DataBind()
        rptDestMes3DS.DataSource = clsProduto.ProdutoIndexMenuH(1, 6)
        rptDestMes3DS.DataBind()
        rptDestMesPSVita.DataSource = clsProduto.ProdutoIndexMenuH(1, 7)
        rptDestMesPSVita.DataBind()
        rptDestMesPSP.DataSource = clsProduto.ProdutoIndexMenuH(1, 8)
        rptDestMesPSP.DataBind()

        dtCategoriaXbox.DataSource = clsProduto.SLCategoria(1, 1)
        dtCategoriaXbox.DataBind()
        dtCategoriaPS3.DataSource = clsProduto.SLCategoria(2, 1)
        dtCategoriaPS3.DataBind()
        dtCategoriaWii.DataSource = clsProduto.SLCategoria(3, 1)
        dtCategoriaWii.DataBind()
        dtCategoriaWiiU.DataSource = clsProduto.SLCategoria(4, 1)
        dtCategoriaWiiU.DataBind()
        dtCategoriaPC.DataSource = clsProduto.SLCategoria(5, 1)
        dtCategoriaPC.DataBind()
        dtCategoria3DS.DataSource = clsProduto.SLCategoria(6, 1)
        dtCategoria3DS.DataBind()
        dtCategoriaPSVita.DataSource = clsProduto.SLCategoria(7, 1)
        dtCategoriaPSVita.DataBind()
        dtCategoriaPSP.DataSource = clsProduto.SLCategoria(8, 1)
        dtCategoriaPSP.DataBind()

    End Sub

    Protected Sub lbLog_Click(sender As Object, e As EventArgs) Handles lbLog.Click

        If Session("Logado") = "1" Then
            Deslogar()
            Response.Redirect("~\Livre\index.aspx")
        ElseIf Session("Logado") = 0 Then
            Deslogar()
            Response.Redirect("~\Livre\login.aspx")
        End If

    End Sub


    Private Sub Deslogar()
        Response.Cookies("pDados").Expires = DateTime.Now.AddMinutes(-1)
        Session("Logado") = 0
        Session.Abandon()
        FormsAuthentication.SignOut()

    End Sub

    Public Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick


    End Sub

    Private Sub UpdatePanel1_Load(sender As Object, e As System.EventArgs) Handles UpdatePanel1.Load
        Dim objCarrinho As New CarrinhoCompra
        Dim ds As DataSet = objCarrinho.obterDataSetCesta()
        If ds.Tables(0).Rows.Count > 0 Then
            lblTotCarrinho.Text = String.Format("{0:c}", ds.Tables(0).Rows(0)("Total"))
            qtdCarrinho.Text = ds.Tables(0).Rows(0)("totalqtde")
        Else
            If Not Session("Cesta") Is Nothing Then
                Session("Cesta") = Nothing
                lblTotCarrinho.Text = "0.00"
                qtdCarrinho.Text = "0 item"

            End If

            Exit Sub
        End If
    End Sub




    Private Sub rptListaTipoXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipoXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 1" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptListaTipoPS3_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipoPS3.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 2" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptListaTipoWii_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipoWii.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 3" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptListaTipoWiiU_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipoWiiU.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 4" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptListaTipoPC_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipoPC.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 5" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptListaTipo3DS_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipo3DS.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 6" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptListaTipoPSVita_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipoPSVita.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 7" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptListaTipoPSP_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipoPSP.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 8" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub


    Private Sub rptAcessXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcessXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 1" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptAcessPS3_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcessPS3.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 2" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptAcessWii_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcessWii.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 3" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptAcessWiiU_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcessWiiU.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 4" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptAcessPC_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcessPC.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 5" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptAcess3DS_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcess3DS.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 6" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptAcessPSVita_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcessPSVita.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 7" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptAcessPSP_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcessPSP.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 8" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub


    Private Sub rptESRBXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRBXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 1" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptESRBPS3_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRBPS3.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 2" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptESRBWii_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRBWii.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 3" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptESRBWiiU_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRBWiiU.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 4" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptESRBPC_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRBPC.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 5" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptESRB3DS_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRB3DS.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 6" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptESRBPSVita_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRBPSVita.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 7" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptESRBPSP_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRBPSP.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 8" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub


    Private Sub dtCategoriaXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoriaXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 1" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub dtCategoriaPS3_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoriaPS3.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 2" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub dtCategoriaWii_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoriaWii.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 3" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub dtCategoriaWiiU_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoriaWiiU.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 4" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub dtCategoriaPC_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoriaPC.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 5" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub dtCategoria3DS_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoria3DS.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 6" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub dtCategoriaPSVita_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoriaPSVita.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 7" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub dtCategoriaPSP_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoriaPSP.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 8" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub


    Private Sub rptDestMesXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDestMesXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "Destque"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))

        End Select
    End Sub

    Private Sub rptDestMesPS3_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDestMesPS3.ItemCommand
        Select Case e.CommandName
            Case Is = "Destque"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))

        End Select
    End Sub

    Private Sub rptDestMesWii_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDestMesWii.ItemCommand
        Select Case e.CommandName
            Case Is = "Destque"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))

        End Select
    End Sub

    Private Sub rptDestMesWiiU_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDestMesWiiU.ItemCommand
        Select Case e.CommandName
            Case Is = "Destque"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))

        End Select
    End Sub

    Private Sub rptDestMesPC_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDestMesPC.ItemCommand
        Select Case e.CommandName
            Case Is = "Destque"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))

        End Select
    End Sub

    Private Sub rptDestMes3DS_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDestMes3DS.ItemCommand
        Select Case e.CommandName
            Case Is = "Destque"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))

        End Select
    End Sub

    Private Sub rptDestMesPSVita_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDestMesPSVita.ItemCommand
        Select Case e.CommandName
            Case Is = "Destque"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))

        End Select
    End Sub

    Private Sub rptDestMesPSP_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptDestMesPSP.ItemCommand
        Select Case e.CommandName
            Case Is = "Destque"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))

        End Select
    End Sub


    Protected Sub btnBusca_Click(sender As Object, e As EventArgs) Handles btnBusca.Click
        If txtBusca.Text = "Digite aqui ..." Then

            Exit Sub

        End If

        If txtBusca.Text = "" Then

            txtBusca.Text = "Digite aqui ..."

        Else
            Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar("AND PRODUTO.nmCompleto LIKE" & "'%" & txtBusca.Text & "%'" & "ORDER BY PRODUTO.dtLancamento DESC  "))
        End If

    End Sub

    Private Sub txtBusca_Disposed(sender As Object, e As System.EventArgs) Handles txtBusca.Disposed

    End Sub

    Private Sub txtBusca_Init(sender As Object, e As System.EventArgs) Handles txtBusca.Init

    End Sub

    Protected Sub LinkButton4_Click(sender As Object, e As EventArgs) Handles LinkButton4.Click

        Response.Redirect("~\Livre\Xbox 360.aspx")

    End Sub
End Class