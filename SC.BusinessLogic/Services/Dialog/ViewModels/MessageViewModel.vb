Namespace SC.BusinessLogic.Service.ViewModels

    Public Class MessageViewModel

        Private _messageContent As String
        Public Property messageContent() As String
            Get
                Return _messageContent
            End Get
            Set(ByVal value As String)
                If (_messageContent <> value) Then
                    _messageContent = value
                End If
            End Set
        End Property

        Private _messageTitle As String
        Public Property messageTitle() As String
            Get
                Return _messageTitle
            End Get
            Set(ByVal value As String)
                If (_messageTitle <> value) Then
                    _messageTitle = value
                End If
            End Set
        End Property


        Public Sub New(ByVal messageTitle As String, ByVal messageContent As String)
            _messageTitle = messageTitle
            _messageContent = messageContent
        End Sub

    End Class

End Namespace