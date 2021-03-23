<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmASStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmASStock))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnShow = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnEdit = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.btnImport = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.dteMonth = New DevExpress.XtraEditors.DateEdit()
        Me.grcProgressBar = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.ProgressBarControl1 = New DevExpress.XtraEditors.ProgressBarControl()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.dteMonth.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteMonth.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grcProgressBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grcProgressBar.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnShow, Me.btnEdit, Me.btnExport, Me.btnImport})
        Me.BarManager1.MaxItemId = 6
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShow), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.btnImport), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.Text = "Tools"
        '
        'btnShow
        '
        Me.btnShow.Caption = "Show"
        Me.btnShow.Id = 0
        Me.btnShow.ImageOptions.Image = CType(resources.GetObject("btnShow.ImageOptions.Image"), System.Drawing.Image)
        Me.btnShow.ImageOptions.LargeImage = CType(resources.GetObject("btnShow.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(60, 60)
        '
        'btnEdit
        '
        Me.btnEdit.Caption = "Edit"
        Me.btnEdit.Id = 2
        Me.btnEdit.ImageOptions.Image = CType(resources.GetObject("btnEdit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnEdit.ImageOptions.LargeImage = CType(resources.GetObject("btnEdit.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 60)
        '
        'btnExport
        '
        Me.btnExport.Caption = "Export"
        Me.btnExport.Id = 4
        Me.btnExport.ImageOptions.Image = CType(resources.GetObject("btnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport.ImageOptions.LargeImage = CType(resources.GetObject("btnExport.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(60, 60)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(744, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 422)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(744, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 362)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(744, 60)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 362)
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(2, 2)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(740, 333)
        Me.GridControl1.TabIndex = 4
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'btnImport
        '
        Me.btnImport.Caption = "Import"
        Me.btnImport.Id = 5
        Me.btnImport.ImageOptions.Image = CType(resources.GetObject("BarLargeButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.btnImport.ImageOptions.LargeImage = CType(resources.GetObject("BarLargeButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(60, 60)
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl1.Controls.Add(Me.dteMonth)
        Me.GroupControl1.Location = New System.Drawing.Point(268, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(107, 60)
        Me.GroupControl1.TabIndex = 9
        Me.GroupControl1.Text = "Month"
        '
        'dteMonth
        '
        Me.dteMonth.EditValue = Nothing
        Me.dteMonth.Location = New System.Drawing.Point(14, 33)
        Me.dteMonth.MenuManager = Me.BarManager1
        Me.dteMonth.Name = "dteMonth"
        Me.dteMonth.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteMonth.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteMonth.Properties.DisplayFormat.FormatString = "MMM-yyyy"
        Me.dteMonth.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteMonth.Properties.EditFormat.FormatString = "MMM-yyyy"
        Me.dteMonth.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteMonth.Properties.Mask.EditMask = "MMM-yyyy"
        Me.dteMonth.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView
        Me.dteMonth.Size = New System.Drawing.Size(78, 20)
        Me.dteMonth.TabIndex = 0
        '
        'grcProgressBar
        '
        Me.grcProgressBar.Controls.Add(Me.ProgressBarControl1)
        Me.grcProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grcProgressBar.Location = New System.Drawing.Point(0, 397)
        Me.grcProgressBar.Name = "grcProgressBar"
        Me.grcProgressBar.ShowCaption = False
        Me.grcProgressBar.Size = New System.Drawing.Size(744, 25)
        Me.grcProgressBar.TabIndex = 10
        Me.grcProgressBar.Text = "GroupControl2"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.GridControl1)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(0, 60)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.ShowCaption = False
        Me.GroupControl3.Size = New System.Drawing.Size(744, 337)
        Me.GroupControl3.TabIndex = 11
        Me.GroupControl3.Text = "GroupControl3"
        '
        'ProgressBarControl1
        '
        Me.ProgressBarControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressBarControl1.Location = New System.Drawing.Point(2, 2)
        Me.ProgressBarControl1.MenuManager = Me.BarManager1
        Me.ProgressBarControl1.Name = "ProgressBarControl1"
        Me.ProgressBarControl1.Size = New System.Drawing.Size(740, 21)
        Me.ProgressBarControl1.TabIndex = 0
        '
        'FrmASStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 422)
        Me.Controls.Add(Me.GroupControl3)
        Me.Controls.Add(Me.grcProgressBar)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmASStock"
        Me.Tag = "0000000041"
        Me.Text = "AS Stock"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.dteMonth.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteMonth.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grcProgressBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grcProgressBar.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.ProgressBarControl1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnEdit As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnExport As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnImport As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dteMonth As DevExpress.XtraEditors.DateEdit
    Friend WithEvents grcProgressBar As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ProgressBarControl1 As DevExpress.XtraEditors.ProgressBarControl
End Class
