Imports Modules.UserLogin.ViewModels
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Prism.Regions

Namespace Modules.UserLogin.Views

    Public Class UserActivityView
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)
            InitializeComponent()
            Me.DataContext = New UserLoginViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As UserLoginViewModel
            Get
                Return DirectCast(Me.DataContext, UserLoginViewModel)
            End Get
        End Property
    End Class

End Namespace