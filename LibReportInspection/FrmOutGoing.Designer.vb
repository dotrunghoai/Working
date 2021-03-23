<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmOutGoing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOutGoing))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar2 = New DevExpress.XtraBars.Bar()
        Me.btnShow = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnEdit = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnExport = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnCancel = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.btnUncancel = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.dteEnd = New DevExpress.XtraEditors.DateEdit()
        Me.dteStart = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.btnLayDuLieu = New DevExpress.XtraEditors.SimpleButton()
        Me.dteEndGetData = New DevExpress.XtraEditors.DateEdit()
        Me.dteStartGetData = New DevExpress.XtraEditors.DateEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.chbAllStatus = New DevExpress.XtraEditors.CheckEdit()
        Me.chbInvalid = New DevExpress.XtraEditors.CheckEdit()
        Me.chbValid = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.dteEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEnd.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteStart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.dteEndGetData.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteEndGetData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteStartGetData.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dteStartGetData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.chbAllStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chbInvalid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chbValid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowCustomization = False
        Me.BarManager1.AllowShowToolbarsPopup = False
        Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar2})
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnShow, Me.btnEdit, Me.btnExport, Me.btnCancel, Me.btnUncancel})
        Me.BarManager1.MaxItemId = 7
        '
        'Bar2
        '
        Me.Bar2.BarName = "Custom 2"
        Me.Bar2.DockCol = 0
        Me.Bar2.DockRow = 0
        Me.Bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShow), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport), New DevExpress.XtraBars.LinkPersistInfo(Me.btnCancel), New DevExpress.XtraBars.LinkPersistInfo(Me.btnUncancel)})
        Me.Bar2.OptionsBar.DrawBorder = False
        Me.Bar2.OptionsBar.DrawDragBorder = False
        Me.Bar2.Text = "Custom 2"
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
        Me.btnEdit.Id = 1
        Me.btnEdit.ImageOptions.Image = CType(resources.GetObject("btnEdit.ImageOptions.Image"), System.Drawing.Image)
        Me.btnEdit.ImageOptions.LargeImage = CType(resources.GetObject("btnEdit.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 60)
        '
        'btnExport
        '
        Me.btnExport.Caption = "Export"
        Me.btnExport.Id = 2
        Me.btnExport.ImageOptions.Image = CType(resources.GetObject("btnExport.ImageOptions.Image"), System.Drawing.Image)
        Me.btnExport.ImageOptions.LargeImage = CType(resources.GetObject("btnExport.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(60, 60)
        '
        'btnCancel
        '
        Me.btnCancel.Caption = "Cancel"
        Me.btnCancel.Id = 5
        Me.btnCancel.ImageOptions.Image = CType(resources.GetObject("btnCancel.ImageOptions.Image"), System.Drawing.Image)
        Me.btnCancel.ImageOptions.LargeImage = CType(resources.GetObject("btnCancel.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 60)
        '
        'btnUncancel
        '
        Me.btnUncancel.Caption = "UnCancel"
        Me.btnUncancel.Id = 6
        Me.btnUncancel.ImageOptions.Image = CType(resources.GetObject("btnUncancel.ImageOptions.Image"), System.Drawing.Image)
        Me.btnUncancel.ImageOptions.LargeImage = CType(resources.GetObject("btnUncancel.ImageOptions.LargeImage"), System.Drawing.Image)
        Me.btnUncancel.Name = "btnUncancel"
        Me.btnUncancel.Size = New System.Drawing.Size(70, 60)
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(993, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 367)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(993, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 307)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(993, 60)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 307)
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShow), New DevExpress.XtraBars.LinkPersistInfo(Me.btnEdit), New DevExpress.XtraBars.LinkPersistInfo(Me.btnExport)})
        Me.Bar1.OptionsBar.DrawBorder = False
        Me.Bar1.OptionsBar.DrawDragBorder = False
        Me.Bar1.Text = "Tools"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 60)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(993, 307)
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
        'GroupControl1
        '
        Me.GroupControl1.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl1.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl1.Controls.Add(Me.dteEnd)
        Me.GroupControl1.Controls.Add(Me.dteStart)
        Me.GroupControl1.Location = New System.Drawing.Point(323, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(236, 60)
        Me.GroupControl1.TabIndex = 5
        Me.GroupControl1.Text = "Ngày"
        '
        'dteEnd
        '
        Me.dteEnd.EditValue = Nothing
        Me.dteEnd.Location = New System.Drawing.Point(125, 31)
        Me.dteEnd.Name = "dteEnd"
        Me.dteEnd.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEnd.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEnd.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dteEnd.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteEnd.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dteEnd.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteEnd.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dteEnd.Size = New System.Drawing.Size(100, 20)
        Me.dteEnd.TabIndex = 0
        '
        'dteStart
        '
        Me.dteStart.EditValue = Nothing
        Me.dteStart.Location = New System.Drawing.Point(11, 31)
        Me.dteStart.MenuManager = Me.BarManager1
        Me.dteStart.Name = "dteStart"
        Me.dteStart.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteStart.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteStart.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dteStart.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteStart.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dteStart.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteStart.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dteStart.Size = New System.Drawing.Size(100, 20)
        Me.dteStart.TabIndex = 0
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.btnLayDuLieu)
        Me.GroupControl6.Controls.Add(Me.dteEndGetData)
        Me.GroupControl6.Controls.Add(Me.dteStartGetData)
        Me.GroupControl6.Location = New System.Drawing.Point(771, 0)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.ShowCaption = False
        Me.GroupControl6.Size = New System.Drawing.Size(210, 60)
        Me.GroupControl6.TabIndex = 17
        Me.GroupControl6.Text = "GroupControl6"
        '
        'btnLayDuLieu
        '
        Me.btnLayDuLieu.Location = New System.Drawing.Point(71, 32)
        Me.btnLayDuLieu.Name = "btnLayDuLieu"
        Me.btnLayDuLieu.Size = New System.Drawing.Size(75, 23)
        Me.btnLayDuLieu.TabIndex = 2
        Me.btnLayDuLieu.Text = "Lấy dữ liệu"
        '
        'dteEndGetData
        '
        Me.dteEndGetData.EditValue = Nothing
        Me.dteEndGetData.Location = New System.Drawing.Point(110, 6)
        Me.dteEndGetData.MenuManager = Me.BarManager1
        Me.dteEndGetData.Name = "dteEndGetData"
        Me.dteEndGetData.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEndGetData.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteEndGetData.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dteEndGetData.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteEndGetData.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dteEndGetData.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteEndGetData.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dteEndGetData.Size = New System.Drawing.Size(93, 20)
        Me.dteEndGetData.TabIndex = 1
        '
        'dteStartGetData
        '
        Me.dteStartGetData.EditValue = Nothing
        Me.dteStartGetData.Location = New System.Drawing.Point(6, 6)
        Me.dteStartGetData.MenuManager = Me.BarManager1
        Me.dteStartGetData.Name = "dteStartGetData"
        Me.dteStartGetData.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteStartGetData.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dteStartGetData.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dteStartGetData.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteStartGetData.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dteStartGetData.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dteStartGetData.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dteStartGetData.Size = New System.Drawing.Size(98, 20)
        Me.dteStartGetData.TabIndex = 0
        '
        'GroupControl2
        '
        Me.GroupControl2.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl2.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl2.Controls.Add(Me.chbAllStatus)
        Me.GroupControl2.Controls.Add(Me.chbInvalid)
        Me.GroupControl2.Controls.Add(Me.chbValid)
        Me.GroupControl2.Location = New System.Drawing.Point(569, 0)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(194, 60)
        Me.GroupControl2.TabIndex = 22
        Me.GroupControl2.Text = "Status"
        '
        'chbAllStatus
        '
        Me.chbAllStatus.Location = New System.Drawing.Point(144, 31)
        Me.chbAllStatus.MenuManager = Me.BarManager1
        Me.chbAllStatus.Name = "chbAllStatus"
        Me.chbAllStatus.Properties.Caption = "All"
        Me.chbAllStatus.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.chbAllStatus.Properties.RadioGroupIndex = 0
        Me.chbAllStatus.Size = New System.Drawing.Size(40, 20)
        Me.chbAllStatus.TabIndex = 2
        Me.chbAllStatus.TabStop = False
        '
        'chbInvalid
        '
        Me.chbInvalid.Location = New System.Drawing.Point(73, 32)
        Me.chbInvalid.MenuManager = Me.BarManager1
        Me.chbInvalid.Name = "chbInvalid"
        Me.chbInvalid.Properties.Caption = "Invalid"
        Me.chbInvalid.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.chbInvalid.Properties.RadioGroupIndex = 0
        Me.chbInvalid.Size = New System.Drawing.Size(64, 20)
        Me.chbInvalid.TabIndex = 1
        Me.chbInvalid.TabStop = False
        '
        'chbValid
        '
        Me.chbValid.EditValue = True
        Me.chbValid.Location = New System.Drawing.Point(13, 32)
        Me.chbValid.MenuManager = Me.BarManager1
        Me.chbValid.Name = "chbValid"
        Me.chbValid.Properties.Caption = "Valid"
        Me.chbValid.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio
        Me.chbValid.Properties.RadioGroupIndex = 0
        Me.chbValid.Size = New System.Drawing.Size(45, 20)
        Me.chbValid.TabIndex = 0
        '
        'FrmOutGoing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 367)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl6)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmOutGoing"
        Me.Tag = "0243RI04"
        Me.Text = "Out Going"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.dteEnd.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEnd.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteStart.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteStart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        CType(Me.dteEndGetData.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteEndGetData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteStartGetData.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dteStartGetData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.chbAllStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chbInvalid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chbValid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents dteEnd As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dteStart As DevExpress.XtraEditors.DateEdit
    Friend WithEvents btnExport As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents btnLayDuLieu As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents dteEndGetData As DevExpress.XtraEditors.DateEdit
    Friend WithEvents dteStartGetData As DevExpress.XtraEditors.DateEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chbAllStatus As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chbInvalid As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chbValid As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents Bar2 As DevExpress.XtraBars.Bar
    Friend WithEvents btnCancel As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents btnUncancel As DevExpress.XtraBars.BarLargeButtonItem
End Class
