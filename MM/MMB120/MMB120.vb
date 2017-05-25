﻿Imports Frame7
Imports Base7
Imports Base7.Shared




Public Class MMB120


    Private Sub MMB120_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '구매발주번호 자동채번 설정
        '   po_no.CodeNo = "MMB120"        'Function dbo.[fnCodeNo]안에 LEB100에 대한 코딩을 해야 한다
        '   po_no.CodeDateField = po_dt

        Me.New_Form()

    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
                Me.Open_Form()

            Case MenuType.Save
                If MyBase.Save() Then
                    Me.Open_Form()
                End If

            Case MenuType.Delete
                'Me.WorkSets("sca100_f10").DeleteRow()   '특정Workset을 삭제

            Case MenuType.New
                Me.New_Form()
                'Me.WorkSets("mmb100_g10").AddNew()  '특정Workset 신규처리

            Case MenuType.Print
                ' Me.Print()

            Case Else
                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

        End Select

    End Sub

    Public Sub Open_Form()
        '   union_yn.Text = "0"
        Me.Open()

        'g10.AddNewRow()
    End Sub

    Public Sub Open3(ByVal POdt As String, ByVal POFac As String, ByVal Entbc As String)
        po_dt.Text = POdt
        po_fac.Text = POFac

        Me.Open_Form()
    End Sub

    Public Sub New_Form()
        po_dt.Text = ""
        Me.Open("mmb120_g10")
        po_dt.Text = Now.ToLongDateString
    End Sub

    'Private Sub SimpleButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    union_yn.Text = "1"
    '    g10.Open()

    '    'Dim p As New OpenParameters

    '    'p.Add("@po_no", po_no.Text)
    '    'p.Add("@po_fac", po_fac.Text)
    '    'p.Add("@po_dt", po_dt.Text)
    '    'p.Add("@cury_bc", cury_bc.Text)
    '    'p.Add("@po_cust", cust_cd.Text)

    '    'Me.Open("mmb100_itm", p)
    '    ''Me.OpenDataSet("mmb100_itm", p)
    '    ''g10.AddNewRow()
    '    ''MyBase.Open("mmb100_itm", p)
    'End Sub
  
    Private Sub g10_CellValueChanging(ByVal sender As Object, ByVal ColumnName As String, ByVal RowIndex As Integer, ByRef Value As Object) Handles g10.CellValueChanging

        'If ColumnName = "po_qty" Then
        '    If Value > "0" And g10.ToDec("po_sq") = 0 Then
        '        Set_maxSq()
        '    ElseIf Value = "0" Then
        '        g10.Text("po_sq") = ""
        '    End If

        'End If

        '수량변경 -> 자동 순번증가
        ' If ColumnName = "so_qty" Then
        'If g10.ToDec("so_qty") = 0 Then
        ' g10.Text("so_sq") = ""
        ' Else
        ' If g10.Text("so_sq") = "" Then
        ' g10.Text("so_sq") = GetSeqNo(sdb100_g10, "so_sq")

        ' End If
        ' End If
        ' End If
    End Sub

    'Public Sub Set_maxSq()

    '    Dim iRow As Integer, maxNo As Double

    '    For iRow = 0 To g10.RowCount - 1
    '        If maxNo < g10.ToDec("po_sq", iRow) Then
    '            maxNo = g10.ToDec("po_sq", iRow)
    '        End If
    '    Next
    '    g10.Text("po_sq") = maxNo + 1
    'End Sub


    Public Sub Open3(ByVal dSet As DataSet)
        'Me.New_Form()
        'g10.DeleteBlankRow()

        'Dim i As Integer = 0
        'For Each dRow As DataRow In dSet.Tables(0).Rows
        '    If ToStr(dRow("chk")) Then

        '        If i = 0 Then
        '            cust_cd.Text = ToStr(dRow("cust_cd"))
        '        End If

        '        g10.AddNewRow()
        '        g10.Text("req_no", i) = ToStr(dRow("req_no"))
        '        g10.Text("req_sq", i) = ToStr(dRow("req_sq"))
        '         g10.Text("itm_cd", i) = ToStr(dRow("itm_cd"))
        '        g10.Text("dlv_um", i) = ToStr(dRow("um_bc"))
        '        g10.Text("po_qty", i) = ToStr(dRow("qty"))

        '        i += 1
        '    End If


        'Next

    End Sub

    Private Sub btn_price_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_price.Click
        Dim p As New OpenParameters

        Try
            Windows.Forms.Cursor.Current = Cursors.WaitCursor
            With g10

                .UpdateRow()

                For Row As Integer = 0 To .RowCount - 1
                    p.Add("@itm_id", g10.Text("itm_id", Row))
                    p.Add("@cust_cd", g10.Text("cust_cd", Row))
                    p.Add("@cury_bc", g10.Text("cury_bc", Row))
                    p.Add("@po_fac", po_fac.Text)
                    p.Add("@po_dt", po_dt.Text)
                    Dim dSet As DataSet = OpenDataSet("mmb120_cost", p)

                    If Not IsEmpty(dSet) Then

                        '.RowIndex = Row
                        .Text("po_up", Row) = DataValue(dSet, "up")
                        .Text("ttm_rt", Row) = DataValue(dSet, "ttm_rt")
                        dSet = Nothing

                    End If

                Next

            End With

        Catch ex As Exception

        Finally
            Windows.Forms.Cursor.Current = Cursors.Default
        End Try

        'Me.OpenDataSet("mmb100_itm", p)
        'g10.AddNewRow()
        'MyBase.Open("mmb100_itm", p)
    End Sub
End Class
