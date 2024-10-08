﻿Imports System.Web.Mvc
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos

Public Class Create
    Inherits ViewPage(Of Associado)

    Private ReadOnly _serviceBaseEmpresa As IServiceBase(Of Empresa)
    Private ReadOnly _serviceBaseAssociado As IServiceBase(Of Associado)
    Private ReadOnly _serviceAssociado As IAssociadoService
    Public Sub New()
        _serviceBaseEmpresa = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Empresa))), IServiceBase(Of Empresa))
        _serviceBaseAssociado = CType(DependencyResolver.Current.GetService(GetType(IServiceBase(Of Associado))), IServiceBase(Of Associado))
        _serviceAssociado = CType(DependencyResolver.Current.GetService(GetType(IAssociadoService)), IAssociadoService)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            Dim empresas As List(Of Empresa) = _serviceBaseEmpresa.GetAll()

            EmpresasListBox.DataSource = empresas
            EmpresasListBox.DataTextField = "Nome"
            EmpresasListBox.DataValueField = "EmpresaId"
            EmpresasListBox.DataBind()
        End If

    End Sub


    Private Function ObterEmpresasSelecionadas() As List(Of Empresa)

        Dim empresasSelecionadas As New List(Of Empresa)
        For Each item As ListItem In EmpresasListBox.Items
            If item.Selected Then
                empresasSelecionadas.Add(New Empresa With {
                    .EmpresaId = Convert.ToInt32(item.Value),
                    .Nome = item.Text
                })
            End If

        Next
        Return empresasSelecionadas
    End Function

    Protected Sub CreateButton_Click1(ByVal sender As Object, ByVal e As EventArgs)
        If Page.IsValid Then


            If _serviceAssociado.ExisteCpf(CpfTextBox.Text) Then

                CpfErrorLabel.Text = "O CPF informado já está cadastrado."
                CpfErrorLabel.Visible = True

            Else
                Dim novoAssociado As New Associado() With {
               .Nome = NomeTextBox.Text,
               .Cpf = CpfTextBox.Text,
               .DataNascimento = DateTime.Parse(DataNascimentoTextBox.Text),
               .Empresas = ObterEmpresasSelecionadas()
                }

                _serviceBaseAssociado.Add(novoAssociado)

                Response.Redirect("~/Views/Associados/Index.aspx")

            End If


        End If
    End Sub
End Class