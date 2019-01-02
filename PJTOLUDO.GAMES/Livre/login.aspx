<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Master.Master"
    CodeBehind="login.aspx.vb" Inherits="PJTOLUDO.GAMES.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="account-login">
                    <div class="page-title">
                        <h1>
                            <b><b>Login</b></b> or Criar uma Conta
                        </h1>
                    </div>
                    <div id="login-form">
                        <div class="col2-set">
                            <div class="col-1 new-users">
                                <div class="content">
                                    <h2>
                                        Ainda não sou cadastrado</h2>
                                    <p>
                                        Confira as vantagens de ter um conta <strong>GRATUITA</strong> na ludogames</p>
                                    <div>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                                            PostBackUrl="~/Livre/NovoUsuario.aspx" CssClass="button">Cadastrar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <div class="col-2 registered-users">
                                <div class="content">
                                    <h2>
                                        Já sou cadastrado na Game Store</h2>
                                    <p>
                                        Se você tem uma conta conosco, faça o login.</p>
                                    <ul class="form-list">
                                        <li>
                                            <label for="email" class="required">
                                                <em>*</em>Informe seu e-mail</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="email" runat="server" CssClass="input-text required-entry" ></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email"
                                                    ErrorMessage="Informe seu e-mail" Display="Dynamic">*</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                    ErrorMessage="Informe um e-mail válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ControlToValidate="email">*</asp:RegularExpressionValidator>
                                            </div>
                                        </li>
                                        <li>
                                            <label for="pass" class="required">
                                                <em>*</em>Informe sua senha</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="pass" runat="server" CssClass="input-text required-entry validate-password"
                                                    TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Informe sua senha"
                                                    Display="Dynamic" ControlToValidate="pass">*</asp:RequiredFieldValidator>
                                            </div>
                                        </li>
                                    </ul>
                                    <p class="required">
                                        * Campos Obrigatórios</p><br />
                                    <div class="buttons-set">
                                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error-msg" /><br />
                                       <asp:Button ID="Enviar" runat="server" Text="Entrar" CssClass="button" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
