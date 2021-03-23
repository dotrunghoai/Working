<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGroupOfUserTrain
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmGroupOfUserTrain))
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuCheckall = New System.Windows.Forms.ToolStripButton()
        Me.mnuUncheck = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ckoAll = New System.Windows.Forms.CheckBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tlsMenu.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCheckall, Me.mnuUncheck, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(669, 58)
        Me.tlsMenu.TabIndex = 9
        '
        'mnuCheckall
        '
        Me.mnuCheckall.AutoSize = False
        Me.mnuCheckall.Image = CType(resources.GetObject("mnuCheckall.Image"), System.Drawing.Image)
        Me.mnuCheckall.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCheckall.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuCheckall.Name = "mnuCheckall"
        Me.mnuCheckall.Size = New System.Drawing.Size(60, 50)
        Me.mnuCheckall.Text = "Check all"
        Me.mnuCheckall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuCheckall.ToolTipText = "Check all"
        '
        'mnuUncheck
        '
        Me.mnuUncheck.AutoSize = False
        Me.mnuUncheck.Image = CType(resources.GetObject("mnuUncheck.Image"), System.Drawing.Image)
        Me.mnuUncheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuUncheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuUncheck.Name = "mnuUncheck"
        Me.mnuUncheck.Size = New System.Drawing.Size(60, 50)
        Me.mnuUncheck.Text = "Uncheck"
        Me.mnuUncheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuUncheck.ToolTipText = "Uncheck"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
        '
        'ckoAll
        '
        Me.ckoAll.AutoSize = True
        Me.ckoAll.Location = New System.Drawing.Point(150, 22)
        Me.ckoAll.Name = "ckoAll"
        Me.ckoAll.Size = New System.Drawing.Size(63, 17)
        Me.ckoAll.TabIndex = 10
        Me.ckoAll.Text = "All Dept"
        Me.ckoAll.UseVisualStyleBackColor = True
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 58)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(669, 371)
        Me.GridControl1.TabIndex = 19
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'FrmGroupOfUserTrain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 429)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.ckoAll)
        Me.Controls.Add(Me.tlsMenu)
        Me.KeyPreview = True
        Me.Name = "FrmGroupOfUserTrain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "GroupOfUser"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuCheckall As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuUncheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ckoAll As System.Windows.Forms.CheckBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
