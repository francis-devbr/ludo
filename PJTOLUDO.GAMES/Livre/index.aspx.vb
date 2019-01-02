Public Class index
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim clsProduto As New clnProduto
            DLAdBlock.DataSource = clsProduto.ProdutoIndexLanc(1)
            DLAdBlock.DataBind()
            Session("Tela") = "index"
        End If
    End Sub

    Private Sub DLAdBlock_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DLAdBlock.ItemCommand
        If e.CommandName = "DetalheProduto" Then
            Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(Convert.ToString(e.CommandArgument)))
        End If
    End Sub
    Private Sub DLAdBlock_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DLAdBlock.ItemDataBound

        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Select Case DirectCast(e.Item.FindControl("hfTipo"), HiddenField).Value
                Case Is = 1
                    Select Case DirectCast(e.Item.FindControl("hfNMPlat"), HiddenField).Value
                        Case Is = "Xbox 360"
                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                            Select Case DirectCast(e.Item.FindControl("hfNMCat"), HiddenField).Value
                                Case Is = "Kinect"
                                    DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformxbox360kinect"
                                Case Else
                                    DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformxbox360"
                            End Select

                        Case Is = "PC"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformpc"

                        Case Is = "Playstation 3"
                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder ps3'>"
                            DirectCast(e.Item.FindControl("imgCapa"), Image).CssClass = "platformps3"
                            Select Case DirectCast(e.Item.FindControl("hfNMCat"), HiddenField).Value
                                Case Is = "Move"
                                    DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformps3"
                                Case Else
                                    DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformps3"
                            End Select

                        Case Is = "3DS"
                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder 3DS'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatform3DS"
                            DirectCast(e.Item.FindControl("imgCapa"), Image).CssClass = "platform3DS"

                        Case Is = "Wii"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformWii"


                        Case Is = "Wii U"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformWii"

                        Case Is = "PS Vita"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformpsvita"
                            DirectCast(e.Item.FindControl("imgCapa"), Image).CssClass = "platformPSVita"
                        Case Is = "PSP"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder PSP'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformPSP"
                            DirectCast(e.Item.FindControl("imgCapa"), Image).CssClass = "platformPSP"

                    End Select
            End Select

        End If

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

        Response.Redirect("Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PRODUTO.idTpProduto=1" & "ORDER BY PRODUTO.dtLancamento DESC  ")))
    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PRODUTO.idTpProduto=2" & "ORDER BY PRODUTO.dtLancamento DESC  ")))
    End Sub

    Protected Sub ImageButton3_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ImageButton3.Click
        Response.Redirect("Busca.aspx?ID=" & Protege.Criptografar(Convert.ToString("AND PRODUTO.idTpProduto=3" & "ORDER BY PRODUTO.dtLancamento DESC  ")))
    End Sub
End Class