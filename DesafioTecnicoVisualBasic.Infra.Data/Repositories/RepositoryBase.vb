Imports System.Data.SqlClient
Imports System.Reflection
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories

Namespace DesafioTecnicoVisualBasic.Infra.Data.Repositorios
    Public Class RepositoryBase(Of TEntity As Class)
        Implements IRepositoryBase(Of TEntity)

        Protected ReadOnly ConnectionString As String



        ' Construtor padrão
        Public Sub New()
        End Sub

        ' Construtor que recebe a string de conexão
        Public Sub New(connectionString As String)
            Me.ConnectionString = connectionString
        End Sub

        Public Sub Add(entity As TEntity) Implements IRepositoryBase(Of TEntity).Add
            Using conn As New SqlConnection(ConnectionString)
                Dim insertQuery As String = BuildInsertQuery(entity)
                Using cmd As New SqlCommand(insertQuery, conn)
                    AddParameters(cmd, entity)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Function GetAll() As IEnumerable(Of TEntity) Implements IRepositoryBase(Of TEntity).GetAll
            Dim entities As New List(Of TEntity)()
            Dim tableName As String = GetTableName()

            Using conn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand($"SELECT * FROM {tableName}", conn)
                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim entity As TEntity = MapToEntity(reader)
                            entities.Add(entity)
                        End While
                    End Using
                End Using
            End Using

            Return entities
        End Function

        Public Function GetById(id As Integer) As TEntity Implements IRepositoryBase(Of TEntity).GetById
            Dim entity As TEntity = Nothing
            Dim tableName As String = GetTableName()
            Dim idName As String = Nothing
            If (tableName = "Associado") Then
                idName = "AssociadoId"
            Else
                idName = "EmpresaId"
            End If
            Using conn As New SqlConnection(ConnectionString)
                Using cmd As New SqlCommand($"SELECT * FROM {tableName} WHERE {idName} = @Id", conn)
                    cmd.Parameters.AddWithValue("@Id", id)
                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            entity = MapToEntity(reader)
                        End If
                    End Using
                End Using
            End Using

            Return entity
        End Function

        Public Sub Remove(entity As TEntity) Implements IRepositoryBase(Of TEntity).Remove
            Using conn As New SqlConnection(ConnectionString)
                Dim tableName As String = GetTableName()

                Dim idName As String = Nothing
                If (tableName = "Associado") Then
                    idName = "AssociadoId"
                Else
                    idName = "EmpresaId"
                End If


                Dim id = GetPropertyValue(entity, idName)
                Using cmd As New SqlCommand($"DELETE FROM {tableName} WHERE {idName} = @Id", conn)
                    cmd.Parameters.AddWithValue("@Id", id)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Public Sub Update(entity As TEntity) Implements IRepositoryBase(Of TEntity).Update
            Using conn As New SqlConnection(ConnectionString)
                Dim updateQuery As String = BuildUpdateQuery(entity)
                Using cmd As New SqlCommand(updateQuery, conn)
                    AddParameters(cmd, entity)
                    conn.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        End Sub

        Private Function BuildInsertQuery(entity As TEntity) As String
            Dim tableName As String = GetTableName()
            Dim properties = entity.GetType().GetProperties()
            Dim columns = String.Join(",", properties.Select(Function(p) p.Name))
            Dim values = String.Join(",", properties.Select(Function(p) $"@{p.Name}"))
            Return $"INSERT INTO {tableName} ({columns}) VALUES ({values})"
        End Function

        Private Function BuildUpdateQuery(entity As TEntity) As String
            Dim tableName As String = GetTableName()
            Dim properties = entity.GetType().GetProperties()
            Dim setClause = String.Join(",", properties.Where(Function(p) p.Name <> "Id").Select(Function(p) $"{p.Name} = @{p.Name}"))
            Return $"UPDATE {tableName} SET {setClause} WHERE Id = @Id"
        End Function

        Private Sub AddParameters(cmd As SqlCommand, entity As TEntity)
            For Each prop As PropertyInfo In entity.GetType().GetProperties()
                cmd.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(entity, Nothing))
            Next
        End Sub

        Private Function GetPropertyValue(entity As TEntity, propertyName As String) As Object
            Return entity.GetType().GetProperty(propertyName).GetValue(entity, Nothing)
        End Function

        Private Function GetTableName() As String
            ' Nome da tabela deve ser o nome da classe. Se precisar de personalização, ajuste aqui.
            Return GetType(TEntity).Name
        End Function

        Private Function MapToEntity(reader As SqlDataReader) As TEntity

            ' Cria uma instância de TEntity
            Dim entity As TEntity = Activator.CreateInstance(Of TEntity)()

            ' Mapeia as colunas do DataReader para as propriedades da entidade
            For Each prop As PropertyInfo In GetType(TEntity).GetProperties()

                'Esse código pode ser melhorado por hora vai ficar assim
                If prop.Name = "Empresas" Then
                    Continue For
                End If

                If prop.Name = "Associados" Then
                    Continue For
                End If

                ' Verifica se a coluna existe no DataReader antes de tentar acessá-la
                If reader.GetOrdinal(prop.Name) >= 0 AndAlso Not IsDBNull(reader(prop.Name)) Then
                    prop.SetValue(entity, reader(prop.Name), Nothing)
                End If
            Next
            Return entity
        End Function
    End Class

End Namespace
