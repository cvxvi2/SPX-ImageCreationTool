Public Class md5this
    Public md5result As String = Nothing
    Private Sub md5this_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Timer1.Tag = 3 Then 'allow form to settle
            Timer1.Stop()
            Timer1.Tag = 0
            runThrough()
        Else
            Timer1.Tag = Timer1.Tag + 1

        End If
    End Sub

    Private Sub runThrough()
        If checkForfile(Me.Tag) Then
            md5result = md5tool.MD5This(Me.Tag)
            Me.Close()
        Else
            md5result = "Error"
            MsgBox("Requested file doesn't exist or can't be accessed. Please check it exists, is accessible, and try again.")
            Me.Close()
        End If

    End Sub
End Class