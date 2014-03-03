Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Input
Imports SC.BusinessObjects.Models
Imports SC.Infrastructure.Events
Imports Microsoft.Practices.ServiceLocation
Imports Microsoft.Practices.Prism.Events

Namespace SC.Infrastructure.Helpers
    Public Class ViewModelBase
        Implements INotifyPropertyChanged

        'Private myServiceLocator As New ServiceLocator
        Private _userPrinciple As PrincipleBusinessObject

        Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

        Protected Sub OnPropertyChanged(ByVal strPropertyName As String)
            If Me.PropertyChangedEvent IsNot Nothing Then
                RaiseEvent PropertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(strPropertyName))
            End If
        End Sub

        Private privateThrowOnInvalidPropertyName As Boolean

        Protected Overridable Property ThrowOnInvalidPropertyName() As Boolean
            Get
                Return privateThrowOnInvalidPropertyName
            End Get
            Set(ByVal value As Boolean)
                privateThrowOnInvalidPropertyName = value
            End Set
        End Property

        <Conditional("DEBUG"), DebuggerStepThrough()> _
        Public Sub VerifyPropertyName(ByVal propertyName As String)
            ' Verify that the property name matches a real,  
            ' public, instance property on this object.
            If TypeDescriptor.GetProperties(Me)(propertyName) Is Nothing Then
                Dim msg As String = "Invalid property name: " & propertyName
                If Me.ThrowOnInvalidPropertyName Then
                    Throw New Exception(msg)
                Else
                    Debug.Fail(msg)
                End If
            End If
        End Sub

        'Public Function ServiceLocator() As ServiceLocator
        '    Return Me.myServiceLocator
        'End Function

        'Public Function GetService(Of T)() As T
        '    Return myServiceLocator.GetService(Of T)()
        'End Function

        Public Property UserPrinciple As PrincipleBusinessObject
            Get
                Return _userPrinciple
            End Get
            Set(ByVal value As PrincipleBusinessObject)
                _userPrinciple = value
            End Set
        End Property

        Public Sub publishStatusEvent(params As String)
            Dim eventAggregator = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance(Of IEventAggregator)()
            Dim statusUpdatedEvent = eventAggregator.GetEvent(Of StatusUpdatedEvent)()
            statusUpdatedEvent.Publish(params)
        End Sub

    End Class
End Namespace
