<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmProcessHour9785
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmProcessHour9785))
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuImport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cboProduct = New System.Windows.Forms.ComboBox()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.cboRC = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ctn = New System.Windows.Forms.SplitContainer()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridControl2 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ckoCompare = New System.Windows.Forms.CheckBox()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtSum = New DevExpress.XtraEditors.TextEdit()
        Me.tlsMenu.SuspendLayout()
        CType(Me.ctn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctn.Panel1.SuspendLayout()
        Me.ctn.Panel2.SuspendLayout()
        Me.ctn.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSum.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuEdit, Me.ToolStripSeparator2, Me.mnuDelete, Me.mnuExport, Me.mnuImport, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1244, 59)
        Me.tlsMenu.TabIndex = 0
        '
        'mnuShowAll
        '
        Me.mnuShowAll.AutoSize = False
        Me.mnuShowAll.Image = CType(resources.GetObject("mnuShowAll.Image"), System.Drawing.Image)
        Me.mnuShowAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuShowAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuShowAll.Name = "mnuShowAll"
        Me.mnuShowAll.Size = New System.Drawing.Size(60, 50)
        Me.mnuShowAll.Text = "Show All"
        Me.mnuShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuShowAll.ToolTipText = "Show All (F5)"
        '
        'mnuEdit
        '
        Me.mnuEdit.AutoSize = False
        Me.mnuEdit.Image = CType(resources.GetObject("mnuEdit.Image"), System.Drawing.Image)
        Me.mnuEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(60, 50)
        Me.mnuEdit.Text = "Edit"
        Me.mnuEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuEdit.ToolTipText = "Edit (Ctrl + E)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 59)
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
        Me.mnuDelete.ToolTipText = "Delete (Ctrl+D)"
        '
        'mnuExport
        '
        Me.mnuExport.AutoSize = False
        Me.mnuExport.Image = CType(resources.GetObject("mnuExport.Image"), System.Drawing.Image)
        Me.mnuExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(60, 50)
        Me.mnuExport.Text = "Export"
        Me.mnuExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuExport.ToolTipText = "Export"
        '
        'mnuImport
        '
        Me.mnuImport.AutoSize = False
        Me.mnuImport.Image = CType(resources.GetObject("mnuImport.Image"), System.Drawing.Image)
        Me.mnuImport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuImport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuImport.Name = "mnuImport"
        Me.mnuImport.Size = New System.Drawing.Size(60, 50)
        Me.mnuImport.Text = "Import"
        Me.mnuImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuImport.ToolTipText = "Import"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 59)
        '
        'cboProduct
        '
        Me.cboProduct.FormattingEnabled = True
        Me.cboProduct.Location = New System.Drawing.Point(344, 24)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(100, 22)
        Me.cboProduct.TabIndex = 29
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(344, 10)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(44, 14)
        Me.lblProcess.TabIndex = 28
        Me.lblProcess.Text = "Product"
        '
        'cboRC
        '
        Me.cboRC.FormattingEnabled = True
        Me.cboRC.Location = New System.Drawing.Point(444, 24)
        Me.cboRC.Name = "cboRC"
        Me.cboRC.Size = New System.Drawing.Size(66, 22)
        Me.cboRC.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(444, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 14)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Revision"
        '
        'ctn
        '
        Me.ctn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ctn.Location = New System.Drawing.Point(0, 59)
        Me.ctn.Name = "ctn"
        '
        'ctn.Panel1
        '
        Me.ctn.Panel1.Controls.Add(Me.GridControl1)
        '
        'ctn.Panel2
        '
        Me.ctn.Panel2.Controls.Add(Me.GridControl2)
        Me.ctn.Size = New System.Drawing.Size(1244, 435)
        Me.ctn.SplitterDistance = 615
        Me.ctn.TabIndex = 32
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(615, 435)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 325
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridControl2
        '
        Me.GridControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl2.Location = New System.Drawing.Point(0, 0)
        Me.GridControl2.MainView = Me.GridView2
        Me.GridControl2.Name = "GridControl2"
        Me.GridControl2.Size = New System.Drawing.Size(625, 435)
        Me.GridControl2.TabIndex = 1
        Me.GridControl2.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.DetailHeight = 325
        Me.GridView2.GridControl = Me.GridControl2
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'ckoCompare
        '
        Me.ckoCompare.AutoSize = True
        Me.ckoCompare.Checked = True
        Me.ckoCompare.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckoCompare.Location = New System.Drawing.Point(525, 26)
        Me.ckoCompare.Name = "ckoCompare"
        Me.ckoCompare.Size = New System.Drawing.Size(105, 18)
        Me.ckoCompare.TabIndex = 33
        Me.ckoCompare.Text = "Compare Old RC"
        Me.ckoCompare.UseVisualStyleBackColor = True
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl1.Location = New System.Drawing.Point(1132, 9)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(24, 13)
        Me.LabelControl1.TabIndex = 36
        Me.LabelControl1.Text = "Sum:"
        '
        'txtSum
        '
        Me.txtSum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSum.Location = New System.Drawing.Point(1132, 23)
        Me.txtSum.Name = "txtSum"
        Me.txtSum.Properties.ReadOnly = True
        Me.txtSum.Size = New System.Drawing.Size(100, 20)
        Me.txtSum.TabIndex = 37
        '
        'FrmProcessHour9785
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1244, 494)
        Me.Controls.Add(Me.txtSum)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.ckoCompare)
        Me.Controls.Add(Me.ctn)
        Me.Controls.Add(Me.cboRC)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboProduct)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmProcessHour9785"
        Me.ShowInTaskbar = False
        Me.Tag = "0254PD09"
        Me.Text = "Leadtime tiếng độ giờ 9785"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.ctn.Panel1.ResumeLayout(False)
        Me.ctn.Panel2.ResumeLayout(False)
        CType(Me.ctn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctn.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSum.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboProduct As System.Windows.Forms.ComboBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents cboRC As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ctn As SplitContainer
    Friend WithEvents ckoCompare As CheckBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridControl2 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtSum As DevExpress.XtraEditors.TextEdit
End Class
