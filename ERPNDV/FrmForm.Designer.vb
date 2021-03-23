<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmForm))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFormName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFormNameJ = New System.Windows.Forms.TextBox()
        Me.txtFormNameE = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtFormNameV = New System.Windows.Forms.TextBox()
        Me.txtFormNameC = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFormID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboModuleName = New System.Windows.Forms.ComboBox()
        Me.txtModuleID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuNew = New System.Windows.Forms.ToolStripButton()
        Me.mnuSave = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tlsMenu.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(554, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "FormName"
        '
        'txtFormName
        '
        Me.txtFormName.Location = New System.Drawing.Point(557, 26)
        Me.txtFormName.Name = "txtFormName"
        Me.txtFormName.Size = New System.Drawing.Size(75, 20)
        Me.txtFormName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1041, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "FormNameC"
        '
        'txtFormNameJ
        '
        Me.txtFormNameJ.Location = New System.Drawing.Point(906, 26)
        Me.txtFormNameJ.Name = "txtFormNameJ"
        Me.txtFormNameJ.Size = New System.Drawing.Size(138, 20)
        Me.txtFormNameJ.TabIndex = 6
        '
        'txtFormNameE
        '
        Me.txtFormNameE.Location = New System.Drawing.Point(768, 26)
        Me.txtFormNameE.Name = "txtFormNameE"
        Me.txtFormNameE.Size = New System.Drawing.Size(138, 20)
        Me.txtFormNameE.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(765, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "FormNameE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(635, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "FormNameV"
        '
        'txtFormNameV
        '
        Me.txtFormNameV.Location = New System.Drawing.Point(638, 26)
        Me.txtFormNameV.Name = "txtFormNameV"
        Me.txtFormNameV.Size = New System.Drawing.Size(124, 20)
        Me.txtFormNameV.TabIndex = 4
        '
        'txtFormNameC
        '
        Me.txtFormNameC.Location = New System.Drawing.Point(1044, 26)
        Me.txtFormNameC.Name = "txtFormNameC"
        Me.txtFormNameC.Size = New System.Drawing.Size(138, 20)
        Me.txtFormNameC.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(903, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "FormNameJ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(475, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "FormID"
        '
        'txtFormID
        '
        Me.txtFormID.Location = New System.Drawing.Point(478, 26)
        Me.txtFormID.Name = "txtFormID"
        Me.txtFormID.Size = New System.Drawing.Size(73, 20)
        Me.txtFormID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(325, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ModuleName"
        '
        'cboModuleName
        '
        Me.cboModuleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModuleName.FormattingEnabled = True
        Me.cboModuleName.Location = New System.Drawing.Point(326, 25)
        Me.cboModuleName.Name = "cboModuleName"
        Me.cboModuleName.Size = New System.Drawing.Size(152, 21)
        Me.cboModuleName.TabIndex = 1
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(253, 26)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.Size = New System.Drawing.Size(73, 20)
        Me.txtModuleID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(250, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ModuleID"
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuSave, Me.mnuDelete, Me.mnuShowAll, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1207, 58)
        Me.tlsMenu.TabIndex = 12
        '
        'mnuNew
        '
        Me.mnuNew.AutoSize = False
        Me.mnuNew.Image = CType(resources.GetObject("mnuNew.Image"), System.Drawing.Image)
        Me.mnuNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(60, 50)
        Me.mnuNew.Text = "Edit"
        Me.mnuNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuNew.ToolTipText = "Edit"
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
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 58)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1207, 411)
        Me.GridControl1.TabIndex = 18
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
        'FrmForm
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 469)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.txtFormName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtFormNameJ)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtFormNameE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtFormID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtModuleID)
        Me.Controls.Add(Me.cboModuleName)
        Me.Controls.Add(Me.txtFormNameV)
        Me.Controls.Add(Me.txtFormNameC)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmForm"
        Me.ShowInTaskbar = False
        Me.Tag = "9994"
        Me.Text = "Form"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFormNameJ As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtFormNameV As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFormNameC As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFormNameE As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFormID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboModuleName As System.Windows.Forms.ComboBox
    Friend WithEvents txtModuleID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFormName As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
