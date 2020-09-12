Imports MySql.Data.MySqlClient

Public Class clsTasks
    Dim connectionString As String = "Server=localhost; User Id=root; Password=; Database=tareas"

    Public Function blnInsertTask(ByVal strName As String) As Boolean

        Dim strQuery As String = "INSERT INTO Tasks (vchName, bitStarted) values (@vchName, @bitStarted)"
        Try
            Using con = New MySqlConnection(connectionString)
                Using SQLcmd = New MySqlCommand(strQuery, con)
                    con.Open()
                    SQLcmd.Parameters.Add(New MySqlParameter("@vchName", strName))
                    SQLcmd.Parameters.Add(New MySqlParameter("@bitStarted", False))
                    SQLcmd.ExecuteNonQuery()
                End Using

                con.Close()
            End Using
        Catch ex As Exception
            Return False

        End Try

        Return True

    End Function

    Public Function blnStartTask(ByVal intTask As Integer, blnValor As Boolean) As Boolean

        Dim strQuery As String = "UPDATE Tasks SET  bitStarted= @bitStarted WHERE intTask = @intTask"
        Try
            Using con = New MySqlConnection(connectionString)
                Using SQLcmd = New MySqlCommand(strQuery, con)
                    con.Open()
                    SQLcmd.Parameters.Add(New MySqlParameter("@intTask", intTask))
                    SQLcmd.Parameters.Add(New MySqlParameter("@bitStarted", blnValor))
                    SQLcmd.ExecuteNonQuery()
                End Using

                con.Close()
            End Using
        Catch ex As Exception
            Return False

        End Try

        Return True

    End Function



    Public Function blnDeleteTask(ByVal intTask As Integer) As Boolean

        Dim strQuery As String = "DELETE FROM Tasks WHERE intTask = @intTask"
        Try
            Using con = New MySqlConnection(connectionString)
                Using SQLcmd = New MySqlCommand(strQuery, con)
                    con.Open()
                    SQLcmd.Parameters.Add(New MySqlParameter("@intTask", intTask))
                    SQLcmd.ExecuteNonQuery()
                End Using

                con.Close()
            End Using
        Catch ex As Exception
            Return False

        End Try

        Return True

    End Function

    Public Function GetTasks() As DataTable
        Dim dtTasks As New DataTable
        Dim strQuery As String = "SELECT * FROM Tasks"

        Try
            Using con = New MySqlConnection(connectionString)
                Using SQLcmd = New MySqlCommand(strQuery, con)
                    con.Open()
                    SQLcmd.ExecuteNonQuery()
                    Dim da As New MySqlDataAdapter(SQLcmd)
                    da.Fill(dtTasks)
                End Using

                con.Close()
            End Using
        Catch ex As Exception
            Return Nothing

        End Try

        Return dtTasks

    End Function

    Public Function GetTasksStartred() As DataTable
        Dim dtTasks As New DataTable
        Dim strQuery As String = "SELECT * FROM Tasks where bitStarted  = 1"

        Try
            Using con = New MySqlConnection(connectionString)
                Using SQLcmd = New MySqlCommand(strQuery, con)
                    con.Open()
                    SQLcmd.ExecuteNonQuery()
                    Dim da As New MySqlDataAdapter(SQLcmd)
                    da.Fill(dtTasks)
                End Using

                con.Close()
            End Using
        Catch ex As Exception
            Return Nothing

        End Try

        Return dtTasks

    End Function
End Class
