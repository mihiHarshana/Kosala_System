Public Class ClassTransActions
    Private strTRIN As Boolean
    Private strTRGateID As String
    Private strTRGateType As String

    Public Property strTRansIN()
        Get
            Return strTRIN
        End Get
        Set(ByVal value)
            strTRIN = value
        End Set
    End Property

    Public Property strTransGATEID()
        Get
            Return strTRGateID
        End Get
        Set(ByVal value)
            strTRGateID = value
        End Set
    End Property

    Public Property strTransGateType()
        Get
            Return strTRGateType
        End Get
        Set(ByVal value)
            strTRGateType = value
        End Set
    End Property
End Class
