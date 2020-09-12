Public Class Form1
    Private Sub BtnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        Dim frmRegister As New frmRegister
        frmRegister.Show()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim frmLogin As New frmLogin
        frmLogin.Show()
    End Sub
End Class
