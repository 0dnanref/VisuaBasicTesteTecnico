Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos
Public Class Index1
    Inherits ViewPage(Of Empresa)

    Private ReadOnly _serviceBase As IServiceBase(Of Empresa)

    Public Sub New()
        Dim serviceBase As IServiceBase(Of Empresa) = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Empresa))), IServiceBase(Of Empresa))
        _serviceBase = serviceBase
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindGrid()
        End If
    End Sub

    Protected Sub FilterButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        BindGrid()
    End Sub

    Private Sub BindGrid()
        Dim nome As String = NomeTextBox.Text
        Dim cnpj As String = CnpjTextBox.Text


        Dim filtro As New EmpresaFilterViewModel With {
                .Nome = nome,
                .Cnpj = cnpj
            }

        Dim empresas = _serviceBase.GetAll()


        If Not String.IsNullOrEmpty(filtro.Nome) Then
            empresas = empresas.Where(Function(a) a.Nome.Contains(filtro.Nome))
        End If

        If Not String.IsNullOrEmpty(filtro.Cnpj) Then
            empresas = empresas.Where(Function(a) a.Cnpj = filtro.Cnpj)
        End If



        GridView.DataSource = empresas
        GridView.DataBind()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles GridView.RowCommand
        Dim id As Integer = Convert.ToInt32(e.CommandArgument)

        Select Case e.CommandName
            Case "Edit"
                Response.Redirect($"~/Empresas/Edit.aspx?id={id}")
            Case "Details"
                Response.Redirect($"~/Empresas/Details.aspx?id={id}")
            Case "Delete"
                Dim associado = _serviceBase.GetById(id)
                If associado IsNot Nothing Then
                    _serviceBase.Remove(associado)
                    BindGrid()
                End If
        End Select
    End Sub

End Class