<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnThem = New DevExpress.XtraEditors.SimpleButton()
        Me.btnLuu = New DevExpress.XtraEditors.SimpleButton()
        Me.btnHienThi = New DevExpress.XtraEditors.SimpleButton()
        Me.btnXoa = New DevExpress.XtraEditors.SimpleButton()
        Me.btnChinhSua = New DevExpress.XtraEditors.SimpleButton()
        Me.btnReport = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTimKiem = New System.Windows.Forms.TextBox()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.FlowLayoutPanel1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnThem)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnLuu)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnHienThi)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnXoa)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnChinhSua)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnReport)
        Me.FlowLayoutPanel1.Controls.Add(Me.Label1)
        Me.FlowLayoutPanel1.Controls.Add(Me.txtTimKiem)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(718, 47)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btnThem
        '
        Me.btnThem.Location = New System.Drawing.Point(3, 3)
        Me.btnThem.Name = "btnThem"
        Me.btnThem.Size = New System.Drawing.Size(75, 44)
        Me.btnThem.TabIndex = 0
        Me.btnThem.Text = "Thêm mới"
        '
        'btnLuu
        '
        Me.btnLuu.Location = New System.Drawing.Point(84, 3)
        Me.btnLuu.Name = "btnLuu"
        Me.btnLuu.Size = New System.Drawing.Size(75, 44)
        Me.btnLuu.TabIndex = 1
        Me.btnLuu.Text = "Lưu"
        '
        'btnHienThi
        '
        Me.btnHienThi.Location = New System.Drawing.Point(165, 3)
        Me.btnHienThi.Name = "btnHienThi"
        Me.btnHienThi.Size = New System.Drawing.Size(75, 44)
        Me.btnHienThi.TabIndex = 2
        Me.btnHienThi.Text = "Hiển thị"
        '
        'btnXoa
        '
        Me.btnXoa.Location = New System.Drawing.Point(246, 3)
        Me.btnXoa.Name = "btnXoa"
        Me.btnXoa.Size = New System.Drawing.Size(75, 44)
        Me.btnXoa.TabIndex = 3
        Me.btnXoa.Text = "Xóa"
        '
        'btnChinhSua
        '
        Me.btnChinhSua.Location = New System.Drawing.Point(327, 3)
        Me.btnChinhSua.Name = "btnChinhSua"
        Me.btnChinhSua.Size = New System.Drawing.Size(75, 44)
        Me.btnChinhSua.TabIndex = 4
        Me.btnChinhSua.Text = "Chỉnh sửa"
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(408, 3)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(75, 44)
        Me.btnReport.TabIndex = 5
        Me.btnReport.Text = "Report"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(489, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tìm kiếm"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTimKiem
        '
        Me.txtTimKiem.Location = New System.Drawing.Point(595, 3)
        Me.txtTimKiem.Name = "txtTimKiem"
        Me.txtTimKiem.Size = New System.Drawing.Size(100, 20)
        Me.txtTimKiem.TabIndex = 7
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(3, 112)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(718, 331)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GridControl1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.19277!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.80723!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 336.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(724, 446)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.Label2)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox1)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label3)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox2)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label4)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox3)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox4)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label6)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox5)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label7)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox6)
        Me.FlowLayoutPanel2.Controls.Add(Me.Label8)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBox7)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(3, 56)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(718, 50)
        Me.FlowLayoutPanel2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mã NV"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(49, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(42, 20)
        Me.TextBox1.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(97, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Tên NV"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(147, 3)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(46, 20)
        Me.TextBox2.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(199, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "NS"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(227, 3)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(47, 20)
        Me.TextBox3.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(280, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Giới tính"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(333, 3)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(41, 20)
        Me.TextBox4.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(380, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ngày vào"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(439, 3)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(41, 20)
        Me.TextBox5.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(486, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Số ngày làm"
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(557, 3)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(41, 20)
        Me.TextBox6.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(604, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Số giờ làm"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(666, 3)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(41, 20)
        Me.TextBox7.TabIndex = 1
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(724, 446)
        Me.Tag = "0258TS"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnThem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnLuu As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnHienThi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnXoa As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnChinhSua As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnReport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTimKiem As TextBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox6 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents TextBox7 As TextBox
End Class
