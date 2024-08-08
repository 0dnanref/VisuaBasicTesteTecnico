
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Namespace DesafioTecnicoVisualBasic.Domain.Servicos
    Public Class AssociadoService
        Inherits ServiceBase(Of Associado)
        Implements IAssociadoService

        Private ReadOnly _associadoRepository As IAssociadoRepository

        Public Sub New()
        End Sub


        Public Sub New(associadoRepository As IAssociadoRepository)
            MyBase.New(associadoRepository)
            _associadoRepository = associadoRepository
        End Sub

        Public Function ExisteCpf(cpf As String) As Boolean Implements IAssociadoService.ExisteCpf
            Return _associadoRepository.ExisteCpf(cpf)
        End Function

        Public Function GetByIdIncludeEmpresas(id As Integer) As Associado Implements IAssociadoService.GetByIdIncludeEmpresas
            Return _associadoRepository.GetByIdIncludeEmpresas(id)
        End Function

        Public Function GetIdByCpf(cpf As String) As Integer Implements IAssociadoService.GetIdByCpf
            Return _associadoRepository.GetIdByCpf(cpf)
        End Function
    End Class
End Namespace
