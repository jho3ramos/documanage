Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports SC.Infrastructure
Imports Modules.UserLogin.Views
Imports Microsoft.Practices.ServiceLocation

Namespace Modules.UserLogin

    Public Class UserLoginModule
        Implements IModule

        Public Sub Initialize() Implements IModule.Initialize

            RegisterViewsWithRegions()

            Dim iRegionManager = ServiceLocator.Current.GetInstance(Of IRegionManager)()

            ' show Workspace
            'Dim userLoginWorkspace = New Uri("UserLoginView", UriKind.RelativeOrAbsolute)
            Dim userLoginWorkspace = New Uri("LoginView", UriKind.RelativeOrAbsolute)
            iRegionManager.RequestNavigate(RegionNames.MainWorkspace, userLoginWorkspace)

        End Sub

        Protected Overridable Sub RegisterViewsWithRegions()

            ' Register task button with Prism Region
            Dim iRegionManager = ServiceLocator.Current.GetInstance(Of IRegionManager)()
            iRegionManager.RegisterViewWithRegion(RegionNames.TaskButtonRegion, GetType(UserTaskButtonView))

            ' Register navigation button with the Prism Region
            iRegionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, GetType(UserNavigationButton))

            ' Register other view objects with DI Container (Unity)
            Dim container = ServiceLocator.Current.GetInstance(Of IUnityContainer)()
            'container.RegisterType(Of Object, UserLoginView)("UserLoginView")
            container.RegisterType(Of Object, LoginView)("LoginView")
            container.RegisterType(Of Object, UserRegistrationView)("UserRegistrationView")
            container.RegisterType(Of Object, UserRolesView)("UserRolesView")
            container.RegisterType(Of Object, UserActivityView)("UserActivityView")

        End Sub
    End Class

End Namespace