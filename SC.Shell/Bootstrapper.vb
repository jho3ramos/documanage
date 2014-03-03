Imports Microsoft.Practices.Prism.UnityExtensions
Imports SC.Shell.Views
Imports Microsoft.Practices.ServiceLocation
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Prism.Modularity
Imports SC.BusinessLogic.Services
Imports SC.BusinessLogic.Services.Dialog

Public Class Bootstrapper
    Inherits UnityBootstrapper

    Protected Overrides Function CreateModuleCatalog() As IModuleCatalog
        Dim moduleCatalog As New DirectoryModuleCatalog

        moduleCatalog.ModulePath = ".\Modules"

        Return moduleCatalog
    End Function

    Protected Overrides Function CreateShell() As DependencyObject
        Dim shell = Me.Container.Resolve(Of Shell)()

        shell.Show()
        Return shell

    End Function

    Protected Overrides Sub ConfigureContainer()

        MyBase.ConfigureContainer()

        ' register the Services
        Me.Container.RegisterInstance(Of IUserDataService)(New UserDataService, New ContainerControlledLifetimeManager)
        Me.Container.RegisterInstance(Of IMemberDataService)(New MemberDataService, New ContainerControlledLifetimeManager)
        Me.Container.RegisterInstance(Of IDialogService)(New ModalDialogService, New ContainerControlledLifetimeManager)

        ' register the extension Views from the SC.Shell
        Me.Container.RegisterType(Of Object, AdminView)("AdminView")

    End Sub

    Protected Overrides Sub InitializeShell()

        MyBase.InitializeShell()
        Application.Current.MainWindow = Me.Shell
        Application.Current.MainWindow.Show()

        'Me.Container.RegisterType(Of Object, AdminView)("AdminView")

    End Sub
End Class
