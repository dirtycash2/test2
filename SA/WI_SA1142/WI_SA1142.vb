﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class WI_SA1142
    Dim stts As String
    Dim p As New OpenParameters

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Clear()

        If find_visible.Checked Then MenuButton_Click(MenuType.Find)
    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
            Case MenuType.Save
                If Not Saves() Then Exit Sub

            Case MenuType.Cancel
                Me.Clear()

            Case MenuType.Confirm
                If Not ConFrim() Then Exit Sub

            Case MenuType.Deconfirm
                If Not DeConFrim() Then Exit Sub

            Case MenuType.Find
                Me.Find()

            Case MenuType.Delete
                If Not Del() Then Exit Sub

            Case MenuType.New
                New_Form()

            Case Else
                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

        End Select

    End Sub

    Private Sub New_Form()

        g_body.AddNewRow()
    End Sub

    Private Function Saves() As Boolean

        If Check_Stts() = "C" Then '상태값 CHECK
            MsgBox("확인처리된 자료입니다.!")
            Return False
        End If

        Me.OTAMT()

        If Check_Od_Qty() <> 0 Then
            Return False
        End If

        If MessageYesNo("저장 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            Max_NO()  '전표채번..

            If MyBase.Save() Then
                If wf_update_lotno() <> 0 Then
                    Return False
                End If
            End If
        End If

        '거래처 체크
        If Not Me.Check_CsCd() Then
            Return False
        End If

        Return True
    End Function

    Private Function Check_Stts() As String
        p.Clear()
        p.Add("@ot_no", ot_no.Text)

        Dim dSet As Data.DataSet = Me.OpenDataSet("wi_sa1142_stts", p)
        Dim stts As String = "S"

        If Not IsEmpty(dSet) Then stts = DataValue(dSet)

        Return stts

    End Function

    Private Sub Max_NO()
        ' 전표 번호 채번
        ot_no.CodeNo = "WI_SA1140"        'Function dbo.[fnCodeNo]안에 LEB100에 대한 코딩을 해야 한다
        ot_no.CodeDateField = ot_dt
    End Sub

    Private Function Del() As Boolean

        If ot_no.Text = Nothing Then
            MsgBox("자료를 확인하세요.!")
            Return False
        End If

        '상태값 CHECK
        If Check_Stts() = "C" Then '상태값 CHECK
            MsgBox("확인처리된 자료입니다.!")
            Return False
        End If

        If MessageYesNo("삭제 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            p.Clear()
            p.Add("@ot_no", ot_no.Text)
            p.Add("@stts", "D")

            Me.Open("wi_sa1142_delete", p)

            Me.Clear()

            g_list.Open()

        End If

        Return True
    End Function

    Private Function ConFrim() As Boolean
        If ot_no.Text = Nothing Then
            MsgBox("자료를 확인하세요.!")
            Return False
        End If

        '상태값 CHECK
        If Check_Stts() = "C" Then '상태값 CHECK
            MsgBox("확인처리된 자료입니다.!")
            Return False
        End If

        If Check_Od_Qty() <> 0 Then
            Return False
        End If

        If MessageYesNo("확인 하시겠습니까?", Nothing, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = MsgBoxResult.No Then
            Exit Function
        Else
            p.Clear()
            p.Add("@ot_no", ot_no.Text)
            p.Add("@stts", "C")

            Me.Open("wi_sa1142_confirm", p)

            If wf_update_satr1121("C") <> 0 Then
                Return False
            End If

            If wf_update_lotno() <> 0 Then
                Return False
            End If

            p.Clear()
            p.Add("@ot_no", ot_no.Text)
            Me.Open("wi_sa1142_head", p)

            p.Clear()
            p.Add("@ot_no", ot_no.Text)
            Me.Open("wi_sa1142_body", p)

            g_list.Open()
        End If

        Return True
    End Function

    Private Function DeConFrim() As Boolean

        If ot_no.Text = Nothing Then
            MsgBox("자료를 확인하세요.!")
            Return False
        End If

        If Check_Stts() = "S" Then
            MsgBox("확인된 자료가 아닙니다.!")
            Return False
        End If

        If Check_Sebal() = "Y" Then
            MsgBox("해당 출하번호로 발행된 세금계산서가 있습니다.")
            Return False
        End If

        If MessageYesNo("확인취소 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            p.Clear()
            p.Add("@ot_no", ot_no.Text)
            p.Add("@stts", "S")

            Me.Open("wi_sa1142_confirm", p)

            If wf_update_satr1121("D") <> 0 Then
                Return False
            End If

            p.Clear()
            p.Add("@ot_no", ot_no.Text)
            Me.Open("wi_sa1142_head", p)

            p.Clear()
            p.Add("@ot_no", ot_no.Text)
            Me.Open("wi_sa1142_body", p)
        End If

        Return True
    End Function

    Private Function Check_CsCd() As Boolean
        Try
            Return True

        Catch ex As Exception
            MessageInfo(ex)
        End Try
    End Function

    Private Sub OTAMT()
        Dim sum_amt1, vat_amt1, ot_amt1 As Double

        With g_body
            .UpdateRow()
            For i As Integer = 0 To .RowCount - 1
                ot_amt1 = ot_amt1 + .ToDec("OT_AMT", i)
                vat_amt1 = vat_amt1 + .ToDec("VAT_AMT", i)
                sum_amt1 = sum_amt1 + .ToDec("SUM_AMT", i)
            Next
        End With

        ot_amt.Text = ot_amt1
        vat_amt.Text = vat_amt1
        sum_amt.Text = sum_amt1
    End Sub

    Private Sub Clear()
        p.Clear()
        p.Add("@ot_no", "XXX")

        Me.Open("wi_sa1142_head", p)
        Me.Open("wi_sa1142_body", p)
    End Sub

    Private Sub Find()
        If spc_1.Panel1Collapsed = False Then
            spc_1.Panel1Collapsed = True
        Else
            spc_1.Panel1Collapsed = False

        End If
    End Sub

    Private Sub find_Clear()
        p.Clear()
        p.Add("@find_from", find_from.Text)
        p.Add("@find_to", find_to.Text)
        p.Add("@find_cs_nm", "XXX")
        p.Add("@find_stts", find_stts.Text)

        Me.Open("wi_sa1142_list", p)
    End Sub

    Private Sub find_Clear2()
        p.Clear()
        p.Add("@find_from2", find_from2.Text)
        p.Add("@find_to2", find_to2.Text)
        p.Add("@find_cs_nm2", "XXX")

        Me.Open("wi_sa1142_rq_od", p)
    End Sub

    Private Sub btn_find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_find.Click
        g_list.Open()
    End Sub

    'Private Sub g_body_CellValueChanged(ByVal sender As System.Object, ByVal ColumnName As System.String, ByVal RowIndex As System.Int32, ByRef Value As System.Object) Handles g_body.CellValueChanged
    '    With g_body
    '        If ColumnName = "OT_QTY" Or ColumnName = "OT_PRI" Then
    '            .Text("OT_AMT") = .ToDec("OT_QTY") * .ToDec("OT_PRI")
    '            .Text("VAT_AMT") = ((.ToDec("OT_QTY") * .ToDec("OT_PRI")) * 0.1)
    '            .Text("SUM_AMT") = (.ToDec("OT_QTY") * .ToDec("OT_PRI")) + (((.ToDec("OT_QTY") * .ToDec("OT_PRI")) * 0.1))
    '            Me.OTAMT()
    '        End If
    '    End With
    'End Sub

    Private Sub g_list_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles g_list.DoubleClick
        p.Clear()
        p.Add("@ot_no", g_list.Text("OT_NO", g_list.RowIndex))

        Me.Open("wi_sa1142_head", p)
        Me.Open("wi_sa1142_body", p)

        If find_visible.Checked Then MenuButton_Click(MenuType.Find)
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.find_Clear()
    End Sub

    Private Sub btn_find2_Click(sender As System.Object, e As System.EventArgs) Handles btn_find2.Click
        g_list2.Open()
    End Sub

    Private Sub g_list2_DoubleClick(sender As Object, e As System.EventArgs) Handles g_list2.DoubleClick
        find_list2()
        If find_visible2.Checked Then MenuButton_Click(MenuType.Find)
    End Sub

    Private Sub btn_cancel2_Click(sender As System.Object, e As System.EventArgs) Handles btn_cancel2.Click
        find_Clear2()
    End Sub

    Private Sub find_list2()
        Me.Clear()

        p.Clear()
        p.Add("@od_no", g_list2.Text("OD_NO", g_list2.RowIndex))

        Dim dSet As Data.DataSet = Me.OpenDataSet("wi_sa1142_set_head", p)

        If Not IsEmpty(dSet) Then
            Dim dRow As DataRow, dRows As DataRowCollection
            dRows = dSet.Tables(0).Rows

            For Each dRow In dRows
                od_no.Text = ToStr(dRow("OD_NO"))
                od_gu.Text = ToStr(dRow("OD_GU"))
                cs_cd.Text = ToStr(dRow("cs_cd"))
                cs_nm.Text = ToStr(dRow("cs_nm"))
                nacs_cd.Text = ToStr(dRow("nacs_cd"))
                cur_cd.Text = ToStr(dRow("cur_cd"))
                rate.Text = ToDec(dRow("rate"))
                cs_tel.Text = ToStr(dRow("CS_TEL"))
                cs_addr.Text = ToStr(dRow("CS_ADDR"))
                deli_place.Text = ToStr(dRow("SHIP_NM"))
                sal_cust.Text = ToStr(dRow("SAL_CUST"))
                sal_cust_nm.Text = ToStr(dRow("SAL_CUST_NM"))
                sal_tel.Text = ToStr(dRow("SAL_TEL"))
                wh_cd.Text = "S001"
            Next
        End If
    End Sub

    Private Sub od_no_TextChanged(sender As Object, oldValue As String) Handles od_no.TextChanged
        Me.od_list()
    End Sub

    Private Sub od_list()
        p.Clear()
        p.Add("@od_no", g_list2.Text("OD_NO", g_list2.RowIndex))

        Dim dSet As Data.DataSet = Me.OpenDataSet("wi_sa1142_set_body", p)
        If Not IsEmpty(dSet) Then
            With g_body
                Dim iRow As Integer = 0
                Dim dRow As DataRow, dRows As DataRowCollection
                dRows = dSet.Tables(0).Rows

                iRow = .RowIndex

                If .Text("GD_CD", .RowIndex) <> Nothing Then iRow += 1

                For Each dRow In dRows
                    .InsertNewRow(iRow)

                    .Text("OD_NO", iRow) = ToStr(dRow("OD_NO"))
                    .Text("OD_SEQ", iRow) = ToDec(dRow("SEQ"))
                    .Text("GD_CD", iRow) = ToStr(dRow("GD_CD"))
                    .Text("GD_NM", iRow) = ToStr(dRow("GD_NM"))
                    .Text("SPEC", iRow) = ToStr(dRow("SPEC"))
                    .Text("UNIT_CD", iRow) = ToStr(dRow("UNIT_CD"))
                    .Text("OT_QTY", iRow) = ToDec(dRow("QTY"))
                    .Text("OT_PRI", iRow) = ToDec(dRow("OD_PRI"))
                    .Text("OT_AMT", iRow) = ToDec(dRow("OD_AMT"))
                    .Text("OD_QTY", iRow) = ToDec(dRow("OD_QTY"))
                    .Text("RM_QTY", iRow) = ToDec(dRow("QTY"))
                    .Text("BU_ODSEQ", iRow) = ToDec(dRow("BU_SEQ"))
                    .Text("DISCOUNT_RT", iRow) = ToDec(dRow("DISCOUNT_RT"))
                    .Text("WH_CD", iRow) = "S001"

                    iRow += 1
                Next
            End With
        End If
    End Sub

    Private Function Check_Od_Qty() As Integer
        Dim ld_rqty As Decimal, ld_oqty As Decimal

        With g_body
            For i As Integer = 0 To .RowCount - 1
                ld_rqty = .Text("RM_QTY", i)
                ld_oqty = .Text("OT_QTY", i)

                If ld_oqty > ld_rqty Then
                    MsgBox("출하수량이이 미출하수량보다 많습니다!")

                    '-----------------
                    .Focus()
                    .FocusedFieldName = "OT_QTY"
                    .RowIndex = i
                    .EditMode()
                    '------------------
                    Return 1
                End If
            Next
        End With

        Return 0
    End Function

    Private Function wf_update_satr1121(a_stts As String) As Integer
        Dim ls_odno As String, ll_odseq As Integer, ld_otqty As Decimal

        With g_body
            For i As Integer = 0 To .RowCount - 1
                ls_odno = .Text("OD_NO", i)
                ll_odseq = .Text("OD_SEQ", i)
                ld_otqty = .Text("OT_QTY", i)

                p.Clear()
                p.Add("@STTS", a_stts)
                p.Add("@OT_QTY", ld_otqty)
                p.Add("@OD_NO", ls_odno)
                p.Add("@OD_SEQ", ll_odseq)

                Me.Open("wi_sa1142_update", p)
            Next
        End With
    End Function

    Private Function Check_Sebal() As String
        p.Clear()
        p.Add("@ot_no", ot_no.Text)

        Dim dSet As Data.DataSet = Me.OpenDataSet("wi_sa1140_sebal", p)
        Dim stts As String = "S"

        If Not IsEmpty(dSet) Then stts = DataValue(dSet)

        Return stts

    End Function

    Private Function wf_update_lotno() As Integer
        Dim ls_otno As String, ll_seq As Integer, ls_lotno As String

        ls_otno = ot_no.Text

        With g_body
            For i As Integer = 0 To .RowCount - 1
                ll_seq = .Text("SEQ", i)
                ls_lotno = .Text("LOT_NO", i)

                p.Clear()
                p.Add("@OT_NO", ls_otno)
                p.Add("@LOT_NO", ls_lotno)
                p.Add("@SEQ", ll_seq)

                Me.Open("wi_sa1142_lotno_update", p)
            Next
        End With
    End Function

    'Private Sub ot_no_TextChanged(sender As Object, oldValue As String) Handles ot_no.TextChanged
    '    p.Clear()
    '    p.Add("@ot_no", ot_no.Text)

    '    Dim dSet As Data.DataSet = Me.OpenDataSet("wi_sa1142_otcnt", p)
    '    'Dim ll_cnt As Decimal

    '    If Not IsEmpty(dSet) Then
    '        p.Clear()
    '        p.Add("@ot_no", ot_no.Text)

    '        Me.Open("wi_sa1142_head", p)
    '        Me.Open("wi_sa1142_body", p)

    '        Me.ConFrim()
    '    Else
    '        Me.Clear()
    '    End If
    'End Sub

    'Private Sub but_prt_Click(sender As System.Object, e As System.EventArgs) Handles but_prt.Click
    '    If ot_no.Text = "" Then
    '        MessageBox.Show("출하 정보를 조회 하세요")
    '        Exit Sub
    '    End If


    '    Dim p As OpenParameters = New OpenParameters
    '    p.Add("@ot_no", ot_no.Text)


    '    Dim p1 As OpenParameters = New OpenParameters

    '    p1.Add("@ot_no", ot_no.Text)

    '    WI_SA1142.ReportView.LoadView("WI_SA1142", "", "wi_sa1140_print", p, Nothing, False, 1, "sub", "wi_sa1140_print_sub", p1) ' 바로출력

    'End Sub
End Class
