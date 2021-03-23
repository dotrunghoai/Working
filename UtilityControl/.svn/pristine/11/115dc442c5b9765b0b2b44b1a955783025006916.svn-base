
Public Class SuggestComboBox
    Inherits ComboBox
#Region "fields and properties"

    Private ReadOnly _suggLb As New ListBox() With { _
     .Visible = False, _
     .TabStop = False _
    }
    Private _countFilter As Integer

#End Region

    ''' <summary>
    ''' ctor
    ''' </summary>
    Public Sub New()
        _suggLb.Height = 150
        AddHandler _suggLb.Click, AddressOf SuggLbOnClick

        AddHandler ParentChanged, AddressOf OnParentChanged
    End Sub

    ''' <summary>
    ''' the magic happens here ;-)
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)

        If Not Focused Then
            Return
        End If
        _suggLb.Visible = True

        _suggLb.Items.Clear()

        Dim dtTemp As DataTable = TryCast(DataSource, DataTable)
        Dim dt As DataTable = dtTemp.Copy()
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("Name") = dt.Rows(i)("Name").ToString.Replace("%", "ThayTheDauPhanTram")
        Next
        If dt Is Nothing Then
            Dim itemsLst As String() = New String(Items.Count - 1) {}
            Items.CopyTo(itemsLst, 0)
            Dim item As String = Text
            Dim filteredItems As String() = itemsLst.Where(Function(x) x.ToLower.Contains(item.ToLower)).ToArray()
            _countFilter = filteredItems.Count
            _suggLb.Items.AddRange(filteredItems)
            If _suggLb.Items.Count > 0 Then
                _suggLb.SelectedIndex = 0
            End If
        Else
            Dim name As String = Text
            Dim rows As DataRow() = dt.Select(String.Format("Name LIKE '%{0}%'", name.Replace("%", "ThayTheDauPhanTram")))
            For Each r As DataRow In rows
                _suggLb.Items.Add(r(1).ToString.Replace("ThayTheDauPhanTram", "%"))
            Next
            _countFilter = _suggLb.Items.Count
            If _suggLb.Items.Count > 0 Then
                _suggLb.SelectedIndex = 0
            End If
        End If

        If _suggLb.Items.Count = 1 AndAlso _suggLb.Items(0).Length = Text.Trim().Length Then
            Text = _suggLb.Items(0)
            [Select](0, Text.Length)
            _suggLb.Visible = False
        End If

        Cursor.Current = Cursors.Default

    End Sub

#Region "size and position of suggest box"

    ''' <summary>
    ''' suggest-ListBox is added to parent control
    ''' (in ctor parent isn't already assigned)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Overloads Sub OnParentChanged(sender As Object, e As EventArgs)
        Parent.Controls.Add(_suggLb)
        Parent.Controls.SetChildIndex(_suggLb, 0)
        _suggLb.Top = Top + Height - 1
        _suggLb.Left = Left
        _suggLb.Width = Width + 200
        _suggLb.Font = New Font("Segoe UI", 9)
    End Sub

    Protected Overrides Sub OnLocationChanged(e As EventArgs)
        MyBase.OnLocationChanged(e)
        _suggLb.Top = Top + Height - 1
        _suggLb.Left = Left
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        _suggLb.Width = Width + 200
    End Sub

#End Region

#Region "visibility of suggest box"

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        ' _suggLb can only getting focused by clicking (because TabStop is off)
        ' --> click-eventhandler 'SuggLbOnClick' is called
        If Not _suggLb.Focused Then
            HideSuggBox()
        End If
        MyBase.OnLostFocus(e)
    End Sub

    Private Sub SuggLbOnClick(sender As Object, eventArgs As EventArgs)
        Text = _suggLb.Text
        Focus()
    End Sub

    Private Sub HideSuggBox()
        _suggLb.Visible = False
    End Sub

    Protected Overrides Sub OnDropDown(e As EventArgs)
        HideSuggBox()
        MyBase.OnDropDown(e)
    End Sub

#End Region

#Region "keystroke events"

    ''' <summary>
    ''' if the suggest-ListBox is visible some keystrokes
    ''' should behave in a custom way
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnPreviewKeyDown(e As PreviewKeyDownEventArgs)
        If Not _suggLb.Visible Then
            MyBase.OnPreviewKeyDown(e)
            Return
        End If

        Select Case e.KeyCode
            Case Keys.Down
                If _suggLb.SelectedIndex < _countFilter - 1 Then
                    _suggLb.SelectedIndex += 1
                End If
                Return
            Case Keys.Up
                If _suggLb.SelectedIndex > 0 Then
                    _suggLb.SelectedIndex -= 1
                End If
                Return
            Case Keys.Enter
                Text = _suggLb.Text
                [Select](0, Text.Length)
                _suggLb.Visible = False
                Return
            Case Keys.Escape
                HideSuggBox()
                Return
        End Select

        MyBase.OnPreviewKeyDown(e)
    End Sub

    Private Shared ReadOnly KeysToHandle As Keys() = {Keys.Down, Keys.Up, Keys.Enter, Keys.Escape}
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
        ' the keysstrokes of our interest should not be processed be base class:
        If _suggLb.Visible AndAlso KeysToHandle.Contains(keyData) Then
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

#End Region
End Class
