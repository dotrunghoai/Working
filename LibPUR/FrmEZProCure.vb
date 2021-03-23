Imports CommonDB
Imports PublicUtility

Public Class FrmEZProCure
    Dim nvd1 As DBSql = New DBSql("Data Source=10.153.1.7;initial catalog=GABLE;user id=sa;password=P@ssw0rd;Connection Timeout=5;")
    Dim nvd As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)

    Private Sub mnuShowAll_Click(sender As System.Object, e As System.EventArgs) Handles mnuShowAll.Click
        'Dim sqlPO As String = String.Format("SELECT A.POID, A.PONo, A.StatusID, C.Description StatusDescription, A.OpenDate, A.RequestDeliveryDate, A.Priority, " +
        '"A.Note, A.PaymentTerm, A.DeliveryTerm, A.Currency, A.Creator, A.VAT, B.PODetailID, B.ItemID, " +
        '"D.ItemCode, D.ItemName, D.Description ItemDescription, D.UnitCode, D.PackingUnit, " +
        '"B.Quantity, B.UnitPrice, B.TaxRate, LTrim(RTrim(F.DeptName)) DeptName, G.ContactName " +
        '"FROM GABLE_POMaster A " +
        '"inner JOIN GABLE_PODetail B " +
        '"ON A.POID = B.POID " +
        '"LEFT JOIN GABLE_Status C ON A.StatusID = C.StatusID " +
        '"LEFT JOIN GABLE_Item D ON b.ItemID = D.ItemID " +
        '"LEFT JOIN GABLE_Category E ON D.CategoryCode = E.CategoryCode " +
        '"LEFT JOIN GABLE_Department F ON B.RequestDeptCode = F.DeptCode " +
        '"LEFT JOIN GABLE_Contact G ON A.ReceiverID = G.ContactID")

        'Dim sqlPO2 As String = String.Format("SELECT  A.PONo , " +
        '"A.OpenDate , " +
        '"Contact = CONVERT(VARCHAR(50), G.ContactID) + ' || ' + G.ContactName , " +
        '"D.ItemCode , " +
        '"D.ItemName , " +
        '"D.Description ItemDescription , " +
        '"D.PackingUnit , " +
        '"D.UnitCode , " +
        '"B.Quantity , " +
        '"B.UnitPrice , " +
        '"A.Currency , " +
        '"Amount = ( B.UnitPrice * B.Quantity ) , " +
        '"A.PaymentTerm , " +
        '"A.DeliveryTerm , " +
        '"A.RequestDeliveryDate , " +
        '"LTRIM(RTRIM(F.DeptName)) DeptName, " +
        '"A.Creator " +
        '"FROM    GABLE_POMaster A " +
        '"INNER JOIN GABLE_PODetail B ON A.POID = B.POID " +
        '"LEFT JOIN GABLE_Status C ON A.StatusID = C.StatusID " +
        '"LEFT JOIN GABLE_Item D ON b.ItemID = D.ItemID " +
        '"LEFT JOIN GABLE_Category E ON D.CategoryCode = E.CategoryCode " +
        '"LEFT JOIN GABLE_Department F ON B.RequestDeptCode = F.DeptCode " +
        '"LEFT JOIN GABLE_Contact G ON A.ReceiverID = G.ContactID " +
        '"where (A.OpenDate between '2011-05-01' and '2014-02-10') and (D.ItemName LIKE N'%lốc lạnh%' " +
        '"OR D.ItemName LIKE N'%máy lạnh%' " +
        '"OR D.ItemName LIKE N'%dàn lạnh%' " +
        '"OR D.ItemName LIKE N'%compressor%') " +
        '"ORDER BY A.OpenDate")

        'Dim sqlDelivery As String = String.Format("SELECT A.POID, A.PONo, A.StatusID, C.Description StatusDescription, A.OpenDate, A.RequestDeliveryDate, A.Priority, " +
        '"A.Note, A.PaymentTerm, A.DeliveryTerm, A.Currency, A.Creator, A.VAT, B.PODetailID, B.ItemID, " +
        '"D.ItemCode, D.ItemName, D.Description ItemDescription, D.UnitCode, D.PackingUnit, " +
        '"B.Quantity, B.UnitPrice, B.TaxRate, LTrim(RTrim(F.DeptName)) DeptName, G.ContactName, " +
        '"K.DeliveryNo, H.DeliveryDate, H.Quantity DeliveryQuantity, DeliveryAmount = B.UnitPrice*ISNULL(H.Quantity,0) " +
        '"FROM GABLE_POMaster A " +
        '"inner JOIN GABLE_PODetail B " +
        '"ON A.POID = B.POID " +
        '"LEFT JOIN GABLE_Status C ON A.StatusID = C.StatusID " +
        '"LEFT JOIN GABLE_Item D ON b.ItemID = D.ItemID " +
        '"LEFT JOIN GABLE_Category E ON D.CategoryCode = E.CategoryCode " +
        '"LEFT JOIN GABLE_Department F ON B.RequestDeptCode = F.DeptCode " +
        '"LEFT JOIN GABLE_Contact G ON A.ReceiverID = G.ContactID " +
        '"LEFT JOIN GABLE_DeliveryDetail H ON B.PODetailID = H.PODetailID " +
        '"LEFT JOIN GABLE_DeliveryMaster K ON H.DeliveryID = K.DeliveryID " +
        '"WHERE H.DeliveryDate >='2012-11-01' OR H.DeliveryDate IS NULL " +
        '"ORDER BY H.DeliveryDate")

        'Dim sqlInvoice As String = String.Format("SELECT A.POID, A.PONo, A.StatusID, C.Description StatusDescription, A.OpenDate, A.RequestDeliveryDate, A.Priority, " +
        '"A.Note, A.PaymentTerm, A.DeliveryTerm, A.Currency, A.Creator, A.VAT, B.PODetailID, B.ItemID, " +
        '"D.ItemCode, D.ItemName, D.Description ItemDescription, D.UnitCode, D.PackingUnit, " +
        '"B.Quantity, B.UnitPrice, B.TaxRate, LTrim(RTrim(F.DeptName)) DeptName, G.ContactName, " +
        '"K.InvoiceNo, H.Quantity InvoiceQuantity, H.UnitPrice InvoiceUnitPrice, InvoiceAmount = ISNULL(H.UnitPrice, 0)*ISNULL(H.Quantity,0) " +
        '"FROM GABLE_POMaster A " +
        '"inner JOIN GABLE_PODetail B " +
        '"ON A.POID = B.POID " +
        '"LEFT JOIN GABLE_Status C ON A.StatusID = C.StatusID " +
        '"LEFT JOIN GABLE_Item D ON b.ItemID = D.ItemID " +
        '"LEFT JOIN GABLE_Category E ON D.CategoryCode = E.CategoryCode " +
        '"LEFT JOIN GABLE_Department F ON B.RequestDeptCode = F.DeptCode " +
        '"LEFT JOIN GABLE_Contact G ON A.ReceiverID = G.ContactID " +
        '"LEFT JOIN GABLE_InvoiceDetail H ON B.PODetailID = H.PODetailID " +
        '"LEFT JOIN GABLE_InvoiceMaster K ON H.InvoiceID = K.InvoiceID")

        Dim sqlSup As String = String.Format("SELECT * FROM dbo.GABLE_Contact ORDER BY ContactID")
        Dim dt As DataTable = nvd1.FillDataTable(sqlSup)
        gridD.DataSource = dt
    End Sub

    Private Sub mnuExportJC_Click(sender As System.Object, e As System.EventArgs) Handles mnuExportJC.Click
        ExportEXCEL(gridD)
        'ExportEXCEL(nvd.ExecuteStoreProcedureTB("[sp_ThaiSon_GetDataEC4]"))
        'ExportEXCEL(nvd.ExecuteStoreProcedureTB("sp_ThaiSon_GetDataEC5"))
    End Sub
End Class