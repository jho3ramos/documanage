Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.Administration.ViewModels

Namespace Modules.Administration.Views
    Partial Public Class AdministrationView
        Implements IRegionMemberLifetime

        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            InitializeComponent()
            Me.DataContext = New AdministrationViewModel(regionManager, container)

        End Sub

        Public ReadOnly Property ViewModel As AdministrationViewModel
            Get
                Return DirectCast(Me.DataContext, AdministrationViewModel)
            End Get
        End Property

        Public ReadOnly Property KeepAlive As Boolean Implements IRegionMemberLifetime.KeepAlive
            Get
                Return False
            End Get
        End Property

    End Class
End Namespace
