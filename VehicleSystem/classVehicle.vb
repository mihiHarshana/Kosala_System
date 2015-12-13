Public Class classVehicle
    Private v_Id As String
    Private v_Count As Integer
    Private v_position As Integer


    Public Function setv_Id(ByVal id As String) As String
        If Trim(id) = "" Then
            Return "Invalid Number"
        End If


        v_Id = id
        Return ""

    End Function

    Public Function getV_Id() As String
        Return Me.v_Id

    End Function

    Public Function setV_count(ByVal vcount As Integer) As String
        Me.v_Count = vcount
        Return "OK"
    End Function

    Public Function getV_Count() As Integer
        Return v_Count

    End Function

    Public Function setV_position(ByVal position) As String
        Me.v_position = position
        Return "OK"
    End Function

    Public Function getV_position() As String
        Return Me.v_position
    End Function

End Class
