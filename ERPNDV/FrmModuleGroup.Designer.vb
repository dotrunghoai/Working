<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModuleGroup
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModuleGroup))
        Me.gboGrid = New System.Windows.Forms.GroupBox()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.GroupID = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.GroupNameE = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.GroupNameV = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.GroupNameJ = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.GroupNameC = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Note = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.txtGroupC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtgroupJ = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGroupV = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtgroupE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtGroupID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuNew = New System.Windows.Forms.ToolStripButton()
        Me.mnuSave = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gboGrid.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gboGrid
        '
        Me.gboGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboGrid.Controls.Add(Me.grid)
        Me.gboGrid.Location = New System.Drawing.Point(0, 47)
        Me.gboGrid.Name = "gboGrid"
        Me.gboGrid.Size = New System.Drawing.Size(926, 348)
        Me.gboGrid.TabIndex = 8
        Me.gboGrid.TabStop = False
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AllowUserToOrderColumns = True
        Me.grid.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GroupID, Me.GroupNameE, Me.GroupNameV, Me.GroupNameJ, Me.GroupNameC, Me.Note})
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.EnableHeadersVisualStyles = False
        Me.grid.Location = New System.Drawing.Point(3, 16)
        Me.grid.Name = "grid"
        Me.grid.RowHeadersWidth = 20
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(920, 329)
        Me.grid.TabIndex = 0
        '
        'GroupID
        '
        Me.GroupID.DataPropertyName = "GroupID"
        Me.GroupID.HeaderText = "GroupID"
        Me.GroupID.Name = "GroupID"
        Me.GroupID.ReadOnly = True
        Me.GroupID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'GroupNameE
        '
        Me.GroupNameE.DataPropertyName = "GroupNameE"
        Me.GroupNameE.HeaderText = "GroupNameE"
        Me.GroupNameE.Name = "GroupNameE"
        Me.GroupNameE.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'GroupNameV
        '
        Me.GroupNameV.DataPropertyName = "GroupNameV"
        Me.GroupNameV.HeaderText = "GroupNameV"
        Me.GroupNameV.Name = "GroupNameV"
        Me.GroupNameV.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'GroupNameJ
        '
        Me.GroupNameJ.DataPropertyName = "GroupNameJ"
        Me.GroupNameJ.HeaderText = "GroupNameJ"
        Me.GroupNameJ.Name = "GroupNameJ"
        Me.GroupNameJ.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'GroupNameC
        '
        Me.GroupNameC.DataPropertyName = "GroupNameC"
        Me.GroupNameC.HeaderText = "GroupNameC"
        Me.GroupNameC.Name = "GroupNameC"
        Me.GroupNameC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Note
        '
        Me.Note.DataPropertyName = "Note"
        Me.Note.HeaderText = "Note"
        Me.Note.Name = "Note"
        Me.Note.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'txtGroupC
        '
        Me.txtGroupC.Location = New System.Drawing.Point(798, 21)
        Me.txtGroupC.Name = "txtGroupC"
        Me.txtGroupC.Size = New System.Drawing.Size(162, 20)
        Me.txtGroupC.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(795, 5)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "GroupNameC"
        '
        'txtgroupJ
        '
        Me.txtgroupJ.Location = New System.Drawing.Point(636, 21)
        Me.txtgroupJ.Name = "txtgroupJ"
        Me.txtgroupJ.Size = New System.Drawing.Size(162, 20)
        Me.txtgroupJ.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(633, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "GroupNameJ"
        '
        'txtGroupV
        '
        Me.txtGroupV.Location = New System.Drawing.Point(474, 21)
        Me.txtGroupV.Name = "txtGroupV"
        Me.txtGroupV.Size = New System.Drawing.Size(162, 20)
        Me.txtGroupV.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(471, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "GroupNameV"
        '
        'txtgroupE
        '
        Me.txtgroupE.Location = New System.Drawing.Point(312, 21)
        Me.txtgroupE.Name = "txtgroupE"
        Me.txtgroupE.Size = New System.Drawing.Size(162, 20)
        Me.txtgroupE.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(309, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "GroupNameE"
        '
        'txtGroupID
        '
        Me.txtGroupID.Location = New System.Drawing.Point(247, 21)
        Me.txtGroupID.Name = "txtGroupID"
        Me.txtGroupID.Size = New System.Drawing.Size(65, 20)
        Me.txtGroupID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(251, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GroupID"
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuSave, Me.mnuDelete, Me.mnuShowAll, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(926, 58)
        Me.tlsMenu.TabIndex = 9
        '
        'mnuNew
        '
        Me.mnuNew.AutoSize = False
        Me.mnuNew.Image = CType(resources.GetObject("mnuNew.Image"), System.Drawing.Image)
        Me.mnuNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(60, 50)
        Me.mnuNew.Text = "New"
        Me.mnuNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuNew.ToolTipText = "New (Ctrl+N)"
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
        Me.mnuSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuSave.ToolTipText = "Save (Ctrl+S)"
        '
        'mnuDelete
        '
        Me.mnuDelete.AutoSize = False
        Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
        Me.mnuDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuDelete.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(60, 50)
        Me.mnuDelete.Text = "Delete"
        Me.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuDelete.ToolTipText = "Delete(Ctrl+D)"
        '
        'mnuShowAll
        '
        Me.mnuShowAll.AutoSize = False
        Me.mnuShowAll.Image = CType(resources.GetObject("mnuShowAll.Image"), System.Drawing.Image)
        Me.mnuShowAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuShowAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuShowAll.Name = "mnuShowAll"
        Me.mnuShowAll.Size = New System.Drawing.Size(60, 50)
        Me.mnuShowAll.Text = "Show all"
        Me.mnuShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuShowAll.ToolTipText = "Show all (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
        '
        'FrmModuleGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 395)
        Me.Controls.Add(Me.gboGrid)
        Me.Controls.Add(Me.txtGroupC)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtgroupJ)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtGroupID)
        Me.Controls.Add(Me.txtGroupV)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtgroupE)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmModuleGroup"
        Me.ShowInTaskbar = False
        Me.Tag = "9996"
        Me.Text = "Module Group"
        Me.gboGrid.ResumeLayout(False)
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gboGrid As System.Windows.Forms.GroupBox
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtGroupC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtgroupJ As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGroupV As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtgroupE As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtGroupID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupID As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents GroupNameE As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents GroupNameV As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents GroupNameJ As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents GroupNameC As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Note As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
End Class
