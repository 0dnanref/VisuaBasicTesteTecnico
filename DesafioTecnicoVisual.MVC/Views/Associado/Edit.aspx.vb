Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Public Class Edit
    Inherits ViewPage

    Private ReadOnly _serviceBase As IServiceBase(Of Associado)
    Private ReadOnly _serviceEmpresa As IServiceBase(Of Empresa)
    Private ReadOnly _serviceAssociadoBase As IAssociadoService

    Public Sub New()
        _serviceBase = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Associado))), IServiceBase(Of Associado))
        _serviceEmpresa = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Empresa))), IServiceBase(Of Empresa))
        _serviceAssociadoBase = CType(DependencyResolver.Current.GetService(GetType(IAssociadoService)), IAssociadoService)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim associadoId As Integer = Convert.ToInt32(Request.QueryString("id"))
            Dim associado As Associado = ObterAssociado(associadoId)

            Dim empresas As List(Of Empresa) = _serviceEmpresa.GetAll()
            EmpresasListBox.DataSource = empresas
            EmpresasListBox.DataTextField = "Nome"
            EmpresasListBox.DataValueField = "EmpresaId"
            EmpresasListBox.DataBind()

            If associado IsNot Nothing Then
                BindData(associado)
            End If

        End If
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveButton.Click
        If Page.IsValid Then


            Dim idAssociadoCpf = _serviceAssociadoBase.GetIdByCpf(CpfTextBox.Text)
            Dim result = _serviceAssociadoBase.ExisteCpf(CpfTextBox.Text)

            If result AndAlso idAssociadoCpf <> Convert.ToInt32(CpfTextBox.Text) Then
                CpfErrorLabel.Text = "Este Cpf já está cadastrado para outro associado."
                CpfErrorLabel.Visible = True
                Return
            Else

                Dim associado As New Associado() With {
                   .AssociadoId = Convert.ToInt32(AssociadoIdTextBox.Text),
                   .Nome = NomeTextBox.Text,
                   .Cpf = CpfTextBox.Text,
                   .DataNascimento = DateTime.Parse(DataNascimentoTextBox.Text),
                   .Empresas = ObterEmpresasSelecionadas()
               }

                AtualizarAssociado(associado)

                ' Redirecionar ou mostrar uma mensagem de sucesso
                Response.Redirect("~/Views/Associado/Index.aspx")

            End If

        End If
    End Sub

    Private Function ObterAssociado(ByVal associadoId As Integer) As Associado
        Return _serviceAssociadoBase.GetByIdIncludeEmpresas(associadoId)
    End Function

    Private Sub BindData(ByVal associado As Associado)
        AssociadoIdTextBox.Text = associado.AssociadoId.ToString()
        NomeTextBox.Text = associado.Nome
        CpfTextBox.Text = associado.Cpf
        DataNascimentoTextBox.Text = associado.DataNascimento.ToString("yyyy-MM-dd")

        ' Marcar as empresas selecionadas
        For Each empresa As Empresa In associado.Empresas
            Dim item As ListItem = EmpresasListBox.Items.FindByValue(empresa.EmpresaId.ToString())
            If item IsNot Nothing Then
                item.Selected = True
            End If
        Next
    End Sub

    Private Function ObterEmpresasSelecionadas() As List(Of Empresa)
        Dim empresasSelecionadas As New List(Of Empresa)
        For Each item As ListItem In EmpresasListBox.Items
            If item.Selected Then
                empresasSelecionadas.Add(New Empresa With {
                        .EmpresaId = Convert.ToInt32(item.Value),
                        .Nome = item.Text
                    })
            End If
        Next
        Return empresasSelecionadas
    End Function

    Private Sub AtualizarAssociado(ByVal associado As Associado)
        _serviceBase.Add(associado)
    End Sub

End Class