<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmB00Detail
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmB00Detail))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNew = New System.Windows.Forms.ToolStripButton()
        Me.btnShow = New System.Windows.Forms.ToolStripButton()
        Me.btnEdit = New System.Windows.Forms.ToolStripButton()
        Me.btnDelete = New System.Windows.Forms.ToolStripButton()
        Me.btnExportGrid = New System.Windows.Forms.ToolStripButton()
        Me.btnExportExcel = New System.Windows.Forms.ToolStripButton()
        Me.btnExport = New System.Windows.Forms.ToolStripButton()
        Me.btnPrintReport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.rbIncomingDate = New DevExpress.XtraEditors.CheckEdit()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.rbInspectionDate = New DevExpress.XtraEditors.CheckEdit()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbIncomingDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rbInspectionDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNew, Me.btnShow, Me.btnEdit, Me.btnDelete, Me.btnExportGrid, Me.btnExportExcel, Me.btnExport, Me.btnPrintReport, Me.ToolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(860, 54)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNew
        '
        Me.btnNew.AutoSize = False
        Me.btnNew.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(60, 54)
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnNew.ToolTipText = "Thêm mới"
        '
        'btnShow
        '
        Me.btnShow.AutoSize = False
        Me.btnShow.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(60, 54)
        Me.btnShow.Text = "Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnShow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnShow.ToolTipText = "Hiển thị"
        '
        'btnEdit
        '
        Me.btnEdit.AutoSize = False
        Me.btnEdit.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 54)
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnEdit.ToolTipText = "Chỉnh sửa"
        '
        'btnDelete
        '
        Me.btnDelete.AutoSize = False
        Me.btnDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 54)
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDelete.ToolTipText = "Xóa"
        '
        'btnExportGrid
        '
        Me.btnExportGrid.AutoSize = False
        Me.btnExportGrid.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExportGrid.Image = CType(resources.GetObject("btnExportGrid.Image"), System.Drawing.Image)
        Me.btnExportGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExportGrid.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportGrid.Name = "btnExportGrid"
        Me.btnExportGrid.Size = New System.Drawing.Size(80, 54)
        Me.btnExportGrid.Text = "Export Grid"
        Me.btnExportGrid.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportGrid.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportGrid.ToolTipText = "Export Grid"
        '
        'btnExportExcel
        '
        Me.btnExportExcel.AutoSize = False
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExportExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(80, 54)
        Me.btnExportExcel.Text = "Export Excel"
        Me.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExportExcel.ToolTipText = "Export Excel"
        '
        'btnExport
        '
        Me.btnExport.AutoSize = False
        Me.btnExport.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnExport.Image = CType(resources.GetObject("btnExport.Image"), System.Drawing.Image)
        Me.btnExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(80, 54)
        Me.btnExport.Text = "Export Temp"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnExport.ToolTipText = "Export"
        '
        'btnPrintReport
        '
        Me.btnPrintReport.AutoSize = False
        Me.btnPrintReport.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnPrintReport.Image = CType(resources.GetObject("btnPrintReport.Image"), System.Drawing.Image)
        Me.btnPrintReport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPrintReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(80, 54)
        Me.btnPrintReport.Text = "Print Report"
        Me.btnPrintReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnPrintReport.ToolTipText = "In Report"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl1.Location = New System.Drawing.Point(0, 54)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(860, 410)
        Me.GridControl1.TabIndex = 2
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'rbIncomingDate
        '
        Me.rbIncomingDate.EditValue = True
        Me.rbIncomingDate.Location = New System.Drawing.Point(622, 3)
        Me.rbIncomingDate.Name = "rbIncomingDate"
        Me.rbIncomingDate.Properties.Caption = "Incoming Date"
        Me.rbIncomingDate.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rbIncomingDate.Properties.RadioGroupIndex = 1
        Me.rbIncomingDate.Size = New System.Drawing.Size(95, 20)
        Me.rbIncomingDate.TabIndex = 3
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(622, 28)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(95, 21)
        Me.dtpStartDate.TabIndex = 4
        '
        'rbInspectionDate
        '
        Me.rbInspectionDate.Location = New System.Drawing.Point(723, 3)
        Me.rbInspectionDate.Name = "rbInspectionDate"
        Me.rbInspectionDate.Properties.Caption = "Inspection Date"
        Me.rbInspectionDate.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rbInspectionDate.Properties.RadioGroupIndex = 1
        Me.rbInspectionDate.Size = New System.Drawing.Size(104, 20)
        Me.rbInspectionDate.TabIndex = 3
        Me.rbInspectionDate.TabStop = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(723, 28)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(95, 21)
        Me.dtpEndDate.TabIndex = 4
        '
        'FrmB00Detail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 464)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.rbInspectionDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.rbIncomingDate)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "FrmB00Detail"
        Me.Tag = "022611"
        Me.Text = "B00 Detail"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbIncomingDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rbInspectionDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolStrip1 As Windows.Forms.ToolStrip
    Friend WithEvents btnNew As Windows.Forms.ToolStripButton
    Friend WithEvents btnShow As Windows.Forms.ToolStripButton
    Friend WithEvents btnEdit As Windows.Forms.ToolStripButton
    Friend WithEvents btnDelete As Windows.Forms.ToolStripButton
    Friend WithEvents btnPrintReport As Windows.Forms.ToolStripButton
    Friend WithEvents btnExportGrid As Windows.Forms.ToolStripButton
    Friend WithEvents btnExportExcel As Windows.Forms.ToolStripButton
    Friend WithEvents btnExport As Windows.Forms.ToolStripButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ToolStripSeparator1 As Windows.Forms.ToolStripSeparator
    Friend WithEvents rbIncomingDate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents dtpStartDate As Windows.Forms.DateTimePicker
    Friend WithEvents rbInspectionDate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents dtpEndDate As Windows.Forms.DateTimePicker
End Class
