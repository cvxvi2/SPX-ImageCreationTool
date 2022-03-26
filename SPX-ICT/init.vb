Public Class init
    Public useDebugLogging As Boolean = False

    Private Sub log(ByVal txt As String)
        If useDebugLogging = True Then
            TextBox1.AppendText(Environment.NewLine & txt)
        End If
    End Sub
    Private Sub init_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Debugger.IsAttached = True Then
            useDebugLogging = True
            TextBox1.Visible = True
            log("Debug logging enabled")
        End If
        log("Starting settler...")
        Label2.Text = Label2.Text & Environment.NewLine & globs.AppVR
        Settler.Start()
    End Sub

    Private Sub Settler_Tick(sender As Object, e As EventArgs) Handles Settler.Tick
        'This allows the form to show and settle before we do things.
        log("Settler Tick...")
        If Settler.Tag = 3 Then
            log("Settler Tock")
            Settler.Stop()
            Settler.Tag = 0
            startup()
        Else
            Settler.Tag = Settler.Tag + 1
        End If
    End Sub



    Sub startup()
        checkDependancies()
        Form1.Show()
        Me.Close()
    End Sub


    Sub checkDependancies()
        Dim appnms = {"Command Prompt", "DISM", "7-Zip", "PowerShell"}
        Dim apppts = {"c:\windows\system32\cmd.exe", "C:\windows\system32\dism.exe", "C:\Program Files\7-Zip\7z.exe", "C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe"}
        Dim appresult As Boolean = False
        For i = 0 To appnms.Length - 1
            log("Checking for dependancy: " & appnms(i).ToString)

            If checkForfile(apppts(i).ToString) = True Then
                appresult = True
            Else
                appresult = False
            End If
            Select Case appresult
                Case True
                    Select Case appnms(i).ToString
                        Case "Command Prompt"
                            cmdLocation = apppts(i).ToString
                        Case "DISM"
                            dismLocation = apppts(i).ToString
                        Case "7-Zip"
                            sevenzipLocation = apppts(i).ToString
                        Case "PowerShell"
                            powerShellLocation = apppts(i).ToString
                    End Select
                Case Else

            End Select
        Next
        log("Checking filesystem...")
        Dim bdirlo = {basepath, basepath & "\mount", basepath & "\exporteddrivers"}
        For i = 0 To bdirlo.Length - 1
            log("Checking " & bdirlo(i).ToString)
            If checkForDir(bdirlo(i).ToString) = True Then
                'do nothing, exists
            Else
                If createDir(bdirlo(i)) = True Then
                    'success, dir made.
                Else
                    'fail, implement crashout
                    MsgBox("Warning, one or more working directories could not be created.", 0 + 48)
                End If
            End If
        Next


    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class