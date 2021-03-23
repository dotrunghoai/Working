<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInputData
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInputData))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnShow = New System.Windows.Forms.ToolStripButton()
        Me.btnPrintReport = New System.Windows.Forms.ToolStripButton()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.btnLabel = New DevExpress.XtraEditors.SimpleButton()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.TreeList2 = New DevExpress.XtraTreeList.TreeList()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.ToolStrip1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        CType(Me.TreeList2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnShow, Me.btnPrintReport})
        Me.ToolStrip1.Location = New System.Drawing.Point(362, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 2, 0)
        Me.ToolStrip1.Size = New System.Drawing.Size(469, 48)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnShow
        '
        Me.btnShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnShow.Image = CType(resources.GetObject("btnShow.Image"), System.Drawing.Image)
        Me.btnShow.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(55, 45)
        Me.btnShow.Text = "Show all"
        '
        'btnPrintReport
        '
        Me.btnPrintReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnPrintReport.Image = CType(resources.GetObject("btnPrintReport.Image"), System.Drawing.Image)
        Me.btnPrintReport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrintReport.Name = "btnPrintReport"
        Me.btnPrintReport.Size = New System.Drawing.Size(74, 45)
        Me.btnPrintReport.Text = "Print Report"
        '
        'GridControl1
        '
        Me.GridControl1.Location = New System.Drawing.Point(382, 68)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(46, 95)
        Me.GridControl1.TabIndex = 1
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'lblGroup
        '
        Me.lblGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblGroup.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.Location = New System.Drawing.Point(551, 9)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(93, 27)
        Me.lblGroup.TabIndex = 2
        Me.lblGroup.Text = "Show Label"
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLabel
        '
        Me.btnLabel.Appearance.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLabel.Appearance.Options.UseFont = True
        Me.btnLabel.Location = New System.Drawing.Point(470, 9)
        Me.btnLabel.Name = "btnLabel"
        Me.btnLabel.Size = New System.Drawing.Size(75, 27)
        Me.btnLabel.TabIndex = 3
        Me.btnLabel.Text = "Button"
        '
        'TreeList1
        '
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsView.ShowColumns = False
        Me.TreeList1.OptionsView.ShowHorzLines = False
        Me.TreeList1.OptionsView.ShowIndicator = False
        Me.TreeList1.OptionsView.ShowVertLines = False
        Me.TreeList1.Size = New System.Drawing.Size(355, 374)
        Me.TreeList1.TabIndex = 100
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel1.ID = New System.Guid("23b16162-2c7b-4656-9acf-1a5b6cb684c2")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(362, 200)
        Me.DockPanel1.Size = New System.Drawing.Size(362, 403)
        Me.DockPanel1.Text = "DockPanel1"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.TreeList1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(3, 26)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(355, 374)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'TreeList2
        '
        Me.TreeList2.Dock = System.Windows.Forms.DockStyle.Right
        Me.TreeList2.Location = New System.Drawing.Point(434, 48)
        Me.TreeList2.Name = "TreeList2"
        Me.TreeList2.OptionsView.ShowColumns = False
        Me.TreeList2.OptionsView.ShowHorzLines = False
        Me.TreeList2.OptionsView.ShowIndicator = False
        Me.TreeList2.OptionsView.ShowVertLines = False
        Me.TreeList2.Size = New System.Drawing.Size(397, 355)
        Me.TreeList2.TabIndex = 8
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "home_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(1, "open_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(2, "window_16x16.png")
        '
        'FrmInputData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(831, 403)
        Me.Controls.Add(Me.TreeList2)
        Me.Controls.Add(Me.btnLabel)
        Me.Controls.Add(Me.lblGroup)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.DockPanel1)
        Me.Name = "FrmInputData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmInputData"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        CType(Me.TreeList2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents btnShow As ToolStripButton
    Friend WithEvents btnPrintReport As ToolStripButton
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents lblGroup As Label
    Friend WithEvents btnLabel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents TreeList2 As DevExpress.XtraTreeList.TreeList
    Public WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
End Class
