Public Class Xbox_360
    Inherits System.Web.UI.Page
    Dim clsProduto As New clnProduto
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then
            Session("Tela") = "xbox360"
            carregarRptExterno()
        End If

    End Sub

    Private Sub DLAdBlock_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DLAdBlock.ItemCommand
        If e.CommandName = "DetalheProduto" Then
            Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))
        End If
    End Sub

    Private Sub DLAdBlock_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DLAdBlock.ItemDataBound


        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then

            Select Case DirectCast(e.Item.FindControl("hfNMCat"), HiddenField).Value
                Case Is = "Kinect"
                    DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformxbox360kinect"
                Case Else
                    DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformxbox360"

            End Select

        End If

    End Sub

    Private Sub rptListaTipoXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptListaTipoXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "Tipo"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 1" & "AND PRODUTO.idTpProduto=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptAcessXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptAcessXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "Acessorios"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 1" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub rptESRBXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.RepeaterCommandEventArgs) Handles rptESRBXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "ESRB"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 1" & "AND PRODUTO.idESRB=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub dtCategoriaXbox_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dtCategoriaXbox.ItemCommand
        Select Case e.CommandName
            Case Is = "Genero"
                Response.Redirect("~\Livre\Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PLATAFORMA.idPLATAFORMA = 1" & "AND CATEGORIA.idCATEGORIA=" & "'" & e.CommandArgument & "'" & "ORDER BY PRODUTO.dtLancamento DESC  ")))

        End Select
    End Sub

    Private Sub carregarRptExterno()


        DLAdBlock.DataSource = clsProduto.LTopProduto("Xbox 360", 1)
        DLAdBlock.DataBind()
        rptListaTipoXbox.DataSource = clsProduto.LstTipoProdIMenu
        rptListaTipoXbox.DataBind()
        rptAcessXbox.DataSource = clsProduto.SLCategoria(1, 3)
        rptAcessXbox.DataBind()
        rptESRBXbox.DataSource = clsProduto.LstESRBIMenu
        rptESRBXbox.DataBind()

        dtCategoriaXbox.DataSource = clsProduto.SLCategoria(1, 1)
        dtCategoriaXbox.DataBind()

    End Sub
End Class