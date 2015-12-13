Imports System.IO

''' <summary>
''' This class s used to read and write to a text file
''' </summary>
''' <remarks>Mihindu Wijesena 02/09/2012</remarks>
Public Class classReadWriteTextFile
    Private FILE_NAME As String = "Property.txt"
    Private ARRAYDATA(,) As String = Nothing ' holds all values in Propertyfile
    Public Function GetPropertyFileDAta() As Array
        '  Dim FILE_NAME As String = "Property.txt"
        ' Dim TextLine As String
        Dim intocunt As Integer
        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objReader As New System.IO.StreamReader(FILE_NAME)
            intocunt = 0
            Dim lines As String() = IO.File.ReadAllLines(FILE_NAME)
            '  ReDim strDataPropFile(lines.Length)
            ReDim ARRAYDATA(lines.Length - 1, 1)
            Dim intC As Integer = 0
            Dim intCend As Integer = 1 ' this value should be same as array Column
            For intocunt = 0 To lines.Length
                If objReader.Peek <> -1 Then
                    ' intLength.SetValue(objReader.ReadLine(), intocunt)
                    Dim STRLineDATA = objReader.ReadLine().Split("=")
                    For intC = 0 To intCend
                        ARRAYDATA(intocunt, intC) = STRLineDATA(intC)
                        '  MessageBox.Show(ARRAYDATA(intocunt, intC))
                    Next
                End If
            Next
            Return ARRAYDATA
            intC = Nothing
            intCend = Nothing
            GC.Collect()
        Else
            LogError.log("Reading Property file error. Classs ReadWriteTextFile - GetPropfileData")
            msgb.msgOKInf("File not Available")
            End

            Return ARRAYDATA


        End If
    End Function
    ''' <summary>
    ''' This function saves the data to a text file. the data should be sent via a two dimentional array
    ''' </summary>
    ''' <param name="strData"></param>
    ''' <returns></returns>
    ''' <remarks>Mihindu Wijesena 18/09/2012</remarks>
    Public Function SaveTextToFile(ByVal strData(,) As String) As Boolean


        'Dim Contents As String
        Dim bAns As Boolean = False
        Dim objwriter As StreamWriter
        Try
            Dim intR As Integer
            objwriter = New StreamWriter(FILE_NAME)
            For intR = 0 To strData.GetLength(0) - 1
                objwriter.Write(strData(intR, 0) & "=")
                objwriter.WriteLine(strData(intR, 1))
            Next
            objwriter.Close()
            bAns = True
            Return True

        Catch Ex As Exception

            LogError.log("Reading Property file error. Classs ReadWriteTextFile - SaveTextToFile")
            msgb.msgOKInf("File not Available")
            End
            Return False
        End Try

    End Function
End Class
