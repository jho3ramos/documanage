Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.UserLogin.ViewModels

Namespace Modules.UserLogin.Views
    <ViewSortHint("31")>
    Public Class UserNavigationButton
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DataContext = New UserNavigationButtonViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As UserNavigationButtonViewModel
            Get
                Return DirectCast(Me.DataContext, UserNavigationButtonViewModel)
            End Get
        End Property

    End Class

End Namespace