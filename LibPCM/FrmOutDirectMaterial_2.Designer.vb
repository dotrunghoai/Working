﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOutDirectMaterial_2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOutDirectMaterial_2))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnShow = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnNew = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnEdit = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnDelete = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnImport = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnLock = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.btnPrint = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.dteOrderDate = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.chbLocked = New DevExpress.XtraEditors.CheckEdit()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.slueECode = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridECode = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.slueJCode = New DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit()
        Me.GridJCode = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.dteOrderDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteOrderDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.chbLocked.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slueECode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridECode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.slueJCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridJCode, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnShow, Me.btnExport, Me.btnPrint, Me.btnDelete, Me.btnImport, Me.btnEdit, Me.btnLock, Me.btnNew})
        Me.BarManager1.MaxItemId = 8
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShow), New DevExpress.XtraBars.LinkPersistInfo(Me.btnNew), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.btnDelete), New DevExpress.XtraBars.LinkPersistInfo(Me.btnImport), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport), New DevExpress.XtraBars.LinkPersistInfo(Me.btnLock)})
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
        'btnNew
        '
        Me.btnNew.Caption = "New"
        Me.btnNew.Id = 7
        Me.btnNew.ImageOptions.Image = CType(resources.GetObject("btnNew.ImageOptions.Image"), System.Drawing.Image)
        Me.btnNew.ImageOptions.LargeImage = CType(resources.GetObject("btnNew.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(60, 60)
        '
        'btnEdit
        '
        Me.btnEdit.Caption = "Edit"
        Me.btnEdit.Id = 5
        Me.btnEdit.ImageOptions.Image = CType(resources.GetObject("btnEdit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnEdit.ImageOptions.LargeImage = CType(resources.GetObject("btnEdit.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 60)
        '
        'btnDelete
        '
        Me.btnDelete.Caption = "Delete"
        Me.btnDelete.Id = 3
        Me.btnDelete.ImageOptions.Image = CType(resources.GetObject("btnDelete.ImageOptions.Image"), System.Drawing.Image)
        Me.btnDelete.ImageOptions.LargeImage = CType(resources.GetObject("btnDelete.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 60)
        '
        'btnImport
        '
        Me.btnImport.Caption = "Import"
        Me.btnImport.Id = 4
        Me.btnImport.ImageOptions.Image = CType(resources.GetObject("btnImport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnImport.ImageOptions.LargeImage = CType(resources.GetObject("btnImport.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(60, 60)
        '
        'btnExport
        '
        Me.btnExport.Caption = "Export"
        Me.btnExport.Id = 1
        Me.btnExport.ImageOptions.Image = CType(resources.GetObject("btnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport.ImageOptions.LargeImage = CType(resources.GetObject("btnExport.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(60, 60)
        '
        'btnLock
        '
        Me.btnLock.Caption = "Lock/Unlock"
        Me.btnLock.Id = 6
        Me.btnLock.ImageOptions.SvgImage = CType(resources.GetObject("btnLock.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(80, 60)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(745, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 413)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(745, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 353)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(745, 60)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 353)
        '
        'btnPrint
        '
        Me.btnPrint.Caption = "Print"
        Me.btnPrint.Id = 2
        Me.btnPrint.ImageOptions.Image = CType(resources.GetObject("btnPrint.ImageOptions.Image"), System.Drawing.Image)
        Me.btnPrint.ImageOptions.LargeImage = CType(resources.GetObject("btnPrint.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(60, 60)
        '
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl1.Controls.Add(Me.dteOrderDate)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupControl1.Location = New System.Drawing.Point(2, 2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(128, 56)
        Me.GroupControl1.TabIndex = 4
        Me.GroupControl1.Text = "Day"
        '
        'dteOrderDate
        '
        Me.dteOrderDate.EditValue = Nothing
        Me.dteOrderDate.Location = New System.Drawing.Point(14, 30)
        Me.dteOrderDate.MenuManager = Me.BarManager1
        Me.dteOrderDate.Name = "dteOrderDate"
        Me.dteOrderDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteOrderDate.Properties.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.dteOrderDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteOrderDate.Properties.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.dteOrderDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteOrderDate.Properties.Mask.EditMask = "dd-MMM-yyyy"
        Me.dteOrderDate.Size = New System.Drawing.Size(100, 20)
        Me.dteOrderDate.TabIndex = 0
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GroupControl3)
        Me.GroupControl2.Controls.Add(Me.GroupControl1)
        Me.GroupControl2.Location = New System.Drawing.Point(465, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.ShowCaption = False
        Me.GroupControl2.Size = New System.Drawing.Size(207, 60)
        Me.GroupControl2.TabIndex = 5
        Me.GroupControl2.Text = "GroupControl2"
        '
        'GroupControl3
        '
        Me.GroupControl3.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl3.Controls.Add(Me.chbLocked)
        Me.GroupControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl3.Location = New System.Drawing.Point(130, 2)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(75, 56)
        Me.GroupControl3.TabIndex = 15
        Me.GroupControl3.Text = "Status"
        '
        'chbLocked
        '
        Me.chbLocked.Location = New System.Drawing.Point(11, 30)
        Me.chbLocked.MenuManager = Me.BarManager1
        Me.chbLocked.Name = "chbLocked"
        Me.chbLocked.Properties.Caption = "Locked"
        Me.chbLocked.Properties.ReadOnly = True
        Me.chbLocked.Size = New System.Drawing.Size(55, 20)
        Me.chbLocked.TabIndex = 5
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 60)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.slueECode, Me.slueJCode})
        Me.GridControl1.Size = New System.Drawing.Size(745, 353)
        Me.GridControl1.TabIndex = 10
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsFind.AlwaysVisible = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'slueECode
        '
        Me.slueECode.AutoHeight = False
        Me.slueECode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.slueECode.Name = "slueECode"
        Me.slueECode.PopupView = Me.GridECode
        '
        'GridECode
        '
        Me.GridECode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridECode.Name = "GridECode"
        Me.GridECode.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridECode.OptionsView.ShowGroupPanel = False
        '
        'slueJCode
        '
        Me.slueJCode.AutoHeight = False
        Me.slueJCode.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.slueJCode.Name = "slueJCode"
        Me.slueJCode.PopupFormSize = New System.Drawing.Size(750, 0)
        Me.slueJCode.PopupView = Me.GridJCode
        '
        'GridJCode
        '
        Me.GridJCode.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridJCode.Name = "GridJCode"
        Me.GridJCode.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridJCode.OptionsView.ShowGroupPanel = False
        '
        'FrmOutDirectMaterial_2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 413)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmOutDirectMaterial_2"
        Me.Tag = "0254Ma01"
        Me.Text = "Out Direct Material New"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.dteOrderDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteOrderDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.chbLocked.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slueECode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridECode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.slueJCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridJCode, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnExport As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnPrint As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnDelete As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnImport As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dteOrderDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chbLocked As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnEdit As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnLock As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnNew As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents slueECode As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridECode As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents slueJCode As DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit
    Friend WithEvents GridJCode As DevExpress.XtraGrid.Views.Grid.GridView
End Class
