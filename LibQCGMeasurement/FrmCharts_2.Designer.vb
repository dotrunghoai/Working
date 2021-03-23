<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCharts_2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCharts_2))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.btnSave = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnCopy = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnPrint = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnPreview = New DevExpress.XtraBars.BarLargeButtonItem()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnSave, Me.btnCopy, Me.btnPrint, Me.btnPreview})
        Me.BarManager1.MaxItemId = 4
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnSave)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.Text = "Tools"
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(684, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 381)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(684, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 321)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(684, 60)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 321)
        '
        'ChartControl1
        '
        Me.ChartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl1.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center
        Me.ChartControl1.Legend.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside
        Me.ChartControl1.Legend.Direction = DevExpress.XtraCharts.LegendDirection.LeftToRight
        Me.ChartControl1.Legend.Name = "Default Legend"
        Me.ChartControl1.Location = New System.Drawing.Point(0, 60)
        Me.ChartControl1.Name = "ChartControl1"
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.ChartControl1.Size = New System.Drawing.Size(684, 321)
        Me.ChartControl1.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Caption = "Save"
        Me.btnSave.Id = 0
        Me.btnSave.ImageOptions.Image = CType(resources.GetObject("BarLargeButtonItem1.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSave.ImageOptions.LargeImage = CType(resources.GetObject("BarLargeButtonItem1.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 60)
        '
        'btnCopy
        '
        Me.btnCopy.Caption = "Copy"
        Me.btnCopy.Id = 1
        Me.btnCopy.ImageOptions.Image = CType(resources.GetObject("BarLargeButtonItem2.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCopy.ImageOptions.LargeImage = CType(resources.GetObject("BarLargeButtonItem2.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(60, 60)
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "Print"
        Me.btnPrint.Id = 2
        Me.btnPrint.ImageOptions.Image = CType(resources.GetObject("BarLargeButtonItem3.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrint.ImageOptions.LargeImage = CType(resources.GetObject("BarLargeButtonItem3.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(60, 60)
        '
        'btnPreview
        '
        Me.btnPreview.Caption = "Preview"
        Me.btnPreview.Id = 3
        Me.btnPreview.ImageOptions.Image = CType(resources.GetObject("BarLargeButtonItem4.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPreview.ImageOptions.LargeImage = CType(resources.GetObject("BarLargeButtonItem4.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(60, 60)
        '
        'FrmCharts_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 381)
        Me.Controls.Add(Me.ChartControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.KeyPreview = True
        Me.Name = "FrmCharts_2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCharts_2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents btnSave As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnCopy As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnPreview As DevExpress.XtraBars.BarLargeButtonItem
End Class
