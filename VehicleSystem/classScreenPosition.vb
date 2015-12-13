''' <summary>
''' Provides the values for screen positioning 
''' 
''' </summary>
''' <remarks>Mihindu Wijesena 02/09/2012</remarks>
Public Class classScreenPosition
    Private arrayIntHw(0, 1) As Integer ' holds the values of the screen height and Width

    ''' <summary>
    ''' Gets the current screen resolution.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ScreenResolution()
        'Dim intX As Integer = Screen.PrimaryScreen.Bounds.Width
        'Dim intY As Integer = Screen.PrimaryScreen.Bounds.Height
        Dim intX As Integer = MDIParent1.Height
        Dim intY As Integer = MDIParent1.Width


        arrayIntHw(0, 0) = intX
        arrayIntHw(0, 1) = intY

        Return arrayIntHw
    End Function


    Public Function ScreenPositioning(ByVal Noforms As Integer) 'As Array(,)

        Dim ArrayR(INT_NO_OF_FORMS, 1)

        Dim intHe As Integer = MDIParent1.Size.Height * 0.98
        Dim intWi As Integer = MDIParent1.Size.Width * 0.98
        'MessageBox.Show(intHe)
        'MessageBox.Show(intWi)


        Dim intSH As Integer
        Dim intSW As Integer

        intSH = intHe / 3.5 ' 3.5
        intSW = intWi / 4.4 ' 4.5

        Dim intSH1 = intHe / 10 ' 3.5
        Dim intSW1 = intWi / 3 ' 4.5

        ArrayR(0, 0) = 0  ' 1st form
        ArrayR(0, 1) = 0

        ArrayR(1, 0) = 0 '2nd form
        ArrayR(1, 1) = intSH1 * 0.5
       

        ArrayR(2, 0) = 0 ' 3rd Form
        ArrayR(2, 1) = intSH1 * 1

        ArrayR(3, 0) = 0 ' 4rd Form
        ArrayR(3, 1) = intSH1 * 1.5


        ArrayR(4, 0) = 0 ' 5th Form
        ArrayR(4, 1) = intSH1 * 2

        ArrayR(5, 0) = 0 ' 6th Form
        ArrayR(5, 1) = intSH1 * 2.5

        ArrayR(6, 0) = 0 ' 7th Form
        ArrayR(6, 1) = intSH1 * 3

        ArrayR(7, 0) = 0 ' 8th Form
        ArrayR(7, 1) = intSH1 * 3.5

        ArrayR(8, 0) = 0 ' 9th Form
        ArrayR(8, 1) = intSH1 * 4

        ArrayR(9, 0) = 0 ' 10th Form
        ArrayR(9, 1) = intSH1 * 4.5

        ArrayR(10, 0) = 0 ' 11th Form
        ArrayR(10, 1) = intSH1 * 5

        ArrayR(11, 0) = 0 ' 11th Form
        ArrayR(11, 1) = intSH1 * 5.5

        ArrayR(12, 0) = 0 ' 11th Form
        ArrayR(12, 1) = intSH1 * 6

        ArrayR(13, 0) = 0 ' 11th Form
        ArrayR(13, 1) = intSH1 * 6.5

        ArrayR(14, 0) = 0 ' 11th Form
        ArrayR(14, 1) = intSH1 * 7

        ArrayR(15, 0) = 0 ' 11th Form
        ArrayR(15, 1) = intSH1 * 7.5


        ArrayR(16, 0) = 0 ' 11th Form
        ArrayR(16, 1) = intSH1 * 8

        ArrayR(17, 0) = 0 ' 11th Form
        ArrayR(17, 1) = intSH1 * 8.5

        ArrayR(18, 0) = 0 ' 11th Form
        ArrayR(18, 1) = intSH1 * 9

        ArrayR(19, 0) = 0 ' 11th Form
        ArrayR(19, 1) = intSH1 * 9.5

        ArrayR(20, 0) = 0 ' 11th Form
        ArrayR(20, 1) = intSH1 * 10


        ' ArrayR = Nothing
        intSH = Nothing
        intSW = Nothing
        intHe = Nothing
        intWi = Nothing
        intSW1 = Nothing
        intSH1 = Nothing

        GC.Collect()
        Return ArrayR
    End Function

End Class
