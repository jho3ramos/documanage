Imports System.Windows.Input
Imports System.ComponentModel

Namespace SC.Infrastructure.Helpers

    Public Class DelegateWorker

        Private _worker As New BackgroundWorker()
        Private _canExecute As Func(Of Boolean)
        Private _action As Action
        Private _completed As Action(Of Object)
        Private _exception As Action(Of Exception)

        Public Sub New(ByVal action As Action, _
                       Optional ByVal canExecute As Func(Of Boolean) = Nothing, _
                       Optional ByVal completed As Action(Of Object) = Nothing, _
                       Optional ByVal exception As Action(Of Exception) = Nothing)

            _action = action
            _completed = completed
            _exception = exception

            AddHandler _worker.DoWork, AddressOf worker_DoWork
            AddHandler _worker.RunWorkerCompleted, AddressOf worker_RunWorkerCompleted

            _canExecute = canExecute
        End Sub

        Private Sub worker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
            CommandManager.InvalidateRequerySuggested()
            _action()
        End Sub

        Private Sub worker_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
            If _completed IsNot Nothing AndAlso e.Error Is Nothing Then
                _completed(e.Result)
            End If

            If _exception IsNot Nothing AndAlso e.Error IsNot Nothing Then
                _exception(e.Error)
            End If

            CommandManager.InvalidateRequerySuggested()
        End Sub

        Public Sub Cancel()
            If _worker.IsBusy Then
                _worker.CancelAsync()
            End If
        End Sub

        Public Function CanExecute(ByVal parameter As Object) As Boolean
            Return If((_canExecute Is Nothing), Not (_worker.IsBusy), Not (_worker.IsBusy) AndAlso _canExecute())
        End Function

        Public Sub Execute(ByVal parameter As Object)
            _worker.RunWorkerAsync()
        End Sub

        Public Event CanExecuteChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Class

End Namespace