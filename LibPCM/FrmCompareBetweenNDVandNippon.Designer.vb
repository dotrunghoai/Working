<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompareBetweenNDVandNippon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompareBetweenNDVandNippon))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuPrintGSR = New System.Windows.Forms.ToolStripButton()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuStockOld = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuUpdateAdjust = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gridD = New UtilityControl.CustomDataGridView()
        Me.JCode = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.JName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.MinQty = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Unit = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ActQty = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.NipponQty = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.NDVQty = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Nipp_Act = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Nipp_NDV = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
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
        Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.txtJCode = New System.Windows.Forms.TextBox()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFilterDifference = New System.Windows.Forms.Label()
        Me.cboDifference = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoAll = New System.Windows.Forms.RadioButton()
        Me.rdoJCode = New System.Windows.Forms.RadioButton()
        Me.rdoItemCode = New System.Windows.Forms.RadioButton()
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
        Me.mnuSendMail = New System.Windows.Forms.ToolStripButton()
        Me.tlsMenu.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnGrid.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.mnuPrintGSR, Me.mnuStockOld, Me.ToolStripSeparator1, Me.mnuUpdateAdjust, Me.ToolStripSeparator2, Me.mnuSendMail})
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
        'mnuStockOld
        '
        Me.mnuStockOld.AutoSize = False
        Me.mnuStockOld.Image = CType(resources.GetObject("mnuStockOld.Image"), System.Drawing.Image)
        Me.mnuStockOld.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuStockOld.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuStockOld.Name = "mnuStockOld"
        Me.mnuStockOld.Size = New System.Drawing.Size(80, 50)
        Me.mnuStockOld.Text = "StockOld"
        Me.mnuStockOld.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuStockOld.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuStockOld.ToolTipText = "Import Stock"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'mnuUpdateAdjust
        '
        Me.mnuUpdateAdjust.AutoSize = False
        Me.mnuUpdateAdjust.Image = CType(resources.GetObject("mnuUpdateAdjust.Image"), System.Drawing.Image)
        Me.mnuUpdateAdjust.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuUpdateAdjust.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuUpdateAdjust.Name = "mnuUpdateAdjust"
        Me.mnuUpdateAdjust.Size = New System.Drawing.Size(80, 50)
        Me.mnuUpdateAdjust.Text = "UpdateAdjust"
        Me.mnuUpdateAdjust.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuUpdateAdjust.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuUpdateAdjust.ToolTipText = "UpdateAdjust"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
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
        Me.gridD.AllowUserToAddRows = False
        Me.gridD.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gridD.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JCode, Me.JName, Me.MinQty, Me.Unit, Me.ActQty, Me.NipponQty, Me.NDVQty, Me.Nipp_Act, Me.Nipp_NDV})
        Me.gridD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridD.EnableHeadersVisualStyles = False
        Me.gridD.Location = New System.Drawing.Point(3, 16)
        Me.gridD.Name = "gridD"
        Me.gridD.ReadOnly = True
        Me.gridD.RowHeadersWidth = 20
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridD.Size = New System.Drawing.Size(978, 593)
        Me.gridD.TabIndex = 0
        '
        'JCode
        '
        Me.JCode.DataPropertyName = "JCode"
        Me.JCode.HeaderText = "JCode"
        Me.JCode.Name = "JCode"
        Me.JCode.ReadOnly = True
        Me.JCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JCode.Width = 70
        '
        'JName
        '
        Me.JName.DataPropertyName = "JName"
        Me.JName.HeaderText = "JName"
        Me.JName.Name = "JName"
        Me.JName.ReadOnly = True
        Me.JName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JName.Width = 120
        '
        'MinQty
        '
        Me.MinQty.DataPropertyName = "MinQty"
        Me.MinQty.HeaderText = "Min Qty"
        Me.MinQty.Name = "MinQty"
        Me.MinQty.ReadOnly = True
        Me.MinQty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MinQty.Width = 60
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
        'ActQty
        '
        Me.ActQty.DataPropertyName = "ActQty"
        Me.ActQty.HeaderText = "Act Qty"
        Me.ActQty.Name = "ActQty"
        Me.ActQty.ReadOnly = True
        Me.ActQty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ActQty.Width = 80
        '
        'NipponQty
        '
        Me.NipponQty.DataPropertyName = "NipponQty"
        Me.NipponQty.HeaderText = "Nippon Qty"
        Me.NipponQty.Name = "NipponQty"
        Me.NipponQty.ReadOnly = True
        Me.NipponQty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NipponQty.Width = 80
        '
        'NDVQty
        '
        Me.NDVQty.DataPropertyName = "NDVQty"
        Me.NDVQty.HeaderText = "NDV Qty"
        Me.NDVQty.Name = "NDVQty"
        Me.NDVQty.ReadOnly = True
        Me.NDVQty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.NDVQty.Width = 80
        '
        'Nipp_Act
        '
        Me.Nipp_Act.DataPropertyName = "Nipp_Act"
        Me.Nipp_Act.HeaderText = "Difference (Nipp_Act)"
        Me.Nipp_Act.Name = "Nipp_Act"
        Me.Nipp_Act.ReadOnly = True
        Me.Nipp_Act.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Nipp_Act.Width = 90
        '
        'Nipp_NDV
        '
        Me.Nipp_NDV.DataPropertyName = "Nipp_NDV"
        Me.Nipp_NDV.HeaderText = "Difference (Nipp_NDV)"
        Me.Nipp_NDV.Name = "Nipp_NDV"
        Me.Nipp_NDV.ReadOnly = True
        Me.Nipp_NDV.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Nipp_NDV.Width = 90
        '
        'bnGrid
        '
        Me.bnGrid.AddNewItem = Nothing
        Me.bnGrid.CountItem = Me.BindingNavigatorCountItem
        Me.bnGrid.DeleteItem = Nothing
        Me.bnGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bnGrid.Location = New System.Drawing.Point(3, 609)
        Me.bnGrid.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnGrid.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnGrid.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnGrid.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnGrid.Name = "bnGrid"
        Me.bnGrid.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnGrid.Size = New System.Drawing.Size(978, 25)
        Me.bnGrid.TabIndex = 34
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
        'dtpOrderDate
        '
        Me.dtpOrderDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOrderDate.Location = New System.Drawing.Point(443, 20)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.Size = New System.Drawing.Size(88, 20)
        Me.dtpOrderDate.TabIndex = 1
        '
        'txtJCode
        '
        Me.txtJCode.Location = New System.Drawing.Point(537, 20)
        Me.txtJCode.Name = "txtJCode"
        Me.txtJCode.Size = New System.Drawing.Size(74, 20)
        Me.txtJCode.TabIndex = 2
        '
        'lblDay
        '
        Me.lblDay.AutoSize = True
        Me.lblDay.Location = New System.Drawing.Point(443, 7)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(30, 13)
        Me.lblDay.TabIndex = 1
        Me.lblDay.Text = "Day:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(537, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Filter JCode"
        '
        'lblFilterDifference
        '
        Me.lblFilterDifference.AutoSize = True
        Me.lblFilterDifference.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFilterDifference.Location = New System.Drawing.Point(617, 6)
        Me.lblFilterDifference.Name = "lblFilterDifference"
        Me.lblFilterDifference.Size = New System.Drawing.Size(84, 13)
        Me.lblFilterDifference.TabIndex = 13
        Me.lblFilterDifference.Text = "Filter Difference"
        '
        'cboDifference
        '
        Me.cboDifference.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboDifference.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDifference.FormattingEnabled = True
        Me.cboDifference.Location = New System.Drawing.Point(617, 19)
        Me.cboDifference.Name = "cboDifference"
        Me.cboDifference.Size = New System.Drawing.Size(84, 21)
        Me.cboDifference.TabIndex = 12
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoAll)
        Me.GroupBox3.Controls.Add(Me.rdoJCode)
        Me.GroupBox3.Controls.Add(Me.rdoItemCode)
        Me.GroupBox3.Location = New System.Drawing.Point(707, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(191, 49)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Visible = False
        '
        'rdoAll
        '
        Me.rdoAll.AutoSize = True
        Me.rdoAll.Location = New System.Drawing.Point(145, 19)
        Me.rdoAll.Name = "rdoAll"
        Me.rdoAll.Size = New System.Drawing.Size(36, 17)
        Me.rdoAll.TabIndex = 2
        Me.rdoAll.Text = "All"
        Me.rdoAll.UseVisualStyleBackColor = True
        '
        'rdoJCode
        '
        Me.rdoJCode.AutoSize = True
        Me.rdoJCode.Location = New System.Drawing.Point(84, 19)
        Me.rdoJCode.Name = "rdoJCode"
        Me.rdoJCode.Size = New System.Drawing.Size(55, 17)
        Me.rdoJCode.TabIndex = 1
        Me.rdoJCode.Text = "JCode"
        Me.rdoJCode.UseVisualStyleBackColor = True
        '
        'rdoItemCode
        '
        Me.rdoItemCode.AutoSize = True
        Me.rdoItemCode.Checked = True
        Me.rdoItemCode.Location = New System.Drawing.Point(6, 19)
        Me.rdoItemCode.Name = "rdoItemCode"
        Me.rdoItemCode.Size = New System.Drawing.Size(72, 17)
        Me.rdoItemCode.TabIndex = 0
        Me.rdoItemCode.TabStop = True
        Me.rdoItemCode.Text = "ItemCode"
        Me.rdoItemCode.UseVisualStyleBackColor = True
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
        'mnuSendMail
        '
        Me.mnuSendMail.AutoSize = False
        Me.mnuSendMail.Image = CType(resources.GetObject("mnuSendMail.Image"), System.Drawing.Image)
        Me.mnuSendMail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSendMail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSendMail.Name = "mnuSendMail"
        Me.mnuSendMail.Size = New System.Drawing.Size(80, 50)
        Me.mnuSendMail.Text = "SendMail"
        Me.mnuSendMail.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuSendMail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuSendMail.ToolTipText = "SendMail"
        '
        'FrmCompareBetweenNDVandNippon
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 692)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.lblFilterDifference)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cboDifference)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpOrderDate)
        Me.Controls.Add(Me.txtJCode)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.KeyPreview = True
        Me.Name = "FrmCompareBetweenNDVandNippon"
        Me.Tag = "021208"
        Me.Text = "Compare Between NDV and Nippon"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnGrid.ResumeLayout(False)
        Me.bnGrid.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents txtJCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents lblFilterDifference As System.Windows.Forms.Label
    Friend WithEvents cboDifference As System.Windows.Forms.ComboBox
    Friend WithEvents mnuStockOld As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoAll As System.Windows.Forms.RadioButton
    Friend WithEvents rdoJCode As System.Windows.Forms.RadioButton
    Friend WithEvents rdoItemCode As System.Windows.Forms.RadioButton
    Friend WithEvents gridD As UtilityControl.CustomDataGridView
    Friend WithEvents JCode As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents JName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents MinQty As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Unit As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ActQty As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents NipponQty As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents NDVQty As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Nipp_Act As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Nipp_NDV As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents mnuUpdateAdjust As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSendMail As Windows.Forms.ToolStripButton
End Class
