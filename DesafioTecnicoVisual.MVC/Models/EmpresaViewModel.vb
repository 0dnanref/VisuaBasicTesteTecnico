Imports System.ComponentModel.DataAnnotations

Namespace DesafioTecnicoVisualBasic.MVC.Models
    Public Class EmpresaViewModel
        <Key>
        Public Property EmpresaId As Integer

        <Required(ErrorMessage:="Campo Nome obrigatório")>
        <MaxLength(200, ErrorMessage:="Máximo {0} caracteres")>
        Public Property Nome As String = String.Empty

        <Required(ErrorMessage:="Campo CNPJ obrigatório")>
        <MaxLength(14, ErrorMessage:="Máximo {0} caracteres")>
        Public Property Cnpj As String = String.Empty

        <Required(ErrorMessage:="Selecione ao menos um associado!")>
        Public Property AssociadosSelecionadas As List(Of Integer) = New List(Of Integer)()

        <Required(ErrorMessage:="Selecione ao menos um associado!")>
        Public Property Associados As List(Of AssociadoViewModel) = New List(Of AssociadoViewModel)()
    End Class
End Namespace
