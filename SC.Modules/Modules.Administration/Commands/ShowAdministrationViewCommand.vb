﻿Imports System
Imports System.Windows.Input
Imports Microsoft.Practices.Prism.Events
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.ServiceLocation
Imports SC.Infrastructure
Imports SC.Infrastructure.Events
Imports Modules.Administration.ViewModels
Imports SC.Infrastructure.Helpers

Namespace Modules.Administration.Commands

    Public Class ShowAdministrationViewCommand
        Inherits ViewModelBase
        Implements ICommand

        Private _viewModel As AdministrationTaskButtonViewModel

#Region "Constructor"
        Public Sub New() 'viewModel As AdministrationTaskButtonViewModel)
            '_viewModel = viewModel
        End Sub
#End Region

#Region "ICommand Members"

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function

        Public Event CanExecuteChanged(sender As Object, e As EventArgs) Implements ICommand.CanExecuteChanged

        Public Sub Execute(parameter As Object) Implements ICommand.Execute

            ' initialize
            Dim iRegionManager = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance(Of IRegionManager)()

            ' show Navigator
            Dim AdministrationNavigator = New Uri("AdministrationNavigationButton", UriKind.Relative)
            iRegionManager.RequestNavigate(RegionNames.NavigationRegion, AdministrationNavigator)

            ' We invoke the NavigationCompleted() callback 
            ' method in our final  navigation request. 

            ' show Workspace
            Dim administrationWorkspace = New Uri("AdministrationView", UriKind.RelativeOrAbsolute)
            iRegionManager.RequestNavigate(RegionNames.MainRegion, administrationWorkspace, AddressOf NavigationCompleted)

        End Sub

#End Region

#Region "Methods"

        Private Sub NavigationCompleted(iReturn As NavigationResult)
            If iReturn.Result <> True Then
                Return
            End If

            ' publish ViewRequestedEvent
            publishEvent("AdministrationModule")

            publishStatusEvent("Ready")

        End Sub

        Private Sub publishEvent(params As String)
            Dim eventAggregator = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance(Of IEventAggregator)()
            Dim navigationCompletedEvent = eventAggregator.GetEvent(Of NavigationCompletedEvent)()
            navigationCompletedEvent.Publish(params)
        End Sub

#End Region

    End Class

End Namespace