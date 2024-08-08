Imports System.ComponentModel.DataAnnotations

Namespace DesafioTecnicoVisualBasic.MVC.Models
    Public Class AssociadoViewModel
        <Key>
        Public Property AssociadoId As Integer

        <Required(ErrorMessage:="Campo Nome obrigatório!")>
        <MaxLength(200, ErrorMessage:="Máximo {0} caracteres!")>
        Public Property Nome As String = String.Empty

        <Required(ErrorMessage:="Campo CPF obrigatório!")>
        <MaxLength(11, ErrorMessage:="Máximo {0} caracteres!")>
        Public Property Cpf As String = String.Empty

        <Required(ErrorMessage:="Campo Data de Nascimento obrigatório!")>
        Public Property DataNascimento As DateTime

        <Required(ErrorMessage:="Selecione ao menos uma empresa!")>
        Public Property EmpresasSelecionadas As List(Of Integer) = New List(Of Integer)()

        Public Property Empresas As List(Of EmpresaViewModel) = New List(Of EmpresaViewModel)()
    End Class
End Namespace

