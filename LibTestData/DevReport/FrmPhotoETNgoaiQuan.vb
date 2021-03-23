Imports CommonDB
Imports PublicUtility
Public Class FrmPhotoETNgoaiQuan
    Sub New()
        InitializeComponent()
        If (Not MvvmContext1.IsDesignMode) Then
            InitializeBindings()
        End If
    End Sub

    Dim _db As New DBSql(PublicConst.EnumServers.NDV_SQL_ERP_NDV)
    Private Sub FrmPhotoETNgoaiQuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'btnShow.PerformClick()
    End Sub

    Private Sub btnShow_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnShow.ItemClick
        GridControl1.DataSource = _db.FillDataTable("SELECT * 
                                                    FROM IT_TF_TreeFolder 
                                                    ORDER BY Order1, Order2, Order3, Order4, 
                                                    Order5, Order6, Order7")
        GridControlSetFormat(GridView1)
        GridView1.Columns("TextEnglish").Visible = False
        GridView1.Columns("TextJapanese").Visible = False
        GridView1.Columns("TextChinese").Visible = False
        GridControlReadOnly(GridView1, True)
        GridView1.Columns("ParentID").OptionsColumn.ReadOnly = False
        GridView1.Columns("Order1").OptionsColumn.ReadOnly = False
        GridView1.Columns("Order2").OptionsColumn.ReadOnly = False
        GridView1.Columns("Order3").OptionsColumn.ReadOnly = False
        GridView1.Columns("Order4").OptionsColumn.ReadOnly = False
        GridView1.Columns("Order5").OptionsColumn.ReadOnly = False
        GridView1.Columns("Order6").OptionsColumn.ReadOnly = False
        GridView1.Columns("Order7").OptionsColumn.ReadOnly = False
        GridControlSetColorEdit(GridView1)

        TreeList1.DataSource = _db.FillDataTable("SELECT ID, ParentID, TextVietNamese 
                                                FROM IT_TF_TreeFolder
                                                ORDER BY Order1, Order2, Order3, Order4, 
                                                Order5, Order6, Order7")
        TreeList1.Columns("TextVietNamese").Width = 200
        TreeList1.CollapseAll()
        TreeList1.ExpandToLevel(1)
        TreeList1.StateImageList = ImageCollection1
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If GridView1.Editable And e.Column.ReadOnly = False Then
            'If e.RowHandle < 0 Then
            '    If IsDBNull(GridView1.GetFocusedRowCellValue("ID")) Then
            '        Dim id = GetID()
            '        _db.ExecuteNonQuery(String.Format("INSERT INTO Main_TestTreeList (ID)
            '                                            VALUES ('{0}')", id))
            '        GridView1.SetFocusedRowCellValue("ID", id)
            '    End If
            'End If
            Dim para(0) As SqlClient.SqlParameter
            para(0) = New SqlClient.SqlParameter("@Value", e.Value)
            _db.ExecuteNonQuery(String.Format("UPDATE IT_TF_TreeFolder
                                                SET {0} = @Value
                                                WHERE ID = '{1}'",
                                                e.Column.FieldName,
                                                GridView1.GetFocusedRowCellValue("ID")), para)
        End If
    End Sub
    Function GetID() As String
        Dim valMaxID As String = _db.ExecuteScalar("SELECT ISNULL(MAX(ID), 0)
                                                    FROM IT_TF_TreeFolder")
        Return (CType(valMaxID, Integer) + 1).ToString.PadLeft(5, "0")
    End Function

    Private Sub TreeList1_GetStateImage(sender As Object, e As DevExpress.XtraTreeList.GetStateImageEventArgs) Handles TreeList1.GetStateImage
        If e.Node.ParentNode Is Nothing Then
            e.NodeImageIndex = 0
        ElseIf e.Node.HasChildren Then
            e.NodeImageIndex = 1
        Else
            e.NodeImageIndex = 2
        End If
    End Sub

    Private Sub btnDelete_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnDelete.ItemClick
        If ShowQuestionDelete() = DialogResult.Yes Then
            _db.ExecuteNonQuery(String.Format("DELETE IT_TF_TreeFolder
                                           WHERE ID = '{0}'",
                                               GridView1.GetFocusedRowCellValue("ID")))
            GridView1.DeleteSelectedRows()
        End If
    End Sub

    Private Sub btnSetting_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btnSetting.ItemClick
        'If txtFormIDOld.Text <> "" And txtOrder2.Text <> "" And txtParentID.Text <> "" Then
        '    Dim dt = _db.FillDataTable(String.Format("SELECT TOP 1 FormID, AssemblyName, FormName, 
        '                                TextVietNam, TextEnglish, TextJapan, TextChina, [Order], 
        '                                SubModule, ChildForm
        '                            FROM Main_FormRight
        '                            WHERE FormID LIKE N'%{0}%'", txtFormIDOld.Text))
        '    Dim id = GetID()
        '    If dt.Rows.Count > 0 Then
        '        Dim obj As New IT_TF_TreeFolder
        '        obj.ID_K = id
        '        obj.ParentID = txtParentID.Text
        '        If Not IsDBNull(dt.Rows(0)("AssemblyName")) Then
        '            obj.LibName = dt.Rows(0)("AssemblyName")
        '        End If
        '        obj.FormName = dt.Rows(0)("FormName")
        '        obj.FormIDOld = dt.Rows(0)("FormID")
        '        obj.TextVietnamese = dt.Rows(0)("TextVietNam")
        '        obj.TextEnglish = dt.Rows(0)("TextEnglish")
        '        obj.TextJapanese = dt.Rows(0)("TextJapan")
        '        obj.TextChinese = dt.Rows(0)("TextChina")
        '        obj.Order1 = 2
        '        obj.Order2 = txtOrder2.Text
        '        obj.Order3 = txtOrder3.Text
        '        obj.Order4 = dt.Rows(0)("ChildForm")
        '        'If Not IsDBNull(dt.Rows(0)("ChildForm")) Then
        '        '    obj.Order5 = dt.Rows(0)("ChildForm")
        '        'End If
        '        obj.CreateUser = "21340"
        '        obj.CreateDate = DateTime.Now
        '        _db.Insert(obj)
        '    End If
        '    btnShow.PerformClick()
        'End If
    End Sub

    Sub InitializeBindings()
        Dim fluent = MvvmContext1.OfType(Of FrmPhotoETNgoaiQuanViewModel)()
    End Sub
End Class