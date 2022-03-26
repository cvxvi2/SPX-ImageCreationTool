﻿Public Class Advanced_Mode

    Function ofdReturn(ByVal filter As String, ByVal title As String)
        OpenFileDialog1.FileName = Nothing
        OpenFileDialog1.Filter = filter
        OpenFileDialog1.Title = title
        OpenFileDialog1.ShowDialog()
        If simplifyFileIO.checkForfile(OpenFileDialog1.FileName) = True Then
            Return OpenFileDialog1.FileName
        Else
            Return Nothing.ToString
        End If


    End Function


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim als As MsgBoxResult
        als = MsgBox("Are you sure you want to quit? All unsaved changes will be lost.", vbYesNoCancel, "Quit SPX-ICT?")
        If als = vbYes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub Advanced_Mode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load defaults
        loadDefaults()


    End Sub

    Sub loadDefaults()
        RadioButton1.Checked = True
        RadioButton4.Checked = True
        'If the form is being reloaded, clear combobox items to prevent them duplicating.
        For Each itm In ComboBox1.Items
            ComboBox1.Items.Remove(itm)
        Next
        For i = 0 To 15
            ComboBox1.Items.Add(i.ToString)
        Next
        If powerShellLocation = "" Then
            RadioButton6.Enabled = False
        End If
        If sevenzipLocation = "" Then
            RadioButton7.Enabled = False
        End If
    End Sub

    Sub extractSwitchBox(ByVal app As String)
        Select Case app
            Case "default"
                globs.useBuiltInZIPExtractor = True
                globs.use7ZipToExtractZip = False
                globs.usePowerShellToExtractZIP = False
            Case "7zip"
                globs.useBuiltInZIPExtractor = False
                globs.use7ZipToExtractZip = True
                globs.usePowerShellToExtractZIP = False
            Case "powershell"
                globs.useBuiltInZIPExtractor = False
                globs.use7ZipToExtractZip = False
                globs.usePowerShellToExtractZIP = True
            Case Else
                extractSwitchBox("default")
        End Select
    End Sub


    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            GroupBox1.Visible = True : GroupBox1.Enabled = True
            GroupBox2.Visible = False : GroupBox2.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            GroupBox1.Visible = False : GroupBox1.Enabled = False
            GroupBox2.Visible = True : GroupBox2.Enabled = True
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            GroupBox4.Visible = True : GroupBox4.Enabled = True
            GroupBox3.Visible = False : GroupBox3.Enabled = False
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            GroupBox4.Visible = False : GroupBox4.Enabled = False
            GroupBox3.Visible = True : GroupBox3.Enabled = True
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        TextBox4.Text = ofdReturn("ISO Files|*.iso", "Select Installation ISO File")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        TextBox3.Text = ofdReturn("boot.wim files|*.wim", "Select Boot.wim")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        TextBox5.Text = ofdReturn("Install.wim Files|*.wim", "Select Install.wim")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox1.Text = ofdReturn("BMR ZIP Files|*.zip", "Select BMR Image")
        If TextBox1.Text = Nothing Then
        Else
            Dim ab = MsgBox("Do you want to validate this file to check its integrity?" & Environment.NewLine & "This may take a moment.", vbYesNoCancel, "Validate MD5 Hash?")
            If ab = vbYes Then
                Dim rs = visibleMD5(TextBox1.Text) : Dim validatedImage As Boolean = False
                For i = 0 To knownHashes.length - 1
                    If rs = knownHashes(i).ToString Then
                        validationstatus.Text = "Valid BMR image detected: " & Environment.NewLine & "Original File Name: " & knownFiles(i).ToString & Environment.NewLine & "MD5 Hash: " & knownHashes(i)
                        validatedImage = True
                    End If
                Next
                If validatedImage = False Then
                    validationstatus.Text = "Image not recognised as original BMR." & Environment.NewLine & "Returned MD5 Hash: " & rs.ToString
                End If

            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox2.Text = ofdReturn("ZIP Files|*.zip", "Select Installation Image")
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton7.CheckedChanged
        extractSwitchBox("7zip")
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        extractSwitchBox("default")
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        extractSwitchBox("powershell")
    End Sub
End Class