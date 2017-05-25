﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports Base7.Functions

Public Class GAD102

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlshow.Visible = False
        'Me.Open()

    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open

                Me.Open()

            Case MenuType.Save

            Case MenuType.Print
                Me.Print()

            Case MenuType.New
                'bs_cd.Text = ""
                work_bc.Text = ""
                emp_no.Text = ""
                emp_nm.Text = ""
                'fr_dt.Text = ""               
                dept_cd.Text = ""

                Me.Open()

            Case Else
                MyBase.MenuButton_Click(mty)
        End Select

    End Sub
    Private Sub Print()
        Dim p As OpenParameters = New OpenParameters
        p.Add("@co_cd", co_cd.Text)
        p.Add("@bs_cd", bs_cd.Text)
        p.Add("@work_bc", work_bc.Text)
        p.Add("@fr_dt", fr_dt.Text)
        p.Add("@dept_cd", dept_cd.Text)
        p.Add("@emp_no", emp_no.Text)
        p.Add("@emp_nm", emp_nm.Text)

        System7.ReportView.LoadView("GAD102", "", "gad102_print", p)


    End Sub



    Private Sub btn_show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show.Click
        pnlshow.Visible = Not pnlshow.Visible
    End Sub

End Class
