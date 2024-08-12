<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Create.aspx.vb" Inherits="DesafioTecnicoVisualBasic.Apresentacao.Create1" %>

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
                        <asp:Label ID="CnpjLabel" runat="server" AssociatedControl="CnpjTextBox" Text="Cnpj"></asp:Label>
                        <asp:TextBox ID="CnpjTextBox" runat="server" CssClass="form-control" Text='<%# Bind("Cnpj") %>' />
                        <asp:RequiredFieldValidator ID="CpfRequiredFieldValidator" runat="server" ControlToValidate="CnpjTextBox" ErrorMessage="Cnpj é obrigatório." CssClass="text-danger" />
                        <asp:Label ID="CnpjErrorLabel" runat="server" CssClass="text-danger" Visible="False"></asp:Label>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label ID="AssociadosSelecionadasLabel" runat="server" Text="Associados"></asp:Label>
                        <asp:ListBox ID="AssociadosListBox" runat="server" SelectionMode="Multiple" CssClass="form-control">
                        </asp:ListBox>
                        <asp:RequiredFieldValidator ID="AssociadosSelecionadasRequiredFieldValidator" runat="server" ControlToValidate="AssociadosListBox" InitialValue="" ErrorMessage="Selecione pelo menos um associado." CssClass="text-danger" />
                    </div>
                    <div class="form-group">    
                        
                        <asp:Button ID="CreateButton" OnClientClick="CreateButton_Click" runat="server" Text="Salvar" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
            <div>
                <asp:HyperLink ID="BackToListLink" runat="server" NavigateUrl="~/Views/Empresa/Index.aspx" Text="Back to List"></asp:HyperLink>
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
