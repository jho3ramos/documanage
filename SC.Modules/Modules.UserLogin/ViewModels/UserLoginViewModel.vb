Imports System.Security.Principal
Imports System.Windows.Input
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports SC.BusinessLogic.Services
Imports SC.BusinessObjects.Models
Imports SC.Infrastructure
Imports SC.Infrastructure.Helpers

Namespace Modules.UserLogin.ViewModels
    Public Class UserLoginViewModel
        Inherits ViewModelBase

#Region "  Declarations"
        
        Public Property appTitle as String="Senior Citizens Dashboard"
        Private _user As user
        Private _loginID As String = "jhoe" 'String.Empty
        Private _password As String = "test" 'String.Empty
        Private _loginMessage As String = String.Empty
        Private _loginSuccess As Boolean = False
        Private _isBusy As Boolean = False
        Private _isEnabled As Boolean = True

        Private _userAccess As IUserDataService

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

#End Region

#Region "  Properties"

        Public Property User As user
            Get
                Return _user
            End Get
            Set(ByVal value As user)
                _user = value
                OnPropertyChanged("User")
            End Set
        End Property

        Public Property LoginID As String
            Get
                Return _loginID
            End Get
            Set(ByVal value As String)
                _loginID = value
                OnPropertyChanged("LoginID")
            End Set
        End Property

        Public Property Password As String
            Get
                Return _password
            End Get
            Set(ByVal value As String)
                _password = value
                OnPropertyChanged("Password")
            End Set
        End Property

        Public Property LoginMessage As String
            Get
                Return _loginMessage
            End Get
            Set(ByVal value As String)
                _loginMessage = value
                OnPropertyChanged("LoginMessage")
                publishStatusEvent(_loginMessage)
            End Set
        End Property

        Public Property IsBusy As Boolean
            Get
                Return _isBusy
            End Get
            Set(ByVal value As Boolean)
                _isBusy = value
                isEnabled = Not value
                OnPropertyChanged("IsBusy")
            End Set
        End Property

        Public Property isEnabled() As Boolean
            Get
                Return _isEnabled
            End Get
            Set(ByVal value As Boolean)
                _isEnabled = value
                OnPropertyChanged("isEnabled")
            End Set
        End Property

        Private _btnEnabled As Boolean = False
        Public Property btnEnabled() As Boolean
            Get
                Return _btnEnabled
            End Get
            Set(ByVal value As Boolean)
                _btnEnabled = value
                OnPropertyChanged("btnEnabled")
            End Set
        End Property

        Public Property LoginSuccess As Boolean
            Get
                Return _loginSuccess
            End Get
            Set(ByVal value As Boolean)
                _loginSuccess = value
            End Set
        End Property

        Public Property LoginCommand As ICommand

#End Region

#Region "  Constructors"

        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _regionManager = regionManager
            _container = container

            '_container.RegisterInstance(Of IUserDataService)(New UserDataService)  >> registered in bootstrap
            _userAccess = _container.Resolve(Of IUserDataService)()

            Dim loginAction As Action = New Action(AddressOf LoginExecute)
            LoginCommand = New AsyncDelegateCommand(loginAction, Nothing, Sub() LoadView())



            IsBusy = False

        End Sub

#End Region

#Region "  Command Methods"

        Private Sub LoginExecute()

            LoginMessage = "Trying to login your account..."

            _loginSuccess = False
            IsBusy = True
            Threading.Thread.Sleep(1000)

            Dim paramLoginID = LoginID
            Dim paramPassword = Password

            Try
                UserPrinciple = _userAccess.Login(paramLoginID, paramPassword)

                Dim myIdentity As IIdentity = New IdentityBusinessObject(Nothing, Nothing, Nothing)
                Dim myRoles As New List(Of String)

                If UserPrinciple.Identity.IsAuthenticated Then
                    _container.RegisterInstance(Of IPrincipal)("UserPrinciple", UserPrinciple, New ContainerControlledLifetimeManager())
                    _loginSuccess = True
                End If
                IsBusy = False
                'LoadView()
            Catch ex As Exception
                IsBusy = False
                LoginMessage = ex.Message
            End Try

        End Sub

        Private Function CanLoginExecute(ByVal param As Object) As Boolean

            Return (Not String.IsNullOrEmpty(LoginID)) AndAlso (Not String.IsNullOrEmpty(Password))

        End Function

#End Region

#Region "Load View Command"
        ''' <summary>
        ''' loads the user workspace
        ''' </summary>
        ''' <remarks>load the workspace based on the user role</remarks>
        Public Sub LoadView()
            Try

                If _loginSuccess Then

                    LoginMessage = ""

                    Dim mainWorkspace As IRegion = _regionManager.Regions(RegionNames.MainWorkspace)

                    If UserPrinciple.IsInRole("administrator") Then
                        'load the admin view
                        Try
                            ' get and show the main workspace for administrator
                            Dim adminWorkspace = New Uri("AdminView", UriKind.RelativeOrAbsolute)
                            _regionManager.RequestNavigate(RegionNames.MainWorkspace, adminWorkspace)
                            ' load the menu region
                            '_regionManager.RegisterViewWithRegion(RegionNames.MenuRegion, GetType(UserLoginMenuView))


                        Catch ex As Exception


                        End Try

                    ElseIf UserPrinciple.IsInRole("encoder") Then
                        'load the cashier view

                    Else
                        ' load the default view

                    End If

                    ' update the user
                    publishStatusEvent("Ready...")
                End If
            Catch ex As Exception
                'Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Sub
#End Region

    End Class
End Namespace
