Public Class frmForm1
    Private vehicle As New classVehicle
    Private dsD As DataSet
    Public Shared enteredValues As New ArrayList

    Private Sub txtVehicleId_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVehicleId.KeyPress

        If e.KeyChar = ChrW(Keys.Enter) Then
            vehicle.setv_Id(Me.txtVehicleId.Text)

            dsD = DAO.CheckVehicleAvailability(vehicle.getV_Id)
            If dsD.Tables(strDBNAME).Rows.Count = 0 Then
                vehicle.setV_count(1)
                vehicle.setV_position(cForm)
                arrayfrm(cForm).lblCount.Text = vehicle.getV_Count
                activateImages(cForm, 1)
                Dim res = DAO.addVehicle(vehicle)
                If res = "Added" Then
                    '  MSGB.msgOKInf("New ID added ")
                    cForm = cForm + 1
                    lastId = vehicle.getV_Id
                    arrayfrm(cForm).txtVehicleId.Focus()
                    MDIParent1.deductRemain()
                End If
            Else

                'MSGB.msgOKInf("Positioni is " & dsD.Tables(strDBNAME).Rows(0).Item("v_Position"))
                'MSGB.msgOKInf("Current form is  " & cForm)

                Dim cposition As Integer = dsD.Tables(strDBNAME).Rows(0).Item("v_Position")
                Dim tot = Convert.ToInt32(dsD.Tables(strDBNAME).Rows(0).Item("v_count").ToString)

                tot = tot + 1
                vehicle.setV_count(tot)
                activateImages(cForm - 1, vehicle.getV_Count)
                DAO.editCount(vehicle.getV_Id, vehicle.getV_Count)
                arrayfrm(cposition).lblCount.Text = tot
                arrayfrm(cForm).txtVehicleId.Clear()
                MDIParent1.deductRemain()
            End If

        End If
    End Sub


    Private Sub frmForm1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FlowLayoutPanel1.Controls.Add(PictureBox1)
        FlowLayoutPanel1.Controls.Add(PictureBox2)
        FlowLayoutPanel1.Controls.Add(PictureBox3)
        FlowLayoutPanel1.Controls.Add(PictureBox4)
        FlowLayoutPanel1.Controls.Add(PictureBox5)
        FlowLayoutPanel1.Controls.Add(PictureBox6)
        FlowLayoutPanel1.Controls.Add(PictureBox7)
        FlowLayoutPanel1.Controls.Add(PictureBox8)
        FlowLayoutPanel1.Controls.Add(PictureBox9)
        FlowLayoutPanel1.Controls.Add(PictureBox10)
        'Dim p2 As New PictureBox
        'Dim p3 As New PictureBox
        'Dim p4 As New PictureBox
        'Dim p2 As New PictureBox
        'Dim p3 As New PictureBox
        'Dim p4 As New PictureBox
        'p2 = PictureBox2
        'p3 = PictureBox3
        'p4 = PictureBox4



    End Sub

    Private Sub activateImages(ByVal formID As Integer, ByVal picCount As Integer)

        Select Case picCount
            Case 1
                arrayfrm(formID).PictureBox1.Show()
            Case 2
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
            Case 3
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
                arrayfrm(formID).PictureBox3.Show()

            Case 4
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
                arrayfrm(formID).PictureBox3.Show()
                arrayfrm(formID).PictureBox4.Show()
            Case 5
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
                arrayfrm(formID).PictureBox3.Show()
                arrayfrm(formID).PictureBox4.Show()
                arrayfrm(formID).PictureBox5.Show()

            Case 6
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
                arrayfrm(formID).PictureBox3.Show()
                arrayfrm(formID).PictureBox4.Show()
                arrayfrm(formID).PictureBox5.Show()
                arrayfrm(formID).PictureBox6.Show()
            Case 7
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
                arrayfrm(formID).PictureBox3.Show()
                arrayfrm(formID).PictureBox4.Show()
                arrayfrm(formID).PictureBox5.Show()
                arrayfrm(formID).PictureBox6.Show()
                arrayfrm(formID).PictureBox7.Show()
            Case 8
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
                arrayfrm(formID).PictureBox3.Show()
                arrayfrm(formID).PictureBox4.Show()
                arrayfrm(formID).PictureBox5.Show()
                arrayfrm(formID).PictureBox6.Show()
                arrayfrm(formID).PictureBox7.Show()
                arrayfrm(formID).PictureBox8.Show()

            Case 9
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
                arrayfrm(formID).PictureBox3.Show()
                arrayfrm(formID).PictureBox4.Show()
                arrayfrm(formID).PictureBox5.Show()
                arrayfrm(formID).PictureBox6.Show()
                arrayfrm(formID).PictureBox7.Show()
                arrayfrm(formID).PictureBox8.Show()
                arrayfrm(formID).PictureBox9.Show()

            Case 10
                arrayfrm(formID).PictureBox1.Show()
                arrayfrm(formID).PictureBox2.Show()
                arrayfrm(formID).PictureBox3.Show()
                arrayfrm(formID).PictureBox4.Show()
                arrayfrm(formID).PictureBox5.Show()
                arrayfrm(formID).PictureBox6.Show()
                arrayfrm(formID).PictureBox7.Show()
                arrayfrm(formID).PictureBox8.Show()
                arrayfrm(formID).PictureBox9.Show()
                arrayfrm(formID).PictureBox10.Show()
        End Select


    End Sub

    Private Sub txtVehicleId_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVehicleId.TextChanged

    End Sub
End Class
