Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Namespace DesafioTecnicoVisualBasic.Domain.Servicos
    Public Class ServiceBase(Of TEntity As Class)
        Implements IServiceBase(Of TEntity)

        Private ReadOnly _repository As IRepositoryBase(Of TEntity)

        Public Sub New()
        End Sub

        Public Sub New(repository As IRepositoryBase(Of TEntity))
            _repository = repository
        End Sub

        Public Sub Add(entity As TEntity) Implements IServiceBase(Of TEntity).Add
            _repository.Add(entity)
        End Sub

        Public Function GetAll() As IEnumerable(Of TEntity) Implements IServiceBase(Of TEntity).GetAll
            Return _repository.GetAll()
        End Function

        Public Function GetById(id As Integer) As TEntity Implements IServiceBase(Of TEntity).GetById
            Return _repository.GetById(id)
        End Function

        Public Sub Remove(entity As TEntity) Implements IServiceBase(Of TEntity).Remove
            _repository.Remove(entity)
        End Sub

        Public Sub Update(entity As TEntity) Implements IServiceBase(Of TEntity).Update
            _repository.Update(entity)
        End Sub
    End Class
End Namespace

