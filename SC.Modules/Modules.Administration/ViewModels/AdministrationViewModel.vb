Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports SC.Infrastructure.Helpers

Namespace Modules.Administration.ViewModels
    Partial Public Class AdministrationViewModel
        Inherits ViewModelBase

#Region "  Declarations"

        Private _isBusy As Boolean = False
        Private _errorMessage As String = String.Empty

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

#End Region

#Region "  Properties"

        Public Property IsBusy As Boolean
            Get
                Return _isBusy
            End Get
            Set(ByVal value As Boolean)
                _isBusy = value
                OnPropertyChanged("IsBusy")
            End Set
        End Property

        Public Property errorMessage As String
            Get
                Return _errorMessage
            End Get
            Set(ByVal value As String)
                _errorMessage = value
                OnPropertyChanged("errorMessage")
                publishStatusEvent(_errorMessage)
            End Set
        End Property

#End Region

#Region "  Constructors"

        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _regionManager = regionManager
            _container = container

            'ServiceLocator.RegisterService(Of ICustomerDataService)(New CustomerDataService)
            '_customerAccess = GetService(Of ICustomerDataService)()

            'Dim getCustomerListAction As Action = New Action(AddressOf getCustomerListExecute)
            'getCustomerListCommand = New AsyncDelegateCommand(getCustomerListAction, Nothing)

        End Sub

#End Region

#Region "Command Methods"



#End Region

    End Class

End Namespace

