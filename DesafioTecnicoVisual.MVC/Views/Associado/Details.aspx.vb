Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Public Class Details
    Inherits ViewPage


    Private ReadOnly _serviceBase As IServiceBase(Of Associado)
    Private ReadOnly _serviceEmpresa As IServiceBase(Of Empresa)
    Private ReadOnly _serviceAssociadoBase As IAssociadoService

    Public Sub New()
        Dim serviceBase As IServiceBase(Of Associado) = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Associado))), IServiceBase(Of Associado))
        Dim serviceEmpresa As IServiceBase(Of Empresa) = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Empresa))), IServiceBase(Of Empresa))
        Dim serviceAssociadoBase As IAssociadoService = CType(DependencyResolver.Current.GetService(GetType(IAssociadoService)), IAssociadoService)
        _serviceBase = serviceBase
        _serviceAssociadoBase = serviceAssociadoBase
        _serviceEmpresa = serviceEmpresa
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim associadoId As Integer = Convert.ToInt32(Request.QueryString("id"))
            Dim associado As Associado = ObterAssociado(associadoId)
            If associado IsNot Nothing Then
                BindData(associado)
            End If
        End If
    End Sub

    Private Function ObterAssociado(ByVal associadoId As Integer) As Associado
        Return _serviceAssociadoBase.GetByIdIncludeEmpresas(associadoId)
    End Function

    Private Sub BindData(ByVal associado As Associado)
        NomeLabel.Text = associado.Nome
        CpfLabel.Text = associado.Cpf
        DataNascimentoLabel.Text = associado.DataNascimento.ToString("dd/MM/yyyy")

        EmpresasRepeater.DataSource = associado.Empresas
        EmpresasRepeater.DataBind()
    End Sub

End Class