﻿Imports CommonDB
Imports LibEntity
Imports PublicUtility

Imports System.Windows.Forms
Public Class FrmLockData : Inherits DevExpress.XtraEditors.XtraForm

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)


    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        Dim para(1) As SqlClient.SqlParameter
        para(0) = New SqlClient.SqlParameter("@Start", GetStartDayOfMonth(dtpDate.Value))
        para(1) = New SqlClient.SqlParameter("@End", GetEndDayOfMonth(dtpDate.Value))
        Dim sql As String = String.Format(" select * from MDQA_Lock where Ngay between @Start and @End")
        Dim bdsource As New BindingSource
        bdsource.DataSource = _db.FillDataTable(sql, para)
        bdn.BindingSource = bdsource
        grid.DataSource = bdsource
    End Sub

    Private Sub mnuLock_Click(sender As System.Object, e As System.EventArgs) Handles mnuLock.Click
        If ShowQuestionLock() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New MDQA_Lock
            obj.Ngay_K = GetStartDate(dtpDate.Value)
            obj.Lock = True
            obj.LockDate = DateTime.Now
            obj.LockUser = CurrentUser.UserID
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub mnuUnLock_Click(sender As System.Object, e As System.EventArgs) Handles mnuUnLock.Click
        If ShowQuestionUnLock() = Windows.Forms.DialogResult.Yes Then
            Dim obj As New MDQA_Lock
            obj.Ngay_K = GetStartDate(dtpDate.Value)
            obj.Lock = False
            obj.LockDate = DateTime.Now
            obj.LockUser = CurrentUser.UserID
            If _db.ExistObject(obj) Then
                _db.Update(obj)
            Else
                _db.Insert(obj)
            End If
            mnuShowAll.PerformClick()
        End If
    End Sub

    Private Sub dtpDate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDate.ValueChanged
        Dim obj As New MDQA_Lock
        obj.Ngay_K = GetStartDate(dtpDate.Value)
        obj.Lock = False
        obj.LockDate = DateTime.Now
        obj.LockUser = CurrentUser.UserID
        If Not _db.ExistObject(obj) Then
            _db.Insert(obj)
        End If
        mnuShowAll.PerformClick()
    End Sub

    Private Sub FrmLockData_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        mnuShowAll.PerformClick()
    End Sub

    Private Sub mnusLock_Click(sender As System.Object, e As System.EventArgs) Handles mnusLock.Click
        If ShowQuestionLock() = Windows.Forms.DialogResult.Yes Then
            For Each r As DataGridViewRow In grid.SelectedRows
                Dim obj As New MDQA_Lock
                obj.Ngay_K = r.Cells("Ngay").Value
                obj.Lock = True
                obj.LockDate = DateTime.Now
                obj.LockUser = CurrentUser.UserID
                r.Cells("Lock").Value = True
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If
            Next
        End If
    End Sub

    Private Sub mnusUnLock_Click(sender As System.Object, e As System.EventArgs) Handles mnusUnLock.Click
        If ShowQuestionUnLock() = Windows.Forms.DialogResult.Yes Then
            For Each r As DataGridViewRow In grid.Rows
                Dim obj As New MDQA_Lock
                obj.Ngay_K = r.Cells("Ngay").Value
                obj.Lock = False
                obj.LockDate = DateTime.Now
                obj.LockUser = CurrentUser.UserID
                r.Cells("Lock").Value = False
                If _db.ExistObject(obj) Then
                    _db.Update(obj)
                Else
                    _db.Insert(obj)
                End If
            Next
        End If
    End Sub
End Class