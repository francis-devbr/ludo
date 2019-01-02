<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Livre/Master.Master"
    CodeBehind="Busca.aspx.vb" Inherits="PJTOLUDO.GAMES.Busca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="cart">
                    <div class="page-title title-buttons">
                        <h1>
                            <b><b>Resultado </b></b>da Busca
                        </h1>
                        <br />
                    </div>
                    <br />
                    <br />
                    <div>
                        <div class="radius-cart">
                            <div class="toolbar">
                                <div class="pager">
                                    <p class="amount">
                                       
                                    </p>
                                   
                                </div>
                            </div>
                            <asp:DataList ID="DataList1" runat="server">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfNMCat" Value='<%#Container.DataItem("nmCategoria")%>' runat="server" />
                                    <asp:HiddenField ID="hfNMPlat" Value='<%#Container.DataItem("nmPLATAFORMA")%>' runat="server" />
                                    <asp:HiddenField ID="hfTipo" Value='<%#Container.DataItem("idTpProduto")%>' runat="server" />
                                    <div class="product">
                                        <div class="grid_2 alpha" style="min-height: 1px;">
                                            <asp:Literal ID="ltImageHolder" runat="server"></asp:Literal>
                                            <asp:LinkButton ID="hpCover" runat="server" CommandName="DetalheProduto" CommandArgument='<%# Eval("idProduto") %>'>
                                                <asp:Image ID="imgCapa" ImageUrl='<%#"~/App_Themes/Theme/img/iconeCover/" & Container.DataItem("ftCapa")%>'
                                                    runat="server" CssClass="platformxbox360" />
                                            </asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="product_info grid_12">
                                        <h3>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="DetalheProduto" CommandArgument='<%# Eval("idProduto") %>'
                                                Text='<%#Container.DataItem("nmCompleto")%>'></asp:LinkButton>
                                            for <strong>
                                                <asp:Literal ID="Literal1" runat="server" Text='<%#Container.DataItem("nmPLATAFORMA")%>'></asp:Literal></strong></h3>
                                        <p class="publisher">
                                            by
                                            <asp:Literal ID="Literal2" runat="server" Text='<%#Container.DataItem("nmPublicador")%>'></asp:Literal></p>
                                        <div class="extras">
                                        </div>
                                        <asp:Image ID="Image3" ImageUrl='<%#"~/App_Themes/Theme/img/iconeESRB/" & Container.DataItem("iconeESRB")%>'
                                            runat="server" CssClass="product_esrb" />
                                        <ul>
                                            <li>
                                                <asp:Label ID="Label1" runat="server" Text='<%# "Data Lançamento " & Container.DataItem("dtLancamento")%>'></asp:Label>
                                                <br>
                                            </li>
                                            <li>
                                                <asp:Label ID="Label2" runat="server" Text='<%# "Garantia " & Container.DataItem("Garantia")%>'></asp:Label></li>
                                        </ul>
                                    </div>
                                    <div class="purchase_info grid_6 omega">
                                        <h4>
                                            Compre <strong>Agora</strong></h4>
                                        <p class="pricing">
                                            <asp:Label ID="lblPVenda" runat="server" Text='<%# Eval("vlVendaLoja", "{0:c2}")%>'></asp:Label></p>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="button buttonright buttoncompra"
                                            CommandName="incluir" CommandArgument='<%# Eval("idProduto") %>'>Add Carrinho</asp:LinkButton>
                                    </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
