﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports System.Data

Public Class FAB530

    Private Sub btn_jump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_jump.Click
        Add_Origin_Rows()
    End Sub



    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)

        Select Case mty

            Case MenuType.Open

                MyBase.Open()

                '    Case Else
                '        MyBase.MenuButton_Click(mty)

        End Select

    End Sub


    'Private Function Add_Origin_Rows() As Boolean

    '    If g10.CheckedRows("chk") = 0 Then
    '        Return True
    '    End If

    '    Me.Save()

    '    ''전표화면 찾기
    '    Dim menuName As String = "FAB100"
    '    Dim ctr As Object = Parameter.MainFrame.Frame.CallMenuForm(menuName)

    '    ''ctr.Set_Origin_Rows(g10) ', "1")

    'End Function

    Private Sub Add_Origin_Rows()
        If Not CheckRequired(pay_kd) Then
            Exit Sub
        End If

        Dim dSet As DataSet = Me.OpenDataSet("fab530_acc_cd")
        Dim accCd As String = DataValue(dSet)
        If accCd = "" Then
            MessageInfo(pay_kd.EditText + ": 계정코드가 설정되지 않았습니다 (기초코드에서 설정)")
            Exit Sub
        End If

        If g10.CheckedRows("chk") = 0 Then
            Exit Sub
        End If


        Me.Save()

        '전표화면 찾기
        Dim menuName As String = "FAB100"
        Dim ctr As Object = Parameter.MainFrame.Frame.CallMenuForm(menuName)
        ctr.Set_Origin_Rows3(g10, accCd, pay_kd.Text, bank_cd.Text, bank_cd.EditText, acct_no.Text, acct_no.EditText, iss_dt.Text, end_dt.Text, "", cust_yn.Text)

    End Sub


    Private Sub g10_CellValueChanging(ByVal sender As Object, ByVal ColumnName As String, ByVal RowIndex As Integer, ByRef Value As Object) Handles g10.CellValueChanging
        With g10
            If ColumnName = "chk" Then
                If Value = "1" Then
                    g10.Text("set_amt") = g10.ToDec("rem_amt")
                Else
                    g10.Text("set_amt") = ""
                End If

                Dim chk As Boolean, sum As Decimal
                For i As Integer = 0 To g10.RowCount - 1
                    If i = g10.RowIndex Then
                        chk = ToBool(Value)
                    ElseIf g10.ToBool("chk", i) Then
                        chk = g10.ToBool("chk", i)
                    End If
                    If chk Then
                        sum += g10.ToDec("set_amt", i)
                    End If
                Next
                sel_amt.Text = sum

            End If
        End With
    End Sub

    Private Sub g10_CellValueChanged(ByVal sender As Object, ByVal ColumnName As String, ByVal RowIndex As Integer, ByRef Value As Object) Handles g10.CellValueChanged
        With g10
            If ColumnName = "set_amt" Then
                If .ToDec("set_amt") <> 0 Then
                    If .ToDec("rem_amt") < .ToDec("set_amt") Then
                        MessageInfo("잔액보다 많을 수 없습니다")
                        .CancelRowChanges()
                        Exit Sub
                    End If
                End If
            End If

            If ColumnName = "fix_amt" Then
                'rem_amt  = isnull(a.doc_amt,0) - isnull(pay_amt,0) - isnull(fix_amt, 0),
                .Text("rem_amt") = .ToDec("doc_amt") - .ToDec("pay_amt") - .ToDec("fix_amt")
            End If

        End With
    End Sub

    Private Sub chk_all_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk_all.CheckedChanged

        g10.CheckRows("chk", chk_all.Checked)

    End Sub


End Class
