Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports SC.Infrastructure.Helpers

Namespace SC.Shell.ViewModels

    Public Class ShellViewModel

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

        'Public Property exitCommand As ICommand
        'Public Property minCommand As ICommand

#Region "Constructor"

        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _regionManager = regionManager
            _container = container

            'Dim exitAction As Action = New Action(AddressOf exitExecute)
            'exitCommand = New AsyncDelegateCommand(exitAction, Nothing, Nothing)

            'Dim minAction As Action = New Action(AddressOf minExecute)
            'minCommand = New AsyncDelegateCommand(minAction, Nothing, Nothing)

        End Sub

#End Region

#Region "Methods"
        'Private Sub exitExecute()
        '    Application.Current.Shutdown()
        'End Sub

        'Private Sub minExecute()
        '    Application.Current.MainWindow.WindowState = WindowState.Minimized
        'End Sub
#End Region


    End Class

End Namespace