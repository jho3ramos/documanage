Namespace SC.BusinessObjects

    ''' <summary>
    ''' Generates ID for any combination of 3(three) string type and 2(two) integer type
    ''' </summary>
    ''' <remarks></remarks>
    Public Class IDGenerator

#Region "Constructor"

        Sub New()

        End Sub

#End Region

#Region "Properties"

        Private Shared Property IDGenerate As String

        Private _customer_Details As Object
        Public Property customer_Details() As Object
            Get
                Return _customer_Details
            End Get
            Set(ByVal value As Object)
                _customer_Details = value
            End Set
        End Property

        Private _customerID As String
        Public Property customerID() As String
            Get
                Return _customerID
            End Get
            Set(ByVal value As String)
                If _customerID <> value Then
                    _customerID = value
                End If
            End Set
        End Property

        Private _paramDate As String
        Public Property paramDate() As String
            Get
                Return _paramDate
            End Get
            Set(ByVal value As String)
                If _paramDate <> value Then
                    _paramDate = value
                End If
            End Set
        End Property

        Private _paramStringOne As String
        Public Property paramStringOne() As String
            Get
                Return _paramStringOne
            End Get
            Set(ByVal value As String)
                If _paramStringOne <> value Then
                    _paramStringOne = value
                End If
            End Set
        End Property

        Private _paramStringTwo As String
        Public Property paramStringTwo() As String
            Get
                Return _paramStringTwo
            End Get
            Set(ByVal value As String)
                If _paramStringTwo <> value Then
                    _paramStringTwo = value
                End If
            End Set
        End Property

        Private _paramStringThree As String
        Public Property paramStringThree() As String
            Get
                Return _paramStringThree
            End Get
            Set(ByVal value As String)
                If _paramStringThree <> value Then
                    _paramStringThree = value
                End If
            End Set
        End Property

        Private _paramIntOne As String
        Public Property paramIntOne() As String
            Get
                Return _paramIntOne
            End Get
            Set(ByVal value As String)
                If _paramIntOne <> value Then
                    _paramIntOne = value
                End If
            End Set
        End Property

        Private _paramIntTwo As String
        Public Property paramIntTwo() As String
            Get
                Return _paramIntTwo
            End Get
            Set(ByVal value As String)
                If _paramIntTwo <> value Then
                    _paramIntTwo = value
                End If
            End Set
        End Property

#End Region

#Region "Methods"


        Private Function getTownCode(p1 As Integer) As String
            ' step 01: 'prepare the data
            'Dim jDatabase As New JDatabase
            Dim dbTableName As String = "ref_town"
            Dim dbFieldName As String = "town_code"
            Dim id As Integer = p1
            Dim townCode As New Object

            'townCode = jDatabase.GetData(dbTableName, dbFieldName, id)
            If IsDBNull(townCode) Then
                'MessageBox.Show("Please update your reference.", "Get Town Code", MessageBoxButton.OK, MessageBoxImage.Information)
            End If

            Return townCode.ToString

        End Function

        Private Function getBrgyCode(p1 As Integer) As String
            ' step 01: 'prepare the data
            'Dim jDatabase As New JDatabase
            Dim dbTableName As String = "ref_barangay"
            Dim dbFieldName As String = "brgy_code"
            Dim id As Integer = p1
            Dim brgyCode As New Object

            'brgyCode = jDatabase.GetData(dbTableName, dbFieldName, id)
            If IsDBNull(brgyCode) Then
                'MessageBox.Show("Please update your reference.", "Get Barangay Code", MessageBoxButton.OK, MessageBoxImage.Information)
            End If

            Return brgyCode.ToString

        End Function

        Private Function getCustomerCounter(p1 As Integer) As Object
            ' step 01: 'prepare the data
            'Dim jDatabase As New JDatabase
            Dim dbTableName As String = "cust_member_counter"
            Dim dbFieldName As String = "member_count"
            Dim dbkey As String = "brgy_id='" & p1 & "'"
            Dim customerCount As New Object

            'customerCount = jDatabase.GetData(dbTableName, dbFieldName, dbkey)
            If customerCount Is Nothing Then
                customerCount = 1

                Dim dbFieldNames As New ArrayList
                dbFieldNames.Add("brgy_id")
                dbFieldNames.Add("member_count")

                Dim dbValues As New ArrayList
                dbValues.Add(p1)
                dbValues.Add(customerCount)

                'jDatabase.InsertRowList(dbTableName, dbFieldNames, dbValues)

            Else

                customerCount += 1
                Dim setValues As String = "member_count='" & customerCount & "'"
                'jDatabase.UpdateRowList(dbTableName, setValues, dbkey)

            End If

            Return customerCount.ToString

        End Function

        Shared Function getID() As String
            ' todo implement ID generator
            Return "OSCA-001"
        End Function

#End Region



    End Class

End Namespace