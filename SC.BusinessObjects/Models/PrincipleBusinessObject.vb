Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Security.Principal

Namespace SC.BusinessObjects.Models

    Public Class PrincipleBusinessObject
        Implements IPrincipal

        Private _roles As New List(Of String)()
        Private _identity As IdentityBusinessObject

        Public Property Roles() As List(Of String)
            Get
                Return _roles
            End Get
            Set(ByVal value As List(Of String))
                _roles = value
            End Set
        End Property

        Public Sub New(ByVal identity As IdentityBusinessObject, ByVal roles As List(Of String))
            _identity = identity
            _roles = roles
        End Sub

        Public ReadOnly Property Identity() As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity
            Get
                Return _identity
            End Get
        End Property

        Public Function IsInRole(ByVal role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
            Return Roles.Contains(role)
        End Function
    End Class

End Namespace