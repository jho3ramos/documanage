Imports SC.BusinessObjects
Imports SC.BusinessObjects.Models
Imports System.Linq
Imports System.Security.Principal
Imports System.Text.RegularExpressions
Imports SC.Infrastructure.Helpers

Namespace SC.BusinessLogic.Services

    Public Class UserDataService
        Implements IUserDataService

        Private Shared principleType As String = "Custom"

        Dim _DatabaseLayer As New DatabaseLayer

        Public Function GetUserByLoginID(ByVal LoginID As String) As user Implements IUserDataService.GetUserByLoginID
            Try
                Dim user = _DatabaseLayer.getUserByLoginID(LoginID)
                Return user
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function
        Public Function GetUserByID(ByVal UserID As Integer) As user Implements IUserDataService.GetUserByID
            Try
                Dim user = _DatabaseLayer.getUserByID(UserID)
                Return user
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function Login(ByVal LoginID As String, _
                              ByVal LoginPassword As String) As PrincipleBusinessObject Implements IUserDataService.Login
            Dim errMsg As String = String.Empty
            Dim user As user = Nothing

            Dim sLoginID As String = LoginID.Trim()
            Dim sLoginPassword As String = LoginPassword.Trim()
            Dim principal As IPrincipal

            Try
                user = GetUserByLoginID(sLoginID)
                If user Is Nothing Then
                    errMsg += "User Id entered is not valid. Please try again or contact Support for assistance."
                    Throw New Exception(errMsg)
                End If

                If Crypto.Verify(sLoginPassword, user.password, "SHA1", user.saltvalue) Then
                    Dim userID As Integer = user.userid

                    Dim roleList As New List(Of String)
                    Dim sRoleList() As String = Nothing
                    Dim userRoles = _DatabaseLayer.getUserRole(LoginID)
                    If userRoles Is Nothing Then
                        errMsg += "Roles have not yet been assigned to this user. Please contact Support for assistance."
                        Throw New Exception(errMsg)
                    End If

                    Dim i As Integer = 0
                    For Each r In userRoles
                        roleList.Add(r.rolename)
                        i += 1
                    Next
                    Dim roleStringArray() As String = roleList.ToArray

                    ' create the Principal and Identity objects
                    If principleType = "Generic" Then
                        Dim identity As New GenericIdentity(user.username, "Custom")
                        principal = New GenericPrincipal(identity, roleStringArray)

                    Else
                        Dim identity As New IdentityBusinessObject(user.userid, user.username, "Custom")
                        principal = New PrincipleBusinessObject(identity, roleList)
                    End If
                Else
                    ' the credentials were not valid
                    ' so create an unauthenticated Principal/Identity
                    If principleType = "Generic" Then
                        Dim identity As New GenericIdentity("", "")
                        principal = New GenericPrincipal(identity, New String() {})

                    Else
                        Dim identity As New IdentityBusinessObject(0, "", "")
                        principal = New PrincipleBusinessObject(identity, Nothing)
                    End If
                    errMsg += "User ID and Password do not match. Please try again or contact Support for assistance."
                    Throw New Exception(errMsg)
                End If

                Return principal

            Catch ex As Exception
                'errMsg += "It takes longer to login your account. Please try again or contact Support for assistance."
                'Throw New Exception(errMsg)
                Throw New Exception(ex.Message, ex.InnerException)
            End Try
        End Function

        Public Function SaveUser(ByVal LoginID As String, ByVal LoginPassword As String, ByVal UserName As String) As Boolean Implements IUserDataService.SaveUser
            Try
                Dim user = _DatabaseLayer.saveUser(LoginID, LoginPassword, UserName)
                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message, ex.InnerException)
                Return False
            End Try
        End Function

    End Class
End Namespace
