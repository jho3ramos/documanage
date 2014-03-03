Imports System.Windows.Input
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.UserLogin.Commands
Imports SC.Infrastructure.Helpers

Namespace Modules.UserLogin.ViewModels

    Public Class UserNavigationButtonViewModel
        Inherits ViewModelBase

#Region "  Declarations"

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

#End Region

#Region "  Properties"

        Public Property ShowAdministrationView1 As ICommand
        Public Property ShowAdministrationView2 As ICommand
        Public Property ShowAdministrationView3 As ICommand

        Public Property taskContent1 As String = "User Registration"
        Public Property taskContent2 As String = "User Roles and Priviledges"
        Public Property taskContent3 As String = "User Activity"

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

#End Region

#Region "  Constructors"

        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _regionManager = regionManager
            _container = container

            Initialize()

        End Sub

        Private Sub Initialize()

            ShowAdministrationView1 = New ShowUserRegistrationViewCommand() 'Me)
            ShowAdministrationView2 = New ShowUserRolesViewCommand() 'Me)
            ShowAdministrationView3 = New ShowUserActivityViewCommand() 'Me)

        End Sub

#End Region

#Region "  Command Methods"


#End Region

#Region "INavigationAware Members"


#End Region

    End Class

End Namespace