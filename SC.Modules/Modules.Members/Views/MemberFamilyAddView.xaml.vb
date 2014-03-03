Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.Members.ViewModels

Namespace Modules.Members.Views

    Public Class MemberFamilyAddView
        Implements IRegionMemberLifetime

        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            InitializeComponent()
            Me.DataContext = New MemberAddViewModel(regionManager, container)

        End Sub

        Public ReadOnly Property ViewModel As MemberAddViewModel
            Get
                Return DirectCast(Me.DataContext, MemberAddViewModel)
            End Get
        End Property

        Public ReadOnly Property KeepAlive As Boolean Implements IRegionMemberLifetime.KeepAlive
            Get
                Return False
            End Get
        End Property

    End Class
End Namespace

