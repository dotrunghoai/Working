<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModuleDocument
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
        Me.bttOpenHDSD = New System.Windows.Forms.Button()
        Me.bttOpenYCVCT = New System.Windows.Forms.Button()
        Me.bttOpenMTCN = New System.Windows.Forms.Button()
        Me.bttOpenFlowchart = New System.Windows.Forms.Button()
        Me.txtHDSD = New System.Windows.Forms.TextBox()
        Me.txtYCVCT = New System.Windows.Forms.TextBox()
        Me.txtMTCN = New System.Windows.Forms.TextBox()
        Me.txtFlowchart = New System.Windows.Forms.TextBox()
        Me.bttAddHDSD = New System.Windows.Forms.Button()
        Me.bttAddYCVCT = New System.Windows.Forms.Button()
        Me.bttAddMTCN = New System.Windows.Forms.Button()
        Me.bttAddFlowchart = New System.Windows.Forms.Button()
        Me.bttSave = New System.Windows.Forms.Button()
        Me.lblModuleName = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'bttOpenHDSD
        '
        Me.bttOpenHDSD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttOpenHDSD.Location = New System.Drawing.Point(61, 36)
        Me.bttOpenHDSD.Name = "bttOpenHDSD"
        Me.bttOpenHDSD.Size = New System.Drawing.Size(182, 79)
        Me.bttOpenHDSD.TabIndex = 0
        Me.bttOpenHDSD.Text = "Hướng dẫn sử dụng"
        Me.bttOpenHDSD.UseVisualStyleBackColor = True
        '
        'bttOpenYCVCT
        '
        Me.bttOpenYCVCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttOpenYCVCT.Location = New System.Drawing.Point(61, 121)
        Me.bttOpenYCVCT.Name = "bttOpenYCVCT"
        Me.bttOpenYCVCT.Size = New System.Drawing.Size(182, 79)
        Me.bttOpenYCVCT.TabIndex = 1
        Me.bttOpenYCVCT.Text = "Yêu cầu viết chương trình"
        Me.bttOpenYCVCT.UseVisualStyleBackColor = True
        '
        'bttOpenMTCN
        '
        Me.bttOpenMTCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttOpenMTCN.Location = New System.Drawing.Point(61, 206)
        Me.bttOpenMTCN.Name = "bttOpenMTCN"
        Me.bttOpenMTCN.Size = New System.Drawing.Size(182, 79)
        Me.bttOpenMTCN.TabIndex = 2
        Me.bttOpenMTCN.Text = "Mô tả chức năng"
        Me.bttOpenMTCN.UseVisualStyleBackColor = True
        '
        'bttOpenFlowchart
        '
        Me.bttOpenFlowchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttOpenFlowchart.Location = New System.Drawing.Point(61, 291)
        Me.bttOpenFlowchart.Name = "bttOpenFlowchart"
        Me.bttOpenFlowchart.Size = New System.Drawing.Size(182, 79)
        Me.bttOpenFlowchart.TabIndex = 3
        Me.bttOpenFlowchart.Text = "Flowchart"
        Me.bttOpenFlowchart.UseVisualStyleBackColor = True
        '
        'txtHDSD
        '
        Me.txtHDSD.Location = New System.Drawing.Point(249, 66)
        Me.txtHDSD.Name = "txtHDSD"
        Me.txtHDSD.ReadOnly = True
        Me.txtHDSD.Size = New System.Drawing.Size(295, 20)
        Me.txtHDSD.TabIndex = 4
        '
        'txtYCVCT
        '
        Me.txtYCVCT.Location = New System.Drawing.Point(249, 151)
        Me.txtYCVCT.Name = "txtYCVCT"
        Me.txtYCVCT.ReadOnly = True
        Me.txtYCVCT.Size = New System.Drawing.Size(295, 20)
        Me.txtYCVCT.TabIndex = 5
        '
        'txtMTCN
        '
        Me.txtMTCN.Location = New System.Drawing.Point(249, 236)
        Me.txtMTCN.Name = "txtMTCN"
        Me.txtMTCN.ReadOnly = True
        Me.txtMTCN.Size = New System.Drawing.Size(295, 20)
        Me.txtMTCN.TabIndex = 6
        '
        'txtFlowchart
        '
        Me.txtFlowchart.Location = New System.Drawing.Point(249, 321)
        Me.txtFlowchart.Name = "txtFlowchart"
        Me.txtFlowchart.ReadOnly = True
        Me.txtFlowchart.Size = New System.Drawing.Size(295, 20)
        Me.txtFlowchart.TabIndex = 7
        '
        'bttAddHDSD
        '
        Me.bttAddHDSD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttAddHDSD.Location = New System.Drawing.Point(550, 64)
        Me.bttAddHDSD.Name = "bttAddHDSD"
        Me.bttAddHDSD.Size = New System.Drawing.Size(75, 23)
        Me.bttAddHDSD.TabIndex = 8
        Me.bttAddHDSD.Text = "..."
        Me.bttAddHDSD.UseVisualStyleBackColor = True
        Me.bttAddHDSD.Visible = False
        '
        'bttAddYCVCT
        '
        Me.bttAddYCVCT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttAddYCVCT.Location = New System.Drawing.Point(550, 148)
        Me.bttAddYCVCT.Name = "bttAddYCVCT"
        Me.bttAddYCVCT.Size = New System.Drawing.Size(75, 23)
        Me.bttAddYCVCT.TabIndex = 9
        Me.bttAddYCVCT.Text = "..."
        Me.bttAddYCVCT.UseVisualStyleBackColor = True
        Me.bttAddYCVCT.Visible = False
        '
        'bttAddMTCN
        '
        Me.bttAddMTCN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttAddMTCN.Location = New System.Drawing.Point(550, 233)
        Me.bttAddMTCN.Name = "bttAddMTCN"
        Me.bttAddMTCN.Size = New System.Drawing.Size(75, 23)
        Me.bttAddMTCN.TabIndex = 10
        Me.bttAddMTCN.Text = "..."
        Me.bttAddMTCN.UseVisualStyleBackColor = True
        Me.bttAddMTCN.Visible = False
        '
        'bttAddFlowchart
        '
        Me.bttAddFlowchart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttAddFlowchart.Location = New System.Drawing.Point(550, 318)
        Me.bttAddFlowchart.Name = "bttAddFlowchart"
        Me.bttAddFlowchart.Size = New System.Drawing.Size(75, 23)
        Me.bttAddFlowchart.TabIndex = 11
        Me.bttAddFlowchart.Text = "..."
        Me.bttAddFlowchart.UseVisualStyleBackColor = True
        Me.bttAddFlowchart.Visible = False
        '
        'bttSave
        '
        Me.bttSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bttSave.Location = New System.Drawing.Point(316, 351)
        Me.bttSave.Name = "bttSave"
        Me.bttSave.Size = New System.Drawing.Size(150, 47)
        Me.bttSave.TabIndex = 12
        Me.bttSave.Text = "Save"
        Me.bttSave.UseVisualStyleBackColor = True
        Me.bttSave.Visible = False
        '
        'lblModuleName
        '
        Me.lblModuleName.AutoSize = True
        Me.lblModuleName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModuleName.Location = New System.Drawing.Point(301, 9)
        Me.lblModuleName.Name = "lblModuleName"
        Me.lblModuleName.Size = New System.Drawing.Size(19, 15)
        Me.lblModuleName.TabIndex = 13
        Me.lblModuleName.TabStop = True
        Me.lblModuleName.Text = "..."
        '
        'FrmModuleDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 410)
        Me.Controls.Add(Me.lblModuleName)
        Me.Controls.Add(Me.bttSave)
        Me.Controls.Add(Me.bttAddFlowchart)
        Me.Controls.Add(Me.bttAddMTCN)
        Me.Controls.Add(Me.bttAddYCVCT)
        Me.Controls.Add(Me.bttAddHDSD)
        Me.Controls.Add(Me.txtFlowchart)
        Me.Controls.Add(Me.txtMTCN)
        Me.Controls.Add(Me.txtYCVCT)
        Me.Controls.Add(Me.txtHDSD)
        Me.Controls.Add(Me.bttOpenFlowchart)
        Me.Controls.Add(Me.bttOpenMTCN)
        Me.Controls.Add(Me.bttOpenYCVCT)
        Me.Controls.Add(Me.bttOpenHDSD)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.Name = "FrmModuleDocument"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "010102"
        Me.Text = "Tài liệu chương trình"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bttOpenHDSD As System.Windows.Forms.Button
    Friend WithEvents bttOpenYCVCT As System.Windows.Forms.Button
    Friend WithEvents bttOpenMTCN As System.Windows.Forms.Button
    Friend WithEvents bttOpenFlowchart As System.Windows.Forms.Button
    Friend WithEvents txtHDSD As System.Windows.Forms.TextBox
    Friend WithEvents txtYCVCT As System.Windows.Forms.TextBox
    Friend WithEvents txtMTCN As System.Windows.Forms.TextBox
    Friend WithEvents txtFlowchart As System.Windows.Forms.TextBox
    Friend WithEvents bttAddHDSD As System.Windows.Forms.Button
    Friend WithEvents bttAddYCVCT As System.Windows.Forms.Button
    Friend WithEvents bttAddMTCN As System.Windows.Forms.Button
    Friend WithEvents bttAddFlowchart As System.Windows.Forms.Button
    Friend WithEvents bttSave As System.Windows.Forms.Button
    Friend WithEvents lblModuleName As System.Windows.Forms.LinkLabel
End Class
