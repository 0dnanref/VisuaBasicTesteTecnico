﻿Namespace DesafioTecnicoVisualBasic.Domain.Entidades
    Public Class Associado
        Public Property AssociadoId As Integer
        Public Property Nome As String
        Public Property Cpf As String
        Public Property DataNascimento As DateTime
        Public Property Empresas As List(Of Empresa)
    End Class
End Namespace
