Imports Microsoft.Practices.Prism.Regions
Imports Microsoft.Practices.Unity
Imports SC.Infrastructure.Helpers
Imports System.Windows.Input
Imports System.Collections.ObjectModel
Imports SC.BusinessObjects
Imports SC.BusinessLogic.Services
Imports SC.BusinessLogic.Services.Dialog
Imports System.Windows.Media.Imaging
Imports SC.BusinessObjects.Models
Imports System.Security.Principal

Namespace Modules.Members.ViewModels

    Public Class MemberAddViewModel
        Inherits ViewModelBase

#Region "  Declarations"

        Private _isBusy As Boolean = False
        Private _errorMessage As String = String.Empty

        Private _regionManager As IRegionManager
        Private _container As IUnityContainer

        Private _memberAccess As IMemberDataService
        'Private _userAccess As IUserDataService

        Private _modalDialog As IDialogService

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

#Region "   Member"

        Public Property addMemberCommand As ICommand
        Public Property editMemberCommand As ICommand
        Public Property addPhotoCommand As ICommand
        Public Property addSignCommand As ICommand

        Private _memberDetail As New member_detail
        Public Property memberDetail() As member_detail
            Get
                Return _memberDetail
            End Get
            Set(ByVal value As member_detail)
                _memberDetail = value
                OnPropertyChanged("memberDetail")
            End Set
        End Property

        Private _memberInfo As New member_information
        Public Property memberInfo() As member_information
            Get
                Return _memberInfo
            End Get
            Set(ByVal value As member_information)
                _memberInfo = value
                OnPropertyChanged("memberInfo")
            End Set
        End Property

#End Region

#Region "   Member Family"

        Private _mapping As New member_family_mapping
        Public Property mapping() As member_family_mapping
            Get
                Return _mapping
            End Get
            Set(ByVal value As member_family_mapping)
                _mapping = value
                OnPropertyChanged("mapping")
            End Set
        End Property

#End Region

#Region "   Family"

        Public Property addFamilyCommand As ICommand
        Public Property editFamilyCommand As ICommand
        Public Property deleteFamilyCommand As ICommand

        Private _familyMemberRecord As New family_record
        Public Property familyMemberRecord() As family_record
            Get
                Return _familyMemberRecord
            End Get
            Set(ByVal value As family_record)
                _familyMemberRecord = value
                OnPropertyChanged("familyMemberRecord")
            End Set
        End Property

        Private _familyMemberRecordCollection As New List(Of family_record)
        Public Property familyMemberRecordCollection() As List(Of family_record)
            Get
                Return _familyMemberRecordCollection
            End Get
            Set(ByVal value As List(Of family_record))
                _familyMemberRecordCollection = value
                OnPropertyChanged("familyMemberRecordCollection")
            End Set
        End Property

        Private _selectedFamilyMember As family_record
        Public Property selectedFamilyMember() As family_record
            Get
                Return _selectedFamilyMember
            End Get
            Set(ByVal value As family_record)
                _selectedFamilyMember = value
                OnPropertyChanged("selectedFamilyMember")
            End Set
        End Property

        Private _selectedIndex As Integer = -1
        Public Property selectedIndex() As Integer
            Get
                Return _selectedIndex
            End Get
            Set(ByVal value As Integer)
                If (_selectedIndex <> value) Then
                    _selectedIndex = value
                    OnPropertyChanged("selectedIndex")
                End If
            End Set
        End Property

        Private _isVisible As Boolean = False
        Public Property isVisible() As Boolean
            Get
                Return _isVisible
            End Get
            Set(ByVal value As Boolean)
                If (_isVisible <> value) Then
                    _isVisible = value
                    OnPropertyChanged("isVisible")
                End If
            End Set
        End Property

        Private _isEdit As Boolean = False
        Public Property isEdit() As Boolean
            Get
                Return _isEdit
            End Get
            Set(ByVal value As Boolean)
                If (_isEdit <> value) Then
                    _isEdit = value
                    OnPropertyChanged("isEdit")
                End If
            End Set
        End Property

        Private _btnAddLabel As String = "Add"
        Public Property btnAddLabel() As String
            Get
                Return _btnAddLabel
            End Get
            Set(ByVal value As String)
                If (_btnAddLabel <> value) Then
                    _btnAddLabel = value
                    OnPropertyChanged("btnAddLabel")
                End If
            End Set
        End Property


#End Region

#Region "   UI Properties"

        Private _gender As New ArrayList
        Public Property gender() As ArrayList
            Get
                Return _gender
            End Get
            Set(ByVal value As ArrayList)
                _gender = value
                'OnPropertyChanged("gender")
            End Set
        End Property

        Private _civilStatus As New ArrayList
        Public Property civilStatus() As ArrayList
            Get
                Return _civilStatus
            End Get
            Set(ByVal value As ArrayList)
                _civilStatus = value
                'OnPropertyChanged("civilStatus")
            End Set
        End Property

        Private _relationship As New ArrayList
        Public Property relationship() As ArrayList
            Get
                Return _relationship
            End Get
            Set(ByVal value As ArrayList)
                _relationship = value
                'OnPropertyChanged("relationship")
            End Set
        End Property


        Private _barangayList As List(Of barangay)
        Public Property barangayList() As List(Of barangay)
            Get
                Return _barangayList
            End Get
            Set(ByVal value As List(Of barangay))
                _barangayList = value
                OnPropertyChanged("barangayList")
            End Set
        End Property

        Private _selectedBarangay As barangay
        Public Property selectedBarangay() As barangay
            Get
                Return _selectedBarangay
            End Get
            Set(ByVal value As barangay)
                _selectedBarangay = value
                memberDetail.barangayid = value.id
                OnPropertyChanged("selectedBarangay")
            End Set
        End Property


        Private _townList As List(Of town)
        Public Property townList() As List(Of town)
            Get
                Return _townList
            End Get
            Set(ByVal value As List(Of town))
                _townList = value
                OnPropertyChanged("townList")
            End Set
        End Property

        Private _selectedTown As town
        Public Property selectedTown() As town
            Get
                Return _selectedTown
            End Get
            Set(ByVal value As town)
                _selectedTown = value
                OnPropertyChanged("selectedTown")
                getBarangayList()
            End Set
        End Property

        Private _provinceList As List(Of province)
        Public Property provinceList() As List(Of province)
            Get
                Return _provinceList
            End Get
            Set(ByVal value As List(Of province))
                _provinceList = value
                OnPropertyChanged("provinceList")
            End Set
        End Property

        Private _selectedProvince As province
        Public Property selectedProvince() As province
            Get
                Return _selectedProvince
            End Get
            Set(ByVal value As province)
                _selectedProvince = value
                OnPropertyChanged("selectedProvince")
                getTownList()
            End Set
        End Property


#End Region

#End Region


#Region "  Constructors"

        Public Sub New(ByVal regionManager As IRegionManager, ByVal container As IUnityContainer)

            _regionManager = regionManager
            _container = container

            _memberAccess = _container.Resolve(Of IMemberDataService)()
            '_userAccess = _container.Resolve(Of IUserDataService)()
            _modalDialog = _container.Resolve(Of IDialogService)()
            Dim myUp As PrincipleBusinessObject = _container.Resolve(GetType(IPrincipal), "UserPrinciple")
            memberDetail.created_by = myUp.Identity.Name
            memberInfo.created_by = myUp.Identity.Name
            memberDetail.modified_by = myUp.Identity.Name
            memberInfo.modified_by = myUp.Identity.Name

            ' Member Command
            addPhotoCommand = New RelayCommand(AddressOf addPhotoExecute)

            addSignCommand = New RelayCommand(AddressOf addSignExecute)

            Dim addMemberAction As Action = New Action(AddressOf addMemberExecute)
            addMemberCommand = New AsyncDelegateCommand(addMemberAction, Nothing)
            ' end of Member Command

            ' Family Member Command 
            Dim addFamilyAction As Action = New Action(AddressOf addFamilyExecute)
            addFamilyCommand = New AsyncDelegateCommand(addFamilyAction, Nothing, Sub() updateUI())
            'addFamilyCommand = New RelayCommand(AddressOf addFamilyExecute)

            Dim editFamilyAction As Action = New Action(AddressOf editFamilyExecute)
            editFamilyCommand = New AsyncDelegateCommand(editFamilyAction, Nothing, Sub() updateUI())

            Dim deleteFamilyAction As Action = New Action(AddressOf deleteFamilyExecute)
            deleteFamilyCommand = New AsyncDelegateCommand(deleteFamilyAction, Nothing, Sub() updateUI())
            ' end of Family Member

            preLoad()

        End Sub

#End Region

#Region "Command Methods"

        Private Sub preLoad()
            ' populate the gender property
            _gender.Add("Male")
            _gender.Add("Female")

            ' populate the civilStatus property
            _civilStatus.Add("Married")
            _civilStatus.Add("Single")
            _civilStatus.Add("Widow")
            _civilStatus.Add("Widower")
            _civilStatus.Add("Separated")

            ' populate the relationship selection
            _relationship.Add("Spouse")
            _relationship.Add("Child")

            ' get provinceList
            getProvinceList()

        End Sub

        Public Sub getProvinceList()
            provinceList = _memberAccess.getProvinceList
        End Sub

        Public Sub getTownList()
            townList = _memberAccess.GetTownList(selectedProvince.id)
        End Sub

        Public Sub getBarangayList()
            barangayList = _memberAccess.GetBarangayList(selectedTown.id)
        End Sub

#Region " Member Command Implementation"

        Private Sub addPhotoExecute()
            Dim initialDirectory As String = My.Computer.FileSystem.SpecialDirectories.MyPictures
            Dim fileFilter As String = "Image Files (*.jpeg,*.jpg,*.png)|*.jpeg;*.jpg;*.png"
            memberInfo.image = _modalDialog.FileOpen(initialDirectory, fileFilter)
            If memberInfo.image <> "" Then
                OnPropertyChanged("memberInfo")
                loadPhoto()
            End If
        End Sub

        Private Sub addSignExecute()
            Dim initialDirectory As String = My.Computer.FileSystem.SpecialDirectories.MyPictures
            Dim fileFilter As String = "Image Files (*.jpeg,*.jpg,*.png)|*.jpeg;*.jpg;*.png"
            memberInfo.sign = _modalDialog.FileOpen(initialDirectory, fileFilter)
            If memberInfo.sign <> "" Then
                OnPropertyChanged("memberInfo")
                loadPhoto()
            End If
        End Sub

        Private Sub loadPhoto()
            '_modalDialog.ShowMessageView("Add Photo", "How was it?")
        End Sub

        Private Sub loadSign()
            '_modalDialog.ShowMessageView("Add Signature", "How was it?")
        End Sub

        Private Sub addMemberExecute()
            ' make sure we have an OSCA ID
            If IsNothing(memberInfo.members_sc_id) Or memberInfo.members_sc_id = String.Empty Then
                ' generate OSCA ID
                Dim oscaID As String = IDGenerator.getID()
                memberInfo.members_sc_id = oscaID
                memberDetail.sc_id = oscaID
            End If
            ' prepare photo and signature then save to preferred location
            memberInfo.image = _memberAccess.saveMemberPhoto(memberInfo)
            memberInfo.sign = _memberAccess.saveMemberSign(memberInfo)

            ' save the member details
            ' todo correct the date and create by...
            memberDetail.created = DateTime.Now
            ' set default value of status
            memberDetail.status = "active"
            If _memberAccess.insertMember(memberDetail) Then
                ' todo get the member record id to use in mapping

                ' save the member details optional fields
                _memberAccess.insertMemberInfo(memberInfo)

            End If

            ' todo save the family records of the member
            '_memberAccess.insertFamilyMember(familyMemberRecordCollection)
        End Sub

#End Region

#Region " Family Member Command Implementation"

        Private Sub addFamilyExecute()
            If Not IsNothing(familyMemberRecord) Then
                ' todo save the member record
                Try
                    If isEdit Then
                        ' update the collection
                        With familyMemberRecordCollection(selectedIndex)
                            .firstname = familyMemberRecord.firstname
                            .middlename = familyMemberRecord.middlename
                            .lastname = familyMemberRecord.lastname
                            .gender = familyMemberRecord.gender
                            .civilstatus = familyMemberRecord.civilstatus
                            .religion = familyMemberRecord.religion
                        End With
                        OnPropertyChanged("familyMemberRecordCollection")
                        Exit Try
                    End If

                    familyMemberRecordCollection.Add(New family_record With { _
                            .firstname = familyMemberRecord.firstname, _
                            .middlename = familyMemberRecord.middlename, _
                            .lastname = familyMemberRecord.lastname, _
                            .gender = familyMemberRecord.gender, _
                            .civilstatus = familyMemberRecord.civilstatus, _
                            .religion = familyMemberRecord.religion, _
                            .dob = familyMemberRecord.dob, _
                            .relationship = familyMemberRecord.relationship _
                    })
                    OnPropertyChanged("familyMemberRecordCollection")
                Catch ex As Exception

                End Try

                '_modalDialog.ShowMessage("added to list", "Member", DialogButton.OK, DialogImage.Information)
                '_modalDialog.ShowMessageView("How was it?")
            End If

        End Sub

        Private Sub editFamilyExecute()
            ' edit the selected family member
            Try
                If Not IsNothing(selectedFamilyMember) Then
                    With familyMemberRecord
                        .firstname = selectedFamilyMember.firstname
                        .middlename = selectedFamilyMember.middlename
                        .lastname = selectedFamilyMember.lastname
                        .gender = selectedFamilyMember.gender
                        .civilstatus = selectedFamilyMember.civilstatus
                        .religion = selectedFamilyMember.religion
                    End With
                End If
                isEdit = True
            Catch ex As Exception

            End Try
        End Sub

        Private Sub deleteFamilyExecute()
            Try
                If Not IsNothing(selectedFamilyMember) And selectedIndex > 0 Then
                    familyMemberRecordCollection.RemoveAt(selectedIndex)
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub updateUI()
            If isVisible Then
                btnAddLabel = "Add"
                isVisible = False
                isEdit = False
            Else
                btnAddLabel = "Add to list"
                isVisible = True
            End If
        End Sub

#End Region



#End Region


    End Class

End Namespace