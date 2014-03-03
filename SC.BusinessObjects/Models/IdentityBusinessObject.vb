Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security.Principal

Namespace SC.BusinessObjects.Models

    Public Class IdentityBusinessObject
        Implements IIdentity

        Private _name As String = String.Empty
        Private _authType As String = String.Empty
        Private _isAuth As Boolean = True
        Private _userid As Integer = 0

        Public Sub New(ByVal userId As Integer, ByVal userName As String, ByVal authenticationType As String)
            _name = userName
            _userid = userId
            _authType = authenticationType
        End Sub

        Public ReadOnly Property UserId() As Integer
            Get
                Return _userid
            End Get
        End Property

#Region "IIdentity Members"

        Public ReadOnly Property AuthenticationType() As String Implements System.Security.Principal.IIdentity.AuthenticationType
            Get
                Return _authType
            End Get
        End Property

        Public ReadOnly Property IsAuthenticated() As Boolean Implements System.Security.Principal.IIdentity.IsAuthenticated
            Get
                Return _isAuth
            End Get
        End Property

        Public ReadOnly Property Name() As String Implements System.Security.Principal.IIdentity.Name
            Get
                Return _name
            End Get
        End Property

#End Region

    End Class

End Namespace