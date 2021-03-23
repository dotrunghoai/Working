

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDefine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDefine))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuImport = New System.Windows.Forms.ToolStripButton()
        Me.mnuView = New System.Windows.Forms.ToolStripButton()
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
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.ProductCode = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Process = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.DataGridViewAutoFilterTextBoxColumn1 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn2 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn3 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn4 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn5 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn6 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn7 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn8 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn9 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn10 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn11 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn12 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn13 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn14 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn15 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn16 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn17 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bdn.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.mnuDelete, Me.mnuImport, Me.mnuView, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(938, 51)
        Me.tlsMenu.TabIndex = 75
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
        Me.mnuExport.ToolTipText = "Export"
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
        'mnuImport
        '
        Me.mnuImport.AutoSize = False
        Me.mnuImport.Image = CType(resources.GetObject("mnuImport.Image"), System.Drawing.Image)
        Me.mnuImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuImport.Name = "mnuImport"
        Me.mnuImport.Size = New System.Drawing.Size(60, 50)
        Me.mnuImport.Text = "Import"
        Me.mnuImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuImport.ToolTipText = "Import"
        '
        'mnuView
        '
        Me.mnuView.AutoSize = False
        Me.mnuView.Image = CType(resources.GetObject("mnuView.Image"), System.Drawing.Image)
        Me.mnuView.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Size = New System.Drawing.Size(60, 50)
        Me.mnuView.Text = "View"
        Me.mnuView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuView.ToolTipText = "View"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 51)
        '
        'bdn
        '
        Me.bdn.AddNewItem = Nothing
        Me.bdn.CountItem = Me.BindingNavigatorCountItem
        Me.bdn.DeleteItem = Nothing
        Me.bdn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bdn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bdn.Location = New System.Drawing.Point(0, 458)
        Me.bdn.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bdn.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bdn.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bdn.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bdn.Name = "bdn"
        Me.bdn.PositionItem = Me.BindingNavigatorPositionItem
        Me.bdn.Size = New System.Drawing.Size(938, 25)
        Me.bdn.TabIndex = 77
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
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductCode, Me.Process})
        Me.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grid.EnableHeadersVisualStyles = False
        Me.grid.Location = New System.Drawing.Point(0, 54)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.RowHeadersWidth = 20
        Me.grid.Size = New System.Drawing.Size(938, 401)
        Me.grid.TabIndex = 78
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "ProductCode"
        Me.ProductCode.HeaderText = "ProductCode"
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.ReadOnly = True
        Me.ProductCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductCode.Width = 70
        '
        'Process
        '
        Me.Process.DataPropertyName = "Process"
        Me.Process.HeaderText = "Process"
        Me.Process.Name = "Process"
        Me.Process.ReadOnly = True
        Me.Process.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(340, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSearch.Location = New System.Drawing.Point(340, 22)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(100, 20)
        Me.txtSearch.TabIndex = 80
        '
        'DataGridViewAutoFilterTextBoxColumn1
        '
        Me.DataGridViewAutoFilterTextBoxColumn1.DataPropertyName = "ProductCode"
        Me.DataGridViewAutoFilterTextBoxColumn1.HeaderText = "ProductCode"
        Me.DataGridViewAutoFilterTextBoxColumn1.Name = "DataGridViewAutoFilterTextBoxColumn1"
        Me.DataGridViewAutoFilterTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn1.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn2
        '
        Me.DataGridViewAutoFilterTextBoxColumn2.DataPropertyName = "Process"
        Me.DataGridViewAutoFilterTextBoxColumn2.HeaderText = "Process"
        Me.DataGridViewAutoFilterTextBoxColumn2.Name = "DataGridViewAutoFilterTextBoxColumn2"
        Me.DataGridViewAutoFilterTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn2.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn3
        '
        Me.DataGridViewAutoFilterTextBoxColumn3.DataPropertyName = "Item"
        Me.DataGridViewAutoFilterTextBoxColumn3.HeaderText = "Item"
        Me.DataGridViewAutoFilterTextBoxColumn3.Name = "DataGridViewAutoFilterTextBoxColumn3"
        Me.DataGridViewAutoFilterTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn3.Width = 60
        '
        'DataGridViewAutoFilterTextBoxColumn4
        '
        Me.DataGridViewAutoFilterTextBoxColumn4.DataPropertyName = "N"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewAutoFilterTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewAutoFilterTextBoxColumn4.HeaderText = "N"
        Me.DataGridViewAutoFilterTextBoxColumn4.Name = "DataGridViewAutoFilterTextBoxColumn4"
        Me.DataGridViewAutoFilterTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn4.Width = 50
        '
        'DataGridViewAutoFilterTextBoxColumn5
        '
        Me.DataGridViewAutoFilterTextBoxColumn5.DataPropertyName = "Spec"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewAutoFilterTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewAutoFilterTextBoxColumn5.HeaderText = "Spec"
        Me.DataGridViewAutoFilterTextBoxColumn5.Name = "DataGridViewAutoFilterTextBoxColumn5"
        Me.DataGridViewAutoFilterTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn5.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn6
        '
        Me.DataGridViewAutoFilterTextBoxColumn6.DataPropertyName = "UTL"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewAutoFilterTextBoxColumn6.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewAutoFilterTextBoxColumn6.HeaderText = "UTL"
        Me.DataGridViewAutoFilterTextBoxColumn6.Name = "DataGridViewAutoFilterTextBoxColumn6"
        Me.DataGridViewAutoFilterTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn6.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn7
        '
        Me.DataGridViewAutoFilterTextBoxColumn7.DataPropertyName = "LTL"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewAutoFilterTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewAutoFilterTextBoxColumn7.HeaderText = "LTL"
        Me.DataGridViewAutoFilterTextBoxColumn7.Name = "DataGridViewAutoFilterTextBoxColumn7"
        Me.DataGridViewAutoFilterTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn7.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn8
        '
        Me.DataGridViewAutoFilterTextBoxColumn8.DataPropertyName = "USL"
        Me.DataGridViewAutoFilterTextBoxColumn8.HeaderText = "USL"
        Me.DataGridViewAutoFilterTextBoxColumn8.Name = "DataGridViewAutoFilterTextBoxColumn8"
        Me.DataGridViewAutoFilterTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn8.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn9
        '
        Me.DataGridViewAutoFilterTextBoxColumn9.DataPropertyName = "LSL"
        Me.DataGridViewAutoFilterTextBoxColumn9.HeaderText = "LSL"
        Me.DataGridViewAutoFilterTextBoxColumn9.Name = "DataGridViewAutoFilterTextBoxColumn9"
        Me.DataGridViewAutoFilterTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn9.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn10
        '
        Me.DataGridViewAutoFilterTextBoxColumn10.DataPropertyName = "UTLMC"
        Me.DataGridViewAutoFilterTextBoxColumn10.HeaderText = "UTLMC"
        Me.DataGridViewAutoFilterTextBoxColumn10.Name = "DataGridViewAutoFilterTextBoxColumn10"
        Me.DataGridViewAutoFilterTextBoxColumn10.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn10.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn11
        '
        Me.DataGridViewAutoFilterTextBoxColumn11.DataPropertyName = "LTLMC"
        Me.DataGridViewAutoFilterTextBoxColumn11.HeaderText = "LTLMC"
        Me.DataGridViewAutoFilterTextBoxColumn11.Name = "DataGridViewAutoFilterTextBoxColumn11"
        Me.DataGridViewAutoFilterTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn11.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn12
        '
        Me.DataGridViewAutoFilterTextBoxColumn12.DataPropertyName = "UMC"
        Me.DataGridViewAutoFilterTextBoxColumn12.HeaderText = "UMC"
        Me.DataGridViewAutoFilterTextBoxColumn12.Name = "DataGridViewAutoFilterTextBoxColumn12"
        Me.DataGridViewAutoFilterTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn12.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn13
        '
        Me.DataGridViewAutoFilterTextBoxColumn13.DataPropertyName = "LMC"
        Me.DataGridViewAutoFilterTextBoxColumn13.HeaderText = "LMC"
        Me.DataGridViewAutoFilterTextBoxColumn13.Name = "DataGridViewAutoFilterTextBoxColumn13"
        Me.DataGridViewAutoFilterTextBoxColumn13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn13.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn14
        '
        Me.DataGridViewAutoFilterTextBoxColumn14.DataPropertyName = "CPK"
        Me.DataGridViewAutoFilterTextBoxColumn14.HeaderText = "CPK"
        Me.DataGridViewAutoFilterTextBoxColumn14.Name = "DataGridViewAutoFilterTextBoxColumn14"
        Me.DataGridViewAutoFilterTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn14.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn15
        '
        Me.DataGridViewAutoFilterTextBoxColumn15.DataPropertyName = "CPM"
        Me.DataGridViewAutoFilterTextBoxColumn15.HeaderText = "CPM"
        Me.DataGridViewAutoFilterTextBoxColumn15.Name = "DataGridViewAutoFilterTextBoxColumn15"
        Me.DataGridViewAutoFilterTextBoxColumn15.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn15.Width = 70
        '
        'DataGridViewAutoFilterTextBoxColumn16
        '
        Me.DataGridViewAutoFilterTextBoxColumn16.DataPropertyName = "CreateDate"
        DataGridViewCellStyle5.Format = "dd-MM-yyyy"
        Me.DataGridViewAutoFilterTextBoxColumn16.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewAutoFilterTextBoxColumn16.HeaderText = "CreateDate"
        Me.DataGridViewAutoFilterTextBoxColumn16.Name = "DataGridViewAutoFilterTextBoxColumn16"
        '
        'DataGridViewAutoFilterTextBoxColumn17
        '
        Me.DataGridViewAutoFilterTextBoxColumn17.DataPropertyName = "CreateUser"
        Me.DataGridViewAutoFilterTextBoxColumn17.HeaderText = "CreateUser"
        Me.DataGridViewAutoFilterTextBoxColumn17.Name = "DataGridViewAutoFilterTextBoxColumn17"
        Me.DataGridViewAutoFilterTextBoxColumn17.Width = 60
        '
        'FrmDefine
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 483)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.bdn)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmDefine"
        Me.Tag = "0243QCG01"
        Me.Text = "Define"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bdn.ResumeLayout(False)
        Me.bdn.PerformLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tlsMenu As Windows.Forms.ToolStrip
    Friend WithEvents mnuShowAll As Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As Windows.Forms.ToolStripButton
    Friend WithEvents mnuImport As Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents bdn As Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As Windows.Forms.ToolStripSeparator
    Friend WithEvents grid As Windows.Forms.DataGridView
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents txtSearch As Windows.Forms.TextBox
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn1 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn2 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn3 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn4 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn5 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn6 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn7 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn8 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn9 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn10 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn11 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn12 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn13 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn14 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn15 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn16 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn17 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProductCode As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Process As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents mnuView As Windows.Forms.ToolStripButton
End Class
