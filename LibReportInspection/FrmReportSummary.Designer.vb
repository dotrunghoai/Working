<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportSummary))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.rdoQuy = New System.Windows.Forms.RadioButton()
        Me.rdoTuan = New System.Windows.Forms.RadioButton()
        Me.rdoThang = New System.Windows.Forms.RadioButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
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
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuGetData = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.grid = New UtilityControl.CustomDataGridView()
        Me.Yield = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SGS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SGD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TSBS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TSBD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.WD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HGSTS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HGSTD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OTHER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ckoTL = New System.Windows.Forms.CheckBox()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bdn.SuspendLayout()
        Me.tlsMenu.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdoQuy
        '
        Me.rdoQuy.AutoSize = True
        Me.rdoQuy.Location = New System.Drawing.Point(281, 43)
        Me.rdoQuy.Name = "rdoQuy"
        Me.rdoQuy.Size = New System.Drawing.Size(52, 21)
        Me.rdoQuy.TabIndex = 40
        Me.rdoQuy.Text = "Quý"
        Me.rdoQuy.UseVisualStyleBackColor = True
        '
        'rdoTuan
        '
        Me.rdoTuan.AutoSize = True
        Me.rdoTuan.Checked = True
        Me.rdoTuan.Location = New System.Drawing.Point(281, 1)
        Me.rdoTuan.Name = "rdoTuan"
        Me.rdoTuan.Size = New System.Drawing.Size(59, 21)
        Me.rdoTuan.TabIndex = 39
        Me.rdoTuan.TabStop = True
        Me.rdoTuan.Text = "Tuần"
        Me.rdoTuan.UseVisualStyleBackColor = True
        '
        'rdoThang
        '
        Me.rdoThang.AutoSize = True
        Me.rdoThang.Location = New System.Drawing.Point(281, 22)
        Me.rdoThang.Name = "rdoThang"
        Me.rdoThang.Size = New System.Drawing.Size(67, 21)
        Me.rdoThang.TabIndex = 38
        Me.rdoThang.Text = "Tháng"
        Me.rdoThang.UseVisualStyleBackColor = True
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
        Me.mnuShowAll.Text = "Show all"
        Me.mnuShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuShowAll.ToolTipText = "Show all (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 71)
        '
        'bdn
        '
        Me.bdn.AddNewItem = Nothing
        Me.bdn.CountItem = Me.BindingNavigatorCountItem
        Me.bdn.DeleteItem = Nothing
        Me.bdn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bdn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bdn.Location = New System.Drawing.Point(0, 558)
        Me.bdn.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bdn.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bdn.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bdn.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bdn.Name = "bdn"
        Me.bdn.PositionItem = Me.BindingNavigatorPositionItem
        Me.bdn.Size = New System.Drawing.Size(1282, 25)
        Me.bdn.TabIndex = 33
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
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.ToolStripSeparator1, Me.mnuGetData, Me.ToolStripSeparator2})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1282, 71)
        Me.tlsMenu.TabIndex = 32
        '
        'mnuGetData
        '
        Me.mnuGetData.AutoSize = False
        Me.mnuGetData.Image = CType(resources.GetObject("mnuGetData.Image"), System.Drawing.Image)
        Me.mnuGetData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuGetData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuGetData.Name = "mnuGetData"
        Me.mnuGetData.Size = New System.Drawing.Size(60, 50)
        Me.mnuGetData.Text = "GetData"
        Me.mnuGetData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuGetData.ToolTipText = "GetData"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 71)
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "dd/MM/yyyy"
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(354, 35)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(105, 23)
        Me.dtpEnd.TabIndex = 46
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "dd/MM/yyyy"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(354, 3)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(105, 23)
        Me.dtpStart.TabIndex = 45
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Yield, Me.Total, Me.TotalS, Me.TotalD, Me.SGS, Me.SGD, Me.TSBS, Me.TSBD, Me.WD, Me.HGSTS, Me.HGSTD, Me.OTHER})
        Me.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grid.EnableHeadersVisualStyles = False
        Me.grid.Location = New System.Drawing.Point(0, 74)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.RowHeadersWidth = 20
        Me.grid.Size = New System.Drawing.Size(1282, 481)
        Me.grid.TabIndex = 31
        '
        'Yield
        '
        Me.Yield.DataPropertyName = "Yield"
        Me.Yield.HeaderText = "Yield (%)"
        Me.Yield.Name = "Yield"
        Me.Yield.ReadOnly = True
        Me.Yield.Width = 150
        '
        'Total
        '
        Me.Total.DataPropertyName = "Total"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.Total.DefaultCellStyle = DataGridViewCellStyle1
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.ToolTipText = "Total"
        Me.Total.Width = 50
        '
        'TotalS
        '
        Me.TotalS.DataPropertyName = "TotalS"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        Me.TotalS.DefaultCellStyle = DataGridViewCellStyle2
        Me.TotalS.HeaderText = "Total (S)"
        Me.TotalS.Name = "TotalS"
        Me.TotalS.ReadOnly = True
        Me.TotalS.ToolTipText = "Total (S)"
        Me.TotalS.Width = 60
        '
        'TotalD
        '
        Me.TotalD.DataPropertyName = "TotalD"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.TotalD.DefaultCellStyle = DataGridViewCellStyle3
        Me.TotalD.HeaderText = "Total (D)"
        Me.TotalD.Name = "TotalD"
        Me.TotalD.ReadOnly = True
        Me.TotalD.ToolTipText = "Total (D)"
        Me.TotalD.Width = 60
        '
        'SGS
        '
        Me.SGS.DataPropertyName = "SGS"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        Me.SGS.DefaultCellStyle = DataGridViewCellStyle4
        Me.SGS.HeaderText = "SG (S)"
        Me.SGS.Name = "SGS"
        Me.SGS.ReadOnly = True
        Me.SGS.ToolTipText = "SG+SKDC (S)"
        Me.SGS.Width = 60
        '
        'SGD
        '
        Me.SGD.DataPropertyName = "SGD"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.SGD.DefaultCellStyle = DataGridViewCellStyle5
        Me.SGD.HeaderText = "SG (D)"
        Me.SGD.Name = "SGD"
        Me.SGD.ReadOnly = True
        Me.SGD.ToolTipText = "SG (D)"
        Me.SGD.Width = 60
        '
        'TSBS
        '
        Me.TSBS.DataPropertyName = "TSBS"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        Me.TSBS.DefaultCellStyle = DataGridViewCellStyle6
        Me.TSBS.HeaderText = "TSB (S)"
        Me.TSBS.Name = "TSBS"
        Me.TSBS.ReadOnly = True
        Me.TSBS.ToolTipText = "TSB (S)"
        Me.TSBS.Width = 60
        '
        'TSBD
        '
        Me.TSBD.DataPropertyName = "TSBD"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        Me.TSBD.DefaultCellStyle = DataGridViewCellStyle7
        Me.TSBD.HeaderText = "TSB (D)"
        Me.TSBD.Name = "TSBD"
        Me.TSBD.ReadOnly = True
        Me.TSBD.ToolTipText = "TSB (D)"
        Me.TSBD.Width = 60
        '
        'WD
        '
        Me.WD.DataPropertyName = "WD"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        Me.WD.DefaultCellStyle = DataGridViewCellStyle8
        Me.WD.HeaderText = "WD"
        Me.WD.Name = "WD"
        Me.WD.ReadOnly = True
        Me.WD.ToolTipText = "WD"
        Me.WD.Width = 50
        '
        'HGSTS
        '
        Me.HGSTS.DataPropertyName = "HGSTS"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        Me.HGSTS.DefaultCellStyle = DataGridViewCellStyle9
        Me.HGSTS.HeaderText = "HGST (S)"
        Me.HGSTS.Name = "HGSTS"
        Me.HGSTS.ReadOnly = True
        Me.HGSTS.ToolTipText = "HGST (S)"
        Me.HGSTS.Width = 60
        '
        'HGSTD
        '
        Me.HGSTD.DataPropertyName = "HGSTD"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.Format = "N2"
        Me.HGSTD.DefaultCellStyle = DataGridViewCellStyle10
        Me.HGSTD.HeaderText = "HGST (D)"
        Me.HGSTD.Name = "HGSTD"
        Me.HGSTD.ReadOnly = True
        Me.HGSTD.ToolTipText = "HGST (D)"
        Me.HGSTD.Width = 60
        '
        'OTHER
        '
        Me.OTHER.DataPropertyName = "OTHER"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.Format = "N2"
        Me.OTHER.DefaultCellStyle = DataGridViewCellStyle11
        Me.OTHER.HeaderText = "OTHER"
        Me.OTHER.Name = "OTHER"
        Me.OTHER.ReadOnly = True
        Me.OTHER.ToolTipText = "OTHER"
        Me.OTHER.Width = 50
        '
        'ckoTL
        '
        Me.ckoTL.AutoSize = True
        Me.ckoTL.Location = New System.Drawing.Point(467, 5)
        Me.ckoTL.Name = "ckoTL"
        Me.ckoTL.Size = New System.Drawing.Size(105, 21)
        Me.ckoTL.TabIndex = 47
        Me.ckoTL.Text = "% xuất excel"
        Me.ckoTL.UseVisualStyleBackColor = True
        '
        'FrmReportSummary
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1282, 583)
        Me.Controls.Add(Me.ckoTL)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.rdoQuy)
        Me.Controls.Add(Me.rdoTuan)
        Me.Controls.Add(Me.rdoThang)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.bdn)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmReportSummary"
        Me.Tag = "0243RI01"
        Me.Text = "Report Summary"
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bdn.ResumeLayout(False)
        Me.bdn.PerformLayout()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdoQuy As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTuan As System.Windows.Forms.RadioButton
    Friend WithEvents rdoThang As System.Windows.Forms.RadioButton
    Friend WithEvents grid As UtilityControl.CustomDataGridView
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bdn As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents ckoTL As System.Windows.Forms.CheckBox
    Friend WithEvents mnuGetData As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Yield As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SGS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SGD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TSBS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TSBD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HGSTS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HGSTD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OTHER As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
