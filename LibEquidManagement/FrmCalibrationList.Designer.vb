<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCalibrationList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCalibrationList))
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuNew = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuConfirm = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.rdoFinish = New System.Windows.Forms.RadioButton()
        Me.rdoProgress = New System.Windows.Forms.RadioButton()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 68)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(920, 415)
        Me.GridControl1.TabIndex = 68
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuDelete, Me.mnuConfirm, Me.mnuShowAll, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(920, 68)
        Me.tlsMenu.TabIndex = 67
        '
        'mnuNew
        '
        Me.mnuNew.AutoSize = False
        Me.mnuNew.Image = CType(resources.GetObject("mnuNew.Image"), System.Drawing.Image)
        Me.mnuNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(60, 50)
        Me.mnuNew.Text = "New"
        Me.mnuNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuNew.ToolTipText = "Import"
        '
        'mnuDelete
        '
        Me.mnuDelete.AutoSize = False
        Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
        Me.mnuDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(60, 50)
        Me.mnuDelete.Text = "Delete"
        Me.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuDelete.ToolTipText = "Delete"
        '
        'mnuConfirm
        '
        Me.mnuConfirm.AutoSize = False
        Me.mnuConfirm.Image = CType(resources.GetObject("mnuConfirm.Image"), System.Drawing.Image)
        Me.mnuConfirm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuConfirm.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuConfirm.Name = "mnuConfirm"
        Me.mnuConfirm.Size = New System.Drawing.Size(60, 50)
        Me.mnuConfirm.Text = "Confirm"
        Me.mnuConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuConfirm.ToolTipText = "Confirm"
        '
        'mnuShowAll
        '
        Me.mnuShowAll.AutoSize = False
        Me.mnuShowAll.Image = CType(resources.GetObject("mnuShowAll.Image"), System.Drawing.Image)
        Me.mnuShowAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuShowAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuShowAll.Name = "mnuShowAll"
        Me.mnuShowAll.Size = New System.Drawing.Size(60, 50)
        Me.mnuShowAll.Text = "Show all"
        Me.mnuShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuShowAll.ToolTipText = "Show all (F5)"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 68)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(522, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "EndDate"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(576, 36)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(109, 21)
        Me.dtpEndDate.TabIndex = 73
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(522, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "StartDate"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd-MM-yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(576, 12)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(109, 21)
        Me.dtpStartDate.TabIndex = 71
        '
        'rdoFinish
        '
        Me.rdoFinish.AutoSize = True
        Me.rdoFinish.Location = New System.Drawing.Point(439, 29)
        Me.rdoFinish.Name = "rdoFinish"
        Me.rdoFinish.Size = New System.Drawing.Size(59, 17)
        Me.rdoFinish.TabIndex = 70
        Me.rdoFinish.Text = "FINISH"
        Me.rdoFinish.UseVisualStyleBackColor = True
        '
        'rdoProgress
        '
        Me.rdoProgress.AutoSize = True
        Me.rdoProgress.Checked = True
        Me.rdoProgress.Location = New System.Drawing.Point(439, 12)
        Me.rdoProgress.Name = "rdoProgress"
        Me.rdoProgress.Size = New System.Drawing.Size(78, 17)
        Me.rdoProgress.TabIndex = 69
        Me.rdoProgress.TabStop = True
        Me.rdoProgress.Text = "PROGRESS"
        Me.rdoProgress.UseVisualStyleBackColor = True
        '
        'FrmCalibrationList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 483)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.rdoFinish)
        Me.Controls.Add(Me.rdoProgress)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.tlsMenu)
        Me.Name = "FrmCalibrationList"
        Me.Tag = "0243EQ04"
        Me.Text = "FrmCalibrationList"
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents tlsMenu As ToolStrip
    Friend WithEvents mnuNew As ToolStripButton
    Friend WithEvents mnuDelete As ToolStripButton
    Friend WithEvents mnuConfirm As ToolStripButton
    Friend WithEvents mnuShowAll As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents rdoFinish As RadioButton
    Friend WithEvents rdoProgress As RadioButton
End Class
