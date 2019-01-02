<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Livre/Master.Master"
    CodeBehind="CarrinhoCompra.aspx.vb" Inherits="PJTOLUDO.GAMES.CarrinhoCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="cart">
                    <div class="page-title title-buttons">
                        <h1>
                            <b><b>Carrinho</b></b> de Compras
                        </h1>
                    </div>
                    <br />
                    <br />
                    <div>
                        <div class="radius-cart">
                            <asp:GridView runat="server" ID="gvCarrinhoCompras" EmptyDataText="Não há nenhum item no seu carrinho de compras."
                                ShowFooter="True" DataKeyNames="ItemID" CssClass="data-table cart-table " AutoGenerateColumns="False">
                                <HeaderStyle CssClass="first last" />
                                <Columns>
                                    <asp:TemplateField ItemStyle-ForeColor="#333333">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#"~/App_Themes/Theme/img/iconeCover/" & Container.DataItem("Foto")%>'
                                                CssClass="product_art" />
                                        </ItemTemplate>
                                        <ItemStyle ForeColor="#333333"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Produto" HeaderText="Nome do Produto" HeaderStyle-CssClass="nobr">
                                        <HeaderStyle CssClass="nobr"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Preco" HeaderText="Preço Unitário" HeaderStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:C}" HeaderStyle-CssClass="a-center" ItemStyle-CssClass="a-center">
                                        <HeaderStyle HorizontalAlign="Right" CssClass="a-center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Quantidade" HeaderStyle-CssClass="a-center" ItemStyle-CssClass="a-center">
                                        <ItemTemplate>
                                            <asp:Label ID="txtQuantidade" runat="server" Text='<%# Eval("Quantidade") %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton runat="server" ID="btnAdd" Text="+" CommandName="Atualizar" CommandArgument='<%# Eval("ItemID") %>'
                                                CssClass="botaoRemoverCarrinho"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                                <asp:LinkButton runat="server" ID="btnRem" Text="-" CommandName="Remover" CommandArgument='<%# Eval("ItemID") %>'
                                                CssClass="botaoRemoverCarrinho"></asp:LinkButton>&nbsp;&nbsp;&nbsp;
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="a-center"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" DataFormatString="{0:C}"
                                        HeaderStyle-CssClass="a-center" ItemStyle-CssClass="a-center">
                                        <HeaderStyle CssClass="a-center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnRemove" Text="Remove" CommandName="Remove"
                                                CommandArgument='<%# Eval("ItemID") %>' CssClass="btn-remove2"></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div style="height: 57px; width: 948px; background: #F3F3F3; padding: 15px; margin: 10px 0;">
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Livre/index.aspx" CssClass="button">Continue Comprando</asp:HyperLink>
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="button buttonright">Finalizar Compra</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
