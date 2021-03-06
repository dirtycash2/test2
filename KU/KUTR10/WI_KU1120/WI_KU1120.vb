﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class WI_KU1120
    Dim stts As String
    Dim p As New OpenParameters

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Clear()

        'MenuButton_Click(MenuType.Find)
    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
                '    'Me.Open()
                '    'Open_Form()
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
        'Clear()

        g_body.AddNewRow()
    End Sub

    Private Function Saves() As Boolean

        If Check_Stts() = "C" Then '상태값 CHECK
            MsgBox("확인된 자료입니다.!")
            Return False
        End If

        Me.BalAmt()

        If MessageYesNo("저장 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            Max_NO()  '전표채번..

            If MyBase.Save() Then
                'MyBase.OpenTrigger("wi_sa1120_list")
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
        p.Add("@bal_no", bal_no.Text)

        Dim dSet As Data.DataSet = Me.OpenDataSet("wi_ku1120_stts", p)
        Dim stts As String = "S"

        If Not IsEmpty(dSet) Then stts = DataValue(dSet)

        Return stts

    End Function

    Private Sub Max_NO()
        ' p/o 번호 채번
        bal_no.CodeNo = "WI_KU1120"        'Function dbo.[fnCodeNo]안에 LEB100에 대한 코딩을 해야 한다
        bal_no.CodeDateField = bal_dt
    End Sub

    Private Function Del() As Boolean

        If bal_no.Text = Nothing Then
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
            p.Add("@bal_no", bal_no.Text)

            Me.Open("wi_ku1120_delete", p)

            Me.Clear()

            g_list.Open()

        End If

        Return True
    End Function

    Private Function ConFrim() As Boolean

        If bal_no.Text = Nothing Then
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
            'Me.Open("wi_ku1120_confirm")

            p.Clear()
            p.Add("@bal_no", bal_no.Text)
            p.Add("@stts", "C")

            Me.Open("wi_ku1120_confirm", p)
        End If

        Return True
    End Function

    Private Function DeConFrim() As Boolean

        If bal_no.Text = Nothing Then
            MsgBox("자료를 확인하세요.!")
            Return False
        End If

        '상태값 CHECK
        If Check_Stts() <> "C" Then
            MsgBox("확인된 자료가 아닙니다.!")
            Return False
        End If

        If MessageYesNo("확인취소 하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        Else
            p.Clear()
            p.Add("@bal_no", bal_no.Text)
            p.Add("@stts", "S")

            Me.Open("wi_ku1120_confirm", p)
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

    Private Sub g_body_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles g_body.DoubleClick
        Dim popup As New Form1

        If g_body.ColumnIndex <> 1 Then Exit Sub

        popup.InitPopup()

        If popup.ShowDialog() = DialogResult.OK Then
            If popup.ActiveControl.Tag IsNot Nothing Then
                Dim pReturn As eGrid = popup.ActiveControl.Tag
                Dim ll_row As Integer
                ll_row = g_body.RowIndex

                'i = g_body.RowIndex
                'popup.ActiveControl.Tag = Nothing
                ' 결과 파라미터를 받아서 처리할경우
                'pReturn.Find()

                'pReturn.AllowFilter.
                'pReturn.Find("1")

                ''멀티 선택시 ..
                For i = 0 To pReturn.RowCount - 1
                    If pReturn.Text("CHK", i) = "1" Then
                        'g_body.AddNewRow()

                        g_body.Text("GD_CD") = pReturn.Text("GD_CD", i)
                        g_body.Text("GD_NM") = pReturn.Text("GD_NM", i)

                        ll_row = ll_row + 1

                        g_body.InsertNewRow(ll_row)
                    End If
                Next

                g_body.DeleteRow(ll_row)


            Else
                ' 결과 파라미터가 없는경우
            End If

        Else
        End If
    End Sub

    Private Sub BalAmt()
        Dim sum_amt As Double

        With g_body
            .UpdateRow()
            For i As Integer = 0 To .RowCount - 1
                sum_amt = sum_amt + .ToDec("BAL_AMT", i)
            Next
        End With

        bal_amt.Text = sum_amt
        won_amt.Text = sum_amt * rate.ToDec
    End Sub

    Private Sub Clear()
        p.Clear()
        p.Add("@bal_no", "XXX")

        Me.Open("wi_ku1120_head", p)
        Me.Open("wi_ku1120_body", p)
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

        Me.Open("wi_ku1120_list", p)
    End Sub

    Private Sub btn_find_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_find.Click
        g_list.Open()
    End Sub

    Private Sub g_body_CellValueChanged(ByVal sender As System.Object, ByVal ColumnName As System.String, ByVal RowIndex As System.Int32, ByRef Value As System.Object) Handles g_body.CellValueChanged
        With g_body
            If ColumnName = "BAL_QTY" Or ColumnName = "BAL_PRI" Then
                .Text("BAL_AMT") = .ToDec("BAL_QTY") * .ToDec("BAL_PRI")
                Me.BalAmt()
            End If


        End With
    End Sub

    Private Sub rate_TextChanged(ByVal sender As Object, ByVal oldValue As String) Handles rate.TextChanged
        won_amt.Text = bal_amt.ToDec * rate.ToDec
    End Sub

    Private Sub g_list_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles g_list.DoubleClick
        p.Clear()
        p.Add("@bal_no", g_list.Text("BAL_NO", g_list.RowIndex))

        Me.Open("wi_ku1120_head", p)
        Me.Open("wi_ku1120_body", p)

        If find_visible.Checked Then MenuButton_Click(MenuType.Find)
    End Sub

    Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.find_Clear()

    End Sub
End Class
