Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports SC.Shell.ViewModels

Namespace SC.Shell.Views

    Class Shell
        Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)
            InitializeComponent()
            Me.DataContext = New ShellViewModel(regionManager, container)
        End Sub

        Public ReadOnly Property ViewModel As ShellViewModel
            Get
                Return DirectCast(Me.DataContext, ShellViewModel)
            End Get
        End Property

        Private Sub minExecute() Handles btnmin.Click
            Application.Current.MainWindow.WindowState = WindowState.Minimized
        End Sub

        Private Sub exitExecute() Handles btnexit.Click
            Application.Current.Shutdown()
        End Sub
    End Class

End Namespace