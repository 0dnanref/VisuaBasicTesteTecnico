Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Public Class Create1
    Inherits ViewPage(Of Empresa)

    Private ReadOnly _serviceBaseEmpresa As IServiceBase(Of Empresa)
    Private ReadOnly _serviceBaseAssociado As IServiceBase(Of Associado)
    Public Sub New()
        Dim serviceBaseEmpresa As IServiceBase(Of Empresa) = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Empresa))), IServiceBase(Of Empresa))
        Dim serviceBaseAssociado As IServiceBase(Of Associado) = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Associado))), IServiceBase(Of Associado))
        _serviceBaseEmpresa = serviceBaseEmpresa
        _serviceBaseAssociado = serviceBaseAssociado
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Not IsPostBack Then

            Dim associado As List(Of Associado) = _serviceBaseAssociado.GetAll()

            AssociadosListBox.DataSource = associado
            AssociadosListBox.DataTextField = "Nome"
            AssociadosListBox.DataValueField = "AssociadoId"
            AssociadosListBox.DataBind()
        End If


    End Sub


    Private Function ObterAssociadosSelecionadas() As List(Of Associado)

        Dim associadoSelecionadas As New List(Of Associado)
        For Each item As ListItem In AssociadosListBox.Items
            If item.Selected Then
                associadoSelecionadas.Add(New Associado With {
                    .AssociadoId = Convert.ToInt32(item.Value),
                    .Nome = item.Text
                })
            End If
        Next
        Return associadoSelecionadas
    End Function

    Protected Sub CreateButton_Click1(ByVal sender As Object, ByVal e As EventArgs)
        If Page.IsValid Then

            Dim novoAssociado As New Empresa() With {
                .Nome = NomeTextBox.Text,
                .Cnpj = CnpjTextBox.Text,
                .Associados = ObterAssociadosSelecionadas()
            }

            _serviceBaseEmpresa.Add(novoAssociado)

            Response.Redirect("~/Views/Empresas/Index.aspx")
        End If
    End Sub

End Class