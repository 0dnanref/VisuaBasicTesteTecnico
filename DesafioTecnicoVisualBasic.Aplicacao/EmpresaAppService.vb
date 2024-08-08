Imports DesafioTecnicoVisualBasic.Aplicacao.DesafioTecnicoVisualBasic.Aplicacao.Interface
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Namespace DesafioTecnicoVisualBasic.Aplicacao
    Public Class EmpresaAppService
        Inherits AppServiceBase(Of Empresa)
        Implements IEmpresaAppService

        Private ReadOnly _empresaService As IEmpresaService

        Public Sub New(service As IEmpresaService)
            MyBase.New(service)
            _empresaService = service
        End Sub

        Public Function ExisteCnpj(cnpj As String) As Boolean Implements IEmpresaAppService.ExisteCnpj
            Return _empresaService.ExisteCnpj(cnpj)
        End Function

        Public Function GetByIdIncludeAssociados(id As Integer) As Empresa Implements IEmpresaAppService.GetByIdIncludeAssociados
            Return _empresaService.GetByIdIncludeAssociados(id)
        End Function

        Public Function GetIdByCnpj(cnpj As String) As Integer Implements IEmpresaAppService.GetIdByCnpj
            Return _empresaService.GetIdByCnpj(cnpj)
        End Function
    End Class
End Namespace

