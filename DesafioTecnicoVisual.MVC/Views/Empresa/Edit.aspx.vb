Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos


Public Class Edit1
    Inherits Page

    Private ReadOnly _serviceBase As IServiceBase(Of Empresa)
    Private ReadOnly _serviceEmpresa As IEmpresaService
    Private ReadOnly _serviceBaseAssociado As IServiceBase(Of Associado)

    Public Sub New()
        _serviceBase = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Empresa))), IServiceBase(Of Empresa))
        _serviceEmpresa = CType(DependencyResolver.Current.GetService(GetType(IEmpresaService)), IEmpresaService)
        _serviceBaseAssociado = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Associado))), IServiceBase(Of Associado))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim empresaId As Integer = Convert.ToInt32(Request.QueryString("id"))
            Dim empresa As Empresa = ObterEmpresa(empresaId)

            Dim associados As List(Of Associado) = _serviceBaseAssociado.GetAll()
            AssociadosListBox.DataSource = associados
            AssociadosListBox.DataTextField = "Nome"
            AssociadosListBox.DataValueField = "AssociadoId"
            AssociadosListBox.DataBind()

            If empresa IsNot Nothing Then
                BindData(empresa)
            End If

        End If
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveButton.Click
        If Page.IsValid Then


            Dim idEmpresaCnpj = _serviceEmpresa.GetIdByCnpj(CnpjTextBox.Text)
            Dim result = _serviceEmpresa.ExisteCnpj(CnpjTextBox.Text)

            If result AndAlso idEmpresaCnpj <> Convert.ToInt32(CnpjTextBox.Text) Then
                CnpjErrorLabel.Text = "Este CNPJ já está cadastrado para outra empresa."
                CnpjErrorLabel.Visible = True
                Return

            Else

                Dim empresa As New Empresa() With {
                   .EmpresaId = Convert.ToInt32(EmpresaIdTextBox.Text),
                   .Nome = NomeTextBox.Text,
                   .Cnpj = CnpjTextBox.Text,
                   .Associados = ObterAssociadosSelecionadas()
               }

                AtualizarEmpresa(empresa)

                ' Redirecionar ou mostrar uma mensagem de sucesso
                Response.Redirect("~/Views/Empresa/Index.aspx")

            End If

        End If
    End Sub

    Private Function ObterEmpresa(ByVal empresaId As Integer) As Empresa
        Return _serviceEmpresa.GetByIdIncludeAssociados(empresaId)
    End Function

    Private Sub BindData(ByVal empresa As Empresa)
        EmpresaIdTextBox.Text = empresa.EmpresaId.ToString()
        NomeTextBox.Text = empresa.Nome
        CnpjTextBox.Text = empresa.Cnpj

        ' Marcar os associados selecionadas
        For Each associado As Associado In empresa.Associados
            Dim item As ListItem = AssociadosListBox.Items.FindByValue(empresa.EmpresaId.ToString())
            If item IsNot Nothing Then
                item.Selected = True
            End If
        Next
    End Sub

    Private Function ObterAssociadosSelecionadas() As List(Of Associado)
        Dim AssociadoSelecionadas As New List(Of Associado)
        For Each item As ListItem In AssociadosListBox.Items
            If item.Selected Then
                AssociadoSelecionadas.Add(New Associado With {
                        .AssociadoId = Convert.ToInt32(item.Value),
                        .Nome = item.Text
                    })
            End If
        Next
        Return AssociadoSelecionadas
    End Function

    Private Sub AtualizarEmpresa(ByVal empresa As Empresa)
        _serviceBase.Add(empresa)
    End Sub

End Class