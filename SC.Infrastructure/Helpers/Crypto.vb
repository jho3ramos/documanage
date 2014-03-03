Imports System
Imports System.Text
Imports System.Security.Cryptography

Namespace SC.Infrastructure.Helpers
    Public Class Crypto

#Region "Declarations"
        Public Const ALGORITHM_SHA1 As String = "SHA1"
        Public Const ALGORITHM_SHA256 As String = "SHA256"
        Public Const ALGORITHM_SHA384 As String = "SHA384"
        Public Const ALGORITHM_SHA512 As String = "SHA512"
        Public Const ALGORITHM_MD5 As String = "MD5"
#End Region

#Region "Public Methods"

        ''' <summary>
        ''' Generates a random SALT value using the .Net Cryptography
        ''' namespace.
        ''' </summary>
        ''' <returns>A Byte array</returns>
        ''' <remarks></remarks>
        Public Shared Function generateRadomSaltvalue() As Byte()
            Dim minSaltSize As Integer = 4
            Dim maxSaltSize As Integer = 8
            Dim random As New Random()
            Dim saltSize As Integer = random.[Next](minSaltSize, maxSaltSize)
            Dim saltBytes As Byte() = New Byte(saltSize - 1) {}
            Dim rng As New RNGCryptoServiceProvider()

            rng.GetNonZeroBytes(saltBytes)
            Return saltBytes
        End Function

        ''' <summary>
        ''' Creates and returns a calculated hash value.
        ''' </summary>
        ''' <param name="plainText">The plain text input to be hashed.</param>
        ''' <param name="hashAlgorithm">The hash algorithm used for the calculation.</param>
        ''' <param name="saltBytes">The salt byte array used in the algorithm</param>
        ''' <returns>A string value that represents a hashed value.</returns>
        ''' <remarks></remarks>
        Public Shared Function ComputeHash(ByVal plainText As String, ByVal hashAlgorithm As String, ByVal saltBytes As Byte()) As String
            'DealwithSalt(out saltBytes); 

            Dim plainTextBytes As Byte() = Encoding.UTF8.GetBytes(plainText)

            Dim plainTextWithSaltBytes As Byte() = New Byte(plainTextBytes.Length + saltBytes.Length - 1) {}

            Dim i As Integer = 0
            If saltBytes.Length <= plainTextBytes.Length Then
                For i = 0 To saltBytes.Length - 1
                    plainTextWithSaltBytes(i * 2) = plainTextBytes(i)
                    plainTextWithSaltBytes(i * 2 + 1) = saltBytes(i)
                Next
                Dim j As Integer = 0
                For j = 0 To plainTextBytes.Length - i - 1
                    plainTextWithSaltBytes(i * 2 + j) = plainTextBytes(i + j)

                Next
            Else
                For i = 0 To plainTextBytes.Length - 1
                    plainTextWithSaltBytes(i * 2) = saltBytes(i)
                    plainTextWithSaltBytes(i * 2 + 1) = plainTextBytes(i)
                Next
                Dim j As Integer = 0
                For j = 0 To saltBytes.Length - i - 1
                    plainTextWithSaltBytes(i * 2 + j) = saltBytes(i + j)
                Next
            End If

            Dim hash As HashAlgorithm

            If hashAlgorithm Is Nothing Then
                hashAlgorithm = ""
            End If

            Select Case hashAlgorithm.ToUpper()
                Case Crypto.ALGORITHM_SHA1
                    hash = New SHA1Managed()
                    Exit Select
                Case Crypto.ALGORITHM_SHA256

                    hash = New SHA256Managed()
                    Exit Select
                Case Crypto.ALGORITHM_SHA384

                    hash = New SHA384Managed()
                    Exit Select
                Case Crypto.ALGORITHM_MD5

                    hash = New SHA512Managed()
                    Exit Select
                Case Else

                    hash = New MD5CryptoServiceProvider()
                    Exit Select
            End Select

            Dim hashBytes As Byte() = hash.ComputeHash(plainTextWithSaltBytes)

            Dim hashValue As String = Convert.ToBase64String(hashBytes)

            Return hashValue
        End Function

        ''' <summary>
        ''' Checks if the plain text value is the same as the hashed value.
        ''' </summary>
        ''' <param name="plainText">The plain text value to be checked.</param>
        ''' <param name="hashCode">A hashed value to be compared to.</param>
        ''' <param name="hashAlgorithm">The hash algorithm to be used.</param>
        ''' <param name="saltValue">The salt value to be used in the algorithm.</param>
        ''' <returns>True if matched, False if not.</returns>
        ''' <remarks>Typically used when comparing an input from a user, to a hashed value that 
        ''' may be stored in a database. For example, a user login password.</remarks>
        Public Shared Function Verify(ByVal plainText As String, ByVal hashCode As String, ByVal hashAlgorithm As String, ByVal saltValue As String) As Boolean
            Dim saltValueBytes As Byte() = Nothing
            Try
                saltValueBytes = Convert.FromBase64String(saltValue)
            Catch ex As Exception
                Return False
            End Try
            If ComputeHash(plainText, hashAlgorithm, saltValueBytes).Equals(hashCode) Then
                Return True
            End If
            Return False
        End Function

#End Region

    End Class
End Namespace