''' <summary>
''' Provides the connections to the databases
''' 
''' </summary>
''' <remarks></remarks>
Public Class ClassDBConnection
    ''' <summary>
    ''' Provides the SQL server connecction 
    ''' </summary>
    ''' <returns></returns>
    Public Function getSQLDBConnection(ByVal strLServerName As String, ByVal strLServerUName As String, ByVal strLServerPassword As String, ByVal DBNAME As String)
        'strLServerPassword = encrpt.cryption(strLServerPassword)

        ' Try
        If ConnectionState.Closed Then
            MSGB.msgOKInf("No contact with SQL Server")
            Return False ' no contact with server
        Else
            Dim strCN As String
            strCN = "Provider=SQLOLEDB;Data Source=" & strLServerName & " ;User ID=" & strLServerUName & "; Password=" & strLServerPassword & "; Initial Catalog=" & DBNAME & "; "
            cn = New OleDb.OleDbConnection
            cn.ConnectionString = strCN
            cn.Open()
            Return True ' Connected
        End If
        '  Catch ex As SqlClient.SqlException

        '    MessageBox.Show(ex.Message)
        '    LogError.log(ex.Message & "DBConnectionClass")
        '   Return False
        ' End Try
    End Function

    Public Sub closeDBConnection()
        cn.Close()
    End Sub

    Public Function getAccessDBConnection(ByVal STR_DBNAME As String)
        Dim strdbname1 = STR_DBNAME & ".crs"
        'Dim strcn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strdbname1 & ";Jet OLEDB:Database; "
        Dim strcn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strdbname1 & ";Persist Security Info=False"
        ' MessageBox.Show(strdbname1)
        Try
            cn = New OleDb.OleDbConnection
            cn.ConnectionString = strcn
            cn.Open()
        Catch ex As Exception
            ' dsM.msgOkCritial("Database error ..! Contact your System Administrator")
            MSGB.msgOKCri(ex.Message & " Error is logged")
            LogError.log(ex.Message & "DBconnection Class")
            End
        End Try
        Return False

    End Function
End Class
