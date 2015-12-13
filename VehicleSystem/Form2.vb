Public Class Form2

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Dim oldNo = Trim(Me.txtOldNo.Text)
        Dim newNo = Trim(Me.txtNewNo.Text)
        If oldNo = "" Then
            MSGB.msgOKInf("Old coupon number cannot be blank ")
            Call clearAll()
        ElseIf newNo = "" Then
            MSGB.msgOKInf("New coupon number cannot be blank")
            Me.txtNewNo.Focus()
        ElseIf oldNo = newNo Then
            MSGB.msgOKInf("Old coupon number and new coupon number cannot be the same")
            Call clearAll()
        Else
            Dim dsD1 As DataSet
            dsD1 = DAO.CheckVehicleAvailability(newNo)
            If dsD1.Tables(strDBNAME).Rows.Count <> 0 Then
                MSGB.msgOKInf("New coupon number already exists")
                Call clearAll()
                Exit Sub
            End If

            Dim dsD As DataSet
            dsD = DAO.CheckVehicleAvailability(oldNo)
            MSGB.msgOKInf("count " & dsD.Tables(strDBNAME).Rows.Count)
            If dsD.Tables(strDBNAME).Rows.Count = 1 Then
                With dsD.Tables(strDBNAME).Rows(0)
                    Dim IntID As Integer = Convert.ToInt32(.Item("ID").ToString)
                    DAO.editVidbyPrimaryKey(IntID, Convert.ToInt32(Me.txtNewNo.Text))

                End With
                MSGB.msgOKInf("Old coupon number : " & oldNo & " is updated with new coupon number " & newNo)
                Call clearAll()
            ElseIf dsD.Tables(strDBNAME).Rows.Count > 1 Then
                MSGB.msgOKInf("New coupon number already exists. Click on Move button if you need to move the count" & vbCrLf & "Contact systems adminsitrator for futher clarifications")
                Call clearAll()
            Else
                MSGB.msgOKInf("No records found")
                Call clearAll()
            End If

        End If
    End Sub

    Private Sub txtOldNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOldNo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim oldNo = Trim(Me.txtOldNo.Text)
            If oldNo = "" Then
                MSGB.msgOKInf("Old coupon number cannot be blank ")

                Call clearAll()
            Else
                Dim dsD As DataSet
                dsD = DAO.CheckVehicleAvailability(oldNo)
                If dsD.Tables(strDBNAME).Rows.Count = 1 Then
                    Me.txtNewNo.Focus()
                Else
                    Call clearAll()
                End If
            End If

        End If
    End Sub

    Public Sub clearAll()
        Me.txtNewNo.Clear()
        Me.txtOldNo.Clear()
        Me.txtOldNo.Focus()
    End Sub

    Private Sub txtNewNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNewNo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Dim oldno = Trim(Me.txtOldNo.Text)
            Dim newNo = Trim(Me.txtNewNo.Text)

            If newNo = "" Then
                MSGB.msgOKInf("New coupon number cannot be a blank")

            End If
        End If
    End Sub

    Private Sub txtNewNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewNo.TextChanged

    End Sub

    Private Sub btnMoveCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveCount.Click
        Dim oldNo = Trim(Me.txtOldNo.Text)
        Dim newNo = Trim(Me.txtNewNo.Text)
        If oldNo = "" Then
            MSGB.msgOKInf("Old coupon number cannot be blank ")
            Call clearAll()
        ElseIf newNo = "" Then
            MSGB.msgOKInf("New coupon number cannot be blank")
            Me.txtNewNo.Focus()
        ElseIf oldNo = newNo Then
            MSGB.msgOKInf("Old coupon number and new coupon number cannot be the same")
            Call clearAll()
        Else
            Dim dsdOLD As DataSet = DAO.CheckVehicleAvailability(oldNo)
            Dim dsDNew As DataSet = DAO.CheckVehicleAvailability(newNo)

            Dim res As Integer
            res = MessageBox.Show("Are you sure you want to move the data to new coupon number ? " & vbCrLf &
                                 " Old coupon number " & oldNo & " with count " & dsdOLD.Tables(strDBNAME).Rows(0).Item("v_count") &
                                 " to new number " & newNo & " with count " & dsDNew.Tables(strDBNAME).Rows(0).Item("v_count") &
                                 vbCrLf & "THE COUNT WILL BE ADDED IF YOU CONTINUE", "Move the count", MessageBoxButtons.YesNo)
            If res = vbYes Then
                Dim newcount As Integer = dsdOLD.Tables(strDBNAME).Rows(0).Item("v_count") + dsDNew.Tables(strDBNAME).Rows(0).Item("v_count")
                Dim res1 = DAO.editCount(dsDNew.Tables(strDBNAME).Rows(0).Item("v_ID"), newcount)
                If res1 = "Updated" Then
                    DAO.deleteByVID(oldNo)
                    MSGB.msgOKInf("New count is now moved")
                    Call clearAll()
                End If

            End If





        End If

    End Sub
End Class