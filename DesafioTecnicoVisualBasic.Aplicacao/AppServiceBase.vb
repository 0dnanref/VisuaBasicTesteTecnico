Imports DesafioTecnicoVisualBasic.Aplicacao.DesafioTecnicoVisualBasic.Aplicacao.Interface
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Namespace DesafioTecnicoVisualBasic.Aplicacao
    Public Class AppServiceBase(Of TEntity As Class)
        Implements IAppServiceBase(Of TEntity)

        Private ReadOnly _service As IServiceBase(Of TEntity)

        Public Sub New(service As IServiceBase(Of TEntity))
            _service = service
        End Sub

        Public Sub Add(entity As TEntity) Implements IAppServiceBase(Of TEntity).Add
            _service.Add(entity)
        End Sub

        Public Function GetAll() As IEnumerable(Of TEntity) Implements IAppServiceBase(Of TEntity).GetAll
            Return _service.GetAll()
        End Function

        Public Function GetById(id As Integer) As TEntity Implements IAppServiceBase(Of TEntity).GetById
            Return _service.GetById(id)
        End Function

        Public Sub Remove(entity As TEntity) Implements IAppServiceBase(Of TEntity).Remove
            _service.Remove(entity)
        End Sub

        Public Sub Update(entity As TEntity) Implements IAppServiceBase(Of TEntity).Update
            _service.Update(entity)
        End Sub
    End Class
End Namespace

