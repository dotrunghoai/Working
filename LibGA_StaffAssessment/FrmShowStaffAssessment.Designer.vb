<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmShowStaffAssessment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmShowStaffAssessment))
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.Bar1 = New DevExpress.XtraBars.Bar()
        Me.btnShow = New DevExpress.XtraBars.BarLargeButtonItem()
        Me.dteStartDate = New DevExpress.XtraBars.BarEditItem()
        Me.BarEditItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.dteEndDate = New DevExpress.XtraBars.BarEditItem()
        Me.BarEditItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.SectionHead = New DevExpress.XtraBars.BarEditItem()
        Me.cbbSection = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarEditItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarEditItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarEditItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarEditItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbbSection, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.btnShow, Me.dteStartDate, Me.dteEndDate, Me.SectionHead})
        Me.BarManager1.MaxItemId = 4
        Me.BarManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.BarEditItemDateEdit1, Me.BarEditItemDateEdit2, Me.cbbSection})
        '
        'Bar1
        '
        Me.Bar1.BarName = "Tools"
        Me.Bar1.DockCol = 0
        Me.Bar1.DockRow = 0
        Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
        Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.btnShow), New DevExpress.XtraBars.LinkPersistInfo(Me.dteStartDate, True), New DevExpress.XtraBars.LinkPersistInfo(Me.dteEndDate), New DevExpress.XtraBars.LinkPersistInfo(Me.SectionHead, True)})
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
        'dteStartDate
        '
        Me.dteStartDate.Caption = "Start Date"
        Me.dteStartDate.Edit = Me.BarEditItemDateEdit1
        Me.dteStartDate.Id = 1
        Me.dteStartDate.Name = "dteStartDate"
        Me.dteStartDate.Size = New System.Drawing.Size(100, 60)
        '
        'BarEditItemDateEdit1
        '
        Me.BarEditItemDateEdit1.AutoHeight = False
        Me.BarEditItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BarEditItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BarEditItemDateEdit1.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.BarEditItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BarEditItemDateEdit1.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.BarEditItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BarEditItemDateEdit1.Mask.EditMask = "dd-MMM-yyyy"
        Me.BarEditItemDateEdit1.Name = "BarEditItemDateEdit1"
        '
        'dteEndDate
        '
        Me.dteEndDate.Caption = "End Date"
        Me.dteEndDate.Edit = Me.BarEditItemDateEdit2
        Me.dteEndDate.Id = 2
        Me.dteEndDate.Name = "dteEndDate"
        Me.dteEndDate.Size = New System.Drawing.Size(100, 60)
        '
        'BarEditItemDateEdit2
        '
        Me.BarEditItemDateEdit2.AutoHeight = False
        Me.BarEditItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BarEditItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.BarEditItemDateEdit2.DisplayFormat.FormatString = "dd-MMM-yyyy"
        Me.BarEditItemDateEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BarEditItemDateEdit2.EditFormat.FormatString = "dd-MMM-yyyy"
        Me.BarEditItemDateEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.BarEditItemDateEdit2.Mask.EditMask = "dd-MMM-yyyy"
        Me.BarEditItemDateEdit2.Name = "BarEditItemDateEdit2"
        '
        'SectionHead
        '
        Me.SectionHead.Caption = "Section"
        Me.SectionHead.Edit = Me.cbbSection
        Me.SectionHead.Id = 3
        Me.SectionHead.Name = "SectionHead"
        Me.SectionHead.Size = New System.Drawing.Size(150, 60)
        '
        'cbbSection
        '
        Me.cbbSection.AutoHeight = False
        Me.cbbSection.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cbbSection.DropDownRows = 25
        Me.cbbSection.Name = "cbbSection"
        Me.cbbSection.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(699, 60)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 424)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(699, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 60)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 364)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(699, 60)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 364)
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 60)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.MenuManager = Me.BarManager1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(699, 364)
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
        'FrmShowStaffAssessment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 424)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Name = "FrmShowStaffAssessment"
        Me.Tag = "0255SA03"
        Me.Text = "Show Staff Assessment"
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarEditItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarEditItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarEditItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarEditItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbbSection, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnShow As DevExpress.XtraBars.BarLargeButtonItem
    Friend WithEvents dteStartDate As DevExpress.XtraBars.BarEditItem
    Friend WithEvents BarEditItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents dteEndDate As DevExpress.XtraBars.BarEditItem
    Friend WithEvents BarEditItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SectionHead As DevExpress.XtraBars.BarEditItem
    Friend WithEvents cbbSection As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
End Class
