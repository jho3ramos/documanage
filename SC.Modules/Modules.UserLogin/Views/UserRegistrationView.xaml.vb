Imports Modules.UserLogin.ViewModels
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Prism.Regions

Namespace Modules.UserLogin.Views

    Public Class UserRegistrationView
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)
            InitializeComponent()
            Me.DataContext = New UserRegistrationViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As UserRegistrationViewModel
            Get
                Return DirectCast(Me.DataContext, UserRegistrationViewModel)
            End Get
        End Property
    End Class

End Namespace