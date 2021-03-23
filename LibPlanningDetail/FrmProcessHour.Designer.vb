<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcessHour
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcessHour))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuImport = New System.Windows.Forms.ToolStripButton()
        Me.mnuProduct = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.bnProcessHour = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtLeadtime = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.txtLeadtime2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.txtLT1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.txtLT2 = New System.Windows.Forms.ToolStripTextBox()
        Me.mnuSave = New System.Windows.Forms.ToolStripButton()
        Me.mnuDeelete = New System.Windows.Forms.ToolStripButton()
        Me.gridProcessHour = New UtilityControl.CustomDataGridView()
        Me.cboProduct = New System.Windows.Forms.ComboBox()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridCS = New UtilityControl.CustomDataGridView()
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Method = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadtimeCS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanDuoi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CanTren = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LTSTart = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LTEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Leadtime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadtimeSub = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Remark = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Leadtime2 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.CreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessNumber_K = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bnProcessHour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnProcessHour.SuspendLayout()
        CType(Me.gridProcessHour, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gridCS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuEdit, Me.ToolStripSeparator2, Me.mnuDelete, Me.mnuExport, Me.mnuImport, Me.mnuProduct, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(960, 55)
        Me.tlsMenu.TabIndex = 0
        '
        'mnuShowAll
        '
        Me.mnuShowAll.AutoSize = False
        Me.mnuShowAll.Image = CType(resources.GetObject("mnuShowAll.Image"), System.Drawing.Image)
        Me.mnuShowAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuShowAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuShowAll.Name = "mnuShowAll"
        Me.mnuShowAll.Size = New System.Drawing.Size(60, 50)
        Me.mnuShowAll.Text = "Show All"
        Me.mnuShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuShowAll.ToolTipText = "Show All (F5)"
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
        Me.mnuEdit.ToolTipText = "Edit (Ctrl + E)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
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
        Me.mnuDelete.ToolTipText = "Delete (Ctrl+D)"
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
        'mnuProduct
        '
        Me.mnuProduct.AutoSize = False
        Me.mnuProduct.Image = CType(resources.GetObject("mnuProduct.Image"), System.Drawing.Image)
        Me.mnuProduct.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuProduct.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuProduct.Name = "mnuProduct"
        Me.mnuProduct.Size = New System.Drawing.Size(74, 50)
        Me.mnuProduct.Text = "Product List"
        Me.mnuProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuProduct.ToolTipText = "Product List"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
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
        'bnProcessHour
        '
        Me.bnProcessHour.AddNewItem = Nothing
        Me.bnProcessHour.CountItem = Me.BindingNavigatorCountItem
        Me.bnProcessHour.DeleteItem = Nothing
        Me.bnProcessHour.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnProcessHour.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ToolStripLabel1, Me.txtLeadtime, Me.ToolStripLabel2, Me.txtLeadtime2, Me.ToolStripLabel3, Me.txtLT1, Me.ToolStripLabel4, Me.txtLT2, Me.mnuSave, Me.mnuDeelete})
        Me.bnProcessHour.Location = New System.Drawing.Point(0, 410)
        Me.bnProcessHour.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnProcessHour.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnProcessHour.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnProcessHour.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnProcessHour.Name = "bnProcessHour"
        Me.bnProcessHour.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnProcessHour.Size = New System.Drawing.Size(960, 25)
        Me.bnProcessHour.TabIndex = 22
        Me.bnProcessHour.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripLabel1.Text = "Leadtime 1:"
        '
        'txtLeadtime
        '
        Me.txtLeadtime.BackColor = System.Drawing.Color.Khaki
        Me.txtLeadtime.Name = "txtLeadtime"
        Me.txtLeadtime.Size = New System.Drawing.Size(60, 25)
        Me.txtLeadtime.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripLabel2.Text = "Leadtime 2:"
        '
        'txtLeadtime2
        '
        Me.txtLeadtime2.BackColor = System.Drawing.Color.Khaki
        Me.txtLeadtime2.Name = "txtLeadtime2"
        Me.txtLeadtime2.Size = New System.Drawing.Size(60, 25)
        Me.txtLeadtime2.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripLabel3.Text = "LT1:"
        '
        'txtLT1
        '
        Me.txtLT1.BackColor = System.Drawing.Color.Khaki
        Me.txtLT1.Name = "txtLT1"
        Me.txtLT1.Size = New System.Drawing.Size(60, 25)
        Me.txtLT1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripLabel4.Text = "LT2:"
        '
        'txtLT2
        '
        Me.txtLT2.BackColor = System.Drawing.Color.Khaki
        Me.txtLT2.Name = "txtLT2"
        Me.txtLT2.Size = New System.Drawing.Size(60, 25)
        Me.txtLT2.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'mnuSave
        '
        Me.mnuSave.Image = CType(resources.GetObject("mnuSave.Image"), System.Drawing.Image)
        Me.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(51, 22)
        Me.mnuSave.Text = "Save"
        '
        'mnuDeelete
        '
        Me.mnuDeelete.Image = CType(resources.GetObject("mnuDeelete.Image"), System.Drawing.Image)
        Me.mnuDeelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuDeelete.Name = "mnuDeelete"
        Me.mnuDeelete.Size = New System.Drawing.Size(60, 22)
        Me.mnuDeelete.Text = "Delete"
        '
        'gridProcessHour
        '
        Me.gridProcessHour.AllowUserToAddRows = False
        Me.gridProcessHour.AllowUserToDeleteRows = False
        Me.gridProcessHour.AllowUserToOrderColumns = True
        Me.gridProcessHour.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridProcessHour.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridProcessHour.BackgroundColor = System.Drawing.SystemColors.Control
        Me.gridProcessHour.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridProcessHour.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProcessNumber, Me.ProcessName, Me.Leadtime, Me.LeadtimeSub, Me.Remark, Me.Leadtime2, Me.CreateUser, Me.CreateDate, Me.UpdateUser, Me.UpdateDate, Me.ProcessNumber_K})
        Me.gridProcessHour.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridProcessHour.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridProcessHour.EnableHeadersVisualStyles = False
        Me.gridProcessHour.Location = New System.Drawing.Point(0, 0)
        Me.gridProcessHour.Name = "gridProcessHour"
        Me.gridProcessHour.RowHeadersWidth = 15
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridProcessHour.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridProcessHour.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridProcessHour.Size = New System.Drawing.Size(505, 355)
        Me.gridProcessHour.TabIndex = 23
        '
        'cboProduct
        '
        Me.cboProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(391, 27)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(160, 21)
        Me.cboProduct.TabIndex = 29
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(391, 9)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(44, 13)
        Me.lblProcess.TabIndex = 28
        Me.lblProcess.Text = "Product"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridProcessHour)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridCS)
        Me.SplitContainer1.Size = New System.Drawing.Size(960, 355)
        Me.SplitContainer1.SplitterDistance = 505
        Me.SplitContainer1.TabIndex = 30
        '
        'gridCS
        '
        Me.gridCS.AllowUserToDeleteRows = False
        Me.gridCS.AllowUserToOrderColumns = True
        Me.gridCS.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridCS.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridCS.BackgroundColor = System.Drawing.SystemColors.Control
        Me.gridCS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Customer, Me.Method, Me.LeadtimeCS, Me.CanDuoi, Me.CanTren, Me.LTSTart, Me.LTEnd})
        Me.gridCS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridCS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridCS.EnableHeadersVisualStyles = False
        Me.gridCS.Location = New System.Drawing.Point(0, 0)
        Me.gridCS.Name = "gridCS"
        Me.gridCS.RowHeadersWidth = 15
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridCS.RowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gridCS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridCS.Size = New System.Drawing.Size(451, 355)
        Me.gridCS.TabIndex = 24
        '
        'Customer
        '
        Me.Customer.DataPropertyName = "Customer"
        Me.Customer.HeaderText = "Customer"
        Me.Customer.Name = "Customer"
        '
        'Method
        '
        Me.Method.DataPropertyName = "Method"
        Me.Method.HeaderText = "Method"
        Me.Method.Name = "Method"
        Me.Method.Width = 60
        '
        'LeadtimeCS
        '
        Me.LeadtimeCS.DataPropertyName = "Leadtime"
        Me.LeadtimeCS.HeaderText = "Leadtime"
        Me.LeadtimeCS.Name = "LeadtimeCS"
        Me.LeadtimeCS.Width = 60
        '
        'CanDuoi
        '
        Me.CanDuoi.DataPropertyName = "CanDuoi"
        Me.CanDuoi.HeaderText = "Cận dưới"
        Me.CanDuoi.Name = "CanDuoi"
        Me.CanDuoi.Width = 60
        '
        'CanTren
        '
        Me.CanTren.DataPropertyName = "CanTren"
        Me.CanTren.HeaderText = "Cận trên"
        Me.CanTren.Name = "CanTren"
        Me.CanTren.Width = 60
        '
        'LTSTart
        '
        Me.LTSTart.DataPropertyName = "LTSTart"
        Me.LTSTart.HeaderText = "LTStart"
        Me.LTSTart.Name = "LTSTart"
        Me.LTSTart.ReadOnly = True
        Me.LTSTart.Width = 60
        '
        'LTEnd
        '
        Me.LTEnd.DataPropertyName = "LTEnd"
        Me.LTEnd.HeaderText = "LTEnd"
        Me.LTEnd.Name = "LTEnd"
        Me.LTEnd.ReadOnly = True
        Me.LTEnd.Width = 60
        '
        'ProcessNumber
        '
        Me.ProcessNumber.DataPropertyName = "ProcessNumber"
        Me.ProcessNumber.HeaderText = "Pn"
        Me.ProcessNumber.Name = "ProcessNumber"
        Me.ProcessNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessNumber.Width = 30
        '
        'ProcessName
        '
        Me.ProcessName.DataPropertyName = "ProcessName"
        Me.ProcessName.HeaderText = "Process"
        Me.ProcessName.Name = "ProcessName"
        Me.ProcessName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Leadtime
        '
        Me.Leadtime.DataPropertyName = "Leadtime"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.Leadtime.DefaultCellStyle = DataGridViewCellStyle2
        Me.Leadtime.HeaderText = "TGGC (Hr)"
        Me.Leadtime.Name = "Leadtime"
        Me.Leadtime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Leadtime.Width = 60
        '
        'LeadtimeSub
        '
        Me.LeadtimeSub.DataPropertyName = "LeadtimeSub"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.LeadtimeSub.DefaultCellStyle = DataGridViewCellStyle3
        Me.LeadtimeSub.HeaderText = "TGGCSub (Hr)"
        Me.LeadtimeSub.Name = "LeadtimeSub"
        Me.LeadtimeSub.Width = 60
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "Remark"
        Me.Remark.Name = "Remark"
        Me.Remark.Width = 60
        '
        'Leadtime2
        '
        Me.Leadtime2.DataPropertyName = "Leadtime2"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Leadtime2.DefaultCellStyle = DataGridViewCellStyle4
        Me.Leadtime2.HeaderText = "Leadtime2 (Hr)"
        Me.Leadtime2.Name = "Leadtime2"
        Me.Leadtime2.Width = 60
        '
        'CreateUser
        '
        Me.CreateUser.DataPropertyName = "CreateUser"
        Me.CreateUser.HeaderText = "CreateUser"
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CreateUser.Width = 50
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        Me.CreateDate.HeaderText = "CreateDate"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CreateDate.Width = 80
        '
        'UpdateUser
        '
        Me.UpdateUser.DataPropertyName = "UpdateUser"
        Me.UpdateUser.HeaderText = "UpdateUser"
        Me.UpdateUser.Name = "UpdateUser"
        Me.UpdateUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UpdateUser.Visible = False
        Me.UpdateUser.Width = 50
        '
        'UpdateDate
        '
        Me.UpdateDate.DataPropertyName = "UpdateDate"
        Me.UpdateDate.HeaderText = "UpdateDate"
        Me.UpdateDate.Name = "UpdateDate"
        Me.UpdateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UpdateDate.Visible = False
        Me.UpdateDate.Width = 80
        '
        'ProcessNumber_K
        '
        Me.ProcessNumber_K.DataPropertyName = "ProcessNumber_K"
        Me.ProcessNumber_K.HeaderText = "ProcessNumber_K"
        Me.ProcessNumber_K.Name = "ProcessNumber_K"
        Me.ProcessNumber_K.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessNumber_K.Visible = False
        Me.ProcessNumber_K.Width = 20
        '
        'FrmProcessHour
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 435)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cboProduct)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.bnProcessHour)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmProcessHour"
        Me.ShowInTaskbar = False
        Me.Tag = "0254PD03"
        Me.Text = "Tiến độ giờ"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bnProcessHour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnProcessHour.ResumeLayout(False)
        Me.bnProcessHour.PerformLayout()
        CType(Me.gridProcessHour, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gridCS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnProcessHour As System.Windows.Forms.BindingNavigator
    Friend WithEvents gridProcessHour As UtilityControl.CustomDataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents mnuProduct As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtLeadtime As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtLeadtime2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gridCS As UtilityControl.CustomDataGridView
    Friend WithEvents Customer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Method As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadtimeCS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanDuoi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanTren As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LTSTart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LTEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtLT1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtLT2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDeelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProcessNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Leadtime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadtimeSub As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Remark As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Leadtime2 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents CreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessNumber_K As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
