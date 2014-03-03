Imports System.Windows.Input
Imports Microsoft.Practices.Prism.Events
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.ServiceLocation
Imports SC.Infrastructure
Imports SC.Infrastructure.Events

Namespace Modules.Members.Commands

    Public Class ShowMemberFamilyViewCommand
        Implements ICommand

        'Private _viewmodel As ProductsTaskButtonViewModel

#Region "Constructor"
        Public Sub New() 'viewmodel As ProductsTaskButtonViewModel)
            '_viewmodel = viewmodel
        End Sub
#End Region

#Region "ICommand Members"

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function

        Public Event CanExecuteChanged(sender As Object, e As EventArgs) Implements ICommand.CanExecuteChanged

        Public Sub Execute(parameter As Object) Implements ICommand.Execute

            Dim iRegionManager = ServiceLocator.Current.GetInstance(Of IRegionManager)()

            ' show Navigator
            'Dim membersNavigator = New Uri("MembersNavigationView", UriKind.Relative)
            'iRegionManager.RequestNavigate(RegionNames.NavigationRegion, membersNavigator)

            ' We invoke the NavigationCompleted() callback 
            ' method in our final  navigation request. 

            ' show Workspace
            Dim membersAddWorkspace = New Uri("MembersFamilyView", UriKind.RelativeOrAbsolute)
            iRegionManager.RequestNavigate(RegionNames.MainRegion, membersAddWorkspace, AddressOf NavigationCompleted)

        End Sub

#End Region

#Region "Methods"

        Private Sub NavigationCompleted(iReturn As NavigationResult)
            If iReturn.Result <> True Then
                Return
            End If

            ' publish ViewRequestedEvent
            Dim eventAggregator = ServiceLocator.Current.GetInstance(Of IEventAggregator)()
            Dim navigationCompletedEvent = eventAggregator.GetEvent(Of NavigationCompletedEvent)()
            navigationCompletedEvent.Publish("MembersModule")

        End Sub

#End Region
    End Class

End Namespace