Imports SC.BusinessLogic.Service.ViewModels

Namespace SC.BusinessLogic.Service.Views

    Partial Public Class MessageView

        Sub New(messageTitle As String, messageContent As String)
            InitializeComponent()
            Me.DataContext = New MessageViewModel(messageTitle, messageContent)
        End Sub

        Public ReadOnly Property ViewModel As MessageViewModel
            Get
                Return DirectCast(Me.DataContext, MessageViewModel)
            End Get
        End Property

#Region "Methods"
        Private Sub closeMe()
            Me.Close()
        End Sub
#End Region

    End Class

End Namespace