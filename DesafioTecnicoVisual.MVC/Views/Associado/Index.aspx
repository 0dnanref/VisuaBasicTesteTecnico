<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Index.aspx.vb" Inherits="DesafioTecnicoVisualBasic.Apresentacao.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
     <link href="~/Content/Index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Index</h1>

            <asp:HyperLink ID="CreateNewLink" runat="server" NavigateUrl="~/Associado/Create.aspx" Text="Create New" />

            <!-- Formulário de filtro -->
            <asp:Panel ID="FilterPanel" runat="server">
                <div class="form-group">
                    <label for="Nome">Nome</label>
                    <asp:TextBox ID="NomeTextBox" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label for="Cpf">CPF</label>
                    <asp:TextBox ID="CpfTextBox" runat="server" CssClass="form-control" />
                </div>
                <div class="form-group">
                    <label for="DataNascimento">Data de Nascimento</label>
                    <asp:TextBox ID="DataNascimentoTextBox" runat="server" CssClass="form-control" TextMode="Date" />
                </div>
                <asp:Button ID="FilterButton" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="FilterButton_Click" />
            </asp:Panel>

            <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Cpf" HeaderText="CPF" />
                    <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="EditButton" runat="server" CommandName="Edit" CommandArgument='<%# Eval("AssociadoId") %>' Text="Edit" />
                            <asp:LinkButton ID="DetailsButton" runat="server" CommandName="Details" CommandArgument='<%# Eval("AssociadoId") %>' Text="Details" />
                            <asp:LinkButton ID="DeleteButton" runat="server" CommandName="Delete" CommandArgument='<%# Eval("AssociadoId") %>' Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
