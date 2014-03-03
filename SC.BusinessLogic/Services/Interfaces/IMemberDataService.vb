Imports System.Collections.ObjectModel
Imports SC.BusinessObjects.Models

Namespace SC.BusinessLogic.Services

    Public Interface IMemberDataService

        Function getMembers() As ObservableCollection(Of member_details)

        Function getMemberByID(ByVal memberID As String) As member_detail

        Function getFamilyMembers(ByVal memberID As String) As ObservableCollection(Of family_record)

        Function insertMember(memberDetails As member_detail) As Boolean

        Function saveMemberPhoto(memberInfo As member_information) As String

        Function saveMemberSign(memberInfo As member_information) As String

        Function updateMember(memberInfo As member_detail) As Boolean

        Function getAddress(barangayid As Integer) As member_address

        Function GetBarangayList(iTownID As Integer) As List(Of barangay)

        Function GetTownList(iProvinceID As Integer) As List(Of town)

        Function getProvinceList() As List(Of province)

        Function insertFamilyMember(familyRecordCollection As ObservableCollection(Of family_record)) As Boolean

        Function insertMemberInfo(member_information As member_information) As Boolean

    End Interface

End Namespace