Public Class frmLogin
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim objUser As New clsUsuario
        If objUser.blnLogin(txtPassword.Text, txtUser.Text) Then
            Dim frmTask As New ftmTasks
            frmTask.Show()
        Else
            MessageBox.Show("Bad Credentials")
        End If
    End Sub
End Class