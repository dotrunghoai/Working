<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLanguage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLanguage))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gboGrid = New System.Windows.Forms.GroupBox()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.FormID = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.FormName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.Parent = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.ControlName = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.TextEnglish = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.TextVietNam = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.TextChina = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.TextJapan = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.IsTranslate = New DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn()
        Me.cboModule = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFormName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tlsMenu = New System.Windows.Forms.ToolStrip()
        Me.mnuNew = New System.Windows.Forms.ToolStripButton()
        Me.mnuDelete = New System.Windows.Forms.ToolStripButton()
        Me.mnuShowAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.gboGrid.SuspendLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlsMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'gboGrid
        '
        Me.gboGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gboGrid.Controls.Add(Me.BindingNavigator1)
        Me.gboGrid.Controls.Add(Me.grid)
        Me.gboGrid.Location = New System.Drawing.Point(0, 61)
        Me.gboGrid.Name = "gboGrid"
        Me.gboGrid.Size = New System.Drawing.Size(1044, 358)
        Me.gboGrid.TabIndex = 8
        Me.gboGrid.TabStop = False
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.CountItem = Me.BindingNavigatorCountItem
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.BindingNavigator1.Location = New System.Drawing.Point(3, 330)
        Me.BindingNavigator1.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.BindingNavigator1.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.BindingNavigator1.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.BindingNavigator1.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Me.BindingNavigatorPositionItem
        Me.BindingNavigator1.Size = New System.Drawing.Size(1038, 25)
        Me.BindingNavigator1.TabIndex = 1
        Me.BindingNavigator1.Text = "BindingNavigator1"
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
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AllowUserToOrderColumns = True
        Me.grid.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LemonChiffon
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FormID, Me.FormName, Me.Parent, Me.ControlName, Me.TextEnglish, Me.TextVietNam, Me.TextChina, Me.TextJapan, Me.IsTranslate})
        Me.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grid.EnableHeadersVisualStyles = False
        Me.grid.Location = New System.Drawing.Point(3, 16)
        Me.grid.Name = "grid"
        Me.grid.RowHeadersWidth = 20
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Blue
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.grid.Size = New System.Drawing.Size(1038, 311)
        Me.grid.TabIndex = 0
        '
        'FormID
        '
        Me.FormID.DataPropertyName = "FormID"
        Me.FormID.Frozen = True
        Me.FormID.HeaderText = "FormID"
        Me.FormID.Name = "FormID"
        Me.FormID.ReadOnly = True
        Me.FormID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FormName
        '
        Me.FormName.DataPropertyName = "FormName"
        Me.FormName.Frozen = True
        Me.FormName.HeaderText = "FormName"
        Me.FormName.Name = "FormName"
        Me.FormName.ReadOnly = True
        Me.FormName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Parent
        '
        Me.Parent.DataPropertyName = "Parent"
        Me.Parent.HeaderText = "Parent"
        Me.Parent.Name = "Parent"
        Me.Parent.ReadOnly = True
        Me.Parent.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ControlName
        '
        Me.ControlName.DataPropertyName = "ControlName"
        Me.ControlName.HeaderText = "ControlName"
        Me.ControlName.Name = "ControlName"
        Me.ControlName.ReadOnly = True
        Me.ControlName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'TextEnglish
        '
        Me.TextEnglish.DataPropertyName = "TextEnglish"
        Me.TextEnglish.HeaderText = "TextEnglish"
        Me.TextEnglish.Name = "TextEnglish"
        Me.TextEnglish.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'TextVietNam
        '
        Me.TextVietNam.DataPropertyName = "TextVietNam"
        Me.TextVietNam.HeaderText = "TextVietNam"
        Me.TextVietNam.Name = "TextVietNam"
        Me.TextVietNam.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'TextChina
        '
        Me.TextChina.DataPropertyName = "TextChina"
        Me.TextChina.HeaderText = "TextChina"
        Me.TextChina.Name = "TextChina"
        Me.TextChina.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'TextJapan
        '
        Me.TextJapan.DataPropertyName = "TextJapan"
        Me.TextJapan.HeaderText = "TextJapan"
        Me.TextJapan.Name = "TextJapan"
        Me.TextJapan.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'IsTranslate
        '
        Me.IsTranslate.DataPropertyName = "IsTranslate"
        Me.IsTranslate.HeaderText = "IsTranslate"
        Me.IsTranslate.Name = "IsTranslate"
        Me.IsTranslate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'cboModule
        '
        Me.cboModule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModule.FormattingEnabled = True
        Me.cboModule.Location = New System.Drawing.Point(201, 22)
        Me.cboModule.Name = "cboModule"
        Me.cboModule.Size = New System.Drawing.Size(135, 21)
        Me.cboModule.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(198, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Module"
        '
        'cboFormName
        '
        Me.cboFormName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFormName.FormattingEnabled = True
        Me.cboFormName.Location = New System.Drawing.Point(342, 22)
        Me.cboFormName.Name = "cboFormName"
        Me.cboFormName.Size = New System.Drawing.Size(181, 21)
        Me.cboFormName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(339, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "FormName"
        '
        'tlsMenu
        '
        Me.tlsMenu.AutoSize = False
        Me.tlsMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tlsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuDelete, Me.mnuShowAll, Me.ToolStripSeparator1})
        Me.tlsMenu.Location = New System.Drawing.Point(0, 0)
        Me.tlsMenu.Name = "tlsMenu"
        Me.tlsMenu.Size = New System.Drawing.Size(1044, 58)
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
        'FrmLanguage
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 421)
        Me.Controls.Add(Me.cboModule)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gboGrid)
        Me.Controls.Add(Me.cboFormName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tlsMenu)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "FrmLanguage"
        Me.ShowInTaskbar = False
        Me.Tag = "9997"
        Me.Text = "Language Management"
        Me.gboGrid.ResumeLayout(False)
        Me.gboGrid.PerformLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlsMenu.ResumeLayout(False)
        Me.tlsMenu.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gboGrid As System.Windows.Forms.GroupBox
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents tlsMenu As System.Windows.Forms.ToolStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents mnuShowAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboFormName As System.Windows.Forms.ComboBox
    Friend WithEvents cboModule As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FormID As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents FormName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents Parent As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents ControlName As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents TextEnglish As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents TextVietNam As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents TextChina As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents TextJapan As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents IsTranslate As DataGridViewAutoFilter.DataGridViewAutoFilterTextBoxColumn
    Friend WithEvents BindingNavigator1 As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
End Class
