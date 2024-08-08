Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades

Namespace DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories
    Public Interface IEmpresaRepository
        Inherits IRepositoryBase(Of Empresa)

        Function ExisteCnpj(cnpj As String) As Boolean
        Function GetByIdIncludeAssociados(id As Integer) As Empresa
        Function GetIdByCnpj(cnpj As String) As Integer
    End Interface
End Namespace
