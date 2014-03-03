Imports Microsoft.Practices.Prism.Events

Namespace SC.Infrastructure.Events
    Public Class StatusUpdatedEvent
        Inherits CompositePresentationEvent(Of String)

        Private _statusMessage As String
        Public Property statusMessage As String
            Get
                Return _statusMessage
            End Get
            Set(ByVal value As String)
                _statusMessage = value
            End Set
        End Property

    End Class
End Namespace