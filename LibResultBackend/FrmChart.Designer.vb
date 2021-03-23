<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChart
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChartControl1
        '
        Me.ChartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl1.Legend.Name = "Default Legend"
        Me.ChartControl1.Location = New System.Drawing.Point(0, 0)
        Me.ChartControl1.Name = "ChartControl1"
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.ChartControl1.Size = New System.Drawing.Size(655, 415)
        Me.ChartControl1.TabIndex = 0
        '
        'FrmChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(655, 415)
        Me.Controls.Add(Me.ChartControl1)
        Me.Name = "FrmChart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chart Backend Result"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
End Class
