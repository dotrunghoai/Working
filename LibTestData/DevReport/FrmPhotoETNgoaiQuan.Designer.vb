<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPhotoETNgoaiQuan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPhotoETNgoaiQuan))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnShow = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnDelete = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnSetting = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarLargeButtonItem1 = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.RepositoryItemButtonEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.TreeList1 = New DevExpress.XtraTreeList.TreeList()
        Me.ImageCollection1 = New DevExpress.Utils.ImageCollection(Me.components)
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.txtFormIDOld = New DevExpress.XtraEditors.TextEdit()
        Me.txtParentID = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txtOrder2 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtOrder3 = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.txtFormIDOld.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtParentID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrder2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrder3.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(881, 374)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnShow, Me.btnDelete, Me.btnSetting, Me.BarLargeButtonItem1})
        Me.BarManager1.MaxItemId = 6
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemButtonEdit1})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShow), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.btnSetting)})
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
        'btnDelete
        '
        Me.btnDelete.Caption = "Delete"
        Me.btnDelete.Id = 1
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.ImageOptions.LargeImage = CType(resources.GetObject("btnDelete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 60)
        '
        'btnSetting
        '
        Me.btnSetting.Caption = "Setting"
        Me.btnSetting.Id = 2
        Me.btnSetting.ImageOptions.Image = CType(resources.GetObject("btnSetting.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSetting.ImageOptions.LargeImage = CType(resources.GetObject("btnSetting.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnSetting.Name = "btnSetting"
        Me.btnSetting.Size = New System.Drawing.Size(60, 60)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(960, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 434)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(960, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 374)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(960, 60)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 374)
        '
        'BarLargeButtonItem1
        '
        Me.BarLargeButtonItem1.Caption = "Edit1"
        Me.BarLargeButtonItem1.Id = 5
        Me.BarLargeButtonItem1.Name = "BarLargeButtonItem1"
        '
        'RepositoryItemButtonEdit1
        '
        Me.RepositoryItemButtonEdit1.AutoHeight = False
        Me.RepositoryItemButtonEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepositoryItemButtonEdit1.Name = "RepositoryItemButtonEdit1"
        '
        'TreeList1
        '
        Me.TreeList1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeList1.Location = New System.Drawing.Point(0, 0)
        Me.TreeList1.MenuManager = Me.BarManager1
        Me.TreeList1.Name = "TreeList1"
        Me.TreeList1.OptionsBehavior.Editable = False
        Me.TreeList1.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.[True]
        Me.TreeList1.OptionsView.ShowColumns = False
        Me.TreeList1.OptionsView.ShowHorzLines = False
        Me.TreeList1.OptionsView.ShowIndicator = False
        Me.TreeList1.OptionsView.ShowVertLines = False
        Me.TreeList1.Size = New System.Drawing.Size(69, 374)
        Me.TreeList1.TabIndex = 5
        '
        'ImageCollection1
        '
        Me.ImageCollection1.ImageStream = CType(resources.GetObject("ImageCollection1.ImageStream"), DevExpress.Utils.ImageCollectionStreamer)
        Me.ImageCollection1.Images.SetKeyName(0, "home_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(1, "open_16x16.png")
        Me.ImageCollection1.Images.SetKeyName(2, "window_16x16.png")
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 60)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.GridControl1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.TreeList1)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(960, 374)
        Me.SplitContainerControl1.SplitterPosition = 881
        Me.SplitContainerControl1.TabIndex = 10
        '
        'txtFormIDOld
        '
        Me.txtFormIDOld.Location = New System.Drawing.Point(254, 27)
        Me.txtFormIDOld.MenuManager = Me.BarManager1
        Me.txtFormIDOld.Name = "txtFormIDOld"
        Me.txtFormIDOld.Size = New System.Drawing.Size(78, 20)
        Me.txtFormIDOld.TabIndex = 15
        '
        'txtParentID
        '
        Me.txtParentID.Location = New System.Drawing.Point(348, 27)
        Me.txtParentID.Name = "txtParentID"
        Me.txtParentID.Size = New System.Drawing.Size(100, 20)
        Me.txtParentID.TabIndex = 16
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(254, 7)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(57, 13)
        Me.LabelControl1.TabIndex = 16
        Me.LabelControl1.Text = "Form ID Old"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(348, 8)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(43, 13)
        Me.LabelControl2.TabIndex = 16
        Me.LabelControl2.Text = "ParentID"
        '
        'txtOrder2
        '
        Me.txtOrder2.Location = New System.Drawing.Point(474, 27)
        Me.txtOrder2.MenuManager = Me.BarManager1
        Me.txtOrder2.Name = "txtOrder2"
        Me.txtOrder2.Size = New System.Drawing.Size(100, 20)
        Me.txtOrder2.TabIndex = 21
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(474, 8)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl3.TabIndex = 22
        Me.LabelControl3.Text = "Order2"
        '
        'txtOrder3
        '
        Me.txtOrder3.Location = New System.Drawing.Point(593, 27)
        Me.txtOrder3.MenuManager = Me.BarManager1
        Me.txtOrder3.Name = "txtOrder3"
        Me.txtOrder3.Size = New System.Drawing.Size(100, 20)
        Me.txtOrder3.TabIndex = 27
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(593, 8)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(34, 13)
        Me.LabelControl4.TabIndex = 28
        Me.LabelControl4.Text = "Order3"
        '
        'FrmPhotoETNgoaiQuan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 434)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.txtOrder3)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtOrder2)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtParentID)
        Me.Controls.Add(Me.txtFormIDOld)
        Me.Controls.Add(Me.SplitContainerControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmPhotoETNgoaiQuan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPhotoETNgoaiQuan"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemButtonEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImageCollection1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.txtFormIDOld.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtParentID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrder2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrder3.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents btnShow As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents TreeList1 As DevExpress.XtraTreeList.TreeList
    Friend WithEvents ImageCollection1 As DevExpress.Utils.ImageCollection
    Friend WithEvents btnDelete As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents btnSetting As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents txtParentID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtFormIDOld As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOrder2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOrder3 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents BarLargeButtonItem1 As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents RepositoryItemButtonEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
End Class
