<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCharts
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.ctm = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuPreview = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuComment = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuDeleteComment = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctm.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        Me.Chart1.BorderSkin.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom
        Me.Chart1.BorderSkin.BorderColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Chart1.BorderSkin.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid
        Me.Chart1.BorderSkin.BorderWidth = 2
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Me.Chart1.ContextMenuStrip = Me.ctm
        Me.Chart1.Dock = System.Windows.Forms.DockStyle.Fill
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(0, 0)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Size = New System.Drawing.Size(748, 381)
        Me.Chart1.TabIndex = 6
        '
        'ctm
        '
        Me.ctm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopy, Me.mnuSave, Me.mnuPrint, Me.mnuPreview, Me.mnuComment, Me.mnuDeleteComment})
        Me.ctm.Name = "ctm"
        Me.ctm.Size = New System.Drawing.Size(165, 136)
        '
        'mnuCopy
        '
        Me.mnuCopy.Name = "mnuCopy"
        Me.mnuCopy.Size = New System.Drawing.Size(164, 22)
        Me.mnuCopy.Text = "Copy"
        '
        'mnuSave
        '
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.Size = New System.Drawing.Size(164, 22)
        Me.mnuSave.Text = "Save"
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(164, 22)
        Me.mnuPrint.Text = "Print"
        '
        'mnuPreview
        '
        Me.mnuPreview.Name = "mnuPreview"
        Me.mnuPreview.Size = New System.Drawing.Size(164, 22)
        Me.mnuPreview.Text = "Preview"
        '
        'mnuComment
        '
        Me.mnuComment.Name = "mnuComment"
        Me.mnuComment.Size = New System.Drawing.Size(164, 22)
        Me.mnuComment.Text = "Comment"
        '
        'mnuDeleteComment
        '
        Me.mnuDeleteComment.Name = "mnuDeleteComment"
        Me.mnuDeleteComment.Size = New System.Drawing.Size(164, 22)
        Me.mnuDeleteComment.Text = "Delete Comment"
        '
        'FrmCharts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 381)
        Me.Controls.Add(Me.Chart1)
        Me.KeyPreview = True
        Me.Name = "FrmCharts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Charts"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctm.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents ctm As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPreview As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuComment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDeleteComment As System.Windows.Forms.ToolStripMenuItem
End Class
