Public Class frmRegister
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim objUser As New clsUsuario
        If objUser.blnInsertUser(txtName.Text, txtPassword.Text, txtUser.Text, txtEmail.Text) Then
            MessageBox.Show("User Add")
        End If
    End Sub
End Class