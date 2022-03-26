Module md5tool
    Function MD5This(ByVal Filename As String) As String
        Dim fail As String = "NOT VALID"
        Try
            Dim MD5 = System.Security.Cryptography.MD5.Create
            Dim Hash As Byte()
            Dim sb As New System.Text.StringBuilder
            Try
                Using st As New IO.FileStream(Filename, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                    Hash = MD5.ComputeHash(st)
                End Using
                For Each b In Hash
                    sb.Append(b.ToString("X2"))
                Next
                Return sb.ToString
            Catch ex As Exception
                Return fail.ToString
            End Try

        Catch ex As Exception
            Return fail.ToString
        End Try
    End Function

    Function visibleMD5(ByVal filename As String)
        Dim als As New md5this
        als.tag = filename
        als.ShowDialog()
        Return als.md5result.ToString
    End Function
End Module
