Imports System.Windows.Input
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports Modules.Administration.Commands
Imports SC.Infrastructure.Helpers

Namespace Modules.Administration.ViewModels

    Public Class AdministrationNavigationButtonViewModel
        Inherits ViewModelBase

#Region "  Declarations"

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

#End Region

#Region "  Properties"

        Public Property ShowAdministrationView1 As ICommand

        Public Property taskContent1 As String = "MasterFiles"
        Public Property taskContent2 As String = "Reprint Receipt/Invoice"
        Public Property taskContent3 As String = "Transactions..."

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


#End Region

#Region "  Constructors"

        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _regionManager = regionManager
            _container = container

            Initialize()

        End Sub

        Private Sub Initialize()

            ShowAdministrationView1 = New ShowAdministrationViewCommand() 'Me)

        End Sub

#End Region

#Region "  Command Methods"


#End Region

#Region "INavigationAware Members"


#End Region

    End Class

End Namespace