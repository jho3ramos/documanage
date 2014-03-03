Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.Administration.Views
Imports SC.Infrastructure
Imports Microsoft.Practices.ServiceLocation

Namespace Modules.Administration

    Public Class AdministrationModule
        Implements IModule

        Public Sub Initialize() Implements IModule.Initialize
            RegisterViewsWithRegions()
        End Sub

        Protected Overridable Sub RegisterViewsWithRegions()

            Dim iRegionManager = ServiceLocator.Current.GetInstance(Of IRegionManager)()
            ' Register task button with Prism Region
            iRegionManager.RegisterViewWithRegion(RegionNames.TaskButtonRegion, GetType(AdministrationTaskButtonView))

            ' Register navigation button with the Prism Region
            iRegionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, GetType(AdministrationNavigationButton))

            ' Register other view objects with DI Container (Unity)
            Dim container = ServiceLocator.Current.GetInstance(Of IUnityContainer)()
            container.RegisterType(Of Object, AdministrationView)("AdministrationView")

        End Sub

    End Class

End Namespace