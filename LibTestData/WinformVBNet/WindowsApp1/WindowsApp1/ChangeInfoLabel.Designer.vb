<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChangeInfoLabel
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnNutNhan = New System.Windows.Forms.Button()
        Me.lblThongTinHienThi = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnNutNhan
        '
        Me.btnNutNhan.Location = New System.Drawing.Point(267, 25)
        Me.btnNutNhan.Name = "btnNutNhan"
        Me.btnNutNhan.Size = New System.Drawing.Size(104, 23)
        Me.btnNutNhan.TabIndex = 0
        Me.btnNutNhan.Text = "Nút Để Nhấn" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnNutNhan.UseVisualStyleBackColor = True
        '
        'lblThongTinHienThi
        '
        Me.lblThongTinHienThi.AutoSize = True
        Me.lblThongTinHienThi.Location = New System.Drawing.Point(264, 89)
        Me.lblThongTinHienThi.Name = "lblThongTinHienThi"
        Me.lblThongTinHienThi.Size = New System.Drawing.Size(105, 13)
        Me.lblThongTinHienThi.TabIndex = 1
        Me.lblThongTinHienThi.Text = "Thông tin để hiển thị"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(616, 359)
        Me.Controls.Add(Me.lblThongTinHienThi)
        Me.Controls.Add(Me.btnNutNhan)
        Me.Name = "Form1"
        Me.Text = "Form Chính"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNutNhan As Button
    Friend WithEvents lblThongTinHienThi As Label
End Class
