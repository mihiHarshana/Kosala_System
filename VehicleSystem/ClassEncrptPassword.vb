Public Class ClassEncrptPassword
    Public Function cryption(ByVal text As String)
        Try
            Dim strtempchar As String = Nothing
            Dim i As Integer
            For i = 1 To Len(text)
                If Asc(Mid$(text, i, 1)) < 128 Then
                    strtempchar = CType(Asc(Mid$(text, i, 1)) + 128, String)
                ElseIf Asc(Mid$(text, i, 1)) > 128 Then
                    strtempchar = CType(Asc(Mid$(text, i, 1)) - 128, String)
                End If
                Mid$(text, i, 1) = Chr(CType(strtempchar, Integer))
            Next i
            Return text
        Catch ex As Exception
            LogError.log(ex.Message & " - Class Encryption")
            MessageBox.Show("System Error, Please contact your Systems administrator", STRTITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End
            Return 0
        End Try
    End Function
End Class
