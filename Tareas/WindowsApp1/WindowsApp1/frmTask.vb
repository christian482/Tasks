Public Class frmTask
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim objTask As New clsTasks
        If objTask.blnInsertTask(txtTask.Text) Then
            MessageBox.Show("Task Added")
        End If
    End Sub
End Class