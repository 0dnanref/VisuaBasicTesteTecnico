Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos


Public Class Delete1
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
            ' Carregar dados do associado para detalhes
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


        AssociadoRepeater.DataSource = empresa.Associados
        AssociadoRepeater.DataBind()
    End Sub

    Protected Sub DeleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim id = Convert.ToInt32(Request.QueryString("id"))
        Dim associado = _serviceAssociadoBase.GetByIdIncludeEmpresas(id)
        ExcluirAssociado(associado)

        Response.Redirect("~/Index.aspx")
    End Sub

    Private Sub ExcluirAssociado(ByVal associado As Associado)
        _serviceAssociadoBase.Remove(associado)
    End Sub

End Class