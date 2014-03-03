Imports SC.BusinessObjects
Imports SC.BusinessObjects.Models
Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports SC.Infrastructure.Helpers
Imports System.Collections.ObjectModel

Namespace SC.BusinessLogic.Services

    Public Class MemberDataService
        Implements IMemberDataService

        Dim _DatabaseLayer As New DatabaseLayer

        Property imageFolder As String = My.Application.Info.DirectoryPath & "\photo"
        Property signFolder As String = My.Application.Info.DirectoryPath & "\sign"

        Public Function getMembers() As ObservableCollection(Of member_details) Implements IMemberDataService.getMembers
            Try
                Return _DatabaseLayer.getMembers()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function getMemberByID(memberID As String) As member_detail Implements IMemberDataService.getMemberByID
            Try
                Return _DatabaseLayer.getMemberByID(memberID)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function getFamilyMembers(memberID As String) As ObservableCollection(Of family_record) Implements IMemberDataService.getFamilyMembers
            Try
                Return _DatabaseLayer.getFamilyMember(memberID)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function insertMember(memberDetails As member_detail) As Boolean Implements IMemberDataService.insertMember
            Try
                Return _DatabaseLayer.insertMember(memberDetails)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function insertMemberInfo(member_information As member_information) As Boolean Implements IMemberDataService.insertMemberInfo
            Try
                Return _DatabaseLayer.insertMemberInfo(member_information)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function insertFamilyMember(familyRecordCollection As ObservableCollection(Of family_record)) As Boolean Implements IMemberDataService.insertFamilyMember
            Try
                Return _DatabaseLayer.insertFamilyMember(familyRecordCollection)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function updateMember(memberDetail As member_detail) As Boolean Implements IMemberDataService.updateMember
            Try
                Return _DatabaseLayer.updateMember(memberDetail)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function getAddress(barangayid As Integer) As member_address Implements IMemberDataService.getAddress
            Try
                Return _DatabaseLayer.getAddress(barangayid)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function getProvinceList() As List(Of province) Implements IMemberDataService.getProvinceList
            Try
                Return _DatabaseLayer.getProvinceList()
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetBarangayList(iTownID As Integer) As List(Of barangay) Implements IMemberDataService.GetBarangayList
            Try
                Return _DatabaseLayer.getBarangayList(iTownID)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function GetTownList(iProvinceID As Integer) As List(Of town) Implements IMemberDataService.GetTownList
            Try
                Return _DatabaseLayer.getTownList(iProvinceID)
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function saveMemberPhoto(memberInfo As member_information) As String Implements IMemberDataService.saveMemberPhoto
            Try
                ' lets make sure that the imageFolder exists
                If Not System.IO.Directory.Exists(imageFolder) Then
                    ' lets create it if none
                    System.IO.Directory.CreateDirectory(imageFolder)
                End If

                'generate new filename for photo
                Dim filename = Split(memberInfo.image, ".")
                Dim extension = filename(filename.Length - 1)
                Dim newFile = CStr(imageFolder) & "\img_" & memberInfo.members_sc_id & "." & extension
                'copy file with new filename
                System.IO.File.Copy(memberInfo.image, newFile, True)
                Return newFile
            Catch ex As Exception
                Return String.Empty
            End Try

        End Function

        Public Function saveMemberSign(memberInfo As member_information) As String Implements IMemberDataService.saveMemberSign
            Try
                ' lets make sure that the signFolder exists
                If Not System.IO.Directory.Exists(signFolder) Then
                    ' lets create it if none
                    System.IO.Directory.CreateDirectory(signFolder)
                End If

                'generate new filename for sign
                Dim filename = Split(memberInfo.sign, ".")
                Dim extension = filename(filename.Length - 1)
                Dim newFile = CStr(signFolder) & "\sgn_" & memberInfo.members_sc_id & "." & extension
                'copy file with new filename
                System.IO.File.Copy(memberInfo.sign, newFile, True)
                Return newFile
            Catch ex As Exception
                Return String.Empty
            End Try

        End Function

    End Class

End Namespace