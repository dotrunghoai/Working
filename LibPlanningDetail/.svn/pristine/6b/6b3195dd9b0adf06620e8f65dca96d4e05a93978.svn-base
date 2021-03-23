Imports CommonDB
Imports LibEntity
Imports PublicUtility

Public Class FrmProcessHour9785 : Inherits DevExpress.XtraEditors.XtraForm
	Private DB As DBSql
	Private _dbFPics As New DBSql(PublicConst.EnumServers.NDV_SQL_Fpics)
	Private bs As BindingSource
	Private _isUpdate As Boolean = False
	Private EnuActionForm As ActionForm = ActionForm.FormLoad

	Enum ActionForm
		None = 0
		FormLoad = 1
		Edit = 2
		Export = 3
		ShowAll = 4
		Delete = 5
	End Enum

	Private EditRight As Boolean = False
	Private ExportRight As Boolean = False
	Private ShowAllRight As Boolean = False
	Private DeleteRight As Boolean = False

	ReadOnly Property GetFormEvents As ActionForm
		Get
			Return EnuActionForm
		End Get
	End Property

	WriteOnly Property SetFormEvents As ActionForm
		Set(ByVal value As ActionForm)
			EnuActionForm = value
			Me.Cursor = Cursors.WaitCursor
			'Try
			Select Case value
				Case ActionForm.Edit
					GridControlReadOnly(GridView1, False)
					GridView1.Columns("ProductCode").OptionsColumn.ReadOnly = True
					GridView1.Columns("RevisionCode").OptionsColumn.ReadOnly = True
					GridView1.Columns("ProcessCode").OptionsColumn.ReadOnly = True
					GridView1.Columns("ProcessNumber").OptionsColumn.ReadOnly = True
					GridView1.Columns("ProcessName").OptionsColumn.ReadOnly = True
					GridView1.Columns("CustomerName").OptionsColumn.ReadOnly = True
					GridView1.Columns("Method").OptionsColumn.ReadOnly = True
					GridView1.Columns("CreateDate").OptionsColumn.ReadOnly = True
					GridView1.Columns("CreateUser").OptionsColumn.ReadOnly = True

					GridView1.Columns("Sheet").OptionsColumn.ReadOnly = True
					GridView1.Columns("LotSize").OptionsColumn.ReadOnly = True
					GridView1.Columns("LeadtimeTDG").OptionsColumn.ReadOnly = True
					GridView1.Columns("LeadtimeThietBi").OptionsColumn.ReadOnly = True
					GridControlSetColorEdit(GridView1)
				Case ActionForm.ShowAll, ActionForm.Delete
					LoadAll()
				Case ActionForm.FormLoad
					LoadCombox()
			End Select
			Me.Cursor = Cursors.Arrow
			'Catch ex As Exception
			'    Me.Cursor = Cursors.Arrow
			'    ShowError(ex, "SetFormEvents", Me.Name)
			'End Try
		End Set
	End Property

#Region "User Function"

	Private Sub LoadCombox()
		Dim sql As String = " Select distinct ProductCode from PD_ProcessHour9785 order by ProductCode"
		Dim tbl As DataTable = DB.FillDataTable(sql)
		cboProduct.ValueMember = "ProductCode"
		cboProduct.DisplayMember = "ProductCode"
		cboProduct.DataSource = tbl
	End Sub

	Private Sub LoadAll()
		If cboRC.Text.Trim = "" Then
			Return
		End If
		'Try
		Dim sProduct As String = cboProduct.Text.PadLeft(5, "0")
		Dim para(1) As SqlClient.SqlParameter
		para(0) = New SqlClient.SqlParameter("@ProductCode", sProduct)
		para(1) = New SqlClient.SqlParameter("@RevisionCode", cboRC.Text)

		Dim sql As String = String.Format("sp_PD_LoadProcessHour9785")
		Dim tbl As DataTable = DB.ExecuteStoreProcedureTB(sql, para)

		GridControl1.DataSource = tbl
		GridControlSetFormat(GridView1, 4)
		GridControlSetColorReadonly(GridView1)

		If cboRC.Text <> "01" Then
			para(0) = New SqlClient.SqlParameter("@ProductCode", sProduct)
			para(1) = New SqlClient.SqlParameter("@RevisionCode",
												 (CInt(cboRC.Text) - 1).ToString.PadLeft(2, "0"))
		Else
			para(0) = New SqlClient.SqlParameter("@ProductCode", sProduct)
			para(1) = New SqlClient.SqlParameter("@RevisionCode", "00")
		End If
		Dim tblOld As DataTable = DB.ExecuteStoreProcedureTB(sql, para)
		If tblOld.Rows.Count = 0 Then
			para(0) = New SqlClient.SqlParameter("@ProductCode", sProduct)
			para(1) = New SqlClient.SqlParameter("@RevisionCode",
												 (CInt(cboRC.Text) - 2).ToString.PadLeft(2, "0"))
			tblOld = DB.ExecuteStoreProcedureTB(sql, para)
		End If
		GridControl2.DataSource = tblOld
		GridControlSetFormat(GridView2, 4)


		'Catch ex As Exception
		'    Throw ex
		'End Try
	End Sub

#End Region

#Region "Form Function"

	Private Sub FrmProcessHour_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
		DB = New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
		SetFormEvents = ActionForm.FormLoad
	End Sub

	Private Sub FrmProcessHour_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		If e.KeyCode = Keys.F5 And mnuShowAll.Enabled Then
			mnuShowAll.PerformClick()
		End If
		If e.KeyCode = Keys.E And e.Control And mnuEdit.Enabled Then
			mnuEdit.PerformClick()
		End If
		If e.KeyCode = Keys.D And e.Control And mnuDelete.Enabled Then
			mnuDelete.PerformClick()
		End If
	End Sub

	Private Sub mnuShowAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuShowAll.Click
		SetFormEvents = ActionForm.ShowAll
		If GridView1.RowCount > 0 Then
			GridView1.Columns("ProductCode").Width = 40
			GridView1.Columns("RevisionCode").Width = 30
			GridView1.Columns("ProcessNumber").Width = 30
			GridView1.Columns("ProcessCode").Width = 40
			GridView2.Columns("ProcessName").Width = 40
			GridControlSetFormatNumber(GridView1, "Sheet,LotSize", 0)
			GridView1.Columns("Sheet").BestFit()
			GridView1.Columns("LotSize").BestFit()
			GridView1.Columns("TGGC").BestFit()
			GridView1.Columns("LeadtimeTDG").AppearanceHeader.BackColor = Color.Yellow
			GridView1.Columns("LeadtimePlanCD").AppearanceHeader.BackColor = Color.Yellow
			CheckLeadtimeCustomer()
		End If
		If GridView2.RowCount > 0 Then
			GridView2.Columns("ProductCode").Width = 40
			GridView2.Columns("RevisionCode").Width = 30
			GridView2.Columns("ProcessNumber").Width = 30
			GridView2.Columns("ProcessCode").Width = 40
			GridView2.Columns("ProcessName").Width = 40
			GridControlSetFormatNumber(GridView2, "Sheet,LotSize", 0)
			GridView2.Columns("Sheet").BestFit()
			GridView2.Columns("LotSize").BestFit()
			GridView1.Columns("TGGC").BestFit()

			GridView2.Columns("LeadtimeTDG").AppearanceHeader.BackColor = Color.Yellow
			GridView2.Columns("LeadtimePlanCD").AppearanceHeader.BackColor = Color.Yellow
		End If

	End Sub

	Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEdit.Click
		SetFormEvents = ActionForm.Edit
	End Sub

	Private Sub mnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExport.Click
		GridControlExportExcel(GridView1)
	End Sub

#End Region

	Private Sub SetValues(ByRef obj As PD_ProcessHour9785, ByVal rN As Integer)
		obj.ProductCode_K = GridView1.GetRowCellValue(rN, "ProductCode")
		obj.RevisionCode_K = GridView1.GetRowCellValue(rN, "RevisionCode")
		obj.ProcessNumber_K = GridView1.GetRowCellValue(rN, "ProcessNumber")
		obj.ProcessNumber_K = If(GridView1.GetRowCellValue(rN, "ProcessNumber") Is DBNull.Value, String.Empty, GridView1.GetRowCellValue(rN, "ProcessNumber"))
		obj.ProcessCode = If(GridView1.GetRowCellValue(rN, "ProcessCode") Is DBNull.Value, String.Empty, GridView1.GetRowCellValue(rN, "ProcessCode"))
		obj.ProcessName = If(GridView1.GetRowCellValue(rN, "ProcessName") Is DBNull.Value, String.Empty, GridView1.GetRowCellValue(rN, "ProcessName"))
		obj.LeadtimeThietBi = If(GridView1.GetRowCellValue(rN, "LeadtimeThietBi") Is DBNull.Value, 0, GridView1.GetRowCellValue(rN, "LeadtimeThietBi"))
		obj.LeadtimeSub = If(GridView1.GetRowCellValue(rN, "LeadtimeSub") Is DBNull.Value, 0, GridView1.GetRowCellValue(rN, "LeadtimeSub"))
		obj.LeadtimePlanCD = If(GridView1.GetRowCellValue(rN, "LeadtimePlanCD") Is DBNull.Value, 0, GridView1.GetRowCellValue(rN, "LeadtimePlanCD"))
		obj.Remark = If(GridView1.GetRowCellValue(rN, "Remark") Is DBNull.Value, "", GridView1.GetRowCellValue(rN, "Remark"))

		obj.Sheet = If(GridView1.GetRowCellValue(rN, "Sheet") Is DBNull.Value, 0, GridView1.GetRowCellValue(rN, "Sheet"))
		obj.Lotsize = If(GridView1.GetRowCellValue(rN, "Lotsize") Is DBNull.Value, 0, GridView1.GetRowCellValue(rN, "Lotsize"))
		obj.TGGC = If(GridView1.GetRowCellValue(rN, "TGGC") Is DBNull.Value, 0, GridView1.GetRowCellValue(rN, "TGGC"))
		obj.SLThietBi = If(GridView1.GetRowCellValue(rN, "SLThietBi") Is DBNull.Value, 0, GridView1.GetRowCellValue(rN, "SLThietBi"))
		obj.SLThietBiA = If(GridView1.GetRowCellValue(rN, "SLThietBiA") Is DBNull.Value, 0, GridView1.GetRowCellValue(rN, "SLThietBiA"))
		If GridView1.GetRowCellValue(rN, "IsAuto") IsNot DBNull.Value Then
			obj.IsAuto = GridView1.GetRowCellValue(rN, "IsAuto")
		Else
			obj.IsAuto = False
		End If
		If obj.SLThietBiA > 0 Then
			obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
		Else
			obj.LeadtimeTDG = 0
		End If
		If obj.SLThietBi > 0 Then
			obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
		Else
			obj.LeadtimeThietBi = 0
		End If
		GridView1.SetRowCellValue(rN, "LeadtimeTDG", obj.LeadtimeTDG)
		GridView1.SetRowCellValue(rN, "LeadtimeThietBi", obj.LeadtimeThietBi)
	End Sub

	Private Sub SetValues(ByRef obj As PD_ProcessHour9785, ByVal r As DataRow)
		obj.ProductCode_K = r("Product Code").ToString().PadLeft(5, "0")
		obj.ProcessNumber_K = r("Process Number").ToString().PadLeft(2, "0")
		obj.RevisionCode_K = r("Revision Code")
		obj.ProcessCode = If(r("Process Code") Is DBNull.Value, String.Empty, r("Process Code"))
		obj.ProcessName = If(r("Process Name") Is DBNull.Value, String.Empty, r("Process Name"))
		obj.LeadtimeThietBi = If(r("Leadtime Thiet Bi") Is DBNull.Value, 0, r("Leadtime Thiet Bi"))
		obj.LeadtimeSub = If(r("Leadtime Sub") Is DBNull.Value, 0, r("Leadtime Sub"))
		obj.LeadtimePlanCD = If(r("Leadtime Plan CD") Is DBNull.Value, 0, r("Leadtime Plan CD"))
		obj.Remark = If(r("Remark") Is DBNull.Value, 0, r("Remark"))

		obj.Sheet = If(r("Sheet") Is DBNull.Value, 0, r("Sheet"))
		obj.Lotsize = If(r("Lot size") Is DBNull.Value, 0, r("Lot size"))
		obj.TGGC = If(r("TGGC") Is DBNull.Value, 0, r("TGGC"))
		obj.SLThietBi = If(r("SL Thiet Bi") Is DBNull.Value, 0, r("SL Thiet Bi"))
		obj.SLThietBiA = If(r("SL Thiet Bi A") Is DBNull.Value, 0, r("SL Thiet Bi A"))
		If obj.SLThietBiA > 0 Then
			obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
		End If
		If obj.SLThietBi > 0 Then
			obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
		End If
	End Sub

	Private Sub mnuImport_Click(sender As System.Object, e As System.EventArgs) Handles mnuImport.Click
		Try
			If cboProduct.Text = String.Empty Then
				ShowWarning("Bạn phải chọn product trước !")
				cboProduct.Focus()
				Exit Sub
			End If
			Dim tbl As DataTable = ImportEXCEL("import")
			If _
				tbl.Rows.Count = 0 Then
				ShowWarning("Không có dữ liệu để import !")
				Exit Sub
			End If
			Me.Cursor = Cursors.WaitCursor
			DB.BeginTransaction()

			Dim objGC As New CL_TGGC_RoiSang
			objGC.ID_K = "0008"
			objGC.ProductCode_K = cboProduct.Text
			DB.GetObject(objGC)
			Dim stt As Integer = 0

			For Each r As DataRow In tbl.Rows
				Dim sProcessNumber As String = If(r("Process Number") Is DBNull.Value,
						String.Empty, r("Process Number"))
				If sProcessNumber = String.Empty Then Continue For
				Dim obj As New PD_ProcessHour9785
				obj.ProductCode_K = r("Product Code").ToString().PadLeft(5, "0")
				obj.ProcessNumber_K = r("Process Number").ToString().PadLeft(2, "0")
				obj.RevisionCode_K = r("Revision Code")
				DB.GetObject(obj)
				obj.CreateDate = DateTime.Now
				obj.CreateUser = CurrentUser.UserID
				If obj.ProcessNumber_K Is Nothing Then
					Me.SetValues(obj, r)

					If obj.ProcessCode = "9052" And objGC.INS1 > 0 Then
						obj.TGGC = objGC.INS1 / 60
						obj.SLThietBi = 20
						obj.SLThietBiA = 20
						If obj.SLThietBiA > 0 Then
							obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
						Else
							obj.LeadtimeTDG = 0
						End If
						If obj.SLThietBi > 0 Then
							obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
						Else
							obj.LeadtimeThietBi = 0
						End If
					ElseIf obj.ProcessCode = "9056" And objGC.INS2 > 0 Then
						obj.TGGC = objGC.INS2 / 60
						obj.SLThietBi = 20
						obj.SLThietBiA = 20
						If obj.SLThietBiA > 0 Then
							obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
						Else
							obj.LeadtimeTDG = 0
						End If
						If obj.SLThietBi > 0 Then
							obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
						Else
							obj.LeadtimeThietBi = 0
						End If
					ElseIf obj.ProcessCode = "9051" And objGC.OUTGOING > 0 Then
						obj.TGGC = objGC.OUTGOING / 60
						obj.SLThietBi = 20
						obj.SLThietBiA = 20
						If obj.SLThietBiA > 0 Then
							obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
						Else
							obj.LeadtimeTDG = 0
						End If
						If obj.SLThietBi > 0 Then
							obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
						Else
							obj.LeadtimeThietBi = 0
						End If
					End If
					DB.Insert(obj)
				Else
					Me.SetValues(obj, r)

					If obj.ProcessCode = "9052" And objGC.INS1 > 0 Then
						obj.TGGC = objGC.INS1 / 60
						obj.SLThietBi = 20
						obj.SLThietBiA = 20
						If obj.SLThietBiA > 0 Then
							obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
						Else
							obj.LeadtimeTDG = 0
						End If
						If obj.SLThietBi > 0 Then
							obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
						Else
							obj.LeadtimeThietBi = 0
						End If
					ElseIf obj.ProcessCode = "9056" And objGC.INS2 > 0 Then
						obj.TGGC = objGC.INS2 / 60
						obj.SLThietBi = 20
						obj.SLThietBiA = 20
						If obj.SLThietBiA > 0 Then
							obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
						Else
							obj.LeadtimeTDG = 0
						End If
						If obj.SLThietBi > 0 Then
							obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
						Else
							obj.LeadtimeThietBi = 0
						End If
					ElseIf obj.ProcessCode = "9051" And objGC.OUTGOING > 0 Then
						obj.TGGC = objGC.OUTGOING / 60
						obj.SLThietBi = 20
						obj.SLThietBiA = 20
						If obj.SLThietBiA > 0 Then
							obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
						Else
							obj.LeadtimeTDG = 0
						End If
						If obj.SLThietBi > 0 Then
							obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
						Else
							obj.LeadtimeThietBi = 0
						End If
					End If
					DB.Update(obj)
				End If
				stt += 1
			Next
			DB.Commit()
			Me.Cursor = Cursors.Arrow
			ShowSuccess("Import dữ liệu thành công")

		Catch ex As Exception
			DB.RollBack()
			Me.Cursor = Cursors.Arrow
			ShowError(ex, mnuImport.Text, Me.Name)
		End Try
	End Sub

	Private Sub cboProduct_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles cboProduct.SelectedValueChanged
		mnuShowAll.PerformClick()
	End Sub

	Private Sub mnuProduct_Click(sender As System.Object, e As System.EventArgs)
		Dim frm As New FrmDSProduct
		If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
			LoadCombox()
		End If
	End Sub

	Private Sub mnuDelete_Click(sender As System.Object, e As System.EventArgs) Handles mnuDelete.Click

		If String.IsNullOrEmpty(cboProduct.Text) Then
			MessageBox.Show("Bạn chưa chọn product", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
			cboProduct.Focus()
			Exit Sub
		End If

		If GridView1.SelectedRowsCount = 0 Then Exit Sub

		If ShowQuestionDelete() = DialogResult.No Then Exit Sub

		DB.BeginTransaction()

		Try
			For Each r As Integer In GridView1.GetSelectedRows
				Dim obj As New PD_ProcessHour9785
				obj.ProductCode_K = GridView1.GetRowCellValue(r, "ProductCode")
				obj.ProcessNumber_K = GridView1.GetRowCellValue(r, "ProcessNumber")
				obj.RevisionCode_K = GridView1.GetRowCellValue(r, "RevisionCode")
				DB.Delete(obj)
			Next
			DB.Commit()
			SetFormEvents = ActionForm.Delete
		Catch ex As Exception
			DB.RollBack()
			ShowError(ex, mnuDelete.Text, Me.Name)
		End Try
	End Sub

	Private Sub cboProduct_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboProduct.SelectedIndexChanged
		If cboProduct.Text <> "" And cboProduct.SelectedIndex >= 0 Then
			LoadRC()
		End If
	End Sub

	Private Sub mnuGetData_Click(sender As System.Object, e As System.EventArgs)
		Dim sql As String = String.Format("Select  cp.[ProductCode]" +
										"  , cp.[RevisionCode] " +
										"  , cp.[ProcessNumber]" +
										"  , cp.[ProcessCode] " +
										"  , p.ProcessNameE As ProcessName" +
										"  , cast(null As Decimal(18, 2)) As Leadtime" +
										"  ,cast(null As Decimal(18,2)) As LeadtimeSub" +
										"  ,cast(null As Decimal(18,2)) As Leadtime2" +
										"  ,cast(null As Decimal(18,2)) As Remark" +
										"  ,cast(null As Decimal(18,2)) As CreateUser" +
										"  ,cast(null As Decimal(18,2)) As CreateDate" +
										" FROM [m_ComponentProcess] cp" +
										" left join m_Process p" +
										" On cp.ProcessCode= p.ProcessCode" +
										" where ProductCode='{0}' and ComponentCode='B00' and RevisionCode='{1}'" +
										" order by cp.ProcessNumber ",
										cboProduct.Text,
										cboRC.Text)

		Dim para(1) As SqlClient.SqlParameter
		para(0) = New SqlClient.SqlParameter("@ProductCode", cboProduct.Text.PadLeft(5, "0"))
		para(1) = New SqlClient.SqlParameter("@RevisionCode", cboRC.Text)
		Dim tbl As DataTable = DB.ExecuteStoreProcedureTB("sp_PD_GetFPICSProcessHourNew", para)
		GridControl1.DataSource = tbl
		GridControlSetFormat(GridView1, 4)
	End Sub

	Private Sub cboProduct_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboProduct.KeyDown
		If e.KeyCode = Keys.Enter Then
			LoadRC()
		End If
	End Sub

	Sub LoadRC()
		Dim sql As String = String.Format("  SELECT  [RevisionCode] " +
											" FROM  [m_Product]" +
											" where ProductCode='{0}' and CompleteFlag='T'" +
											" order by [RevisionCode] desc",
											cboProduct.Text)
		cboRC.DataSource = _dbFPics.FillDataTable(sql)
		cboRC.ValueMember = "RevisionCode"
		cboRC.DisplayMember = "RevisionCode"
	End Sub


	Sub CheckLeadtimeCustomer()
		'Dim ltimeThietBi As Decimal = GridView1.Columns("LeadtimeThietBi").SummaryItem.SummaryValue
		'Dim ltimePlanCD As Decimal = GridView1.Columns("LeadtimePlanCD").SummaryItem.SummaryValue
		'If ltimeThietBi > 0 Then
		'	ltimeThietBi = ltimeThietBi / 24
		'End If
		'If ltimePlanCD > 0 Then
		'	ltimePlanCD = ltimePlanCD / 24
		'End If
		'Dim obj As New FPICS_LeadtimeCustomer
		'obj.CustomerName_K = GridView1.GetFocusedRowCellValue("CustomerName")
		'obj.Layer_K = GridView1.GetFocusedRowCellValue("Method")
		'DB.GetObject(obj)
		'txtLeadtimeStd.Text = obj.LTEnd
		'If obj.LTEnd > 0 Then
		'	If obj.LTEnd < ltimeThietBi Or obj.LTEnd < ltimePlanCD Then
		'		ShowWarning(String.Format("Leadtime đang vượt chuẩn {0} ! Vui lòng kiểm tra lại.", obj.LTEnd))
		'	End If
		'End If
	End Sub

	Private Sub cboRC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRC.SelectedIndexChanged
		If cboRC.ValueMember <> "" And cboRC.DisplayMember <> "" And cboRC.SelectedIndex >= 0 Then
			mnuShowAll.PerformClick()
		End If
	End Sub

	Private Sub ckoCompare_CheckedChanged(sender As Object, e As EventArgs) Handles ckoCompare.CheckedChanged
		If ckoCompare.Checked Then
			ctn.Panel2Collapsed = False
		Else
			ctn.Panel2Collapsed = True
		End If
	End Sub

	Private Sub mnuUpdateOld_Click(sender As Object, e As EventArgs)

		If ShowQuestion("Bán muốn cập nhật Leadtime từ RC cũ sang mới ?") = DialogResult.No Then
			Return
		End If

		mnuEdit.PerformClick()
		_isUpdate = True

		Dim objGC As New CL_TGGC_RoiSang
		objGC.ID_K = "0008"
		objGC.ProductCode_K = cboProduct.Text
		DB.GetObject(objGC)

		Dim mySTT As Integer = 0
		For rN As Integer = 0 To GridView1.RowCount - 1
			For rO As Integer = mySTT To GridView2.RowCount - 1
				'mySTT = rO
				If GridView1.GetRowCellValue(rN, "ProcessCode") = GridView2.GetRowCellValue(rO, "ProcessCode") Then

					GridView1.SetRowCellValue(rN, "TGGC", GridView2.GetRowCellValue(rO, "TGGC"))
					GridView1.SetRowCellValue(rN, "SLThietBi", GridView2.GetRowCellValue(rO, "SLThietBi"))
					GridView1.SetRowCellValue(rN, "SLThietBiA", GridView2.GetRowCellValue(rO, "SLThietBiAO"))
					GridView1.SetRowCellValue(rN, "LeadtimeTDG", GridView2.GetRowCellValue(rO, "LeadtimeTDG"))
					GridView1.SetRowCellValue(rN, "LeadtimeThietBi", GridView2.GetRowCellValue(rO, "LeadtimeThietBi"))
					GridView1.SetRowCellValue(rN, "LeadtimePlanCD", GridView2.GetRowCellValue(rO, "LeadtimePlanCD"))
					GridView1.SetRowCellValue(rN, "LeadtimeSub", GridView2.GetRowCellValue(rO, "LeadtimeSub"))

					Dim obj As New PD_ProcessHour9785

					obj.ProductCode_K = GridView1.GetRowCellValue(rN, "ProductCode")
					obj.RevisionCode_K = GridView1.GetRowCellValue(rN, "RevisionCode")
					obj.ProcessNumber_K = GridView1.GetRowCellValue(rN, "ProcessNumber")

					DB.GetObject(obj)


					If obj.ProcessNumber_K Is Nothing Then
						SetValues(obj, rN)
						If obj.ProcessCode = "9052" And objGC.INS1 > 0 Then
							obj.TGGC = objGC.INS1 / 60
							obj.SLThietBi = 20
							obj.SLThietBiA = 20
							If obj.SLThietBiA > 0 Then
								obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
							Else
								obj.LeadtimeTDG = 0
							End If
							If obj.SLThietBi > 0 Then
								obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
							Else
								obj.LeadtimeThietBi = 0
							End If
						ElseIf obj.ProcessCode = "9056" And objGC.INS2 > 0 Then
							obj.TGGC = objGC.INS2 / 60
							obj.SLThietBi = 20
							obj.SLThietBiA = 20
							If obj.SLThietBiA > 0 Then
								obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
							Else
								obj.LeadtimeTDG = 0
							End If
							If obj.SLThietBi > 0 Then
								obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
							Else
								obj.LeadtimeThietBi = 0
							End If
						ElseIf obj.ProcessCode = "9051" And objGC.OUTGOING > 0 Then
							obj.TGGC = objGC.OUTGOING / 60
							obj.SLThietBi = 20
							obj.SLThietBiA = 20
							If obj.SLThietBiA > 0 Then
								obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
							Else
								obj.LeadtimeTDG = 0
							End If
							If obj.SLThietBi > 0 Then
								obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
							Else
								obj.LeadtimeThietBi = 0
							End If
						End If
						obj.CreateUser = CurrentUser.UserID
						obj.CreateDate = DateTime.Now
						DB.Insert(obj)
					Else
						SetValues(obj, rN)
						If obj.ProcessCode = "9052" And objGC.INS1 > 0 Then
							obj.TGGC = objGC.INS1 / 60
							obj.SLThietBi = 20
							obj.SLThietBiA = 20
							If obj.SLThietBiA > 0 Then
								obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
							Else
								obj.LeadtimeTDG = 0
							End If
							If obj.SLThietBi > 0 Then
								obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
							Else
								obj.LeadtimeThietBi = 0
							End If
						ElseIf obj.ProcessCode = "9056" And objGC.INS2 > 0 Then
							obj.TGGC = objGC.INS2 / 60
							obj.SLThietBi = 20
							obj.SLThietBiA = 20
							If obj.SLThietBiA > 0 Then
								obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
							Else
								obj.LeadtimeTDG = 0
							End If
							If obj.SLThietBi > 0 Then
								obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
							Else
								obj.LeadtimeThietBi = 0
							End If
						ElseIf obj.ProcessCode = "9051" And objGC.OUTGOING > 0 Then
							obj.TGGC = objGC.OUTGOING / 60
							obj.SLThietBi = 20
							obj.SLThietBiA = 20
							If obj.SLThietBiA > 0 Then
								obj.LeadtimeTDG = obj.TGGC / obj.SLThietBiA
							Else
								obj.LeadtimeTDG = 0
							End If
							If obj.SLThietBi > 0 Then
								obj.LeadtimeThietBi = obj.TGGC / obj.SLThietBi
							Else
								obj.LeadtimeThietBi = 0
							End If
						End If
						DB.Update(obj)
					End If

					Exit For
				End If
			Next
		Next
	End Sub

	Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
		Try
			If GridView1.Editable And e.Column.ReadOnly = False Then
				Dim obj As New PD_ProcessHour9785

				obj.ProductCode_K = GridView1.GetRowCellValue(e.RowHandle, "ProductCode")
				obj.RevisionCode_K = GridView1.GetRowCellValue(e.RowHandle, "RevisionCode")
				obj.ProcessNumber_K = GridView1.GetRowCellValue(e.RowHandle, "ProcessNumber")

				DB.GetObject(obj)

				If obj.ProcessNumber_K Is Nothing Then
					SetValues(obj, e.RowHandle)
					obj.CreateUser = CurrentUser.UserID
					obj.CreateDate = DateTime.Now
					DB.Insert(obj)
				Else
					SetValues(obj, e.RowHandle)
					DB.Update(obj)
				End If
			End If
		Catch ex As Exception
			ShowError(ex, "gridProcessHour_CellValueChanged", Me.Name)
		End Try
	End Sub

	Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
		If e.Column.FieldName = "SLThietBiA" Then
			If GridView1.GetRowCellValue(e.RowHandle, "IsAuto") IsNot DBNull.Value Then
				If GridView1.GetRowCellValue(e.RowHandle, "IsAuto") = True Then
					e.Appearance.BackColor = Color.Yellow
				End If
			End If
		End If
	End Sub

	Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
		GridControlSum(GridView1, txtSum)
	End Sub
	Private Sub GridView2_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView2.SelectionChanged
		GridControlSum(GridView2, txtSum)
	End Sub
End Class