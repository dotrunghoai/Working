<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCheckQty
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCheckQty))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gridD = New UtilityControl.CustomDataGridView()
        Me.JCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LOQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.KhoQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bdn = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tlsMenu.SuspendLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bdn.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.mnuExport, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tlsMenu.Size = New System.Drawing.Size(738, 59)
        Me.tlsMenu.TabIndex = 1
        Me.tlsMenu.Text = "ToolStrip1"
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
        Me.mnuShowAll.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.mnuExport.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 59)
        '
        'gridD
        '
        Me.gridD.AllowUserToAddRows = False
        Me.gridD.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.gridD.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JCode, Me.LOQty, Me.KhoQty})
        Me.gridD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridD.EnableHeadersVisualStyles = False
        Me.gridD.Location = New System.Drawing.Point(0, 59)
        Me.gridD.Name = "gridD"
        Me.gridD.ReadOnly = True
        Me.gridD.RowHeadersWidth = 20
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.gridD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridD.Size = New System.Drawing.Size(738, 317)
        Me.gridD.TabIndex = 37
        '
        'JCode
        '
        Me.JCode.DataPropertyName = "JCode"
        Me.JCode.HeaderText = "JCode"
        Me.JCode.Name = "JCode"
        Me.JCode.ReadOnly = True
        '
        'LOQty
        '
        Me.LOQty.DataPropertyName = "LOQty"
        Me.LOQty.HeaderText = "LOQty"
        Me.LOQty.Name = "LOQty"
        Me.LOQty.ReadOnly = True
        '
        'KhoQty
        '
        Me.KhoQty.DataPropertyName = "KhoQty"
        Me.KhoQty.HeaderText = "KhoQty"
        Me.KhoQty.Name = "KhoQty"
        Me.KhoQty.ReadOnly = True
        '
        'bdn
        '
        Me.bdn.AddNewItem = Nothing
        Me.bdn.CountItem = Me.BindingNavigatorCountItem
        Me.bdn.DeleteItem = Nothing
        Me.bdn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bdn.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.bdn.Location = New System.Drawing.Point(0, 376)
        Me.bdn.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bdn.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bdn.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bdn.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bdn.Name = "bdn"
        Me.bdn.PositionItem = Me.BindingNavigatorPositionItem
        Me.bdn.Size = New System.Drawing.Size(738, 25)
        Me.bdn.TabIndex = 38
        Me.bdn.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'FrmCheckQty
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(738, 401)
        Me.Controls.Add(Me.gridD)
        Me.Controls.Add(Me.bdn)
        Me.Controls.Add(Me.tlsMenu)
        Me.Name = "FrmCheckQty"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CheckQty TempB"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bdn, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bdn.ResumeLayout(False)
        Me.bdn.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gridD As UtilityControl.CustomDataGridView
    Friend WithEvents bdn As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents JCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KhoQty As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
