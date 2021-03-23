<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModuleConnected
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModuleConnected))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gboGrid = New System.Windows.Forms.GroupBox()
        Me.bdn = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.Assemblyfile = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ModuleName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Connected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Note = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtModuleV = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtModuleID = New System.Windows.Forms.TextBox()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuAllow = New System.Windows.Forms.ToolStripButton()
        Me.mnuLocked = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataGridViewAutoFilterTextBoxColumn1 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn2 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn3 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.gboGrid.SuspendLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bdn.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gboGrid
        '
        Me.gboGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboGrid.Controls.Add(Me.bdn)
        Me.gboGrid.Controls.Add(Me.grid)
        Me.gboGrid.Location = New System.Drawing.Point(0, 61)
        Me.gboGrid.Name = "gboGrid"
        Me.gboGrid.Size = New System.Drawing.Size(1012, 369)
        Me.gboGrid.TabIndex = 8
        Me.gboGrid.TabStop = False
        '
        'bdn
        '
        Me.bdn.AddNewItem = Nothing
        Me.bdn.CountItem = Me.BindingNavigatorCountItem
        Me.bdn.DeleteItem = Nothing
        Me.bdn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bdn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bdn.Location = New System.Drawing.Point(3, 341)
        Me.bdn.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bdn.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bdn.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bdn.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bdn.Name = "bdn"
        Me.bdn.PositionItem = Me.BindingNavigatorPositionItem
        Me.bdn.Size = New System.Drawing.Size(1006, 25)
        Me.bdn.TabIndex = 1
        Me.bdn.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
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
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Assemblyfile, Me.ModuleName, Me.Connected, Me.Note})
        Me.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grid.EnableHeadersVisualStyles = False
        Me.grid.Location = New System.Drawing.Point(3, 16)
        Me.grid.Name = "grid"
        Me.grid.RowHeadersWidth = 20
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.grid.Size = New System.Drawing.Size(1009, 320)
        Me.grid.TabIndex = 0
        '
        'Assemblyfile
        '
        Me.Assemblyfile.DataPropertyName = "Assemblyfile"
        Me.Assemblyfile.HeaderText = "ModuleID"
        Me.Assemblyfile.Name = "Assemblyfile"
        Me.Assemblyfile.ReadOnly = True
        Me.Assemblyfile.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ModuleName
        '
        Me.ModuleName.DataPropertyName = "ModuleName"
        Me.ModuleName.HeaderText = "ModuleName"
        Me.ModuleName.Name = "ModuleName"
        Me.ModuleName.ReadOnly = True
        Me.ModuleName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ModuleName.Width = 200
        '
        'Connected
        '
        Me.Connected.DataPropertyName = "Connected"
        Me.Connected.HeaderText = "Connected"
        Me.Connected.Name = "Connected"
        Me.Connected.ReadOnly = True
        Me.Connected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Connected.Width = 80
        '
        'Note
        '
        Me.Note.DataPropertyName = "Note"
        Me.Note.HeaderText = "Note"
        Me.Note.Name = "Note"
        Me.Note.ReadOnly = True
        Me.Note.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Note.Width = 200
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(478, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "ModuleNameV"
        '
        'txtModuleV
        '
        Me.txtModuleV.Location = New System.Drawing.Point(481, 25)
        Me.txtModuleV.Name = "txtModuleV"
        Me.txtModuleV.Size = New System.Drawing.Size(157, 20)
        Me.txtModuleV.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(399, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "ModuleID"
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(402, 25)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.Size = New System.Drawing.Size(73, 20)
        Me.txtModuleID.TabIndex = 2
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAllow, Me.mnuLocked, Me.mnuDelete, Me.mnuShowAll, Me.mnuEdit, Me.mnuExport, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1012, 58)
        Me.tlsMenu.TabIndex = 9
        '
        'mnuAllow
        '
        Me.mnuAllow.AutoSize = False
        Me.mnuAllow.Image = CType(resources.GetObject("mnuAllow.Image"), System.Drawing.Image)
        Me.mnuAllow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuAllow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuAllow.Name = "mnuAllow"
        Me.mnuAllow.Size = New System.Drawing.Size(60, 50)
        Me.mnuAllow.Text = "Allow"
        Me.mnuAllow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuAllow.ToolTipText = "Allow"
        '
        'mnuLocked
        '
        Me.mnuLocked.AutoSize = False
        Me.mnuLocked.Image = CType(resources.GetObject("mnuLocked.Image"), System.Drawing.Image)
        Me.mnuLocked.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuLocked.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuLocked.Name = "mnuLocked"
        Me.mnuLocked.Size = New System.Drawing.Size(60, 50)
        Me.mnuLocked.Text = "Locked"
        Me.mnuLocked.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuLocked.ToolTipText = "Locked"
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
        'mnuEdit
        '
        Me.mnuEdit.AutoSize = False
        Me.mnuEdit.Image = CType(resources.GetObject("mnuEdit.Image"), System.Drawing.Image)
        Me.mnuEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(60, 50)
        Me.mnuEdit.Text = "Edit"
        Me.mnuEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuEdit.ToolTipText = "Edit"
        '
        'mnuExport
        '
        Me.mnuExport.AutoSize = False
        Me.mnuExport.Image = CType(resources.GetObject("mnuExport.Image"), System.Drawing.Image)
        Me.mnuExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(60, 50)
        Me.mnuExport.Text = "Export"
        Me.mnuExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuExport.ToolTipText = "Export"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
        '
        'DataGridViewAutoFilterTextBoxColumn1
        '
        Me.DataGridViewAutoFilterTextBoxColumn1.DataPropertyName = "Assamblyfile"
        Me.DataGridViewAutoFilterTextBoxColumn1.HeaderText = "ModuleID"
        Me.DataGridViewAutoFilterTextBoxColumn1.Name = "DataGridViewAutoFilterTextBoxColumn1"
        Me.DataGridViewAutoFilterTextBoxColumn1.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewAutoFilterTextBoxColumn2
        '
        Me.DataGridViewAutoFilterTextBoxColumn2.DataPropertyName = "ModuleName"
        Me.DataGridViewAutoFilterTextBoxColumn2.HeaderText = "ModuleName"
        Me.DataGridViewAutoFilterTextBoxColumn2.Name = "DataGridViewAutoFilterTextBoxColumn2"
        Me.DataGridViewAutoFilterTextBoxColumn2.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewAutoFilterTextBoxColumn3
        '
        Me.DataGridViewAutoFilterTextBoxColumn3.DataPropertyName = "Note"
        Me.DataGridViewAutoFilterTextBoxColumn3.HeaderText = "Note"
        Me.DataGridViewAutoFilterTextBoxColumn3.Name = "DataGridViewAutoFilterTextBoxColumn3"
        Me.DataGridViewAutoFilterTextBoxColumn3.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn3.Width = 200
        '
        'FrmModuleConnected
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 429)
        Me.Controls.Add(Me.gboGrid)
        Me.Controls.Add(Me.txtModuleV)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtModuleID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmModuleConnected"
        Me.ShowInTaskbar = False
        Me.Tag = "010101"
        Me.Text = "Module Connected"
        Me.gboGrid.ResumeLayout(False)
        Me.gboGrid.PerformLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bdn.ResumeLayout(False)
        Me.bdn.PerformLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gboGrid As System.Windows.Forms.GroupBox
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuLocked As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtModuleID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtModuleV As System.Windows.Forms.TextBox
    Friend WithEvents bdn As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAllow As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn1 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn2 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn3 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Assemblyfile As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ModuleName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Connected As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Note As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
End Class
