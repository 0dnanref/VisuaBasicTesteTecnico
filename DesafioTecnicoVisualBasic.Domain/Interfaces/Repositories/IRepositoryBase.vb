Namespace DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories
    Public Interface IRepositoryBase(Of TEntity As Class)
        Sub Add(entity As TEntity)
        Function GetById(id As Integer) As TEntity
        Function GetAll() As IEnumerable(Of TEntity)
        Sub Update(entity As TEntity)
        Sub Remove(entity As TEntity)
    End Interface
End Namespace

