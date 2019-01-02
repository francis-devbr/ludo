Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Public Class clnProduto
    Dim objCldBD As New cldBD

    Public Function SLCategoria(ByVal idPlat As Integer, ByVal idTpProd As Integer) As DataSet
        Dim strProcedure As String
        Dim prmParametro = New SqlParameter(1) {}
        prmParametro(0) = New SqlParameter("@idPlataforma", idPlat)
        prmParametro(1) = New SqlParameter("@idTpProduto", idTpProd)

        strProcedure = "SP_LCategoria"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataSETProcedure(strProcedure, prmParametro)

    End Function

    Public Function ListaPlataforma() As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT * ")
        strQuery.Append(" FROM PLATAFORMA ")
        strQuery.Append(" ORDER BY IDPLATAFORMA ")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)

    End Function

    Public Function ListaESRB() As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT * ")
        strQuery.Append(" FROM ESRB ")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)

    End Function

    Public Function ProdutoIndexLanc(ByVal Categoria As Integer) As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT TOP 10 PRODUTO.idProduto, PRODUTO.idTpProduto, PRODUTO.dtLancamento, PRODUTO.nmCompleto, PRODUTO.ftCapa , PLATAFORMA.nmPLATAFORMA, PRECO_PRODUTO.vlVendaLoja,CATEGORIA.NMCATEGORIA ")
        strQuery.Append(" FROM TPPRODUTO, PRODUTO, PLATAFORMA,PRECO_PRODUTO, CATEGORIA,PRODUTO_CATEGORIA ")
        strQuery.Append(" WHERE TPPRODUTO.idTpProduto=PRODUTO.idTpProduto")
        strQuery.Append(" AND PLATAFORMA.idPlataforma=PRODUTO.idPlataforma ")
        strQuery.Append(" AND PRODUTO.idProduto=PRECO_PRODUTO.idProduto")
        strQuery.Append(" AND CATEGORIA.IDCATEGORIA= PRODUTO_CATEGORIA.IDCATEGORIA ")
        strQuery.Append(" AND PRODUTO.idProduto=PRODUTO_CATEGORIA.idProduto ")
        strQuery.Append(" AND PRODUTO.idTpProduto=" & Categoria & "")
        strQuery.Append(" ORDER BY PRODUTO.dtLancamento DESC ")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function


    Public Function ProdutoIndexMenuH(ByVal Categoria As Integer, ByVal idPlat As Integer) As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT TOP 1 PRODUTO.idProduto, PRODUTO.descrProduto, PRODUTO.idTpProduto, PRODUTO.dtLancamento, PRODUTO.nmCompleto, PRODUTO.ftCapa , PLATAFORMA.nmPLATAFORMA, PRECO_PRODUTO.vlVendaLoja,CATEGORIA.NMCATEGORIA ")
        strQuery.Append(" FROM TPPRODUTO, PRODUTO, PLATAFORMA,PRECO_PRODUTO, CATEGORIA,PRODUTO_CATEGORIA ")
        strQuery.Append(" WHERE TPPRODUTO.idTpProduto=PRODUTO.idTpProduto")
        strQuery.Append(" AND PLATAFORMA.idPlataforma=PRODUTO.idPlataforma ")
        strQuery.Append(" AND PRODUTO.idProduto=PRECO_PRODUTO.idProduto")
        strQuery.Append(" AND CATEGORIA.IDCATEGORIA= PRODUTO_CATEGORIA.IDCATEGORIA ")
        strQuery.Append(" AND PRODUTO.idProduto=PRODUTO_CATEGORIA.idProduto ")
        strQuery.Append(" AND PRODUTO.idTpProduto=" & Categoria & "")
        strQuery.Append(" AND PLATAFORMA.idPLATAFORMA=" & idPlat & "")
        strQuery.Append(" ORDER BY PRODUTO.dtLancamento DESC ")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function LTopProduto(ByVal Plataforma As String, Categoria As Integer) As DataSet
        Dim prmParametro = New SqlParameter(1) {}
        prmParametro(0) = New SqlParameter("@nmPlataforma", Plataforma)
        prmParametro(1) = New SqlParameter("@idTpProduto", Categoria)
        Dim strQuery As String
        strQuery = "SP_LTopProduto"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataSETProcedure(strQuery, prmParametro)
    End Function


    Public Function LGenero(ByVal Plataforma As String) As DataSet
        Dim prmParametro = New SqlParameter(0) {}
        prmParametro(0) = New SqlParameter("@nmPlataforma", Plataforma)
        Dim strQuery As String
        strQuery = "SP_LGenero"
        Dim objCldBD As New cldBD
        Return objCldBD.RetornaDataSETProcedure(strQuery, prmParametro)
    End Function

    Public Function ProdutoIndexDet(ByVal id As Integer) As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT PRODUTO.idProduto, PRODUTO.idTpProduto, PRODUTO.Garantia, PRODUTO.descrProduto, PRODUTO.dtLancamento, PRODUTO.nmCompleto, PRODUTO.ftCapa , PLATAFORMA.nmPLATAFORMA, PLATAFORMA.iconePlataforma, PRECO_PRODUTO.vlVendaLoja,CATEGORIA.NMCATEGORIA, ESRB.iconeESRB, PUBLICADOR.nmPUBLICADOR, PUBLICADOR.iconePublicador, Midia.iconeMidia, DESENVOLVEDOR.nmDesenvolvedor, PRODUTO.descrProduto2  ")
        strQuery.Append(" FROM TPPRODUTO, PRODUTO, PLATAFORMA,PRECO_PRODUTO, CATEGORIA,PRODUTO_CATEGORIA, ESRB, PUBLICADOR, DESENVOLVEDOR,  MIDIA ")
        strQuery.Append(" WHERE TPPRODUTO.idTpProduto=PRODUTO.idTpProduto")
        strQuery.Append(" AND PLATAFORMA.idPlataforma=PRODUTO.idPlataforma ")
        strQuery.Append(" AND ESRB.idESRB=PRODUTO.idESRB ")
        strQuery.Append(" AND MIDIA.idMidia=PRODUTO.idMidia ")
        strQuery.Append(" AND PUBLICADOR.idPUBLICADOR=PRODUTO.idPUBLICADOR ")
        strQuery.Append(" AND DESENVOLVEDOR.idDESENVOLVEDOR=PRODUTO.idDESENVOLVEDOR ")
        strQuery.Append(" AND PRODUTO.idProduto=PRECO_PRODUTO.idProduto")
        strQuery.Append(" AND CATEGORIA.IDCATEGORIA= PRODUTO_CATEGORIA.IDCATEGORIA ")
        strQuery.Append(" AND PRODUTO.idProduto=PRODUTO_CATEGORIA.idProduto ")
        strQuery.Append(" AND PRODUTO.idProduto=" & id & "")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function ProdutoDetGenero(ByVal id As Integer) As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT nmGENERO")
        strQuery.Append(" FROM  GENERO, PRODUTO_GENERO")
        strQuery.Append(" WHERE GENERO.idGENERO=PRODUTO_GENERO.idGENERO")
        strQuery.Append(" AND PRODUTO_GENERO.idProduto=" & id & "")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function ListaProdutoCarrinho(ByVal id As Integer) As SqlDataReader
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT * ")
        strQuery.Append(" FROM PRODUTO, PRECO_PRODUTO")
        strQuery.Append(" WHERE PRODUTO.idProduto=PRECO_PRODUTO.idProduto AND PRODUTO.idProduto = '" & id & "'")
        Dim objcldBancoDados As New cldBD()
        Return objcldBancoDados.RetornaDataReader(strQuery.ToString)
    End Function


    Public Function ListaBusca() As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT * ")
        strQuery.Append(" FROM PRODUTO, PRECO_PRODUTO")
        strQuery.Append(" WHERE PRODUTO.idProduto=PRECO_PRODUTO.idProduto")
        Dim objcldBancoDados As New cldBD()
        Return objcldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function ProdutoBusca(Optional id = "") As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT *  ")
        strQuery.Append(" FROM TPPRODUTO, PRODUTO, PLATAFORMA,PRECO_PRODUTO, CATEGORIA,PRODUTO_CATEGORIA, ESRB, PUBLICADOR, DESENVOLVEDOR,  MIDIA ")
        strQuery.Append(" WHERE TPPRODUTO.idTpProduto=PRODUTO.idTpProduto")
        strQuery.Append(" AND PLATAFORMA.idPlataforma=PRODUTO.idPlataforma ")
        strQuery.Append(" AND ESRB.idESRB=PRODUTO.idESRB ")
        strQuery.Append(" AND MIDIA.idMidia=PRODUTO.idMidia ")
        strQuery.Append(" AND PUBLICADOR.idPUBLICADOR=PRODUTO.idPUBLICADOR ")
        strQuery.Append(" AND DESENVOLVEDOR.idDESENVOLVEDOR=PRODUTO.idDESENVOLVEDOR ")
        strQuery.Append(" AND PRODUTO.idProduto=PRECO_PRODUTO.idProduto")
        strQuery.Append(" AND CATEGORIA.IDCATEGORIA= PRODUTO_CATEGORIA.IDCATEGORIA ")
        strQuery.Append(" AND PRODUTO.idProduto=PRODUTO_CATEGORIA.idProduto ")
        strQuery.Append(id)
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function LstTipoProdIMenu() As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT *    ")
        strQuery.Append(" FROM TPPRODUTO ")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function

    Public Function LstESRBIMenu() As DataSet
        Dim strQuery As New StringBuilder
        strQuery.Append(" SELECT *    ")
        strQuery.Append(" FROM ESRB ")
        Dim objCldBancoDados As New cldBD
        Return objCldBancoDados.RetornaDataSet(strQuery.ToString)
    End Function
End Class