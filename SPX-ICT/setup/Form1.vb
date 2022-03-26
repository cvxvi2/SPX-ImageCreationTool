Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = globs.AppNM & " " & globs.AppVR
        Me.Text = Label1.Text
        Me.MaximizeBox = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim als As MsgBoxResult
        als = MsgBox("Are you sure you want to quit? All unsaved changes will be lost.", vbYesNoCancel, "Quit SPX-ICT?")
        If als = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Advanced_Mode.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Setup1.Show()
        Me.Close()
    End Sub
End Class
