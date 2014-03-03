Imports System.Data
Imports MySql.Data.MySqlClient
Imports System
Imports System.Management

Namespace SC.BusinessObjects

    ''' <summary>
    ''' Handles connections and CRUD transactions to the MySQL database
    ''' </summary>
    ''' <remarks></remarks>
    Public Class JDatabase

#Region "Database Property Settings"

        Private _server As String
        Public Property server() As String
            Get
                Return _server
            End Get
            Set(ByVal value As String)
                If _server <> value Then
                    _server = value
                    My.Settings.server = _server
                    My.Settings.Save()
                End If
            End Set
        End Property

        Private _userID As String
        Public Property userID() As String
            Get
                Return _userID
            End Get
            Set(ByVal value As String)
                If _userID <> value Then
                    _userID = value
                    My.Settings.userID = _userID
                    My.Settings.Save()
                End If
            End Set
        End Property

        Private _userPass As String
        Public Property userPass() As String
            Get
                Return _userPass
            End Get
            Set(ByVal value As String)
                If _userPass <> value Then
                    _userPass = value
                    My.Settings.password = _userPass
                    My.Settings.Save()
                End If
            End Set
        End Property

        Private _dataBase As String
        Public Property dataBase() As String
            Get
                Return _dataBase
            End Get
            Set(ByVal value As String)
                If _dataBase <> value Then
                    _dataBase = value
                    My.Settings.database = _dataBase
                    My.Settings.Save()
                End If
            End Set
        End Property

        Private Property mySQLConString As String
        Private Property myConnectionString As MySqlConnection
        Private Property sql As String
        Private Property dbCommand As MySqlCommand

        Private Property myData As DataSet = Nothing
        Private Property myAdapter As MySqlDataAdapter = Nothing
        Private Property myCommand As MySqlCommand = Nothing

#End Region

#Region "Constructor"
        Public Sub New()

            server = My.Settings.server
            userID = My.Settings.userID

            If My.Settings.password = String.Empty Then
                userPass = String.Empty
            Else
                userPass = My.Settings.password
            End If

                dataBase = My.Settings.database

                mySQLConString = "server=" & server & ";" _
                                                      & "uid=" & userID & ";" _
                                                      & "pwd=" & userPass & ";" _
                                                      & "database=" & dataBase

        End Sub
#End Region

#Region "Database Inquiry"

        ''' <summary>
        ''' Retrieves data from the database with customized SQL query string
        ''' </summary>
        ''' <param name="dbQuery">Customized SQL string</param>
        ''' <returns>list or lists of data</returns>
        ''' <remarks>Used to get data from the related database table</remarks>
        Public Overridable Function LoadRowList(ByVal dbQuery As String) As DataSet

            Return getRowData(dbQuery)

        End Function

        ''' <summary>
        ''' Retrieves data from the database based on id.
        ''' </summary>
        ''' <param name="dbTableName">Table name of the database</param>
        ''' <param name="id">The id of the data to retrieve</param>
        ''' <returns>Row list of data</returns>
        ''' <remarks></remarks>
        Public Overridable Function LoadRowList(ByVal dbTableName As String, ByVal id As String) As DataSet

            ' set the query
            sql = "Select * FROM {0} WHERE {1}"
            sql = String.Format(sql, dbTableName, "id=" & encloseText(CStr(id), """"))

            Return getRowData(sql)

        End Function

        Public Overridable Function LoadRowList(ByVal dbTableName As String, ByVal fieldParameter As ArrayList) As DataSet

            ' set the query
            sql = "Select * FROM {0} WHERE {1}"
            sql = String.Format(sql, dbTableName, String.Join(" AND ", TryCast(fieldParameter.ToArray(GetType(String)), String())))

            Return getRowData(sql)

        End Function

        ''' <summary>
        ''' Retrieves more than one field of data from the database based on id.
        ''' </summary>
        ''' <param name="dbFieldName">Array of field names of the database to retrieve</param>
        ''' <param name="dbTableName">Table name of the database</param>
        ''' <param name="id">The id of the data to retrieve</param>
        ''' <returns>Row list of data</returns>
        ''' <remarks>If only one field name is required to retrieve, please use the GetData function instead.</remarks>
        Public Overridable Function LoadRowList(ByVal dbFieldName As ArrayList, ByVal dbTableName As String, ByVal id As String) As DataSet

            ' set the query
            sql = "Select {0} FROM {1} WHERE {2} AND published=1"
            sql = String.Format(sql, String.Join(", ", TryCast(dbFieldName.ToArray(GetType(String)), String())), dbTableName, "id=" & encloseText(CStr(id), """"))

            Return getRowData(sql)

        End Function

        ''' <summary>
        ''' Retrieves more than one field of data from the database based on field name parameters.
        ''' </summary>
        ''' <param name="dbFieldName">Array of field names of the database to retrieve</param>
        ''' <param name="dbTableName">Table name of the database</param>
        ''' <param name="dbFieldNameParameters">The field name required parameters.</param>
        ''' <returns>Row list of data</returns>
        ''' <remarks>If only one field name is required to retrieve, please use the GetData function instead.</remarks>
        Public Overridable Function LoadRowList(ByVal dbFieldName As ArrayList, ByVal dbTableName As String, ByVal dbFieldNameParameters As ArrayList) As DataSet

            ' set the query
            sql = "Select {0} FROM {1} WHERE {2}"
            sql = String.Format(sql, String.Join(", ", TryCast(dbFieldName.ToArray(GetType(String)), String())), dbTableName, String.Join(" AND ", TryCast(dbFieldNameParameters.ToArray(GetType(String)), String())))

            Return getRowData(sql)

        End Function
        ''' <summary>
        ''' Execute to retrieve data from the database
        ''' </summary>
        ''' <param name="sql">the command string</param>
        ''' <returns>data from the database</returns>
        ''' <remarks></remarks>
        Private Function getRowData(ByVal sql As String) As DataSet

            Using myConnectionString As New MySqlConnection(mySQLConString)
                dbCommand = New MySqlCommand(sql, myConnectionString)
                getRowData = New DataSet
                Try
                    Dim myadapter = New MySqlDataAdapter(dbCommand)
                    myadapter.Fill(getRowData)
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                End Try
                Return getRowData
            End Using

        End Function

        Public Overridable Function GetData(sql As String)

            Return getSingleData(sql)

        End Function

        ''' <summary>
        ''' Retrieves single data based on id.
        ''' </summary>
        ''' <param name="dbFieldName">the data to get from the database</param>
        ''' <param name="dbTableName" >the table name where the data is to retrieve</param>
        ''' <param name="id">the primary key of the object property to retrieve</param>
        ''' <returns>single value</returns>
        ''' <remarks></remarks>
        Public Overridable Function GetData(dbTableName As String, dbFieldName As String, id As Integer)

            ' set the query
            sql = "Select {0} FROM {1} WHERE {2}"
            sql = String.Format(sql, dbFieldName, dbTableName, "id=" & encloseText(CStr(id), """"))

            Return getSingleData(sql)

        End Function


        Public Overridable Function GetData(dbTableName As String, dbFieldname As String, dbkey As String)

            ' set the query
            sql = "Select {0} FROM {1} WHERE {2}"
            sql = String.Format(sql, dbFieldname, dbTableName, dbkey)

            Return getSingleData(sql)

        End Function

        Private Function getSingleData(ByRef sql As String) As Object

            Using myConnectionString As New MySqlConnection(mySQLConString)
                getSingleData = Nothing
                dbCommand = New MySqlCommand(sql, myConnectionString)

                Try
                    dbCommand.Connection.Open()
                    getSingleData = dbCommand.ExecuteScalar
                    dbCommand.Connection.Close()
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                    dbCommand.Connection.Close()
                End Try
                Return getSingleData

            End Using

        End Function

        ''' <summary>
        ''' Retrieve the data type of every field of the database
        ''' </summary>
        ''' <param name="dbSchema">The database name</param>
        ''' <param name="dbTableName">The table name of the database</param>
        ''' <param name="dbColumn">the field name of the database</param>
        ''' <returns>Data type of the field name</returns>
        ''' <remarks></remarks>
        Private Function GetDataType(dbSchema As String, dbTableName As String, dbColumn As String)

            ' set the query
            sql = "SELECT data_type FROM information_schema.columns WHERE table_schema='{0}' AND table_name='{1}' AND column_name='{2}'"
            sql = String.Format(sql, dbSchema, dbTableName, dbColumn)

            GetDataType = Nothing
            dbCommand = New MySqlCommand(sql, myConnectionString)
            Try
                dbCommand.Connection.Open()
                GetDataType = dbCommand.ExecuteScalar
                dbCommand.Connection.Close()
            Catch ex As Exception
                'MessageBox.Show(ex.Message)
                dbCommand.Connection.Close()
            End Try
            dbCommand = Nothing
            Return GetDataType

        End Function

        ''' <summary>
        ''' Enclose a text with character
        ''' </summary>
        ''' <param name="Ttext">The string to apply enclosure</param>
        ''' <param name="Tchar">The character to enclose</param>
        ''' <returns>Enclosed string</returns>
        ''' <remarks></remarks>
        Overridable Function encloseText(ByVal Ttext As String, Tchar As String)
            Return Tchar & Ttext & Tchar
        End Function

        ''' <summary>
        ''' Enclose a string with a character
        ''' </summary>
        ''' <param name="Ttext">The string to apply enclosure</param>
        ''' <param name="Tchar1">The character to enclose in the beginning</param>
        ''' <param name="Tchar2">The character to enclose in the end</param>
        ''' <returns>Enclosed string</returns>
        ''' <remarks></remarks>
        Overridable Function encloseText(ByVal Ttext As String, Tchar1 As String, Tchar2 As String)
            Return Tchar1 & Ttext & Tchar2
        End Function

        ''' <summary>
        ''' Format date to accepted MySQL Database format
        ''' </summary>
        ''' <param name="dDate">a date to format</param>
        ''' <returns>formatted MySQL accepted date</returns>
        ''' <remarks></remarks>
        Public Function MySQLDate(dDate As Date)
            Return Format(CDate(dDate), "yyyy-MM-dd HH:mm:ss")
        End Function

#End Region

#Region "Database Update"

        ''' <summary>
        ''' Updates database based on the Query set by the user
        ''' </summary>
        ''' <param name="dbQuery">sql string command</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overridable Function UpdateRowList(ByVal dbQuery As String)

            ' set the query
            sql = dbQuery

            Return updateDatabase(sql)

        End Function

        Public Overridable Function UpdateRowList(ByVal dbTableName As String, ByVal setValues As String, ByVal dbkey As String)

            ' process sql here
            sql = "UPDATE {0} SET {1} WHERE {2}"
            sql = String.Format(sql, dbTableName, setValues, dbkey)

            Return updateDatabase(sql)

        End Function

        Public Overridable Function UpdateRowList(ByVal dbTableName As String, ByVal dbFieldname As ArrayList, ByVal dbValues As ArrayList, ByVal dbkey As String)
            If dbFieldname.Count <> dbValues.Count Then
                Return False
                Exit Function
            End If
            ' process sql here
            sql = "UPDATE {0} SET {1} WHERE {2}"

            Dim setValues As String = Nothing

            For index = 0 To dbValues.Count - 2
                setValues += encloseText(dbFieldname(index), "`") & "=" & encloseText(dbValues(index), """") & ","
            Next
            setValues += encloseText(dbFieldname(dbFieldname.Count - 1), "`") & "=" & encloseText(dbValues(dbValues.Count - 1), """")

            sql = String.Format(sql, dbTableName, setValues, "id=" & encloseText(dbkey, """"))

            'sql = String.Format(sql, dbTableName, String.Join(", ", TryCast(dbFieldname.ToArray(GetType(String)), String())), String.Join(", ", TryCast(dbValues.ToArray(GetType(String)), String())), dbkey)

            Return updateDatabase(sql)

        End Function

        ''' <summary>
        ''' Executes update to the database
        ''' </summary>
        ''' <param name="sql">string parameter</param>
        ''' <returns>affected rows</returns>
        ''' <remarks></remarks>
        Private Function updateDatabase(sql As String)

            Using myConnectionString As New MySqlConnection(mySQLConString)
                dbCommand = New MySqlCommand(sql, myConnectionString)
                Dim affectedRows = 0
                Try
                    dbCommand.Connection.Open()
                    affectedRows = dbCommand.ExecuteNonQuery
                    dbCommand.Connection.Close()
                Catch ex As InvalidOperationException
                    affectedRows = dbCommand.ExecuteNonQuery
                    dbCommand.Connection.Close()
                Catch ex As Exception
                    'MessageBox.Show(ex.Message)
                End Try
                If affectedRows > 0 Then
                    Return True
                Else
                    Return False
                End If
            End Using

        End Function

#End Region

#Region "Database Insert"

        Public Overridable Function InsertRowList(ByVal dbTableName As String, ByVal dbFieldname As ArrayList, ByVal dbValues As ArrayList)

            If dbFieldname.Count > dbValues.Count Then
                Return False
                Exit Function
            End If
            ' process sql here
            sql = "INSERT INTO {0} ({1}) VALUES {2}"

            Dim setFieldNames As String = Nothing
            For index = 0 To dbFieldname.Count - 2
                setFieldNames += encloseText(dbFieldname(index), "`") & ","
            Next
            setFieldNames += encloseText(dbFieldname(dbFieldname.Count - 1), "`")

            Dim setValues As String = Nothing
            Dim fieldValuesArray As New ArrayList

            If dbFieldname.Count = dbValues.Count Then
                sql = "INSERT INTO {0} ({1}) VALUES ({2})"
                ' we got one value to insert
                For index = 0 To dbValues.Count - 1
                    fieldValuesArray.Add(encloseText(dbValues(index), """"))
                Next
                setValues = String.Join(", ", TryCast(fieldValuesArray.ToArray(GetType(String)), String()))
            ElseIf dbFieldname.Count < dbValues.Count Then
                ' we got more to do
                Dim newValuesArray As New ArrayList
                Dim iCount As Integer = 0

                For index = 0 To dbValues.Count - 1
                    fieldValuesArray.Add(encloseText(dbValues(index), """"))
                    iCount += 1
                    If iCount = dbFieldname.Count Then
                        iCount = 0
                        setValues = String.Join(", ", TryCast(fieldValuesArray.ToArray(GetType(String)), String()))
                        newValuesArray.Add(encloseText(setValues, "(", ")"))
                        fieldValuesArray.Clear()
                    End If
                Next
                setValues = String.Join(", ", TryCast(newValuesArray.ToArray(GetType(String)), String()))
            End If

            sql = String.Format(sql, dbTableName, setFieldNames, setValues)

            Return updateDatabase(sql)

        End Function

#End Region

    End Class

End Namespace