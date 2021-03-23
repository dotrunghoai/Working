<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBaoCaoSeagate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBaoCaoSeagate))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.gridM = New System.Windows.Forms.DataGridView()
        Me.W = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gridD = New System.Windows.Forms.DataGridView()
        Me.Defect = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rdoThuNghiem = New System.Windows.Forms.RadioButton()
        Me.rdoKiemLai = New System.Windows.Forms.RadioButton()
        Me.rdoHangThuong = New System.Windows.Forms.RadioButton()
        Me.rdoAll = New System.Windows.Forms.RadioButton()
        Me.tlsMenu.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gridM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(159, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "End"
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "dd-MM-yyyy"
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(196, 30)
        Me.dtpEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(98, 20)
        Me.dtpEnd.TabIndex = 45
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
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 55)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(159, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Start"
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.ToolStripSeparator6})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(877, 55)
        Me.tlsMenu.TabIndex = 36
        '
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "dd-MM-yyyy"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(196, 9)
        Me.dtpStart.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(98, 20)
        Me.dtpStart.TabIndex = 37
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 55)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.gridM)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridD)
        Me.SplitContainer1.Size = New System.Drawing.Size(877, 418)
        Me.SplitContainer1.SplitterDistance = 209
        Me.SplitContainer1.TabIndex = 48
        '
        'gridM
        '
        Me.gridM.AllowUserToAddRows = False
        Me.gridM.AllowUserToDeleteRows = False
        Me.gridM.AllowUserToResizeRows = False
        Me.gridM.BackgroundColor = System.Drawing.Color.White
        Me.gridM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.W})
        Me.gridM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridM.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridM.EnableHeadersVisualStyles = False
        Me.gridM.Location = New System.Drawing.Point(0, 0)
        Me.gridM.Margin = New System.Windows.Forms.Padding(2)
        Me.gridM.Name = "gridM"
        Me.gridM.ReadOnly = True
        Me.gridM.RowHeadersWidth = 20
        Me.gridM.Size = New System.Drawing.Size(877, 209)
        Me.gridM.TabIndex = 44
        '
        'W
        '
        Me.W.DataPropertyName = "W"
        Me.W.HeaderText = "WW"
        Me.W.Name = "W"
        Me.W.ReadOnly = True
        Me.W.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'gridD
        '
        Me.gridD.AllowUserToAddRows = False
        Me.gridD.AllowUserToDeleteRows = False
        Me.gridD.AllowUserToResizeRows = False
        Me.gridD.BackgroundColor = System.Drawing.Color.White
        Me.gridD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Defect})
        Me.gridD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridD.EnableHeadersVisualStyles = False
        Me.gridD.Location = New System.Drawing.Point(0, 0)
        Me.gridD.Margin = New System.Windows.Forms.Padding(2)
        Me.gridD.Name = "gridD"
        Me.gridD.ReadOnly = True
        Me.gridD.RowHeadersWidth = 20
        Me.gridD.Size = New System.Drawing.Size(877, 205)
        Me.gridD.TabIndex = 43
        '
        'Defect
        '
        Me.Defect.DataPropertyName = "Defect"
        Me.Defect.HeaderText = "Defect"
        Me.Defect.Name = "Defect"
        Me.Defect.ReadOnly = True
        Me.Defect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'rdoThuNghiem
        '
        Me.rdoThuNghiem.AutoSize = True
        Me.rdoThuNghiem.Location = New System.Drawing.Point(460, 7)
        Me.rdoThuNghiem.Name = "rdoThuNghiem"
        Me.rdoThuNghiem.Size = New System.Drawing.Size(106, 17)
        Me.rdoThuNghiem.TabIndex = 53
        Me.rdoThuNghiem.TabStop = True
        Me.rdoThuNghiem.Text = "Hàng thử nghiệm"
        Me.rdoThuNghiem.UseVisualStyleBackColor = True
        '
        'rdoKiemLai
        '
        Me.rdoKiemLai.AutoSize = True
        Me.rdoKiemLai.Location = New System.Drawing.Point(321, 30)
        Me.rdoKiemLai.Name = "rdoKiemLai"
        Me.rdoKiemLai.Size = New System.Drawing.Size(61, 17)
        Me.rdoKiemLai.TabIndex = 52
        Me.rdoKiemLai.TabStop = True
        Me.rdoKiemLai.Text = "Kiểm lại"
        Me.rdoKiemLai.UseVisualStyleBackColor = True
        '
        'rdoHangThuong
        '
        Me.rdoHangThuong.AutoSize = True
        Me.rdoHangThuong.Checked = True
        Me.rdoHangThuong.Location = New System.Drawing.Point(321, 5)
        Me.rdoHangThuong.Name = "rdoHangThuong"
        Me.rdoHangThuong.Size = New System.Drawing.Size(135, 17)
        Me.rdoHangThuong.TabIndex = 51
        Me.rdoHangThuong.TabStop = True
        Me.rdoHangThuong.Text = "Hàng thường + Tách lô"
        Me.rdoHangThuong.UseVisualStyleBackColor = True
        '
        'rdoAll
        '
        Me.rdoAll.AutoSize = True
        Me.rdoAll.Location = New System.Drawing.Point(460, 28)
        Me.rdoAll.Name = "rdoAll"
        Me.rdoAll.Size = New System.Drawing.Size(56, 17)
        Me.rdoAll.TabIndex = 54
        Me.rdoAll.TabStop = True
        Me.rdoAll.Text = "Tất cả"
        Me.rdoAll.UseVisualStyleBackColor = True
        '
        'FrmBaoCaoSeagate
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(877, 473)
        Me.Controls.Add(Me.rdoAll)
        Me.Controls.Add(Me.rdoThuNghiem)
        Me.Controls.Add(Me.rdoKiemLai)
        Me.Controls.Add(Me.rdoHangThuong)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FrmBaoCaoSeagate"
        Me.Tag = "0243QA09"
        Me.Text = "Báo cáo Seagate"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gridM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents gridM As System.Windows.Forms.DataGridView
    Friend WithEvents gridD As System.Windows.Forms.DataGridView
    Friend WithEvents Defect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents W As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rdoThuNghiem As System.Windows.Forms.RadioButton
    Friend WithEvents rdoKiemLai As System.Windows.Forms.RadioButton
    Friend WithEvents rdoHangThuong As System.Windows.Forms.RadioButton
    Friend WithEvents rdoAll As System.Windows.Forms.RadioButton
End Class
