<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="Master.Master"
    CodeBehind="NovoUsuario.aspx.vb" Inherits="PJTOLUDO.GAMES.NovoUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container col1-layout">
        <div class="main">
            <div class="col-main">
                <div class="account-create">
                    <div class="page-title">
                        <h1>
                            <b><b>Criar</b></b> uma Conta
                        </h1>
                    </div>
                    <div id="form-validate">
                        <div class="fieldset">
                            <h2 class="legend">
                                Informações Pessoais</h2>
                            <ul class="form-list">
                                <li class="fields">
                                    <div class="customer-name">
                                        <div class="field name-firstname">
                                            <label for="firstname" class="required">
                                                <em>*</em>Primeiro Nome</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="firstname" runat="server" MaxLength="30" CssClass="input-text required-entry"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="firstname"
                                                    ErrorMessage="Informe seu Nome" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="field name-lastname">
                                            <label for="lastname" class="required">
                                                <em>*</em>Sobrenome</label>
                                            <div class="input-box">
                                                <asp:TextBox ID="lastname" runat="server" MaxLength="40" CssClass="input-text required-entry"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="lastname"
                                                    ErrorMessage="Informe o Sobrenome" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                                <li>
                                    <label for="email_address" class="required">
                                        <em>*</em>CPF</label>
                                    <div class="input-box">
                                        <asp:TextBox ID="txtCPF" runat="server" CssClass="input-text required-entry"></asp:TextBox>
                                    </div>
                                </li>
                                <li>
                                    <label for="email_address" class="required">
                                        <em>*</em>Endereço de E-mail</label>
                                    <div class="input-box">
                                        <asp:TextBox ID="email_address" runat="server" CssClass="input-text validate-email required-entry"
                                            ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="email_address"
                                            ErrorMessage="Informe seu e-mail" Display="Dynamic">*</asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                            ErrorMessage="Informe um e-mail válido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ControlToValidate="email_address">*</asp:RegularExpressionValidator>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <div class="fieldset">
                            <h2 class="legend">
                                Informações de Acesso</h2>
                            <ul class="form-list">
                                <li class="fields">
                                    <div class="field">
                                        <label for="password" class="required">
                                            <em>*</em>Senha</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="password" runat="server" MaxLength="8" CssClass="input-text required-entry validate-password"
                                                TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="password"
                                                ErrorMessage="Informe sua senha" Display="Dynamic">*</asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="confirmation"
                                                ControlToValidate="password" Display="Dynamic" ErrorMessage="Senhas não conferem">*</asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="field">
                                        <label for="confirmation" class="required">
                                            <em>*</em>Confirme sua senha</label>
                                        <div class="input-box">
                                            <asp:TextBox ID="confirmation" runat="server" MaxLength="10" CssClass="input-text required-entry validate-cpassword"
                                                TextMode="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="confirmation"
                                                ErrorMessage="Confirme sua senha" Display="Dynamic">*</asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <div class="buttons-set">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error-msg" />
                            <asp:Literal ID="ltInfoConta" runat="server"></asp:Literal>
                            <p class="required">
                                * Campos Obrigatórios</p>
                            <asp:Button ID="btnRegistrar" runat="server" Text="Enviar" CssClass="button" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
