<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmModule))
        Me.gboCondition = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtModuleJ = New System.Windows.Forms.TextBox()
        Me.txtModuleE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtModuleV = New System.Windows.Forms.TextBox()
        Me.txtModuleC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtModuleID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboGropName = New System.Windows.Forms.ComboBox()
        Me.txtgropID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuNew = New System.Windows.Forms.ToolStripButton()
        Me.mnuSave = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMaxModuleID = New System.Windows.Forms.TextBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gboCondition.SuspendLayout()
        Me.tlsMenu.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gboCondition
        '
        Me.gboCondition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboCondition.Controls.Add(Me.Label4)
        Me.gboCondition.Controls.Add(Me.txtModuleJ)
        Me.gboCondition.Controls.Add(Me.txtModuleE)
        Me.gboCondition.Controls.Add(Me.Label6)
        Me.gboCondition.Controls.Add(Me.Label7)
        Me.gboCondition.Controls.Add(Me.txtModuleV)
        Me.gboCondition.Controls.Add(Me.txtModuleC)
        Me.gboCondition.Controls.Add(Me.Label5)
        Me.gboCondition.Controls.Add(Me.Label3)
        Me.gboCondition.Controls.Add(Me.txtModuleID)
        Me.gboCondition.Controls.Add(Me.Label2)
        Me.gboCondition.Controls.Add(Me.cboGropName)
        Me.gboCondition.Controls.Add(Me.txtgropID)
        Me.gboCondition.Controls.Add(Me.Label1)
        Me.gboCondition.Location = New System.Drawing.Point(0, 61)
        Me.gboCondition.Name = "gboCondition"
        Me.gboCondition.Size = New System.Drawing.Size(1012, 71)
        Me.gboCondition.TabIndex = 0
        Me.gboCondition.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(826, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "ModuleNameC"
        '
        'txtModuleJ
        '
        Me.txtModuleJ.Location = New System.Drawing.Point(663, 33)
        Me.txtModuleJ.Name = "txtModuleJ"
        Me.txtModuleJ.Size = New System.Drawing.Size(157, 20)
        Me.txtModuleJ.TabIndex = 5
        '
        'txtModuleE
        '
        Me.txtModuleE.Location = New System.Drawing.Point(500, 34)
        Me.txtModuleE.Name = "txtModuleE"
        Me.txtModuleE.Size = New System.Drawing.Size(157, 20)
        Me.txtModuleE.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(497, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "ModuleNameE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(325, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "ModuleNameV"
        '
        'txtModuleV
        '
        Me.txtModuleV.Location = New System.Drawing.Point(328, 33)
        Me.txtModuleV.Name = "txtModuleV"
        Me.txtModuleV.Size = New System.Drawing.Size(157, 20)
        Me.txtModuleV.TabIndex = 3
        '
        'txtModuleC
        '
        Me.txtModuleC.Location = New System.Drawing.Point(829, 33)
        Me.txtModuleC.Name = "txtModuleC"
        Me.txtModuleC.Size = New System.Drawing.Size(157, 20)
        Me.txtModuleC.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(660, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "ModuleNameJ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(246, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "ModuleID"
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(249, 34)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.Size = New System.Drawing.Size(73, 20)
        Me.txtModuleID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(85, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "GroupName"
        '
        'cboGropName
        '
        Me.cboGropName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGropName.FormattingEnabled = True
        Me.cboGropName.Location = New System.Drawing.Point(88, 33)
        Me.cboGropName.Name = "cboGropName"
        Me.cboGropName.Size = New System.Drawing.Size(152, 21)
        Me.cboGropName.TabIndex = 1
        '
        'txtgropID
        '
        Me.txtgropID.Location = New System.Drawing.Point(6, 33)
        Me.txtgropID.Name = "txtgropID"
        Me.txtgropID.Size = New System.Drawing.Size(73, 20)
        Me.txtgropID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "GroupID"
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuSave, Me.mnuDelete, Me.mnuShowAll, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1012, 58)
        Me.tlsMenu.TabIndex = 9
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
        Me.mnuNew.ToolTipText = "New (Ctrl+N)"
        '
        'mnuSave
        '
        Me.mnuSave.AutoSize = False
        Me.mnuSave.Image = CType(resources.GetObject("mnuSave.Image"), System.Drawing.Image)
        Me.mnuSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(60, 50)
        Me.mnuSave.Text = "Save"
        Me.mnuSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuSave.ToolTipText = "Save (Ctrl+S)"
        '
        'mnuDelete
        '
        Me.mnuDelete.AutoSize = False
        Me.mnuDelete.Image = CType(resources.GetObject("mnuDelete.Image"), System.Drawing.Image)
        Me.mnuDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuDelete.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Size = New System.Drawing.Size(60, 50)
        Me.mnuDelete.Text = "Delete"
        Me.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuDelete.ToolTipText = "Delete(Ctrl+D)"
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
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(257, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Max ModuleID"
        '
        'txtMaxModuleID
        '
        Me.txtMaxModuleID.Enabled = False
        Me.txtMaxModuleID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaxModuleID.Location = New System.Drawing.Point(260, 25)
        Me.txtMaxModuleID.Name = "txtMaxModuleID"
        Me.txtMaxModuleID.Size = New System.Drawing.Size(73, 20)
        Me.txtMaxModuleID.TabIndex = 11
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(0, 138)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1012, 289)
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
        'FrmModule
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1012, 429)
        Me.Controls.Add(Me.txtMaxModuleID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gboCondition)
        Me.Controls.Add(Me.tlsMenu)
        Me.Controls.Add(Me.GridControl1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmModule"
        Me.ShowInTaskbar = False
        Me.Tag = "9995"
        Me.Text = "Module"
        Me.gboCondition.ResumeLayout(False)
        Me.gboCondition.PerformLayout()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gboCondition As System.Windows.Forms.GroupBox
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtModuleC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtModuleE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtModuleID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGropName As System.Windows.Forms.ComboBox
    Friend WithEvents txtgropID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtModuleJ As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtModuleV As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMaxModuleID As System.Windows.Forms.TextBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
