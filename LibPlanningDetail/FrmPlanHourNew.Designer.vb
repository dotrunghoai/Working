﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPlanHourNew
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPlanHourNew))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuRun = New System.Windows.Forms.ToolStripButton()
        Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuSaveLeadtime = New System.Windows.Forms.ToolStripButton()
        Me.mnuSavePlan = New System.Windows.Forms.ToolStripButton()
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
        Me.bdn = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuNewForm = New System.Windows.Forms.ToolStripButton()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.txtLotNoList = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.rdCNN = New System.Windows.Forms.RadioButton()
        Me.rdKNN = New System.Windows.Forms.RadioButton()
        Me.dtpPlanDate = New System.Windows.Forms.DateTimePicker()
        Me.ckoXem = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rdoHoliday = New System.Windows.Forms.RadioButton()
        Me.rdoHC = New System.Windows.Forms.RadioButton()
        Me.rdo2Ca = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdo3Ca = New System.Windows.Forms.RadioButton()
        Me.ctm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuXoa = New System.Windows.Forms.ToolStripMenuItem()
        Me.ckoPR = New DevExpress.XtraEditors.CheckEdit()
        Me.ckoSunday = New DevExpress.XtraEditors.CheckEdit()
        Me.gridP = New UtilityControl.CustomDataGridView()
        Me.ProductCodeP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RevisionCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessNumberP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessCodeP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProcessNameP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TGGC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SLThietBi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadtimeThietBi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SlThietBiA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.leadtimeTDG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeadtimeSub = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TGDung = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LotListP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RemarkP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridKQ = New UtilityControl.CustomDataGridView()
        Me.PlanDate = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ProductCodeK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.LotNo = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ProcessNumberK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ProcessCodeK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ProcessNameK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.TGGCK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.SlThietBiK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.LeadtimeThietBiK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.SLThietBiAK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.LeadtimeTDGK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.LeadtimeSubK = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.LotList = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Remark = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.TGKT = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.TGTT = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.SaiLech = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Status = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.LyDo = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bdn.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ctm.SuspendLayout()
        CType(Me.ckoPR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckoSunday.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridKQ, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRun, Me.mnuEdit, Me.mnuExport, Me.mnuSaveLeadtime, Me.mnuSavePlan, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1146, 55)
        Me.tlsMenu.TabIndex = 0
        '
        'mnuRun
        '
        Me.mnuRun.AutoSize = False
        Me.mnuRun.Image = CType(resources.GetObject("mnuRun.Image"), System.Drawing.Image)
        Me.mnuRun.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuRun.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuRun.Name = "mnuRun"
        Me.mnuRun.Size = New System.Drawing.Size(60, 50)
        Me.mnuRun.Text = "Run"
        Me.mnuRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuRun.ToolTipText = "Run"
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
        'mnuSaveLeadtime
        '
        Me.mnuSaveLeadtime.AutoSize = False
        Me.mnuSaveLeadtime.Image = CType(resources.GetObject("mnuSaveLeadtime.Image"), System.Drawing.Image)
        Me.mnuSaveLeadtime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSaveLeadtime.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSaveLeadtime.Name = "mnuSaveLeadtime"
        Me.mnuSaveLeadtime.Size = New System.Drawing.Size(60, 50)
        Me.mnuSaveLeadtime.Text = "SaveLT"
        Me.mnuSaveLeadtime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuSaveLeadtime.ToolTipText = "Save Leadtime"
        '
        'mnuSavePlan
        '
        Me.mnuSavePlan.AutoSize = False
        Me.mnuSavePlan.Image = CType(resources.GetObject("mnuSavePlan.Image"), System.Drawing.Image)
        Me.mnuSavePlan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSavePlan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSavePlan.Name = "mnuSavePlan"
        Me.mnuSavePlan.Size = New System.Drawing.Size(60, 50)
        Me.mnuSavePlan.Text = "SavePlan"
        Me.mnuSavePlan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuSavePlan.ToolTipText = "SavePlan"
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
        'bdn
        '
        Me.bdn.AddNewItem = Nothing
        Me.bdn.CountItem = Me.BindingNavigatorCountItem
        Me.bdn.DeleteItem = Nothing
        Me.bdn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bdn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ToolStripLabel1, Me.ToolStripSeparator2, Me.mnuNewForm})
        Me.bdn.Location = New System.Drawing.Point(0, 434)
        Me.bdn.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bdn.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bdn.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bdn.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bdn.Name = "bdn"
        Me.bdn.PositionItem = Me.BindingNavigatorPositionItem
        Me.bdn.Size = New System.Drawing.Size(1146, 25)
        Me.bdn.TabIndex = 22
        Me.bdn.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(149, 22)
        Me.ToolStripLabel1.Text = "Double click to view dettail"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'mnuNewForm
        '
        Me.mnuNewForm.Image = CType(resources.GetObject("mnuNewForm.Image"), System.Drawing.Image)
        Me.mnuNewForm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuNewForm.Name = "mnuNewForm"
        Me.mnuNewForm.Size = New System.Drawing.Size(82, 22)
        Me.mnuNewForm.Text = "New Form"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(392, 10)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(44, 13)
        Me.lblProcess.TabIndex = 28
        Me.lblProcess.Text = "Product"
        '
        'txtProductCode
        '
        Me.txtProductCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProductCode.Location = New System.Drawing.Point(392, 24)
        Me.txtProductCode.MaxLength = 5
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(65, 20)
        Me.txtProductCode.TabIndex = 30
        Me.txtProductCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLotNoList
        '
        Me.txtLotNoList.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLotNoList.Location = New System.Drawing.Point(457, 24)
        Me.txtLotNoList.Name = "txtLotNoList"
        Me.txtLotNoList.Size = New System.Drawing.Size(87, 20)
        Me.txtLotNoList.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(457, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Lot# List"
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Location = New System.Drawing.Point(546, 21)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(86, 23)
        Me.btnAdd.TabIndex = 33
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'rdCNN
        '
        Me.rdCNN.AutoSize = True
        Me.rdCNN.Location = New System.Drawing.Point(635, 25)
        Me.rdCNN.Name = "rdCNN"
        Me.rdCNN.Size = New System.Drawing.Size(198, 17)
        Me.rdCNN.TabIndex = 34
        Me.rdCNN.TabStop = True
        Me.rdCNN.Text = "Có làm ngày nghỉ, không làm ngày lễ"
        Me.rdCNN.UseVisualStyleBackColor = True
        '
        'rdKNN
        '
        Me.rdKNN.AutoSize = True
        Me.rdKNN.Checked = True
        Me.rdKNN.Location = New System.Drawing.Point(635, 2)
        Me.rdKNN.Name = "rdKNN"
        Me.rdKNN.Size = New System.Drawing.Size(124, 17)
        Me.rdKNN.TabIndex = 35
        Me.rdKNN.TabStop = True
        Me.rdKNN.Text = "Không làm ngày nghỉ"
        Me.rdKNN.UseVisualStyleBackColor = True
        '
        'dtpPlanDate
        '
        Me.dtpPlanDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPlanDate.Location = New System.Drawing.Point(310, 24)
        Me.dtpPlanDate.Name = "dtpPlanDate"
        Me.dtpPlanDate.Size = New System.Drawing.Size(82, 20)
        Me.dtpPlanDate.TabIndex = 36
        '
        'ckoXem
        '
        Me.ckoXem.AutoSize = True
        Me.ckoXem.Location = New System.Drawing.Point(546, 2)
        Me.ckoXem.Name = "ckoXem"
        Me.ckoXem.Size = New System.Drawing.Size(86, 17)
        Me.ckoXem.TabIndex = 39
        Me.ckoXem.Text = "Xem kết quả"
        Me.ckoXem.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(310, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Ngày"
        '
        'rdoHoliday
        '
        Me.rdoHoliday.AutoSize = True
        Me.rdoHoliday.Location = New System.Drawing.Point(761, 2)
        Me.rdoHoliday.Name = "rdoHoliday"
        Me.rdoHoliday.Size = New System.Drawing.Size(135, 17)
        Me.rdoHoliday.TabIndex = 42
        Me.rdoHoliday.TabStop = True
        Me.rdoHoliday.Text = "Có làm cả ngày nghỉ+lễ"
        Me.rdoHoliday.UseVisualStyleBackColor = True
        '
        'rdoHC
        '
        Me.rdoHC.AutoSize = True
        Me.rdoHC.Location = New System.Drawing.Point(6, 35)
        Me.rdoHC.Name = "rdoHC"
        Me.rdoHC.Size = New System.Drawing.Size(40, 17)
        Me.rdoHC.TabIndex = 43
        Me.rdoHC.Text = "HC"
        Me.rdoHC.UseVisualStyleBackColor = True
        '
        'rdo2Ca
        '
        Me.rdo2Ca.AutoSize = True
        Me.rdo2Ca.Checked = True
        Me.rdo2Ca.Location = New System.Drawing.Point(6, 15)
        Me.rdo2Ca.Name = "rdo2Ca"
        Me.rdo2Ca.Size = New System.Drawing.Size(47, 17)
        Me.rdo2Ca.TabIndex = 44
        Me.rdo2Ca.TabStop = True
        Me.rdo2Ca.Text = "2 Ca"
        Me.rdo2Ca.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdo3Ca)
        Me.GroupBox1.Controls.Add(Me.rdoHC)
        Me.GroupBox1.Controls.Add(Me.rdo2Ca)
        Me.GroupBox1.Location = New System.Drawing.Point(898, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(114, 55)
        Me.GroupBox1.TabIndex = 45
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ca"
        '
        'rdo3Ca
        '
        Me.rdo3Ca.AutoSize = True
        Me.rdo3Ca.Location = New System.Drawing.Point(59, 15)
        Me.rdo3Ca.Name = "rdo3Ca"
        Me.rdo3Ca.Size = New System.Drawing.Size(47, 17)
        Me.rdo3Ca.TabIndex = 45
        Me.rdo3Ca.Text = "3 Ca"
        Me.rdo3Ca.UseVisualStyleBackColor = True
        '
        'ctm
        '
        Me.ctm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuXoa})
        Me.ctm.Name = "ContextMenuStrip1"
        Me.ctm.Size = New System.Drawing.Size(194, 26)
        '
        'mnuXoa
        '
        Me.mnuXoa.Image = CType(resources.GetObject("mnuXoa.Image"), System.Drawing.Image)
        Me.mnuXoa.Name = "mnuXoa"
        Me.mnuXoa.Size = New System.Drawing.Size(193, 22)
        Me.mnuXoa.Text = "Xóa dữ liệu đang chọn"
        '
        'ckoPR
        '
        Me.ckoPR.EditValue = True
        Me.ckoPR.Location = New System.Drawing.Point(1015, 5)
        Me.ckoPR.Name = "ckoPR"
        Me.ckoPR.Properties.Caption = "PR-INS"
        Me.ckoPR.Size = New System.Drawing.Size(91, 20)
        Me.ckoPR.TabIndex = 47
        '
        'ckoSunday
        '
        Me.ckoSunday.Location = New System.Drawing.Point(1015, 24)
        Me.ckoSunday.Name = "ckoSunday"
        Me.ckoSunday.Properties.Caption = "Not work Sunday"
        Me.ckoSunday.Size = New System.Drawing.Size(108, 20)
        Me.ckoSunday.TabIndex = 48
        '
        'gridP
        '
        Me.gridP.AllowUserToAddRows = False
        Me.gridP.AllowUserToDeleteRows = False
        Me.gridP.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridP.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridP.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridP.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridP.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductCodeP, Me.RevisionCode, Me.ProcessNumberP, Me.ProcessCodeP, Me.ProcessNameP, Me.TGGC, Me.SLThietBi, Me.LeadtimeThietBi, Me.SlThietBiA, Me.leadtimeTDG, Me.LeadtimeSub, Me.TGDung, Me.LotListP, Me.RemarkP})
        Me.gridP.ContextMenuStrip = Me.ctm
        Me.gridP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridP.EnableHeadersVisualStyles = False
        Me.gridP.Location = New System.Drawing.Point(0, 55)
        Me.gridP.Name = "gridP"
        Me.gridP.RowHeadersWidth = 15
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridP.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridP.Size = New System.Drawing.Size(1146, 379)
        Me.gridP.TabIndex = 23
        '
        'ProductCodeP
        '
        Me.ProductCodeP.DataPropertyName = "ProductCode"
        Me.ProductCodeP.Frozen = True
        Me.ProductCodeP.HeaderText = "ProductCode"
        Me.ProductCodeP.Name = "ProductCodeP"
        Me.ProductCodeP.ReadOnly = True
        Me.ProductCodeP.Width = 50
        '
        'RevisionCode
        '
        Me.RevisionCode.DataPropertyName = "RevisionCode"
        Me.RevisionCode.Frozen = True
        Me.RevisionCode.HeaderText = "RevisionCode"
        Me.RevisionCode.Name = "RevisionCode"
        Me.RevisionCode.ReadOnly = True
        Me.RevisionCode.Width = 20
        '
        'ProcessNumberP
        '
        Me.ProcessNumberP.DataPropertyName = "ProcessNumber"
        Me.ProcessNumberP.Frozen = True
        Me.ProcessNumberP.HeaderText = "ProcessNumber"
        Me.ProcessNumberP.Name = "ProcessNumberP"
        Me.ProcessNumberP.ReadOnly = True
        Me.ProcessNumberP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessNumberP.Width = 50
        '
        'ProcessCodeP
        '
        Me.ProcessCodeP.DataPropertyName = "ProcessCode"
        Me.ProcessCodeP.Frozen = True
        Me.ProcessCodeP.HeaderText = "ProcessCode"
        Me.ProcessCodeP.Name = "ProcessCodeP"
        Me.ProcessCodeP.ReadOnly = True
        Me.ProcessCodeP.Width = 50
        '
        'ProcessNameP
        '
        Me.ProcessNameP.DataPropertyName = "ProcessName"
        Me.ProcessNameP.Frozen = True
        Me.ProcessNameP.HeaderText = "ProcessName"
        Me.ProcessNameP.Name = "ProcessNameP"
        Me.ProcessNameP.ReadOnly = True
        Me.ProcessNameP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TGGC
        '
        Me.TGGC.DataPropertyName = "TGGC"
        Me.TGGC.Frozen = True
        Me.TGGC.HeaderText = "TGGC"
        Me.TGGC.Name = "TGGC"
        Me.TGGC.ReadOnly = True
        Me.TGGC.Width = 50
        '
        'SLThietBi
        '
        Me.SLThietBi.DataPropertyName = "SLThietBi"
        Me.SLThietBi.Frozen = True
        Me.SLThietBi.HeaderText = "SL ThietBi"
        Me.SLThietBi.Name = "SLThietBi"
        Me.SLThietBi.ReadOnly = True
        Me.SLThietBi.Width = 50
        '
        'LeadtimeThietBi
        '
        Me.LeadtimeThietBi.DataPropertyName = "LeadtimeThietBi"
        Me.LeadtimeThietBi.Frozen = True
        Me.LeadtimeThietBi.HeaderText = "Leadtime ThietBi"
        Me.LeadtimeThietBi.Name = "LeadtimeThietBi"
        Me.LeadtimeThietBi.ReadOnly = True
        Me.LeadtimeThietBi.Width = 50
        '
        'SlThietBiA
        '
        Me.SlThietBiA.DataPropertyName = "SlThietBiA"
        Me.SlThietBiA.Frozen = True
        Me.SlThietBiA.HeaderText = "SLThietBi Actual"
        Me.SlThietBiA.Name = "SlThietBiA"
        Me.SlThietBiA.ReadOnly = True
        Me.SlThietBiA.Width = 50
        '
        'leadtimeTDG
        '
        Me.leadtimeTDG.DataPropertyName = "leadtimeTDG"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "N2"
        Me.leadtimeTDG.DefaultCellStyle = DataGridViewCellStyle2
        Me.leadtimeTDG.Frozen = True
        Me.leadtimeTDG.HeaderText = "Leadtime TDG"
        Me.leadtimeTDG.Name = "leadtimeTDG"
        Me.leadtimeTDG.ReadOnly = True
        Me.leadtimeTDG.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.leadtimeTDG.Width = 50
        '
        'LeadtimeSub
        '
        Me.LeadtimeSub.DataPropertyName = "LeadtimeSub"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "N2"
        Me.LeadtimeSub.DefaultCellStyle = DataGridViewCellStyle3
        Me.LeadtimeSub.Frozen = True
        Me.LeadtimeSub.HeaderText = "Leadtime Sub"
        Me.LeadtimeSub.Name = "LeadtimeSub"
        Me.LeadtimeSub.ReadOnly = True
        Me.LeadtimeSub.Width = 50
        '
        'TGDung
        '
        Me.TGDung.DataPropertyName = "TGDung"
        Me.TGDung.Frozen = True
        Me.TGDung.HeaderText = "TG dừng"
        Me.TGDung.Name = "TGDung"
        Me.TGDung.Width = 80
        '
        'LotListP
        '
        Me.LotListP.DataPropertyName = "LotList"
        Me.LotListP.Frozen = True
        Me.LotListP.HeaderText = "LotList"
        Me.LotListP.Name = "LotListP"
        '
        'RemarkP
        '
        Me.RemarkP.DataPropertyName = "Remark"
        Me.RemarkP.Frozen = True
        Me.RemarkP.HeaderText = "Remark"
        Me.RemarkP.Name = "RemarkP"
        Me.RemarkP.ReadOnly = True
        Me.RemarkP.Width = 60
        '
        'gridKQ
        '
        Me.gridKQ.AllowUserToAddRows = False
        Me.gridKQ.AllowUserToDeleteRows = False
        Me.gridKQ.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridKQ.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridKQ.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridKQ.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridKQ.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridKQ.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PlanDate, Me.ProductCodeK, Me.LotNo, Me.ProcessNumberK, Me.ProcessCodeK, Me.ProcessNameK, Me.TGGCK, Me.SlThietBiK, Me.LeadtimeThietBiK, Me.SLThietBiAK, Me.LeadtimeTDGK, Me.LeadtimeSubK, Me.LotList, Me.Remark, Me.TGKT, Me.TGTT, Me.SaiLech, Me.Status, Me.LyDo})
        Me.gridKQ.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridKQ.EnableHeadersVisualStyles = False
        Me.gridKQ.Location = New System.Drawing.Point(0, 55)
        Me.gridKQ.Name = "gridKQ"
        Me.gridKQ.ReadOnly = True
        Me.gridKQ.RowHeadersWidth = 15
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridKQ.RowsDefaultCellStyle = DataGridViewCellStyle15
        Me.gridKQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridKQ.Size = New System.Drawing.Size(1146, 379)
        Me.gridKQ.TabIndex = 40
        Me.gridKQ.Visible = False
        '
        'PlanDate
        '
        Me.PlanDate.DataPropertyName = "PlanDate"
        DataGridViewCellStyle6.Format = "dd-MM-yyyy"
        Me.PlanDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.PlanDate.HeaderText = "PlanDate"
        Me.PlanDate.Name = "PlanDate"
        Me.PlanDate.ReadOnly = True
        Me.PlanDate.Width = 80
        '
        'ProductCodeK
        '
        Me.ProductCodeK.DataPropertyName = "ProductCode"
        Me.ProductCodeK.HeaderText = "ProductCode"
        Me.ProductCodeK.Name = "ProductCodeK"
        Me.ProductCodeK.ReadOnly = True
        Me.ProductCodeK.Width = 50
        '
        'LotNo
        '
        Me.LotNo.DataPropertyName = "LotNo"
        Me.LotNo.HeaderText = "LotNo"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.ReadOnly = True
        Me.LotNo.Width = 50
        '
        'ProcessNumberK
        '
        Me.ProcessNumberK.DataPropertyName = "ProcessNumber"
        Me.ProcessNumberK.HeaderText = "ProcessNumber"
        Me.ProcessNumberK.Name = "ProcessNumberK"
        Me.ProcessNumberK.ReadOnly = True
        Me.ProcessNumberK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProcessNumberK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProcessNumberK.Width = 40
        '
        'ProcessCodeK
        '
        Me.ProcessCodeK.DataPropertyName = "ProcessCode"
        Me.ProcessCodeK.HeaderText = "ProcessCode"
        Me.ProcessCodeK.Name = "ProcessCodeK"
        Me.ProcessCodeK.ReadOnly = True
        Me.ProcessCodeK.Width = 40
        '
        'ProcessNameK
        '
        Me.ProcessNameK.DataPropertyName = "ProcessName"
        Me.ProcessNameK.HeaderText = "ProcessName"
        Me.ProcessNameK.Name = "ProcessNameK"
        Me.ProcessNameK.ReadOnly = True
        Me.ProcessNameK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ProcessNameK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TGGCK
        '
        Me.TGGCK.DataPropertyName = "TGGC"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.TGGCK.DefaultCellStyle = DataGridViewCellStyle7
        Me.TGGCK.HeaderText = "TGGC"
        Me.TGGCK.Name = "TGGCK"
        Me.TGGCK.ReadOnly = True
        Me.TGGCK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TGGCK.Width = 60
        '
        'SlThietBiK
        '
        Me.SlThietBiK.DataPropertyName = "SlThietBi"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.SlThietBiK.DefaultCellStyle = DataGridViewCellStyle8
        Me.SlThietBiK.HeaderText = "SLThietBi"
        Me.SlThietBiK.Name = "SlThietBiK"
        Me.SlThietBiK.ReadOnly = True
        Me.SlThietBiK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SlThietBiK.Width = 60
        '
        'LeadtimeThietBiK
        '
        Me.LeadtimeThietBiK.DataPropertyName = "LeadtimeThietBi"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.LeadtimeThietBiK.DefaultCellStyle = DataGridViewCellStyle9
        Me.LeadtimeThietBiK.HeaderText = "Leadtime ThietBi"
        Me.LeadtimeThietBiK.Name = "LeadtimeThietBiK"
        Me.LeadtimeThietBiK.ReadOnly = True
        Me.LeadtimeThietBiK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeadtimeThietBiK.Width = 60
        '
        'SLThietBiAK
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.SLThietBiAK.DefaultCellStyle = DataGridViewCellStyle10
        Me.SLThietBiAK.HeaderText = "SLThietBiA"
        Me.SLThietBiAK.Name = "SLThietBiAK"
        Me.SLThietBiAK.ReadOnly = True
        Me.SLThietBiAK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SLThietBiAK.Width = 60
        '
        'LeadtimeTDGK
        '
        Me.LeadtimeTDGK.DataPropertyName = "LeadtimeTDG"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.Format = "N2"
        Me.LeadtimeTDGK.DefaultCellStyle = DataGridViewCellStyle11
        Me.LeadtimeTDGK.HeaderText = "Leadtime TDG"
        Me.LeadtimeTDGK.Name = "LeadtimeTDGK"
        Me.LeadtimeTDGK.ReadOnly = True
        Me.LeadtimeTDGK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeadtimeTDGK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.LeadtimeTDGK.Width = 60
        '
        'LeadtimeSubK
        '
        Me.LeadtimeSubK.DataPropertyName = "LeadtimeSub"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.Format = "N2"
        Me.LeadtimeSubK.DefaultCellStyle = DataGridViewCellStyle12
        Me.LeadtimeSubK.HeaderText = "Leadtime Sub"
        Me.LeadtimeSubK.Name = "LeadtimeSubK"
        Me.LeadtimeSubK.ReadOnly = True
        Me.LeadtimeSubK.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LeadtimeSubK.Width = 60
        '
        'LotList
        '
        Me.LotList.DataPropertyName = "LotList"
        Me.LotList.HeaderText = "LotList"
        Me.LotList.Name = "LotList"
        Me.LotList.ReadOnly = True
        Me.LotList.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LotList.Width = 50
        '
        'Remark
        '
        Me.Remark.DataPropertyName = "Remark"
        Me.Remark.HeaderText = "Remark"
        Me.Remark.Name = "Remark"
        Me.Remark.ReadOnly = True
        Me.Remark.Width = 60
        '
        'TGKT
        '
        Me.TGKT.DataPropertyName = "TGKT"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "HH:mm dd-MM-yy"
        Me.TGKT.DefaultCellStyle = DataGridViewCellStyle13
        Me.TGKT.HeaderText = "TGKT"
        Me.TGKT.Name = "TGKT"
        Me.TGKT.ReadOnly = True
        Me.TGKT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TGKT.Width = 60
        '
        'TGTT
        '
        Me.TGTT.DataPropertyName = "TGTT"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "HH:mm dd-MM-yy"
        Me.TGTT.DefaultCellStyle = DataGridViewCellStyle14
        Me.TGTT.HeaderText = "TGTT"
        Me.TGTT.Name = "TGTT"
        Me.TGTT.ReadOnly = True
        Me.TGTT.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.TGTT.Width = 60
        '
        'SaiLech
        '
        Me.SaiLech.DataPropertyName = "SaiLech"
        Me.SaiLech.HeaderText = "SaiLech"
        Me.SaiLech.Name = "SaiLech"
        Me.SaiLech.ReadOnly = True
        Me.SaiLech.Width = 50
        '
        'Status
        '
        Me.Status.DataPropertyName = "Status"
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.ReadOnly = True
        Me.Status.Width = 50
        '
        'LyDo
        '
        Me.LyDo.DataPropertyName = "LyDo"
        Me.LyDo.HeaderText = "Lý do"
        Me.LyDo.Name = "LyDo"
        Me.LyDo.ReadOnly = True
        Me.LyDo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FrmPlanHourNew
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1146, 459)
        Me.Controls.Add(Me.ckoSunday)
        Me.Controls.Add(Me.ckoPR)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.rdoHoliday)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ckoXem)
        Me.Controls.Add(Me.dtpPlanDate)
        Me.Controls.Add(Me.rdKNN)
        Me.Controls.Add(Me.rdCNN)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLotNoList)
        Me.Controls.Add(Me.txtProductCode)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.bdn)
        Me.Controls.Add(Me.tlsMenu)
        Me.Controls.Add(Me.gridP)
        Me.Controls.Add(Me.gridKQ)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmPlanHourNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "0254PD06"
        Me.Text = "Lập tiến đồ giờ (Mới)"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bdn.ResumeLayout(False)
        Me.bdn.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ctm.ResumeLayout(False)
        CType(Me.ckoPR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckoSunday.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridKQ, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuRun As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents bdn As System.Windows.Forms.BindingNavigator
    Friend WithEvents gridP As UtilityControl.CustomDataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents txtLotNoList As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents rdCNN As System.Windows.Forms.RadioButton
    Friend WithEvents rdKNN As System.Windows.Forms.RadioButton
    Friend WithEvents dtpPlanDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ckoXem As System.Windows.Forms.CheckBox
    Friend WithEvents gridKQ As UtilityControl.CustomDataGridView
    Friend WithEvents mnuSavePlan As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents mnuSaveLeadtime As System.Windows.Forms.ToolStripButton
	Friend WithEvents rdoHoliday As System.Windows.Forms.RadioButton
	Friend WithEvents rdoHC As RadioButton
	Friend WithEvents rdo2Ca As RadioButton
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents rdo3Ca As RadioButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ctm As ContextMenuStrip
    Friend WithEvents mnuXoa As ToolStripMenuItem
    Friend WithEvents ProductCodeP As DataGridViewTextBoxColumn
    Friend WithEvents RevisionCode As DataGridViewTextBoxColumn
    Friend WithEvents ProcessNumberP As DataGridViewTextBoxColumn
    Friend WithEvents ProcessCodeP As DataGridViewTextBoxColumn
    Friend WithEvents ProcessNameP As DataGridViewTextBoxColumn
    Friend WithEvents TGGC As DataGridViewTextBoxColumn
    Friend WithEvents SLThietBi As DataGridViewTextBoxColumn
    Friend WithEvents LeadtimeThietBi As DataGridViewTextBoxColumn
    Friend WithEvents SlThietBiA As DataGridViewTextBoxColumn
    Friend WithEvents leadtimeTDG As DataGridViewTextBoxColumn
    Friend WithEvents LeadtimeSub As DataGridViewTextBoxColumn
    Friend WithEvents TGDung As DataGridViewTextBoxColumn
    Friend WithEvents LotListP As DataGridViewTextBoxColumn
    Friend WithEvents RemarkP As DataGridViewTextBoxColumn
    Friend WithEvents PlanDate As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProductCodeK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents LotNo As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProcessNumberK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProcessCodeK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProcessNameK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents TGGCK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents SlThietBiK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents LeadtimeThietBiK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents SLThietBiAK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents LeadtimeTDGK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents LeadtimeSubK As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents LotList As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Remark As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents TGKT As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents TGTT As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents SaiLech As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Status As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents LyDo As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ckoPR As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents ckoSunday As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents mnuNewForm As ToolStripButton
End Class
