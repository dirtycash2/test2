﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class QML200

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        clm_no.CodeNo = "QML200"        'Function dbo.[fnCodeNo]안에 코딩을 해야 한다
        clm_no.CodeDateField = clm_dt

        pnlshow.Visible = False

        MyBase.Open()

    End Sub
    'Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    pnlshow.Visible = False
    'End Sub

    Public Overrides Function Save() As Boolean
        If MyBase.Save() Then
            Dim saveID As String = clm_no.Text

            MyBase.Open()
            g10.Find("clm_no=" + saveID)
        End If
    End Function

    Public Overrides Sub Delete()
        Me.WorkSet("qml200_f10").DeleteRow()
        MyBase.Open()
    End Sub

    Public Overrides Sub NewForm()
        clm_no.Text = ""
        Me.OpenTrigger("qml200_g10")
    End Sub

    Private Sub btn_show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show.Click
        pnlshow.Visible = Not pnlshow.Visible
    End Sub

End Class
