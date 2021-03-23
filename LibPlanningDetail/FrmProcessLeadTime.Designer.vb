<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProcessLeadTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcessLeadTime))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
        Me.mnuBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.bsProductLeadTime = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsProductLeadTime = New System.Data.DataSet()
        Me.tblProductLeadTime = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.DataColumn7 = New System.Data.DataColumn()
        Me.DataColumn8 = New System.Data.DataColumn()
        Me.DataColumn9 = New System.Data.DataColumn()
        Me.DataColumn10 = New System.Data.DataColumn()
        Me.DataColumn11 = New System.Data.DataColumn()
        Me.DataColumn12 = New System.Data.DataColumn()
        Me.DataColumn13 = New System.Data.DataColumn()
        Me.DataColumn14 = New System.Data.DataColumn()
        Me.DataColumn15 = New System.Data.DataColumn()
        Me.DataColumn16 = New System.Data.DataColumn()
        Me.DataColumn17 = New System.Data.DataColumn()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.bnProductLeadTime = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.cboLeadTime = New System.Windows.Forms.ComboBox()
        Me.lblLeadTime = New System.Windows.Forms.Label()
        Me.gridProductLeadTime = New UtilityControl.CustomDataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Idx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadTimeID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ProcessNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessNumberParent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadTimePn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReportGroupCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ProcessGroup = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.CreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID_K = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bsProductLeadTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsProductLeadTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblProductLeadTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnProductLeadTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnProductLeadTime.SuspendLayout()
        CType(Me.gridProductLeadTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuEdit, Me.mnuBack, Me.ToolStripSeparator2, Me.mnuExport, Me.mnuShowAll, Me.mnuDelete, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(910, 55)
        Me.tlsMenu.TabIndex = 0
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
        'mnuBack
        '
        Me.mnuBack.AutoSize = False
        Me.mnuBack.Image = CType(resources.GetObject("mnuBack.Image"), System.Drawing.Image)
        Me.mnuBack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuBack.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuBack.Name = "mnuBack"
        Me.mnuBack.Size = New System.Drawing.Size(60, 50)
        Me.mnuBack.Text = "Back"
        Me.mnuBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuBack.ToolTipText = "Back"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
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
        Me.mnuShowAll.ToolTipText = "Show All"
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
        Me.mnuDelete.Text = "Del Rows"
        Me.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuDelete.ToolTipText = "Delete CD (Ctrl+D)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'bsProductLeadTime
        '
        Me.bsProductLeadTime.DataMember = "tblProductLeadTime"
        Me.bsProductLeadTime.DataSource = Me.dsProductLeadTime
        '
        'dsProductLeadTime
        '
        Me.dsProductLeadTime.DataSetName = "NewDataSet"
        Me.dsProductLeadTime.Tables.AddRange(New System.Data.DataTable() {Me.tblProductLeadTime})
        '
        'tblProductLeadTime
        '
        Me.tblProductLeadTime.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn8, Me.DataColumn9, Me.DataColumn10, Me.DataColumn11, Me.DataColumn12, Me.DataColumn13, Me.DataColumn14, Me.DataColumn15, Me.DataColumn16, Me.DataColumn17})
        Me.tblProductLeadTime.TableName = "tblProductLeadTime"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "ID"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "LeadTimeID"
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "ProcessCode"
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "ProcessName"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "ProcessNumber"
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "ProcessNumberParent"
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "Description"
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "LeadTime"
        Me.DataColumn8.DataType = GetType(Short)
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "LeadTimePn"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "ReportGroupCode"
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "Idx"
        Me.DataColumn11.DataType = GetType(Byte)
        '
        'DataColumn12
        '
        Me.DataColumn12.ColumnName = "CreateDate"
        Me.DataColumn12.DataType = GetType(Date)
        '
        'DataColumn13
        '
        Me.DataColumn13.ColumnName = "CreateUser"
        '
        'DataColumn14
        '
        Me.DataColumn14.ColumnName = "ID_K"
        '
        'DataColumn15
        '
        Me.DataColumn15.ColumnName = "ProcessGroup"
        Me.DataColumn15.DataType = GetType(Byte)
        '
        'DataColumn16
        '
        Me.DataColumn16.ColumnName = "UpdateDate"
        Me.DataColumn16.DataType = GetType(Date)
        '
        'DataColumn17
        '
        Me.DataColumn17.ColumnName = "UpdateUser"
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
        'bnProductLeadTime
        '
        Me.bnProductLeadTime.AddNewItem = Nothing
        Me.bnProductLeadTime.CountItem = Me.BindingNavigatorCountItem
        Me.bnProductLeadTime.DeleteItem = Nothing
        Me.bnProductLeadTime.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnProductLeadTime.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bnProductLeadTime.Location = New System.Drawing.Point(0, 410)
        Me.bnProductLeadTime.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnProductLeadTime.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnProductLeadTime.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnProductLeadTime.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnProductLeadTime.Name = "bnProductLeadTime"
        Me.bnProductLeadTime.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnProductLeadTime.Size = New System.Drawing.Size(910, 25)
        Me.bnProductLeadTime.TabIndex = 22
        Me.bnProductLeadTime.Text = "BindingNavigator1"
        '
        'cboLeadTime
        '
        Me.cboLeadTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLeadTime.FormattingEnabled = True
        Me.cboLeadTime.Location = New System.Drawing.Point(315, 28)
        Me.cboLeadTime.Name = "cboLeadTime"
        Me.cboLeadTime.Size = New System.Drawing.Size(150, 21)
        Me.cboLeadTime.TabIndex = 27
        '
        'lblLeadTime
        '
        Me.lblLeadTime.AutoSize = True
        Me.lblLeadTime.Location = New System.Drawing.Point(315, 11)
        Me.lblLeadTime.Name = "lblLeadTime"
        Me.lblLeadTime.Size = New System.Drawing.Size(54, 13)
        Me.lblLeadTime.TabIndex = 26
        Me.lblLeadTime.Text = "LeadTime"
        '
        'gridProductLeadTime
        '
        Me.gridProductLeadTime.AllowUserToAddRows = False
        Me.gridProductLeadTime.AllowUserToDeleteRows = False
        Me.gridProductLeadTime.AllowUserToOrderColumns = True
        Me.gridProductLeadTime.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridProductLeadTime.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridProductLeadTime.AutoGenerateColumns = False
        Me.gridProductLeadTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridProductLeadTime.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Idx, Me.LeadTimeID, Me.ProcessCode, Me.ProcessName, Me.ProcessNumber, Me.ProcessNumberParent, Me.Description, Me.LeadTime, Me.LeadTimePn, Me.ReportGroupCode, Me.ProcessGroup, Me.CreateDate, Me.CreateUser, Me.UpdateDate, Me.UpdateUser, Me.ID_K})
        Me.gridProductLeadTime.DataSource = Me.bsProductLeadTime
        Me.gridProductLeadTime.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridProductLeadTime.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridProductLeadTime.EnableHeadersVisualStyles = False
        Me.gridProductLeadTime.Location = New System.Drawing.Point(0, 55)
        Me.gridProductLeadTime.Name = "gridProductLeadTime"
        Me.gridProductLeadTime.RowHeadersWidth = 15
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridProductLeadTime.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.gridProductLeadTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridProductLeadTime.Size = New System.Drawing.Size(910, 355)
        Me.gridProductLeadTime.TabIndex = 23
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ID.Visible = False
        '
        'Idx
        '
        Me.Idx.DataPropertyName = "Idx"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Idx.DefaultCellStyle = DataGridViewCellStyle2
        Me.Idx.HeaderText = "No."
        Me.Idx.Name = "Idx"
        Me.Idx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Idx.Width = 55
        '
        'LeadTimeID
        '
        Me.LeadTimeID.DataPropertyName = "LeadTimeID"
        Me.LeadTimeID.HeaderText = "LeadTimeID"
        Me.LeadTimeID.Name = "LeadTimeID"
        Me.LeadTimeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LeadTimeID.Visible = False
        '
        'ProcessCode
        '
        Me.ProcessCode.DataPropertyName = "ProcessCode"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ProcessCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.ProcessCode.HeaderText = "PrcCode"
        Me.ProcessCode.MaxInputLength = 4
        Me.ProcessCode.Name = "ProcessCode"
        Me.ProcessCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProcessName
        '
        Me.ProcessName.DataPropertyName = "ProcessName"
        Me.ProcessName.HeaderText = "PrcName"
        Me.ProcessName.Name = "ProcessName"
        Me.ProcessName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProcessName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProcessNumber
        '
        Me.ProcessNumber.DataPropertyName = "ProcessNumber"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ProcessNumber.DefaultCellStyle = DataGridViewCellStyle4
        Me.ProcessNumber.HeaderText = "Pn"
        Me.ProcessNumber.MaxInputLength = 2
        Me.ProcessNumber.Name = "ProcessNumber"
        Me.ProcessNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProcessNumberParent
        '
        Me.ProcessNumberParent.DataPropertyName = "ProcessNumberParent"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ProcessNumberParent.DefaultCellStyle = DataGridViewCellStyle5
        Me.ProcessNumberParent.HeaderText = "Pn Parent"
        Me.ProcessNumberParent.MaxInputLength = 2
        Me.ProcessNumberParent.Name = "ProcessNumberParent"
        Me.ProcessNumberParent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessNumberParent.Visible = False
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Description.Visible = False
        '
        'LeadTime
        '
        Me.LeadTime.DataPropertyName = "LeadTime"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LeadTime.DefaultCellStyle = DataGridViewCellStyle6
        Me.LeadTime.HeaderText = "LeadTime"
        Me.LeadTime.Name = "LeadTime"
        Me.LeadTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'LeadTimePn
        '
        Me.LeadTimePn.DataPropertyName = "LeadTimePn"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LeadTimePn.DefaultCellStyle = DataGridViewCellStyle7
        Me.LeadTimePn.HeaderText = "LeadTimePn"
        Me.LeadTimePn.Name = "LeadTimePn"
        Me.LeadTimePn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LeadTimePn.Visible = False
        '
        'ReportGroupCode
        '
        Me.ReportGroupCode.DataPropertyName = "ReportGroupCode"
        Me.ReportGroupCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.ReportGroupCode.DisplayStyleForCurrentCellOnly = True
        Me.ReportGroupCode.HeaderText = "Rpt Group"
        Me.ReportGroupCode.Name = "ReportGroupCode"
        Me.ReportGroupCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ProcessGroup
        '
        Me.ProcessGroup.DataPropertyName = "ProcessGroup"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ProcessGroup.DefaultCellStyle = DataGridViewCellStyle8
        Me.ProcessGroup.HeaderText = "Prc Group"
        Me.ProcessGroup.Name = "ProcessGroup"
        Me.ProcessGroup.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProcessGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessGroup.Width = 75
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        Me.CreateDate.HeaderText = "CreateDate"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CreateDate.Visible = False
        '
        'CreateUser
        '
        Me.CreateUser.DataPropertyName = "CreateUser"
        Me.CreateUser.HeaderText = "CreateUser"
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CreateUser.Visible = False
        '
        'UpdateDate
        '
        Me.UpdateDate.DataPropertyName = "UpdateDate"
        Me.UpdateDate.HeaderText = "UpdateDate"
        Me.UpdateDate.Name = "UpdateDate"
        Me.UpdateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'UpdateUser
        '
        Me.UpdateUser.DataPropertyName = "UpdateUser"
        Me.UpdateUser.HeaderText = "UpdateUser"
        Me.UpdateUser.Name = "UpdateUser"
        Me.UpdateUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ID_K
        '
        Me.ID_K.DataPropertyName = "ID_K"
        Me.ID_K.HeaderText = "ID_K"
        Me.ID_K.Name = "ID_K"
        Me.ID_K.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ID_K.Visible = False
        '
        'FrmProcessLeadTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 435)
        Me.Controls.Add(Me.cboLeadTime)
        Me.Controls.Add(Me.lblLeadTime)
        Me.Controls.Add(Me.gridProductLeadTime)
        Me.Controls.Add(Me.bnProductLeadTime)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmProcessLeadTime"
        Me.ShowInTaskbar = False
        Me.Tag = "022702"
        Me.Text = "Product LeadTime"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bsProductLeadTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsProductLeadTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblProductLeadTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnProductLeadTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnProductLeadTime.ResumeLayout(False)
        Me.bnProductLeadTime.PerformLayout()
        CType(Me.gridProductLeadTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents bsProductLeadTime As System.Windows.Forms.BindingSource
    Friend WithEvents dsProductLeadTime As System.Data.DataSet
    Friend WithEvents tblProductLeadTime As System.Data.DataTable
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnProductLeadTime As System.Windows.Forms.BindingNavigator
    Friend WithEvents gridProductLeadTime As UtilityControl.CustomDataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboLeadTime As System.Windows.Forms.ComboBox
    Friend WithEvents lblLeadTime As System.Windows.Forms.Label
    Friend WithEvents DataColumn1 As System.Data.DataColumn
    Friend WithEvents DataColumn2 As System.Data.DataColumn
    Friend WithEvents DataColumn3 As System.Data.DataColumn
    Friend WithEvents DataColumn4 As System.Data.DataColumn
    Friend WithEvents DataColumn5 As System.Data.DataColumn
    Friend WithEvents DataColumn6 As System.Data.DataColumn
    Friend WithEvents DataColumn7 As System.Data.DataColumn
    Friend WithEvents DataColumn8 As System.Data.DataColumn
    Friend WithEvents DataColumn9 As System.Data.DataColumn
    Friend WithEvents DataColumn10 As System.Data.DataColumn
    Friend WithEvents DataColumn11 As System.Data.DataColumn
    Friend WithEvents DataColumn12 As System.Data.DataColumn
    Friend WithEvents DataColumn13 As System.Data.DataColumn
    Friend WithEvents DataColumn14 As System.Data.DataColumn
    Friend WithEvents DataColumn15 As System.Data.DataColumn
    Friend WithEvents DataColumn16 As System.Data.DataColumn
    Friend WithEvents DataColumn17 As System.Data.DataColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Idx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimeID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProcessNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessNumberParent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeadTimePn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportGroupCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ProcessGroup As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents CreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID_K As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
