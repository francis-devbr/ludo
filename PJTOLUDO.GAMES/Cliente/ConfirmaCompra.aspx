<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Livre/Master.Master"
    CodeBehind="ConfirmaCompra.aspx.vb" Inherits="PJTOLUDO.GAMES.ConfirmaCompra" %>

<%@ Register Namespace="BoletoNet" TagPrefix="BoletoNet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col2-right-layout">
        <div class="main">
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:Panel ID="pnEndereco" runat="server">
                        <div class="col-main">
                            <div class="step-title">
                                <h2>
                                    Endereço de Entrega</h2>
                                <asp:Button ID="btnAddEndereco" runat="server" Text="Cadastrar Novo Endereço" CssClass="button buttonright" />
                            </div>
                            <div id="checkout-step-billing" class="step a-item" style="">
                                <div id="co-billing-form">
                                    <div class="input-box">
                                        <asp:UpdatePanel ID="UpdatePan" UpdateMode="Conditional" runat="server">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddEnderecos" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <asp:DataList ID="dtLEndConfirma" runat="server">
                                                    <ItemTemplate>
                                                       <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItem("PNomeDest") + " " + Container.DataItem("UNomeDest")%>'></asp:Label><br />
                                                            <asp:Label ID="Label2" runat="server" Text='<%#"CEP: " + Container.DataItem("noCEP")%>'
                                                                CommandArgument='<%#Container.DataItem("noCEP")%>'></asp:Label><br />
                                                            <asp:Label ID="Label14" runat="server" Text='<%#"Log.: " + Container.DataItem("Logradouro") + " - " + Container.DataItem("noLog") + " - " + Container.DataItem("Complemento")%>'></asp:Label><br />
                                                            <asp:Label ID="Label15" runat="server" Text='<%#Container.DataItem("Bairro") + " - " + Container.DataItem("Cidade") + " - " + Container.DataItem("UF")%>'></asp:Label><br />
                                                            <asp:Label ID="Label3" runat="server" Text='<%#"Tel.: " + Container.DataItem("DDD") + " " + Container.DataItem("Telefone")%>'></asp:Label>
                                                        <asp:HiddenField ID="hfCliEnd" runat="server" Value='<%#Container.DataItem("idCliEnd")%>' />
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <br />
                                        <br />
                                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" Text="Mudar para outro endereço" />
                                        <br />
                                        <br />
                                        <asp:DropDownList ID="ddEnderecos" runat="server" CssClass="address-select" AutoPostBack="True"
                                            Visible="False">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="buttons-set" id="billing-buttons-container" style="">
                                        <asp:Button ID="Continue" runat="server" Text="Continue" CssClass="button " />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnCadEndereco" runat="server" Visible="False">
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
                                                            MaxLength="9"></asp:TextBox>
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
                                            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
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
                                        <asp:Button ID="Button3" runat="server" Text="Cancelar" CssClass="button" CausesValidation="False" />
                                        <asp:Button ID="Button2" runat="server" Text="Enviar" CssClass="button buttonright" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </asp:View>
                <asp:View ID="View2" runat="server">
                    <div class="col-main">
                        <div class="step-title">
                            <h2>
                                Forma de Pagamento</h2>
                        </div>
                        <div id="checkout-step-payment" class="step a-item" style="">
                            <div id="Div2">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                                </asp:RadioButtonList>
                                <div class="buttons-set" id="Div3" style="">
                                    <asp:Button ID="btnFinalizaCompra" runat="server" Text="Finalizar Pedido" CssClass="button" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:View>
                <asp:View ID="View3" runat="server">
                    <asp:Panel ID="pnTransferencia" runat="server">
                        <div class="col-main">
                            <div class="page-title">
                                <h1>
                                    <b><b>Seu</b></b> pedido foi processado.
                                </h1>
                            </div>
                            <h2 class="sub-title">
                                Obrigado pela sua compra!</h2>
                            <p>
                                O seu pedido é:
                                <asp:Label ID="lblPedido" runat="server" Text="Label"></asp:Label></p>
                            <p>
                                O seu pedido foi processado e será enviado para o endereço indicado via correio</p>
                            <p>
                                Todos os dados necessários para efetuar o pagamento foram enviado para o Email:
                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></p>
                            <div class="buttons-set" id="Div6" style="">
                                <asp:Button ID="Button1" runat="server" Text="Continuar Comprando" CssClass="button" />
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnBoleto" runat="server">
                        <div class="col-main">
                            <div class="page-title">
                                <h1>
                                    <b><b>Seu</b></b> pedido foi processado.
                                </h1>
                            </div>
                            <h2 class="sub-title">
                                Obrigado pela sua compra!</h2>
                            <p>
                                O seu pedido é:
                                <asp:Label ID="lblPedidoBoleto" runat="server" Text="Label"></asp:Label></p>
                            <p>
                                <asp:Button ID="btnImprimirBoleto" runat="server" Text="Imprimir Boleto" CssClass="button"
                                    OnClientClick="window.open('ImprimeBoleto.aspx','Boleto','height=400,weight=400')" />&nbsp;</p>
                            <p>
                                &nbsp;</p>
                            <div class="buttons-set" id="Div1" style="">
                                <asp:Button ID="Button4" runat="server" Text="Continuar Comprando" CssClass="button buttonright" />
                            </div>
                        </div>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
