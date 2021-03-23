<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataKT1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDataKT1))
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboPhong = New System.Windows.Forms.ComboBox()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuSave = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.cmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuBC = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNOBC = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuCopyHeader = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuXoaHeader = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.ctmD = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuXoaD = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPdCode = New System.Windows.Forms.TextBox()
        Me.txtLotNo = New System.Windows.Forms.TextBox()
        Me.txtTrang = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtLotQty = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAQL = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtThoiGianRM = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtghichu = New System.Windows.Forms.TextBox()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.tlsMenu.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmenu.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctmD.SuspendLayout()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.mnuEdit.ToolTipText = "Export(Ctrl+E)"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 55)
        '
        'cboPhong
        '
        Me.cboPhong.FormattingEnabled = True
        Me.cboPhong.Items.AddRange(New Object() {"1", "2", "3", "8"})
        Me.cboPhong.Location = New System.Drawing.Point(594, 25)
        Me.cboPhong.Margin = New System.Windows.Forms.Padding(2)
        Me.cboPhong.Name = "cboPhong"
        Me.cboPhong.Size = New System.Drawing.Size(78, 21)
        Me.cboPhong.TabIndex = 4
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
        'dtpStart
        '
        Me.dtpStart.CustomFormat = "dd-MM-yyyy"
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStart.Location = New System.Drawing.Point(286, 5)
        Me.dtpStart.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(85, 20)
        Me.dtpStart.TabIndex = 0
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.mnuEdit, Me.mnuSave, Me.ToolStripSeparator6})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1172, 55)
        Me.tlsMenu.TabIndex = 21
        '
        'mnuSave
        '
        Me.mnuSave.AutoSize = False
        Me.mnuSave.Image = CType(resources.GetObject("mnuSave.Image"), System.Drawing.Image)
        Me.mnuSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(60, 50)
        Me.mnuSave.Text = "Save"
        Me.mnuSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuSave.ToolTipText = "Export(Ctrl+E)"
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.GridControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControl2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1172, 436)
        Me.SplitContainer1.SplitterDistance = 251
        Me.SplitContainer1.TabIndex = 24
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.cmenu
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1172, 251)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'cmenu
        '
        Me.cmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBC, Me.mnuNOBC, Me.ToolStripSeparator1, Me.mnuCopyHeader, Me.mnuXoaHeader})
        Me.cmenu.Name = "cmenu"
        Me.cmenu.Size = New System.Drawing.Size(155, 98)
        '
        'mnuBC
        '
        Me.mnuBC.Image = CType(resources.GetObject("mnuBC.Image"), System.Drawing.Image)
        Me.mnuBC.Name = "mnuBC"
        Me.mnuBC.Size = New System.Drawing.Size(154, 22)
        Me.mnuBC.Text = "Có báo cáo"
        '
        'mnuNOBC
        '
        Me.mnuNOBC.Image = CType(resources.GetObject("mnuNOBC.Image"), System.Drawing.Image)
        Me.mnuNOBC.Name = "mnuNOBC"
        Me.mnuNOBC.Size = New System.Drawing.Size(154, 22)
        Me.mnuNOBC.Text = "Không báo cáo"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(151, 6)
        '
        'mnuCopyHeader
        '
        Me.mnuCopyHeader.Image = CType(resources.GetObject("mnuCopyHeader.Image"), System.Drawing.Image)
        Me.mnuCopyHeader.Name = "mnuCopyHeader"
        Me.mnuCopyHeader.Size = New System.Drawing.Size(154, 22)
        Me.mnuCopyHeader.Text = "Copy"
        '
        'mnuXoaHeader
        '
        Me.mnuXoaHeader.Image = CType(resources.GetObject("mnuXoaHeader.Image"), System.Drawing.Image)
        Me.mnuXoaHeader.Name = "mnuXoaHeader"
        Me.mnuXoaHeader.Size = New System.Drawing.Size(154, 22)
        Me.mnuXoaHeader.Text = "Xóa"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridControl2
        '
        Me.GridControl2.ContextMenuStrip = Me.ctmD
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(1172, 181)
        Me.GridControl2.TabIndex = 1
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'ctmD
        '
        Me.ctmD.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuXoaD})
        Me.ctmD.Name = "cmenu"
        Me.ctmD.Size = New System.Drawing.Size(95, 26)
        '
        'mnuXoaD
        '
        Me.mnuXoaD.Image = CType(resources.GetObject("mnuXoaD.Image"), System.Drawing.Image)
        Me.mnuXoaD.Name = "mnuXoaD"
        Me.mnuXoaD.Size = New System.Drawing.Size(94, 22)
        Me.mnuXoaD.Text = "Xóa"
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(249, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Ngày"
        '
        'txtPdCode
        '
        Me.txtPdCode.Location = New System.Drawing.Point(376, 25)
        Me.txtPdCode.Name = "txtPdCode"
        Me.txtPdCode.Size = New System.Drawing.Size(76, 20)
        Me.txtPdCode.TabIndex = 1
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(458, 25)
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(76, 20)
        Me.txtLotNo.TabIndex = 2
        '
        'txtTrang
        '
        Me.txtTrang.Location = New System.Drawing.Point(540, 26)
        Me.txtTrang.Name = "txtTrang"
        Me.txtTrang.Size = New System.Drawing.Size(49, 20)
        Me.txtTrang.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(373, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "PdCode"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(455, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "LotNo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(537, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Số tramg"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(601, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 35
        Me.Label6.Text = "Phòng"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(685, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "LotQty"
        '
        'txtLotQty
        '
        Me.txtLotQty.Location = New System.Drawing.Point(679, 26)
        Me.txtLotQty.Name = "txtLotQty"
        Me.txtLotQty.Size = New System.Drawing.Size(54, 20)
        Me.txtLotQty.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(736, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "AQL"
        '
        'txtAQL
        '
        Me.txtAQL.Location = New System.Drawing.Point(739, 26)
        Me.txtAQL.Name = "txtAQL"
        Me.txtAQL.Size = New System.Drawing.Size(56, 20)
        Me.txtAQL.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(807, 4)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Thời gian RM"
        '
        'txtThoiGianRM
        '
        Me.txtThoiGianRM.Enabled = False
        Me.txtThoiGianRM.Location = New System.Drawing.Point(801, 25)
        Me.txtThoiGianRM.Name = "txtThoiGianRM"
        Me.txtThoiGianRM.ReadOnly = True
        Me.txtThoiGianRM.Size = New System.Drawing.Size(76, 20)
        Me.txtThoiGianRM.TabIndex = 8
        Me.txtThoiGianRM.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(884, 5)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 13)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Ghi chú"
        '
        'txtghichu
        '
        Me.txtghichu.Location = New System.Drawing.Point(883, 25)
        Me.txtghichu.Name = "txtghichu"
        Me.txtghichu.Size = New System.Drawing.Size(178, 20)
        Me.txtghichu.TabIndex = 9
        '
        'dtpEnd
        '
        Me.dtpEnd.CustomFormat = "dd-MM-yyyy"
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEnd.Location = New System.Drawing.Point(286, 26)
        Me.dtpEnd.Margin = New System.Windows.Forms.Padding(2)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(85, 20)
        Me.dtpEnd.TabIndex = 44
        '
        'FrmDataKT1
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1172, 491)
        Me.Controls.Add(Me.dtpEnd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboPhong)
        Me.Controls.Add(Me.txtghichu)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtThoiGianRM)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAQL)
        Me.Controls.Add(Me.txtLotQty)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtTrang)
        Me.Controls.Add(Me.txtLotNo)
        Me.Controls.Add(Me.txtPdCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.dtpStart)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmDataKT1"
        Me.Tag = "0243QA04"
        Me.Text = "DataKT1"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmenu.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctmD.ResumeLayout(False)
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboPhong As System.Windows.Forms.ComboBox
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPdCode As System.Windows.Forms.TextBox
    Friend WithEvents txtLotNo As System.Windows.Forms.TextBox
    Friend WithEvents txtTrang As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtLotQty As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAQL As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtThoiGianRM As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtghichu As System.Windows.Forms.TextBox
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuBC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNOBC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuCopyHeader As Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuXoaHeader As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctmD As Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuXoaD As Windows.Forms.ToolStripMenuItem
End Class
