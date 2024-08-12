<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Create.aspx.vb" Inherits="DesafioTecnicoVisualBasic.Apresentacao.Create" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Create</title>
    <link href="~/Content/Cadastro.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
      
            <h1>Create</h1>          
            <hr />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <asp:Label ID="NomeLabel" runat="server" AssociatedControl="NomeTextBox" Text="Nome"></asp:Label>
                        <asp:TextBox ID="NomeTextBox" runat="server" CssClass="form-control" Text='<%# Bind("Nome") %>' />
                        <asp:RequiredFieldValidator ID="NomeRequiredFieldValidator" runat="server" ControlToValidate="NomeTextBox" ErrorMessage="Nome é obrigatório." CssClass="text-danger" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="CpfLabel" runat="server" AssociatedControl="CpfTextBox" Text="CPF"></asp:Label>
                        <asp:TextBox ID="CpfTextBox" runat="server" CssClass="form-control" Text='<%# Bind("Cpf") %>' />
                        <asp:RequiredFieldValidator ID="CpfRequiredFieldValidator" runat="server" ControlToValidate="CpfTextBox" ErrorMessage="CPF é obrigatório." CssClass="text-danger" />
                        <asp:Label ID="CpfErrorLabel" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="DataNascimentoLabel" runat="server" AssociatedControl="DataNascimentoTextBox" Text="Data de Nascimento"></asp:Label>
                        <asp:TextBox ID="DataNascimentoTextBox" runat="server" CssClass="form-control" Text='<%# Bind("DataNascimento") %>' />
                        <asp:RequiredFieldValidator ID="DataNascimentoRequiredFieldValidator" runat="server" ControlToValidate="DataNascimentoTextBox" ErrorMessage="Data de Nascimento é obrigatória." CssClass="text-danger" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="EmpresasSelecionadasLabel" runat="server" Text="Empresas"></asp:Label>
                        <asp:ListBox ID="EmpresasListBox" runat="server" SelectionMode="Multiple" CssClass="form-control">
                        </asp:ListBox>
                        <asp:RequiredFieldValidator ID="EmpresasSelecionadasRequiredFieldValidator" runat="server" ControlToValidate="EmpresasListBox" InitialValue="" ErrorMessage="Selecione pelo menos uma empresa." CssClass="text-danger" />
                    </div>
                    <div class="form-group">    
                        
                        <asp:Button ID="CreateButton" OnClientClick="CreateButton_Click" runat="server" Text="Salvar" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
            <div>
                <asp:HyperLink ID="BackToListLink" runat="server" NavigateUrl="~/Views/Associado/Index.aspx" Text="Back to List"></asp:HyperLink>
            </div>
    </form>

   <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.inputmask/5.0.8/jquery.inputmask.min.js"></script>
    <script>
        $(document).ready(function () {
            $('#CpfTextBox').inputmask('999.999.999-99');
        });
    </script>
</body>
</html>
