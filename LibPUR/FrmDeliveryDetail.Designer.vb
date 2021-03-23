Imports UtilityControl

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDeliveryDetail
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDeliveryDetail))
        Me.gridDLRV = New UtilityControl.CustomDataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.JCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceivedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReceivedDate = New UtilityControl.CalendarColumn()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        CType(Me.gridDLRV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridDLRV
        '
        Me.gridDLRV.AllowUserToAddRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridDLRV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridDLRV.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gridDLRV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDLRV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.OrderID, Me.JCode, Me.OrderNo, Me.AP, Me.InvoiceID, Me.POID, Me.ReceivedQuantity, Me.ReceivedDate})
        Me.gridDLRV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDLRV.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridDLRV.EnableHeadersVisualStyles = False
        Me.gridDLRV.Location = New System.Drawing.Point(0, 55)
        Me.gridDLRV.Name = "gridDLRV"
        Me.gridDLRV.ReadOnly = True
        Me.gridDLRV.RowHeadersWidth = 20
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridDLRV.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.gridDLRV.Size = New System.Drawing.Size(724, 357)
        Me.gridDLRV.TabIndex = 2
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "GSR ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'OrderID
        '
        Me.OrderID.DataPropertyName = "OrderID"
        Me.OrderID.HeaderText = "OrderID"
        Me.OrderID.Name = "OrderID"
        Me.OrderID.ReadOnly = True
        '
        'JCode
        '
        Me.JCode.DataPropertyName = "JCode"
        Me.JCode.HeaderText = "JCode"
        Me.JCode.Name = "JCode"
        Me.JCode.ReadOnly = True
        '
        'OrderNo
        '
        Me.OrderNo.DataPropertyName = "OrderNo"
        Me.OrderNo.HeaderText = "OrderNo"
        Me.OrderNo.Name = "OrderNo"
        Me.OrderNo.ReadOnly = True
        '
        'AP
        '
        Me.AP.DataPropertyName = "AP"
        Me.AP.HeaderText = "A/P"
        Me.AP.Name = "AP"
        Me.AP.ReadOnly = True
        Me.AP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'InvoiceID
        '
        Me.InvoiceID.DataPropertyName = "InvoiceID"
        Me.InvoiceID.HeaderText = "InvoiceID"
        Me.InvoiceID.Name = "InvoiceID"
        Me.InvoiceID.ReadOnly = True
        '
        'POID
        '
        Me.POID.DataPropertyName = "POID"
        Me.POID.HeaderText = "POID"
        Me.POID.Name = "POID"
        Me.POID.ReadOnly = True
        '
        'ReceivedQuantity
        '
        Me.ReceivedQuantity.DataPropertyName = "ReceivedQuantity"
        Me.ReceivedQuantity.HeaderText = "Received Quantity"
        Me.ReceivedQuantity.Name = "ReceivedQuantity"
        Me.ReceivedQuantity.ReadOnly = True
        '
        'ReceivedDate
        '
        Me.ReceivedDate.DataPropertyName = "ReceivedDate"
        Me.ReceivedDate.HeaderText = "Received Date"
        Me.ReceivedDate.Name = "ReceivedDate"
        Me.ReceivedDate.ReadOnly = True
        Me.ReceivedDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ReceivedDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuExport})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.tlsMenu.Size = New System.Drawing.Size(724, 55)
        Me.tlsMenu.TabIndex = 12
        Me.tlsMenu.Text = "ToolStrip1"
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
        'FrmDeliveryDetail
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 412)
        Me.Controls.Add(Me.gridDLRV)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmDeliveryDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Delivery Detail"
        CType(Me.gridDLRV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gridDLRV As CustomDataGridView
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReceivedDate As UtilityControl.CalendarColumn
End Class
