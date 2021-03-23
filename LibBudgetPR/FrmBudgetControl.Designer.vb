<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBudgetControl
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBudgetControl))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnShow = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnEdit = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.dteEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.dteStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.rdoMatCodeProcess = New DevExpress.XtraEditors.CheckEdit()
        Me.rdoMatCode = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.rdoYearly = New DevExpress.XtraEditors.CheckEdit()
        Me.rdoMonthly = New DevExpress.XtraEditors.CheckEdit()
        Me.rdoDaily = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.rdoVertical = New DevExpress.XtraEditors.CheckEdit()
        Me.rdoHorizontal = New DevExpress.XtraEditors.CheckEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnCapNhatTonCuoi = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.dteEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.rdoMatCodeProcess.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdoMatCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.rdoYearly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdoMonthly.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdoDaily.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.rdoVertical.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdoHorizontal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnShow, Me.btnExport, Me.btnPrint, Me.btnEdit})
        Me.BarManager1.MaxItemId = 4
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShow), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport), New DevExpress.XtraBars.LinkPersistInfo(Me.btnPrint), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEdit)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.Text = "Tools"
        '
        'btnShow
        '
        Me.btnShow.Caption = "Show"
        Me.btnShow.Id = 0
        Me.btnShow.ImageOptions.Image = CType(resources.GetObject("btnShow.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnShow.Size = New System.Drawing.Size(60, 60)
        '
        'btnExport
        '
        Me.btnExport.Caption = "Export"
        Me.btnExport.Id = 1
        Me.btnExport.ImageOptions.Image = CType(resources.GetObject("btnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnExport.Size = New System.Drawing.Size(60, 60)
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "Print"
        Me.btnPrint.Id = 2
        Me.btnPrint.ImageOptions.Image = CType(resources.GetObject("btnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnPrint.Size = New System.Drawing.Size(60, 60)
        '
        'btnEdit
        '
        Me.btnEdit.Caption = "Edit"
        Me.btnEdit.Id = 3
        Me.btnEdit.ImageOptions.Image = CType(resources.GetObject("btnEdit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnEdit.Size = New System.Drawing.Size(60, 60)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(984, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 575)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(984, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 515)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(984, 60)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 515)
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.dteEndDate)
        Me.GroupControl1.Controls.Add(Me.dteStartDate)
        Me.GroupControl1.Location = New System.Drawing.Point(266, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(222, 66)
        Me.GroupControl1.TabIndex = 4
        Me.GroupControl1.Text = "Date"
        '
        'dteEndDate
        '
        Me.dteEndDate.EditValue = Nothing
        Me.dteEndDate.Location = New System.Drawing.Point(115, 32)
        Me.dteEndDate.MenuManager = Me.BarManager1
        Me.dteEndDate.Name = "dteEndDate"
        Me.dteEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEndDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dteEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteEndDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dteEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteEndDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dteEndDate.Size = New System.Drawing.Size(100, 20)
        Me.dteEndDate.TabIndex = 1
        '
        'dteStartDate
        '
        Me.dteStartDate.EditValue = Nothing
        Me.dteStartDate.Location = New System.Drawing.Point(7, 32)
        Me.dteStartDate.MenuManager = Me.BarManager1
        Me.dteStartDate.Name = "dteStartDate"
        Me.dteStartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteStartDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dteStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteStartDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dteStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteStartDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dteStartDate.Size = New System.Drawing.Size(100, 20)
        Me.dteStartDate.TabIndex = 0
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.rdoMatCodeProcess)
        Me.GroupControl2.Controls.Add(Me.rdoMatCode)
        Me.GroupControl2.Location = New System.Drawing.Point(497, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.ShowCaption = False
        Me.GroupControl2.Size = New System.Drawing.Size(160, 66)
        Me.GroupControl2.TabIndex = 5
        Me.GroupControl2.Text = "GroupControl2"
        '
        'rdoMatCodeProcess
        '
        Me.rdoMatCodeProcess.Location = New System.Drawing.Point(11, 36)
        Me.rdoMatCodeProcess.Name = "rdoMatCodeProcess"
        Me.rdoMatCodeProcess.Properties.Caption = "By MatCode and Process"
        Me.rdoMatCodeProcess.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoMatCodeProcess.Properties.RadioGroupIndex = 1
        Me.rdoMatCodeProcess.Size = New System.Drawing.Size(149, 20)
        Me.rdoMatCodeProcess.TabIndex = 3
        Me.rdoMatCodeProcess.TabStop = False
        '
        'rdoMatCode
        '
        Me.rdoMatCode.EditValue = True
        Me.rdoMatCode.Location = New System.Drawing.Point(11, 12)
        Me.rdoMatCode.MenuManager = Me.BarManager1
        Me.rdoMatCode.Name = "rdoMatCode"
        Me.rdoMatCode.Properties.Caption = "By MatCode"
        Me.rdoMatCode.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoMatCode.Properties.RadioGroupIndex = 1
        Me.rdoMatCode.Size = New System.Drawing.Size(91, 20)
        Me.rdoMatCode.TabIndex = 2
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.rdoYearly)
        Me.GroupControl3.Controls.Add(Me.rdoMonthly)
        Me.GroupControl3.Controls.Add(Me.rdoDaily)
        Me.GroupControl3.Location = New System.Drawing.Point(666, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.ShowCaption = False
        Me.GroupControl3.Size = New System.Drawing.Size(75, 66)
        Me.GroupControl3.TabIndex = 6
        Me.GroupControl3.Text = "GroupControl3"
        '
        'rdoYearly
        '
        Me.rdoYearly.Location = New System.Drawing.Point(6, 44)
        Me.rdoYearly.Name = "rdoYearly"
        Me.rdoYearly.Properties.Caption = "Yearly"
        Me.rdoYearly.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoYearly.Properties.RadioGroupIndex = 2
        Me.rdoYearly.Size = New System.Drawing.Size(61, 20)
        Me.rdoYearly.TabIndex = 6
        Me.rdoYearly.TabStop = False
        '
        'rdoMonthly
        '
        Me.rdoMonthly.Location = New System.Drawing.Point(6, 23)
        Me.rdoMonthly.Name = "rdoMonthly"
        Me.rdoMonthly.Properties.Caption = "Monthly"
        Me.rdoMonthly.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoMonthly.Properties.RadioGroupIndex = 2
        Me.rdoMonthly.Size = New System.Drawing.Size(61, 20)
        Me.rdoMonthly.TabIndex = 5
        Me.rdoMonthly.TabStop = False
        '
        'rdoDaily
        '
        Me.rdoDaily.EditValue = True
        Me.rdoDaily.Location = New System.Drawing.Point(6, 3)
        Me.rdoDaily.MenuManager = Me.BarManager1
        Me.rdoDaily.Name = "rdoDaily"
        Me.rdoDaily.Properties.Caption = "Daily"
        Me.rdoDaily.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoDaily.Properties.RadioGroupIndex = 2
        Me.rdoDaily.Size = New System.Drawing.Size(61, 20)
        Me.rdoDaily.TabIndex = 4
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.rdoVertical)
        Me.GroupControl4.Controls.Add(Me.rdoHorizontal)
        Me.GroupControl4.Location = New System.Drawing.Point(751, 0)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.ShowCaption = False
        Me.GroupControl4.Size = New System.Drawing.Size(85, 66)
        Me.GroupControl4.TabIndex = 7
        Me.GroupControl4.Text = "GroupControl4"
        '
        'rdoVertical
        '
        Me.rdoVertical.EditValue = True
        Me.rdoVertical.Location = New System.Drawing.Point(9, 36)
        Me.rdoVertical.Name = "rdoVertical"
        Me.rdoVertical.Properties.Caption = "Vertical"
        Me.rdoVertical.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoVertical.Properties.RadioGroupIndex = 3
        Me.rdoVertical.Size = New System.Drawing.Size(72, 20)
        Me.rdoVertical.TabIndex = 8
        '
        'rdoHorizontal
        '
        Me.rdoHorizontal.Location = New System.Drawing.Point(9, 12)
        Me.rdoHorizontal.MenuManager = Me.BarManager1
        Me.rdoHorizontal.Name = "rdoHorizontal"
        Me.rdoHorizontal.Properties.Caption = "Horizontal"
        Me.rdoHorizontal.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoHorizontal.Properties.RadioGroupIndex = 3
        Me.rdoHorizontal.Size = New System.Drawing.Size(72, 20)
        Me.rdoHorizontal.TabIndex = 7
        Me.rdoHorizontal.TabStop = False
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 60)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(984, 515)
        Me.GridControl1.TabIndex = 8
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddFileToolStripMenuItem, Me.DeleteFileToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(129, 48)
        '
        'AddFileToolStripMenuItem
        '
        Me.AddFileToolStripMenuItem.Name = "AddFileToolStripMenuItem"
        Me.AddFileToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.AddFileToolStripMenuItem.Text = "Add File"
        '
        'DeleteFileToolStripMenuItem
        '
        Me.DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
        Me.DeleteFileToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.DeleteFileToolStripMenuItem.Text = "Delete File"
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'btnCapNhatTonCuoi
        '
        Me.btnCapNhatTonCuoi.Location = New System.Drawing.Point(855, 14)
        Me.btnCapNhatTonCuoi.Name = "btnCapNhatTonCuoi"
        Me.btnCapNhatTonCuoi.Size = New System.Drawing.Size(106, 46)
        Me.btnCapNhatTonCuoi.TabIndex = 13
        Me.btnCapNhatTonCuoi.Text = "Cập nhật tồn cuối"
        '
        'FrmBudgetControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 575)
        Me.Controls.Add(Me.btnCapNhatTonCuoi)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupControl4)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmBudgetControl"
        Me.Tag = "0267BG01"
        Me.Text = "Budget Control"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.dteEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.rdoMatCodeProcess.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdoMatCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.rdoYearly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdoMonthly.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdoDaily.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.rdoVertical.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdoHorizontal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnShow As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dteEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dteStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rdoMatCodeProcess As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rdoMatCode As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rdoYearly As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rdoMonthly As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rdoDaily As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rdoVertical As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rdoHorizontal As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnExport As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnEdit As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents AddFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnCapNhatTonCuoi As DevExpress.XtraEditors.SimpleButton
End Class
