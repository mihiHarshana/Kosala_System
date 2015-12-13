Public Class ClassCardDetails
    Private card_ID As String
    Private card_SNO As String
    Private card_TYPE As String
    Private card_STATUS As String
    Private card_TRIN As Boolean
    Private card_Name As String

    ' // 02/11/2012 addding this to show the name from the card details
    Public Property strcardName()
        Get
            Return card_Name
        End Get
        Set(ByVal value)
            card_Name = value
        End Set
    End Property


    Public LASTINTIME As String
    Public LASTOUTTIME As String
    'Private DAO As New ClassDAO

    Public Property strCardId()
        Get
            Return card_ID
        End Get

        Set(ByVal value)
            card_ID = value
        End Set
    End Property


    Public Property strCardSNO()
        Get
            Return card_SNO
        End Get
        Set(ByVal value)
            card_SNO = value
        End Set
    End Property

    Public Property strCardType()
        Get
            Return card_TYPE
        End Get
        Set(ByVal value)
            card_TYPE = value
        End Set
    End Property

    Public Property blnCardStatus()
        Get
            Return card_STATUS
        End Get
        Set(ByVal value)
            card_STATUS = value
        End Set
    End Property

    Public Property blnCARDTRIN()
        Get
            Return card_TRIN
        End Get
        Set(ByVal value)
            card_TRIN = value

        End Set
    End Property

    Public Sub getCardDetails(ByVal strCArdID As String)
        Dim cDAO As New ClassDAO
        Dim cCDEtails As New ClassCardDetails

        cDAO.getCardDetails(cCDEtails.strCardId)



    End Sub

    'Public Function ValidateCArdID(ByVal strCArdId) As Boolean
    '    If Len(strCArdId) = arrayDATAPropFile(0, 1) Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function
    'Public Function ValidateNumeric(ByVal StrCardId) As Boolean
    '    If IsNumeric(StrCardId) = True Then
    '        Return True
    '    Else
    '        Return False

    '    End If
    'End Function

    'Public Function CheckforSameCard(ByVal strCARDID As String) As Boolean
    '    '   If LCID = strCARDID And LCIDDateTime.AddSeconds(arrayDATAPropFile(8, 1)) >= Now Then
    '    If LCID = strCARDID And LCIDDateTime.AddSeconds(arrayDATAPropFile(7, 1)) >= Now Then
    '        ' MessageBox.Show("Same again")
    '        Return True
    '    Else
    '        'MessageBox.Show("Another Card")
    '        Return False
    '    End If
    'End Function

    'Public Function setCArdDetails(ByVal strCardId As String)
    '    Dim dsCD As New DataSet
    '    dsCD = DAO.getCardDetails(strCardId)
    '    '  MessageBox.Show(dsCD.Tables(STR_DBNAME).Rows.Count)
    '    With dsCD.Tables(STR_DBNAME).Rows(0)
    '        strCNo = .Item("cardSno")
    '        strCType = .Item("cardType")
    '        blnStatus = .Item("cardStatus")

    '        dsCD = Nothing
    '        GC.Collect()
    '    End With
    'End Function

    'Public Function setLastINTime(ByVal strCArdId As String)

    ' Commented by SS 22022013

    '    LASTINTIME = DAO.GetLastInTime(strCArdId)
    '    '   If LASTINTIME = "00:00:00" Then
    '    'Return ""
    '    '  Else
    '    Return LASTINTIME
    '    ' End If
    'End Function

    ' Commented by SS 22022013

    'Public Function setLASTOUTTime(ByVal strCARdID As String)
    '    LASTOUTTIME = DAO.getLastOutTime(strCARdID)
    '    '  If LASTOUTTIME = "00:00:00" Then
    '    'Return ""
    '    '  Else
    '    Return LASTOUTTIME
    '    ' End If
    'End Function
End Class
