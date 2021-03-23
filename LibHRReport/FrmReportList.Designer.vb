<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportList
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportList))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.DocNo = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DocName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.CreateUser = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.CreateDate = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.gridR = New System.Windows.Forms.DataGridView()
        Me.Observation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridEmail = New System.Windows.Forms.DataGridView()
        Me.Checked = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtDocNo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblDocName = New System.Windows.Forms.Label()
        Me.txtDocName = New System.Windows.Forms.TextBox()
        Me.DataGridViewAutoFilterTextBoxColumn1 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn2 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn3 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn4 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bdn.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.gridR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AllowUserToOrderColumns = True
        Me.grid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.BackgroundColor = System.Drawing.Color.White
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DocNo, Me.DocName, Me.CreateUser, Me.CreateDate})
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Location = New System.Drawing.Point(0, 0)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.RowHeadersWidth = 20
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(574, 357)
        Me.grid.TabIndex = 12
        '
        'DocNo
        '
        Me.DocNo.DataPropertyName = "DocNo"
        Me.DocNo.HeaderText = "DocNo"
        Me.DocNo.Name = "DocNo"
        Me.DocNo.ReadOnly = True
        '
        'DocName
        '
        Me.DocName.DataPropertyName = "DocName"
        Me.DocName.HeaderText = "DocName"
        Me.DocName.Name = "DocName"
        Me.DocName.ReadOnly = True
        Me.DocName.Width = 200
        '
        'CreateUser
        '
        Me.CreateUser.DataPropertyName = "CreateUser"
        Me.CreateUser.HeaderText = "CreateUser"
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.ReadOnly = True
        Me.CreateUser.Width = 50
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        Me.CreateDate.HeaderText = "CreateDate"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.ReadOnly = True
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.mnuDelete, Me.mnuSave, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(953, 58)
        Me.tlsMenu.TabIndex = 13
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
        Me.mnuExport.ToolTipText = "Export(Ctrl+E)"
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
        Me.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuDelete.ToolTipText = "Delete"
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
        Me.mnuSave.ToolTipText = "Save"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
        '
        'bdn
        '
        Me.bdn.AddNewItem = Nothing
        Me.bdn.CountItem = Me.BindingNavigatorCountItem
        Me.bdn.DeleteItem = Nothing
        Me.bdn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bdn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bdn.Location = New System.Drawing.Point(0, 415)
        Me.bdn.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bdn.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bdn.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bdn.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bdn.Name = "bdn"
        Me.bdn.PositionItem = Me.BindingNavigatorPositionItem
        Me.bdn.Size = New System.Drawing.Size(953, 25)
        Me.bdn.TabIndex = 14
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
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 58)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grid)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(953, 357)
        Me.SplitContainer1.SplitterDistance = 574
        Me.SplitContainer1.TabIndex = 15
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.gridR)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.gridEmail)
        Me.SplitContainer2.Size = New System.Drawing.Size(375, 357)
        Me.SplitContainer2.SplitterDistance = 136
        Me.SplitContainer2.TabIndex = 14
        '
        'gridR
        '
        Me.gridR.AllowUserToAddRows = False
        Me.gridR.AllowUserToDeleteRows = False
        Me.gridR.AllowUserToOrderColumns = True
        Me.gridR.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridR.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gridR.BackgroundColor = System.Drawing.Color.White
        Me.gridR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Observation})
        Me.gridR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridR.Location = New System.Drawing.Point(0, 0)
        Me.gridR.Name = "gridR"
        Me.gridR.RowHeadersWidth = 20
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridR.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridR.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridR.Size = New System.Drawing.Size(375, 136)
        Me.gridR.TabIndex = 13
        '
        'Observation
        '
        Me.Observation.DataPropertyName = "Observation"
        Me.Observation.HeaderText = "Observation"
        Me.Observation.Name = "Observation"
        Me.Observation.ReadOnly = True
        Me.Observation.Width = 200
        '
        'gridEmail
        '
        Me.gridEmail.AllowUserToAddRows = False
        Me.gridEmail.AllowUserToDeleteRows = False
        Me.gridEmail.AllowUserToOrderColumns = True
        Me.gridEmail.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridEmail.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridEmail.BackgroundColor = System.Drawing.Color.White
        Me.gridEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridEmail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Checked, Me.Email})
        Me.gridEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridEmail.Location = New System.Drawing.Point(0, 0)
        Me.gridEmail.Name = "gridEmail"
        Me.gridEmail.RowHeadersWidth = 20
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridEmail.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridEmail.Size = New System.Drawing.Size(375, 217)
        Me.gridEmail.TabIndex = 14
        '
        'Checked
        '
        Me.Checked.DataPropertyName = "Checked"
        Me.Checked.HeaderText = "Checked"
        Me.Checked.Name = "Checked"
        Me.Checked.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Checked.Width = 50
        '
        'Email
        '
        Me.Email.DataPropertyName = "Email"
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Width = 200
        '
        'txtDocNo
        '
        Me.txtDocNo.Location = New System.Drawing.Point(278, 23)
        Me.txtDocNo.MaxLength = 15
        Me.txtDocNo.Name = "txtDocNo"
        Me.txtDocNo.Size = New System.Drawing.Size(100, 20)
        Me.txtDocNo.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(275, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "DocNo"
        '
        'lblDocName
        '
        Me.lblDocName.AutoSize = True
        Me.lblDocName.Location = New System.Drawing.Point(381, 7)
        Me.lblDocName.Name = "lblDocName"
        Me.lblDocName.Size = New System.Drawing.Size(55, 13)
        Me.lblDocName.TabIndex = 19
        Me.lblDocName.Text = "DocName"
        '
        'txtDocName
        '
        Me.txtDocName.Location = New System.Drawing.Point(384, 23)
        Me.txtDocName.MaxLength = 255
        Me.txtDocName.Name = "txtDocName"
        Me.txtDocName.Size = New System.Drawing.Size(268, 20)
        Me.txtDocName.TabIndex = 18
        '
        'DataGridViewAutoFilterTextBoxColumn1
        '
        Me.DataGridViewAutoFilterTextBoxColumn1.DataPropertyName = "DocNo"
        Me.DataGridViewAutoFilterTextBoxColumn1.HeaderText = "DocNo"
        Me.DataGridViewAutoFilterTextBoxColumn1.Name = "DataGridViewAutoFilterTextBoxColumn1"
        '
        'DataGridViewAutoFilterTextBoxColumn2
        '
        Me.DataGridViewAutoFilterTextBoxColumn2.DataPropertyName = "DocName"
        Me.DataGridViewAutoFilterTextBoxColumn2.HeaderText = "DocName"
        Me.DataGridViewAutoFilterTextBoxColumn2.Name = "DataGridViewAutoFilterTextBoxColumn2"
        Me.DataGridViewAutoFilterTextBoxColumn2.Width = 200
        '
        'DataGridViewAutoFilterTextBoxColumn3
        '
        Me.DataGridViewAutoFilterTextBoxColumn3.DataPropertyName = "CreateUser"
        Me.DataGridViewAutoFilterTextBoxColumn3.HeaderText = "CreateUser"
        Me.DataGridViewAutoFilterTextBoxColumn3.Name = "DataGridViewAutoFilterTextBoxColumn3"
        Me.DataGridViewAutoFilterTextBoxColumn3.Width = 50
        '
        'DataGridViewAutoFilterTextBoxColumn4
        '
        Me.DataGridViewAutoFilterTextBoxColumn4.DataPropertyName = "CreateDate"
        Me.DataGridViewAutoFilterTextBoxColumn4.HeaderText = "CreateDate"
        Me.DataGridViewAutoFilterTextBoxColumn4.Name = "DataGridViewAutoFilterTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Observation"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Observation"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 200
        '
        'FrmReportList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 440)
        Me.Controls.Add(Me.lblDocName)
        Me.Controls.Add(Me.txtDocName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDocNo)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.bdn)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmReportList"
        Me.Tag = "025001"
        Me.Text = "Danh sách báo cáo"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bdn.ResumeLayout(False)
        Me.bdn.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.gridR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gridR As System.Windows.Forms.DataGridView
    Friend WithEvents DocNo As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DocName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents CreateUser As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents CreateDate As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents txtDocNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblDocName As System.Windows.Forms.Label
    Friend WithEvents txtDocName As System.Windows.Forms.TextBox
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn1 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn2 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn3 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn4 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Observation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gridEmail As System.Windows.Forms.DataGridView
    Friend WithEvents Checked As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
