Module Module1
    Public strDBNAME As String = "INS"
    Public cn As New OleDb.OleDbConnection
    Public MSGB As New classMessages
    Public LogError As New classLogError
    Public DBConnection As New ClassDBConnection
    Public STRTITLE As String = "Vehicle System"
    Public INT_NO_OF_FORMS As Integer = 21
    Public DAO As New classDAOAccessDB
    Public cForm As Integer = 1 '  keep track of the current form

    Public arrayfrm(INT_NO_OF_FORMS) As frmForm1
    Public lastId As String = "" ' keeps track of the entered Id  
    Public remainingCount As Integer = 20

End Module
