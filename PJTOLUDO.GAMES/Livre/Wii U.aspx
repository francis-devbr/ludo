<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Livre/Master.Master" CodeBehind="Wii U.aspx.vb" Inherits="PJTOLUDO.GAMES.Wii_U" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="std">
                    <div class="pager">
                        <p class="amount platform cs_ps3  ">
                            &nbsp;&nbsp;&nbsp;&nbsp; Wii U
                        </p>
                        <div class="limiter">
                            Wii
                        </div>
                    </div>
                </div>
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
                <div class="contact-left">
                    <h2>
                        Wii U</h2>
                    <ul>
                        <li>
                            <h3>
                                Tipo
                            </h3>
                            <asp:Repeater ID="rptListaTipoXbox" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Container.DataItem("idTpProduto")%>'
                                        CommandName="Tipo" CausesValidation="False"> <%#Container.DataItem("nmTpProduto")%></asp:LinkButton><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>
                        <li>
                            <h3>
                                Categoria
                            </h3>
                            <asp:DataList ID="dtCategoriaXbox" runat="server" RepeatDirection="Horizontal" RepeatColumns="1">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%#Container.DataItem("idCategoria")%>'
                                        CommandName="Genero" CausesValidation="False"><%#Container.DataItem("nmCategoria")%></asp:LinkButton>
                                </ItemTemplate>
                            </asp:DataList>
                        </li>
                        <li>
                            <h3>
                                Faixa Etária</h3>
                            <asp:Repeater ID="rptESRBXbox" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LikButton3" runat="server" CommandArgument='<%#Container.DataItem("idESRB")%>'
                                        CommandName="ESRB" CausesValidation="False"><%#Container.DataItem("nmESRB")%></asp:LinkButton><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>
                        <li class="last">
                            <h3>
                                Acessórios</h3>
                            <asp:Repeater ID="rptAcessXbox" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%#Container.DataItem("idCategoria")%>'
                                        CommandName="Acessorios" CausesValidation="False"><%#Container.DataItem("nmCategoria")%></asp:LinkButton><br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>
                    </ul>
                </div>
                <div id="contactForm">
                    <div class="fieldset">
                        <h2 class="legend">
                            Lançamentos</h2>
                        <asp:DataList ID="DLAdBlock" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"
                            Width="712px">
                            <ItemTemplate>
                                <asp:Literal ID="ltImageHolder" runat="server"></asp:Literal>
                                <asp:LinkButton ID="hpCover" runat="server" CommandName="DetalheProduto" CommandArgument='<%# Eval("idProduto") %>'>
                                    <asp:Image ID="imgCapa" ImageUrl='<%#"~/App_Themes/Theme/img/iconeCover/" & Container.DataItem("ftCapa")%>'
                                        runat="server" CssClass="platformxbox360" />
                                    <asp:HiddenField ID="hfNMCat" Value='<%#Container.DataItem("nmCategoria")%>' runat="server" />
                                    <asp:HiddenField ID="hfNMPlat" Value='<%#Container.DataItem("nmPLATAFORMA")%>' runat="server" />
                                </asp:LinkButton>
                                </div>
                                <br />
                                <div class="preco_nome">
                                    <asp:HyperLink ID="hlNome" Text='<%#Container.DataItem("nmCompleto")%>' runat="server"
                                        ForeColor="#9ACD2E" Font-Size="Medium"></asp:HyperLink><br />
                                    <asp:Label ID="lblPVenda" runat="server" Text='<%# Eval("vlVendaLoja", "{0:c2}")%>'></asp:Label>
                                    <br />
                                    <br />
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                    <br />
                    <br />
                    <div class="fieldset">
                        <h2 class="legend">
                            Consoles</h2>
                        <asp:DataList ID="dtlConsole" runat="server" RepeatDirection="Horizontal" RepeatColumns="5"
                            Width="112px">
                            <ItemTemplate>
                                <div class='imageHolder'>
                                    <asp:LinkButton ID="hpCover" runat="server" CommandName="DetalheProduto" CommandArgument='<%# Eval("idProduto") %>'
                                        CssClass='photo caseconsole'>
                                        <asp:Image ID="imgCapa" ImageUrl='<%#"~/App_Themes/Theme/img/iconeCover/" & Container.DataItem("ftCapa")%>'
                                            runat="server" CssClass="platformxbox360" />
                                        <asp:HiddenField ID="hfNMCat" Value='<%#Container.DataItem("nmCategoria")%>' runat="server" />
                                        <asp:HiddenField ID="hfNMPlat" Value='<%#Container.DataItem("nmPLATAFORMA")%>' runat="server" />
                                    </asp:LinkButton>
                                </div>
                                <br />
                                <div class="preco_nome">
                                    <asp:HyperLink ID="hlNome" Text='<%#Container.DataItem("nmCompleto")%>' runat="server"
                                        ForeColor="#9ACD2E" Font-Size="Medium"></asp:HyperLink><br />
                                    <asp:Label ID="lblPVenda" runat="server" Text='<%# Eval("vlVendaLoja", "{0:c2}")%>'></asp:Label>
                                    <br />
                                    <br />
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
