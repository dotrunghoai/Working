<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGSRUserRight
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGSRUserRight))
        Me.gridD = New UtilityControl.CustomDataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsAll = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuSave = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtUserID = New System.Windows.Forms.TextBox()
        Me.chkIsAll = New System.Windows.Forms.CheckBox()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridD
        '
        Me.gridD.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridD.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.UserID, Me.FullName, Me.IsAll})
        Me.gridD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridD.EnableHeadersVisualStyles = False
        Me.gridD.Location = New System.Drawing.Point(0, 55)
        Me.gridD.Name = "gridD"
        Me.gridD.ReadOnly = True
        Me.gridD.RowHeadersWidth = 20
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridD.Size = New System.Drawing.Size(814, 327)
        Me.gridD.TabIndex = 1
        '
        'No
        '
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'FullName
        '
        Me.FullName.DataPropertyName = "FullName"
        Me.FullName.HeaderText = "FullName"
        Me.FullName.Name = "FullName"
        Me.FullName.ReadOnly = True
        '
        'IsAll
        '
        Me.IsAll.DataPropertyName = "IsAll"
        Me.IsAll.HeaderText = "IsAll"
        Me.IsAll.Name = "IsAll"
        Me.IsAll.ReadOnly = True
        Me.IsAll.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSave, Me.mnuDelete, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tlsMenu.Size = New System.Drawing.Size(814, 55)
        Me.tlsMenu.TabIndex = 2
        Me.tlsMenu.Text = "ToolStrip1"
        '
        'mnuSave
        '
        Me.mnuSave.AutoSize = False
        Me.mnuSave.Image = CType(resources.GetObject("mnuSave.Image"), System.Drawing.Image)
        Me.mnuSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(60, 50)
        Me.mnuSave.Text = "Save"
        Me.mnuSave.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuDelete
        '
        Me.mnuDelete.AutoSize = False
        Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
        Me.mnuDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(60, 50)
        Me.mnuDelete.Text = "Delete"
        Me.mnuDelete.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(132, 19)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(100, 20)
        Me.txtUserID.TabIndex = 3
        '
        'chkIsAll
        '
        Me.chkIsAll.AutoSize = True
        Me.chkIsAll.Location = New System.Drawing.Point(242, 20)
        Me.chkIsAll.Name = "chkIsAll"
        Me.chkIsAll.Size = New System.Drawing.Size(46, 18)
        Me.chkIsAll.TabIndex = 5
        Me.chkIsAll.Text = "IsAll"
        Me.chkIsAll.UseVisualStyleBackColor = True
        '
        'FrmGSRUserRight
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 382)
        Me.Controls.Add(Me.gridD)
        Me.Controls.Add(Me.chkIsAll)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmGSRUserRight"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "020803"
        Me.Text = "User Right"
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridD As UtilityControl.CustomDataGridView
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents chkIsAll As System.Windows.Forms.CheckBox
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsAll As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
