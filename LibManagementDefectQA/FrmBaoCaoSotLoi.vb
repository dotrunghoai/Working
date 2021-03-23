
Imports CommonDB
Imports LibEntity
Imports PublicUtility
Imports System.Windows.Forms


Public Class FrmBaoCaoSotLoi : Inherits DevExpress.XtraEditors.XtraForm
    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim Loai As String = ""
    Dim tb_Head As String = "MDQA_KTPL"
    Dim tb_Detail As String = "MDQA_KTPL_Detail"


    Sub LoadDetail()
        Dim condition As String = " 1=1 " 
        If txtPdCode.Text <> "" Then
            condition += String.Format(" and ProductCode='{0}' ", txtPdCode.Text.PadLeft(5, "0"))
        End If
        If txtLotNo.Text <> "" Then
            condition += String.Format(" and LotNo='{0}' ", txtLotNo.Text)
        End If
        If cboCustomer.Text <> "" And cboCustomer.Text <> "All" Then
            condition += String.Format(" and Customer='{0}' ", cboCustomer.Text)
        End If
        If bdnH.BindingSource.Filter <> "" Then
            condition += String.Format(" and {0} ", bdnH.BindingSource.Filter)
        End If
        Dim sql As String = String.Format("SELECT  d.DefectCode as MaLoi,c.DefectNameE as TenLoi,sum(d.[DefectQty]) as SL " +
                                                     " FROM  [{1}] h" +
                                                     " inner join [dbo].[{2}] d" +
                                                     " on h.ID=d.id" +
                                                     " inner join MDQA_DefectCode c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate and LoaiHang='{3}' and {0} " +
                                                     " group by d.DefectCode,c.DefectNameE ", condition, tb_Head, tb_Detail, Loai)
        If Loai = "" Then
            sql = String.Format("SELECT  d.DefectCode as MaLoi,c.DefectNameE as TenLoi,sum(d.[DefectQty]) as SL " +
                                                     " FROM  [{1}] h" +
                                                     " inner join [dbo].[{2}] d" +
                                                     " on h.ID=d.id" +
                                                     " inner join MDQA_DefectCode c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate and {0} " +
                                                     " group by d.DefectCode,c.DefectNameE ", condition, tb_Head, tb_Detail)
        ElseIf Loai = "HANG-THUONG" Then
            sql = String.Format("SELECT  d.DefectCode as MaLoi,c.DefectNameE as TenLoi,sum(d.[DefectQty]) as SL " +
                                                     " FROM  [{1}] h" +
                                                     " inner join [dbo].[{2}] d" +
                                                     " on h.ID=d.id" +
                                                     " inner join MDQA_DefectCode c" +
                                                     " on c.DefectCode=d.DefectCode" +
                                                     " where Ngay between @StartDate and @EndDate and ( LoaiHang='{3}' or LoaiHang='TACH-LO' ) and {0} " +
                                                     " group by d.DefectCode,c.DefectNameE ",
                                                     condition, tb_Head, tb_Detail, Loai)
        End If
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetStartDate(dtpEnd.Value))
        Dim bd As New BindingSource
        bd.DataSource = _db.FillDataTable(sql, para)
        bdnD.BindingSource = bd
        gridD.DataSource = bd

        txtQtyMode.Text = CType(bd.DataSource, DataTable).Compute("sum(SL)", "")
    End Sub

    Sub LoadDetailS() 
        Dim condition As String = " 1=1 "
        If txtPdCode.Text <> "" Then
            condition += String.Format(" and ProductCode='{0}' ", txtPdCode.Text.PadLeft(5, "0"))
        End If
        If txtLotNo.Text <> "" Then
            condition += String.Format(" and LotNo='{0}' ", txtLotNo.Text)
        End If
        If cboCustomer.Text <> "" And cboCustomer.Text <> "All" Then
            condition += String.Format(" and Customer='{0}' ", cboCustomer.Text)
        End If
        If bdnH.BindingSource.Filter <> "" Then
            condition += String.Format(" and {0} ", bdnH.BindingSource.Filter)
        End If
        Dim sql As String = String.Format("SELECT  d.[EmpID] ,sum(d.SL) as AQLS,sum(d.[DefectQty]) as QtyS,sum(d.ThoiGian) as ThoiGian " +
                                                     " FROM  [{1}] h" +
                                                     " inner join [dbo].[{2}] d" +
                                                     " on h.ID=d.id" +
                                                     " where Ngay between @StartDate and @EndDate and LoaiHang='{3}' and {0} " +
                                                     " group by d.EmpID ", condition, tb_Head, tb_Detail, Loai)

        If Loai = "" Then
            sql = String.Format("SELECT  d.[EmpID] ,sum(d.SL) as AQLS,sum(d.[DefectQty]) as QtyS,sum(d.ThoiGian) as ThoiGian " +
                                                     " FROM  [{1}] h" +
                                                     " inner join [dbo].[{2}] d" +
                                                     " on h.ID=d.id" +
                                                     " where Ngay between @StartDate and @EndDate  and {0} " +
                                                     " group by d.EmpID ", condition, tb_Head, tb_Detail)
        ElseIf Loai = "HANG-THUONG" Then
            sql = String.Format("SELECT  d.[EmpID] ,sum(d.SL) as AQLS,sum(d.[DefectQty]) as QtyS,sum(d.ThoiGian) as ThoiGian " +
                                                     " FROM  [{1}] h" +
                                                     " inner join [dbo].[{2}] d" +
                                                     " on h.ID=d.id" +
                                                     " where Ngay between @StartDate and @EndDate and (LoaiHang='{3}' or LoaiHang='TACH-LO') and {0} " +
                                                     " group by d.EmpID ", condition, tb_Head, tb_Detail, Loai)
        End If
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetStartDate(dtpEnd.Value))
        Dim bd As New BindingSource
        bd.DataSource = _db.FillDataTable(sql, para)
        bdnN.BindingSource = bd
        gridS.DataSource = bd

        txtQTyEmp.Text = CType(bd.DataSource, DataTable).Compute("sum(QtyS)", "")
    End Sub

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim condition As String = " 1=1 "
        If rdoThuNghiem.Checked Then
            Loai = "THU-NGHIEM"
        ElseIf rdoKiemLai.Checked Then
            Loai = "KIEM-LAI" 
        ElseIf rdoHangThuong.Checked Then
            Loai = "HANG-THUONG"
        Else
            Loai = ""
        End If
        If rdoKT1.Checked Then
            tb_Head = "MDQA_KT1"
            tb_Detail = "MDQA_KT1_Detail" 
        Else
            tb_Head = "MDQA_KTPL"
            tb_Detail = "MDQA_KTPL_Detail"
        End If

        If txtPdCode.Text <> "" Then
            condition += String.Format(" and ProductCode='{0}' ", txtPdCode.Text)
        End If

        If txtLotNo.Text <> "" Then
            condition += String.Format(" and LotNo='{0}' ", txtLotNo.Text)
        End If

        If cboCustomer.Text <> "" And cboCustomer.Text <> "All" Then
            condition += String.Format(" and Customer='{0}' ", cboCustomer.Text)
        End If

        Dim sql As String = String.Format(" select [Ngay] " +
                                         " ,[Customer]" +
                                         " ,[ProductCode]" +
                                         " ,[ProductName]" +
                                         " ,[LotNo]" +
                                         " ,[SoTrang]" +
                                         " ,[Nhom]" +
                                         " ,[Phong]" +
                                         " ,[LotQty]" +
                                         " ,[AQL]" +
                                         " ,[FPC]" +
                                         " ,[NgayEntek]" +
                                         " ,[Evaluate]" +
                                         " ,EmpID" +
                                         " ,SL as AQLD" +
                                         " ,DefectCode" +
                                         " ,DefectQty as Qty " +
                                         " ,[LoaiHang]" +
                                         " ,[ThoiGianRM]" +
                                         " ,[HangSSI]" +
                                         " ,[CuDiemXuat]" +
                                         " ,[GhiChu]" +
                                         " ,[BaoCao] from {1} h left join {2} d on d.ID=h.ID " +
                                         " where Ngay between @StartDate and @EndDate and LoaiHang='{3}' and {0}",
                                         condition, tb_Head, tb_Detail, Loai)
        If Loai = "" Then
            sql = String.Format(" select [Ngay] " +
                                         " ,[Customer]" +
                                         " ,[ProductCode]" +
                                         " ,[ProductName]" +
                                         " ,[LotNo]" +
                                         " ,[SoTrang]" +
                                         " ,[Nhom]" +
                                         " ,[Phong]" +
                                         " ,[LotQty]" +
                                         " ,[AQL]" +
                                         " ,[FPC]" +
                                         " ,[NgayEntek]" +
                                         " ,[Evaluate]" +
                                         " ,EmpID" +
                                         " ,SL as AQLD" +
                                         " ,DefectCode" +
                                         " ,DefectQty as Qty " +
                                         " ,[LoaiHang]" +
                                         " ,[ThoiGianRM]" +
                                         " ,[HangSSI]" +
                                         " ,[CuDiemXuat]" +
                                         " ,[GhiChu]" +
                                         " ,[BaoCao] from {1} h left join {2} d on d.ID=h.ID " +
                                         " where Ngay between @StartDate and @EndDate  and {0}",
                                         condition, tb_Head, tb_Detail)
        ElseIf Loai = "HANG-THUONG" Then
            sql = String.Format(" select [Ngay] " +
                                         " ,[Customer]" +
                                         " ,[ProductCode]" +
                                         " ,[ProductName]" +
                                         " ,[LotNo]" +
                                         " ,[SoTrang]" +
                                         " ,[Nhom]" +
                                         " ,[Phong]" +
                                         " ,[LotQty]" +
                                         " ,[AQL]" +
                                         " ,[FPC]" +
                                         " ,[NgayEntek]" +
                                         " ,[Evaluate]" +
                                         " ,EmpID" +
                                         " ,SL as AQLD" +
                                         " ,DefectCode" +
                                         " ,DefectQty as Qty " +
                                         " ,[LoaiHang]" +
                                         " ,[ThoiGianRM]" +
                                         " ,[HangSSI]" +
                                         " ,[CuDiemXuat]" +
                                         " ,[GhiChu]" +
                                         " ,[BaoCao] from {1} h left join {2} d on d.ID=h.ID " +
                                         " where Ngay between @StartDate and @EndDate and (LoaiHang='{3}' or LoaiHang='TACH-LO' ) and {0}",
                                         condition, tb_Head, tb_Detail, Loai)

        End If

        If rdoKT1.Checked Then
            sql = String.Format(" select [Ngay] " +
                                         " ,[Customer]" +
                                         " ,[ProductCode]" +
                                         " ,[ProductName]" +
                                         " ,[LotNo]" +
                                         " ,[SoTrang]" +
                                         " ,[Phong]" +
                                         " ,[LotQty]" +
                                         " ,[AQL]" +
                                         " ,'' as [FPC]" +
                                         " ,null as [NgayEntek]" +
                                         " ,[Evaluate]" +
                                         " ,EmpID" +
                                         " ,SL as AQLD" +
                                         " ,DefectCode" +
                                         " ,DefectQty as Qty " +
                                         " ,[LoaiHang]" +
                                         " ,[ThoiGianRM]" +
                                         " ,'' as [HangSSI]" +
                                         " ,'' as [CuDiemXuat]" +
                                         " ,[GhiChu]" +
                                         " ,[BaoCao] from {1} h left join {2} d on d.ID=h.ID " +
                                         " where Ngay between @StartDate and @EndDate and LoaiHang='{3}' and {0}",
                                         condition, tb_Head, tb_Detail, Loai)
            If Loai = "" Then
                sql = String.Format(" select [Ngay] " +
                                         " ,[Customer]" +
                                         " ,[ProductCode]" +
                                         " ,[ProductName]" +
                                         " ,[LotNo]" +
                                         " ,[SoTrang]" +
                                         " ,[Phong]" +
                                         " ,[LotQty]" +
                                         " ,[AQL]" +
                                         " ,'' as [FPC]" +
                                         " ,null as [NgayEntek]" +
                                         " ,[Evaluate]" +
                                         " ,EmpID" +
                                         " ,SL as AQLD" +
                                         " ,DefectCode" +
                                         " ,DefectQty as Qty " +
                                         " ,[LoaiHang]" +
                                         " ,[ThoiGianRM]" +
                                         " ,'' as [HangSSI]" +
                                         " ,'' as [CuDiemXuat]" +
                                         " ,[GhiChu]" +
                                         " ,[BaoCao] from {1} h left join {2} d on d.ID=h.ID " +
                                         " where Ngay between @StartDate and @EndDate and {0}",
                                         condition, tb_Head, tb_Detail)
            ElseIf Loai = "HANG-THUONG" Then
                sql = String.Format(" select [Ngay] " +
                                        " ,[Customer]" +
                                        " ,[ProductCode]" +
                                        " ,[ProductName]" +
                                        " ,[LotNo]" +
                                        " ,[SoTrang]" +
                                        " ,[Phong]" +
                                        " ,[LotQty]" +
                                        " ,[AQL]" +
                                        " ,'' as [FPC]" +
                                        " ,null as [NgayEntek]" +
                                        " ,[Evaluate]" +
                                        " ,EmpID" +
                                        " ,SL as AQLD" +
                                        " ,DefectCode" +
                                        " ,DefectQty as Qty " +
                                        " ,[LoaiHang]" +
                                        " ,[ThoiGianRM]" +
                                        " ,'' as [HangSSI]" +
                                        " ,'' as [CuDiemXuat]" +
                                        " ,[GhiChu]" +
                                        " ,[BaoCao] from {1} h left join {2} d on d.ID=h.ID " +
                                        " where Ngay between @StartDate and @EndDate and (LoaiHang='{3}' or LoaiHang='TACH-LO') and {0}",
                                        condition, tb_Head, tb_Detail, Loai)
            End If
        End If
        Dim sqlUpdate As String = String.Format(" update [MDQA_KTPL] " +
                                                 " set LoaiHang='THU-NGHIEM'" +
                                                 " where Ngay between @StartDate and @EndDate and ProductCode like '7%' ")
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@StartDate", GetStartDate(dtpStart.Value))
        para(1) = New SqlClient.SqlParameter("@EndDate", GetStartDate(dtpEnd.Value))
        Dim bd As New BindingSource
        If rdoPL.Checked Then
            _db.ExecuteNonQuery(sqlUpdate, para)
        End If
        bd.DataSource = _db.FillDataTable(sql, para)
        bdnH.BindingSource = bd
        gridH.DataSource = bd


    End Sub

    Private Sub mnuExport_Click(sender As System.Object, e As System.EventArgs) Handles mnuExport.Click
        ExportEXCEL(gridH)
    End Sub

    Private Sub txtPdCode_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPdCode.TextChanged
        If bdnH.BindingSource IsNot Nothing Then
            If txtPdCode.Text = "" Then
                bdnH.BindingSource.Filter = ""
            Else
                bdnH.BindingSource.Filter = String.Format("productcode like '%{0}%'", txtPdCode.Text)
            End If
        End If
    End Sub

    Private Sub txtLotNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtLotNo.TextChanged
        If bdnH.BindingSource IsNot Nothing Then
            If txtLotNo.Text = "" Then
                bdnH.BindingSource.Filter = ""
            Else
                bdnH.BindingSource.Filter = String.Format("LotNo like '%{0}%'", txtLotNo.Text)
            End If
        End If
    End Sub

    Private Sub gridH_DataBindingComplete(sender As System.Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles gridH.DataBindingComplete
        LoadDetail()
        LoadDetailS()

        txtQtyHead.Text = CType(CType(bdnH.BindingSource, BindingSource).DataSource, DataTable).Compute("sum(Qty)", bdnH.BindingSource.Filter)
    End Sub

    Private Sub rdoKT1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rdoKT1.CheckedChanged

        rdoKiemLai.Enabled = Not rdoKT1.Checked

    End Sub

    Private Sub mnuExportL_Click(sender As System.Object, e As System.EventArgs) Handles mnuExportL.Click
        ExportEXCEL(gridD)
    End Sub

    Private Sub mnuExportE_Click(sender As System.Object, e As System.EventArgs) Handles mnuExportE.Click
        ExportEXCEL(gridS)
    End Sub
End Class