Imports Unity
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Entidades
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Repositories
Imports Unity.Injection
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Interfaces.Servicos
Imports DesafioTecnicoVisualBasic.Domain.DesafioTecnicoVisualBasic.Domain.Servicos
Imports Unity.AspNet.Mvc
Imports DesafioTecnicoVisualBasic.Infra.Data.DesafioTecnicoVisualBasic.Infra.Data.Repositorios

Public Class Global_asax
    Inherits HttpApplication

    Private Shared container As IUnityContainer

    Sub Application_Start(sender As Object, e As EventArgs)

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString

        ' Configurar serviços e repositórios
        ' Inicializar o Unity Container
        container = New UnityContainer()

        ' Registro dos tipos no Unity Container
        container.RegisterType(Of IRepositoryBase(Of Associado), RepositoryBase(Of Associado))(
            New InjectionConstructor(New InjectionParameter(Of String)(connectionString)))

        container.RegisterType(Of IRepositoryBase(Of Empresa), RepositoryBase(Of Empresa))(
            New InjectionConstructor(New InjectionParameter(Of String)(connectionString)))

        container.RegisterType(Of IAssociadoRepository, AssociadoRepository)(New InjectionConstructor(connectionString))
        container.RegisterType(Of IEmpresaRepository, EmpresaRepository)(New InjectionConstructor(connectionString))

        ' Registrar serviços
        container.RegisterType(Of IServiceBase(Of Empresa), ServiceBase(Of Empresa))()
        container.RegisterType(Of IServiceBase(Of Associado), ServiceBase(Of Associado))()
        container.RegisterType(Of IAssociadoService, AssociadoService)()
        container.RegisterType(Of IEmpresaService, EmpresaService)()


        ' Configurar o resolver
        Dim resolver As New UnityDependencyResolver(container)
        DependencyResolver.SetResolver(resolver)
        AreaRegistration.RegisterAllAreas()
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
    End Sub
End Class