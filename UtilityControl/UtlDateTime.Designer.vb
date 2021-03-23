<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UtlDateTime
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.cboDate = New System.Windows.Forms.ComboBox()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ckbUse = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(14, 56)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.Size = New System.Drawing.Size(140, 20)
        Me.dtpStartDateTime.TabIndex = 0
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(15, 95)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.Size = New System.Drawing.Size(140, 20)
        Me.dtpEndDateTime.TabIndex = 1
        '
        'cboDate
        '
        Me.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDate.FormattingEnabled = True
        Me.cboDate.Location = New System.Drawing.Point(15, 16)
        Me.cboDate.Name = "cboDate"
        Me.cboDate.Size = New System.Drawing.Size(117, 21)
        Me.cboDate.TabIndex = 2
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(12, 40)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(53, 13)
        Me.lblStart.TabIndex = 3
        Me.lblStart.Text = "Start date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "End date"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(167, 131)
        Me.ShapeContainer1.TabIndex = 5
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.RectangleShape1.BorderWidth = 2
        Me.RectangleShape1.Location = New System.Drawing.Point(6, 6)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(156, 119)
        '
        'ckbUse
        '
        Me.ckbUse.AutoSize = True
        Me.ckbUse.Checked = True
        Me.ckbUse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbUse.Location = New System.Drawing.Point(139, 21)
        Me.ckbUse.Name = "ckbUse"
        Me.ckbUse.Size = New System.Drawing.Size(15, 14)
        Me.ckbUse.TabIndex = 6
        Me.ckbUse.UseVisualStyleBackColor = True
        '
        'UtlDateTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ckbUse)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.cboDate)
        Me.Controls.Add(Me.dtpEndDateTime)
        Me.Controls.Add(Me.dtpStartDateTime)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "UtlDateTime"
        Me.Size = New System.Drawing.Size(167, 131)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboDate As System.Windows.Forms.ComboBox
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents ckbUse As System.Windows.Forms.CheckBox

End Class
