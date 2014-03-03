Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.Administration.ViewModels

Namespace Modules.Administration.Views
    <ViewSortHint("31")>
    Public Class AdministrationNavigationButton
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DataContext = New AdministrationNavigationButtonViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As AdministrationNavigationButtonViewModel
            Get
                Return DirectCast(Me.DataContext, AdministrationNavigationButtonViewModel)
            End Get
        End Property

    End Class

End Namespace