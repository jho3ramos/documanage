Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.Members.ViewModels

Namespace Modules.Members.Views

    Public Class MembersFamilyView
        Implements IRegionMemberLifetime

        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            InitializeComponent()
            Me.DataContext = New MembersViewModel(regionManager, container)

        End Sub

        Public ReadOnly Property ViewModel As MembersViewModel
            Get
                Return DirectCast(Me.DataContext, MembersViewModel)
            End Get
        End Property

        Public ReadOnly Property KeepAlive As Boolean Implements IRegionMemberLifetime.KeepAlive
            Get
                Return False
            End Get
        End Property
    End Class

End Namespace