﻿Imports CommonDB
Imports PublicUtility

Public Class FrmFCB00 : Inherits DevExpress.XtraEditors.XtraForm
	Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

	Private Sub FrmFCB00_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		dteStartDate.EditValue = Date.Now.AddDays(-15)
		dteEndDate.EditValue = Date.Parse(dteStartDate.EditValue).AddMonths(9)
	End Sub

	Private Sub dteStartDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteStartDate.EditValueChanged
		If dteStartDate.EditValue > dteEndDate.EditValue Then
			dteEndDate.EditValue = dteStartDate.EditValue
		End If
	End Sub

	Private Sub dteEndDate_EditValueChanged(sender As Object, e As EventArgs) Handles dteEndDate.EditValueChanged
		If dteEndDate.EditValue < dteStartDate.EditValue Then
			dteStartDate.EditValue = dteEndDate.EditValue
		End If
	End Sub

	Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
		GridView1.Columns.Clear()
		Dim para(1) As SqlClient.SqlParameter
		para(0) = New SqlClient.SqlParameter("@StartDate", dteStartDate.EditValue)
		para(1) = New SqlClient.SqlParameter("@EndDate", dteEndDate.EditValue)
		GridControl1.DataSource = _db.ExecuteStoreProcedureTB("sp_PLM_LoadFCBoo", para)
		GridControlSetFormat(GridView1)
		GridView1.BestFitColumns()
	End Sub

	Private Sub btnImport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnImport.ItemClick
		Dim dt As DataTable = ImportEXCEL(True)
		If dt.Rows.Count > 0 Then
			Dim row As Integer = 0
			Dim notBom As Integer = 0
			Try
				Dim dtNotBomExcel As New DataTable
				dtNotBomExcel.Columns.Add("Product Code")

				_db.BeginTransaction()
				Dim tImport = "W" + Date.Parse(dt.Columns(dt.Columns.IndexOf("Balance PO") + 1).ColumnName).ToString("yyyyMMdd")
				Dim succ As Integer = 0
				For Each r As DataRow In dt.Rows
					row += 1
					If IsDBNull(r("Product Code")) Then Continue For
					'Insert FC_BOO
					Dim obj As New PLM_FC_BOO
					obj.TuanImport_K = tImport
					obj.ProductCode_K = r("Product Code")

					'Kiểm tra đăng lục BOM
					Dim dtNotBom = _db.FillDataTable(String.Format("SELECT TOP 1 Std_PdCode
																    FROM BOMSTD_A1StdBOM
																    WHERE Std_PdCode = '{0}'",
																	obj.ProductCode_K))
					If dtNotBom.Rows.Count = 0 Then
						dtNotBomExcel.Rows.Add(obj.ProductCode_K)
						notBom += 1
					End If

					obj.Location_K = r("Location")
					obj.EOL = IIf(IsDBNull(r("EOL")), "", r("EOL"))
					obj.OutstandingPO = r("Outstanding PO")
					obj.BalancePO = r("Balance PO")
					For Each c As DataColumn In dt.Columns
						If dt.Columns.IndexOf(c.ColumnName) > dt.Columns.IndexOf("Balance PO") Then
							If Not IsDate(c.ColumnName) Then
								c.ColumnName = DateTime.FromOADate(c.ColumnName)
							End If
							obj.Tuan_K = c.ColumnName
							obj.Qty = r(c)
							obj.CreateDate = DateTime.Now.Date
							obj.CreateUser = CurrentUser.UserID
							If _db.ExistObject(obj) Then
								_db.Update(obj)
							Else
								_db.Insert(obj)
								succ += 1
							End If
						End If
					Next

					'Insert BomB0
					_db.ExecuteNonQuery(String.Format("	INSERT INTO PLM_Bom_B0 (TuanImport, Std_PdCode, Std_Rc, Std_Cc, Std_Pn, Std_MatCode, Std_PrcCode, Std_StdQtyP, Adjust)
														SELECT h.TuanImport, h.Std_PdCode, h.Std_Rc, h.Std_Cc, h.Std_Pn, h.Std_MatCode, h.Std_PrcCode, h.Std_StdQtyP, h.Std_StdQtyP AS Adjust
														FROM (
															SELECT '{0}' AS TuanImport, h.Std_PdCode, h.Std_Rc, h.Std_Cc, h.Std_Pn, h.Std_MatCode, h.Std_PrcCode, h.Std_StdQtyP
															FROM BOMSTD_A1StdBOM AS h
															INNER JOIN (
																SELECT Std_PdCode, MAX(Std_Rc) AS Std_Rc
																FROM BOMSTD_A1StdBOM
																WHERE Std_PdCode = '{1}'
																GROUP BY Std_PdCode
															) AS m
															ON h.Std_PdCode = m.Std_PdCode
															AND h.Std_Rc = m.Std_Rc
														) AS h
														LEFT JOIN (
															SELECT TuanImport, Std_PdCode 
															FROM PLM_Bom_B0
															GROUP BY TuanImport, Std_PdCode
														) AS g
														ON h.TuanImport = g.TuanImport
														AND h.Std_PdCode = g.Std_PdCode
														LEFT JOIN PLM_Bom_B0 AS d
														ON  h.TuanImport = d.TuanImport
														AND h.Std_PdCode = d.Std_PdCode
														AND h.Std_Rc = d.Std_Rc
														AND h.Std_Cc = d.Std_Cc
														AND h.Std_Pn = d.Std_Pn
														AND h.Std_MatCode = d.Std_MatCode
														WHERE g.TuanImport IS NULL
														AND d.Std_PdCode IS NULL",
														tImport,
														r("Product Code")))
				Next
				_db.Commit()
				ShowSuccess(succ)
				If notBom <> 0 Then
					ShowWarning(String.Format("Có {0} Bom chưa đăng lục", notBom))
					ExportEXCEL(dtNotBomExcel)
				End If
			Catch ex As Exception
				_db.RollBack()
				ShowWarning(ex.Message + " - Row " + row.ToString)
			End Try
		Else
			ShowWarning("Không có dữ liệu import !")
		End If
	End Sub

	Private Sub btnExport_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnExport.ItemClick
		GridControlExportExcel(GridView1)
	End Sub
End Class