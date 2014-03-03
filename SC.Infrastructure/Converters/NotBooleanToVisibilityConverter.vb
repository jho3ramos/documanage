Imports System.Windows.Data
Imports System.Windows

Namespace SC.Infrastructure.Converters

    ''' <summary>
    ''' Represents a NotBooleanToVisbilityConverter.  If value is true, will return Collapsed, other wise returns Visible
    ''' </summary>
    <ValueConversion(GetType(Boolean), GetType(Visibility))>
    Public Class NotBooleanToVisbilityConverter
        Implements IValueConverter
        Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert

            If value Is Nothing OrElse Not (TypeOf value Is Boolean) Then
                Return Visibility.Visible

            ElseIf (CType(value, Boolean)) Then
                Return Visibility.Collapsed

            Else
                Return Visibility.Visible
            End If
        End Function

        Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class

End Namespace