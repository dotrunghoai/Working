Imports PublicUtility
Imports CommonDB
Imports System.Windows.Forms
Imports System.IO

Public Class FrmAutoCopy
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim dt As New DataTable

    Private Sub FrmAutoCopy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim obj As New IT_AutoCopy
        obj.EmpID_K = CurrentUser.UserID
        If _db.ExistObject(obj) Then
            _db.GetObject(obj)
            txtEmpID.Text = obj.EmpID_K
            txtFrom.Text = obj.FromFolder
            txtTo.Text = obj.ToFolder
            txtTimer.Text = obj.Timer
        End If
        btnStop.Enabled = False
        Timer1.Enabled = False
        dt.Columns.Add("File")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Copy()
    End Sub

    Private Sub btnSelectFrom_Click(sender As Object, e As EventArgs) Handles btnSelectFrom.Click
        Dim obj As New IT_AutoCopy
        obj.EmpID_K = txtEmpID.Text
        If _db.ExistObject(obj) Then
            _db.GetObject(obj)
        Else
            obj.EmpID_K = CurrentUser.UserID
            _db.Insert(obj)
            txtEmpID.Text = obj.EmpID_K
        End If
        If IsNumeric(txtTimer.Text) Then
            obj.Timer = txtTimer.Text
        End If
        Dim browser As New FolderBrowserDialog()
        browser.ShowDialog()
        If browser.SelectedPath <> "" Then
            txtFrom.Text = browser.SelectedPath
            obj.FromFolder = txtFrom.Text
            _db.Update(obj)
        End If
    End Sub

    Private Sub btnSelectTo_Click(sender As Object, e As EventArgs) Handles btnSelectTo.Click
        Dim obj As New IT_AutoCopy
        obj.EmpID_K = txtEmpID.Text
        If _db.ExistObject(obj) Then
            _db.GetObject(obj)
        Else
            obj.EmpID_K = CurrentUser.UserID
            _db.Insert(obj)
            txtEmpID.Text = obj.EmpID_K
        End If
        If IsNumeric(txtTimer.Text) Then
            obj.Timer = txtTimer.Text
        End If
        Dim browser As New FolderBrowserDialog()
        browser.ShowDialog()
        If browser.SelectedPath <> "" Then
            txtTo.Text = browser.SelectedPath
            obj.ToFolder = txtTo.Text
            _db.Update(obj)
        End If
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        If txtFrom.Text = "" Or txtTo.Text = "" Or txtTimer.Text = "" Then
            ShowWarning("Path or Timer is null !")
            txtFrom.Select()
            txtTo.Select()
            Return
        End If
        Timer1.Interval = txtTimer.Text * 60 * 1000
        'Timer1.Interval = 5000
        Timer1.Enabled = True
        btnStart.Enabled = False
        btnStop.Enabled = True
        txtTimer.ReadOnly = True
        Copy()
        dteLast.EditValue = DateTime.Now
        dteNext.EditValue = dteLast.DateTime.AddMinutes(txtTimer.Text)
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        Timer1.Enabled = False
        btnStart.Enabled = True
        btnStop.Enabled = False
        txtTimer.ReadOnly = False
    End Sub

    Private Sub txtTimer_EditValueChanged(sender As Object, e As EventArgs) Handles txtTimer.EditValueChanged
        If IsNumeric(txtTimer.Text) Then
            Dim obj As New IT_AutoCopy
            obj.EmpID_K = txtEmpID.Text
            If _db.ExistObject(obj) Then
                _db.GetObject(obj)
            Else
                obj.EmpID_K = CurrentUser.UserID
                _db.Insert(obj)
                txtEmpID.Text = obj.EmpID_K
            End If
            obj.Timer = txtTimer.Text
            _db.Update(obj)
        End If
    End Sub
    Sub Copy()
        Dim fromF() = Directory.GetFiles(txtFrom.Text)
        For i = 0 To fromF.Length - 1
            fromF(i) = fromF(i).Substring(txtFrom.Text.Length + 1)
        Next
        Dim toF() = Directory.GetFiles(txtTo.Text)
        For i = 0 To toF.Length - 1
            toF(i) = toF(i).Substring(txtTo.Text.Length + 1)
        Next

        ProgressBarControl1.Properties.Step = 1
        ProgressBarControl1.Properties.PercentView = True
        ProgressBarControl1.Properties.Maximum = fromF.Length
        ProgressBarControl1.Properties.Minimum = 0
        ProgressBarControl1.Properties.ShowTitle = True
        For Each fileName As String In fromF
            If toF.Contains(fileName) = False Then
                Dim a As String = txtFrom.Text + "\" + fileName
                Dim b As String = txtTo.Text + "\" + fileName
                File.Copy(a, b, False)
                Dim dr As DataRow
                dr = dt.NewRow
                dr("File") = fileName
                dt.Rows.InsertAt(dr, 0)
            End If
            ProgressBarControl1.PerformStep()
            ProgressBarControl1.Update()
        Next fileName
        ProgressBarControl1.EditValue = 0

        If dt.Rows.Count > 0 Then
            GridControl1.DataSource = dt
            GridControlSetFormat(GridView1)
            GridView1.Columns("File").Width = 400
        End If
        dteLast.EditValue = dteNext.DateTime
        dteNext.EditValue = dteLast.DateTime.AddMinutes(txtTimer.Text)
    End Sub
End Class