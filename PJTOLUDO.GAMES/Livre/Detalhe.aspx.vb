Public Class Detalhe
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objclsProduto As New clnProduto
        Dim pegaEan As String = Protege.Descriptografar(Request.QueryString("ID"))

        fvDetProd.DataSource = objclsProduto.ProdutoIndexDet(pegaEan)
        fvDetProd.DataBind()


    End Sub

    Private Sub fvDetProd_DataBound(sender As Object, e As System.EventArgs) Handles fvDetProd.DataBound
        Dim objclsProduto As New clnProduto
        Select Case DirectCast(fvDetProd.FindControl("hfTipo"), HiddenField).Value
            Case Is = 1
                Select Case DirectCast(fvDetProd.FindControl("hfNMPlat"), HiddenField).Value
                    Case Is = "Xbox 360"
                        Select Case DirectCast(fvDetProd.FindControl("hfNMCat"), HiddenField).Value
                            Case Is = "Kinect"
                                DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet Detcaseplatformxbox360kinect"
                                DirectCast(fvDetProd.FindControl("Image1"), Image).CssClass = "Detplatformxbox360"
                            Case Else
                                DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet caseplatformxbox360"
                                DirectCast(fvDetProd.FindControl("Image1"), Image).CssClass = "Detplatformxbox360"
                        End Select
                    Case Is = "PC"
                        DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet Detcaseplatformpcgames"
                    Case Is = "PSP"
                        DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet Detcaseplatformpsp"
                        DirectCast(fvDetProd.FindControl("Image1"), Image).CssClass = "Detplatformpsp"
                    Case Is = "Wii"
                        DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet Detcaseplatformwii"
                    Case Is = "Wii U"
                        DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet Detcaseplatformwii"
                    Case Is = "3DS"
                        DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet Detcaseplatform3DS"
                        DirectCast(fvDetProd.FindControl("Image1"), Image).CssClass = "Detplatform3DS"
                    Case Is = "PS Vita"
                        DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet Detcaseplatformpsvita"
                        DirectCast(fvDetProd.FindControl("Image1"), Image).CssClass = "Detplatformpsvita"
                    Case Is = "Playstation 3"
                        Select Case DirectCast(fvDetProd.FindControl("hfNMCat"), HiddenField).Value
                            Case Is = "Move"
                                DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photo caseplatformps3"
                            Case Else
                                DirectCast(fvDetProd.FindControl("hpCover"), HyperLink).CssClass = "photoDet Detcaseplatformps3"
                                DirectCast(fvDetProd.FindControl("Image1"), Image).CssClass = "Detplatformps3"
                        End Select


                End Select
        End Select

        DirectCast(fvDetProd.FindControl("rptGenero"), Repeater).DataSource = objclsProduto.ProdutoDetGenero(Protege.Descriptografar(Request.QueryString("ID")))
        DirectCast(fvDetProd.FindControl("rptGenero"), Repeater).DataBind()
    End Sub


    Private Sub fvDetProd_ItemCommand(sender As Object, e As System.Web.UI.WebControls.FormViewCommandEventArgs) Handles fvDetProd.ItemCommand
        If e.CommandName = "incluir" Then
            Dim IDENT = Protege.Criptografar(Convert.ToString(e.CommandArgument))
            Response.Redirect("~\Cliente\CarrinhoCompra.aspx?ID=" & IDENT & "&quantidade=1")
        End If
    End Sub



End Class