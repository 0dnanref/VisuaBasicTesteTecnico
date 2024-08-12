Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Apresentacao.DesafioTecnicoAspNet.MVC.Filtros
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos


Public Class Index
    Inherits ViewPage(Of Associado)


    Private ReadOnly _serviceBase As IServiceBase(Of Associado)

    Public Sub New()
        Dim serviceBase As IServiceBase(Of Associado) = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Associado))), IServiceBase(Of Associado))
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
        Dim cpf As String = CpfTextBox.Text
        Dim dataNascimento As DateTime

        DateTime.TryParse(DataNascimentoTextBox.Text, dataNascimento)

        Dim filtro As New AssociadoFilterViewModel With {
                .Nome = nome,
                .Cpf = cpf,
                .DataNascimento = If(dataNascimento <> DateTime.MinValue, dataNascimento, CType(Nothing, DateTime?))
            }

        Dim associados = _serviceBase.GetAll()


        If Not String.IsNullOrEmpty(filtro.Nome) Then
            associados = associados.Where(Function(a) a.Nome.Contains(filtro.Nome))
        End If

        If Not String.IsNullOrEmpty(filtro.Cpf) Then
            associados = associados.Where(Function(a) a.Cpf = filtro.Cpf)
        End If

        If filtro.DataNascimento.HasValue Then
            associados = associados.Where(Function(a) a.DataNascimento = filtro.DataNascimento.Value)
        End If

        GridView.DataSource = associados
        GridView.DataBind()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs) Handles GridView.RowCommand
        Dim id As Integer = Convert.ToInt32(e.CommandArgument)

        Select Case e.CommandName
            Case "Edit"
                Response.Redirect($"~/Associado/Edit.aspx?id={id}")
            Case "Details"
                Response.Redirect($"~/Associado/Details.aspx?id={id}")
            Case "Delete"
                Dim associado = _serviceBase.GetById(id)
                If associado IsNot Nothing Then
                    _serviceBase.Remove(associado)
                    BindGrid()
                End If
        End Select
    End Sub

End Class