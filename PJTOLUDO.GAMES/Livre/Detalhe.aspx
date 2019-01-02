<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Master.Master"
    CodeBehind="Detalhe.aspx.vb" Inherits="PJTOLUDO.GAMES.Detalhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../App_Themes/Theme/css/styletab.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col1-layout">
        <div class="main">
            <div class="breadcrumbs">
            </div>
            <div class="col-main">
                <div id="messages_product_view">
                </div>
                <asp:FormView ID="fvDetProd" runat="server" RenderOuterTable="true" CssClass="product-view">
                    <ItemTemplate>
                        <div class="product-essential">
                            <div class="product-shop">
                                <div class="product-name">
                                    <h1>
                                        <asp:Label ID="lblNmProd" runat="server" Text='<%#Container.DataItem("nmCompleto")%>'></asp:Label><br />
                                         <asp:HiddenField ID="hfNMCat" Value='<%#Container.DataItem("nmCategoria")%>' runat="server" />
                                        <asp:HiddenField ID="hfNMPlat" Value='<%#Container.DataItem("nmPLATAFORMA")%>' runat="server" />
                                        <asp:HiddenField ID="hfTipo" Value='<%#Container.DataItem("idTpProduto")%>' runat="server" />
                                    </h1>
                                </div>
                                <div class="short-description">
                                    <div class="std">
                                        <asp:Literal ID="txtDesc" runat="server" Text='<%#Container.DataItem("descrProduto")%>'>></asp:Literal>
                                    </div>
                                </div>
                             
                                <div class="add-to-box">
                                    <div class="add-to-cart">
                                        <div class="price-box">
                                            <span class="regular-price" id="product-price-3">
                                                <asp:Label ID="lblPreco" runat="server" Text='<%# Eval("vlVendaLoja", "{0:c2}")%>'
                                                    Font-Bold="True" CssClass="price"></asp:Label>
                                            </span>
                                        </div>
                                       
                                         <br class="clear" />
                                          <br class="clear" />
                                           <br class="clear" />
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="incluir" CommandArgument='<%# Eval("idProduto") %>'
                                            CssClass="button buttoncompra" CausesValidation="False">Adicionar Carrinho</asp:LinkButton>
                                    </div>
                                </div>
                                <br class="clear" />
                                                           
                               
                                <div class="gameinfo nograd grid_15">
                                    <ul>
                                        <li>Platforma <span>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItem("nmPLataforma")%>'></asp:Label></span></li>
                                        <li>Publicador <span>
                                            <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItem("nmPUBLICADOR")%>'></asp:Label></span></li>
                                        <li>Desenvolvedor <span>
                                            <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItem("nmDESENVOLVEDOR")%>'></asp:Label></span></li>
                                        <li>Gênero <span>
                                            <asp:Label ID="Label4" runat="server" Text='<%#Container.DataItem("nmCategoria")%>'></asp:Label><br />
                                            <asp:Repeater ID="rptGenero" runat="server">
                                                <ItemTemplate>
                                                    <asp:Label ID="Label6" runat="server" Text='<%#Container.DataItem("nmGenero")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </span></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="product-img-box">
                                <div class="zoom-inner">
                                    <asp:HyperLink ID="hpCover" runat="server" CssClass="photoDet caseplatformxbox360">
                                        <asp:Image ID="Image1" ImageUrl='<%#"~/App_Themes/Theme/img/iconeCover/" & Container.DataItem("ftCapa")%>'
                                            runat="server" CssClass="Detplatformxbox360" />
                                    </asp:HyperLink>
                                    <p>
                                    </p>
                                </div>
                            </div>
                        </div>
                        <br class="clear" />
                        <br class="clear" />
                        <div class="product-collateral">
                            <div class="padder">
                                <div class="box">
                                    <ul class="clearfix">
                                        <li class="active">Informações</li>
                                        <li>Especificação</li>
                                        <li>Parcelamento</li>
                                    </ul>
                                    <br class="clear" />
                                    <div class="conteudo">
                                        <div>
                                            <h2>
                                                Informações</h2>
                                            <p>
                                                <asp:Literal ID="Literal1" runat="server" Text='<%#Container.DataItem("descrProduto2")%>'>></asp:Literal></p>
                                        </div>
                                       
                                     
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:FormView>
            </div>
        </div>
    </div>
</asp:Content>
