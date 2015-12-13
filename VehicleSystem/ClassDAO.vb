''' <summary>
''' This is the class to access the Database
''' Provides the methos
''' </summary>
''' <remarks>Mihindu Wijesnena 02/09/2012 </remarks>
Public Class ClassDAO


    ''' <summary>
    ''' 16/09/2012 Mihindu Wijesena
    ''' Gets the carddetais from CardDetaisl table and returns a dataset
    ''' </summary>
    ''' <param name="strCardID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCardDetails(ByVal strCardID As String) As DataSet
        Call callConnection()
        Dim strSQLCD As String = "Select * from cardDetails where cardId ='" & strCardID & "'"
        Dim dsCD As New DataSet
        Dim daCD As New OleDb.OleDbDataAdapter(strSQLCD, cn)
        daCD.Fill(dsCD, STR_DBNAME)


        strSQLCD = Nothing
        dsCD = Nothing
        daCD = Nothing
        GC.Collect()
        Return dsCD







    End Function

    Public Function getCardDetailsbySNo(ByVal strCARDSNO As String) As DataSet
        Call callConnection()
        Dim strSQLSNO As String = "Select * from cardDetails where cardSNo='" & strCARDSNO & "'"
        Dim dsSNO As New DataSet
        Dim daSNo As New OleDb.OleDbDataAdapter(strSQLSNO, cn)
        daSNo.Fill(dsSNO, STR_DBNAME)


        strSQLSNO = Nothing
        daSNo = Nothing
        GC.Collect()


        Return dsSNO


    End Function

    ''' <summary>
    ''' 15/09/2012 Mihindu Wijesena
    ''' Add transaction details of card to the trans table.
    ''' </summary>
    ''' <param name="intCF"></param>
    ''' <param name="strMessage"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function addCardDetails(ByVal intCF As Integer, ByVal strMessage As String)
        Try
            If strMessage = strNOPERMISSION Or strMessage = strINVALIDCARD Then
            Else

                Call callConnection()

                Dim strSQLA As String = "Select * from trans"
                Dim dsA As DataSet
                Dim daA As OleDb.OleDbDataAdapter
                dsA = New DataSet
                daA = New OleDb.OleDbDataAdapter(strSQLA, cn)
                daA.Fill(dsA, STR_DBNAME)

                Dim cbA As New OleDb.OleDbCommandBuilder(daA)
                Dim dsnrA As DataRow
                dsnrA = dsA.Tables(STR_DBNAME).NewRow
                With dsnrA
                    .Item("trID") = getTransRowCount(arrayfrm(intCF).txtCardID.Text, STRGATEID) & "_" & arrayfrm(intCF).txtCardID.Text _
               & "_" & arrayfrm(intCF).lblCardType.Text & "_" & STRGATEID & "_" & STRGATETYPE

                    .Item("TrTime") = Now
                    .Item("cardId") = arrayfrm(intCF).txtCardID.Text
                    .Item("cardSNo") = arrayfrm(intCF).txtSNo.Text
                    .Item("CardType") = arrayfrm(intCF).lblCardType.Text
                    .Item("trGateID") = STRGATEID ' this should be logged in GATE
                    '.Item("trType") = STRGATETYPE ' This should be logged in Gate Type
                    If strMessage = strNOVALIDIN Then '"NO VALID IN"  Then

                        .Item("trType") = "OUT"
                    Else
                        .Item("trType") = strMessage ' This should be logged in Gate Type

                    End If

                    '  MessageBox.Show(getTransRowCount(arrayfrm(intCF).lblCardType.Text, STRGATEID))

                    If STRGATETYPE = "IN" And strMessage = strINVALIDIN Or strMessage = strNOVALIDIN Then
                        .Item("trin") = False
                    ElseIf STRGATETYPE = "IN" And strMessage = STROK Then
                        .Item("trIN") = True


                    ElseIf STRGATETYPE = "OUT" Then
                        .Item("trIN") = False
                    Else
                        .Item("trin") = False

                    End If

                    dsA.Tables(STR_DBNAME).Rows.Add(dsnrA)
                    daA.Update(dsA, STR_DBNAME)

                    strSQLA = Nothing
                    dsA = Nothing
                    daA = Nothing
                    dsnrA = Nothing
                    cbA = Nothing
                    GC.Collect()
                    ' MessageBox.Show("Row added to the database")
                    Return True
                End With
            End If

            Return False
        Catch ex As Exception
            MSGB.msgOKCri("Serious Error. Please contact your systems administrator. Error Code 001")
            LogError.log(ex.Message & "ClassDAO ,addCardDetails()")
            End
            Return False

        End Try

    End Function

    ''' <summary>
    ''' 08/09/2012 Mihindu Wijesena
    ''' Get the current row count of the table trans and returns a count of the rows
    ''' </summary>
    ''' <param name="strCARDID"></param>
    ''' <param name="strGateID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getTransRowCount(ByVal strCARDID As String, ByVal strGateID As String) As String

        Call callConnection()
        Dim strSQLC As String = "Select count(trID) as cTr from trans"
        Dim dsC As DataSet
        Dim daC As OleDb.OleDbDataAdapter
        dsC = New DataSet
        daC = New OleDb.OleDbDataAdapter(strSQLC, cn)
        daC.Fill(dsC, STR_DBNAME)

        strSQLC = Nothing
        GC.Collect()

        Return dsC.Tables(STR_DBNAME).Rows(0).Item("cTr") ' & "_" & strCARDID & "_" & strGateID
    End Function
    ''' <summary>
    ''' 08/09/2012 Mihindu Wijesena
    ''' Gets the last in Time for the perticular cardId and returns the date time from the table
    ''' </summary>
    ''' <param name="strCARDID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetLastInTime(ByVal strCARDID) As String
        Call callConnection()

        'Dim strSQLLIN As String = "Select * from trans where cardId='" & strCARDID & "' and  trType='IN' and trIN='" & True & "' order by TrTime DESC"
        Dim strSQLLIN As String = "Select trTime,trGateID from trans where cardId='" & strCARDID & "' and  trType='IN'   order by TrTime DESC"
        Dim dsLIN As New DataSet
        Dim daLIN As New OleDb.OleDbDataAdapter(strSQLLIN, cn)
        daLIN.Fill(dsLIN, STR_DBNAME)
        '    Dim dtR As String
        Dim dtRDate As DateTime
        If dsLIN.Tables(STR_DBNAME).Rows.Count - 1 >= 0 Then
            'dtR = dsLIN.Tables(STR_DBNAME).Rows(0).Item("trTime").ToString& "-" & dsLIN.Tables(STR_DBNAME).Rows(0).Item("trGateID")
            dtRDate = dsLIN.Tables(STR_DBNAME).Rows(0).Item("Trtime")

            'dtR = dtRDate.Month & "/" & dtRDate.Day & " " & dtRDate.Hour.ToString & ":" & dtRDate.Minute.ToSt & ":" & dtRDate.Second.ToString & " - " & dsLIN.Tables(STR_DBNAME).Rows(0).Item("trGateID")
            Return dtRDate.Day & "/" & dtRDate.Month & " " & dtRDate.ToLongTimeString() & " - " & dsLIN.Tables(STR_DBNAME).Rows(0).Item("trGateID")
        Else
            Return Nothing

        End If

        strSQLLIN = Nothing
        daLIN = Nothing
        dsLIN = Nothing
        '  dtR1 = Nothing

        GC.Collect()

        ' Return dtR
    End Function

    ''' <summary>
    ''' 08/09/2012 Mihindu Wijesena
    ''' Get the last out time of the perticular card Id from the table trans and returns time 
    ''' </summary>
    ''' <param name="strCARDID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getLastOutTime(ByVal strCARDID) As String

        Call callConnection()
        '   Dim strSQLLOUT As String = "Select * from trans where cardID='" & strCARDID & "' and trType='OUT' and trIN='" & False & "' order by TRTime DESC"
        Dim strSQLLOUT As String = "Select * from trans where cardID='" & strCARDID & "' and trType='OUT'  order by TRTime DESC"
        Dim dsLOUT As New DataSet
        Dim daLOUT As New OleDb.OleDbDataAdapter(strSQLLOUT, cn)
        daLOUT.Fill(dsLOUT, STR_DBNAME)
        ' Dim dtR As String
        Dim dtrDAte As DateTime
        ' Dim dtr1 As DateTime
        If dsLOUT.Tables(STR_DBNAME).Rows.Count - 1 >= 0 Then

            dtrDAte = dsLOUT.Tables(STR_DBNAME).Rows(0).Item("Trtime")
            Return dtrDAte.Day & "/" & dtrDAte.Month & " " & dtrDAte.ToLongTimeString() & " - " & dsLOUT.Tables(STR_DBNAME).Rows(0).Item("trGateID")
            'dtR = dtrDAte.Month & "/" & dtrDAte.Day & " " & dtrDAte.Hour & ":" & dtrDAte.Minute & ":" & dtrDAte.Second & " - " & dsLOUT.Tables(STR_DBNAME).Rows(0).Item("trGateID")
            ' dtR = dsLOUT.Tables(STR_DBNAME).Rows(0).Item("trTime")
            ' dtR = dtr1.ToShortTimeString
        Else
            'dtrDAte = Nothing
            Return Nothing
        End If

        strSQLLOUT = Nothing
        dsLOUT = Nothing
        daLOUT = Nothing
        '  dtr1 = Nothing
        GC.Collect()
        Return dtrDAte
        'Return dtR
    End Function

    'Public Function getLastOutTime(ByVal strCARDID) As DateTime

    '    Call callConnection()
    '    '   Dim strSQLLOUT As String = "Select * from trans where cardID='" & strCARDID & "' and trType='OUT' and trIN='" & False & "' order by TRTime DESC"
    '    Dim strSQLLOUT As String = "Select * from trans where cardID='" & strCARDID & "' and trType='OUT'  order by TRTime DESC"
    '    Dim dsLOUT As New DataSet
    '    Dim daLOUT As New OleDb.OleDbDataAdapter(strSQLLOUT, cn)
    '    daLOUT.Fill(dsLOUT, STR_DBNAME)
    '    Dim dtR As DateTime
    '    ' Dim dtr1 As DateTime
    '    If dsLOUT.Tables(STR_DBNAME).Rows.Count - 1 >= 0 Then
    '        dtR = dsLOUT.Tables(STR_DBNAME).Rows(0).Item("trTime")
    '        ' dtR = dtr1.ToShortTimeString

    '    End If

    '    strSQLLOUT = Nothing
    '    dsLOUT = Nothing
    '    daLOUT = Nothing
    '    '  dtr1 = Nothing
    '    GC.Collect()

    '    Return dtR
    'End Function
    ''' <summary>
    ''' 08/09/2012 Mihindu Wijesena
    ''' set the card details retrieving data from the perticulart card, from the DB
    ''' </summary>
    ''' <param name="strCardID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCardAllDetails(ByVal strCardID As String) As String

        Try
            Call callConnection()
            Dim strSQLAl As String = "Select * from CardDetails where cardID ='" & strCardID & "'  and cardstatus= '" & True & "'"

            Dim dsAl As New DataSet
            Dim daAl As New OleDb.OleDbDataAdapter(strSQLAl, cn)

            daAl.Fill(dsAl, STR_DBNAME)
            If dsAl.Tables(STR_DBNAME).Rows.Count - 1 = 0 Then

                ' MessageBox.Show("card is available")
                With dsAl.Tables(STR_DBNAME)
                    cid_s.strCardId = .Rows(0).Item("cardId")
                    cid_s.strCardSNO = .Rows(0).Item("cardSNo")
                    cid_s.strCardType = .Rows(0).Item("cardType")
                    cid_s.blnCardStatus = .Rows(0).Item("cardStatus")
                    'If IsDBNull(.Rows(0).Item("cardOwner")) = False Then
                    '    cid_s.strcardName = .Rows(0).Item("cardOwner")
                    'End If
                    strSQLAl = Nothing
                    dsAl = Nothing
                    daAl = Nothing
                    GC.Collect()
                    Return "CARDAVAILABLE"
                End With
            Else
                strSQLAl = Nothing
                dsAl = Nothing
                daAl = Nothing
                GC.Collect()

                Return strINVALIDCARD '"INVALIDCARD"
                ' MessageBox.Show("card is NOT available")
            End If
            'Catch ex As SqlClient.SqlException
            '    MSGB.msgOKCri("SERIOUS ERROR" & ex.ErrorCode)
            '    LogError.log(ex.Message & "Code" & ex.ErrorCode & "classDAO_getCardAllDetails")
        Catch ex As Exception
            MSGB.msgOKCri("SERIOUS ERROR")
            LogError.log(ex.Message & "Code" & "classDAO_getCardAllDetails")
            Return ""
        End Try
    End Function

    Public Function checkTrans_LastINhasOut(ByVal strCardID As String) As Boolean
        Call callConnection()
        ' MessageBox.Show(Now.Date)
        Dim strSQLCT As String = "Select * from trans where cardID= '" & strCardID & "' and trIN='" & True & "' and trTime >= '" & Now.Date & "' order by TrTime DESC "
        Dim dsCT As New DataSet
        Dim daCT As New OleDb.OleDbDataAdapter(strSQLCT, cn)
        daCT.Fill(dsCT, STR_DBNAME)

        'If (dsCT.Tables(STR_DBNAME).Rows(0).Item("TRTime")) <= Now.Date Then
        '    MessageBox.Show("TRTIME <= now")
        'Else
        '    MessageBox.Show(dsCT.Tables(STR_DBNAME).Rows(0).Item("TRTime") & " " & Now.Date)

        'End If
        'MessageBox.Show(dsCT.Tables(STR_DBNAME).Rows.Count)
        'MessageBox.Show(dsCT.Tables(STR_DBNAME).Rows(0).Item("TRTime"))
        If dsCT.Tables(STR_DBNAME).Rows.Count - 1 >= 0 Then
            ctd.strTransGATEID = dsCT.Tables(STR_DBNAME).Rows(0).Item("trGATEID")
            ctd.strTransGateType = dsCT.Tables(STR_DBNAME).Rows(0).Item("trTYPE")
            strSQLCT = Nothing
            dsCT = Nothing
            daCT = Nothing
            GC.Collect()
            Return True
        Else
            strSQLCT = Nothing
            dsCT = Nothing
            daCT = Nothing
            GC.Collect()
            Return False

        End If
    End Function

    Public Function checkTrans_hasOut(ByVal strCARDID As String) As DataSet
        Call callConnection()

        Dim strSQLTO As String = "Select * from trans where cardId= '" & strCARDID & "' and trIN = '" & True & "' "
        Dim dsTO As New DataSet
        Dim daTO As New OleDb.OleDbDataAdapter(strSQLTO, cn)
        daTO.Fill(dsTO, STR_DBNAME)

        strSQLTO = Nothing
        daTO = Nothing
        GC.Collect()

        Return dsTO
    End Function

    ''' <summary>
    ''' Get the card Id and check for the lastIN, and update TRIN as false 
    ''' </summary>
    ''' <param name="strCardID"></param>
    ''' <returns>True or False</returns>
    ''' <remarks>Mihindu Wijesena 08/09/2012</remarks>
    Public Function edit_TransData(ByVal strCardID As String) As Boolean

        Call callConnection()
        Dim strSQLU As String = "Select * from trans where cardID='" & strCardID & "' and TrIN = '" & True & "'"
        Dim dsU As New DataSet
        Dim daU As New OleDb.OleDbDataAdapter(strSQLU, cn)
        Dim cbU As New OleDb.OleDbCommandBuilder(daU)
        daU.Fill(dsU, STR_DBNAME)
        Dim intU As Integer
        With dsU.Tables(STR_DBNAME)
            For intU = 0 To .Rows.Count - 1
                .Rows(intU).Item("trIN") = False
            Next
            daU.Update(dsU, STR_DBNAME)
            strSQLU = Nothing
            daU = Nothing
            dsU = Nothing
            cbU = Nothing
            GC.Collect()
            Return True
        End With
    End Function
    ' // 12/10/2012 Changes from strCArdId to strGateId as requested by Sanjeewa S. Due to the fact the need to know the history of the gate

    Public Function getDataGrid1Data(ByVal strGATEID As String) As DataSet

        Dim intTOP As Integer = arrayDATAPropFile(6, 1)
        Call callConnection()
        ' Dim strSQLGD As String = " Select TOP " & intTOP & " * from trans where cardId = '" & strCardID & "' order by TRID DESC"
        Dim strSQLGD As String = " Select TOP " & intTOP & " * from trans where trGAteId = '" & strGATEID & "' order by TRTime DESC"
        Dim dsGD As New DataSet
        Dim daGD As New OleDb.OleDbDataAdapter(strSQLGD, cn)
        daGD.Fill(dsGD, STR_DBNAME)
        strSQLGD = Nothing
        daGD = Nothing
        GC.Collect()

        Return dsGD
    End Function


    ' '' Overloads the getDataGridData method. If needed to get the only the specific card ID's details per gate
    'Public Function getDataGrid1Data(ByVal intCArdID As String) As DataSet

    '    Dim intTOP As Integer = arrayDATAPropFile(6, 1)

    '    Call callConnection()
    '    Dim strSQLGD As String = " Select TOP " & intTOP & " * from trans where cardId = '" & intCArdID & "' order by TRID DESC"

    '    Dim dsGD As New DataSet
    '    Dim daGD As New OleDb.OleDbDataAdapter(strSQLGD, cn)
    '    daGD.Fill(dsGD, STR_DBNAME)

    '    strSQLGD = Nothing
    '    daGD = Nothing
    '    Return dsGD



    'End Function
    ''' <summary>
    ''' getTermsfromTerms will return a dataset from the terms table
    ''' </summary>
    ''' <param name="strTType"></param>
    ''' <returns>dataset dsT</returns>
    ''' <remarks></remarks>

    Public Function getTermsfromTerms(ByVal strTType) As DataSet
        Call callConnection()
        Dim strSQLT As String = "Select * from terms where TType='" & strTType & "' "
        Dim dsT As New DataSet
        Dim daT As New OleDb.OleDbDataAdapter(strSQLT, cn)
        daT.Fill(dsT, STR_DBNAME)

        strSQLT = Nothing
        daT = Nothing
        GC.Collect()

        Return dsT
    End Function

    ''' <summary>
    ''' Method will return card detils for the given cardID
    ''' </summary>
    ''' <param name="strCARDID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getTransDetailsForCardID(ByVal strCARDID As String) As DataSet
        Call callConnection()
        Dim strSQLGT As String = "SELECT * from trans where cardID=  '" & strCARDID & "' ORDER BY TrId DESC"
        Dim dsGT As New DataSet
        Dim daGT As New OleDb.OleDbDataAdapter(strSQLGT, cn)

        daGT.Fill(dsGT, STR_DBNAME)
        Return dsGT

        strSQLGT = Nothing
        dsGT = Nothing
        dsGT = Nothing
        GC.Collect()
    End Function

    Public Function getPermissions(ByVal strGAteID As String, ByVal strGateType As String) As DataSet
        Call CallConnection()
        Dim strSQLP As String = "select * from gtpermissions where GateID='" & strGAteID & "' and GateType='" & strGateType & "' "
        Dim dsP As DataSet

        Dim daP As OleDb.OleDbDataAdapter
        dsP = New DataSet
        daP = New OleDb.OleDbDataAdapter(strSQLP, cn)

        daP.Fill(dsP, STR_DBNAME)
        strSQLP = Nothing
        daP = Nothing
        Return dsP
        dsP = Nothing
        GC.Collect()
    End Function

    Public Function getIGnoreRules(ByVal strGateID As String, ByVal strGateType As String) As DataSet
        Call CallConnection()

        Dim strSQLP As String = "select * from gtIgnoreRules where GateID='" & strGateID & "' and GateType='" & strGateType & "' "
        Dim dsP As DataSet

        Dim daP As OleDb.OleDbDataAdapter
        dsP = New DataSet
        daP = New OleDb.OleDbDataAdapter(strSQLP, cn)

        daP.Fill(dsP, STR_DBNAME)
        Return dsP

        dsP = Nothing
        daP = Nothing
        strSQLP = Nothing
        GC.Collect()
    End Function
End Class
