﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompleteProcess
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompleteProcess))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuImport = New System.Windows.Forms.ToolStripButton()
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
        Me.bnCompleteProcess = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.gridCompleteProcess = New UtilityControl.CustomDataGridView()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CustomerNameE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.roisang1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.roisang2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inmuc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.etching1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.etching2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plasma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dotlo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.xulyuv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.thumach1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preset = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.say = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.entek = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.niau = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tafue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cls00 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cls01 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kiem1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clu00 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dot3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.giaap = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.phanloai = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.catS00 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.catC00 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lami = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.developresist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ssexposurefirst = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tapemask = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.softet1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.softet2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.softet3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kiemdangtam = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.daptapemask = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.randomsample = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tapemask2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laserdirect = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductCode_K = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtProductCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCustomerNameE = New System.Windows.Forms.TextBox()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bnCompleteProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnCompleteProcess.SuspendLayout()
        CType(Me.gridCompleteProcess, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuEdit, Me.ToolStripSeparator2, Me.mnuExport, Me.mnuImport, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(910, 55)
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
        Me.mnuShowAll.ToolTipText = "Show All"
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
        Me.mnuImport.ToolTipText = "Show All"
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
        'bnCompleteProcess
        '
        Me.bnCompleteProcess.AddNewItem = Nothing
        Me.bnCompleteProcess.CountItem = Me.BindingNavigatorCountItem
        Me.bnCompleteProcess.DeleteItem = Nothing
        Me.bnCompleteProcess.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnCompleteProcess.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bnCompleteProcess.Location = New System.Drawing.Point(0, 410)
        Me.bnCompleteProcess.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnCompleteProcess.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnCompleteProcess.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnCompleteProcess.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnCompleteProcess.Name = "bnCompleteProcess"
        Me.bnCompleteProcess.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnCompleteProcess.Size = New System.Drawing.Size(910, 25)
        Me.bnCompleteProcess.TabIndex = 22
        Me.bnCompleteProcess.Text = "BindingNavigator1"
        '
        'gridCompleteProcess
        '
        Me.gridCompleteProcess.AllowUserToAddRows = False
        Me.gridCompleteProcess.AllowUserToDeleteRows = False
        Me.gridCompleteProcess.AllowUserToOrderColumns = True
        Me.gridCompleteProcess.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridCompleteProcess.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridCompleteProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridCompleteProcess.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductCode, Me.CustomerNameE, Me.roisang1, Me.roisang2, Me.inmuc, Me.etching1, Me.etching2, Me.plasma, Me.laser, Me.pth, Me.dotlo, Me.xulyuv, Me.thumach1, Me.preset, Me.say, Me.entek, Me.niau, Me.tafue, Me.cls00, Me.cls01, Me.kiem1, Me.clu00, Me.dot3, Me.giaap, Me.phanloai, Me.catS00, Me.catC00, Me.lami, Me.developresist, Me.ssexposurefirst, Me.tapemask, Me.softet1, Me.softet2, Me.softet3, Me.kiemdangtam, Me.daptapemask, Me.randomsample, Me.tapemask2, Me.laserdirect, Me.ProductCode_K})
        Me.gridCompleteProcess.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridCompleteProcess.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridCompleteProcess.EnableHeadersVisualStyles = False
        Me.gridCompleteProcess.Location = New System.Drawing.Point(0, 55)
        Me.gridCompleteProcess.Name = "gridCompleteProcess"
        Me.gridCompleteProcess.RowHeadersWidth = 15
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridCompleteProcess.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridCompleteProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridCompleteProcess.Size = New System.Drawing.Size(910, 355)
        Me.gridCompleteProcess.TabIndex = 23
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "ProductCode"
        Me.ProductCode.HeaderText = "ProductCode"
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProductCode.Width = 75
        '
        'CustomerNameE
        '
        Me.CustomerNameE.DataPropertyName = "CustomerNameE"
        Me.CustomerNameE.HeaderText = "CustomerNameE"
        Me.CustomerNameE.Name = "CustomerNameE"
        Me.CustomerNameE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'roisang1
        '
        Me.roisang1.DataPropertyName = "roisang1"
        Me.roisang1.HeaderText = "roisang1"
        Me.roisang1.Name = "roisang1"
        Me.roisang1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.roisang1.Width = 75
        '
        'roisang2
        '
        Me.roisang2.DataPropertyName = "roisang2"
        Me.roisang2.HeaderText = "roisang2"
        Me.roisang2.Name = "roisang2"
        Me.roisang2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.roisang2.Width = 75
        '
        'inmuc
        '
        Me.inmuc.DataPropertyName = "inmuc"
        Me.inmuc.HeaderText = "inmuc"
        Me.inmuc.Name = "inmuc"
        Me.inmuc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.inmuc.Width = 75
        '
        'etching1
        '
        Me.etching1.DataPropertyName = "etching1"
        Me.etching1.HeaderText = "etching1"
        Me.etching1.Name = "etching1"
        Me.etching1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.etching1.Width = 75
        '
        'etching2
        '
        Me.etching2.DataPropertyName = "etching2"
        Me.etching2.HeaderText = "etching2"
        Me.etching2.Name = "etching2"
        Me.etching2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.etching2.Width = 75
        '
        'plasma
        '
        Me.plasma.DataPropertyName = "plasma"
        Me.plasma.HeaderText = "plasma"
        Me.plasma.Name = "plasma"
        Me.plasma.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.plasma.Width = 75
        '
        'laser
        '
        Me.laser.DataPropertyName = "laser"
        Me.laser.HeaderText = "laser"
        Me.laser.Name = "laser"
        Me.laser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.laser.Width = 75
        '
        'pth
        '
        Me.pth.DataPropertyName = "pth"
        Me.pth.HeaderText = "pth"
        Me.pth.Name = "pth"
        Me.pth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pth.Width = 75
        '
        'dotlo
        '
        Me.dotlo.DataPropertyName = "dotlo"
        Me.dotlo.HeaderText = "dotlo"
        Me.dotlo.Name = "dotlo"
        Me.dotlo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dotlo.Width = 75
        '
        'xulyuv
        '
        Me.xulyuv.DataPropertyName = "xulyuv"
        Me.xulyuv.HeaderText = "xulyuv"
        Me.xulyuv.Name = "xulyuv"
        Me.xulyuv.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.xulyuv.Width = 75
        '
        'thumach1
        '
        Me.thumach1.DataPropertyName = "thumach1"
        Me.thumach1.HeaderText = "thumach1"
        Me.thumach1.Name = "thumach1"
        Me.thumach1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.thumach1.Width = 75
        '
        'preset
        '
        Me.preset.DataPropertyName = "preset"
        Me.preset.HeaderText = "preset"
        Me.preset.Name = "preset"
        Me.preset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.preset.Width = 75
        '
        'say
        '
        Me.say.DataPropertyName = "say"
        Me.say.HeaderText = "say"
        Me.say.Name = "say"
        Me.say.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.say.Width = 75
        '
        'entek
        '
        Me.entek.DataPropertyName = "entek"
        Me.entek.HeaderText = "entek"
        Me.entek.Name = "entek"
        Me.entek.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.entek.Width = 75
        '
        'niau
        '
        Me.niau.DataPropertyName = "niau"
        Me.niau.HeaderText = "niau"
        Me.niau.Name = "niau"
        Me.niau.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.niau.Width = 75
        '
        'tafue
        '
        Me.tafue.DataPropertyName = "tafue"
        Me.tafue.HeaderText = "tafue"
        Me.tafue.Name = "tafue"
        Me.tafue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tafue.Width = 75
        '
        'cls00
        '
        Me.cls00.DataPropertyName = "cls00"
        Me.cls00.HeaderText = "cls00"
        Me.cls00.Name = "cls00"
        Me.cls00.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cls00.Width = 75
        '
        'cls01
        '
        Me.cls01.DataPropertyName = "cls01"
        Me.cls01.HeaderText = "cls01"
        Me.cls01.Name = "cls01"
        Me.cls01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.cls01.Width = 75
        '
        'kiem1
        '
        Me.kiem1.DataPropertyName = "kiem1"
        Me.kiem1.HeaderText = "kiem1"
        Me.kiem1.Name = "kiem1"
        Me.kiem1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.kiem1.Width = 75
        '
        'clu00
        '
        Me.clu00.DataPropertyName = "clu00"
        Me.clu00.HeaderText = "clu00"
        Me.clu00.Name = "clu00"
        Me.clu00.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dot3
        '
        Me.dot3.DataPropertyName = "dot3"
        Me.dot3.HeaderText = "dot3"
        Me.dot3.Name = "dot3"
        Me.dot3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.dot3.Width = 75
        '
        'giaap
        '
        Me.giaap.DataPropertyName = "giaap"
        Me.giaap.HeaderText = "giaap"
        Me.giaap.Name = "giaap"
        Me.giaap.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.giaap.Width = 75
        '
        'phanloai
        '
        Me.phanloai.DataPropertyName = "phanloai"
        Me.phanloai.HeaderText = "phanloai"
        Me.phanloai.Name = "phanloai"
        Me.phanloai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.phanloai.Width = 75
        '
        'catS00
        '
        Me.catS00.DataPropertyName = "catS00"
        Me.catS00.HeaderText = "catS00"
        Me.catS00.Name = "catS00"
        Me.catS00.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.catS00.Width = 75
        '
        'catC00
        '
        Me.catC00.DataPropertyName = "catC00"
        Me.catC00.HeaderText = "catC00"
        Me.catC00.Name = "catC00"
        Me.catC00.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.catC00.Width = 75
        '
        'lami
        '
        Me.lami.DataPropertyName = "lami"
        Me.lami.HeaderText = "lami"
        Me.lami.Name = "lami"
        Me.lami.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.lami.Width = 75
        '
        'developresist
        '
        Me.developresist.DataPropertyName = "developresist"
        Me.developresist.HeaderText = "developresist"
        Me.developresist.Name = "developresist"
        Me.developresist.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ssexposurefirst
        '
        Me.ssexposurefirst.DataPropertyName = "ssexposurefirst"
        Me.ssexposurefirst.HeaderText = "ssexposurefirst"
        Me.ssexposurefirst.Name = "ssexposurefirst"
        Me.ssexposurefirst.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'tapemask
        '
        Me.tapemask.DataPropertyName = "tapemask"
        Me.tapemask.HeaderText = "tapemask"
        Me.tapemask.Name = "tapemask"
        Me.tapemask.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.tapemask.Width = 75
        '
        'softet1
        '
        Me.softet1.DataPropertyName = "softet1"
        Me.softet1.HeaderText = "softet1"
        Me.softet1.Name = "softet1"
        Me.softet1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'softet2
        '
        Me.softet2.DataPropertyName = "softet2"
        Me.softet2.HeaderText = "softet2"
        Me.softet2.Name = "softet2"
        Me.softet2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'softet3
        '
        Me.softet3.DataPropertyName = "softet3"
        Me.softet3.HeaderText = "softet3"
        Me.softet3.Name = "softet3"
        Me.softet3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'kiemdangtam
        '
        Me.kiemdangtam.DataPropertyName = "kiemdangtam"
        Me.kiemdangtam.HeaderText = "kiemdangtam"
        Me.kiemdangtam.Name = "kiemdangtam"
        Me.kiemdangtam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'daptapemask
        '
        Me.daptapemask.DataPropertyName = "daptapemask"
        Me.daptapemask.HeaderText = "daptapemask"
        Me.daptapemask.Name = "daptapemask"
        Me.daptapemask.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'randomsample
        '
        Me.randomsample.DataPropertyName = "randomsample"
        Me.randomsample.HeaderText = "randomsample"
        Me.randomsample.Name = "randomsample"
        Me.randomsample.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'tapemask2
        '
        Me.tapemask2.DataPropertyName = "tapemask2"
        Me.tapemask2.HeaderText = "tapemask2"
        Me.tapemask2.Name = "tapemask2"
        Me.tapemask2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'laserdirect
        '
        Me.laserdirect.DataPropertyName = "laserdirect"
        Me.laserdirect.HeaderText = "laserdirect"
        Me.laserdirect.Name = "laserdirect"
        '
        'ProductCode_K
        '
        Me.ProductCode_K.DataPropertyName = "ProductCode_K"
        Me.ProductCode_K.HeaderText = "ProductCode_K"
        Me.ProductCode_K.Name = "ProductCode_K"
        Me.ProductCode_K.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ProductCode_K.Visible = False
        '
        'txtProductCode
        '
        Me.txtProductCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtProductCode.Location = New System.Drawing.Point(258, 26)
        Me.txtProductCode.MaxLength = 100
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(100, 20)
        Me.txtProductCode.TabIndex = 44
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(258, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Tag = ""
        Me.Label1.Text = "Filter ProductCode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(364, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 47
        Me.Label2.Tag = ""
        Me.Label2.Text = "Filter Customer"
        '
        'txtCustomerNameE
        '
        Me.txtCustomerNameE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtCustomerNameE.Location = New System.Drawing.Point(364, 26)
        Me.txtCustomerNameE.MaxLength = 100
        Me.txtCustomerNameE.Name = "txtCustomerNameE"
        Me.txtCustomerNameE.Size = New System.Drawing.Size(100, 20)
        Me.txtCustomerNameE.TabIndex = 46
        '
        'FrmCompleteProcess
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 435)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCustomerNameE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtProductCode)
        Me.Controls.Add(Me.gridCompleteProcess)
        Me.Controls.Add(Me.bnCompleteProcess)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmCompleteProcess"
        Me.ShowInTaskbar = False
        Me.Tag = "0254PD01"
        Me.Text = "Complete Process"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bnCompleteProcess, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnCompleteProcess.ResumeLayout(False)
        Me.bnCompleteProcess.PerformLayout()
        CType(Me.gridCompleteProcess, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents bnCompleteProcess As System.Windows.Forms.BindingNavigator
    Friend WithEvents gridCompleteProcess As UtilityControl.CustomDataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtProductCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerNameE As System.Windows.Forms.TextBox
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerNameE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents roisang1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents roisang2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inmuc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents etching1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents etching2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plasma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents laser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dotlo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents xulyuv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents thumach1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents preset As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents say As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents entek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents niau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tafue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cls00 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cls01 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kiem1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clu00 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dot3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents giaap As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents phanloai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents catS00 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents catC00 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lami As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents developresist As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ssexposurefirst As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tapemask As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents softet1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents softet2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents softet3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kiemdangtam As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents daptapemask As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents randomsample As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tapemask2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents laserdirect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductCode_K As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
