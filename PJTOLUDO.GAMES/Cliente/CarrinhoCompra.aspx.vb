Imports System.Data.SqlClient
Public Class CarrinhoCompra
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Cesta") Is Nothing Then
            LinkButton1.Visible = False
        Else
            LinkButton1.Visible = True
        End If
        If Not IsPostBack Then
            'se o codigo do produto recebido na requisição nao for nulo
            If Not Request.QueryString("ID") Is Nothing Then
                'inclui o produto na cesta obtendo a quantida da requisicão
                IncluirNaCesta(Convert.ToInt32(Request.QueryString("quantidade")))
            End If
            'mostra no gridview

        End If
        gvCarrinhoCompras.DataSource = obterDataSetCesta()
        gvCarrinhoCompras.DataBind()
    End Sub

    Public Function obterDataSetCesta() As DataSet

        'verifica se a cesta de compras esta na sessão
        If Session("cesta") Is Nothing Then
            Dim ds As DataSet = New DataSet()
            Dim keys(1) As DataColumn
            'define o campo que sera a chave primaria
            Dim itemID As New DataColumn("itemID", GetType(String))

            'cria o datatable
            Dim dt As DataTable = New DataTable("cesta")
            'inclua as colunas no datatable
            dt.Columns.Add(itemID)
            dt.Columns.Add("Foto", System.Type.GetType("System.String"), "")
            dt.Columns.Add("Produto", System.Type.GetType("System.String"), "")
            dt.Columns.Add("Quantidade", System.Type.GetType("System.Int32"), "")
            dt.Columns.Add("Preco", System.Type.GetType("System.Double"), "")
            dt.Columns.Add("SubTotal", System.Type.GetType("System.Double"), "Preco * Quantidade")
            dt.Columns.Add("total", System.Type.GetType("System.Double"), "SUM(subtotal)")
            dt.Columns.Add("totalqtde", System.Type.GetType("System.Double"), "SUM(Quantidade)")

            'define a chave primária
            keys(0) = itemID
            dt.PrimaryKey = keys

            'inclui na tabela
            ds.Tables.Add(dt)

            'coloca o dataset na sessão
            Session("cesta") = ds

            'retorna o dataset criado
            Return ds
        Else
            'retorna o dataset que esta na sessão
            Return Session("cesta")
        End If
    End Function

    Private Sub IncluirNaCesta(ByVal quantidade As Integer)
        Dim id As String = Protege.Descriptografar(Request.QueryString("ID"))

        Dim Produto As New clnProduto
        Dim drDados As System.Data.SqlClient.SqlDataReader
        drDados = Produto.ListaProdutoCarrinho(id)
        drDados.Read()
        Dim dt As DataTable = obterDataSetCesta().Tables(0)

        Dim row As DataRow = dt.Rows.Find(id)

        If row Is Nothing Then

            row = dt.NewRow()
            row("itemID") = id
            row("Foto") = drDados("ftCapa")
            row("Produto") = drDados("nmCompleto")
            row("Quantidade") = quantidade
            row("preco") = drDados("vlVendaLoja")
            dt.Rows.Add(row)

        Else
            'se a linha ja existir então apenas altera a quantidade
            Dim qtd As Integer = Convert.ToInt32(row("Quantidade"))
            qtd = qtd + quantidade
            row("Quantidade") = qtd

        End If

    End Sub

    Private Sub RemoverItemDaCesta(ByVal prodID As String)

        Dim ds As DataSet = obterDataSetCesta()
        Dim row As DataRow = ds.Tables(0).Rows.Find(prodID)
        If row IsNot Nothing Then
            ds.Tables(0).Rows.Remove(row)
            ds.AcceptChanges()
            gvCarrinhoCompras.DataSource = obterDataSetCesta()
            gvCarrinhoCompras.DataBind()
        End If

        If ds.Tables(0).Rows.Count = 0 Then
            LinkButton1.Visible = False
        Else
            LinkButton1.Visible = True
        End If

    End Sub

    Protected Sub gvCarrinhoCompras_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvCarrinhoCompras.RowDataBound

        If e.Row.RowType = DataControlRowType.Footer Then

            e.Row.Cells(3).Text = "Total: "
            e.Row.Cells(4).Text = String.Format("{0:c}", obterDataSetCesta().Tables(0).Rows(0)("Total"))
            Session("Total") = obterDataSetCesta().Tables(0).Rows(0)("Total")
            If Session("Cesta") Is Nothing Then
                LinkButton1.Visible = False
            Else
                LinkButton1.Visible = True
            End If
        End If

    End Sub

    Protected Sub gvCarrinhoCompras_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles gvCarrinhoCompras.RowCommand
        If e.CommandName = "Remove" Then
            Dim produtoId = Convert.ToString(e.CommandArgument)
            RemoverItemDaCesta(Convert.ToString(produtoId))

        End If

        If e.CommandName = "Atualizar" Then
            Dim produtoId = Convert.ToString(e.CommandArgument)
            Dim produtosId As String = Nothing
            Dim quantidade As String
            Dim linhaAtual As Integer

            If gvCarrinhoCompras.Rows.Count > 0 Then

                For linhaAtual = 0 To gvCarrinhoCompras.Rows.Count - 1
                    With gvCarrinhoCompras.Rows(linhaAtual)
                        quantidade = CType(.FindControl("txtQuantidade"), Label).Text.ToString
                    End With
                Next

                AlteraNaCesta(1, produtoId)
            End If

        ElseIf e.CommandName = "Remover" Then

            If gvCarrinhoCompras.Rows.Count > 0 Then
                Dim produtoId = Convert.ToString(e.CommandArgument)
                Dim produtosId As String = Nothing
                Dim quantidade As String
                Dim linhaAtual As Integer
                For linhaAtual = 0 To gvCarrinhoCompras.Rows.Count - 1
                    With gvCarrinhoCompras.Rows(linhaAtual)
                        quantidade = CType(.FindControl("txtQuantidade"), Label).Text.ToString
                    End With
                Next

                AlteraNaCesta(-1, produtoId)
            End If


        End If



        'If Session("cesta") Is Nothing Then
        '    Exit Sub
        'Else
        '    Session("TotalCarrinho") = String.Format("{0:c}", obterDataSetCesta().Tables(0).Rows(0)("Total"))
        '    Session("TotalQtde") = obterDataSetCesta().Tables(0).Rows(0)("totalqtde")
        'End If
    End Sub


    Private Sub AlteraNaCesta(ByVal quantidade As Integer, produtoId As String)
        Dim dt As DataTable = obterDataSetCesta().Tables(0)
        Dim row As DataRow = dt.Rows.Find(produtoId)
        'se a linha ja existir então apenas altera a quantidade
        Dim qtd As Integer = Convert.ToInt32(row("Quantidade"))
       
        qtd = quantidade + qtd


        row("Quantidade") = qtd
        dt.AcceptChanges()
        gvCarrinhoCompras.DataSource = obterDataSetCesta()
        gvCarrinhoCompras.DataBind()
    End Sub

    Private Sub atualizaPedidos()

        If Session("Cesta") Is Nothing Then
            Response.Redirect("~\Livre\index.aspx")
        End If

        Dim data As String = DateTime.Now

        Dim IdCliente As String = Protege.Descriptografar(Request.Cookies("pDados")("ID"))
        Dim objClsEstoque As New clnEstoque

        With objClsEstoque
            Dim row As DataRow
            For Each row In obterDataSetCesta.Tables(0).Rows
                .IdCliente = IdCliente
                .DtMovEst = data
                .IdTPMe = 3
                .IdDetMe = 2
                .IdProduto = row("itemID")
                .Qtde = row("quantidade")
                .ReservaPedido()
            Next
        End With
        Session("dtReserva") = data
        Session("TotalCompra") = obterDataSetCesta().Tables(0).Rows(0)("Total")
        Response.Redirect("~\Cliente\ConfirmaCompra.aspx")
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        atualizaPedidos()
    End Sub
End Class