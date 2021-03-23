<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFirstLotHS
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFirstLotHS))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuRefresh = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuExport = New System.Windows.Forms.ToolStripButton()
        Me.mnuGetPrintDate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.bnFirstLot = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txtTotalLot = New System.Windows.Forms.ToolStripTextBox()
        Me.gridFirstLot = New UtilityControl.CustomDataGridView()
        Me.Customer = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartLot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndLot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalLot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrintDateStatus = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.IsCL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Machine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tlsMenu.SuspendLayout()
        CType(Me.bnFirstLot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bnFirstLot.SuspendLayout()
        CType(Me.gridFirstLot, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.BackColor = System.Drawing.Color.White
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRefresh, Me.mnuDelete, Me.mnuEdit, Me.ToolStripSeparator2, Me.mnuExport, Me.mnuGetPrintDate, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(868, 55)
        Me.tlsMenu.TabIndex = 0
        '
        'mnuRefresh
        '
        Me.mnuRefresh.AutoSize = False
        Me.mnuRefresh.Image = CType(resources.GetObject("mnuRefresh.Image"), System.Drawing.Image)
        Me.mnuRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuRefresh.Name = "mnuRefresh"
        Me.mnuRefresh.Size = New System.Drawing.Size(99, 50)
        Me.mnuRefresh.Text = "Dữ liệu mới nhất"
        Me.mnuRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuRefresh.ToolTipText = "Refresh"
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
        Me.mnuDelete.Text = "Xóa dòng"
        Me.mnuDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuDelete.ToolTipText = "Delete (Ctrl+D)"
        '
        'mnuEdit
        '
        Me.mnuEdit.AutoSize = False
        Me.mnuEdit.Image = CType(resources.GetObject("mnuEdit.Image"), System.Drawing.Image)
        Me.mnuEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(60, 50)
        Me.mnuEdit.Text = "Chỉnh sửa"
        Me.mnuEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuEdit.ToolTipText = "Edit (Ctrl + E)"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
        '
        'mnuExport
        '
        Me.mnuExport.AutoSize = False
        Me.mnuExport.Image = CType(resources.GetObject("mnuExport.Image"), System.Drawing.Image)
        Me.mnuExport.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuExport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuExport.Name = "mnuExport"
        Me.mnuExport.Size = New System.Drawing.Size(60, 50)
        Me.mnuExport.Text = "Xuất excel"
        Me.mnuExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuExport.ToolTipText = "Export"
        '
        'mnuGetPrintDate
        '
        Me.mnuGetPrintDate.AutoSize = False
        Me.mnuGetPrintDate.Image = CType(resources.GetObject("mnuGetPrintDate.Image"), System.Drawing.Image)
        Me.mnuGetPrintDate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.mnuGetPrintDate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuGetPrintDate.Name = "mnuGetPrintDate"
        Me.mnuGetPrintDate.Size = New System.Drawing.Size(90, 50)
        Me.mnuGetPrintDate.Text = "Xem tình trạng"
        Me.mnuGetPrintDate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.mnuGetPrintDate.ToolTipText = "Get Print Date"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
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
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
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
        'bnFirstLot
        '
        Me.bnFirstLot.AddNewItem = Nothing
        Me.bnFirstLot.CountItem = Me.BindingNavigatorCountItem
        Me.bnFirstLot.DeleteItem = Nothing
        Me.bnFirstLot.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bnFirstLot.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.ToolStripLabel1, Me.txtTotalLot})
        Me.bnFirstLot.Location = New System.Drawing.Point(0, 410)
        Me.bnFirstLot.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.bnFirstLot.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.bnFirstLot.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.bnFirstLot.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.bnFirstLot.Name = "bnFirstLot"
        Me.bnFirstLot.PositionItem = Me.BindingNavigatorPositionItem
        Me.bnFirstLot.Size = New System.Drawing.Size(868, 25)
        Me.bnFirstLot.TabIndex = 22
        Me.bnFirstLot.Text = "BindingNavigator1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(34, 22)
        Me.ToolStripLabel1.Text = "Total"
        '
        'txtTotalLot
        '
        Me.txtTotalLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalLot.Name = "txtTotalLot"
        Me.txtTotalLot.Size = New System.Drawing.Size(100, 25)
        Me.txtTotalLot.Text = "0"
        Me.txtTotalLot.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'gridFirstLot
        '
        Me.gridFirstLot.AllowUserToAddRows = False
        Me.gridFirstLot.AllowUserToDeleteRows = False
        Me.gridFirstLot.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridFirstLot.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.gridFirstLot.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Customer, Me.ProductCode, Me.StartLot, Me.EndLot, Me.TotalLot, Me.PrintDateStatus, Me.IsCL, Me.Machine})
        Me.gridFirstLot.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridFirstLot.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.gridFirstLot.EnableHeadersVisualStyles = False
        Me.gridFirstLot.Location = New System.Drawing.Point(0, 55)
        Me.gridFirstLot.MultiSelect = False
        Me.gridFirstLot.Name = "gridFirstLot"
        Me.gridFirstLot.RowHeadersWidth = 15
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Blue
        Me.gridFirstLot.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.gridFirstLot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridFirstLot.Size = New System.Drawing.Size(868, 355)
        Me.gridFirstLot.TabIndex = 23
        '
        'Customer
        '
        Me.Customer.DataPropertyName = "Customer"
        Me.Customer.HeaderText = "Khách hàng"
        Me.Customer.Name = "Customer"
        Me.Customer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Customer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "ProductCode"
        Me.ProductCode.HeaderText = "Sản phẩm"
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'StartLot
        '
        Me.StartLot.DataPropertyName = "StartLot"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.StartLot.DefaultCellStyle = DataGridViewCellStyle2
        Me.StartLot.HeaderText = "Lô bắt đầu"
        Me.StartLot.Name = "StartLot"
        Me.StartLot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'EndLot
        '
        Me.EndLot.DataPropertyName = "EndLot"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.EndLot.DefaultCellStyle = DataGridViewCellStyle3
        Me.EndLot.HeaderText = "Lô kết thúc"
        Me.EndLot.Name = "EndLot"
        Me.EndLot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TotalLot
        '
        Me.TotalLot.DataPropertyName = "TotalLot"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.TotalLot.DefaultCellStyle = DataGridViewCellStyle4
        Me.TotalLot.HeaderText = "Tổng số lô"
        Me.TotalLot.Name = "TotalLot"
        Me.TotalLot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'PrintDateStatus
        '
        Me.PrintDateStatus.DataPropertyName = "PrintDateStatus"
        Me.PrintDateStatus.HeaderText = "Tình trạng QT"
        Me.PrintDateStatus.Name = "PrintDateStatus"
        Me.PrintDateStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrintDateStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'IsCL
        '
        Me.IsCL.DataPropertyName = "IsCL"
        Me.IsCL.HeaderText = "IS_RPP"
        Me.IsCL.Name = "IsCL"
        Me.IsCL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.IsCL.Visible = False
        '
        'Machine
        '
        Me.Machine.DataPropertyName = "Machine"
        Me.Machine.HeaderText = "Máy"
        Me.Machine.Name = "Machine"
        Me.Machine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'dtpDate
        '
        Me.dtpDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDate.Location = New System.Drawing.Point(386, 26)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpDate.TabIndex = 32
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(386, 9)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(99, 13)
        Me.lblDate.TabIndex = 31
        Me.lblDate.Text = "Ngày lấy lô bắt đầu"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(495, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(323, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "(Chú ý: chương trình sẽ lấy dữ liệu chỉnh lưu trước ngày này 1 ngày)"
        '
        'FrmFirstLotHS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 435)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.gridFirstLot)
        Me.Controls.Add(Me.bnFirstLot)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmFirstLotHS"
        Me.ShowInTaskbar = False
        Me.Tag = "0254PD05"
        Me.Text = "Lô bắt đầu của rọi sáng"
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        CType(Me.bnFirstLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bnFirstLot.ResumeLayout(False)
        Me.bnFirstLot.PerformLayout()
        CType(Me.gridFirstLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuGetPrintDate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExport As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bnFirstLot As System.Windows.Forms.BindingNavigator
    Friend WithEvents gridFirstLot As UtilityControl.CustomDataGridView
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents txtTotalLot As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuRefresh As System.Windows.Forms.ToolStripButton
    Friend WithEvents Customer As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartLot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndLot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalLot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrintDateStatus As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents IsCL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Machine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
