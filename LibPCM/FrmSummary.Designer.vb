<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSummary))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rdoAll = New System.Windows.Forms.RadioButton()
        Me.rdoJCode = New System.Windows.Forms.RadioButton()
        Me.rdoItemCode = New System.Windows.Forms.RadioButton()
        Me.grpDimension = New System.Windows.Forms.GroupBox()
        Me.rdoVertical = New System.Windows.Forms.RadioButton()
        Me.rdoHorizontal = New System.Windows.Forms.RadioButton()
        Me.grpDayMonth = New System.Windows.Forms.GroupBox()
        Me.rdoMonthly = New System.Windows.Forms.RadioButton()
        Me.rdoDaily = New System.Windows.Forms.RadioButton()
        Me.grpMatCode = New System.Windows.Forms.GroupBox()
        Me.rdoMatCode = New System.Windows.Forms.RadioButton()
        Me.rdoMatCodeProcess = New System.Windows.Forms.RadioButton()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuPrintGSR = New System.Windows.Forms.ToolStripButton()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupBox3.SuspendLayout()
        Me.grpDimension.SuspendLayout()
        Me.grpDayMonth.SuspendLayout()
        Me.grpMatCode.SuspendLayout()
        Me.tlsMenu.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rdoAll)
        Me.GroupBox3.Controls.Add(Me.rdoJCode)
        Me.GroupBox3.Controls.Add(Me.rdoItemCode)
        Me.GroupBox3.Location = New System.Drawing.Point(646, -4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(84, 59)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'rdoAll
        '
        Me.rdoAll.AutoSize = True
        Me.rdoAll.Location = New System.Drawing.Point(6, 7)
        Me.rdoAll.Name = "rdoAll"
        Me.rdoAll.Size = New System.Drawing.Size(37, 18)
        Me.rdoAll.TabIndex = 2
        Me.rdoAll.Text = "All"
        Me.rdoAll.UseVisualStyleBackColor = True
        '
        'rdoJCode
        '
        Me.rdoJCode.AutoSize = True
        Me.rdoJCode.Checked = True
        Me.rdoJCode.Location = New System.Drawing.Point(7, 41)
        Me.rdoJCode.Name = "rdoJCode"
        Me.rdoJCode.Size = New System.Drawing.Size(55, 18)
        Me.rdoJCode.TabIndex = 1
        Me.rdoJCode.TabStop = True
        Me.rdoJCode.Text = "JCode"
        Me.rdoJCode.UseVisualStyleBackColor = True
        '
        'rdoItemCode
        '
        Me.rdoItemCode.AutoSize = True
        Me.rdoItemCode.Location = New System.Drawing.Point(7, 23)
        Me.rdoItemCode.Name = "rdoItemCode"
        Me.rdoItemCode.Size = New System.Drawing.Size(69, 18)
        Me.rdoItemCode.TabIndex = 0
        Me.rdoItemCode.Text = "ItemCode"
        Me.rdoItemCode.UseVisualStyleBackColor = True
        '
        'grpDimension
        '
        Me.grpDimension.Controls.Add(Me.rdoVertical)
        Me.grpDimension.Controls.Add(Me.rdoHorizontal)
        Me.grpDimension.Location = New System.Drawing.Point(556, 0)
        Me.grpDimension.Name = "grpDimension"
        Me.grpDimension.Size = New System.Drawing.Size(84, 51)
        Me.grpDimension.TabIndex = 4
        Me.grpDimension.TabStop = False
        '
        'rdoVertical
        '
        Me.rdoVertical.AutoSize = True
        Me.rdoVertical.Checked = True
        Me.rdoVertical.Location = New System.Drawing.Point(7, 29)
        Me.rdoVertical.Name = "rdoVertical"
        Me.rdoVertical.Size = New System.Drawing.Size(61, 18)
        Me.rdoVertical.TabIndex = 1
        Me.rdoVertical.TabStop = True
        Me.rdoVertical.Text = "Vertical"
        Me.rdoVertical.UseVisualStyleBackColor = True
        '
        'rdoHorizontal
        '
        Me.rdoHorizontal.AutoSize = True
        Me.rdoHorizontal.Location = New System.Drawing.Point(7, 11)
        Me.rdoHorizontal.Name = "rdoHorizontal"
        Me.rdoHorizontal.Size = New System.Drawing.Size(73, 18)
        Me.rdoHorizontal.TabIndex = 0
        Me.rdoHorizontal.Text = "Horizontal"
        Me.rdoHorizontal.UseVisualStyleBackColor = True
        '
        'grpDayMonth
        '
        Me.grpDayMonth.Controls.Add(Me.rdoMonthly)
        Me.grpDayMonth.Controls.Add(Me.rdoDaily)
        Me.grpDayMonth.Location = New System.Drawing.Point(474, 0)
        Me.grpDayMonth.Name = "grpDayMonth"
        Me.grpDayMonth.Size = New System.Drawing.Size(76, 55)
        Me.grpDayMonth.TabIndex = 3
        Me.grpDayMonth.TabStop = False
        '
        'rdoMonthly
        '
        Me.rdoMonthly.AutoSize = True
        Me.rdoMonthly.Location = New System.Drawing.Point(7, 32)
        Me.rdoMonthly.Name = "rdoMonthly"
        Me.rdoMonthly.Size = New System.Drawing.Size(62, 18)
        Me.rdoMonthly.TabIndex = 1
        Me.rdoMonthly.Text = "Monthly"
        Me.rdoMonthly.UseVisualStyleBackColor = True
        '
        'rdoDaily
        '
        Me.rdoDaily.AutoSize = True
        Me.rdoDaily.Checked = True
        Me.rdoDaily.Location = New System.Drawing.Point(7, 14)
        Me.rdoDaily.Name = "rdoDaily"
        Me.rdoDaily.Size = New System.Drawing.Size(48, 18)
        Me.rdoDaily.TabIndex = 0
        Me.rdoDaily.TabStop = True
        Me.rdoDaily.Text = "Daily"
        Me.rdoDaily.UseVisualStyleBackColor = True
        '
        'grpMatCode
        '
        Me.grpMatCode.Controls.Add(Me.rdoMatCode)
        Me.grpMatCode.Controls.Add(Me.rdoMatCodeProcess)
        Me.grpMatCode.Location = New System.Drawing.Point(315, 2)
        Me.grpMatCode.Name = "grpMatCode"
        Me.grpMatCode.Size = New System.Drawing.Size(153, 53)
        Me.grpMatCode.TabIndex = 2
        Me.grpMatCode.TabStop = False
        '
        'rdoMatCode
        '
        Me.rdoMatCode.AutoSize = True
        Me.rdoMatCode.Checked = True
        Me.rdoMatCode.Location = New System.Drawing.Point(7, 11)
        Me.rdoMatCode.Name = "rdoMatCode"
        Me.rdoMatCode.Size = New System.Drawing.Size(83, 18)
        Me.rdoMatCode.TabIndex = 1
        Me.rdoMatCode.TabStop = True
        Me.rdoMatCode.Text = "By MatCode"
        Me.rdoMatCode.UseVisualStyleBackColor = True
        '
        'rdoMatCodeProcess
        '
        Me.rdoMatCodeProcess.AutoSize = True
        Me.rdoMatCodeProcess.Location = New System.Drawing.Point(7, 31)
        Me.rdoMatCodeProcess.Name = "rdoMatCodeProcess"
        Me.rdoMatCodeProcess.Size = New System.Drawing.Size(147, 18)
        Me.rdoMatCodeProcess.TabIndex = 0
        Me.rdoMatCodeProcess.Text = "By MatCode and Process"
        Me.rdoMatCodeProcess.UseVisualStyleBackColor = True
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(221, 26)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(88, 20)
        Me.dtpEndDate.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.AutoSize = True
        Me.lblStartDate.Location = New System.Drawing.Point(183, 7)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(29, 14)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Date"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(221, 4)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(88, 20)
        Me.dtpStartDate.TabIndex = 0
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
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.mnuPrintGSR, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tlsMenu.Size = New System.Drawing.Size(792, 55)
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
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
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 55)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(792, 637)
        Me.GridControl1.TabIndex = 9
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'FrmSummary
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 692)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.grpDimension)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.grpDayMonth)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.grpMatCode)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmSummary"
        Me.Tag = "021209"
        Me.Text = "Summary"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpDimension.ResumeLayout(False)
        Me.grpDimension.PerformLayout()
        Me.grpDayMonth.ResumeLayout(False)
        Me.grpDayMonth.PerformLayout()
        Me.grpMatCode.ResumeLayout(False)
        Me.grpMatCode.PerformLayout()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CalendarColumn1 As UtilityControl.CalendarColumn
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents grpDayMonth As System.Windows.Forms.GroupBox
    Friend WithEvents rdoMonthly As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDaily As System.Windows.Forms.RadioButton
    Friend WithEvents grpMatCode As System.Windows.Forms.GroupBox
    Friend WithEvents rdoMatCode As System.Windows.Forms.RadioButton
    Friend WithEvents rdoMatCodeProcess As System.Windows.Forms.RadioButton
    Friend WithEvents grpDimension As System.Windows.Forms.GroupBox
    Friend WithEvents rdoVertical As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHorizontal As System.Windows.Forms.RadioButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdoJCode As System.Windows.Forms.RadioButton
    Friend WithEvents rdoItemCode As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAll As System.Windows.Forms.RadioButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
