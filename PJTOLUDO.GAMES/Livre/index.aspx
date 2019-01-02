<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Master.Master"
    CodeBehind="index.aspx.vb" Inherits="PJTOLUDO.GAMES.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">

                <div id="featured_slide" class="imgholder">
                    <div class="border-skitter content-width">
                        <div class="box_skitter box_skitter_large">
                            <ul>
                                <li>
                                    <img src="../App_Themes/Theme/img/midia/0001.jpg" alt="Midia 1" /></li>
                                <li>
                                    <img src="../App_Themes/Theme/img/midia/0002.jpg" alt="Midia 2" /></li>
                                <li>
                                    <img src="../App_Themes/Theme/img/midia/0003.jpg" alt="Midia 3" /></li>
                                <li>
                                    <img src="../App_Themes/Theme/img/midia/0004.jpg" alt="Midia 4" /></li>
                                <li>
                                    <img src="../App_Themes/Theme/img/midia/0005.jpg" alt="Midia 5" /></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <asp:ImageButton ID="ImageButton1" ImageUrl="~/App_Themes/Theme/img/layout/bnGame.png"
                    runat="server" CssClass="bannerTipoProduto" />
                <asp:ImageButton ID="ImageButton2" ImageUrl="~/App_Themes/Theme/img/layout/bnConsole.png"
                    runat="server" CssClass="bannerTipoProduto" />
                <asp:ImageButton ID="ImageButton3" ImageUrl="~/App_Themes/Theme/img/layout/BnAcessorio.png"
                    runat="server" CssClass="bannerTipoProduto" />
                <asp:DataList ID="DLAdBlock" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfNMCat" Value='<%#Container.DataItem("nmCategoria")%>' runat="server" />
                        <asp:HiddenField ID="hfNMPlat" Value='<%#Container.DataItem("nmPLATAFORMA")%>' runat="server" />
                        <asp:HiddenField ID="hfTipo" Value='<%#Container.DataItem("idTpProduto")%>' runat="server" />

                        <div class="containerImagemIndex">
                            <div class="productImageWrapper">
                                <asp:Literal ID="ltImageHolder" runat="server"></asp:Literal>
                                <asp:LinkButton ID="hpCover" runat="server" CommandName="DetalheProduto" CommandArgument='<%# Eval("idProduto") %>'>
                                    <asp:Image ID="imgCapa" ImageUrl='<%#"~/App_Themes/Theme/img/iconeCover/" & Container.DataItem("ftCapa")%>'
                                        runat="server" CssClass="platformxbox360" />
                                </asp:LinkButton>
                            </div>
                             </div>
                            <div class="productInfoWrapper">
                                <asp:HyperLink ID="hlNome" Text='<%#Container.DataItem("nmCompleto")%>' runat="server"></asp:HyperLink>
                                <br class="clear" />
                                <br class="clear" />
                                <asp:Label ID="lblPVenda" runat="server" Text='<%# Eval("vlVendaLoja", "{0:c2}")%>'></asp:Label></span>
                                <br />
                            </div>
                       
                        <br class="clear" />
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>
