Imports System.Data.SqlClient
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories

Namespace DesafioTecnicoVisualBasic.Infra.Data.Repositorios
    Public Class EmpresaRepository
        Inherits RepositoryBase(Of Empresa)
        Implements IEmpresaRepository

        Private ReadOnly _connectionString As String

        Public Sub New(connectionString As String)
            _connectionString = connectionString
        End Sub


        Public Function ExisteCnpj(cnpj As String) As Boolean Implements IEmpresaRepository.ExisteCnpj
            Dim exists As Boolean = False

            Using conn As New SqlConnection(_connectionString)
                Dim query As String = "SELECT COUNT(1) FROM Empresa WHERE Cnpj = @Cnpj"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Cnpj", cnpj)
                    conn.Open()
                    exists = Convert.ToBoolean(cmd.ExecuteScalar())
                End Using
            End Using

            Return exists
        End Function

        Public Function GetByIdIncludeAssociados(id As Integer) As Empresa Implements IEmpresaRepository.GetByIdIncludeAssociados
            Dim empresa As New Empresa()
            empresa.Associados = New List(Of Associado)

            Using conn As New SqlConnection(_connectionString)
                Dim query As String = "SELECT e.EmpresaId, e.Nome, e.Cnpj, a.AssociadoId, a.Nome AS AssociadoNome, a.Cpf " &
                                      "FROM Empresa e " &
                                      "LEFT JOIN AssociadoEmpresa ae ON e.EmpresaId = ae.EmpresaId " &
                                      "LEFT JOIN Associado a ON ae.AssociadoId = a.AssociadoId " &
                                      "WHERE e.EmpresaId = @Id"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Id", id)
                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If empresa.EmpresaId = 0 Then
                                empresa.EmpresaId = reader.GetInt32(0)
                                empresa.Nome = reader.GetString(1)
                                empresa.Cnpj = reader.GetString(2)
                            End If

                            If Not reader.IsDBNull(3) Then
                                Dim associado As New Associado With {
                                    .AssociadoId = reader.GetInt32(3),
                                    .Nome = reader.GetString(4),
                                    .Cpf = reader.GetString(5)
                                }
                                empresa.Associados.Add(associado)
                            End If
                        End While
                    End Using
                End Using
            End Using

            Return empresa
        End Function

        Public Function GetIdByCnpj(cnpj As String) As Integer Implements IEmpresaRepository.GetIdByCnpj
            Dim id As Integer = 0

            Using conn As New SqlConnection(_connectionString)
                Dim query As String = "SELECT EmpresaId FROM Empresa WHERE Cnpj = @Cnpj"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Cnpj", cnpj)
                    conn.Open()

                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        id = Convert.ToInt32(result)
                    End If
                End Using
            End Using

            Return id
        End Function

    End Class
End Namespace
