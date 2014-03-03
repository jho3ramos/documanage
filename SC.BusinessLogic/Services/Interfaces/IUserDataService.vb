Imports System.Collections.ObjectModel
Imports SC.BusinessObjects.Models

Namespace SC.BusinessLogic.Services

    Public Interface IUserDataService

        Function GetUserByLoginID(ByVal LoginID As String) As user

        Function GetUserByID(ByVal UserID As Integer) As user

        Function Login(ByVal LoginID As String, ByVal LoginPassword As String) As PrincipleBusinessObject

        Function SaveUser(ByVal LoginID As String, ByVal LoginPassword As String, UserName As String) As Boolean

    End Interface

End Namespace