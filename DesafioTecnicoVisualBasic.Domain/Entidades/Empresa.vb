
Namespace DesafioTecnicoVisualBasic.Domain.Entidades
    Public Class Empresa
        Public Property EmpresaId As Integer
        Public Property Nome As String
        Public Property Cnpj As String
        Public Property Associados As List(Of Associado)
    End Class
End Namespace
