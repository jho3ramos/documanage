Imports SC.BusinessLogic.Service.ViewModels

Namespace SC.BusinessLogic.Service.Views

    Partial Public Class BusyView

        Sub New(messageTitle As String, messageContent As String)
            InitializeComponent()
            Me.DataContext = New BusyViewModel(messageTitle, messageContent)
        End Sub

        Public ReadOnly Property ViewModel As BusyViewModel
            Get
                Return DirectCast(Me.DataContext, BusyViewModel)
            End Get
        End Property

#Region "Methods"
        Private Sub closeMe()
            Me.Close()
        End Sub
#End Region

    End Class

End Namespace