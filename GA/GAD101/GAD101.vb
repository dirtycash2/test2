﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class GAD101

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlshow.Visible = False
        Init_Form()
    End Sub

    Public Sub Init_Form()
        g20.SelectRow = True
        g30.SelectRow = True

        show_ty.AddItem("0", "사원")
        show_ty.AddItem("1", "일자")
        show_ty.AddItem("3", "전체")

        show_ty.Text = "0"
    End Sub

    Public Overrides Sub Open()
        Try
            Me._ShowGrid()

            If show_ty.Text = "0" Then
                g20.Open()
            End If
            If show_ty.Text = "1" Then
                g30.Open()
            End If

            If show_ty.Text = "3" Then
                g10.Open()
            End If

        Catch ex As Exception
            MessageError(ex)
        End Try
    End Sub

    Private Sub _ShowGrid()
        If show_ty.Text = "3" Then
            SplitContainer2.Panel1Collapsed = True
        Else
            SplitContainer2.Panel1Collapsed = False
            EPanel2.Text = show_ty.EditText
            If show_ty.Text = "0" Then
                g20.BringToFront()
            End If
            If show_ty.Text = "1" Then
                g30.BringToFront()
            End If
        End If
    End Sub

    Private Sub show_ty_TextChanged(ByVal sender As Object, ByVal oldValue As String) Handles show_ty.TextChanged
        Me.Open()

        g10.ColumnVisible("work_dt") = (show_ty.Text = "0" Or show_ty.Text = "3" Or show_ty.Text = "1")
        g10.ColumnVisible("weekday") = (show_ty.Text = "0" Or show_ty.Text = "3")
        g10.ColumnVisible("dt_bc") = (show_ty.Text = "0" Or show_ty.Text = "3" Or show_ty.Text = "1")
        g10.ColumnVisible("emp_no") = (show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("emp_nm") = (show_ty.Text = "1" Or show_ty.Text = "3")
        ' g10.ColumnVisible("dept_nm") = (show_ty.Text = "1" Or show_ty.Text = "3")
        'g10.ColumnVisible("work_bc") = (show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("work_kd") = (show_ty.Text = "1" Or show_ty.Text = "3")
        ' g10.ColumnVisible("grp_bc") = (show_ty.Text = "1" Or show_ty.Text = "3")
    End Sub

    Private Sub g20_AfterMoveRow(ByVal sender As Object, ByVal PrevRowIndex As Integer, ByVal RowIndex As Integer) Handles g20.AfterMoveRow

        Dim p As OpenParameters = New OpenParameters

        p.Add("@co_cd", co_cd.Text)
        p.Add("@bs_cd", bs_cd.Text)
        p.Add("@work_bc", work_bc.Text)
        p.Add("@work_kd", work_kd.Text)
        p.Add("@grp_bc", grp_bc.Text)
        p.Add("@fr_dt", fr_dt.Text)
        p.Add("@to_dt", to_dt.Text)
        p.Add("@dept_cd", dept_cd.Text)
        p.Add("@emp_no", g20.Text("emp_no"))
        p.Add("@emp_nm", emp_nm.Text)
        p.Add("@sub_yn", sub_yn.Text)

        g10.Open(p)

    End Sub

    Private Sub g30_AfterMoveRow(ByVal sender As Object, ByVal PrevRowIndex As Integer, ByVal RowIndex As Integer) Handles g30.AfterMoveRow

        Dim p As OpenParameters = New OpenParameters

        p.Add("@co_cd", co_cd.Text)
        p.Add("@bs_cd", bs_cd.Text)
        p.Add("@work_bc", work_bc.Text)
        p.Add("@work_kd", work_kd.Text)
        p.Add("@grp_bc", grp_bc.Text)
        p.Add("@fr_dt", g30.Text("dt"))
        p.Add("@to_dt", g30.Text("dt"))
        p.Add("@dept_cd", dept_cd.Text)
        p.Add("@emp_no", emp_no.Text)
        p.Add("@emp_nm", emp_nm.Text)
        p.Add("@sub_yn", sub_yn.Text)

        g10.Open(p)

    End Sub


    'Private Sub but_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For i As Integer = 0 To g10.RowCount - 1
    '        g10.Text("ok_yn", i) = "1"
    '    Next
    'End Sub

    'Private Sub but_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    For i As Integer = 0 To g10.RowCount - 1
    '        g10.Text("ok_yn", i) = "0"
    '    Next
    'End Sub


    Private Sub btn_show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show.Click
        pnlshow.Visible = Not pnlshow.Visible
    End Sub

End Class
