Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPermissionControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPermissionControl))
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuUnCheck = New System.Windows.Forms.ToolStripButton()
        Me.mnuCheckAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ckoEdit = New DevExpress.XtraEditors.CheckEdit()
        Me.ckoIsAdmin = New DevExpress.XtraEditors.CheckEdit()
        Me.tlsMenu.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckoEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ckoIsAdmin.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuUnCheck, Me.mnuCheckAll, Me.ToolStripSeparator1, Me.mnuDelete})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(529, 58)
        Me.tlsMenu.TabIndex = 9
        '
        'mnuUnCheck
        '
        Me.mnuUnCheck.AutoSize = False
        Me.mnuUnCheck.Image = CType(resources.GetObject("mnuUnCheck.Image"), System.Drawing.Image)
        Me.mnuUnCheck.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuUnCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuUnCheck.Margin = New System.Windows.Forms.Padding(0, 1, 0, 0)
        Me.mnuUnCheck.Name = "mnuUnCheck"
        Me.mnuUnCheck.Size = New System.Drawing.Size(60, 50)
        Me.mnuUnCheck.Text = "Uncheck"
        Me.mnuUnCheck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuUnCheck.ToolTipText = "Uncheck"
        '
        'mnuCheckAll
        '
        Me.mnuCheckAll.AutoSize = False
        Me.mnuCheckAll.Image = CType(resources.GetObject("mnuCheckAll.Image"), System.Drawing.Image)
        Me.mnuCheckAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuCheckAll.Name = "mnuCheckAll"
        Me.mnuCheckAll.Size = New System.Drawing.Size(60, 50)
        Me.mnuCheckAll.Text = "Check all"
        Me.mnuCheckAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuCheckAll.ToolTipText = "Check all"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 58)
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ControlName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ControlName"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ControlText"
        Me.DataGridViewTextBoxColumn2.HeaderText = "ControlText"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 150
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 58)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(529, 284)
        Me.GridControl1.TabIndex = 22
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
        'ckoEdit
        '
        Me.ckoEdit.Location = New System.Drawing.Point(267, 12)
        Me.ckoEdit.Name = "ckoEdit"
        Me.ckoEdit.Properties.Caption = "IsEdit"
        Me.ckoEdit.Size = New System.Drawing.Size(75, 20)
        Me.ckoEdit.TabIndex = 23
        '
        'ckoIsAdmin
        '
        Me.ckoIsAdmin.Location = New System.Drawing.Point(348, 12)
        Me.ckoIsAdmin.Name = "ckoIsAdmin"
        Me.ckoIsAdmin.Properties.Caption = "IsAdmin"
        Me.ckoIsAdmin.Size = New System.Drawing.Size(75, 20)
        Me.ckoIsAdmin.TabIndex = 24
        '
        'FrmPermissionControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(529, 342)
        Me.Controls.Add(Me.ckoIsAdmin)
        Me.Controls.Add(Me.ckoEdit)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.tlsMenu)
        Me.KeyPreview = True
        Me.Name = "FrmPermissionControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Permission Control"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckoEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ckoIsAdmin.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuUnCheck As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuCheckAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ckoEdit As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents mnuDelete As ToolStripButton
    Friend WithEvents ckoIsAdmin As DevExpress.XtraEditors.CheckEdit
End Class
