Imports System.Drawing.Imaging

Public Class ftmTasks
    Dim memoryImage As Bitmap
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim frmTask As New frmTask
        frmTask.Show()
    End Sub

    Private Sub FtmTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDatas()
        SurroundingSub()
    End Sub
    Private Sub SurroundingSub()
        Dim startTimeSpan = TimeSpan.Zero
        Dim periodTimeSpan = TimeSpan.FromMinutes(1)
        Dim timer = New System.Threading.Timer(Sub(e)
                                                   loadDatasstarted()
                                               End Sub, Nothing, startTimeSpan, periodTimeSpan)
    End Sub
    Protected Sub loadDatas()
        Dim objTask As New clsTasks
        Dim dtTasks As New DataTable
        dtTasks = objTask.GetTasks()
        GrdTasks.DataSource = dtTasks
    End Sub

    Protected Sub loadDatasstarted()
        Dim objTask As New clsTasks
        Dim dtTasks As New DataTable
        dtTasks = objTask.GetTasksStartred()
        If dtTasks.Rows.Count > 0 Then
            CaptureScreen()
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim objTask As New clsTasks
        Dim intTask As Integer
        intTask = GrdTasks.SelectedRows(0).Cells(0).Value
        If objTask.blnDeleteTask(intTask) Then
            MessageBox.Show("Task Deleted")
            loadDatas()
        End If

    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim objTask As New clsTasks
        Dim intTask As Integer
        intTask = GrdTasks.SelectedRows(0).Cells(0).Value
        If objTask.blnStartTask(intTask, True) Then
            MessageBox.Show("Task Started")
            loadDatas()
        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Dim objTask As New clsTasks
        Dim intTask As Integer
        intTask = GrdTasks.SelectedRows(0).Cells(0).Value
        If objTask.blnStartTask(intTask, False) Then
            MessageBox.Show("Task Stoped")
            loadDatas()
        End If
    End Sub

    Private Declare Function GetActiveWindow Lib "user32" Alias "GetActiveWindow" () As IntPtr

    Private Declare Function GetWindowRect Lib "user32" _
                (ByVal hwnd As IntPtr,
                ByRef lpRect As RECT) _
                As Integer

    Private Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Private Sub CaptureScreen()
        Dim r As New RECT
        GetWindowRect(GetActiveWindow, r)
        Dim img As New Bitmap(r.Right - r.Left, r.Bottom - r.Top)
        Dim gr As Graphics = Graphics.FromImage(img)
        gr.CopyFromScreen(New Point(r.Left, r.Top), Point.Empty, img.Size)
        img.Save("C:\Users\HP\Downloads\sample\test" & DateTime.Now.Ticks.ToString & ".png")
        Process.Start("test.png")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        CaptureScreen()
    End Sub
End Class