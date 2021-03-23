<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PictureViewer
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.showButton = New System.Windows.Forms.Button()
        Me.clearimageButton = New System.Windows.Forms.Button()
        Me.backgroupButton = New System.Windows.Forms.Button()
        Me.clearbackcolorButton = New System.Windows.Forms.Button()
        Me.closeButton = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.CheckBox1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 1, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(640, 353)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TableLayoutPanel1.SetColumnSpan(Me.PictureBox1, 2)
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(634, 311)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.Blue
        Me.CheckBox1.Location = New System.Drawing.Point(3, 320)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(90, 30)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "Stretch"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.showButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.clearimageButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.backgroupButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.clearbackcolorButton)
        Me.FlowLayoutPanel1.Controls.Add(Me.closeButton)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(99, 320)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(538, 30)
        Me.FlowLayoutPanel1.TabIndex = 2
        '
        'showButton
        '
        Me.showButton.Location = New System.Drawing.Point(433, 3)
        Me.showButton.Name = "showButton"
        Me.showButton.Size = New System.Drawing.Size(102, 23)
        Me.showButton.TabIndex = 0
        Me.showButton.Text = "Show a Picture"
        Me.showButton.UseVisualStyleBackColor = True
        '
        'clearimageButton
        '
        Me.clearimageButton.Location = New System.Drawing.Point(329, 3)
        Me.clearimageButton.Name = "clearimageButton"
        Me.clearimageButton.Size = New System.Drawing.Size(98, 23)
        Me.clearimageButton.TabIndex = 1
        Me.clearimageButton.Text = "Clear the picture"
        Me.clearimageButton.UseVisualStyleBackColor = True
        '
        'backgroupButton
        '
        Me.backgroupButton.Location = New System.Drawing.Point(178, 3)
        Me.backgroupButton.Name = "backgroupButton"
        Me.backgroupButton.Size = New System.Drawing.Size(145, 23)
        Me.backgroupButton.TabIndex = 2
        Me.backgroupButton.Text = "Set the background color"
        Me.backgroupButton.UseVisualStyleBackColor = True
        '
        'clearbackcolorButton
        '
        Me.clearbackcolorButton.Location = New System.Drawing.Point(64, 3)
        Me.clearbackcolorButton.Name = "clearbackcolorButton"
        Me.clearbackcolorButton.Size = New System.Drawing.Size(108, 23)
        Me.clearbackcolorButton.TabIndex = 3
        Me.clearbackcolorButton.Text = "Clear BackColor"
        Me.clearbackcolorButton.UseVisualStyleBackColor = True
        '
        'closeButton
        '
        Me.closeButton.Location = New System.Drawing.Point(3, 3)
        Me.closeButton.Name = "closeButton"
        Me.closeButton.Size = New System.Drawing.Size(55, 23)
        Me.closeButton.TabIndex = 4
        Me.closeButton.Text = "Close"
        Me.closeButton.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" &
    "s (*.*)|*.*"
        Me.OpenFileDialog1.Title = "Select a picture file"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(640, 353)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Form2"
        Me.Text = "PictureViewer"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents showButton As Button
    Friend WithEvents clearimageButton As Button
    Friend WithEvents backgroupButton As Button
    Friend WithEvents clearbackcolorButton As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents closeButton As Button
End Class
