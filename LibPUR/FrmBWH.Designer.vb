<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBWH
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBWH))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.gridH = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalendarColumn1 = New UtilityControl.CalendarColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridViewAutoFilterTextBoxColumn6 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn9 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn7 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn8 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.bnGridD = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn5 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.chkOrderDate = New System.Windows.Forms.CheckBox()
        Me.DataGridViewAutoFilterTextBoxColumn4 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.mnuDeleteUnit = New System.Windows.Forms.ToolStripButton()
        Me.dtpOrderDateEnd = New System.Windows.Forms.DateTimePicker()
        Me.mnuExportJC = New System.Windows.Forms.ToolStripButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuPrint = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuNew = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gridD = New UtilityControl.CustomDataGridView()
        Me.OrderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StockWS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Air = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DeliveryDate = New UtilityControl.CalendarColumn()
        Me.LastVendorCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastVendorName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Note = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceivedQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceivedDate = New UtilityControl.CalendarColumn()
        Me.RemainQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemainDate = New UtilityControl.CalendarColumn()
        Me.dtpOrderDate = New System.Windows.Forms.DateTimePicker()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn1 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn3 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DataGridViewAutoFilterTextBoxColumn2 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuEZProcure = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.cboSection = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.ID = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Employee = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Section = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.OrderDate = New UtilityControl.CalendarColumn()
        Me.Reason = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.IsLock = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        CType(Me.gridH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnGrid.SuspendLayout()
        CType(Me.bnGridD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnGridD.SuspendLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        CType(Me.cboSection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(732, 23)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(105, 20)
        Me.txtID.TabIndex = 5
        Me.txtID.Visible = False
        '
        'gridH
        '
        Me.gridH.AllowUserToAddRows = False
        Me.gridH.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridH.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridH.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridH.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Employee, Me.Section, Me.OrderDate, Me.Reason, Me.IsLock})
        Me.gridH.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gridH.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridH.EnableHeadersVisualStyles = False
        Me.gridH.Location = New System.Drawing.Point(0, 424)
        Me.gridH.Name = "gridH"
        Me.gridH.ReadOnly = True
        Me.gridH.RowHeadersWidth = 20
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridH.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridH.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridH.Size = New System.Drawing.Size(984, 243)
        Me.gridH.TabIndex = 38
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "VenderName"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Vender Name"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.HeaderText = "Delivery Date"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn4.HeaderText = "GSR ID"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'bnGrid
        '
        Me.bnGrid.AddNewItem = Nothing
        Me.bnGrid.CountItem = Me.BindingNavigatorCountItem
        Me.bnGrid.DeleteItem = Nothing
        Me.bnGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bnGrid.Location = New System.Drawing.Point(0, 667)
        Me.bnGrid.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnGrid.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnGrid.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnGrid.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnGrid.Name = "bnGrid"
        Me.bnGrid.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnGrid.Size = New System.Drawing.Size(984, 25)
        Me.bnGrid.TabIndex = 39
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
        'DataGridViewAutoFilterTextBoxColumn6
        '
        Me.DataGridViewAutoFilterTextBoxColumn6.DataPropertyName = "FullName"
        Me.DataGridViewAutoFilterTextBoxColumn6.HeaderText = "Employee"
        Me.DataGridViewAutoFilterTextBoxColumn6.Name = "DataGridViewAutoFilterTextBoxColumn6"
        Me.DataGridViewAutoFilterTextBoxColumn6.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewAutoFilterTextBoxColumn9
        '
        Me.DataGridViewAutoFilterTextBoxColumn9.DataPropertyName = "IsLock"
        Me.DataGridViewAutoFilterTextBoxColumn9.HeaderText = "IsLock"
        Me.DataGridViewAutoFilterTextBoxColumn9.Name = "DataGridViewAutoFilterTextBoxColumn9"
        Me.DataGridViewAutoFilterTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewAutoFilterTextBoxColumn7
        '
        Me.DataGridViewAutoFilterTextBoxColumn7.DataPropertyName = "OrderDate"
        Me.DataGridViewAutoFilterTextBoxColumn7.HeaderText = "Order Date"
        Me.DataGridViewAutoFilterTextBoxColumn7.Name = "DataGridViewAutoFilterTextBoxColumn7"
        Me.DataGridViewAutoFilterTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewAutoFilterTextBoxColumn8
        '
        Me.DataGridViewAutoFilterTextBoxColumn8.DataPropertyName = "Reason"
        Me.DataGridViewAutoFilterTextBoxColumn8.HeaderText = "Reason"
        Me.DataGridViewAutoFilterTextBoxColumn8.Name = "DataGridViewAutoFilterTextBoxColumn8"
        Me.DataGridViewAutoFilterTextBoxColumn8.ReadOnly = True
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.AccessibleName = "Position"
        Me.ToolStripTextBox1.AutoSize = False
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox1.Text = "0"
        Me.ToolStripTextBox1.ToolTipText = "Current position"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Move previous"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Move last"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "Move first"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "Move next"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "of {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
        '
        'bnGridD
        '
        Me.bnGridD.AddNewItem = Nothing
        Me.bnGridD.CountItem = Me.ToolStripLabel1
        Me.bnGridD.DeleteItem = Nothing
        Me.bnGridD.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnGridD.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator1, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator3})
        Me.bnGridD.Location = New System.Drawing.Point(0, 399)
        Me.bnGridD.MoveFirstItem = Me.ToolStripButton1
        Me.bnGridD.MoveLastItem = Me.ToolStripButton4
        Me.bnGridD.MoveNextItem = Me.ToolStripButton3
        Me.bnGridD.MovePreviousItem = Me.ToolStripButton2
        Me.bnGridD.Name = "bnGridD"
        Me.bnGridD.PositionItem = Me.ToolStripTextBox1
        Me.bnGridD.Size = New System.Drawing.Size(984, 25)
        Me.bnGridD.TabIndex = 40
        Me.bnGridD.Text = "BindingNavigator1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
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
        'DataGridViewAutoFilterTextBoxColumn5
        '
        Me.DataGridViewAutoFilterTextBoxColumn5.DataPropertyName = "Unit"
        Me.DataGridViewAutoFilterTextBoxColumn5.HeaderText = "Unit"
        Me.DataGridViewAutoFilterTextBoxColumn5.Name = "DataGridViewAutoFilterTextBoxColumn5"
        Me.DataGridViewAutoFilterTextBoxColumn5.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewAutoFilterTextBoxColumn5.Visible = False
        '
        'chkOrderDate
        '
        Me.chkOrderDate.AutoSize = True
        Me.chkOrderDate.Checked = True
        Me.chkOrderDate.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOrderDate.Location = New System.Drawing.Point(504, 27)
        Me.chkOrderDate.Name = "chkOrderDate"
        Me.chkOrderDate.Size = New System.Drawing.Size(15, 14)
        Me.chkOrderDate.TabIndex = 1
        Me.chkOrderDate.UseVisualStyleBackColor = True
        '
        'DataGridViewAutoFilterTextBoxColumn4
        '
        Me.DataGridViewAutoFilterTextBoxColumn4.DataPropertyName = "Quantity"
        Me.DataGridViewAutoFilterTextBoxColumn4.HeaderText = "Quantity"
        Me.DataGridViewAutoFilterTextBoxColumn4.Name = "DataGridViewAutoFilterTextBoxColumn4"
        Me.DataGridViewAutoFilterTextBoxColumn4.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'mnuDeleteUnit
        '
        Me.mnuDeleteUnit.AutoSize = False
        Me.mnuDeleteUnit.Image = CType(resources.GetObject("mnuDeleteUnit.Image"), System.Drawing.Image)
        Me.mnuDeleteUnit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuDeleteUnit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuDeleteUnit.Name = "mnuDeleteUnit"
        Me.mnuDeleteUnit.Size = New System.Drawing.Size(65, 50)
        Me.mnuDeleteUnit.Text = "Delete Unit"
        Me.mnuDeleteUnit.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuDeleteUnit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'dtpOrderDateEnd
        '
        Me.dtpOrderDateEnd.CustomFormat = "dd/MM/yyyy"
        Me.dtpOrderDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOrderDateEnd.Location = New System.Drawing.Point(638, 24)
        Me.dtpOrderDateEnd.Name = "dtpOrderDateEnd"
        Me.dtpOrderDateEnd.Size = New System.Drawing.Size(88, 20)
        Me.dtpOrderDateEnd.TabIndex = 3
        '
        'mnuExportJC
        '
        Me.mnuExportJC.AutoSize = False
        Me.mnuExportJC.Image = CType(resources.GetObject("mnuExportJC.Image"), System.Drawing.Image)
        Me.mnuExportJC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuExportJC.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuExportJC.Name = "mnuExportJC"
        Me.mnuExportJC.Size = New System.Drawing.Size(60, 50)
        Me.mnuExportJC.Text = "Export JC"
        Me.mnuExportJC.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuExportJC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(613, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 14)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "==>"
        '
        'mnuDelete
        '
        Me.mnuDelete.AutoSize = False
        Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
        Me.mnuDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(60, 50)
        Me.mnuDelete.Text = "Delete All"
        Me.mnuDelete.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuPrint
        '
        Me.mnuPrint.AutoSize = False
        Me.mnuPrint.Image = CType(resources.GetObject("mnuPrint.Image"), System.Drawing.Image)
        Me.mnuPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(60, 50)
        Me.mnuPrint.Text = "Print BWH"
        Me.mnuPrint.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuExport
        '
        Me.mnuExport.AutoSize = False
        Me.mnuExport.Image = CType(resources.GetObject("mnuExport.Image"), System.Drawing.Image)
        Me.mnuExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(65, 50)
        Me.mnuExport.Text = "ExportBWH"
        Me.mnuExport.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.mnuNew.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(525, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 14)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order Date"
        '
        'gridD
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gridD.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OrderID, Me.StockWS, Me.JCode, Me.JName, Me.LeadTime, Me.MinQty, Me.Unit, Me.Air, Me.Quantity, Me.DeliveryDate, Me.LastVendorCode, Me.LastVendorName, Me.Note, Me.ReceivedQty, Me.ReceivedDate, Me.RemainQty, Me.RemainDate})
        Me.gridD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridD.EnableHeadersVisualStyles = False
        Me.gridD.Location = New System.Drawing.Point(0, 55)
        Me.gridD.Name = "gridD"
        Me.gridD.RowHeadersWidth = 20
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gridD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridD.Size = New System.Drawing.Size(984, 344)
        Me.gridD.TabIndex = 35
        '
        'OrderID
        '
        Me.OrderID.DataPropertyName = "OrderID"
        Me.OrderID.HeaderText = "Order ID"
        Me.OrderID.Name = "OrderID"
        Me.OrderID.ReadOnly = True
        Me.OrderID.Visible = False
        '
        'StockWS
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.StockWS.DefaultCellStyle = DataGridViewCellStyle4
        Me.StockWS.HeaderText = "StockWS"
        Me.StockWS.Name = "StockWS"
        Me.StockWS.Width = 55
        '
        'JCode
        '
        Me.JCode.DataPropertyName = "JCode"
        Me.JCode.HeaderText = "JCode"
        Me.JCode.Name = "JCode"
        Me.JCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.JCode.Width = 50
        '
        'JName
        '
        Me.JName.DataPropertyName = "JName"
        Me.JName.HeaderText = "JName"
        Me.JName.Name = "JName"
        Me.JName.ReadOnly = True
        Me.JName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.JName.Width = 230
        '
        'LeadTime
        '
        Me.LeadTime.DataPropertyName = "LeadTime"
        Me.LeadTime.HeaderText = "LeadTime (Week)"
        Me.LeadTime.Name = "LeadTime"
        Me.LeadTime.Width = 80
        '
        'MinQty
        '
        Me.MinQty.DataPropertyName = "MinQty"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.MinQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.MinQty.HeaderText = "MOQ"
        Me.MinQty.Name = "MinQty"
        Me.MinQty.ReadOnly = True
        Me.MinQty.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.MinQty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.MinQty.Width = 55
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "Unit"
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Unit.Width = 40
        '
        'Air
        '
        Me.Air.DataPropertyName = "Air"
        Me.Air.HeaderText = "Means of transport"
        Me.Air.Name = "Air"
        Me.Air.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Air.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Air.Width = 60
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.Quantity.HeaderText = "Order Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Quantity.Width = 70
        '
        'DeliveryDate
        '
        Me.DeliveryDate.DataPropertyName = "DeliveryDate"
        DataGridViewCellStyle7.Format = "dd-MM-yyyy"
        Me.DeliveryDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.DeliveryDate.HeaderText = "Date of MGR"
        Me.DeliveryDate.Name = "DeliveryDate"
        Me.DeliveryDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DeliveryDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'LastVendorCode
        '
        Me.LastVendorCode.DataPropertyName = "LastVendorCode"
        Me.LastVendorCode.HeaderText = "Last Vendor Code"
        Me.LastVendorCode.Name = "LastVendorCode"
        Me.LastVendorCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LastVendorCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.LastVendorCode.Visible = False
        '
        'LastVendorName
        '
        Me.LastVendorName.DataPropertyName = "LastVendorName"
        Me.LastVendorName.HeaderText = "Last Vendor Name"
        Me.LastVendorName.Name = "LastVendorName"
        Me.LastVendorName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LastVendorName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.LastVendorName.Visible = False
        '
        'Note
        '
        Me.Note.DataPropertyName = "Note"
        Me.Note.HeaderText = "Note"
        Me.Note.Name = "Note"
        Me.Note.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Note.Width = 300
        '
        'ReceivedQty
        '
        Me.ReceivedQty.DataPropertyName = "ReceivedQty"
        Me.ReceivedQty.HeaderText = "Received Qty"
        Me.ReceivedQty.Name = "ReceivedQty"
        Me.ReceivedQty.Width = 80
        '
        'ReceivedDate
        '
        Me.ReceivedDate.DataPropertyName = "ReceivedDate"
        DataGridViewCellStyle8.Format = "dd-MM-yyyy"
        Me.ReceivedDate.DefaultCellStyle = DataGridViewCellStyle8
        Me.ReceivedDate.HeaderText = "ReceivedDate"
        Me.ReceivedDate.Name = "ReceivedDate"
        '
        'RemainQty
        '
        Me.RemainQty.DataPropertyName = "RemainQty"
        Me.RemainQty.HeaderText = "Remain Qty"
        Me.RemainQty.Name = "RemainQty"
        Me.RemainQty.Width = 80
        '
        'RemainDate
        '
        Me.RemainDate.DataPropertyName = "RemainDate"
        DataGridViewCellStyle9.Format = "dd-MM-yyyy"
        Me.RemainDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.RemainDate.HeaderText = "Remain Date"
        Me.RemainDate.Name = "RemainDate"
        Me.RemainDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.RemainDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'dtpOrderDate
        '
        Me.dtpOrderDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOrderDate.Location = New System.Drawing.Point(525, 24)
        Me.dtpOrderDate.Name = "dtpOrderDate"
        Me.dtpOrderDate.Size = New System.Drawing.Size(88, 20)
        Me.dtpOrderDate.TabIndex = 2
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
        'DataGridViewAutoFilterTextBoxColumn1
        '
        Me.DataGridViewAutoFilterTextBoxColumn1.DataPropertyName = "JName"
        Me.DataGridViewAutoFilterTextBoxColumn1.HeaderText = "JName"
        Me.DataGridViewAutoFilterTextBoxColumn1.Name = "DataGridViewAutoFilterTextBoxColumn1"
        Me.DataGridViewAutoFilterTextBoxColumn1.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewAutoFilterTextBoxColumn3
        '
        Me.DataGridViewAutoFilterTextBoxColumn3.DataPropertyName = "Air"
        Me.DataGridViewAutoFilterTextBoxColumn3.HeaderText = "Air"
        Me.DataGridViewAutoFilterTextBoxColumn3.Name = "DataGridViewAutoFilterTextBoxColumn3"
        Me.DataGridViewAutoFilterTextBoxColumn3.ReadOnly = True
        Me.DataGridViewAutoFilterTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
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
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuShowAll, Me.mnuExport, Me.mnuPrint, Me.mnuDeleteUnit, Me.mnuExportJC, Me.mnuDelete, Me.mnuEZProcure, Me.ToolStripSeparator4})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tlsMenu.Size = New System.Drawing.Size(984, 55)
        Me.tlsMenu.TabIndex = 36
        Me.tlsMenu.Text = "ToolStrip1"
        '
        'mnuEZProcure
        '
        Me.mnuEZProcure.AutoSize = False
        Me.mnuEZProcure.Image = CType(resources.GetObject("mnuEZProcure.Image"), System.Drawing.Image)
        Me.mnuEZProcure.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuEZProcure.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuEZProcure.Name = "mnuEZProcure"
        Me.mnuEZProcure.Size = New System.Drawing.Size(60, 50)
        Me.mnuEZProcure.Text = "EZProCure"
        Me.mnuEZProcure.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuEZProcure.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 55)
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(843, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(35, 13)
        Me.LabelControl1.TabIndex = 42
        Me.LabelControl1.Text = "Section"
        '
        'cboSection
        '
        Me.cboSection.Location = New System.Drawing.Point(843, 23)
        Me.cboSection.Name = "cboSection"
        Me.cboSection.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cboSection.Properties.Items.AddRange(New Object() {"CIS", "PP", "PE"})
        Me.cboSection.Size = New System.Drawing.Size(100, 20)
        Me.cboSection.TabIndex = 41
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "BWH No"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Employee
        '
        Me.Employee.DataPropertyName = "FullName"
        Me.Employee.HeaderText = "ECode"
        Me.Employee.Name = "Employee"
        Me.Employee.ReadOnly = True
        Me.Employee.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Employee.Width = 65
        '
        'Section
        '
        Me.Section.DataPropertyName = "Department"
        Me.Section.HeaderText = "Section"
        Me.Section.Name = "Section"
        Me.Section.ReadOnly = True
        Me.Section.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Section.Width = 50
        '
        'OrderDate
        '
        Me.OrderDate.DataPropertyName = "OrderDate"
        Me.OrderDate.HeaderText = "Order Date"
        Me.OrderDate.Name = "OrderDate"
        Me.OrderDate.ReadOnly = True
        Me.OrderDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OrderDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'Reason
        '
        Me.Reason.DataPropertyName = "Reason"
        Me.Reason.HeaderText = "Reason"
        Me.Reason.Name = "Reason"
        Me.Reason.ReadOnly = True
        Me.Reason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Reason.Visible = False
        Me.Reason.Width = 60
        '
        'IsLock
        '
        Me.IsLock.DataPropertyName = "IsLock"
        Me.IsLock.HeaderText = "IsLock"
        Me.IsLock.Name = "IsLock"
        Me.IsLock.ReadOnly = True
        Me.IsLock.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsLock.Width = 60
        '
        'FrmBWH
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 692)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.cboSection)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.chkOrderDate)
        Me.Controls.Add(Me.gridD)
        Me.Controls.Add(Me.dtpOrderDateEnd)
        Me.Controls.Add(Me.bnGridD)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.gridH)
        Me.Controls.Add(Me.bnGrid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpOrderDate)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmBWH"
        Me.Tag = "020804"
        Me.Text = "Incoming BWH"
        CType(Me.gridH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnGrid.ResumeLayout(False)
        Me.bnGrid.PerformLayout()
        CType(Me.bnGridD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnGridD.ResumeLayout(False)
        Me.bnGridD.PerformLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.cboSection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents gridH As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn1 As UtilityControl.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn6 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn9 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn7 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn8 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bnGridD As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn5 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents chkOrderDate As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn4 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents mnuDeleteUnit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpOrderDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents mnuExportJC As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gridD As UtilityControl.CustomDataGridView
    Friend WithEvents dtpOrderDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn1 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn3 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DataGridViewAutoFilterTextBoxColumn2 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuEZProcure As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OrderID As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockWS As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JCode As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JName As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTime As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinQty As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Air As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeliveryDate As UtilityControl.CalendarColumn
    Friend WithEvents LastVendorCode As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastVendorName As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Note As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedQty As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedDate As UtilityControl.CalendarColumn
    Friend WithEvents RemainQty As Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RemainDate As UtilityControl.CalendarColumn
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cboSection As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents ID As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Employee As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Section As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents OrderDate As UtilityControl.CalendarColumn
    Friend WithEvents Reason As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents IsLock As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
End Class
