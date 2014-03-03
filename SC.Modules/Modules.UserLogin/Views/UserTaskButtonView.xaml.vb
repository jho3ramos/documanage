Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.UserLogin.ViewModels

Namespace Modules.UserLogin.Views
    <ViewSortHint("90")>
    Public Class UserTaskButtonView
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            InitializeComponent()
            Me.DataContext = New UserTaskButtonViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As UserTaskButtonViewModel
            Get
                Return DirectCast(Me.DataContext, UserTaskButtonViewModel)
            End Get
        End Property

    End Class

End Namespace