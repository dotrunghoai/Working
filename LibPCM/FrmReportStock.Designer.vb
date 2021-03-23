<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmReportStock))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.nmuGetEndLot = New System.Windows.Forms.ToolStripButton()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuPrint = New System.Windows.Forms.ToolStripButton()
        Me.mnuJLots = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gridD = New UtilityControl.CustomDataGridView()
        Me.JCode = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.PrcName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.SubPrcName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Cc = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.PdCode = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.EndLot = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.StockWS = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.StockAS = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.JEName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.JVName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Unit = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.JLots = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.bnGrid = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsStock = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFilterMatCode = New System.Windows.Forms.Label()
        Me.lblPdCode = New System.Windows.Forms.Label()
        Me.txtJCode = New System.Windows.Forms.TextBox()
        Me.txtPdCode = New System.Windows.Forms.TextBox()
        Me.cboJLots = New System.Windows.Forms.ComboBox()
        Me.lblFilterJLots = New System.Windows.Forms.Label()
        Me.tlsMenu.SuspendLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bnGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShowAll, Me.nmuGetEndLot, Me.mnuExport, Me.mnuPrint, Me.mnuJLots, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tlsMenu.Size = New System.Drawing.Size(984, 51)
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
        'nmuGetEndLot
        '
        Me.nmuGetEndLot.AutoSize = False
        Me.nmuGetEndLot.Image = CType(resources.GetObject("nmuGetEndLot.Image"), System.Drawing.Image)
        Me.nmuGetEndLot.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.nmuGetEndLot.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.nmuGetEndLot.Name = "nmuGetEndLot"
        Me.nmuGetEndLot.Size = New System.Drawing.Size(65, 50)
        Me.nmuGetEndLot.Text = "Get EndLot"
        Me.nmuGetEndLot.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.nmuGetEndLot.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'mnuPrint
        '
        Me.mnuPrint.AutoSize = False
        Me.mnuPrint.Image = CType(resources.GetObject("mnuPrint.Image"), System.Drawing.Image)
        Me.mnuPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(60, 50)
        Me.mnuPrint.Text = "Print"
        Me.mnuPrint.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'mnuJLots
        '
        Me.mnuJLots.AutoSize = False
        Me.mnuJLots.Image = CType(resources.GetObject("mnuJLots.Image"), System.Drawing.Image)
        Me.mnuJLots.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuJLots.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuJLots.Name = "mnuJLots"
        Me.mnuJLots.Size = New System.Drawing.Size(60, 50)
        Me.mnuJLots.Text = "JLots"
        Me.mnuJLots.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        Me.mnuJLots.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 51)
        '
        'gridD
        '
        Me.gridD.AllowUserToAddRows = False
        Me.gridD.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridD.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridD.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.JCode, Me.PrcName, Me.SubPrcName, Me.Cc, Me.PdCode, Me.EndLot, Me.StockWS, Me.StockAS, Me.JEName, Me.JVName, Me.Unit, Me.JLots})
        Me.gridD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridD.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridD.EnableHeadersVisualStyles = False
        Me.gridD.Location = New System.Drawing.Point(0, 51)
        Me.gridD.Name = "gridD"
        Me.gridD.RowHeadersWidth = 20
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridD.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridD.Size = New System.Drawing.Size(984, 567)
        Me.gridD.TabIndex = 41
        '
        'JCode
        '
        Me.JCode.DataPropertyName = "JCode"
        Me.JCode.Frozen = True
        Me.JCode.HeaderText = "JCode"
        Me.JCode.Name = "JCode"
        Me.JCode.ReadOnly = True
        Me.JCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JCode.Width = 70
        '
        'PrcName
        '
        Me.PrcName.DataPropertyName = "PrcName"
        Me.PrcName.Frozen = True
        Me.PrcName.HeaderText = "PrcName"
        Me.PrcName.Name = "PrcName"
        Me.PrcName.ReadOnly = True
        Me.PrcName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrcName.Width = 80
        '
        'SubPrcName
        '
        Me.SubPrcName.DataPropertyName = "SubPrcName"
        Me.SubPrcName.Frozen = True
        Me.SubPrcName.HeaderText = "SubPrcName"
        Me.SubPrcName.Name = "SubPrcName"
        Me.SubPrcName.ReadOnly = True
        Me.SubPrcName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Cc
        '
        Me.Cc.DataPropertyName = "Cc"
        Me.Cc.HeaderText = "Cc"
        Me.Cc.Name = "Cc"
        Me.Cc.ReadOnly = True
        Me.Cc.Width = 50
        '
        'PdCode
        '
        Me.PdCode.DataPropertyName = "PdCode"
        Me.PdCode.HeaderText = "PdCode"
        Me.PdCode.Name = "PdCode"
        Me.PdCode.ReadOnly = True
        Me.PdCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PdCode.Width = 60
        '
        'EndLot
        '
        Me.EndLot.DataPropertyName = "EndLot"
        Me.EndLot.HeaderText = "End Lot"
        Me.EndLot.Name = "EndLot"
        Me.EndLot.ReadOnly = True
        Me.EndLot.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EndLot.Width = 40
        '
        'StockWS
        '
        Me.StockWS.DataPropertyName = "StockWS"
        Me.StockWS.HeaderText = "StockWS"
        Me.StockWS.Name = "StockWS"
        Me.StockWS.ReadOnly = True
        Me.StockWS.Width = 80
        '
        'StockAS
        '
        Me.StockAS.DataPropertyName = "StockAS"
        Me.StockAS.HeaderText = "StockAS"
        Me.StockAS.Name = "StockAS"
        Me.StockAS.ReadOnly = True
        Me.StockAS.Width = 80
        '
        'JEName
        '
        Me.JEName.DataPropertyName = "JEName"
        Me.JEName.HeaderText = "JEName"
        Me.JEName.Name = "JEName"
        Me.JEName.ReadOnly = True
        Me.JEName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JEName.Width = 120
        '
        'JVName
        '
        Me.JVName.DataPropertyName = "JVName"
        Me.JVName.HeaderText = "JVName"
        Me.JVName.Name = "JVName"
        Me.JVName.ReadOnly = True
        Me.JVName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JVName.Width = 120
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "Unit"
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        Me.Unit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Unit.Width = 40
        '
        'JLots
        '
        Me.JLots.DataPropertyName = "JLots"
        Me.JLots.HeaderText = "JLots"
        Me.JLots.Name = "JLots"
        Me.JLots.ReadOnly = True
        Me.JLots.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.JLots.Width = 60
        '
        'bnGrid
        '
        Me.bnGrid.AddNewItem = Nothing
        Me.bnGrid.CountItem = Me.BindingNavigatorCountItem
        Me.bnGrid.DeleteItem = Nothing
        Me.bnGrid.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ToolStripStatusLabel1, Me.tsStock})
        Me.bnGrid.Location = New System.Drawing.Point(0, 618)
        Me.bnGrid.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnGrid.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnGrid.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnGrid.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnGrid.Name = "bnGrid"
        Me.bnGrid.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnGrid.Size = New System.Drawing.Size(984, 25)
        Me.bnGrid.TabIndex = 42
        Me.bnGrid.Text = "BindingNavigator1"
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
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(39, 20)
        Me.ToolStripStatusLabel1.Text = "Stock:"
        '
        'tsStock
        '
        Me.tsStock.ForeColor = System.Drawing.Color.Blue
        Me.tsStock.Name = "tsStock"
        Me.tsStock.Size = New System.Drawing.Size(13, 20)
        Me.tsStock.Text = "0"
        '
        'lblFilterMatCode
        '
        Me.lblFilterMatCode.AutoSize = True
        Me.lblFilterMatCode.Location = New System.Drawing.Point(326, 11)
        Me.lblFilterMatCode.Name = "lblFilterMatCode"
        Me.lblFilterMatCode.Size = New System.Drawing.Size(75, 13)
        Me.lblFilterMatCode.TabIndex = 43
        Me.lblFilterMatCode.Text = "Filter MatCode"
        '
        'lblPdCode
        '
        Me.lblPdCode.AutoSize = True
        Me.lblPdCode.Location = New System.Drawing.Point(417, 11)
        Me.lblPdCode.Name = "lblPdCode"
        Me.lblPdCode.Size = New System.Drawing.Size(70, 13)
        Me.lblPdCode.TabIndex = 45
        Me.lblPdCode.Text = "Filter PdCode"
        '
        'txtJCode
        '
        Me.txtJCode.Location = New System.Drawing.Point(326, 27)
        Me.txtJCode.Name = "txtJCode"
        Me.txtJCode.Size = New System.Drawing.Size(81, 20)
        Me.txtJCode.TabIndex = 47
        '
        'txtPdCode
        '
        Me.txtPdCode.Location = New System.Drawing.Point(417, 27)
        Me.txtPdCode.Name = "txtPdCode"
        Me.txtPdCode.Size = New System.Drawing.Size(81, 20)
        Me.txtPdCode.TabIndex = 48
        '
        'cboJLots
        '
        Me.cboJLots.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.cboJLots.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboJLots.FormattingEnabled = True
        Me.cboJLots.Location = New System.Drawing.Point(507, 27)
        Me.cboJLots.Name = "cboJLots"
        Me.cboJLots.Size = New System.Drawing.Size(72, 21)
        Me.cboJLots.TabIndex = 49
        '
        'lblFilterJLots
        '
        Me.lblFilterJLots.AutoSize = True
        Me.lblFilterJLots.Location = New System.Drawing.Point(507, 11)
        Me.lblFilterJLots.Name = "lblFilterJLots"
        Me.lblFilterJLots.Size = New System.Drawing.Size(57, 13)
        Me.lblFilterJLots.TabIndex = 50
        Me.lblFilterJLots.Text = "Filter JLots"
        '
        'FrmReportStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 643)
        Me.Controls.Add(Me.lblFilterJLots)
        Me.Controls.Add(Me.cboJLots)
        Me.Controls.Add(Me.txtPdCode)
        Me.Controls.Add(Me.txtJCode)
        Me.Controls.Add(Me.lblPdCode)
        Me.Controls.Add(Me.lblFilterMatCode)
        Me.Controls.Add(Me.gridD)
        Me.Controls.Add(Me.bnGrid)
        Me.Controls.Add(Me.tlsMenu)
        Me.KeyPreview = True
        Me.Name = "FrmReportStock"
        Me.Text = "FrmReportStock"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.gridD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bnGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnGrid.ResumeLayout(False)
        Me.bnGrid.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents gridD As UtilityControl.CustomDataGridView
    Friend WithEvents bnGrid As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsStock As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblFilterMatCode As System.Windows.Forms.Label
    Friend WithEvents lblPdCode As System.Windows.Forms.Label
    Friend WithEvents txtJCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPdCode As System.Windows.Forms.TextBox
    Friend WithEvents nmuGetEndLot As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuJLots As System.Windows.Forms.ToolStripButton
    Friend WithEvents JCode As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents PrcName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents SubPrcName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Cc As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents PdCode As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents EndLot As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents StockWS As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents StockAS As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents JEName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents JVName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Unit As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents JLots As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cboJLots As System.Windows.Forms.ComboBox
    Friend WithEvents lblFilterJLots As System.Windows.Forms.Label
End Class
