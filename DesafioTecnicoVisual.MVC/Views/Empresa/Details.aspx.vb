Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Public Class Details1
    Inherits ViewPage(Of Empresa)

    Private ReadOnly _serviceBase As IServiceBase(Of Associado)
    Private ReadOnly _serviceEmpresa As IEmpresaService
    Private ReadOnly _serviceAssociadoBase As IAssociadoService

    Public Sub New()
        Dim serviceBase As IServiceBase(Of Associado) = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Associado))), IServiceBase(Of Associado))
        Dim serviceEmpresa As IEmpresaService = CType(DependencyResolver.Current.GetService(GetType(IEmpresaService)), IEmpresaService)
        Dim serviceAssociadoBase As IAssociadoService = CType(DependencyResolver.Current.GetService(GetType(IAssociadoService)), IAssociadoService)
        _serviceBase = serviceBase
        _serviceAssociadoBase = serviceAssociadoBase
        _serviceEmpresa = serviceEmpresa
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim empresaId As Integer = Convert.ToInt32(Request.QueryString("id"))
            Dim empresa As Empresa = ObterEmpresa(empresaId)
            If empresa IsNot Nothing Then
                BindData(empresa)
            End If
        End If
    End Sub

    Private Function ObterEmpresa(ByVal empresaId As Integer) As Empresa
        Return _serviceEmpresa.GetByIdIncludeAssociados(empresaId)
    End Function

    Private Sub BindData(ByVal empresa As Empresa)
        NomeLabel.Text = empresa.Nome
        CnpjLabel.Text = empresa.Cnpj

        AssociadosRepeater.DataSource = empresa.Associados
        AssociadosRepeater.DataBind()
    End Sub

End Class