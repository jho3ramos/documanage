Imports Modules.UserLogin.ViewModels
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Prism.Regions

Namespace Modules.UserLogin.Views

    Public Class UserRolesView
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)
            InitializeComponent()
            Me.DataContext = New UserRolesViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As UserRolesViewModel
            Get
                Return DirectCast(Me.DataContext, UserRolesViewModel)
            End Get
        End Property
    End Class

End Namespace