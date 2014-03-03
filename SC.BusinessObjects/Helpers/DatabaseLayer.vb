Imports System.Text
Imports System.Collections.ObjectModel

Namespace SC.BusinessObjects

    Public Class DatabaseLayer

#Region "Properties"

        Private _databaseName As String
        Public Property databaseName As String
            Get
                Return _databaseName
            End Get
            Set(value As String)
                _databaseName = value
            End Set
        End Property

        'Private _databaseServer As String
        'Public Property databaseServer As String
        '    Get
        '        Return _databaseServer
        '    End Get
        '    Set(value As String)
        '        _databaseServer = value
        '    End Set
        'End Property

        Private _serverName As String
        Public Property serverName As String
            Get
                Return _serverName
            End Get
            Set(value As String)
                _serverName = value
            End Set
        End Property

        Private _userID As String
        Public Property userID As String
            Get
                Return _userID
            End Get
            Set(value As String)
                _userID = value
            End Set
        End Property

        Private _userPassword As String
        Public Property userPassword As String
            Get
                Return _userPassword
            End Get
            Set(value As String)
                _userPassword = value
            End Set
        End Property

        Private Property jDatabase As New jDatabaseLib.jDatabase
        Private Property jDatabaseLite As jDatabaseLib.jDatabaseLite
        Private Property jDatabaseSQL As jDatabaseLib.jDatabaseSQL

#End Region

#Region "Constructor"

        Public Sub New()

            serverName = My.Settings.server
            userID = My.Settings.userID
            userPassword = My.Settings.password
            databaseName = My.Settings.database

            With jDatabase
                .serverName = Me.serverName
                .userID = Me._userID
                .userPassword = Me.userPassword
                .databaseName = Me.databaseName
                ' call the initialize
                .Initialize()

            End With

            jDatabaseLite = New jDatabaseLib.jDatabaseLite(My.Settings.databaseLite)

        End Sub

#End Region

#Region "   Users"

        Public Function getUserByLoginID(LoginID As String) As user
            ' fetch the data from the database
            Dim dsCollection As DataSet

            'Dim rtn As String = "rtn_getUserByLoginId"
            'Dim params As String = "loginID"
            'Dim paramsValue As String = LoginID

            'dsCollection = jDatabase.getRowDataWithRoutine(rtn, params, paramsValue)
            Dim stbSQL As New StringBuilder
            stbSQL.Append("SELECT * FROM user")

            If Not LoginID Is Nothing Then
                stbSQL.Append(" WHERE loginid LIKE '" & LoginID & "'")
            End If

            dsCollection = jDatabaseLite.LoadRowList(stbSQL.ToString)

            Dim userData As New user
            ' return empty data if no row collected
            If dsCollection.Tables(0).Rows.Count = 0 Then
                Return userData
            End If
            ' transfer the data to local class
            With userData
                .userid = dsCollection.Tables(0).Rows(0).Item("userid")
                .username = dsCollection.Tables(0).Rows(0).Item("username")
                '.emailaddress = dsCollection.Tables(0).Rows(0).Item("emailaddress")
                .loginid = dsCollection.Tables(0).Rows(0).Item("loginid")
                .password = dsCollection.Tables(0).Rows(0).Item("password")
                .saltvalue = dsCollection.Tables(0).Rows(0).Item("saltvalue")
                .block = dsCollection.Tables(0).Rows(0).Item("block")
            End With

            Return userData

        End Function

        Public Function getUserByID(UserID As Integer) As user
            ' fetch the data from the database
            Dim dsCollection As DataSet
            Dim rtn As String = "rtn_getUserById"
            Dim params As String = "userID"
            Dim paramsValue As Integer = UserID

            '*******************************
            ' OLD IMPLEMENTATION
            'Dim stbSQL As New StringBuilder
            'stbSQL.Append("SELECT * FROM users")

            'If UserID > 0 Then
            '    stbSQL.Append(" WHERE userid LIKE '" & UserID & "'")
            'End If
            'dsCollection = jDatabase.LoadRowList(stbSQL.ToString)

            '*******************************

            dsCollection = jDatabaseSQL.getRowDataWithRoutine(rtn, params, paramsValue)

            Dim userData As New user
            ' return empty data if no row collected
            If dsCollection.Tables(0).Rows.Count = 0 Then
                Return userData
            End If
            ' transfer the data to local class
            With userData
                .userid = dsCollection.Tables(0).Rows(0).Item("userid")
                .username = dsCollection.Tables(0).Rows(0).Item("username")
                ' = dsCollection.Tables(0).Rows(0).Item("emailaddress")
                .loginid = dsCollection.Tables(0).Rows(0).Item("loginid")
                .password = dsCollection.Tables(0).Rows(0).Item("password")
                .saltvalue = dsCollection.Tables(0).Rows(0).Item("saltvalue")
                .block = dsCollection.Tables(0).Rows(0).Item("block")
            End With

            Return userData
        End Function

        Public Function getUserRole(LoginID As String) As ICollection(Of user_role)
            ' fetch the data from the database
            Dim dsCollection As DataSet
            Dim stbSQL As New StringBuilder
            stbSQL.Append("SELECT a.userid, b.roleid, c.rolename FROM user as a")
            stbSQL.Append(" LEFT JOIN user_to_role as b ON a.userid = b.userid")
            stbSQL.Append(" LEFT JOIN user_role as c ON b.roleid = c.roleid")

            If Not LoginID Is Nothing Then
                stbSQL.Append(" WHERE a.loginid LIKE '" & LoginID & "'")
            End If
            dsCollection = jDatabaseLite.LoadRowList(stbSQL.ToString)

            Dim userRoles As New List(Of user_role)
            ' return empty data if no row collected
            If dsCollection.Tables(0).Rows.Count = 0 Then
                Return userRoles
            End If
            ' transfer the data to local class
            For index = 0 To dsCollection.Tables(0).Rows.Count - 1
                If IsDBNull(dsCollection.Tables(0).Rows(index).Item("roleid")) Then
                    Return userRoles
                End If

                userRoles.Add(New user_role With { _
                      .roleid = dsCollection.Tables(0).Rows(index).Item("roleid"), _
                      .rolename = dsCollection.Tables(0).Rows(index).Item("rolename") _
                  })
            Next

            Return userRoles

        End Function

        Public Function saveUser(LoginID As String, LoginPassword As String, UserName As String) As Boolean
            Throw New NotImplementedException
        End Function

#End Region

#Region "   Member"

        Function getMembers() As ObservableCollection(Of member_details)
            ' fetch the data from the database
            Dim dsCollection As DataSet

            'Dim rtn As String = "rtn_getMembers"
            'Dim params As String = Nothing
            'Dim paramsValue As String = Nothing

            'dsCollection = jDatabase.getRowDataWithRoutine(rtn, params, paramsValue)

            Dim stbSQL As New StringBuilder
            stbSQL.Append("SELECT * FROM vmembers")
            'stbSQL.Append("SELECT a.*, b.[barangayname], c.[townname], d.[provincename]")
            'stbSQL.Append(" FROM member_detail as a")
            'stbSQL.Append(" INNER JOIN barangay as b ON a.barangayid=b.id")
            'stbSQL.Append(" INNER JOIN town as c ON b.[town_id] =c.id")
            'stbSQL.Append(" INNER JOIN province d ON c.province_id = b.id")

            dsCollection = jDatabaseLite.LoadRowList(stbSQL.ToString)

            Dim memberData As New ObservableCollection(Of member_details)

            ' return empty data if no row collected
            If dsCollection.Tables(0).Rows.Count = 0 Then
                Return memberData
            End If

            Try
                ' transfer the data to local class
                For index = 0 To dsCollection.Tables(0).Rows.Count - 1
                    memberData.Add(New member_details With { _
                            .sc_id = dsCollection.Tables(0).Rows(index).Item("sc_id"), _
                            .firstname = dsCollection.Tables(0).Rows(index).Item("firstname"), _
                            .middlename = dsCollection.Tables(0).Rows(index).Item("middlename"), _
                            .lastname = dsCollection.Tables(0).Rows(index).Item("lastname"), _
                            .dob = dsCollection.Tables(0).Rows(index).Item("dob"), _
                            .gender = dsCollection.Tables(0).Rows(index).Item("gender"), _
                            .civilstatus = dsCollection.Tables(0).Rows(index).Item("civilstatus"), _
                            .address = dsCollection.Tables(0).Rows(index).Item("address"), _
                            .barangayid = dsCollection.Tables(0).Rows(index).Item("barangayid"), _
                            .barangayname = dsCollection.Tables(0).Rows(index).Item("barangayname"), _
                            .townname = dsCollection.Tables(0).Rows(index).Item("townname"), _
                            .provincename = dsCollection.Tables(0).Rows(index).Item("provincename"), _
                            .birthplace = dsCollection.Tables(0).Rows(index).Item("birthplace"), _
                            .occupation = dsCollection.Tables(0).Rows(index).Item("occupation"), _
                            .religion = dsCollection.Tables(0).Rows(index).Item("religion"), _
                            .phone = dsCollection.Tables(0).Rows(index).Item("phone"), _
                            .citizenship = dsCollection.Tables(0).Rows(index).Item("citizenship"), _
                            .education = dsCollection.Tables(0).Rows(index).Item("education"), _
                            .skills = dsCollection.Tables(0).Rows(index).Item("skills"), _
                            .image = dsCollection.Tables(0).Rows(index).Item("image"), _
                            .sign = dsCollection.Tables(0).Rows(index).Item("sign"), _
                            .status = dsCollection.Tables(0).Rows(index).Item("status"), _
                            .created = dsCollection.Tables(0).Rows(index).Item("created"), _
                            .created_by = dsCollection.Tables(0).Rows(index).Item("created_by"), _
                            .modified = dsCollection.Tables(0).Rows(index).Item("modified"), _
                            .modified_by = dsCollection.Tables(0).Rows(index).Item("modified_by") _
                      })
                Next
            Catch ex As Exception
                Throw New Exception(ex.Message)
                Return memberData
            End Try

            Return memberData

        End Function

        Function getMemberByID(memberID As String) As member_detail
            ' fetch the data from the database
            Dim dsCollection As DataSet

            Dim rtn As String = "rtn_getMemberById"
            Dim params As String = "memberID"
            Dim paramsValue As String = memberID

            dsCollection = jDatabaseSQL.getRowDataWithRoutine(rtn, params, paramsValue)

            Dim memberData As New member_detail
            ' return empty data if no row collected
            If dsCollection.Tables(0).Rows.Count = 0 Then
                Return memberData
            End If

            'For Each prop In memberData.GetType().GetProperties()
            '    prop = dsCollection.Tables(0).Rows(0).Item(prop.Name)
            'Next

            ' transfer the data to local class
            With memberData

                '.id = dsCollection.Tables(0).Rows(0).Item("id")
                .sc_id = dsCollection.Tables(0).Rows(0).Item("sc_id")
                .firstname = dsCollection.Tables(0).Rows(0).Item("firstname")
                .middlename = dsCollection.Tables(0).Rows(0).Item("middlename")
                .lastname = dsCollection.Tables(0).Rows(0).Item("lastname")
                .dob = dsCollection.Tables(0).Rows(0).Item("dob")
                .gender = dsCollection.Tables(0).Rows(0).Item("gender")
                .address = dsCollection.Tables(0).Rows(0).Item("address")
                .barangayid = dsCollection.Tables(0).Rows(0).Item("barangayid")
                .status = dsCollection.Tables(0).Rows(0).Item("status")
                .created = dsCollection.Tables(0).Rows(0).Item("created")
                .created_by = dsCollection.Tables(0).Rows(0).Item("created_by")
                .modified = dsCollection.Tables(0).Rows(0).Item("modified")
                .modified_by = dsCollection.Tables(0).Rows(0).Item("modified_by")

            End With

            Return memberData

        End Function

        Function getFamilyMember(memberID As String) As ObservableCollection(Of family_record)
            Throw New NotImplementedException
        End Function

        Function insertFamilyMember(familyRecordCollection As ObservableCollection(Of family_record)) As Boolean
            Throw New NotImplementedException
        End Function

        Function insertMember(memberDetails As member_detail) As Boolean
            Try
                ' step 01: 'prepare the data
                Dim dbTableName As String = "member_detail"
                Dim dbFieldname As New ArrayList
                Dim dbValues As New ArrayList
                ' lets enumerate fieldname
                With dbFieldname
                    .Add("sc_id")
                    .Add("firstname")
                    .Add("middlename")
                    .Add("lastname")
                    .Add("dob")
                    .Add("gender")
                    .Add("civilstatus")
                    .Add("address")
                    .Add("barangayid")
                    .Add("status")
                    .Add("created")
                    .Add("created_by")
                    .Add("modified")
                    .Add("modified_by")
                End With
                ' lets pass the values from member details
                With dbValues
                    .Add(memberDetails.sc_id)
                    .Add(memberDetails.firstname)
                    .Add(memberDetails.middlename)
                    .Add(memberDetails.lastname)
                    .Add(jDatabase.MySQLDate(memberDetails.dob))
                    .Add(memberDetails.gender)
                    .Add(memberDetails.civilstatus)
                    .Add(memberDetails.address)
                    .Add(memberDetails.barangayid)
                    .Add(memberDetails.status)
                    .Add(jDatabase.MySQLDate(memberDetails.created))
                    .Add(memberDetails.created_by)
                    .Add(jDatabase.MySQLDate(memberDetails.modified))
                    .Add(memberDetails.modified_by)
                End With

                Return jDatabaseLite.InsertRowList(dbTableName, dbFieldname, dbValues)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Function insertMemberInfo(memberInfo As member_information) As Boolean
            Try
                ' step 01: 'prepare the data
                Dim dbTableName As String = "member_information"
                Dim dbFieldname As New ArrayList
                Dim dbValues As New ArrayList
                ' lets enumerate fieldname
                With dbFieldname
                    .Add("members_sc_id")
                    .Add("birthplace")
                    .Add("occupation")
                    .Add("religion")
                    .Add("phone")
                    .Add("citizenship")
                    .Add("education")
                    .Add("skills")
                    .Add("image")
                    .Add("sign")
                    .Add("created")
                    .Add("created_by")
                    .Add("modified")
                    .Add("modified_by")
                End With
                ' lets pass the values from member information
                With dbValues
                    .Add(memberInfo.members_sc_id)
                    .Add(memberInfo.birthplace)
                    .Add(memberInfo.occupation)
                    .Add(memberInfo.religion)
                    .Add(memberInfo.phone)
                    .Add(memberInfo.citizenship)
                    .Add(memberInfo.education)
                    .Add(memberInfo.skills)
                    .Add(memberInfo.image)
                    .Add(memberInfo.sign)
                    .Add(memberInfo.created)
                    .Add(memberInfo.created_by)
                    .Add(memberInfo.modified)
                    .Add(memberInfo.modified_by)
                End With

                Return jDatabaseLite.InsertRowList(dbTableName, dbFieldname, dbValues)
            Catch ex As Exception
                Return False
            End Try

        End Function


        Function updateMember(memberDetail As member_detail) As Integer
            Throw New NotImplementedException
        End Function

        Function getAddress(barangayid As Integer) As member_address
            ' fetch the data from the database
            Dim dsCollection As DataSet

            Dim rtn As String = "rtn_getAddress"
            Dim params As String = "brgyID"
            Dim paramsValue As String = barangayid

            dsCollection = jDatabaseSQL.getRowDataWithRoutine(rtn, params, paramsValue)

            Dim addressData As New member_address
            ' return empty data if no row collected
            If dsCollection.Tables(0).Rows.Count = 0 Then
                Return addressData
            End If
            ' transfer the data to local class
            With addressData

                .barangayname = dsCollection.Tables(0).Rows(0).Item("barangayname")
                .townname = dsCollection.Tables(0).Rows(0).Item("townname")
                .provincename = dsCollection.Tables(0).Rows(0).Item("provincename")

            End With

            Return addressData

        End Function

        Function getProvinceList() As List(Of province)
            ' step 01: get the data from the database 
            Dim dsProvinceCollection As DataSet
            Dim sql As String = "SELECT * FROM province WHERE state=1"
            dsProvinceCollection = jDatabaseLite.LoadRowList(sql)

            Dim provinceList As New List(Of province)
            If dsProvinceCollection.Tables(0).Rows.Count = 0 Then
                Return provinceList
            End If

            Try
                For index = 0 To dsProvinceCollection.Tables(0).Rows.Count - 1
                    provinceList.Add(New province With { _
                                       .id = dsProvinceCollection.Tables(0).Rows(index).Item("id"), _
                                       .provincename = StrConv(dsProvinceCollection.Tables(0).Rows(index).Item("provincename"), vbProperCase) _
                                   })
                Next
            Catch ex As Exception

            End Try

            Return provinceList

        End Function

        Function getTownList(iProvinceID As Integer) As List(Of town)
            ' step 01: get the data from the database 
            Dim dsTownList As DataSet
            Dim sql As String = "SELECT * FROM town WHERE province_id=" & iProvinceID & " and state=1"
            dsTownList = jDatabaseLite.LoadRowList(sql)

            ' step 02: transfer the data to the List
            Dim townList As New List(Of town)
            If dsTownList.Tables(0).Rows.Count = 0 Then
                Return townList
            End If

            Try
                For index = 0 To dsTownList.Tables(0).Rows.Count - 1
                    townList.Add(New town With { _
                            .id = dsTownList.Tables(0).Rows(index).Item("id"), _
                            .townname = StrConv(dsTownList.Tables(0).Rows(index).Item("townname"), vbProperCase) _
                                            })
                Next
            Catch ex As Exception

            End Try

            Return townList

        End Function

        Function getBarangayList(iTownID As Integer) As List(Of barangay)
            ' step 01: get the data from the database 
            Dim dsBarangayList As DataSet
            Dim sql As String = "SELECT * FROM barangay WHERE town_id=" & iTownID & " and  state=1"
            dsBarangayList = jDatabaseLite.LoadRowList(sql)

            ' step 02: transfer the data to the List
            Dim barangayList As New List(Of barangay)

            If dsBarangayList.Tables(0).Rows.Count = 0 Then
                Return barangayList
            End If

            Try
                For index = 0 To dsBarangayList.Tables(0).Rows.Count - 1
                    barangayList.Add(New barangay With { _
                                            .id = dsBarangayList.Tables(0).Rows(index).Item("id"), _
                                            .barangayname = StrConv(dsBarangayList.Tables(0).Rows(index).Item("barangayname"), vbProperCase) _
                                        })
                Next
            Catch ex As Exception

            End Try

            Return barangayList

        End Function

#End Region

    End Class

End Namespace