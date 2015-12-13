''' <summary>
''' Provides the message box functionality 
''' </summary>
''' <remarks>Mihindu Wijesena 
''' 02/09/2012
''' </remarks>
Public Class classMessages

    Public Sub msgOKInf(ByVal strMessage As String)
        MessageBox.Show(strMessage, STRTITLE, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub msgOKCri(ByVal strMessage As String)
        MessageBox.Show(strMessage, STRTITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop)

    End Sub

    Public Sub msgOKCri(ByVal strMessage As String, ByVal strTitle As String)
        MessageBox.Show(strMessage, strTitle, MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub
End Class
