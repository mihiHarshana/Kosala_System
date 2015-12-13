''' <summary>
''' Provides the Ignore rules and Permissions
''' 
''' </summary>
''' <remarks>Mihindu Wijesena  -  05/09/2012
''' </remarks>
Public Class ClassAuthentications
    ''' <summary>
    ''' Loads the permissions for the gate.
    ''' Gets the data from gtpermission table 
    ''' </summary>
    ''' <param name="strGateID"></param>
    ''' <param name="strGATETYPE"></param>
    ''' 
    ''' <remarks></remarks>
    Public Function getPermissions(ByVal strGateID As String, ByVal strGATETYPE As String) As String
        'Call CallConnection()
        'Try
        '    Dim strSQLP As String = "select * from gtpermissions where GateID='" & strGateID & "' and GateType='" & strGATETYPE & "' "
        '    Dim dsP As DataSet

        '    Dim daP As OleDb.OleDbDataAdapter
        '    dsP = New DataSet
        '    daP = New OleDb.OleDbDataAdapter(strSQLP, cn)

        '    daP.Fill(dsP, STR_DBNAME)
        Dim dsPR = DAO.getPermissions(strGateID, strGATETYPE)
        Dim Res As Integer
        Res = dsPR.Tables(STR_DBNAME).Rows.Count - 1
        If Res >= 0 Then
            ReDim ArrayPemi(Res)
            Dim intP As Integer
            For intP = 0 To dsPR.Tables(STR_DBNAME).Rows.Count - 1
                ArrayPemi(intP) = (dsPR.Tables(STR_DBNAME).Rows(intP).Item("CARDTYPE"))
                'MessageBox.Show(ArrayPemi(intP))
            Next
            dsPR = Nothing
            ' daPR = Nothing
            Res = Nothing
            intP = Nothing
            GC.Collect()
            Return "TRUE"
        Else
            'dsP = Nothing
            'daP = Nothing
            Res = Nothing
            ' intP = Nothing
            GC.Collect()
            Return "FALSE"

        End If
        'Catch ex As Exception
        '    MSGB.msgOKCri("Error Code 001- ", "No Contact with server")
        '    LogError.log(ex.Message & "ClassAuthentication - GetPermissions() Error Code 001 ")

        '    End

        'End Try

    End Function
    ''' <summary>
    ''' Loads the data from gtIrnoreRules table
    ''' </summary>
    ''' <param name="strGATEID"></param>
    ''' <param name="strGATETYPE"></param>
    ''' <returns>dsIgR</returns>
    ''' <remarks></remarks>
    Public Function getIgnoreRules(ByVal strGATEID As String, ByVal strGATETYPE As String) As String
        'Call callConnection()

        'Dim strSQLP As String = "select * from gtIgnoreRules where GateID='" & strGATEID & "' and GateType='" & strGATETYPE & "' "
        'Dim dsP As DataSet

        'Dim daP As OleDb.OleDbDataAdapter
        'dsP = New DataSet
        'daP = New OleDb.OleDbDataAdapter(strSQLP, cn)

        'daP.Fill(dsP, STR_DBNAME)
        Dim dsPR = DAO.getIGnoreRules(strGATEID, strGATETYPE)

        Dim Res As Integer
        Res = dsPR.Tables(STR_DBNAME).Rows.Count - 1
        If Res >= 0 Then  '' was 1 and changed to 0 as when with one igrule ddnt work 22/09/2012
            ReDim ArrayIgRules(Res, 1)
            Dim intR As Integer
            Dim intC As Integer = 0
            For intR = 0 To dsPR.Tables(STR_DBNAME).Rows.Count - 1
                For intC = 0 To 1
                    If intC = 0 Then
                        ArrayIgRules(intR, intC) = (dsPR.Tables(STR_DBNAME).Rows(intR).Item("igGateID"))
                    Else
                        ArrayIgRules(intR, intC) = (dsPR.Tables(STR_DBNAME).Rows(intR).Item("igGateType"))
                    End If
                Next

                'MessageBox.Show(ArrayPemi(intP))
            Next
            intR = Nothing
            intC = Nothing
            Res = Nothing

            dsPR = Nothing
            GC.Collect()
            Return "TRUE"
        Else
            ReDim ArrayIgRules(0, 0)
            ArrayIgRules(0, 0) = Nothing
            Res = Nothing
            dsPR = Nothing
            GC.Collect()
            Return "FALSE"
        End If

    End Function

End Class
