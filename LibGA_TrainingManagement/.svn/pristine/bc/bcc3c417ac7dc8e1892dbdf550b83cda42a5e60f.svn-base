Imports System.Drawing
Imports DevExpress.XtraReports.UI

Public Class RpF028
    Sub DrawCell(cell As XRTableCell, val As Object)
        If Not IsDBNull(val) Then
            If val = "Plan" Then
                cell.BackColor = Color.Yellow
            ElseIf val = "Delayed" Then
                cell.BackColor = Color.Green
            ElseIf val = "Completed" Then
                cell.BackColor = Color.Blue
                cell.ForeColor = Color.White
            ElseIf val = "Cancelled" Then
                cell.BackColor = Color.Red
            ElseIf val = "Not Completed" Then
                cell.BackColor = Color.Orange
            ElseIf val = "New Plan" Then
                cell.BackColor = Color.Purple
            End If
        Else
            cell.BackColor = Color.Transparent
        End If
    End Sub
    Private Sub AprCol_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles AprCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Apr"))
    End Sub

    Private Sub MayCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MayCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("May"))
    End Sub

    Private Sub JunCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles JunCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Jun"))
    End Sub

    Private Sub JulCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles JulCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Jul"))
    End Sub

    Private Sub AugCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles AugCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Aug"))
    End Sub

    Private Sub SepCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles SepCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Sep"))
    End Sub

    Private Sub OctCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles OctCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Oct"))
    End Sub

    Private Sub NovCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles NovCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Nov"))
    End Sub

    Private Sub DecCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles DecCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Dec"))
    End Sub

    Private Sub JanCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles JanCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Jan"))
    End Sub

    Private Sub FebCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles FebCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Feb"))
    End Sub

    Private Sub MarCol_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MarCol.BeforePrint
        DrawCell(TryCast(sender, XRTableCell), GetCurrentColumnValue("Mar"))
    End Sub
End Class