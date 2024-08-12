<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Details.aspx.vb" Inherits="DesafioTecnicoVisualBasic.Apresentacao.Details1" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Details</title>
    <link href="~/Content/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        
            <h1>Details</h1>         
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
                    <asp:Repeater ID="AssociadosRepeater" runat="server">
                        <ItemTemplate>
                            <div>
                                <asp:Label ID="AssociadoNomeLabel" runat="server" Text='<%# Eval("Nome") %>' />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </dd>
            </dl>
        
        <div>
            <asp:LinkButton ID="EditLink" runat="server" Text="Edit" PostBackUrl='<%# ResolveUrl("~/Empresa/Edit.aspx?id=" & Bind("EmpresaId")) %>' />
            <asp:HyperLink ID="BackLink" runat="server" NavigateUrl="~/Views/Empresa/Index.aspx" Text="Back to List" />
        </div>
    </form>
</body>
</html>
