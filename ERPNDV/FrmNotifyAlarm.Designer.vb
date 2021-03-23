<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNotifyAlarm
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNotifyAlarm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bttXem = New DevExpress.XtraEditors.SimpleButton()
        Me.bttDong = New DevExpress.XtraEditors.SimpleButton()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Location = New System.Drawing.Point(25, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(239, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Bạn có yêu cầu đang chờ duyệt !"
        '
        'bttXem
        '
        Me.bttXem.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttXem.Appearance.Options.UseFont = True
        Me.bttXem.ImageOptions.Image = CType(resources.GetObject("bttXem.ImageOptions.Image"), System.Drawing.Image)
        Me.bttXem.Location = New System.Drawing.Point(32, 51)
        Me.bttXem.Name = "bttXem"
        Me.bttXem.Size = New System.Drawing.Size(113, 31)
        Me.bttXem.TabIndex = 3
        Me.bttXem.Text = "Xem ngay"
        '
        'bttDong
        '
        Me.bttDong.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttDong.Appearance.Options.UseFont = True
        Me.bttDong.ImageOptions.Image = CType(resources.GetObject("bttDong.ImageOptions.Image"), System.Drawing.Image)
        Me.bttDong.Location = New System.Drawing.Point(151, 51)
        Me.bttDong.Name = "bttDong"
        Me.bttDong.Size = New System.Drawing.Size(113, 31)
        Me.bttDong.TabIndex = 4
        Me.bttDong.Text = "Để sau"
        '
        'FrmNotifyAlarm
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(289, 114)
        Me.Controls.Add(Me.bttDong)
        Me.Controls.Add(Me.bttXem)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.Shadow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNotifyAlarm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NDVERP Notify"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents bttXem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents bttDong As DevExpress.XtraEditors.SimpleButton
End Class
