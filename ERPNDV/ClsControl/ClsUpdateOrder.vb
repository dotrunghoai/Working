Imports LibEntity
Imports CommonDB
Imports System.Windows.Forms

Public Class ClsUpdateOrder
    Dim db As New DBSql(PublicUtility.PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Dim dbAs As New DBFunction(PublicUtility.PublicConst.EnumServers.NDV_DB2_AS400)

    Sub UpdateGoodsDetail()
        Try
            db.BeginTransaction()
            Dim obj() As GSR_GoodsOrderDetail = db.GetObjects(Of GSR_GoodsOrderDetail)("select * from GSR_GoodsOrderDetail")
            For Each o As GSR_GoodsOrderDetail In obj
                Dim sql As String = String.Format("SELECT * " +
                                     " FROM [t_ASMaterialInOutHistory] " +
                                     " where TransactionType='110' and PurchaseOrderNumber='{0}' " +
                                     " and ItemCode='{1}' ", o.POID, o.JCode_K)
                Dim tbINOUt As DataTable = db.FillDataTable(sql)
                Dim index As Integer = 1
                If tbINOUt.Rows.Count >= 1 Then
                    For Each row As DataRow In tbINOUt.Rows
                        Dim oD As New GSR_GoodsDetail
                        oD.ID_K = o.ID_K
                        oD.JCode_K = o.JCode_K
                        oD.OrderID_K = o.OrderID_K
                        oD.OrderNo_K = index
                        oD.POID = o.POID
                        oD.ReceivedDate = IIf(row("PurchaseDate") IsNot DBNull.Value, row("PurchaseDate"), Nothing)
                        oD.ReceivedQuantity = IIf(row("Quantity") IsNot DBNull.Value, row("Quantity"), Nothing)
                        index += 1
                        db.Insert(oD)
                    Next
                End If
            Next
            db.Commit()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            db.RollBack()
        End Try
    End Sub

    Sub UpdateInvoice()
        Try

            Dim obj() As GSR_GoodsDetail = db.GetObjects(Of GSR_GoodsDetail)("select * from GSR_GoodsDetail  where left(ID,2)>='11' and (invoiceid is null or invoiceid='') ")
            For Each o As GSR_GoodsDetail In obj
                Application.DoEvents()
                Dim PON As String = String.Format(" SELECT PurchaseNumber " +
                                                  " FROM [t_ASMaterialInOutHistory] " +
                                                  "    where TransactionType='110' and PurchaseOrderNumber='{0}' " +
                                                  "    and ItemCode='{1}' ", o.POID, o.JCode_K)
                Dim sqlAS As String = String.Format("select THVEIV as InvoiceID from NDVDTA.MTHVIVP " +
                                                 " where THPUNB='{0}' and THPONB='{1}'", db.ExecuteScalar(PON), o.POID)
                Dim invoice As Object = dbAs.ExecuteScalar(sqlAS)
                o.InvoiceID = IIf(invoice Is DBNull.Value, Nothing, invoice)
                db.Update(o)
                Console.WriteLine(o.ReceivedDate & " - " & o.InvoiceID)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class
