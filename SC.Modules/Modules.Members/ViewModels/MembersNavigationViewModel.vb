Imports SC.Infrastructure.Helpers
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports System.Windows.Input
Imports Modules.Members.Commands

Namespace Modules.Members.ViewModels

    Public Class MembersNavigationViewModel
        Inherits ViewModelBase

#Region "  Declarations"

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

#End Region

#Region "  Properties"

        Public Property ShowMembersView1 As ICommand
        Public Property ShowMembersView2 As ICommand
        Public Property ShowMembersView3 As ICommand
        Public Property ShowMembersView4 As ICommand

        Public Property taskContent1 As String = "View Members"
        Public Property taskContent2 As String = "Add Member"
        Public Property taskContent3 As String = "View Family Member"
        Public Property taskContent4 As String = "Add Family Member"

        Private _IsChecked1 As Boolean
        Public Property IsChecked1 As Boolean
            Get
                Return _IsChecked1
            End Get
            Set(ByVal value As Boolean)
                _IsChecked1 = value
                OnPropertyChanged("IsChecked1")
            End Set
        End Property

        Private _IsChecked2 As Boolean
        Public Property IsChecked2 As Boolean
            Get
                Return _IsChecked2
            End Get
            Set(ByVal value As Boolean)
                _IsChecked2 = value
                OnPropertyChanged("IsChecked2")
            End Set
        End Property

        Private _IsChecked3 As Boolean
        Public Property IsChecked3 As Boolean
            Get
                Return _IsChecked3
            End Get
            Set(ByVal value As Boolean)
                _IsChecked3 = value
                OnPropertyChanged("IsChecked3")
            End Set
        End Property

        Private _IsChecked4 As Boolean
        Public Property IsChecked4 As Boolean
            Get
                Return _IsChecked4
            End Get
            Set(ByVal value As Boolean)
                _IsChecked4 = value
                OnPropertyChanged("IsChecked4")
            End Set
        End Property

#End Region

#Region "  Constructors"

        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _regionManager = regionManager
            _container = container

            Initialize()

        End Sub

        Private Sub Initialize()

            ShowMembersView1 = New ShowMembersViewCommand() 'Me)
            ShowMembersView2 = New ShowMemberAddViewCommand()
            ShowMembersView3 = New ShowMemberFamilyViewCommand()
            ShowMembersView4 = New ShowMemberFamilyAddViewCommand()

        End Sub

#End Region

#Region "  Command Methods"


#End Region

#Region "INavigationAware Members"


#End Region

    End Class

End Namespace