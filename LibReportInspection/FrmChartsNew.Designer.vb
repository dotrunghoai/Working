<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChartsNew
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
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.ccbbError = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.chbError0641 = New DevExpress.XtraEditors.CheckEdit()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.ccbbError.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chbError0641.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ChartControl1
        '
        Me.ChartControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChartControl1.Legend.Name = "Default Legend"
        Me.ChartControl1.Location = New System.Drawing.Point(2, 2)
        Me.ChartControl1.Name = "ChartControl1"
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
        Me.ChartControl1.SeriesTemplate.SeriesPointsSortingKey = DevExpress.XtraCharts.SeriesPointKey.Value_1
        Me.ChartControl1.Size = New System.Drawing.Size(696, 388)
        Me.ChartControl1.TabIndex = 0
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GroupControl3)
        Me.GroupControl1.Controls.Add(Me.chbError0641)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.ShowCaption = False
        Me.GroupControl1.Size = New System.Drawing.Size(700, 53)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "GroupControl1"
        '
        'GroupControl3
        '
        Me.GroupControl3.AppearanceCaption.Options.UseTextOptions = True
        Me.GroupControl3.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GroupControl3.Controls.Add(Me.ccbbError)
        Me.GroupControl3.Location = New System.Drawing.Point(188, 0)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(136, 53)
        Me.GroupControl3.TabIndex = 1
        Me.GroupControl3.Text = "Error Filter"
        '
        'ccbbError
        '
        Me.ccbbError.EditValue = ""
        Me.ccbbError.Location = New System.Drawing.Point(18, 28)
        Me.ccbbError.Name = "ccbbError"
        Me.ccbbError.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ccbbError.Properties.DropDownRows = 20
        Me.ccbbError.Size = New System.Drawing.Size(100, 20)
        Me.ccbbError.TabIndex = 2
        '
        'chbError0641
        '
        Me.chbError0641.Location = New System.Drawing.Point(11, 18)
        Me.chbError0641.Name = "chbError0641"
        Me.chbError0641.Properties.Caption = "Không hiển thị lỗi 0641"
        Me.chbError0641.Size = New System.Drawing.Size(151, 20)
        Me.chbError0641.TabIndex = 0
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.ChartControl1)
        Me.GroupControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl2.Location = New System.Drawing.Point(0, 53)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.ShowCaption = False
        Me.GroupControl2.Size = New System.Drawing.Size(700, 392)
        Me.GroupControl2.TabIndex = 2
        Me.GroupControl2.Text = "GroupControl2"
        '
        'FrmChartsNew
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 445)
        Me.Controls.Add(Me.GroupControl2)
        Me.Controls.Add(Me.GroupControl1)
        Me.KeyPreview = True
        Me.Name = "FrmChartsNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmChartsNew"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.ccbbError.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chbError0641.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents chbError0641 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents ccbbError As DevExpress.XtraEditors.CheckedComboBoxEdit
End Class
