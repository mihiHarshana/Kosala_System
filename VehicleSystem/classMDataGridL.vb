'' // 12/10/2012 Change the strCARDID to strGateId  requested by Sanjeewa S .

Public Class classMDataGridL
    Public Sub LoadGridData1(ByVal strGATEID As String)
        Dim dsGDr As DataSet
        dsGDr = DAO.getDataGrid1Data(strGATEID)
        MDIParent1.DataGridView1.DataSource = dsGDr.Tables(STR_DBNAME).DefaultView
        DataGrid1_rowcolors(dsGDr)

    End Sub

    Public Sub DataGrid1_rowcolors(ByVal dsD As DataSet)
        Dim intI As Integer

        For intI = 0 To dsD.Tables(STR_DBNAME).Rows.Count - 1

            If (intI Mod 2) = 0 Then
                MDIParent1.DataGridView1.Rows(intI).DefaultCellStyle.BackColor = Color.LightCyan
            End If
            If MDIParent1.DataGridView1.Rows(intI).Cells("TRTYPE").Value = strINVALIDIN Then
                MDIParent1.DataGridView1.Rows(intI).DefaultCellStyle.BackColor = Color.Red
                ' Else
                'MDIParent1.DataGridView1.Rows(intI).DefaultCellStyle.BackColor = Color.LightCyan
            End If
            If MDIParent1.DataGridView1.Rows(intI).Cells("TRIN").Value = True Then
                MDIParent1.DataGridView1.Rows(intI).DefaultCellStyle.BackColor = Color.Green
                ' Else
                'MDIParent1.DataGridView1.Rows(intI).DefaultCellStyle.BackColor = Color.LightCyan
            End If
        Next
    End Sub

    Public Sub dataGrid2_RowColors(ByVal rcount As Integer)
        For rcount = 0 To rcount - 1
            If (rcount Mod 2) = 0 Then
                MDIParent1.DataGridView2.Rows(rcount).DefaultCellStyle.BackColor = Color.LightCyan
            End If
            If MDIParent1.DataGridView2.Rows(rcount).Cells("TRTYPE").Value = strINVALIDIN Then
                MDIParent1.DataGridView2.Rows(rcount).DefaultCellStyle.BackColor = Color.Red
                ' Else
                'MDIParent1.DataGridView1.Rows(intI).DefaultCellStyle.BackColor = Color.LightCyan
            End If
            If MDIParent1.DataGridView2.Rows(rcount).Cells("TRIN").Value = True Then
                MDIParent1.DataGridView2.Rows(rcount).DefaultCellStyle.BackColor = Color.Green
                ' Else
                'MDIParent1.DataGridView1.Rows(intI).DefaultCellStyle.BackColor = Color.LightCyan
            End If
        Next
    End Sub

End Class
