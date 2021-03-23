<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLock
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
        Me.components = New System.ComponentModel.Container()
        Me.bttOK = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.ckoVisiblePassword = New System.Windows.Forms.CheckBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bttOK
        '
        Me.bttOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bttOK.ForeColor = System.Drawing.Color.Blue
        Me.bttOK.Location = New System.Drawing.Point(133, 160)
        Me.bttOK.Name = "bttOK"
        Me.bttOK.Size = New System.Drawing.Size(196, 41)
        Me.bttOK.TabIndex = 0
        Me.bttOK.Text = "OK"
        Me.bttOK.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(100, 35)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(300, 16)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Login user or admin only can unlock this program."
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(133, 105)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(196, 21)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'ckoVisiblePassword
        '
        Me.ckoVisiblePassword.AutoSize = True
        Me.ckoVisiblePassword.BackColor = System.Drawing.Color.Transparent
        Me.ckoVisiblePassword.Location = New System.Drawing.Point(133, 132)
        Me.ckoVisiblePassword.Name = "ckoVisiblePassword"
        Me.ckoVisiblePassword.Size = New System.Drawing.Size(118, 19)
        Me.ckoVisiblePassword.TabIndex = 3
        Me.ckoVisiblePassword.Text = "Visible password"
        Me.ckoVisiblePassword.UseVisualStyleBackColor = False
        '
        'lblUser
        '
        Me.lblUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        Me.lblUser.Location = New System.Drawing.Point(12, 60)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(476, 15)
        Me.lblUser.TabIndex = 5
        Me.lblUser.Text = "..."
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'FrmLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 267)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.ckoVisiblePassword)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.bttOK)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLock"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        'Me.TabText = "Lock"
        Me.Tag = "0002"
        Me.Text = "Lock"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bttOK As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ckoVisiblePassword As System.Windows.Forms.CheckBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
