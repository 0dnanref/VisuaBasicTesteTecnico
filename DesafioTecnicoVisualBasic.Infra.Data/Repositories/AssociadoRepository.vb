Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories
Imports System.Data.SqlClient

Namespace DesafioTecnicoVisualBasic.Infra.Data.Repositorios
    Public Class AssociadoRepository
        Inherits RepositoryBase(Of Associado)
        Implements IAssociadoRepository

        Private ReadOnly _connectionString As String

        ' Construtor padrão
        Public Sub New()
        End Sub

        Public Sub New(connectionString As String)
            _connectionString = connectionString
        End Sub

        Public Function ExisteCpf(cpf As String) As Boolean Implements IAssociadoRepository.ExisteCpf
            Dim exists As Boolean = False

            Using conn As New SqlConnection(_connectionString)
                Dim query As String = "SELECT COUNT(1) FROM Associado WHERE Cpf = @Cpf"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Cpf", cpf)
                    conn.Open()
                    exists = Convert.ToBoolean(cmd.ExecuteScalar())
                End Using
            End Using

            Return exists
        End Function

        Public Function GetByIdIncludeEmpresas(id As Integer) As Associado Implements IAssociadoRepository.GetByIdIncludeEmpresas
            Dim associado As New Associado()
            associado.Empresas = New List(Of Empresa)

            Using conn As New SqlConnection(_connectionString)
                Dim query As String = "SELECT a.AssociadoId, a.Nome, a.Cpf, a.DataNascimento, e.EmpresaId, e.Nome AS EmpresaNome, e.Cnpj " &
                                      "FROM Associado a " &
                                      "LEFT JOIN AssociadoEmpresa ae ON a.AssociadoId = ae.AssociadoId " &
                                      "LEFT JOIN Empresa e ON ae.EmpresaId = e.EmpresaId " &
                                      "WHERE a.AssociadoId = @Id"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Id", id)
                    conn.Open()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If associado.AssociadoId = 0 Then
                                associado.AssociadoId = reader.GetInt32(0)
                                associado.Nome = reader.GetString(1)
                                associado.Cpf = reader.GetString(2)
                                associado.DataNascimento = reader.GetDateTime(3)
                            End If

                            If Not reader.IsDBNull(4) Then
                                Dim empresa As New Empresa With {
                                    .EmpresaId = reader.GetInt32(4),
                                    .Nome = reader.GetString(5),
                                    .Cnpj = reader.GetString(6)
                                }
                                associado.Empresas.Add(empresa)
                            End If
                        End While
                    End Using
                End Using
            End Using

            Return associado
        End Function

        Public Function GetIdByCpf(cpf As String) As Integer Implements IAssociadoRepository.GetIdByCpf
            Dim id As Integer = 0

            Using conn As New SqlConnection(_connectionString)
                Dim query As String = "SELECT AssociadoId FROM Associado WHERE Cpf = @Cpf"
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@Cpf", cpf)
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
