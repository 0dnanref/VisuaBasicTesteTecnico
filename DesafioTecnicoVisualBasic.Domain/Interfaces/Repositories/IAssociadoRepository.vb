Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades

Namespace DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories
    Public Interface IAssociadoRepository
        Inherits IRepositoryBase(Of Associado)

        Function ExisteCpf(cpf As String) As Boolean
        Function GetByIdIncludeEmpresas(id As Integer) As Associado
        Function GetIdByCpf(cpf As String) As Integer
    End Interface
End Namespace
