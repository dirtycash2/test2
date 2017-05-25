﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports System.Data
Imports System.Collections

Public Class WI_PR1123
    Dim p As New OpenParameters

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If find_visible2.Checked Then MenuButton_Click(MenuType.Find)
        Me.Clear()
        'Me.Open()

        'MenuButton_Click(MenuType.Find)
    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
                'Me.Open()
                '    'Open_Form()
            Case MenuType.Save
                If Not Saves() Then Exit Sub

            Case MenuType.Cancel
                temp_lot_no.Text = ""
                Me.Clear()

            Case MenuType.Confirm
                If Not ConFrim() Then Exit Sub

            Case MenuType.Deconfirm
                If Not DeConFrim() Then Exit Sub

            Case MenuType.Find
                Me.Find()

            Case MenuType.Delete
                If Not Del() Then Exit Sub

                'Case MenuType.New
                'New_Form()

            Case Else
                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

        End Select

    End Sub

    Private Sub New_Form()
        'Clear()

        g_body1.AddNewRow()
    End Sub

    Private Function Saves() As Boolean

        If Check_Stts() = "C" Then '상태값 CHECK
            MsgBox("확인된 자료입니다.!")
            Return False
        End If

        Me.totQty()

        If job_qty.ToDec < tot_qty.ToDec Then
            MsgBox("합계수량이 지시수량보다 많습니다.!")
            Return False
        End If


        If MessageYesNo("저장 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            Max_NO()  '전표채번..

            If MyBase.Save() Then
                'MyBase.OpenTrigger("wi_sa1120_list")
            Else
                Return False
            End If

            stts.Text = "S"
        End If

        '거래처 체크
        If Not Me.Check_CsCd() Then
            Return False
        End If

        Return True
    End Function

    Private Function Check_Stts() As String
        p.Clear()
        p.Add("@pr_no", pr_no.Text)

        Dim dSet As Data.DataSet = Me.OpenDataSet("WI_PR1123_stts", p)
        Dim stts As String = "S"

        If Not IsEmpty(dSet) Then stts = DataValue(dSet)

        Return stts

    End Function

    Private Sub Max_NO()
        ' p/o 번호 채번
        pr_no.CodeNo = "WI_PR1123"        'Function dbo.[fnCodeNo]안에 LEB100에 대한 코딩을 해야 한다
        pr_no.CodeDateField = pr_dt

    End Sub

    Private Function Del() As Boolean

        If pr_no.Text = Nothing Then
            MsgBox("자료를 확인하세요.!")
            Return False
        End If

        '상태값 CHECK
        If Check_Stts() = "C" Then
            MsgBox("확인된 자료입니다.!")
            Return False
        End If

        If MessageYesNo("삭제 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            p.Clear()
            p.Add("@pr_no", pr_no.Text)

            Me.Open("WI_PR1123_delete", p)

            Me.Clear()

            g_list.Open()

        End If

        Return True
    End Function

    Private Function ConFrim() As Boolean

        If pr_no.Text = Nothing Then
            MsgBox("자료를 확인하세요.!")
            Return False
        End If

        '상태값 CHECK
        If Check_Stts() = "C" Then
            MsgBox("확인된 자료입니다.!")
            Return False
        End If

        If MessageYesNo("확인 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            'Me.Open("WI_PR1123_confirm")

            p.Clear()
            p.Add("@pr_no", pr_no.Text)
            p.Add("@stts", "C")

            Me.Open("WI_PR1123_confirm", p)

            stts.Text = "C"
        End If

        Return True
    End Function

    Private Function DeConFrim() As Boolean

        If pr_no.Text = Nothing Then
            MsgBox("자료를 확인하세요.!")
            Return False
        End If

        '상태값 CHECK
        If Check_Stts() <> "C" Then
            MsgBox("확인된 자료가 아닙니다.!")
            Return False
        End If

        If Check_deconfirm() = "Y" Then
            MsgBox("재고가 부족하여 취소할수 없습니다.!")
            Return False
        End If

        If MessageYesNo("확인취소 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            p.Clear()
            p.Add("@pr_no", pr_no.Text)
            p.Add("@stts", "S")

            Me.Open("WI_PR1123_confirm", p)

            stts.Text = "S"
        End If

        Return True
    End Function

    Private Function Check_deconfirm() As String
        p.Clear()
        p.Add("@PR_NO", pr_no.Text)

        Dim dSet As Data.DataSet = Me.OpenDataSet("wi_pr1123_deconfirm", p)
        Dim stts As String = "N"

        If Not IsEmpty(dSet) Then stts = DataValue(dSet)

        Return stts

    End Function

    Private Function Check_CsCd() As Boolean
        Try
            Return True

        Catch ex As Exception
            MessageInfo(ex)
        End Try
    End Function

    Private Sub Clear()
        p.Clear()
        p.Add("@pr_no", "XXX")

        Me.Open("WI_PR1123_head", p)
        Me.Open("WI_PR1123_body", p)
        Me.Open("WI_PR1123_body1", p)
        Me.Open("WI_PR1123_body2", p)
        Me.Open("WI_PR1123_body3", p)
        Me.Open("WI_PR1123_body4", p)
        Me.Open("WI_PR1123_body5", p)

    End Sub
    Public Sub Open3(ByVal OUTRNO As String) ', ByVal OUTRDT As String) ', ByVal faccd As String, ByVal whcd As String) ' ByVal outwh As String,

        pr_no.Text = OUTRNO
        p.Clear()
        p.Add("@pr_no", pr_no.Text)
        Me.Open("WI_PR1123_head", p)
        Me.Open("WI_PR1123_body", p)
        Me.Open("WI_PR1123_body1", p)
        Me.Open("WI_PR1123_body2", p)
        Me.Open("WI_PR1123_body3", p)
        Me.Open("WI_PR1123_body4", p)
        Me.Open("WI_PR1123_body5", p)


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
        p.Add("@find_gd_nm", "XXX")
        p.Add("@find_stts", find_stts.Text)
        p.Add("@@find_lot_no", find_lot_no.Text)

        Me.Open("WI_PR1123_list", p)
    End Sub

    Private Sub find_Clear2()
        p.Clear()
        p.Add("@find_from2", find_from2.Text)
        p.Add("@find_to2", find_to2.Text)
        p.Add("@find_gd_nm2", "XXX")
        p.Add("@find_job_no2", find_job_no2.Text)
        p.Add("@@find_lot_no2", find_lot_no2.Text)

        Me.Open("WI_PR1123_list2", p)
    End Sub

    Private Sub totQty()
        Dim sum_amt As Double

        With g_body1
            .UpdateRow()
            For i As Integer = 0 To .RowCount - 1
                sum_amt = sum_amt + .ToDec("NG_QTY", i)
            Next
        End With
        ng_qty.Text = sum_amt.ToString
        tot_qty.Text = pr_qty.ToDec + ng_qty.ToDec + sample_qty.ToDec
    End Sub

    'Private Sub rate_TextChanged(ByVal sender As Object, ByVal oldValue As String) Handles Rate.TextChanged
    '    won_amt.Text = bal_amt.ToDec * Rate.ToDec
    'End Sub

    Private Sub btn_find2_Click(sender As Object, e As System.EventArgs) Handles btn_find2.Click
        g_list2.Open()
    End Sub

    Private Sub g_list2_DoubleClick(sender As Object, e As System.EventArgs) Handles g_list2.DoubleClick
        Me.Clear()
        'lot_no.Text = g_list2.Text("LOT_NO", g_list2.RowIndex)
        temp_lot_no.Text = g_list2.Text("LOT_NO", g_list2.RowIndex)
        'setJobNO()

        'pr_jobno.Text = g_list2.Text("JOB_NO", g_list2.RowIndex)
        'job_no.Text = g_list2.Text("JOB_NO", g_list2.RowIndex)
        'job_seq.Text = g_list2.Text("JOB_SEQ", g_list2.RowIndex)
        'gong_cd.Text = g_list2.Text("GONG_CD", g_list2.RowIndex)
        'wa_cd.Text = g_list2.Text("WA_CD", g_list2.RowIndex)
        'mc_cd.Text = g_list2.Text("MC_CD", g_list2.RowIndex)
        'job_qty.Text = g_list2.Text("JOB_QTY", g_list2.RowIndex)
        'gd_cd.Text = g_list2.Text("GD_CD", g_list2.RowIndex)
        'gd_nm.Text = g_list2.Text("GD_NM", g_list2.RowIndex)
        'spec.Text = g_list2.Text("SPEC", g_list2.RowIndex)
        'unit_cd.Text = g_list2.Text("UNIT_CD", g_list2.RowIndex)
        'new_gdcd.Text = g_list2.Text("GD_CD", g_list2.RowIndex)

        If find_visible2.Checked Then MenuButton_Click(MenuType.Find)
    End Sub

    Private Sub ng_qty_TextChanged(sender As Object, oldValue As String) Handles ng_qty.TextChanged
        With g_body
            .UpdateRow()
            For i As Integer = 0 To .RowCount - 1
                .Text("TUIP_QTY", i) = .ToDec("SO_QTY", i) * (pr_qty.ToDec + ng_qty.ToDec + sample_qty.ToDec)
            Next
        End With
        Me.totQty()

    End Sub

    Private Sub pr_qty_TextChanged(sender As Object, oldValue As String) Handles pr_qty.TextChanged
        With g_body
            .UpdateRow()
            For i As Integer = 0 To .RowCount - 1
                .Text("TUIP_QTY", i) = .ToDec("SO_QTY", i) * (pr_qty.ToDec + ng_qty.ToDec + sample_qty.ToDec)
            Next
        End With

        Me.totQty()
    End Sub


    Private Sub btn_find_Click(sender As Object, e As System.EventArgs) Handles btn_find.Click
        g_list.Open()
    End Sub

    Private Sub btn_cancel2_Click(sender As Object, e As System.EventArgs) Handles btn_cancel2.Click
        find_Clear2()
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As System.EventArgs) Handles btn_cancel.Click
        find_Clear()
    End Sub

    Private Sub g_list_DoubleClick(sender As Object, e As System.EventArgs) Handles g_list.DoubleClick
        temp_lot_no.Text = ""

        p.Clear()
        p.Add("@pr_no", g_list.Text("PR_NO", g_list.RowIndex))

        Me.Open("WI_PR1123_head", p)
        Me.Open("WI_PR1123_body", p)
        Me.Open("WI_PR1123_body1", p)
        Me.Open("WI_PR1123_body2", p)
        Me.Open("WI_PR1123_body3", p)
        Me.Open("WI_PR1123_body4", p)
        Me.Open("WI_PR1123_body5", p)

        If find_visible.Checked Then MenuButton_Click(MenuType.Find)
    End Sub

    'Private Sub pr_jobno_TextChanged(sender As Object, oldValue As String) Handles pr_jobno.TextChanged
    '    'Me.Clear()

    '    setJobNO()
    'End Sub

    Private Sub setJobNO()

        If lot_no.Text = Nothing Then Exit Sub
        If gong_cd.Text = Nothing Then Exit Sub

        Dim s_pr_jobno As String = "", s_gong_cd As String = ""

        s_pr_jobno = lot_no.Text
        s_gong_cd = gong_cd.Text

        p.Clear()
        p.Add("@lot_no", lot_no.Text)
        p.Add("@gong_cd", gong_cd.Text)

        Dim dSet As Data.DataSet = Me.OpenDataSet("WI_PR1123_jobno", p)

        'Me.Clear()

        If Not IsEmpty(dSet) Then
            Dim dRow As DataRow, dRows As DataRowCollection
            dRows = dSet.Tables(0).Rows

            For Each dRow In dRows
                job_no.Text = ToStr(dRow("job_no"))
                job_seq.Text = ToStr(dRow("job_seq"))
                pr_jobno.Text = ToStr(dRow("job_no"))
                wa_cd.Text = ToStr(dRow("wa_cd"))
                mc_cd.Text = ToStr(dRow("mc_cd"))
                job_qty.Text = ToStr(dRow("job_qty"))
                gd_cd.Text = ToStr(dRow("gd_cd"))
                gd_nm.Text = ToStr(dRow("gd_nm"))
                spec.Text = ToStr(dRow("spec"))
                unit_cd.Text = ToStr(dRow("unit_cd"))
                new_gdcd.Text = ToStr(dRow("gd_cd"))
                'ja_cd.Text = ToStr(dRow("ja_cd"))
                'lot_no.Text = ToStr(dRow("lot_no"))

            Next
        Else
            Me.Clear()
            'pr_jobno.Text = s_pr_jobno
            'gong_cd.Text = s_gong_cd
            Exit Sub
        End If

        p.Clear()
        p.Add("@pr_no", "XXXX")
        Me.Open("WI_PR1123_body", p)
        Me.Open("WI_PR1123_body1", p)
        Me.Open("WI_PR1123_body2", p)
        Me.Open("WI_PR1123_body3", p)
        Me.Open("WI_PR1123_body4", p)
        Me.Open("WI_PR1123_body5", p)


        p.Clear()
        p.Add("@GD_CD", gd_cd.Text)
        p.Add("@GONG_CD", gong_cd.Text)

        dSet = Me.OpenDataSet("WI_PR1123_bom", p)
        Dim ll_row As Integer = 0

        If Not IsEmpty(dSet) Then
            Dim dRow As DataRow, dRows As DataRowCollection
            dRows = dSet.Tables(0).Rows

            With g_body
                ll_row = .RowIndex
                For Each dRow In dRows
                    .InsertNewRow(ll_row)

                    .Text("GD_CD", ll_row) = ToStr(dRow("JA_CD"))
                    .Text("GD_NM", ll_row) = ToStr(dRow("GD_NM"))
                    '.Text("SPEC", ll_row) = ToStr(dRow("SPEC"))
                    .Text("SO_QTY", ll_row) = ToStr(dRow("QTY"))
                    .Text("TUIP_QTY", ll_row) = ToStr(dRow("QTY") * job_qty.ToDec)

                    'If ja_cd.Text = .Text("GD_CD", ll_row) Then
                    .Text("LOT_NO", ll_row) = lot_no.Text

                    'End If

                Next
            End With
        Else
            Exit Sub
        End If

    End Sub

    Private Sub gong_cd_TextChanged(sender As Object, e As System.EventArgs) Handles gong_cd.TextChanged
        setJobNO()
    End Sub

    Private Sub lot_no_TextChanged(sender As Object, oldValue As String) Handles lot_no.TextChanged
        setJobNO()
    End Sub

    Private Sub temp_lot_no_TextChanged(sender As Object, oldValue As String) Handles temp_lot_no.TextChanged
        Me.Clear()

        lot_no.Text = temp_lot_no.Text
    End Sub

    Private Sub g_body1_CellValueChanged1(sender As Object, ColumnName As String, RowIndex As Integer, ByRef Value As Object) Handles g_body1.CellValueChanged
        If g_body1.FieldName(g_body1.ColumnIndex + 1) <> "NG_QTY" Then Exit Sub
        'MsgBox(g_body1.FieldName(g_body1.ColumnIndex))
        totQty()
    End Sub

    Private Sub find_lot_no_TextChanged(sender As Object, oldValue As String) Handles find_lot_no.TextChanged
        g_list.Open()
    End Sub

    Private Sub find_lot_no2_TextChanged(sender As Object, oldValue As String) Handles find_lot_no2.TextChanged
        g_list2.Open()
    End Sub

    Private Sub sample_qty_TextChanging(sender As System.Object, newValue As System.String, oldValue As System.String, ByRef cancel As System.Boolean) Handles sample_qty.TextChanging
        With g_body
            .UpdateRow()
            For i As Integer = 0 To .RowCount - 1
                .Text("TUIP_QTY", i) = .ToDec("SO_QTY", i) * (pr_qty.ToDec + ng_qty.ToDec + sample_qty.ToDec)
            Next
        End With

        Me.totQty()
    End Sub
End Class
