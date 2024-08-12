<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Edit.aspx.vb" Inherits="DesafioTecnicoVisualBasic.Apresentacao.Edit" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Edit</title>
    <link href="~/Content/site.css" rel="stylesheet" />
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
                            <asp:Label ID="AssociadoIdLabel" runat="server" AssociatedControl="AssociadoIdTextBox" Text="AssociadoId" CssClass="control-label" />
                            <asp:TextBox ID="AssociadoIdTextBox" runat="server" CssClass="form-control" Enabled="False" Text='<%# Bind("AssociadoId") %>' />
                            <asp:RequiredFieldValidator ID="AssociadoIdRequiredFieldValidator" runat="server" ControlToValidate="AssociadoIdTextBox" ErrorMessage="AssociadoId é obrigatório." CssClass="text-danger" Display="None" />
                        </div>

                        <div class="form-group">
                            <asp:Label ID="NomeLabel" runat="server" AssociatedControl="NomeTextBox" Text="Nome" CssClass="control-label" />
                            <asp:TextBox ID="NomeTextBox" runat="server" CssClass="form-control" Text='<%# Bind("Nome") %>' />
                            <asp:RequiredFieldValidator ID="NomeRequiredFieldValidator" runat="server" ControlToValidate="NomeTextBox" ErrorMessage="Nome é obrigatório." CssClass="text-danger" />
                        </div>

                        <div class="form-group">
                            <asp:Label ID="CpfLabel" runat="server" AssociatedControl="CpfTextBox" Text="CPF" CssClass="control-label" />
                            <asp:TextBox ID="CpfTextBox" runat="server" CssClass="form-control" Text='<%# Bind("Cpf") %>' />
                            <asp:RequiredFieldValidator ID="CpfRequiredFieldValidator" runat="server" ControlToValidate="CpfTextBox" ErrorMessage="CPF é obrigatório." CssClass="text-danger" />
                            <asp:RegularExpressionValidator ID="CpfRegularExpressionValidator" runat="server" ControlToValidate="CpfTextBox" ValidationExpression="\d{3}\.\d{3}\.\d{3}-\d{2}" ErrorMessage="O CPF deve estar no formato XXX.XXX.XXX-XX" CssClass="text-danger" />
                            <asp:Label ID="CpfErrorLabel" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
                        </div>

                        <div class="form-group">
                            <asp:Label ID="DataNascimentoLabel" runat="server" AssociatedControl="DataNascimentoTextBox" Text="Data de Nascimento" CssClass="control-label" />
                            <asp:TextBox ID="DataNascimentoTextBox" runat="server" CssClass="form-control" Text='<%# Bind("DataNascimento") %>' />
                            <asp:RequiredFieldValidator ID="DataNascimentoRequiredFieldValidator" runat="server" ControlToValidate="DataNascimentoTextBox" ErrorMessage="Data de Nascimento é obrigatória." CssClass="text-danger" />
                            <asp:RangeValidator ID="DataNascimentoRangeValidator" runat="server" ControlToValidate="DataNascimentoTextBox" Type="Date" MinimumValue="1900-01-01" MaximumValue="2100-12-31" ErrorMessage="Data de Nascimento inválida." CssClass="text-danger" />
                        </div>

                        <div class="form-group">
                            <asp:Label ID="EmpresasSelecionadasLabel" runat="server" Text="Empresas" CssClass="control-label" />
                            <asp:ListBox ID="EmpresasListBox" runat="server" SelectionMode="Multiple" CssClass="form-control">
                            </asp:ListBox>
                            <asp:RequiredFieldValidator ID="EmpresasSelecionadasRequiredFieldValidator" runat="server" ControlToValidate="EmpresasListBox" InitialValue="" ErrorMessage="Selecione pelo menos uma empresa." CssClass="text-danger" />
                        </div>

                        <div class="form-group">
                            <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="btn btn-primary" CommandName="Save" OnClick="SaveButton_Click" />
                        </div>
                    </asp:Panel>
                </div>
            </div>

            <div>
                <asp:HyperLink ID="BackToListLink" runat="server" NavigateUrl="~/Views/Associado/Index.aspx" Text="Back to List" />
            </div>
        
    </form>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/5.0.8/jquery.inputmask.min.js"></script>
    <script>
        $(document).ready(function(){
            $('#CpfTextBox').inputmask('999.999.999-99');
        });
    </script>
</body>
</html>
