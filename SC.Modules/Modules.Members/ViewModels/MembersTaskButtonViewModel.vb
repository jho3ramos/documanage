Imports System.Windows.Input
Imports Microsoft.Practices.Prism.Events
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.ServiceLocation
Imports Microsoft.Practices.Unity
Imports Modules.Members.Commands
Imports SC.Infrastructure.Events
Imports SC.Infrastructure.Helpers

Namespace Modules.Members.ViewModels

    Public Class MembersTaskButtonViewModel
        Inherits ViewModelBase
        Implements INavigationAware

#Region "  Declarations"

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

#End Region

#Region "  Properties"

        Public Property ShowMembersView As ICommand

        Public Property taskContent As String = "Member View"

        Private _IsCheck As Boolean
        Public Property IsCheck As Boolean
            Get
                Return _IsCheck
            End Get
            Set(ByVal value As Boolean)
                _IsCheck = value
                OnPropertyChanged("IsCheck")
            End Set
        End Property

#End Region

#Region "  Constructors"
        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _container = container
            _regionManager = regionManager

            Initialize()

        End Sub

        Private Sub Initialize()

            ShowMembersView = New ShowMembersViewCommand()

            IsCheck = False

            ' subscribe to Composite Presentation Events
            Dim eventAggregator = ServiceLocator.Current.GetInstance(Of IEventAggregator)()
            Dim navigationCompletedEvent = eventAggregator.GetEvent(Of NavigationCompletedEvent)()
            navigationCompletedEvent.Subscribe(AddressOf OnNavigationCompleted, ThreadOption.UIThread)

        End Sub

#End Region

#Region "  Command Methods"

        Private Sub OnNavigationCompleted(publisher As String)
            ' exit if this module published the event
            If publisher = "MembersModule" Then
                Return
            End If

            ' Otherwise, uncheck this button
            IsCheck = False

        End Sub

#End Region

#Region "INavigationAware Members"

        Public Function IsNavigationTarget(navigationContext As NavigationContext) As Boolean Implements INavigationAware.IsNavigationTarget
            Return True
        End Function

        Public Sub OnNavigatedFrom(navigationContext As NavigationContext) Implements INavigationAware.OnNavigatedFrom

        End Sub

        Public Sub OnNavigatedTo(navigationContext As NavigationContext) Implements INavigationAware.OnNavigatedTo

        End Sub

#End Region

    End Class

End Namespace