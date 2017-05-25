﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class HRA100_HM

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        EPanel1.SetSplitter(SplitContainer1, SplitContainer1.Panel2)
        EPanel3.SetSplitter(SplitContainer1, SplitContainer1.Panel1)

        photo.Visible = False

        g10.SelectRow = True

    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open

                Me.OpenTrigger("hra100_hm_g10")

                Me.Open()

                Me.DisableFields(True)

            Case MenuType.Save

                If retr_dt.Text <> "" Then
                    If retr_bc.Text = "" Then
                        MsgBox("'퇴직구분' 입력은 필수 입니다.")
                        Exit Sub
                    End If
                    If retr_rmk.Text = "" Then
                        MsgBox("'퇴직사유' 입력은 필수 입니다.")
                        Exit Sub
                    End If
                    Me.Save()
                    Exit Sub
                End If

                If stat_bc.Text = "HR125400" Then
                    If retr_dt.Text = "" Then
                        MsgBox("'퇴사일자' 입력은 필수 입니다.")
                        Exit Sub
                    End If
                    If retr_bc.Text = "" Then
                        MsgBox("'퇴직구분' 입력은 필수 입니다.")
                        Exit Sub
                    End If
                    If retr_rmk.Text = "" Then
                        MsgBox("'퇴직사유' 입력은 필수 입니다.")
                        Exit Sub
                    End If
                    Me.Save()
                    Exit Sub
                End If

                If retr_dt.Text = "" Then
                    Me.Save()
                    Exit Sub
                End If


            Case MenuType.New

                Me._New()

            Case MenuType.Print
                Me.Print()
            Case Else
                MyBase.MenuButton_Click(mty)
        End Select

    End Sub

    Private Sub _New()
        emp_no.Text = ""

        Me.OpenTrigger("hra100_hm_g10")

        Me.DisableFields(False)
    End Sub

    Private Sub Print()

        Dim p As OpenParameters = New OpenParameters
        p.Add("@emp_no", emp_no.Text)

        System7.ReportView.LoadView("HRA100_HM", "", "hra100_hm_print", p, )

    End Sub

    Private Sub g40_CellValueChanged(ByVal sender As Object, ByVal ColumnName As String, ByVal RowIndex As Integer, ByRef Value As Object) Handles g40.CellValueChanged
        If ColumnName = "fr_dt" Or ColumnName = "to_dt" Then
            With g40
                If .Text("fr_dt") = Nothing Or .Text("to_dt") = Nothing Then
                    .Text("work_year") = 0
                    .Text("work_month") = 0
                Else
                    Dim WorkYear As Integer = DateDiff(DateInterval.Year, CDate(.Text("fr_dt")), CDate(.Text("to_dt"))) - 1
                    Dim WorkMonth As Integer = DateDiff(DateInterval.Month, CDate(.Text("fr_dt")), CDate(.Text("to_dt")))

                    If WorkYear < 0 Then WorkYear = 0

                    .Text("work_year") = WorkYear
                    .Text("work_month") = WorkMonth - (WorkYear * 12)

                    If .Text("work_month") >= 12 Then
                        .Text("work_year") = .Text("work_year") + 1
                        .Text("work_month") = .Text("work_month") - 12
                    End If

                End If

            End With

        End If

    End Sub

    Private Sub hire_dt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles hire_dt.TextChanged, f_retr_dt2.TextChanged, f_retr_dt1.TextChanged, f_hire_dt2.TextChanged, f_hire_dt1.TextChanged
        hire2_dt.Text = hire_dt.Text
    End Sub

    Private Sub reg_no_TextChanged(ByVal sender As Object, ByVal oldValue As String) Handles reg_no.TextChanged
        If reg_no.Text.Length > 7 Then

            If reg_no.Text.Substring(0, 2) > 30 Then
                bir_dt.Text = "19" + reg_no.Text.Substring(0, 2) + "-" + reg_no.Text.Substring(2, 2) + "-" + reg_no.Text.Substring(4, 2)
            Else
                bir_dt.Text = "20" + reg_no.Text.Substring(0, 2) + "-" + reg_no.Text.Substring(2, 2) + "-" + reg_no.Text.Substring(4, 2)
            End If
        Else
            MessageYesNo("주민번호를 확인 하시길 바랍니다.")
        End If

    End Sub


    Private Sub btn_pic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pic.Click, PictureBox3.Click
        If photo.Visible Then
            photo.Visible = False
            Me.SplitContainer4.SplitterDistance = 35
        Else
            photo.Visible = True
            Me.SplitContainer4.SplitterDistance = 127
        End If
    End Sub

    Private Sub g10_AfterMoveRow(ByVal sender As Object, ByVal PrevRowIndex As Integer, ByVal RowIndex As Integer) Handles g10.AfterMoveRow
        Me.OpenTrigger("hra100_hm_g10")

        Me.DisableFields(True)
    End Sub

    Private Sub DisableFields(ByVal yn As Boolean)
        bs_cd.ReadOnly = yn
        work_bs.ReadOnly = yn
        emp_no.ReadOnly = yn
        work_bc.ReadOnly = yn
        duty_bc.ReadOnly = yn
        rank_bc.ReadOnly = yn
        step_bc.ReadOnly = yn
        dept_cd.ReadOnly = yn
        pay_kd.ReadOnly = yn
    End Sub


    Private Sub retr_dt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles retr_dt.TextChanged

        If retr_dt.Text = "" Then
            stat_bc.Text = "HR125100"
            retr_bc.Text = ""
            retr_rmk.Text = ""
        End If
        If retr_dt.Text <> "" Then
            stat_bc.Text = "HR125400"
        End If
    End Sub

    Private Sub g10_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles g10.Load

    End Sub
End Class
