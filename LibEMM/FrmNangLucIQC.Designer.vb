

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmNangLucIQC : Inherits DevExpress.XtraEditors.XtraForm

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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNangLucIQC))
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.tlsMenu = New System.Windows.Forms.ToolStrip()
		Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
		Me.mnuExport = New System.Windows.Forms.ToolStripButton()
		Me.mnuMasterIQC = New System.Windows.Forms.ToolStripButton()
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
		Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
		Me.lblSStatus = New System.Windows.Forms.ToolStripLabel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.dtpStart = New System.Windows.Forms.DateTimePicker()
		Me.grid = New UtilityControl.CustomDataGridView()
		Me.Ngay = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
		Me.HangMuc = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
		Me.HangMucSub = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
		Me.TGC = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
		Me.SoLot = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
		Me.TongTG = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
		Me.GhiChu = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
		Me.tlsMenu.SuspendLayout()
		CType(Me.bdn, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.bdn.SuspendLayout()
		CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'tlsMenu
		'
		Me.tlsMenu.AutoSize = False
		Me.tlsMenu.BackColor = System.Drawing.Color.White
		Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.mnuMasterIQC, Me.ToolStripSeparator1})
		Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
		Me.tlsMenu.Name = "tlsMenu"
		Me.tlsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
		Me.tlsMenu.Size = New System.Drawing.Size(987, 59)
		Me.tlsMenu.TabIndex = 2
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
		'mnuMasterIQC
		'
		Me.mnuMasterIQC.AutoSize = False
		Me.mnuMasterIQC.Image = CType(resources.GetObject("mnuMasterIQC.Image"), System.Drawing.Image)
		Me.mnuMasterIQC.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
		Me.mnuMasterIQC.ImageTransparentColor = System.Drawing.Color.Magenta
		Me.mnuMasterIQC.Name = "mnuMasterIQC"
		Me.mnuMasterIQC.Size = New System.Drawing.Size(60, 50)
		Me.mnuMasterIQC.Text = "Master"
		Me.mnuMasterIQC.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
		Me.mnuMasterIQC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
		'
		'ToolStripSeparator1
		'
		Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
		Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 59)
		'
		'bdn
		'
		Me.bdn.AddNewItem = Nothing
		Me.bdn.CountItem = Me.BindingNavigatorCountItem
		Me.bdn.DeleteItem = Nothing
		Me.bdn.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.bdn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ToolStripLabel1, Me.lblSStatus})
		Me.bdn.Location = New System.Drawing.Point(0, 469)
		Me.bdn.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
		Me.bdn.MoveLastItem = Me.BindingNavigatorMoveLastItem
		Me.bdn.MoveNextItem = Me.BindingNavigatorMoveNextItem
		Me.bdn.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
		Me.bdn.Name = "bdn"
		Me.bdn.PositionItem = Me.BindingNavigatorPositionItem
		Me.bdn.Size = New System.Drawing.Size(987, 25)
		Me.bdn.TabIndex = 38
		Me.bdn.Text = "BindingNavigator1"
		'
		'BindingNavigatorCountItem
		'
		Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
		Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(36, 22)
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
		'ToolStripLabel1
		'
		Me.ToolStripLabel1.Name = "ToolStripLabel1"
		Me.ToolStripLabel1.Size = New System.Drawing.Size(42, 22)
		Me.ToolStripLabel1.Text = "Status:"
		'
		'lblSStatus
		'
		Me.lblSStatus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
		Me.lblSStatus.ForeColor = System.Drawing.Color.Red
		Me.lblSStatus.Name = "lblSStatus"
		Me.lblSStatus.Size = New System.Drawing.Size(16, 22)
		Me.lblSStatus.Text = "..."
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(214, 10)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(32, 13)
		Me.Label1.TabIndex = 43
		Me.Label1.Text = "Ngày"
		'
		'dtpStart
		'
		Me.dtpStart.CustomFormat = "dd-MM-yyyy"
		Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.dtpStart.Location = New System.Drawing.Point(214, 26)
		Me.dtpStart.Name = "dtpStart"
		Me.dtpStart.Size = New System.Drawing.Size(97, 20)
		Me.dtpStart.TabIndex = 42
		'
		'grid
		'
		Me.grid.AllowUserToAddRows = False
		Me.grid.AllowUserToDeleteRows = False
		DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
		Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
		Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke
		Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ngay, Me.HangMuc, Me.HangMucSub, Me.TGC, Me.SoLot, Me.TongTG, Me.GhiChu})
		Me.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
		Me.grid.EnableHeadersVisualStyles = False
		Me.grid.Location = New System.Drawing.Point(0, 62)
		Me.grid.Name = "grid"
		Me.grid.RowHeadersWidth = 20
		DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.White
		DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Blue
		Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle7
		Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.grid.Size = New System.Drawing.Size(987, 404)
		Me.grid.TabIndex = 3
		'
		'Ngay
		'
		Me.Ngay.DataPropertyName = "Ngay"
		DataGridViewCellStyle2.Format = "dd-MM-yyyy"
		Me.Ngay.DefaultCellStyle = DataGridViewCellStyle2
		Me.Ngay.HeaderText = "Ngày"
		Me.Ngay.Name = "Ngay"
		Me.Ngay.ReadOnly = True
		Me.Ngay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		'
		'HangMuc
		'
		Me.HangMuc.DataPropertyName = "HangMuc"
		Me.HangMuc.HeaderText = "Hạng mục"
		Me.HangMuc.Name = "HangMuc"
		Me.HangMuc.ReadOnly = True
		Me.HangMuc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		'
		'HangMucSub
		'
		Me.HangMucSub.DataPropertyName = "HangMucSub"
		Me.HangMucSub.HeaderText = "Hạng mục con"
		Me.HangMucSub.Name = "HangMucSub"
		Me.HangMucSub.ReadOnly = True
		Me.HangMucSub.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		'
		'TGC
		'
		Me.TGC.DataPropertyName = "TGC"
		DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
		DataGridViewCellStyle3.Format = "N2"
		Me.TGC.DefaultCellStyle = DataGridViewCellStyle3
		Me.TGC.HeaderText = "Thời gian chuẩn (phút/lô)"
		Me.TGC.Name = "TGC"
		Me.TGC.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		'
		'SoLot
		'
		Me.SoLot.DataPropertyName = "SoLot"
		DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
		DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		DataGridViewCellStyle4.Format = "N0"
		Me.SoLot.DefaultCellStyle = DataGridViewCellStyle4
		Me.SoLot.HeaderText = "Số lô thực tế"
		Me.SoLot.Name = "SoLot"
		Me.SoLot.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		'
		'TongTG
		'
		Me.TongTG.DataPropertyName = "TongTG"
		DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
		DataGridViewCellStyle5.Format = "N2"
		Me.TongTG.DefaultCellStyle = DataGridViewCellStyle5
		Me.TongTG.HeaderText = "Tổng thời gian thực tế (phút)"
		Me.TongTG.Name = "TongTG"
		Me.TongTG.ReadOnly = True
		Me.TongTG.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		'
		'GhiChu
		'
		Me.GhiChu.DataPropertyName = "GhiChu"
		DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
		Me.GhiChu.DefaultCellStyle = DataGridViewCellStyle6
		Me.GhiChu.HeaderText = "Ghi chú"
		Me.GhiChu.Name = "GhiChu"
		Me.GhiChu.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
		Me.GhiChu.Width = 200
		'
		'FrmNangLucIQC
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(987, 494)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.dtpStart)
		Me.Controls.Add(Me.bdn)
		Me.Controls.Add(Me.grid)
		Me.Controls.Add(Me.tlsMenu)
		Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Name = "FrmNangLucIQC"
		Me.Tag = "022605"
		Me.Text = "Nhập năng lực IQC"
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
	Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
	Friend WithEvents grid As UtilityControl.CustomDataGridView
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
	Friend WithEvents ToolStripLabel1 As Windows.Forms.ToolStripLabel
	Friend WithEvents lblSStatus As Windows.Forms.ToolStripLabel
	Friend WithEvents mnuMasterIQC As Windows.Forms.ToolStripButton
	Friend WithEvents Label1 As Windows.Forms.Label
	Friend WithEvents dtpStart As Windows.Forms.DateTimePicker
	Friend WithEvents Ngay As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents HangMuc As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents HangMucSub As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents TGC As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents SoLot As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents TongTG As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
	Friend WithEvents GhiChu As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
End Class
