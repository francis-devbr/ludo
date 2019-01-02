<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="../Livre/Master.Master"
    CodeBehind="PainelC.aspx.vb" Inherits="PJTOLUDO.GAMES.PainelC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col2-left-layout">
        <div class="main">
            <asp:MultiView ID="mvPainelControle" runat="server" ActiveViewIndex="0">
                <asp:View ID="vPainel" runat="server">
                    <div class="col-main">
                        <div class="my-account">
                            <div class="dashboard">
                                <div class="page-title">
                                    <h1>
                                        <b><b>Meu</b></b> Painel
                                    </h1>
                                </div>
                                <div class="welcome-msg">
                                    <p class="hello">
                                        <strong>
                                            <asp:Label ID="lblOla" runat="server" Text="Label"></asp:Label></strong></p>
                                    <p>
                                        Do seu Painel Minha Conta você tem a capacidade de visualizar as atividades da sua
                                        conta e atualizar suas informações.</p>
                                </div>
                                <div class="box-account box-info">
                                    <div class="box-head">
                                        <h2>
                                            Informações da Conta</h2>
                                    </div>
                                    <div class="col2-set">
                                        <div class="col-1">
                                            <div class="boxe">
                                                <div class="box-title">
                                                    <h3>
                                                        Informações para Contato</h3>
                                                    <asp:LinkButton ID="lbEditInfoCont" runat="server">Editar</asp:LinkButton>
                                                </div>
                                                <div class="box-content">
                                                    <p>
                                                        <asp:Literal ID="ltDadosPessoais" runat="server"></asp:Literal>
                                                        <asp:LinkButton ID="lbMudarSenha" runat="server">Alterar Senha</asp:LinkButton>
                                                    </p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-2">
                                            <div class="boxe">
                                                <div class="box-title">
                                                    <h3>
                                                        Lista de Endereços</h3>
                                                    <asp:LinkButton ID="lbGerEnder" runat="server">Gerenciar Endereços</asp:LinkButton>
                                                </div>
                                                <div class="box-content">
                                                    <h4>
                                                        Endereço de Entrega Padrão</h4>
                                                </div>
                                                <asp:DataList ID="DtLEPadraoPrincipal" runat="server">
                                                    <ItemTemplate>
                                                        <address>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItem("PNomeDest") + " " + Container.DataItem("UNomeDest")%>'></asp:Label><br />
                                                            <asp:Label ID="Label2" runat="server" Text='<%#"CEP: " + Container.DataItem("noCEP")%>'
                                                                CommandArgument='<%#Container.DataItem("noCEP")%>'></asp:Label><br />
                                                            <asp:Label ID="Label14" runat="server" Text='<%#"Log.: " + Container.DataItem("Logradouro") + " - " + Container.DataItem("noLog") + " - " + Container.DataItem("Complemento")%>'></asp:Label><br />
                                                            <asp:Label ID="Label15" runat="server" Text='<%#Container.DataItem("Bairro") + " - " + Container.DataItem("Cidade") + " - " + Container.DataItem("UF")%>'></asp:Label><br />
                                                            <asp:Label ID="Label3" runat="server" Text='<%#"Tel.: " + Container.DataItem("DDD") + " " + Container.DataItem("Telefone")%>'></asp:Label>
                                                        </address>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <asp:Literal ID="ltEndPad" runat="server"></asp:Literal>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="vInfoConta" runat="server">
                    <div class="col-main">
                        <div class="my-account">
                            <div class="page-title">
                                <h1>
                                    <b><b>Editar</b></b> Informações da Conta
                                </h1>
                            </div>
                            <asp:Literal ID="ltInfoConta" runat="server"></asp:Literal>
                            <div>
                                <div>
                                    <h2 class="legend">
                                        Informações da Conta</h2>
                                    <ul class="form-list">
                                        <li class="fields">
                                            <div class="customer-name">
                                                <div class="field name-firstname">
                                                    <label for="firstname" class="required">
                                                        <em>*</em>Primeiro Nome</label>
                                                    <div class="input-box">
                                                        <asp:TextBox ID="firstname" runat="server" MaxLength="40" CssClass="input-text required-entry"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="field name-lastname">
                                                    <label for="lastname" class="required">
                                                        <em>*</em>Sobrenome</label>
                                                    <div class="input-box">
                                                        <asp:TextBox ID="lastname" runat="server" MaxLength="70" CssClass="input-text required-entry"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <li>
                                            <label for="email_address" class="required">
                                                <em>*</em>Endereço de E-mail</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="email_address" runat="server" CssClass="input-text validate-email required-entry"
                                                    MaxLength="70" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email_address"
                                                    ErrorMessage="Informe seu e-mail" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                    ErrorMessage="Informe um e-mail válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ControlToValidate="email_address">*</asp:RegularExpressionValidator>
                                            </div>
                                        </li>
                                        <li>
                                            <label for="current_password" class="required">
                                                <em>*</em>Senha Atual</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="current_password" runat="server" CssClass="input-text required-entry"
                                                    MaxLength="8" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="current_password"
                                                    ErrorMessage="Informe sua senha atual" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            </div>
                                        </li>
                                        <li class="control">
                                            <asp:CheckBox ID="change_password" runat="server" AutoPostBack="True" CssClass="checkbox" />
                                            <label for="change_password">
                                                Alterar Senha</label>
                                        </li>
                                    </ul>
                                </div>
                                <asp:Panel ID="Panel1" runat="server" Visible="False">
                                    <div class="fieldset" style="">
                                        <h2 class="legend">
                                            Alterar Senha</h2>
                                        <ul class="form-list">
                                            <li class="fields">
                                                <div class="field">
                                                    <label for="password" class="required">
                                                        <em>*</em>Nova Senha</label>
                                                    <div class="input-box">
                                                        <asp:TextBox ID="password" runat="server" CssClass="input-text validate-password required-entry"
                                                            MaxLength="8" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password"
                                                            ErrorMessage="Informe sua senha" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="confirmation"
                                                            ControlToValidate="password" Display="Dynamic" ErrorMessage="Senhas não conferem">*</asp:CompareValidator>
                                                    </div>
                                                </div>
                                                <div class="field">
                                                    <label for="confirmation" class="required">
                                                        <em>*</em>Confirme a Nova Senha</label>
                                                    <div class="input-box">
                                                        <asp:TextBox ID="confirmation" runat="server" CssClass="input-text validate-cpassword required-entry"
                                                            MaxLength="8" TextMode="Password"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="confirmation"
                                                            ErrorMessage="Confirme sua senha" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </asp:Panel>
                                <div class="buttons-set">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error-msg" />
                                    <p class="required">
                                        * Campos Obrigatórios</p>
                                    <asp:Button ID="btnRegistrar" runat="server" Text="Salvar Alterações" CssClass="button" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="vLEnder" runat="server">
                    <div class="col-main">
                        <div class="my-account">
                            <div class="page-title title-buttons">
                                <h1>
                                    <b><b>Lista</b></b> de Endereços
                                </h1>
                                <asp:Button ID="btnAddEnder" runat="server" Text="Add Novo Endereço" CssClass="button buttonright"
                                    CausesValidation="False" />
                            </div>
                            <asp:Literal ID="ltMensagem" runat="server"></asp:Literal>
                            <div class="col2-set addresses-list">
                                <div class="col-1 addresses-primary">
                                    <ol>
                                        <asp:DataList ID="dtPadrao" runat="server">
                                            <ItemTemplate>
                                                <li class="item">
                                                    <h3>
                                                        Endereço de Entrega Padrão</h3>
                                                    <address>
                                                        <address>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItem("PNomeDest") + " " + Container.DataItem("UNomeDest")%>'></asp:Label><br />
                                                            <asp:Label ID="Label2" runat="server" Text='<%#"CEP: " + Container.DataItem("noCEP")%>'
                                                                CommandArgument='<%#Container.DataItem("noCEP")%>'></asp:Label><br />
                                                            <asp:Label ID="Label14" runat="server" Text='<%#"Log.: " + Container.DataItem("Logradouro") + " - " + Container.DataItem("noLog") + " - " + Container.DataItem("Complemento")%>'></asp:Label><br />
                                                            <asp:Label ID="Label15" runat="server" Text='<%#Container.DataItem("Bairro") + " - " + Container.DataItem("Cidade") + " - " + Container.DataItem("UF")%>'></asp:Label><br />
                                                            <asp:Label ID="Label3" runat="server" Text='<%#"Tel.: " + Container.DataItem("DDD") + " " + Container.DataItem("Telefone")%>'></asp:Label>
                                                        </address>
                                                        <p>
                                                            <asp:LinkButton ID="lbAltEEPadrao" runat="server" CommandName="AltEEPadrao" CommandArgument='<%#Container.DataItem("idCliEnd")%>'>Alterar Endereço de Entrega</asp:LinkButton></p>
                                                </li>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <li class="item empty">
                                            <p>
                                                <asp:Literal ID="ltEndPadVazio" runat="server"></asp:Literal></p>
                                        </li>
                                    </ol>
                                </div>
                                <div class="col-2 addresses-additional">
                                    <h2>
                                        Outras Entradas de Endereço</h2>
                                    <ol>
                                        <asp:DataList ID="dtEnderecos" runat="server">
                                            <ItemTemplate>
                                                <li class="item">
                                                    <address>
                                                        <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItem("PNomeDest") + " " + Container.DataItem("UNomeDest")%>'></asp:Label><br />
                                                            <asp:Label ID="Label2" runat="server" Text='<%#"CEP: " + Container.DataItem("noCEP")%>'
                                                                CommandArgument='<%#Container.DataItem("noCEP")%>'></asp:Label><br />
                                                            <asp:Label ID="Label14" runat="server" Text='<%#"Log.: " + Container.DataItem("Logradouro") + " - " + Container.DataItem("noLog") + " - " + Container.DataItem("Complemento")%>'></asp:Label><br />
                                                            <asp:Label ID="Label15" runat="server" Text='<%#Container.DataItem("Bairro") + " - " + Container.DataItem("Cidade") + " - " + Container.DataItem("UF")%>'></asp:Label><br />
                                                            <asp:Label ID="Label3" runat="server" Text='<%#"Tel.: " + Container.DataItem("DDD") + " " + Container.DataItem("Telefone")%>'></asp:Label>
                                                    </address>
                                                    <p>
                                                        <asp:LinkButton ID="lkBtnEdit" runat="server" CommandName="Editar" CommandArgument='<%#Container.DataItem("idCliEnd")%>'>Editar</asp:LinkButton><span
                                                            class="separator">|</span>
                                                        <asp:LinkButton ID="lkBtnDel" runat="server" CommandName="Deletar" CommandArgument='<%#Container.DataItem("idCliEnd")%>'>Deletar</asp:LinkButton></p>
                                                </li>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <li class="item empty">
                                            <p>
                                                <asp:Literal ID="ltOutrosEndVazio" runat="server"></asp:Literal></p>
                                        </li>
                                    </ol>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="vAddEditEnder" runat="server">
                    <div class="col-main">
                        <div class="my-account">
                            <div class="page-title">
                                <h1>
                                    <asp:Literal ID="ltEndereco" runat="server"></asp:Literal>
                                </h1>
                            </div>
                            <div>
                                <div class="fieldset">
                                    <h2 class="legend">
                                        Informações do Destinário</h2>
                                    <ul class="form-list">
                                        <li class="fields">
                                            <div class="customer-name">
                                                <div class="field name-firstname">
                                                    <label for="firstname" class="required">
                                                        <em>*</em>Primeiro Nome</label>
                                                    <div class="input-box">
                                                        <asp:TextBox ID="txtPNomeDest" runat="server" MaxLength="40" CssClass="input-text required-entry"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPNomeDest"
                                                            ErrorMessage="Informe seu Nome !" Display="Dynamic" ForeColor="Red">!Este Campo é Obrigatório</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="field name-lastname">
                                                    <label for="lastname" class="required">
                                                        <em>*</em>Sobrenome</label>
                                                    <div class="input-box">
                                                        <asp:TextBox ID="txtUNomeDest" runat="server" MaxLength="70" CssClass="input-text required-entry"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtUNomeDest"
                                                            ErrorMessage="Informe seu Sobrenome" Display="Dynamic" ForeColor="Red">!Este Campo é Obrigatório</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="fields">
                                            <div class="fields">
                                                <label for="telephone" class="required">
                                                    <em>*</em>Telefone</label>
                                                <div class="fields">
                                                    <br class="clear" />
                                                    <asp:TextBox ID="txtDDD" runat="server" Height="16px" Width="47px" CssClass="input-text   required-entry"
                                                        MaxLength="2"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtDDD"
                                                        ErrorMessage="Informe seu DDD" Display="Dynamic" ForeColor="Red">!</asp:RequiredFieldValidator>
                                                    &nbsp;&nbsp;
                                                    <asp:TextBox ID="txtTelefone" runat="server" Height="16px" Width="265px" CssClass="input-text   required-entry"
                                                        MaxLength="9" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTelefone"
                                                        ErrorMessage="Informe seu Telefone" Display="Dynamic" ForeColor="Red">!</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                    </ul>
                                </div>
                                <br class="clear" />
                                <div class="fieldset">
                                    <h2 class="legend">
                                        Endereço</h2>
                                    <ul class="form-list">
                                        <li class="fields">
                                            <div class="wide">
                                                <label for="zip" class="required">
                                                    <em style="">*</em>CEP</label>
                                                <div class="input-box">
                                                    <asp:TextBox ID="txtCep" runat="server" CssClass="input-text required-entry" MaxLength="8"
                                                        AutoPostBack="True"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtCep"
                                                        ErrorMessage="Informe seu CEP" Display="Dynamic" ForeColor="Red">!Este Campo é Obrigatório</asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </li>
                                        <asp:UpdatePanel ID="UpdatePan" UpdateMode="Conditional" runat="server">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="txtCep" EventName="TextChanged" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <li class="fields">
                                                    <li class="wide">
                                                        <label for="street_1" class="required">
                                                            <asp:Label ID="lblTpLog" runat="server" Text="Logradouro"></asp:Label><em>*</em></label>
                                                        <div class="input-box">
                                                            <asp:TextBox ID="txtLogradouro" runat="server" CssClass="input-text  required-entry"
                                                                Enabled="False"></asp:TextBox>
                                                        </div>
                                                    </li>
                                                    <li class="fields">
                                                        <div class="field">
                                                            <label for="city" class="required">
                                                                <em>*</em>Bairro</label>
                                                            <div class="input-box">
                                                                <asp:TextBox ID="txtBairro" runat="server" CssClass="input-text  required-entry"
                                                                    Enabled="False"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="fields">
                                                        <div class="field">
                                                            <label for="city" class="required">
                                                                <em>*</em>Cidade</label>
                                                            <div class="input-box">
                                                                <asp:TextBox ID="txtCidade" runat="server" CssClass="input-text  required-entry"
                                                                    Enabled="False"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="field">
                                                            <label for="city" class="required">
                                                                <em>*</em>UF</label>
                                                            <div class="input-box">
                                                                <asp:DropDownList ID="ddEstado" runat="server" CssClass="input-text  required-entry"
                                                                    Visible="False">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtUF" runat="server" CssClass="input-text  required-entry" Enabled="False"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </li>
                                                </li>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <li class="fields">
                                            <div class="customer-name">
                                                <div class="field name-firstname">
                                                    <label for="firstname" class="required">
                                                        <em>*</em>Número</label>
                                                    <div class="input-box">
                                                        <asp:TextBox ID="txtNo" runat="server" MaxLength="8" CssClass="input-text required-entry"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNo"
                                                            ErrorMessage="Informe seu Número" Display="Dynamic" ForeColor="Red">!Este Campo é Obrigatório</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="field name-lastname">
                                                    <label>
                                                        Complemento</label>
                                                    <div class="input-box">
                                                        <asp:TextBox ID="txtComplemento" runat="server" MaxLength="70" CssClass="input-text required-entry"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </li>
                                        <li class="control">
                                            <asp:CheckBox ID="primary_shipping" runat="server" CssClass="checkbox" /><label for="primary_shipping">Use
                                                como meu endereço de entrega padrão</label></li>
                                    </ul>
                                </div>
                                <div class="buttons-set">
                                    <asp:ValidationSummary ID="ValidationSummary2" runat="server" CssClass="error-msg" />
                                    <p class="required">
                                        * Campos Obrigatórios</p>
                                    <asp:Button ID="Button1" runat="server" Text="Enviar" CssClass="button" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="vPedidos" runat="server">
                    <div class="col-main">
                        <div class="my-account">
                            <div class="page-title">
                                <h1>
                                    <b><b>Meus</b></b> Pedidos
                                </h1>
                            </div>
                            <asp:GridView ID="gvGeralPDV" runat="server" CssClass="data-table" AutoGenerateColumns="False"
                                EmptyDataText="Não há nenhum pedido de compra.">
                                <Columns>
                                    <asp:BoundField DataField="idPDV" HeaderText="Nº Pedido" HeaderStyle-CssClass="nobr" ItemStyle-CssClass="a-center">
                                        <HeaderStyle CssClass="a-center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dtPedido" HeaderText="Data" HeaderStyle-HorizontalAlign="Right"
                                        HeaderStyle-CssClass="a-center" ItemStyle-CssClass="a-center">
                                        <HeaderStyle HorizontalAlign="Right" CssClass="a-center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Entrega para">
                                    <ItemTemplate>
                                           <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItem("PNomeDest") + " " + Container.DataItem("UNomeDest")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:BoundField DataField="nmSituacao" HeaderText="Status" HeaderStyle-CssClass="a-center" ItemStyle-CssClass="a-center">
                                         <HeaderStyle HorizontalAlign="Right" CssClass="a-center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField ItemStyle-CssClass="a-center">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("idPDV") %>'
                                                CommandName="VerPDV">Ver Pedido</asp:LinkButton>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="a-center"></HeaderStyle>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="VDetPedidos" runat="server">
                    <div class="col-main">
                        <div class="my-account">
                            <div class="order-items order-details">
                                <h2 class="table-caption">
                                    Itens do Pedido
                                </h2>
                                <asp:DataList ID="dtPDV" runat="server" CssClass="order-items order-details">
                                    <ItemTemplate>
                                        <div class="page-title title-buttons">
                                            <h1>
                                                <b><b>Pedido</b></b> &nbsp;&nbsp;#<asp:Label ID="Label5" runat="server" Text='<%# Eval("idPDV") %>'></asp:Label>
                                                -
                                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("nmSituacao") %>'></asp:Label>
                                            </h1>
                                            <a href="#" class="link-print">Imprimir</a>
                                        </div>
                                        <dl class="order-info">
                                            <dt>Sobre este Pedido:</dt>
                                            <dd>
                                                <ul id="order-info-tabs">
                                                    <li class="current first last">Informações do Pedido</li>
                                                </ul>
                                            </dd>
                                        </dl>
                                        <p class="order-date">
                                            Data do Pedido:
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("dtPedido") %>'></asp:Label></p>
                                        <div class="col2-set order-info-box">
                                            <div class="col-1">
                                                <div class="boxe">
                                                    <div class="box-title">
                                                        <h2>
                                                            Endereço de Entrega</h2>
                                                    </div>
                                                    <div class="box-content">
                                                        <address>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItem("PNomeDest") + " " + Container.DataItem("UNomeDest")%>'></asp:Label><br />
                                                            <asp:Label ID="Label2" runat="server" Text='<%#"CEP: " + Container.DataItem("noCEP")%>'
                                                                CommandArgument='<%#Container.DataItem("noCEP")%>'></asp:Label><br />
                                                            <asp:Label ID="Label14" runat="server" Text='<%#"Log.: " + Container.DataItem("Logradouro") + " - " + Container.DataItem("noLog") + " - " + Container.DataItem("Complemento")%>'></asp:Label><br />
                                                            <asp:Label ID="Label15" runat="server" Text='<%#Container.DataItem("Bairro") + " - " + Container.DataItem("Cidade") + " - " + Container.DataItem("UF")%>'></asp:Label><br />
                                                            <asp:Label ID="Label3" runat="server" Text='<%#"Tel.: " + Container.DataItem("DDD") + " " + Container.DataItem("Telefone")%>'></asp:Label>
                                                        </address>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-2">
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:DataList>
                                <asp:GridView runat="server" ID="gvDetPDV" EmptyDataText="Não há nenhum item no seu carrinho de compras."
                                    ShowFooter="True" DataKeyNames="idProduto" CssClass="data-table" AutoGenerateColumns="False">
                                    <FooterStyle HorizontalAlign="Right" />
                                    <HeaderStyle CssClass="first last" />
                                    <Columns>
                                        <asp:BoundField DataField="nmCompleto" HeaderText="Nome do Produto" HeaderStyle-CssClass="nobr">
                                            <HeaderStyle CssClass="nobr"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:BoundField DataField="SubTotal" HeaderText="Preço Unitário" HeaderStyle-HorizontalAlign="Right"
                                            DataFormatString="{0:C}" HeaderStyle-CssClass="a-center" ItemStyle-CssClass="a-center">
                                            <HeaderStyle HorizontalAlign="Right" CssClass="a-center"></HeaderStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Quantidade" HeaderStyle-CssClass="a-center" ItemStyle-CssClass="a-center">
                                            <ItemTemplate>
                                                <asp:Label ID="txtQuantidade" runat="server" Text='<%# Eval("QTDE") %>'></asp:Label>&nbsp;&nbsp;&nbsp;
                                            </ItemTemplate>
                                            <HeaderStyle CssClass="a-center"></HeaderStyle>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SubTotal" HeaderText="SubTotal" DataFormatString="{0:C}"
                                            HeaderStyle-CssClass="a-center" ItemStyle-CssClass="a-center">
                                            <HeaderStyle CssClass="a-center"></HeaderStyle>
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                                <br />

                                   <div class="page-title title-buttons buttonright">
                                            <h1>
                                                <b><b>Total</b></b> &nbsp;&nbsp;<asp:Label ID="lblTotalPedido" runat="server" Text="Label"></asp:Label>
                                                
                                            </h1>
                                           
                                        </div>

                              
                                <br class="clear" />
                                <br class="clear" />
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
            <div class="col-left sidebar">
                <div class="block block-account first">
                    <div class="block-title">
                        <strong><span>Minha Conta</span></strong>
                    </div>
                    <div class="block-content">
                        <ul>
                            <li>
                                <asp:LinkButton ID="lbPainel" runat="server" CausesValidation="False">Painel</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lbInfoConta" runat="server" CausesValidation="False">Informações da Conta</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lbEndereco" runat="server" CausesValidation="False">Lista de Endereços</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lbPedido" runat="server" CausesValidation="False">Meus Pedidos</asp:LinkButton></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
