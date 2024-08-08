Imports DesafioTecnicoVisualBasic.Aplicacao.DesafioTecnicoVisualBasic.Aplicacao.Interface
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Namespace DesafioTecnicoVisualBasic.Aplicacao
    Public Class AssociadoAppService
        Inherits AppServiceBase(Of Associado)
        Implements IAssociadoAppService

        Private ReadOnly _associadoService As IAssociadoService

        Public Sub New(service As IAssociadoService)
            MyBase.New(service)
            _associadoService = service
        End Sub

        Public Function ExisteCpf(cpf As String) As Boolean Implements IAssociadoAppService.ExisteCpf
            Return _associadoService.ExisteCpf(cpf)
        End Function

        Public Function GetByIdIncludeEmpresas(id As Integer) As Associado Implements IAssociadoAppService.GetByIdIncludeEmpresas
            Return _associadoService.GetByIdIncludeEmpresas(id)
        End Function

        Public Function GetIdByCpf(cpf As String) As Integer Implements IAssociadoAppService.GetIdByCpf
            Return _associadoService.GetIdByCpf(cpf)
        End Function
    End Class
End Namespace

