
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Namespace DesafioTecnicoVisualBasic.Domain.Servicos
    Public Class EmpresaService
        Inherits ServiceBase(Of Empresa)
        Implements IEmpresaService

        Private ReadOnly _empresaRepository As IEmpresaRepository

        Public Sub New()
        End Sub

        Public Sub New(empresaRepository As IEmpresaRepository)
            MyBase.New(empresaRepository)
            _empresaRepository = empresaRepository
        End Sub

        Public Function ExisteCnpj(cnpj As String) As Boolean Implements IEmpresaService.ExisteCnpj
            Return _empresaRepository.ExisteCnpj(cnpj)
        End Function

        Public Function GetByIdIncludeAssociados(id As Integer) As Empresa Implements IEmpresaService.GetByIdIncludeAssociados
            Return _empresaRepository.GetByIdIncludeAssociados(id)
        End Function

        Public Function GetIdByCnpj(cnpj As String) As Integer Implements IEmpresaService.GetIdByCnpj
            Return _empresaRepository.GetIdByCnpj(cnpj)
        End Function
    End Class
End Namespace
