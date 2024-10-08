﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Edit.aspx.vb" Inherits="DesafioTecnicoVisualBasic.Apresentacao.Edit1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Edit</title>
    <link href="~/Content/Cadastro.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">    
            <h1>Edição</h1>            
            <hr />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
            
            <div class="row">
                <div class="col-md-4">
                    <asp:Panel ID="Panel1" runat="server">
                        <div hidden class="form-group">
                            <asp:Label ID="EmpresaIdLabel" runat="server" AssociatedControl="EmpresaIdTextBox" Text="EmpresaId" CssClass="control-label" />
                            <asp:TextBox ID="EmpresaIdTextBox" runat="server" CssClass="form-control" Enabled="False" Text='<%# Bind("EmpresaId") %>' />
                            <asp:RequiredFieldValidator ID="EmpresaIdRequiredFieldValidator" runat="server" ControlToValidate="EmpresaIdTextBox" ErrorMessage="EmpresaId é obrigatório." CssClass="text-danger" Display="None" />
                        </div>

                        <div class="form-group">
                            <asp:Label ID="NomeLabel" runat="server" AssociatedControl="NomeTextBox" Text="Nome" CssClass="control-label" />
                            <asp:TextBox ID="NomeTextBox" runat="server" CssClass="form-control" Text='<%# Bind("Nome") %>' />
                            <asp:RequiredFieldValidator ID="NomeRequiredFieldValidator" runat="server" ControlToValidate="NomeTextBox" ErrorMessage="Nome é obrigatório." CssClass="text-danger" />
                        </div>

                        <div class="form-group">
                            <asp:Label ID="CnpjLabel" runat="server" AssociatedControl="CnpjTextBox" Text="Cnpj" CssClass="control-label" />
                            <asp:TextBox ID="CnpjTextBox" runat="server" CssClass="form-control" Text='<%# Bind("Cnpj") %>' />
                            <asp:RequiredFieldValidator ID="CnpjRequiredFieldValidator" runat="server" ControlToValidate="CnpjTextBox" ErrorMessage="CPF é obrigatório." CssClass="text-danger" />
                            <asp:RegularExpressionValidator ID="CnpjRegularExpressionValidator" runat="server" ControlToValidate="CnpjTextBox" ValidationExpression="\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}" ErrorMessage="O CNPJ deve estar no formato XX.XXX.XXX/0001-XX"  CssClass="text-danger" />
                            <asp:Label ID="CnpjErrorLabel" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
                        </div>                   

                        <div class="form-group">
                            <asp:Label ID="AssociadosSelecionadasLabel" runat="server" Text="Associados" CssClass="control-label" />
                            <asp:ListBox ID="AssociadosListBox" runat="server" SelectionMode="Multiple" CssClass="form-control">
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="AssociadosSelecionadasRequiredFieldValidator" runat="server" ControlToValidate="AssociadosListBox" InitialValue="" ErrorMessage="Selecione pelo menos um associado." CssClass="text-danger" />
                        </div>

                        <div class="form-group">
                            <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-primary" CommandName="Save" OnClick="SaveButton_Click" />
                        </div>
                    </asp:Panel>
                </div>
            </div>

            <div>
                <asp:HyperLink ID="BackToListLink" runat="server" NavigateUrl="~/Views/Empresa/Index.aspx" Text="Back to List" />
            </div>
    </form>


    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/5.0.8/jquery.inputmask.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#CnpjTextBox').inputmask('99.999.999/9999-99');
        });
    </script>

</body>
</html>

