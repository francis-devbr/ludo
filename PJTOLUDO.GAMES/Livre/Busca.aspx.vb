Public Class Busca
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim Produto As New clnProduto
        Dim PARAMETRO As String = ""
        If Not Request.QueryString("ID") Is Nothing Then
            PARAMETRO = Protege.Descriptografar(Request.QueryString("ID"))
           
        End If
        DataList1.DataSource = Produto.ProdutoBusca(PARAMETRO)
        DataList1.DataBind()
    End Sub

    Private Sub DataList1_ItemCommand(source As Object, e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Select Case e.CommandName
            Case Is = "DetalheProduto"
                Response.Redirect("Detalhe.aspx?ID=" & Protege.Criptografar(e.CommandArgument))
            Case Is = "incluir"
                Dim IDENT = Protege.Criptografar(e.CommandArgument)
                Response.Redirect("~\Cliente\CarrinhoCompra.aspx?ID=" & IDENT & "&quantidade=1")
        End Select
    End Sub

    
    Private Sub DataList1_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
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

                        Case Is = "PS Vita"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformpsvita"
                            DirectCast(e.Item.FindControl("imgCapa"), Image).CssClass = "platformPSVita"
                        Case Is = "PSP"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder PSP'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformPSP"
                            DirectCast(e.Item.FindControl("imgCapa"), Image).CssClass = "platformPSP"
                        Case Is = "3DS"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder 3DS'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatform3DS"
                            DirectCast(e.Item.FindControl("imgCapa"), Image).CssClass = "platform3DS"
                        Case Is = "Wii U"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformWii"

                        Case Is = "Wii"

                            DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                            DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseplatformWii"
                      


                    End Select
                Case Else

                    DirectCast(e.Item.FindControl("ltImageHolder"), Literal).Text = "<div class='imageHolder'>"
                    DirectCast(e.Item.FindControl("hpCover"), LinkButton).CssClass = "photo caseconsole"
            End Select

        End If
    End Sub
End Class