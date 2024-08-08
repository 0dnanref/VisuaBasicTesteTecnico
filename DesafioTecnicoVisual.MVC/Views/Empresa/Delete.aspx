<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Delete.aspx.vb" Inherits="DesafioTecnicoVisualBasic.Apresentacao.Delete1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Delete</title>
    <link href="~/Content/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Delete</h1>
            <h3>Você tem certeza de que deseja excluir isso?</h3>
            <div>
                <h4>AssociadoViewModel</h4>
                <hr />
                <dl class="row">
                    <dt class="col-sm-2">
                        Nome
                    </dt>
                    <dd class="col-sm-10">
                        <asp:Label ID="NomeLabel" runat="server" Text='<%# Bind("Nome") %>' />
                    </dd>
                    <dt class="col-sm-2">
                        CNPJ
                    </dt>
                    <dd class="col-sm-10">
                        <asp:Label ID="CnpjLabel" runat="server" Text='<%# Bind("Cnpj") %>' />
                    </dd>
                    
                    
                    <dd class="col-sm-10">
                        <asp:Repeater ID="AssociadoRepeater" runat="server">
                            <ItemTemplate>
                                <div>
                                    <asp:Label ID="AssociadoNomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </dd>
                </dl>
                <asp:Button ID="DeleteButton" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="DeleteButton_Click" />
                <asp:HyperLink ID="BackLink" runat="server" NavigateUrl="~/Views/Empresa/Index.aspx" Text="Back to List" />
            </div>
        </div>
    </form>
</body>
</html>

