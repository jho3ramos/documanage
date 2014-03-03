Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.Administration.ViewModels

Namespace Modules.Administration.Views
    <ViewSortHint("90")>
    Public Class AdministrationTaskButtonView
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            InitializeComponent()
            Me.DataContext = New AdministrationTaskButtonViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As AdministrationTaskButtonViewModel
            Get
                Return DirectCast(Me.DataContext, AdministrationTaskButtonViewModel)
            End Get
        End Property

    End Class

End Namespace