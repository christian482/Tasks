
Imports MySql.Data.MySqlClient
Imports System.Data.Sql
Imports System
Imports System.Data

Public Class clsUsuario

    Dim connectionString As String = "Server=localhost; User Id=root; Password=; Database=tareas"



    Public Function blnInsertUser(ByVal strName As String, strPassword As String, strUser As String, strEmail As String) As Boolean

        Dim strQuery As String = "INSERT INTO usuarios (vchName, vchPassword, vchUser, vchEmail) values (@vchName, @vchPassword, @vchUser, @vchEmail)"
        Try
            Using con = New MySqlConnection(connectionString)
                Using SQLcmd = New MySqlCommand(strQuery, con)
                    con.Open()
                    SQLcmd.Parameters.Add(New MySqlParameter("@vchName", strName))
                    SQLcmd.Parameters.Add(New MySqlParameter("@vchPassword", strPassword))
                    SQLcmd.Parameters.Add(New MySqlParameter("@vchUser", strUser))
                    SQLcmd.Parameters.Add(New MySqlParameter("@vchEmail", strEmail))
                    SQLcmd.ExecuteNonQuery()
                End Using

                con.Close()
            End Using
        Catch ex As Exception
            Return False

        End Try

        Return True

    End Function

    Public Function blnLogin(strPassword As String, strUser As String) As Boolean
        Dim blnResult As Boolean = False
        Dim strQuery As String = "Select * from usuarios WHERE vchUser = @vchUser and vchPassword= @vchPassword"
        Try
            Using con = New MySqlConnection(connectionString)
                Using SQLcmd = New MySqlCommand(strQuery, con)
                    con.Open()
                    SQLcmd.Parameters.Add(New MySqlParameter("@vchUser", strUser))
                    SQLcmd.Parameters.Add(New MySqlParameter("@vchPassword", strPassword))
                    Dim cant As Integer = CInt(SQLcmd.ExecuteScalar())

                    If cant <> 0 Then
                        blnResult = True
                    End If
                End Using

                con.Close()
            End Using
        Catch ex As Exception
            Return False

        End Try

        Return blnResult

    End Function
End Class
