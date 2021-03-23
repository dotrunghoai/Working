<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOutDirectMaterial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOutDirectMaterial))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuPrintGSR = New System.Windows.Forms.ToolStripButton()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gridD = New UtilityControl.CustomDataGridView()
        Me.OutYMD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ECode = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DeptName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.JCode = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.SubPrcName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ECodeTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JCodeTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubPrcNameTemp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrcName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.JEName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JVName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.MinQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IssuingQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UsePurpose = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bnGrid = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsStock = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.chkLocked = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn8 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn5 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn7 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn4 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn3 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn2 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn6 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn1 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn9 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.CalendarColumn1 = New UtilityControl.CalendarColumn()
        Me.tlsMenu.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnGrid.SuspendLayout()
        Me.SuspendLayout()
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
        'mnuExport
        '
        Me.mnuExport.AutoSize = False
        Me.mnuExport.Image = CType(resources.GetObject("mnuExport.Image"), System.Drawing.Image)
        Me.mnuExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(60, 50)
        Me.mnuExport.Text = "Export"
        Me.mnuExport.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuPrintGSR
        '
        Me.mnuPrintGSR.AutoSize = False
        Me.mnuPrintGSR.Image = CType(resources.GetObject("mnuPrintGSR.Image"), System.Drawing.Image)
        Me.mnuPrintGSR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuPrintGSR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrintGSR.Name = "mnuPrintGSR"
        Me.mnuPrintGSR.Size = New System.Drawing.Size(60, 50)
        Me.mnuPrintGSR.Text = "Print"
        Me.mnuPrintGSR.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuPrintGSR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.mnuPrintGSR, Me.mnuDelete, Me.mnuImport, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tlsMenu.Size = New System.Drawing.Size(984, 55)
        Me.tlsMenu.TabIndex = 0
        Me.tlsMenu.Text = "ToolStrip1"
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
        Me.mnuShowAll.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.mnuImport.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridD)
        Me.GroupBox2.Controls.Add(Me.bnGrid)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(984, 637)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'gridD
        '
        Me.gridD.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridD.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OutYMD, Me.ECode, Me.DeptName, Me.JCode, Me.SubPrcName, Me.ECodeTemp, Me.JCodeTemp, Me.SubPrcNameTemp, Me.PrcName, Me.JEName, Me.JVName, Me.Unit, Me.MinQty, Me.IssuingQty, Me.UsePurpose, Me.Remarks, Me.CreateDate, Me.CreateUser})
        Me.gridD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridD.EnableHeadersVisualStyles = False
        Me.gridD.Location = New System.Drawing.Point(3, 16)
        Me.gridD.Name = "gridD"
        Me.gridD.RowHeadersWidth = 20
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gridD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridD.Size = New System.Drawing.Size(978, 593)
        Me.gridD.TabIndex = 0
        '
        'OutYMD
        '
        Me.OutYMD.DataPropertyName = "OutYMD"
        Me.OutYMD.HeaderText = "OutYMD"
        Me.OutYMD.Name = "OutYMD"
        Me.OutYMD.ReadOnly = True
        Me.OutYMD.Visible = False
        '
        'ECode
        '
        Me.ECode.DataPropertyName = "ECode"
        Me.ECode.HeaderText = "ECode"
        Me.ECode.Name = "ECode"
        Me.ECode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ECode.Width = 65
        '
        'DeptName
        '
        Me.DeptName.DataPropertyName = "DeptName"
        Me.DeptName.HeaderText = "DeptName"
        Me.DeptName.Name = "DeptName"
        Me.DeptName.ReadOnly = True
        Me.DeptName.Visible = False
        Me.DeptName.Width = 60
        '
        'JCode
        '
        Me.JCode.DataPropertyName = "JCode"
        Me.JCode.HeaderText = "JCode"
        Me.JCode.Name = "JCode"
        Me.JCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JCode.Width = 70
        '
        'SubPrcName
        '
        Me.SubPrcName.DataPropertyName = "SubPrcName"
        Me.SubPrcName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.SubPrcName.HeaderText = "Sub Process Name"
        Me.SubPrcName.Name = "SubPrcName"
        Me.SubPrcName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SubPrcName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ECodeTemp
        '
        Me.ECodeTemp.DataPropertyName = "ECodeTemp"
        Me.ECodeTemp.HeaderText = "ECodeTemp"
        Me.ECodeTemp.Name = "ECodeTemp"
        Me.ECodeTemp.Visible = False
        '
        'JCodeTemp
        '
        Me.JCodeTemp.DataPropertyName = "JCodeTemp"
        Me.JCodeTemp.HeaderText = "JCodeTemp"
        Me.JCodeTemp.Name = "JCodeTemp"
        Me.JCodeTemp.Visible = False
        '
        'SubPrcNameTemp
        '
        Me.SubPrcNameTemp.DataPropertyName = "SubPrcNameTemp"
        Me.SubPrcNameTemp.HeaderText = "SubPrcNameTemp"
        Me.SubPrcNameTemp.Name = "SubPrcNameTemp"
        Me.SubPrcNameTemp.Visible = False
        '
        'PrcName
        '
        Me.PrcName.DataPropertyName = "PrcName"
        Me.PrcName.HeaderText = "Process Name"
        Me.PrcName.Name = "PrcName"
        Me.PrcName.ReadOnly = True
        Me.PrcName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'JEName
        '
        Me.JEName.DataPropertyName = "JEName"
        Me.JEName.HeaderText = "English Material Name"
        Me.JEName.Name = "JEName"
        Me.JEName.ReadOnly = True
        Me.JEName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JEName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.JEName.Width = 120
        '
        'JVName
        '
        Me.JVName.DataPropertyName = "JVName"
        Me.JVName.HeaderText = "Vietnamese Material Name"
        Me.JVName.Name = "JVName"
        Me.JVName.ReadOnly = True
        Me.JVName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JVName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.JVName.Width = 120
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "Unit"
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Unit.Width = 60
        '
        'MinQty
        '
        Me.MinQty.DataPropertyName = "MinQty"
        Me.MinQty.HeaderText = "Min Qty"
        Me.MinQty.Name = "MinQty"
        Me.MinQty.ReadOnly = True
        Me.MinQty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MinQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.MinQty.Width = 60
        '
        'IssuingQty
        '
        Me.IssuingQty.DataPropertyName = "IssuingQty"
        Me.IssuingQty.HeaderText = "Issuing Qty"
        Me.IssuingQty.Name = "IssuingQty"
        Me.IssuingQty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IssuingQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.IssuingQty.Width = 80
        '
        'UsePurpose
        '
        Me.UsePurpose.DataPropertyName = "UsePurpose"
        Me.UsePurpose.HeaderText = "Note"
        Me.UsePurpose.Name = "UsePurpose"
        Me.UsePurpose.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UsePurpose.Width = 80
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Average using"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Remarks.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Remarks.Width = 80
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        DataGridViewCellStyle2.Format = "dd-MM-yyyy HH:mm"
        Me.CreateDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.CreateDate.HeaderText = "CreateDate"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.ReadOnly = True
        '
        'CreateUser
        '
        Me.CreateUser.DataPropertyName = "CreateUser"
        Me.CreateUser.HeaderText = "CreateUser"
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.ReadOnly = True
        Me.CreateUser.Width = 50
        '
        'bnGrid
        '
        Me.bnGrid.AddNewItem = Nothing
        Me.bnGrid.CountItem = Me.BindingNavigatorCountItem
        Me.bnGrid.DeleteItem = Nothing
        Me.bnGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ToolStripStatusLabel1, Me.tsStock})
        Me.bnGrid.Location = New System.Drawing.Point(3, 609)
        Me.bnGrid.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnGrid.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnGrid.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnGrid.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnGrid.Name = "bnGrid"
        Me.bnGrid.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnGrid.Size = New System.Drawing.Size(978, 25)
        Me.bnGrid.TabIndex = 38
        Me.bnGrid.Text = "BindingNavigator1"
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
        Me.BindingNavigatorPositionItem.Font = New System.Drawing.Font("Segoe UI", 9.0!)
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
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 20)
        Me.ToolStripStatusLabel1.Text = "Stock:"
        '
        'tsStock
        '
        Me.tsStock.ForeColor = System.Drawing.Color.Blue
        Me.tsStock.Name = "tsStock"
        Me.tsStock.Size = New System.Drawing.Size(13, 20)
        Me.tsStock.Text = "0"
        '
        'dtpOrderDate
        '
        Me.dtpOrderDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOrderDate.Location = New System.Drawing.Point(348, 20)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.Size = New System.Drawing.Size(98, 20)
        Me.dtpOrderDate.TabIndex = 1
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(319, 23)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(29, 14)
        Me.lblDay.TabIndex = 1
        Me.lblDay.Text = "Day:"
        '
        'chkLocked
        '
        Me.chkLocked.AutoSize = True
        Me.chkLocked.Enabled = False
        Me.chkLocked.Location = New System.Drawing.Point(452, 21)
        Me.chkLocked.Name = "chkLocked"
        Me.chkLocked.Size = New System.Drawing.Size(61, 18)
        Me.chkLocked.TabIndex = 2
        Me.chkLocked.Text = "Locked"
        Me.chkLocked.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "VenderName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Vender Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewAutoFilterTextBoxColumn8
        '
        Me.DataGridViewAutoFilterTextBoxColumn8.DataPropertyName = "Reason"
        Me.DataGridViewAutoFilterTextBoxColumn8.HeaderText = "Reason"
        Me.DataGridViewAutoFilterTextBoxColumn8.Name = "DataGridViewAutoFilterTextBoxColumn8"
        Me.DataGridViewAutoFilterTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewAutoFilterTextBoxColumn5
        '
        Me.DataGridViewAutoFilterTextBoxColumn5.DataPropertyName = "Unit"
        Me.DataGridViewAutoFilterTextBoxColumn5.HeaderText = "Unit"
        Me.DataGridViewAutoFilterTextBoxColumn5.Name = "DataGridViewAutoFilterTextBoxColumn5"
        Me.DataGridViewAutoFilterTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn5.Visible = False
        '
        'DataGridViewAutoFilterTextBoxColumn7
        '
        Me.DataGridViewAutoFilterTextBoxColumn7.DataPropertyName = "OrderDate"
        Me.DataGridViewAutoFilterTextBoxColumn7.HeaderText = "Order Date"
        Me.DataGridViewAutoFilterTextBoxColumn7.Name = "DataGridViewAutoFilterTextBoxColumn7"
        Me.DataGridViewAutoFilterTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewAutoFilterTextBoxColumn4
        '
        Me.DataGridViewAutoFilterTextBoxColumn4.DataPropertyName = "Quantity"
        Me.DataGridViewAutoFilterTextBoxColumn4.HeaderText = "Quantity"
        Me.DataGridViewAutoFilterTextBoxColumn4.Name = "DataGridViewAutoFilterTextBoxColumn4"
        Me.DataGridViewAutoFilterTextBoxColumn4.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewAutoFilterTextBoxColumn3
        '
        Me.DataGridViewAutoFilterTextBoxColumn3.DataPropertyName = "Air"
        Me.DataGridViewAutoFilterTextBoxColumn3.HeaderText = "Air"
        Me.DataGridViewAutoFilterTextBoxColumn3.Name = "DataGridViewAutoFilterTextBoxColumn3"
        Me.DataGridViewAutoFilterTextBoxColumn3.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DeliveryDate"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Delivery Date"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewAutoFilterTextBoxColumn2
        '
        Me.DataGridViewAutoFilterTextBoxColumn2.DataPropertyName = "PackingUnit"
        Me.DataGridViewAutoFilterTextBoxColumn2.HeaderText = "Packing Unit"
        Me.DataGridViewAutoFilterTextBoxColumn2.Name = "DataGridViewAutoFilterTextBoxColumn2"
        Me.DataGridViewAutoFilterTextBoxColumn2.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn2.Visible = False
        '
        'DataGridViewAutoFilterTextBoxColumn6
        '
        Me.DataGridViewAutoFilterTextBoxColumn6.DataPropertyName = "FullName"
        Me.DataGridViewAutoFilterTextBoxColumn6.HeaderText = "Employee"
        Me.DataGridViewAutoFilterTextBoxColumn6.Name = "DataGridViewAutoFilterTextBoxColumn6"
        Me.DataGridViewAutoFilterTextBoxColumn6.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewAutoFilterTextBoxColumn1
        '
        Me.DataGridViewAutoFilterTextBoxColumn1.DataPropertyName = "JName"
        Me.DataGridViewAutoFilterTextBoxColumn1.HeaderText = "JName"
        Me.DataGridViewAutoFilterTextBoxColumn1.Name = "DataGridViewAutoFilterTextBoxColumn1"
        Me.DataGridViewAutoFilterTextBoxColumn1.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "GSR ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "JCode"
        Me.DataGridViewTextBoxColumn1.HeaderText = "JCode"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewAutoFilterTextBoxColumn9
        '
        Me.DataGridViewAutoFilterTextBoxColumn9.DataPropertyName = "IsLock"
        Me.DataGridViewAutoFilterTextBoxColumn9.HeaderText = "IsLock"
        Me.DataGridViewAutoFilterTextBoxColumn9.Name = "DataGridViewAutoFilterTextBoxColumn9"
        Me.DataGridViewAutoFilterTextBoxColumn9.ReadOnly = True
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.HeaderText = "Delivery Date"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'FrmOutDirectMaterial
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 692)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chkLocked)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.dtpOrderDate)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmOutDirectMaterial"
        Me.Tag = "021207"
        Me.Text = "Output Direct Material"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnGrid.ResumeLayout(False)
        Me.bnGrid.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gridD As UtilityControl.CustomDataGridView
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuPrintGSR As System.Windows.Forms.ToolStripButton
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn8 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn5 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn7 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn4 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn3 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn2 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn6 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn1 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn9 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CalendarColumn1 As UtilityControl.CalendarColumn
    Friend WithEvents dtpOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents chkLocked As System.Windows.Forms.CheckBox
    Friend WithEvents bnGrid As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsStock As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
	Friend WithEvents OutYMD As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents ECode As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents DeptName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents JCode As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents SubPrcName As Windows.Forms.DataGridViewComboBoxColumn
	Friend WithEvents ECodeTemp As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents JCodeTemp As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents SubPrcNameTemp As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents PrcName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents JEName As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents JVName As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents Unit As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents MinQty As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents IssuingQty As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents UsePurpose As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents Remarks As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents CreateDate As Windows.Forms.DataGridViewTextBoxColumn
	Friend WithEvents CreateUser As Windows.Forms.DataGridViewTextBoxColumn
End Class
