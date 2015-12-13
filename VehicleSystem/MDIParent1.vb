Imports System.Windows.Forms

Public Class MDIParent1

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DateisToday As Date = DateTime.Now.Date.AddDays(31)

        Dim test = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\software\classes\myApp", "myAPP", "")
        If IsNothing(test) Then

            My.Computer.Registry.SetValue("HKEY_CURRENT_USER\software\classes\myApp", "myAPP", DateisToday)
        ElseIf test = "EXPIRED" Then
            MessageBox.Show("System halts due to unknow error (Error Code 0002)" & vbCrLf &
                                 "Contact your system administrator. ", "SERIOUSE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop
                                 )
            Application.Exit()
        Else
            Dim dateTime As DateTime = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\software\classes\myApp", "myAPP", DateisToday)
            'MSGB.msgOKInf("test")
            Dim dateTime1 = Now.Date
            If dateTime < dateTime1 Then
                MessageBox.Show("System halts due to unknow error (Error Code 0001)" & vbCrLf &
                                 "Contact your system administrator. ", "SERIOUSE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Stop
                                 )
                My.Computer.Registry.SetValue("HKEY_CURRENT_USER\software\classes\myApp", "myAPP", "EXPIRED")
                Application.Exit()
            Else
                '  MSGB.msgOKInf("not expired")
            End If
        End If

        Me.Text = "Trial Version 0.1  - (30 days Evaluation. )"
        'If Date.Today > "12 / 12 / 2015" Or Date.Today < "12 / 12 / 2015" Then
        '    MSGB.msgOKCri("Seriouse Error")
        '    Exit Sub
        'End If

        Dim sr As New classScreenPosition

        Dim arrayHW(0, 1) As Integer

        arrayHW = sr.ScreenResolution()
        'MessageBox.Show("height is " & arrayHW(0, 0))
        'MessageBox.Show("weidth is  " & arrayHW(0, 1))


        Dim arraySP(,) = sr.ScreenPositioning(1)



        Dim intI As Integer = 1 ' not using 0 th element. so starting from 1 
        Dim intIend As Integer = arrayfrm.Length - 1
        ' MessageBox.Show(arrayfrm.Length - 1)
        Me.Show()

        Dim SWV As Integer = 1.5
        Dim SHV As Integer = 20

        'arrayfrm(1) = New frmForm1

        'arrayfrm(2) = New frmForm1

        arrayfrm(1) = New frmForm1
        arrayfrm(1).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(1).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(1).Location = New Point(0, 0)

        arrayfrm(2) = New frmForm1
        arrayfrm(2).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(2).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(2).Location = New Point(arraySP(1, 0), arraySP(1, 1))

        arrayfrm(3) = New frmForm1
        arrayfrm(3).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(3).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(3).Location = New Point(arraySP(2, 0), arraySP(2, 1))

        arrayfrm(4) = New frmForm1
        arrayfrm(4).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(4).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(4).Location = New Point(arraySP(3, 0), arraySP(3, 1))

        arrayfrm(5) = New frmForm1
        arrayfrm(5).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(5).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(5).Location = New Point(arraySP(4, 0), arraySP(4, 1))

        arrayfrm(6) = New frmForm1
        arrayfrm(6).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(6).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(6).Location = New Point(arraySP(5, 0), arraySP(5, 1))

        arrayfrm(7) = New frmForm1
        arrayfrm(7).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(7).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(7).Location = New Point(arraySP(6, 0), arraySP(6, 1))

        arrayfrm(8) = New frmForm1
        arrayfrm(8).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(8).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(8).Location = New Point(arraySP(7, 0), arraySP(7, 1))

        arrayfrm(9) = New frmForm1
        arrayfrm(9).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(9).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(9).Location = New Point(arraySP(8, 0), arraySP(8, 1))

        arrayfrm(10) = New frmForm1
        arrayfrm(10).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(10).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(10).Location = New Point(arraySP(9, 0), arraySP(9, 1))

        arrayfrm(11) = New frmForm1
        arrayfrm(11).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(11).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(11).Location = New Point(arraySP(10, 0), arraySP(10, 1))

        arrayfrm(12) = New frmForm1
        arrayfrm(12).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(12).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(12).Location = New Point(arraySP(11, 0), arraySP(11, 1))

        arrayfrm(13) = New frmForm1
        arrayfrm(13).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(13).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(13).Location = New Point(arraySP(12, 0), arraySP(12, 1))

        arrayfrm(14) = New frmForm1
        arrayfrm(14).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(14).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(14).Location = New Point(arraySP(13, 0), arraySP(13, 1))

        arrayfrm(15) = New frmForm1
        arrayfrm(15).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(15).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(15).Location = New Point(arraySP(14, 0), arraySP(14, 1))

        arrayfrm(16) = New frmForm1
        arrayfrm(16).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(16).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(16).Location = New Point(arraySP(15, 0), arraySP(15, 1))

        arrayfrm(17) = New frmForm1
        arrayfrm(17).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(17).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(17).Location = New Point(arraySP(16, 0), arraySP(16, 1))

        arrayfrm(18) = New frmForm1
        arrayfrm(18).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(18).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(18).Location = New Point(arraySP(17, 0), arraySP(17, 1))

        arrayfrm(19) = New frmForm1
        arrayfrm(19).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(19).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(19).Location = New Point(arraySP(18, 0), arraySP(18, 1))

        arrayfrm(20) = New frmForm1
        arrayfrm(20).Width = arrayHW(0, 1) / SWV ' 4.7
        arrayfrm(20).Height = arrayHW(0, 0) / SHV ' 3.7
        arrayfrm(20).Location = New Point(arraySP(19, 0), arraySP(19, 1))

        Dim f As Integer
        For f = 1 To 20
            arrayfrm(f).MdiParent = Me
        Next

        For f = 1 To 20
            arrayfrm(f).Show()
            arrayfrm(f).Text = f
        Next

        Dim intIC As Integer
        For intIC = 1 To arrayfrm.Length - 2
            arrayfrm(intIC).PictureBox1.Hide()
            arrayfrm(intIC).PictureBox2.Hide()
            arrayfrm(intIC).PictureBox3.Hide()
            arrayfrm(intIC).PictureBox4.Hide()
            arrayfrm(intIC).PictureBox5.Hide()
            arrayfrm(intIC).PictureBox6.Hide()
            arrayfrm(intIC).PictureBox7.Hide()
            arrayfrm(intIC).PictureBox8.Hide()
            arrayfrm(intIC).PictureBox9.Hide()
            arrayfrm(intIC).PictureBox10.Hide()


        Next
        '' Loads the previouse data if availabel

        Dim DSDA As DataSet = DAO.getAllData
        Dim intC As Integer

        Dim intPic As Integer = 0
        If DSDA.Tables(strDBNAME).Rows.Count = 0 Then
            MSGB.msgOKInf("Nothing to load")
        Else
            For intC = 0 To DSDA.Tables(strDBNAME).Rows.Count - 1

                arrayfrm(intC + 1).txtVehicleId.Text = DSDA.Tables(strDBNAME).Rows(intC).Item("v_ID")
                arrayfrm(intC + 1).lblCount.Text = DSDA.Tables(strDBNAME).Rows(intC).Item("v_count")
                deductRemain(Convert.ToInt32(DSDA.Tables(strDBNAME).Rows(intC).Item("v_count")))



                Select Case arrayfrm(intC + 1).lblCount.Text
                    Case 1
                        arrayfrm(intC + 1).PictureBox1.Show()

                    Case 2
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()

                    Case 3
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()
                        arrayfrm(intC + 1).PictureBox3.Show()

                    Case 4
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()
                        arrayfrm(intC + 1).PictureBox3.Show()
                        arrayfrm(intC + 1).PictureBox4.Show()

                    Case 5
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()
                        arrayfrm(intC + 1).PictureBox3.Show()
                        arrayfrm(intC + 1).PictureBox4.Show()
                        arrayfrm(intC + 1).PictureBox5.Show()

                    Case 6
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()
                        arrayfrm(intC + 1).PictureBox3.Show()
                        arrayfrm(intC + 1).PictureBox4.Show()
                        arrayfrm(intC + 1).PictureBox5.Show()
                        arrayfrm(intC + 1).PictureBox6.Show()

                    Case 7
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()
                        arrayfrm(intC + 1).PictureBox3.Show()
                        arrayfrm(intC + 1).PictureBox4.Show()
                        arrayfrm(intC + 1).PictureBox5.Show()
                        arrayfrm(intC + 1).PictureBox6.Show()
                        arrayfrm(intC + 1).PictureBox7.Show()

                    Case 8
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()
                        arrayfrm(intC + 1).PictureBox3.Show()
                        arrayfrm(intC + 1).PictureBox4.Show()
                        arrayfrm(intC + 1).PictureBox5.Show()
                        arrayfrm(intC + 1).PictureBox6.Show()
                        arrayfrm(intC + 1).PictureBox7.Show()
                        arrayfrm(intC + 1).PictureBox8.Show()

                    Case 9
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()
                        arrayfrm(intC + 1).PictureBox3.Show()
                        arrayfrm(intC + 1).PictureBox4.Show()
                        arrayfrm(intC + 1).PictureBox5.Show()
                        arrayfrm(intC + 1).PictureBox6.Show()
                        arrayfrm(intC + 1).PictureBox7.Show()
                        arrayfrm(intC + 1).PictureBox8.Show()
                        arrayfrm(intC + 1).PictureBox9.Show()

                    Case 10
                        arrayfrm(intC + 1).PictureBox1.Show()
                        arrayfrm(intC + 1).PictureBox2.Show()
                        arrayfrm(intC + 1).PictureBox3.Show()
                        arrayfrm(intC + 1).PictureBox4.Show()
                        arrayfrm(intC + 1).PictureBox5.Show()
                        arrayfrm(intC + 1).PictureBox6.Show()
                        arrayfrm(intC + 1).PictureBox7.Show()
                        arrayfrm(intC + 1).PictureBox8.Show()
                        arrayfrm(intC + 1).PictureBox9.Show()
                        arrayfrm(intC + 1).PictureBox10.Show()
                End Select
            Next
            ' lastId = arrayfrm(intC + 1).txtVehicleId.Text
            cForm = intC + 1
            arrayfrm(cForm).txtVehicleId.Focus()
        End If
    End Sub

    Public Sub deductRemain(ByVal intValue)
        remainingCount = remainingCount - intValue
        Me.lblRemainingCount.Text = remainingCount
    End Sub

    Public Sub deductRemain()
        remainingCount = remainingCount - 1
        Me.lblRemainingCount.Text = remainingCount
    End Sub
End Class
