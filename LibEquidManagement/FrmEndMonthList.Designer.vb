<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEndMonthList
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEndMonthList))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnNew = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnDelete = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnConfirm = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnShow = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.rdoFinish = New DevExpress.XtraEditors.CheckEdit()
        Me.rdoProgress = New DevExpress.XtraEditors.CheckEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.dteEndDate = New DevExpress.XtraEditors.DateEdit()
        Me.dteStartDate = New DevExpress.XtraEditors.DateEdit()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.rdoFinish.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdoProgress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.dteEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteStartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnNew, Me.btnDelete, Me.btnConfirm, Me.btnShow})
        Me.BarManager1.MaxItemId = 4
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnNew), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.btnConfirm), New DevExpress.XtraBars.LinkPersistInfo(Me.btnShow)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.Text = "Tools"
        '
        'btnNew
        '
        Me.btnNew.Caption = "New"
        Me.btnNew.Id = 0
        Me.btnNew.ImageOptions.Image = CType(resources.GetObject("btnNew.ImageOptions.Image"), System.Drawing.Image)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnNew.Size = New System.Drawing.Size(50, 60)
        '
        'btnDelete
        '
        Me.btnDelete.Caption = "Delete"
        Me.btnDelete.Id = 1
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnDelete.Size = New System.Drawing.Size(50, 60)
        '
        'btnConfirm
        '
        Me.btnConfirm.Caption = "Confirm"
        Me.btnConfirm.Id = 2
        Me.btnConfirm.ImageOptions.Image = CType(resources.GetObject("btnConfirm.ImageOptions.Image"), System.Drawing.Image)
        Me.btnConfirm.Name = "btnConfirm"
        Me.btnConfirm.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnConfirm.Size = New System.Drawing.Size(60, 60)
        '
        'btnShow
        '
        Me.btnShow.Caption = "Show all"
        Me.btnShow.Id = 3
        Me.btnShow.ImageOptions.Image = CType(resources.GetObject("btnShow.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.btnShow.Size = New System.Drawing.Size(60, 60)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(794, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 316)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(794, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 256)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(794, 60)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 256)
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.rdoFinish)
        Me.GroupControl1.Controls.Add(Me.rdoProgress)
        Me.GroupControl1.Location = New System.Drawing.Point(266, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.ShowCaption = False
        Me.GroupControl1.Size = New System.Drawing.Size(98, 60)
        Me.GroupControl1.TabIndex = 4
        Me.GroupControl1.Text = "GroupControl1"
        '
        'rdoFinish
        '
        Me.rdoFinish.Location = New System.Drawing.Point(11, 33)
        Me.rdoFinish.Name = "rdoFinish"
        Me.rdoFinish.Properties.Caption = "FINISH"
        Me.rdoFinish.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoFinish.Properties.RadioGroupIndex = 1
        Me.rdoFinish.Size = New System.Drawing.Size(75, 20)
        Me.rdoFinish.TabIndex = 0
        Me.rdoFinish.TabStop = False
        '
        'rdoProgress
        '
        Me.rdoProgress.EditValue = True
        Me.rdoProgress.Location = New System.Drawing.Point(11, 8)
        Me.rdoProgress.MenuManager = Me.BarManager1
        Me.rdoProgress.Name = "rdoProgress"
        Me.rdoProgress.Properties.Caption = "PROGRESS"
        Me.rdoProgress.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.rdoProgress.Properties.RadioGroupIndex = 1
        Me.rdoProgress.Size = New System.Drawing.Size(75, 20)
        Me.rdoProgress.TabIndex = 0
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(13, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(50, 13)
        Me.LabelControl1.TabIndex = 1
        Me.LabelControl1.Text = "Date Start"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.dteEndDate)
        Me.GroupControl2.Controls.Add(Me.dteStartDate)
        Me.GroupControl2.Controls.Add(Me.LabelControl2)
        Me.GroupControl2.Controls.Add(Me.LabelControl1)
        Me.GroupControl2.Location = New System.Drawing.Point(394, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.ShowCaption = False
        Me.GroupControl2.Size = New System.Drawing.Size(230, 60)
        Me.GroupControl2.TabIndex = 5
        Me.GroupControl2.Text = "GroupControl2"
        '
        'dteEndDate
        '
        Me.dteEndDate.EditValue = Nothing
        Me.dteEndDate.Location = New System.Drawing.Point(122, 30)
        Me.dteEndDate.Name = "dteEndDate"
        Me.dteEndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEndDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dteEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteEndDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dteEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteEndDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dteEndDate.Size = New System.Drawing.Size(100, 20)
        Me.dteEndDate.TabIndex = 2
        '
        'dteStartDate
        '
        Me.dteStartDate.EditValue = Nothing
        Me.dteStartDate.Location = New System.Drawing.Point(11, 30)
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
        Me.dteStartDate.TabIndex = 2
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(124, 12)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(44, 13)
        Me.LabelControl2.TabIndex = 1
        Me.LabelControl2.Text = "Date End"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 60)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(794, 256)
        Me.GridControl1.TabIndex = 6
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'FrmEndMonthList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 316)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmEndMonthList"
        Me.Tag = "0243EQ12"
        Me.Text = "End Month List"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.rdoFinish.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdoProgress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.dteEndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteStartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteStartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnNew As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnDelete As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnConfirm As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnShow As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents rdoFinish As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents rdoProgress As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dteEndDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dteStartDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
