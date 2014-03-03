Imports SC.Infrastructure.Helpers
Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports SC.BusinessLogic.Services
Imports System.Collections.ObjectModel
Imports System.Windows.Input

Namespace Modules.Members.ViewModels

    Public Class MembersViewModel
        Inherits ViewModelBase

#Region "  Declarations"

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

        Private _memberAccess As IMemberDataService

        Public Property deleteMemberCommand As ICommand
        Public Property createIDCommand As ICommand

#End Region

#Region "  Properties"

        Private _isBusy As Boolean = False
        Public Property IsBusy As Boolean
            Get
                Return _isBusy
            End Get
            Set(ByVal value As Boolean)
                _isBusy = value
                OnPropertyChanged("IsBusy")
            End Set
        End Property

        Private _errorMessage As String = String.Empty
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

        Private _isVisible As String = "Collapse"
        Public Property isVisible() As String
            Get
                Return _isVisible
            End Get
            Set(ByVal value As String)
                If (_isVisible <> value) Then
                    _isVisible = value
                    OnPropertyChanged("isVisible")
                End If
            End Set
        End Property

        Private _memberList As ObservableCollection(Of member_details)
        Public Property memberList() As ObservableCollection(Of member_details)
            Get
                Return _memberList
            End Get
            Set(ByVal value As ObservableCollection(Of member_details))
                _memberList = value
                OnPropertyChanged("memberList")
            End Set
        End Property

        Private _selectedMember As member_details
        Public Property selectedMember() As member_details
            Get
                Return _selectedMember
            End Get
            Set(ByVal value As member_details)
                _selectedMember = value
                updateProperty()
                isVisible = "Visible"
                OnPropertyChanged("selectedMember")
            End Set
        End Property

        Private _fullName As String
        Public Property fullName() As String
            Get
                Return StrConv(_fullName, vbProperCase)
            End Get
            Set(ByVal value As String)
                If (_fullName <> value) Then
                    _fullName = value
                    OnPropertyChanged("fullName")
                End If
            End Set
        End Property

        Private _fullAddress As String
        Public Property fullAddress() As String
            Get
                Return _fullAddress
            End Get
            Set(ByVal value As String)
                If (_fullAddress <> value) Then
                    _fullAddress = value
                    OnPropertyChanged("fullAddress")
                End If
            End Set
        End Property

        Private _age As Integer
        Public Property age() As Integer
            Get
                Return _age
            End Get
            Set(ByVal value As Integer)
                If (_age <> value) Then
                    _age = value
                    OnPropertyChanged("age")
                End If
            End Set
        End Property

        Private _gender As String
        Public Property gender() As String
            Get
                If _gender = "m" Then
                    Return "Male"
                Else
                    Return "Female"
                End If
            End Get
            Set(ByVal value As String)
                If (_gender <> value) Then
                    _gender = value
                    OnPropertyChanged("gender")
                End If
            End Set
        End Property

        Private _childList As ObservableCollection(Of family_record)
        Public Property childList() As ObservableCollection(Of family_record)
            Get
                Return _childList
            End Get
            Set(ByVal value As ObservableCollection(Of family_record))
                _childList = value
                OnPropertyChanged("childList")
            End Set
        End Property


#End Region

#Region "   Constructors"

        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _regionManager = regionManager
            _container = container

            _memberAccess = _container.Resolve(Of IMemberDataService)()

            Dim collectMemberAction As Action = New Action(AddressOf collectMemberExecute)
            'memberList = New DelegateWorker(collectMemberAction, Nothing, Nothing)

            collectMemberExecute()

        End Sub

#End Region

#Region "   Command Methods"

        Private Sub collectMemberExecute()
            memberList = _memberAccess.getMembers()
        End Sub

        Private Sub deleteMemberExecute()
            'todo deleteMember
        End Sub

        Private Sub createIDExecute()
            'todo createID
        End Sub

        Private Sub editMemberExecute()
            'todo editMember
        End Sub

#End Region

#Region "Methods"
        Private Sub updateProperty()
            fullName = String.Format("{0} {1} {2}", _selectedMember.firstname, _selectedMember.middlename, _selectedMember.lastname)
            fullAddress = String.Format("{0} {1}, {2}, {3}", _selectedMember.address, _selectedMember.barangayname, _selectedMember.townname, _selectedMember.provincename)
            age = DateDiff(DateInterval.Year, CDate(selectedMember.dob), Now)
            gender = _selectedMember.gender

            'childList = _memberAccess.getFamilyMembers(_selectedMember.sc_id)
        End Sub
#End Region

    End Class

End Namespace