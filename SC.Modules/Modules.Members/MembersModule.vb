Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.ServiceLocation
Imports Microsoft.Practices.Unity
Imports Modules.Members.Views
Imports SC.Infrastructure

Namespace Modules.Members

    Public Class MembersModule
        Implements IModule

        Public Sub Initialize() Implements IModule.Initialize
            RegisterViewsWithRegions()
        End Sub

        Protected Overridable Sub RegisterViewsWithRegions()

            ' Register task button with Prism Region
            Dim iRegionManager = ServiceLocator.Current.GetInstance(Of IRegionManager)()
            iRegionManager.RegisterViewWithRegion(RegionNames.TaskButtonRegion, GetType(MembersTaskButtonView))

            ' Register navigation button with the Prism Region
            iRegionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, GetType(MembersNavigationView))

            ' Register other view objects with DI Container (Unity)
            Dim container = ServiceLocator.Current.GetInstance(Of IUnityContainer)()
            container.RegisterType(Of Object, MembersView)("MembersView")
            container.RegisterType(Of Object, MemberAddView)("MemberAddView")
            container.RegisterType(Of Object, MemberFamilyAddView)("MemberFamilyAddView")
            container.RegisterType(Of Object, MembersFamilyView)("MembersFamilyView")
            'container.RegisterType(Of Object, CustomersEditView)("CustomersEditView")

        End Sub
    End Class

End Namespace