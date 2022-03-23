Module simplifyFileIO

    Function checkForfile(ByVal filepath As String)
        Try
            If My.Computer.FileSystem.FileExists(filepath) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Debug.WriteLine("[ERROR] [SFIO] [cFF] " & ex.Message.ToString)
            Return False
        End Try

    End Function

    Function checkForDir(ByVal dir As String)

        Try
            If My.Computer.FileSystem.DirectoryExists(dir) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Debug.WriteLine("[ERROR] [SFIO] [cFF] " & ex.Message.ToString)
            Return False
        End Try
    End Function



End Module
