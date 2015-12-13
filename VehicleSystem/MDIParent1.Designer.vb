<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblRemainingCount = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblRemainingCount
        '
        Me.lblRemainingCount.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblRemainingCount.AutoSize = True
        Me.lblRemainingCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRemainingCount.Location = New System.Drawing.Point(594, 9)
        Me.lblRemainingCount.Name = "lblRemainingCount"
        Me.lblRemainingCount.Size = New System.Drawing.Size(106, 73)
        Me.lblRemainingCount.TabIndex = 1
        Me.lblRemainingCount.Text = "20"
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 471)
        Me.Controls.Add(Me.lblRemainingCount)
        Me.IsMdiContainer = True
        Me.Name = "MDIParent1"
        Me.Text = "MDIParent1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblRemainingCount As System.Windows.Forms.Label

End Class
