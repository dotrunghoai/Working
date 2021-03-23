<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmViewReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmViewReport))
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.Xem = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.DocNo = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.DocName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.FileName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Note = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ReportDate = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.dtpReportDate = New System.Windows.Forms.DateTimePicker()
        Me.lblReportDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
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
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bdn.SuspendLayout()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AllowUserToOrderColumns = True
        Me.grid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.BackgroundColor = System.Drawing.Color.White
        Me.grid.ColumnHeadersHeight = 25
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Xem, Me.DocNo, Me.DocName, Me.FileName, Me.Note, Me.ReportDate})
        Me.grid.Location = New System.Drawing.Point(0, 67)
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.RowHeadersWidth = 20
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grid.RowTemplate.Height = 30
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(1156, 353)
        Me.grid.TabIndex = 14
        '
        'Xem
        '
        Me.Xem.DataPropertyName = "Xem"
        Me.Xem.HeaderText = "Xem báo cáo"
        Me.Xem.Name = "Xem"
        Me.Xem.ReadOnly = True
        Me.Xem.Text = "Xem báo cáo"
        Me.Xem.ToolTipText = "Xem báo cáo"
        Me.Xem.UseColumnTextForButtonValue = True
        '
        'DocNo
        '
        Me.DocNo.DataPropertyName = "DocNo"
        Me.DocNo.HeaderText = "DocNo"
        Me.DocNo.Name = "DocNo"
        Me.DocNo.ReadOnly = True
        Me.DocNo.Visible = False
        Me.DocNo.Width = 80
        '
        'DocName
        '
        Me.DocName.DataPropertyName = "DocName"
        Me.DocName.HeaderText = "TypeName"
        Me.DocName.Name = "DocName"
        Me.DocName.ReadOnly = True
        Me.DocName.Width = 150
        '
        'FileName
        '
        Me.FileName.DataPropertyName = "FileName"
        Me.FileName.HeaderText = "FileName"
        Me.FileName.Name = "FileName"
        Me.FileName.ReadOnly = True
        Me.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.FileName.Width = 200
        '
        'Note
        '
        Me.Note.DataPropertyName = "Note"
        Me.Note.HeaderText = "Note"
        Me.Note.Name = "Note"
        Me.Note.ReadOnly = True
        '
        'ReportDate
        '
        Me.ReportDate.DataPropertyName = "ReportDate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "dd-MMM-yyyy"
        Me.ReportDate.DefaultCellStyle = DataGridViewCellStyle2
        Me.ReportDate.HeaderText = "ReportDate"
        Me.ReportDate.Name = "ReportDate"
        Me.ReportDate.ReadOnly = True
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1156, 67)
        Me.tlsMenu.TabIndex = 15
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
        Me.mnuExport.ToolTipText = "Export(Ctrl+E)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 67)
        '
        'dtpReportDate
        '
        Me.dtpReportDate.CustomFormat = "MM-yyyy"
        Me.dtpReportDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReportDate.Location = New System.Drawing.Point(169, 36)
        Me.dtpReportDate.Name = "dtpReportDate"
        Me.dtpReportDate.Size = New System.Drawing.Size(135, 21)
        Me.dtpReportDate.TabIndex = 18
        Me.dtpReportDate.Visible = False
        '
        'lblReportDate
        '
        Me.lblReportDate.AutoSize = True
        Me.lblReportDate.Location = New System.Drawing.Point(168, 17)
        Me.lblReportDate.Name = "lblReportDate"
        Me.lblReportDate.Size = New System.Drawing.Size(73, 15)
        Me.lblReportDate.TabIndex = 19
        Me.lblReportDate.Text = "Report Date"
        Me.lblReportDate.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(329, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "File Name"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(332, 36)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(270, 21)
        Me.txtFileName.TabIndex = 21
        '
        'bdn
        '
        Me.bdn.AddNewItem = Nothing
        Me.bdn.CountItem = Me.BindingNavigatorCountItem
        Me.bdn.DeleteItem = Nothing
        Me.bdn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bdn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bdn.Location = New System.Drawing.Point(0, 423)
        Me.bdn.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bdn.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bdn.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bdn.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bdn.Name = "bdn"
        Me.bdn.PositionItem = Me.BindingNavigatorPositionItem
        Me.bdn.Size = New System.Drawing.Size(1156, 25)
        Me.bdn.TabIndex = 22
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
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(58, 23)
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
        'FrmViewReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 448)
        Me.Controls.Add(Me.bdn)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.lblReportDate)
        Me.Controls.Add(Me.dtpReportDate)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmViewReport"
        Me.Tag = "025002"
        Me.Text = "Xem báo cáo nhân sự"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bdn.ResumeLayout(False)
        Me.bdn.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dtpReportDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReportDate As System.Windows.Forms.Label
    Friend WithEvents Xem As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents DocNo As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents DocName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents FileName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Note As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ReportDate As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
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
End Class
