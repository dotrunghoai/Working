<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLotStatus_1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLotStatus_1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuAddNew = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuBack = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuImport = New System.Windows.Forms.ToolStripButton()
        Me.mnuView = New System.Windows.Forms.ToolStripButton()
        Me.mnuViewDebit = New System.Windows.Forms.ToolStripButton()
        Me.mnuViewExcess = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.bsLotStatus = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsLotStatus = New System.Data.DataSet()
        Me.tblLotStatus = New System.Data.DataTable()
        Me.DataColumn8 = New System.Data.DataColumn()
        Me.DataColumn9 = New System.Data.DataColumn()
        Me.DataColumn10 = New System.Data.DataColumn()
        Me.DataColumn11 = New System.Data.DataColumn()
        Me.DataColumn12 = New System.Data.DataColumn()
        Me.DataColumn13 = New System.Data.DataColumn()
        Me.DataColumn14 = New System.Data.DataColumn()
        Me.DataColumn16 = New System.Data.DataColumn()
        Me.DataColumn17 = New System.Data.DataColumn()
        Me.DataColumn31 = New System.Data.DataColumn()
        Me.DataColumn35 = New System.Data.DataColumn()
        Me.bsOutput = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsOutput = New System.Data.DataSet()
        Me.tblOutput = New System.Data.DataTable()
        Me.DataColumn1 = New System.Data.DataColumn()
        Me.DataColumn2 = New System.Data.DataColumn()
        Me.DataColumn3 = New System.Data.DataColumn()
        Me.DataColumn4 = New System.Data.DataColumn()
        Me.DataColumn5 = New System.Data.DataColumn()
        Me.DataColumn6 = New System.Data.DataColumn()
        Me.DataColumn7 = New System.Data.DataColumn()
        Me.DataColumn15 = New System.Data.DataColumn()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.lblToDate = New System.Windows.Forms.Label()
        Me.lblFromDate = New System.Windows.Forms.Label()
        Me.tbMain = New System.Windows.Forms.TabControl()
        Me.tpgOutput = New System.Windows.Forms.TabPage()
        Me.txtProductCode1 = New System.Windows.Forms.TextBox()
        Me.gridOutput = New UtilityControl.CustomDataGridView()
        Me.PeriodCode = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.FromDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Idx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartLot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreateDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bnOutput = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tpgLotStatus = New System.Windows.Forms.TabPage()
        Me.txtProductCode2 = New System.Windows.Forms.TextBox()
        Me.gridLotStatus = New UtilityControl.CustomDataGridView()
        Me.Idx1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlanningDate = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ProductCode1 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.RevisionCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComponentCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Standard = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.bnLotStatus = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tpgLotDebit = New System.Windows.Forms.TabPage()
        Me.txtProductCode3 = New System.Windows.Forms.TextBox()
        Me.gridDebit = New UtilityControl.CustomDataGridView()
        Me.ProductCode2 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.RevisionCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComponentCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNumber2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessNumber2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessCode2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessName2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Idx2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Standard2 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.bsDebit = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsDebit = New System.Data.DataSet()
        Me.tblDebit = New System.Data.DataTable()
        Me.DataColumn18 = New System.Data.DataColumn()
        Me.DataColumn19 = New System.Data.DataColumn()
        Me.DataColumn20 = New System.Data.DataColumn()
        Me.DataColumn21 = New System.Data.DataColumn()
        Me.DataColumn22 = New System.Data.DataColumn()
        Me.DataColumn23 = New System.Data.DataColumn()
        Me.DataColumn24 = New System.Data.DataColumn()
        Me.DataColumn26 = New System.Data.DataColumn()
        Me.DataColumn32 = New System.Data.DataColumn()
        Me.DataColumn36 = New System.Data.DataColumn()
        Me.bnDebit = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tpgExcess = New System.Windows.Forms.TabPage()
        Me.bnExcess = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.bsExcess = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsExcess = New System.Data.DataSet()
        Me.tblExcess = New System.Data.DataTable()
        Me.DataColumn25 = New System.Data.DataColumn()
        Me.DataColumn27 = New System.Data.DataColumn()
        Me.DataColumn28 = New System.Data.DataColumn()
        Me.DataColumn29 = New System.Data.DataColumn()
        Me.DataColumn33 = New System.Data.DataColumn()
        Me.DataColumn30 = New System.Data.DataColumn()
        Me.DataColumn34 = New System.Data.DataColumn()
        Me.DataColumn37 = New System.Data.DataColumn()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripTextBox3 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator()
        Me.txtProductCode4 = New System.Windows.Forms.TextBox()
        Me.gridExcess = New UtilityControl.CustomDataGridView()
        Me.ProductCode3 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.RevisionCode3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ComponentCode3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotNumber3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Quantity3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Idx3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsOutside = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Standard3 = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPeriod = New System.Windows.Forms.ComboBox()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bsLotStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsLotStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblLotStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbMain.SuspendLayout()
        Me.tpgOutput.SuspendLayout()
        CType(Me.gridOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnOutput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnOutput.SuspendLayout()
        Me.tpgLotStatus.SuspendLayout()
        CType(Me.gridLotStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnLotStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnLotStatus.SuspendLayout()
        Me.tpgLotDebit.SuspendLayout()
        CType(Me.gridDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bsDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnDebit.SuspendLayout()
        Me.tpgExcess.SuspendLayout()
        CType(Me.bnExcess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnExcess.SuspendLayout()
        CType(Me.bsExcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsExcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tblExcess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridExcess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddNew, Me.mnuDelete, Me.mnuBack, Me.ToolStripSeparator6, Me.mnuShowAll, Me.mnuExport, Me.ToolStripSeparator3, Me.mnuImport, Me.mnuView, Me.mnuViewDebit, Me.mnuViewExcess, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(928, 55)
        Me.tlsMenu.TabIndex = 0
        '
        'mnuAddNew
        '
        Me.mnuAddNew.AutoSize = False
        Me.mnuAddNew.Image = CType(resources.GetObject("mnuAddNew.Image"), System.Drawing.Image)
        Me.mnuAddNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuAddNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuAddNew.Name = "mnuAddNew"
        Me.mnuAddNew.Size = New System.Drawing.Size(60, 50)
        Me.mnuAddNew.Text = "New"
        Me.mnuAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuAddNew.ToolTipText = "New (Ctrl + N)"
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 55)
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
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 55)
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
        Me.mnuView.Text = "View Lot"
        Me.mnuView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuView.ToolTipText = "View Lot#"
        '
        'mnuViewDebit
        '
        Me.mnuViewDebit.AutoSize = False
        Me.mnuViewDebit.Image = CType(resources.GetObject("mnuViewDebit.Image"), System.Drawing.Image)
        Me.mnuViewDebit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuViewDebit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuViewDebit.Name = "mnuViewDebit"
        Me.mnuViewDebit.Size = New System.Drawing.Size(60, 50)
        Me.mnuViewDebit.Text = "View Debit"
        Me.mnuViewDebit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuViewDebit.ToolTipText = "View Lot# Debit"
        '
        'mnuViewExcess
        '
        Me.mnuViewExcess.AutoSize = False
        Me.mnuViewExcess.Image = CType(resources.GetObject("mnuViewExcess.Image"), System.Drawing.Image)
        Me.mnuViewExcess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuViewExcess.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuViewExcess.Name = "mnuViewExcess"
        Me.mnuViewExcess.Size = New System.Drawing.Size(72, 50)
        Me.mnuViewExcess.Text = "View Excess"
        Me.mnuViewExcess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuViewExcess.ToolTipText = "View Lot# Excess"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'bsLotStatus
        '
        Me.bsLotStatus.DataMember = "tblLotStatus"
        Me.bsLotStatus.DataSource = Me.dsLotStatus
        '
        'dsLotStatus
        '
        Me.dsLotStatus.DataSetName = "dsLotStatus"
        Me.dsLotStatus.Tables.AddRange(New System.Data.DataTable() {Me.tblLotStatus})
        '
        'tblLotStatus
        '
        Me.tblLotStatus.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn8, Me.DataColumn9, Me.DataColumn10, Me.DataColumn11, Me.DataColumn12, Me.DataColumn13, Me.DataColumn14, Me.DataColumn16, Me.DataColumn17, Me.DataColumn31, Me.DataColumn35})
        Me.tblLotStatus.TableName = "tblLotStatus"
        '
        'DataColumn8
        '
        Me.DataColumn8.ColumnName = "ProductCode"
        '
        'DataColumn9
        '
        Me.DataColumn9.ColumnName = "RevisionCode"
        '
        'DataColumn10
        '
        Me.DataColumn10.ColumnName = "ComponentCode"
        '
        'DataColumn11
        '
        Me.DataColumn11.ColumnName = "LotNumber"
        '
        'DataColumn12
        '
        Me.DataColumn12.ColumnName = "ProcessNumber"
        '
        'DataColumn13
        '
        Me.DataColumn13.ColumnName = "ProcessCode"
        '
        'DataColumn14
        '
        Me.DataColumn14.ColumnName = "ProcessName"
        '
        'DataColumn16
        '
        Me.DataColumn16.ColumnName = "PlanningDate"
        Me.DataColumn16.DataType = GetType(Date)
        '
        'DataColumn17
        '
        Me.DataColumn17.ColumnName = "Idx"
        Me.DataColumn17.DataType = GetType(Integer)
        '
        'DataColumn31
        '
        Me.DataColumn31.ColumnName = "Quantity"
        Me.DataColumn31.DataType = GetType(Integer)
        '
        'DataColumn35
        '
        Me.DataColumn35.ColumnName = "Standard"
        Me.DataColumn35.DataType = GetType(Boolean)
        '
        'bsOutput
        '
        Me.bsOutput.DataMember = "tblOutput"
        Me.bsOutput.DataSource = Me.dsOutput
        '
        'dsOutput
        '
        Me.dsOutput.DataSetName = "dsOutput"
        Me.dsOutput.Tables.AddRange(New System.Data.DataTable() {Me.tblOutput})
        '
        'tblOutput
        '
        Me.tblOutput.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn1, Me.DataColumn2, Me.DataColumn3, Me.DataColumn4, Me.DataColumn5, Me.DataColumn6, Me.DataColumn7, Me.DataColumn15})
        Me.tblOutput.TableName = "tblOutput"
        '
        'DataColumn1
        '
        Me.DataColumn1.ColumnName = "PeriodCode"
        '
        'DataColumn2
        '
        Me.DataColumn2.ColumnName = "FromDate"
        Me.DataColumn2.DataType = GetType(Date)
        '
        'DataColumn3
        '
        Me.DataColumn3.ColumnName = "ToDate"
        Me.DataColumn3.DataType = GetType(Date)
        '
        'DataColumn4
        '
        Me.DataColumn4.ColumnName = "ProductCode"
        '
        'DataColumn5
        '
        Me.DataColumn5.ColumnName = "StartLot"
        '
        'DataColumn6
        '
        Me.DataColumn6.ColumnName = "CreateUser"
        '
        'DataColumn7
        '
        Me.DataColumn7.ColumnName = "CreateDate"
        Me.DataColumn7.DataType = GetType(Date)
        '
        'DataColumn15
        '
        Me.DataColumn15.ColumnName = "Idx"
        Me.DataColumn15.DataType = GetType(Integer)
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToDate.Location = New System.Drawing.Point(786, 26)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpToDate.TabIndex = 35
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(700, 26)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(80, 20)
        Me.dtpFromDate.TabIndex = 34
        '
        'lblToDate
        '
        Me.lblToDate.AutoSize = True
        Me.lblToDate.Location = New System.Drawing.Point(786, 10)
        Me.lblToDate.Name = "lblToDate"
        Me.lblToDate.Size = New System.Drawing.Size(20, 13)
        Me.lblToDate.TabIndex = 33
        Me.lblToDate.Text = "To"
        '
        'lblFromDate
        '
        Me.lblFromDate.AutoSize = True
        Me.lblFromDate.Location = New System.Drawing.Point(700, 10)
        Me.lblFromDate.Name = "lblFromDate"
        Me.lblFromDate.Size = New System.Drawing.Size(30, 13)
        Me.lblFromDate.TabIndex = 32
        Me.lblFromDate.Text = "From"
        '
        'tbMain
        '
        Me.tbMain.Controls.Add(Me.tpgOutput)
        Me.tbMain.Controls.Add(Me.tpgLotStatus)
        Me.tbMain.Controls.Add(Me.tpgLotDebit)
        Me.tbMain.Controls.Add(Me.tpgExcess)
        Me.tbMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbMain.Location = New System.Drawing.Point(0, 55)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.SelectedIndex = 0
        Me.tbMain.Size = New System.Drawing.Size(928, 380)
        Me.tbMain.TabIndex = 36
        '
        'tpgOutput
        '
        Me.tpgOutput.Controls.Add(Me.txtProductCode1)
        Me.tpgOutput.Controls.Add(Me.gridOutput)
        Me.tpgOutput.Controls.Add(Me.bnOutput)
        Me.tpgOutput.Location = New System.Drawing.Point(4, 22)
        Me.tpgOutput.Name = "tpgOutput"
        Me.tpgOutput.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOutput.Size = New System.Drawing.Size(920, 354)
        Me.tpgOutput.TabIndex = 0
        Me.tpgOutput.Text = "Output"
        Me.tpgOutput.UseVisualStyleBackColor = True
        '
        'txtProductCode1
        '
        Me.txtProductCode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProductCode1.Location = New System.Drawing.Point(17, 4)
        Me.txtProductCode1.MaxLength = 5
        Me.txtProductCode1.Name = "txtProductCode1"
        Me.txtProductCode1.Size = New System.Drawing.Size(65, 20)
        Me.txtProductCode1.TabIndex = 43
        '
        'gridOutput
        '
        Me.gridOutput.AllowUserToAddRows = False
        Me.gridOutput.AllowUserToDeleteRows = False
        Me.gridOutput.AllowUserToOrderColumns = True
        Me.gridOutput.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridOutput.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridOutput.AutoGenerateColumns = False
        Me.gridOutput.ColumnHeadersHeight = 21
        Me.gridOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridOutput.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PeriodCode, Me.FromDate, Me.ToDate, Me.Idx, Me.ProductCode, Me.StartLot, Me.CreateUser, Me.CreateDate})
        Me.gridOutput.DataSource = Me.bsOutput
        Me.gridOutput.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridOutput.Location = New System.Drawing.Point(3, 27)
        Me.gridOutput.Name = "gridOutput"
        Me.gridOutput.ReadOnly = True
        Me.gridOutput.RowHeadersWidth = 15
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridOutput.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridOutput.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridOutput.Size = New System.Drawing.Size(914, 300)
        Me.gridOutput.TabIndex = 23
        '
        'PeriodCode
        '
        Me.PeriodCode.DataPropertyName = "PeriodCode"
        Me.PeriodCode.HeaderText = "Period"
        Me.PeriodCode.Name = "PeriodCode"
        Me.PeriodCode.ReadOnly = True
        Me.PeriodCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PeriodCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PeriodCode.Visible = False
        '
        'FromDate
        '
        Me.FromDate.DataPropertyName = "FromDate"
        Me.FromDate.HeaderText = "FromDate"
        Me.FromDate.Name = "FromDate"
        Me.FromDate.ReadOnly = True
        Me.FromDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FromDate.Visible = False
        '
        'ToDate
        '
        Me.ToDate.DataPropertyName = "ToDate"
        Me.ToDate.HeaderText = "ToDate"
        Me.ToDate.Name = "ToDate"
        Me.ToDate.ReadOnly = True
        Me.ToDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ToDate.Visible = False
        '
        'Idx
        '
        Me.Idx.DataPropertyName = "Idx"
        Me.Idx.HeaderText = "#"
        Me.Idx.Name = "Idx"
        Me.Idx.ReadOnly = True
        Me.Idx.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Idx.Visible = False
        Me.Idx.Width = 35
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "ProductCode"
        Me.ProductCode.HeaderText = "PdCode"
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.ReadOnly = True
        Me.ProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProductCode.Width = 65
        '
        'StartLot
        '
        Me.StartLot.DataPropertyName = "StartLot"
        Me.StartLot.HeaderText = "StartLot"
        Me.StartLot.Name = "StartLot"
        Me.StartLot.ReadOnly = True
        Me.StartLot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.StartLot.Width = 55
        '
        'CreateUser
        '
        Me.CreateUser.DataPropertyName = "CreateUser"
        Me.CreateUser.HeaderText = "CreateUser"
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.ReadOnly = True
        Me.CreateUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CreateUser.Visible = False
        '
        'CreateDate
        '
        Me.CreateDate.DataPropertyName = "CreateDate"
        Me.CreateDate.HeaderText = "CreateDate"
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.ReadOnly = True
        Me.CreateDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CreateDate.Visible = False
        '
        'bnOutput
        '
        Me.bnOutput.AddNewItem = Nothing
        Me.bnOutput.BindingSource = Me.bsOutput
        Me.bnOutput.CountItem = Me.BindingNavigatorCountItem
        Me.bnOutput.DeleteItem = Nothing
        Me.bnOutput.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnOutput.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bnOutput.Location = New System.Drawing.Point(3, 326)
        Me.bnOutput.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnOutput.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnOutput.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnOutput.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnOutput.Name = "bnOutput"
        Me.bnOutput.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnOutput.Size = New System.Drawing.Size(914, 25)
        Me.bnOutput.TabIndex = 24
        Me.bnOutput.Text = "BindingNavigator1"
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
        'tpgLotStatus
        '
        Me.tpgLotStatus.Controls.Add(Me.txtProductCode2)
        Me.tpgLotStatus.Controls.Add(Me.gridLotStatus)
        Me.tpgLotStatus.Controls.Add(Me.bnLotStatus)
        Me.tpgLotStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpgLotStatus.Name = "tpgLotStatus"
        Me.tpgLotStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgLotStatus.Size = New System.Drawing.Size(920, 354)
        Me.tpgLotStatus.TabIndex = 1
        Me.tpgLotStatus.Text = "Lot Status"
        Me.tpgLotStatus.UseVisualStyleBackColor = True
        '
        'txtProductCode2
        '
        Me.txtProductCode2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProductCode2.Location = New System.Drawing.Point(103, 3)
        Me.txtProductCode2.MaxLength = 5
        Me.txtProductCode2.Name = "txtProductCode2"
        Me.txtProductCode2.Size = New System.Drawing.Size(65, 20)
        Me.txtProductCode2.TabIndex = 43
        '
        'gridLotStatus
        '
        Me.gridLotStatus.AllowUserToAddRows = False
        Me.gridLotStatus.AllowUserToDeleteRows = False
        Me.gridLotStatus.AllowUserToOrderColumns = True
        Me.gridLotStatus.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridLotStatus.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gridLotStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridLotStatus.AutoGenerateColumns = False
        Me.gridLotStatus.ColumnHeadersHeight = 21
        Me.gridLotStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridLotStatus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Idx1, Me.PlanningDate, Me.ProductCode1, Me.RevisionCode, Me.ComponentCode, Me.LotNumber, Me.Quantity, Me.ProcessNumber, Me.ProcessCode, Me.ProcessName, Me.Standard})
        Me.gridLotStatus.DataSource = Me.bsLotStatus
        Me.gridLotStatus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridLotStatus.Location = New System.Drawing.Point(3, 26)
        Me.gridLotStatus.Name = "gridLotStatus"
        Me.gridLotStatus.ReadOnly = True
        Me.gridLotStatus.RowHeadersWidth = 15
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridLotStatus.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.gridLotStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridLotStatus.Size = New System.Drawing.Size(914, 300)
        Me.gridLotStatus.TabIndex = 24
        '
        'Idx1
        '
        Me.Idx1.DataPropertyName = "Idx"
        Me.Idx1.HeaderText = "Idx1"
        Me.Idx1.Name = "Idx1"
        Me.Idx1.ReadOnly = True
        Me.Idx1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Idx1.Visible = False
        '
        'PlanningDate
        '
        Me.PlanningDate.DataPropertyName = "PlanningDate"
        DataGridViewCellStyle4.Format = "dd-MMM-yy"
        Me.PlanningDate.DefaultCellStyle = DataGridViewCellStyle4
        Me.PlanningDate.HeaderText = "Date"
        Me.PlanningDate.Name = "PlanningDate"
        Me.PlanningDate.ReadOnly = True
        Me.PlanningDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PlanningDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PlanningDate.Width = 85
        '
        'ProductCode1
        '
        Me.ProductCode1.DataPropertyName = "ProductCode"
        Me.ProductCode1.HeaderText = "PdCode"
        Me.ProductCode1.Name = "ProductCode1"
        Me.ProductCode1.ReadOnly = True
        Me.ProductCode1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductCode1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProductCode1.Width = 65
        '
        'RevisionCode
        '
        Me.RevisionCode.DataPropertyName = "RevisionCode"
        Me.RevisionCode.HeaderText = "Rc"
        Me.RevisionCode.Name = "RevisionCode"
        Me.RevisionCode.ReadOnly = True
        Me.RevisionCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RevisionCode.Width = 35
        '
        'ComponentCode
        '
        Me.ComponentCode.DataPropertyName = "ComponentCode"
        Me.ComponentCode.HeaderText = "Cc"
        Me.ComponentCode.Name = "ComponentCode"
        Me.ComponentCode.ReadOnly = True
        Me.ComponentCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ComponentCode.Width = 45
        '
        'LotNumber
        '
        Me.LotNumber.DataPropertyName = "LotNumber"
        Me.LotNumber.HeaderText = "Lot#"
        Me.LotNumber.Name = "LotNumber"
        Me.LotNumber.ReadOnly = True
        Me.LotNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LotNumber.Width = 75
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Quantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.Quantity.HeaderText = "Qty"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        Me.Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Quantity.Width = 75
        '
        'ProcessNumber
        '
        Me.ProcessNumber.DataPropertyName = "ProcessNumber"
        Me.ProcessNumber.HeaderText = "Pn"
        Me.ProcessNumber.Name = "ProcessNumber"
        Me.ProcessNumber.ReadOnly = True
        Me.ProcessNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessNumber.Width = 35
        '
        'ProcessCode
        '
        Me.ProcessCode.DataPropertyName = "ProcessCode"
        Me.ProcessCode.HeaderText = "PrcCode"
        Me.ProcessCode.Name = "ProcessCode"
        Me.ProcessCode.ReadOnly = True
        Me.ProcessCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessCode.Width = 65
        '
        'ProcessName
        '
        Me.ProcessName.DataPropertyName = "ProcessName"
        Me.ProcessName.HeaderText = "PrcName"
        Me.ProcessName.Name = "ProcessName"
        Me.ProcessName.ReadOnly = True
        Me.ProcessName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Standard
        '
        Me.Standard.DataPropertyName = "Standard"
        Me.Standard.HeaderText = "Standard"
        Me.Standard.Name = "Standard"
        Me.Standard.ReadOnly = True
        Me.Standard.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Standard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'bnLotStatus
        '
        Me.bnLotStatus.AddNewItem = Nothing
        Me.bnLotStatus.BindingSource = Me.bsLotStatus
        Me.bnLotStatus.CountItem = Me.ToolStripLabel1
        Me.bnLotStatus.DeleteItem = Nothing
        Me.bnLotStatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnLotStatus.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripSeparator2, Me.ToolStripTextBox1, Me.ToolStripLabel1, Me.ToolStripSeparator4, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator5})
        Me.bnLotStatus.Location = New System.Drawing.Point(3, 326)
        Me.bnLotStatus.MoveFirstItem = Me.ToolStripButton1
        Me.bnLotStatus.MoveLastItem = Me.ToolStripButton4
        Me.bnLotStatus.MoveNextItem = Me.ToolStripButton3
        Me.bnLotStatus.MovePreviousItem = Me.ToolStripButton2
        Me.bnLotStatus.Name = "bnLotStatus"
        Me.bnLotStatus.PositionItem = Me.ToolStripTextBox1
        Me.bnLotStatus.Size = New System.Drawing.Size(914, 25)
        Me.bnLotStatus.TabIndex = 25
        Me.bnLotStatus.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel1.Text = "of {0}"
        Me.ToolStripLabel1.ToolTipText = "Total number of items"
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
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "Move previous"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "Move last"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tpgLotDebit
        '
        Me.tpgLotDebit.Controls.Add(Me.txtProductCode3)
        Me.tpgLotDebit.Controls.Add(Me.gridDebit)
        Me.tpgLotDebit.Controls.Add(Me.bnDebit)
        Me.tpgLotDebit.Location = New System.Drawing.Point(4, 22)
        Me.tpgLotDebit.Name = "tpgLotDebit"
        Me.tpgLotDebit.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgLotDebit.Size = New System.Drawing.Size(920, 354)
        Me.tpgLotDebit.TabIndex = 2
        Me.tpgLotDebit.Text = "Debit"
        Me.tpgLotDebit.UseVisualStyleBackColor = True
        '
        'txtProductCode3
        '
        Me.txtProductCode3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProductCode3.Location = New System.Drawing.Point(17, 3)
        Me.txtProductCode3.MaxLength = 5
        Me.txtProductCode3.Name = "txtProductCode3"
        Me.txtProductCode3.Size = New System.Drawing.Size(65, 20)
        Me.txtProductCode3.TabIndex = 41
        '
        'gridDebit
        '
        Me.gridDebit.AllowUserToAddRows = False
        Me.gridDebit.AllowUserToDeleteRows = False
        Me.gridDebit.AllowUserToOrderColumns = True
        Me.gridDebit.AllowUserToResizeRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridDebit.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.gridDebit.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridDebit.AutoGenerateColumns = False
        Me.gridDebit.ColumnHeadersHeight = 21
        Me.gridDebit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridDebit.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductCode2, Me.RevisionCode2, Me.ComponentCode2, Me.LotNumber2, Me.Quantity2, Me.ProcessNumber2, Me.ProcessCode2, Me.ProcessName2, Me.Idx2, Me.Standard2})
        Me.gridDebit.DataSource = Me.bsDebit
        Me.gridDebit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridDebit.Location = New System.Drawing.Point(3, 26)
        Me.gridDebit.Name = "gridDebit"
        Me.gridDebit.ReadOnly = True
        Me.gridDebit.RowHeadersWidth = 15
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridDebit.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.gridDebit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridDebit.Size = New System.Drawing.Size(914, 300)
        Me.gridDebit.TabIndex = 25
        '
        'ProductCode2
        '
        Me.ProductCode2.DataPropertyName = "ProductCode"
        Me.ProductCode2.HeaderText = "PdCode"
        Me.ProductCode2.Name = "ProductCode2"
        Me.ProductCode2.ReadOnly = True
        Me.ProductCode2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductCode2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProductCode2.Width = 65
        '
        'RevisionCode2
        '
        Me.RevisionCode2.DataPropertyName = "RevisionCode"
        Me.RevisionCode2.HeaderText = "Rc"
        Me.RevisionCode2.Name = "RevisionCode2"
        Me.RevisionCode2.ReadOnly = True
        Me.RevisionCode2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RevisionCode2.Width = 35
        '
        'ComponentCode2
        '
        Me.ComponentCode2.DataPropertyName = "ComponentCode"
        Me.ComponentCode2.HeaderText = "Cc"
        Me.ComponentCode2.Name = "ComponentCode2"
        Me.ComponentCode2.ReadOnly = True
        Me.ComponentCode2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ComponentCode2.Width = 45
        '
        'LotNumber2
        '
        Me.LotNumber2.DataPropertyName = "LotNumber"
        Me.LotNumber2.HeaderText = "Lot#"
        Me.LotNumber2.Name = "LotNumber2"
        Me.LotNumber2.ReadOnly = True
        Me.LotNumber2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LotNumber2.Width = 65
        '
        'Quantity2
        '
        Me.Quantity2.DataPropertyName = "Quantity"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Quantity2.DefaultCellStyle = DataGridViewCellStyle8
        Me.Quantity2.HeaderText = "Qty"
        Me.Quantity2.Name = "Quantity2"
        Me.Quantity2.ReadOnly = True
        Me.Quantity2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Quantity2.Width = 75
        '
        'ProcessNumber2
        '
        Me.ProcessNumber2.DataPropertyName = "ProcessNumber"
        Me.ProcessNumber2.HeaderText = "Pn"
        Me.ProcessNumber2.Name = "ProcessNumber2"
        Me.ProcessNumber2.ReadOnly = True
        Me.ProcessNumber2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessNumber2.Width = 35
        '
        'ProcessCode2
        '
        Me.ProcessCode2.DataPropertyName = "ProcessCode"
        Me.ProcessCode2.HeaderText = "PrcCode"
        Me.ProcessCode2.Name = "ProcessCode2"
        Me.ProcessCode2.ReadOnly = True
        Me.ProcessCode2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessCode2.Width = 55
        '
        'ProcessName2
        '
        Me.ProcessName2.DataPropertyName = "ProcessName"
        Me.ProcessName2.HeaderText = "PrcName"
        Me.ProcessName2.Name = "ProcessName2"
        Me.ProcessName2.ReadOnly = True
        Me.ProcessName2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Idx2
        '
        Me.Idx2.DataPropertyName = "Idx"
        Me.Idx2.HeaderText = "Idx"
        Me.Idx2.Name = "Idx2"
        Me.Idx2.ReadOnly = True
        Me.Idx2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Idx2.Visible = False
        '
        'Standard2
        '
        Me.Standard2.DataPropertyName = "Standard"
        Me.Standard2.HeaderText = "Standard"
        Me.Standard2.Name = "Standard2"
        Me.Standard2.ReadOnly = True
        Me.Standard2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Standard2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'bsDebit
        '
        Me.bsDebit.DataMember = "tblDebit"
        Me.bsDebit.DataSource = Me.dsDebit
        '
        'dsDebit
        '
        Me.dsDebit.DataSetName = "dsDebit"
        Me.dsDebit.Tables.AddRange(New System.Data.DataTable() {Me.tblDebit})
        '
        'tblDebit
        '
        Me.tblDebit.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn18, Me.DataColumn19, Me.DataColumn20, Me.DataColumn21, Me.DataColumn22, Me.DataColumn23, Me.DataColumn24, Me.DataColumn26, Me.DataColumn32, Me.DataColumn36})
        Me.tblDebit.TableName = "tblDebit"
        '
        'DataColumn18
        '
        Me.DataColumn18.ColumnName = "ProductCode"
        '
        'DataColumn19
        '
        Me.DataColumn19.ColumnName = "RevisionCode"
        '
        'DataColumn20
        '
        Me.DataColumn20.ColumnName = "ComponentCode"
        '
        'DataColumn21
        '
        Me.DataColumn21.ColumnName = "LotNumber"
        '
        'DataColumn22
        '
        Me.DataColumn22.ColumnName = "ProcessNumber"
        '
        'DataColumn23
        '
        Me.DataColumn23.ColumnName = "ProcessCode"
        '
        'DataColumn24
        '
        Me.DataColumn24.ColumnName = "ProcessName"
        '
        'DataColumn26
        '
        Me.DataColumn26.ColumnName = "Idx"
        Me.DataColumn26.DataType = GetType(Integer)
        '
        'DataColumn32
        '
        Me.DataColumn32.ColumnName = "Quantity"
        Me.DataColumn32.DataType = GetType(Integer)
        '
        'DataColumn36
        '
        Me.DataColumn36.ColumnName = "Standard"
        Me.DataColumn36.DataType = GetType(Boolean)
        '
        'bnDebit
        '
        Me.bnDebit.AddNewItem = Nothing
        Me.bnDebit.BindingSource = Me.bsDebit
        Me.bnDebit.CountItem = Me.ToolStripLabel2
        Me.bnDebit.DeleteItem = Nothing
        Me.bnDebit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnDebit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripSeparator7, Me.ToolStripTextBox2, Me.ToolStripLabel2, Me.ToolStripSeparator8, Me.ToolStripButton7, Me.ToolStripButton8, Me.ToolStripSeparator9})
        Me.bnDebit.Location = New System.Drawing.Point(3, 326)
        Me.bnDebit.MoveFirstItem = Me.ToolStripButton5
        Me.bnDebit.MoveLastItem = Me.ToolStripButton8
        Me.bnDebit.MoveNextItem = Me.ToolStripButton7
        Me.bnDebit.MovePreviousItem = Me.ToolStripButton6
        Me.bnDebit.Name = "bnDebit"
        Me.bnDebit.PositionItem = Me.ToolStripTextBox2
        Me.bnDebit.Size = New System.Drawing.Size(914, 25)
        Me.bnDebit.TabIndex = 40
        Me.bnDebit.Text = "BindingNavigator1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel2.Text = "of {0}"
        Me.ToolStripLabel2.ToolTipText = "Total number of items"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton5.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton5.Text = "Move first"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton6.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton6.Text = "Move previous"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox2
        '
        Me.ToolStripTextBox2.AccessibleName = "Position"
        Me.ToolStripTextBox2.AutoSize = False
        Me.ToolStripTextBox2.Name = "ToolStripTextBox2"
        Me.ToolStripTextBox2.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox2.Text = "0"
        Me.ToolStripTextBox2.ToolTipText = "Current position"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = CType(resources.GetObject("ToolStripButton7.Image"), System.Drawing.Image)
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton7.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton7.Text = "Move next"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = CType(resources.GetObject("ToolStripButton8.Image"), System.Drawing.Image)
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton8.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton8.Text = "Move last"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'tpgExcess
        '
        Me.tpgExcess.Controls.Add(Me.bnExcess)
        Me.tpgExcess.Controls.Add(Me.txtProductCode4)
        Me.tpgExcess.Controls.Add(Me.gridExcess)
        Me.tpgExcess.Location = New System.Drawing.Point(4, 22)
        Me.tpgExcess.Name = "tpgExcess"
        Me.tpgExcess.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgExcess.Size = New System.Drawing.Size(920, 354)
        Me.tpgExcess.TabIndex = 3
        Me.tpgExcess.Text = "Excess"
        Me.tpgExcess.UseVisualStyleBackColor = True
        '
        'bnExcess
        '
        Me.bnExcess.AddNewItem = Nothing
        Me.bnExcess.BindingSource = Me.bsExcess
        Me.bnExcess.CountItem = Me.ToolStripLabel3
        Me.bnExcess.DeleteItem = Nothing
        Me.bnExcess.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnExcess.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton9, Me.ToolStripButton10, Me.ToolStripSeparator10, Me.ToolStripTextBox3, Me.ToolStripLabel3, Me.ToolStripSeparator11, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripSeparator12})
        Me.bnExcess.Location = New System.Drawing.Point(3, 326)
        Me.bnExcess.MoveFirstItem = Me.ToolStripButton9
        Me.bnExcess.MoveLastItem = Me.ToolStripButton12
        Me.bnExcess.MoveNextItem = Me.ToolStripButton11
        Me.bnExcess.MovePreviousItem = Me.ToolStripButton10
        Me.bnExcess.Name = "bnExcess"
        Me.bnExcess.PositionItem = Me.ToolStripTextBox3
        Me.bnExcess.Size = New System.Drawing.Size(914, 25)
        Me.bnExcess.TabIndex = 43
        Me.bnExcess.Text = "BindingNavigator1"
        '
        'bsExcess
        '
        Me.bsExcess.DataMember = "tblExcess"
        Me.bsExcess.DataSource = Me.dsExcess
        '
        'dsExcess
        '
        Me.dsExcess.DataSetName = "dsExcess"
        Me.dsExcess.Tables.AddRange(New System.Data.DataTable() {Me.tblExcess})
        '
        'tblExcess
        '
        Me.tblExcess.Columns.AddRange(New System.Data.DataColumn() {Me.DataColumn25, Me.DataColumn27, Me.DataColumn28, Me.DataColumn29, Me.DataColumn33, Me.DataColumn30, Me.DataColumn34, Me.DataColumn37})
        Me.tblExcess.TableName = "tblExcess"
        '
        'DataColumn25
        '
        Me.DataColumn25.ColumnName = "ProductCode"
        '
        'DataColumn27
        '
        Me.DataColumn27.ColumnName = "RevisionCode"
        '
        'DataColumn28
        '
        Me.DataColumn28.ColumnName = "ComponentCode"
        '
        'DataColumn29
        '
        Me.DataColumn29.ColumnName = "LotNumber"
        '
        'DataColumn33
        '
        Me.DataColumn33.ColumnName = "Idx"
        Me.DataColumn33.DataType = GetType(Integer)
        '
        'DataColumn30
        '
        Me.DataColumn30.ColumnName = "IsOutside"
        Me.DataColumn30.DataType = GetType(Boolean)
        '
        'DataColumn34
        '
        Me.DataColumn34.ColumnName = "Quantity"
        Me.DataColumn34.DataType = GetType(Integer)
        '
        'DataColumn37
        '
        Me.DataColumn37.ColumnName = "Standard"
        Me.DataColumn37.DataType = GetType(Boolean)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(35, 22)
        Me.ToolStripLabel3.Text = "of {0}"
        Me.ToolStripLabel3.ToolTipText = "Total number of items"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = CType(resources.GetObject("ToolStripButton9.Image"), System.Drawing.Image)
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton9.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton9.Text = "Move first"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = CType(resources.GetObject("ToolStripButton10.Image"), System.Drawing.Image)
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton10.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton10.Text = "Move previous"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripTextBox3
        '
        Me.ToolStripTextBox3.AccessibleName = "Position"
        Me.ToolStripTextBox3.AutoSize = False
        Me.ToolStripTextBox3.Name = "ToolStripTextBox3"
        Me.ToolStripTextBox3.Size = New System.Drawing.Size(50, 23)
        Me.ToolStripTextBox3.Text = "0"
        Me.ToolStripTextBox3.ToolTipText = "Current position"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = CType(resources.GetObject("ToolStripButton11.Image"), System.Drawing.Image)
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton11.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton11.Text = "Move next"
        '
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = CType(resources.GetObject("ToolStripButton12.Image"), System.Drawing.Image)
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.RightToLeftAutoMirrorImage = True
        Me.ToolStripButton12.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton12.Text = "Move last"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(6, 25)
        '
        'txtProductCode4
        '
        Me.txtProductCode4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProductCode4.Location = New System.Drawing.Point(19, 4)
        Me.txtProductCode4.MaxLength = 5
        Me.txtProductCode4.Name = "txtProductCode4"
        Me.txtProductCode4.Size = New System.Drawing.Size(65, 20)
        Me.txtProductCode4.TabIndex = 42
        '
        'gridExcess
        '
        Me.gridExcess.AllowUserToAddRows = False
        Me.gridExcess.AllowUserToDeleteRows = False
        Me.gridExcess.AllowUserToOrderColumns = True
        Me.gridExcess.AllowUserToResizeRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridExcess.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.gridExcess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridExcess.AutoGenerateColumns = False
        Me.gridExcess.ColumnHeadersHeight = 21
        Me.gridExcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.gridExcess.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductCode3, Me.RevisionCode3, Me.ComponentCode3, Me.LotNumber3, Me.Quantity3, Me.Idx3, Me.IsOutside, Me.Standard3})
        Me.gridExcess.DataSource = Me.bsExcess
        Me.gridExcess.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridExcess.Location = New System.Drawing.Point(3, 27)
        Me.gridExcess.Name = "gridExcess"
        Me.gridExcess.ReadOnly = True
        Me.gridExcess.RowHeadersWidth = 15
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridExcess.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.gridExcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridExcess.Size = New System.Drawing.Size(914, 296)
        Me.gridExcess.TabIndex = 26
        '
        'ProductCode3
        '
        Me.ProductCode3.DataPropertyName = "ProductCode"
        Me.ProductCode3.HeaderText = "PdCode"
        Me.ProductCode3.Name = "ProductCode3"
        Me.ProductCode3.ReadOnly = True
        Me.ProductCode3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProductCode3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProductCode3.Width = 65
        '
        'RevisionCode3
        '
        Me.RevisionCode3.DataPropertyName = "RevisionCode"
        Me.RevisionCode3.HeaderText = "Rc"
        Me.RevisionCode3.Name = "RevisionCode3"
        Me.RevisionCode3.ReadOnly = True
        Me.RevisionCode3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RevisionCode3.Width = 35
        '
        'ComponentCode3
        '
        Me.ComponentCode3.DataPropertyName = "ComponentCode"
        Me.ComponentCode3.HeaderText = "Cc"
        Me.ComponentCode3.Name = "ComponentCode3"
        Me.ComponentCode3.ReadOnly = True
        Me.ComponentCode3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ComponentCode3.Width = 45
        '
        'LotNumber3
        '
        Me.LotNumber3.DataPropertyName = "LotNumber"
        Me.LotNumber3.HeaderText = "Lot#"
        Me.LotNumber3.Name = "LotNumber3"
        Me.LotNumber3.ReadOnly = True
        Me.LotNumber3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LotNumber3.Width = 65
        '
        'Quantity3
        '
        Me.Quantity3.DataPropertyName = "Quantity"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Quantity3.DefaultCellStyle = DataGridViewCellStyle11
        Me.Quantity3.HeaderText = "Qty"
        Me.Quantity3.Name = "Quantity3"
        Me.Quantity3.ReadOnly = True
        Me.Quantity3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Quantity3.Width = 75
        '
        'Idx3
        '
        Me.Idx3.DataPropertyName = "Idx"
        Me.Idx3.HeaderText = "Idx"
        Me.Idx3.Name = "Idx3"
        Me.Idx3.ReadOnly = True
        Me.Idx3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Idx3.Visible = False
        '
        'IsOutside
        '
        Me.IsOutside.DataPropertyName = "IsOutside"
        Me.IsOutside.HeaderText = "IsOutside"
        Me.IsOutside.Name = "IsOutside"
        Me.IsOutside.ReadOnly = True
        Me.IsOutside.Visible = False
        '
        'Standard3
        '
        Me.Standard3.DataPropertyName = "Standard"
        Me.Standard3.HeaderText = "Standard"
        Me.Standard3.Name = "Standard3"
        Me.Standard3.ReadOnly = True
        Me.Standard3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Standard3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(573, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 37
        Me.Label1.Tag = ""
        Me.Label1.Text = "Period"
        '
        'cboPeriod
        '
        Me.cboPeriod.FormattingEnabled = True
        Me.cboPeriod.Location = New System.Drawing.Point(573, 26)
        Me.cboPeriod.Name = "cboPeriod"
        Me.cboPeriod.Size = New System.Drawing.Size(121, 21)
        Me.cboPeriod.TabIndex = 38
        '
        'FrmLotStatus_1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 435)
        Me.Controls.Add(Me.cboPeriod)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbMain)
        Me.Controls.Add(Me.dtpToDate)
        Me.Controls.Add(Me.dtpFromDate)
        Me.Controls.Add(Me.lblToDate)
        Me.Controls.Add(Me.lblFromDate)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmLotStatus_1"
        Me.ShowInTaskbar = False
        Me.Tag = "022708"
        Me.Text = "Lot Status"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bsLotStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsLotStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblLotStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbMain.ResumeLayout(False)
        Me.tpgOutput.ResumeLayout(False)
        Me.tpgOutput.PerformLayout()
        CType(Me.gridOutput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnOutput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnOutput.ResumeLayout(False)
        Me.bnOutput.PerformLayout()
        Me.tpgLotStatus.ResumeLayout(False)
        Me.tpgLotStatus.PerformLayout()
        CType(Me.gridLotStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnLotStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnLotStatus.ResumeLayout(False)
        Me.bnLotStatus.PerformLayout()
        Me.tpgLotDebit.ResumeLayout(False)
        Me.tpgLotDebit.PerformLayout()
        CType(Me.gridDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bsDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnDebit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnDebit.ResumeLayout(False)
        Me.bnDebit.PerformLayout()
        Me.tpgExcess.ResumeLayout(False)
        Me.tpgExcess.PerformLayout()
        CType(Me.bnExcess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnExcess.ResumeLayout(False)
        Me.bnExcess.PerformLayout()
        CType(Me.bsExcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsExcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tblExcess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridExcess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents bsLotStatus As System.Windows.Forms.BindingSource
    Friend WithEvents dsLotStatus As System.Data.DataSet
    Friend WithEvents tblLotStatus As System.Data.DataTable
    Friend WithEvents gridOutput As UtilityControl.CustomDataGridView
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuView As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblToDate As System.Windows.Forms.Label
    Friend WithEvents lblFromDate As System.Windows.Forms.Label
    Friend WithEvents tbMain As System.Windows.Forms.TabControl
    Friend WithEvents tpgOutput As System.Windows.Forms.TabPage
    Friend WithEvents tpgLotStatus As System.Windows.Forms.TabPage
    Friend WithEvents gridLotStatus As UtilityControl.CustomDataGridView
    Friend WithEvents bnOutput As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnLotStatus As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bsOutput As System.Windows.Forms.BindingSource
    Friend WithEvents dsOutput As System.Data.DataSet
    Friend WithEvents tblOutput As System.Data.DataTable
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mnuAddNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents cboPeriod As System.Windows.Forms.ComboBox
    Friend WithEvents DataColumn15 As System.Data.DataColumn
    Friend WithEvents mnuBack As System.Windows.Forms.ToolStripButton
    Friend WithEvents PeriodCode As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents FromDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Idx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartLot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataColumn16 As System.Data.DataColumn
    Friend WithEvents DataColumn17 As System.Data.DataColumn
    Friend WithEvents tpgLotDebit As System.Windows.Forms.TabPage
    Friend WithEvents gridDebit As UtilityControl.CustomDataGridView
    Friend WithEvents mnuViewDebit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dsDebit As System.Data.DataSet
    Friend WithEvents tblDebit As System.Data.DataTable
    Friend WithEvents DataColumn18 As System.Data.DataColumn
    Friend WithEvents DataColumn19 As System.Data.DataColumn
    Friend WithEvents DataColumn20 As System.Data.DataColumn
    Friend WithEvents DataColumn21 As System.Data.DataColumn
    Friend WithEvents DataColumn22 As System.Data.DataColumn
    Friend WithEvents DataColumn23 As System.Data.DataColumn
    Friend WithEvents DataColumn24 As System.Data.DataColumn
    Friend WithEvents DataColumn26 As System.Data.DataColumn
    Friend WithEvents bsDebit As System.Windows.Forms.BindingSource
    Friend WithEvents bnDebit As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox2 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtProductCode3 As System.Windows.Forms.TextBox
    Friend WithEvents tpgExcess As System.Windows.Forms.TabPage
    Friend WithEvents txtProductCode4 As System.Windows.Forms.TextBox
    Friend WithEvents gridExcess As UtilityControl.CustomDataGridView
    Friend WithEvents mnuViewExcess As System.Windows.Forms.ToolStripButton
    Friend WithEvents bnExcess As System.Windows.Forms.BindingNavigator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripTextBox3 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dsExcess As System.Data.DataSet
    Friend WithEvents tblExcess As System.Data.DataTable
    Friend WithEvents DataColumn25 As System.Data.DataColumn
    Friend WithEvents DataColumn27 As System.Data.DataColumn
    Friend WithEvents DataColumn28 As System.Data.DataColumn
    Friend WithEvents DataColumn29 As System.Data.DataColumn
    Friend WithEvents DataColumn33 As System.Data.DataColumn
    Friend WithEvents bsExcess As System.Windows.Forms.BindingSource
    Friend WithEvents txtProductCode2 As System.Windows.Forms.TextBox
    Friend WithEvents txtProductCode1 As System.Windows.Forms.TextBox
    Friend WithEvents DataColumn30 As System.Data.DataColumn
    Friend WithEvents DataColumn31 As System.Data.DataColumn
    Friend WithEvents DataColumn32 As System.Data.DataColumn
    Friend WithEvents DataColumn34 As System.Data.DataColumn
    Friend WithEvents DataColumn35 As System.Data.DataColumn
    Friend WithEvents DataColumn36 As System.Data.DataColumn
    Friend WithEvents DataColumn37 As System.Data.DataColumn
    Friend WithEvents Idx1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlanningDate As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProductCode1 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents RevisionCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Standard As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProductCode2 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents RevisionCode2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentCode2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumber2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessNumber2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessCode2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProcessName2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Idx2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Standard2 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProductCode3 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents RevisionCode3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComponentCode3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LotNumber3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Idx3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsOutside As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Standard3 As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
End Class
