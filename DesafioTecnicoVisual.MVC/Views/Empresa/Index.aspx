<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="DesafioTecnicoVisualBasic.Apresentacao.Index1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Index</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Index</h1>

            <p>
                <asp:LinkButton ID="CreateLinkButton" runat="server" PostBackUrl="~/Empresa/Create.aspx">Create New</asp:LinkButton>
            </p>

            <!-- Formulário de filtro -->
            <asp:Panel ID="FilterPanel" runat="server">
                <div class="form-group">
                    <asp:Label ID="NomeLabel" runat="server" Text="Nome" AssociatedControlID="NomeTextBox" />
                    <asp:TextBox ID="NomeTextBox" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <asp:Label ID="CnpjLabel" runat="server" Text="CNPJ" AssociatedControlID="CnpjTextBox" />
                    <asp:TextBox ID="CnpjTextBox" runat="server" CssClass="form-control" />
                </div>
                <asp:Button ID="FilterButton" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="FilterButton_Click" />
            </asp:Panel>

            <asp:GridView ID="EmpresasGridView" runat="server" CssClass="table" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Cnpj" HeaderText="CNPJ" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="EditLinkButton" runat="server" CommandName="Edit" CommandArgument='<%# Eval("EmpresaId") %>' Text="Edit" />
                            |
                            <asp:LinkButton ID="DetailsLinkButton" runat="server" CommandName="Details" CommandArgument='<%# Eval("EmpresaId") %>' Text="Details" />
                            |
                            <asp:LinkButton ID="DeleteLinkButton" runat="server" CommandName="Delete" CommandArgument='<%# Eval("EmpresaId") %>' Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
