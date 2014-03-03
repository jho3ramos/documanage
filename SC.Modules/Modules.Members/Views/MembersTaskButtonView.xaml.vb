Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.Members.ViewModels

Namespace Modules.Members.Views

    Public Class MembersTaskButtonView
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.DataContext = New MembersTaskButtonViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As MembersTaskButtonViewModel
            Get
                Return DirectCast(Me.DataContext, MembersTaskButtonViewModel)
            End Get
        End Property

    End Class

End Namespace