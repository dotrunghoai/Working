<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReport
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
        Me.ReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'ReportViewer
        '
        Me.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer.Name = "ReportViewer"
        Me.ReportViewer.ServerReport.BearerToken = Nothing
        Me.ReportViewer.Size = New System.Drawing.Size(813, 643)
        Me.ReportViewer.TabIndex = 0
        '
        'FrmReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 643)
        Me.Controls.Add(Me.ReportViewer)
        Me.Name = "FrmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents ReportViewer As Microsoft.Reporting.WinForms.ReportViewer
End Class
