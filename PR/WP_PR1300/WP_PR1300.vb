﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports System.Data

Public Class WP_PR1300
     Private Sub Me_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        With g10
            'Master 부분(왼쪽꺼)
            .GridColumn("tm_cd").IsMasterKey = True
            .GridColumn("ps_cd").IsMasterKey = True
            .GridColumn("ps_nm").IsMasterKey = True

            .GridColumn("test_sum").IsMasterData = True
            .GridColumn("pr_sum").IsMasterData = True
            .GridColumn("avg_time").IsMasterData = True
            .GridColumn("t_test").IsMasterData = True
            .GridColumn("t_pr").IsMasterData = True
            .GridColumn("rt").IsMasterData = True
            .GridColumn("rmks").IsMasterData = True
            .GridColumn("bad_rt").IsMasterData = True

            'Detail 부분
            .GridColumn("std_mon").IsDetailKey = True

            'Multi Column 으로 정의 시 2개이상의 컬럼이 DetailData 로 정의되어야 한다
            .GridColumn("test_qty").IsDetailData = True
            .GridColumn("pr_qty").IsDetailData = True

        End With

    End Sub

    Public Overrides Sub Open()

        Me.Init_Title()
        MyBase.Open()

    End Sub
    Private Sub Init_Title()

        '1. 컬럼배열을 만든다

        Dim frDt As Date = Mid(fr_mon.Text, 1, 7) + "-01"
        Dim toDt As Date = Mid(to_mon.Text, 1, 7) + "-01"

        Dim cnt As Integer = DateDiff(DateInterval.Month, frDt, toDt) + 1
        MsgBox(ToStr(cnt))

        Dim arr(1, 0) As String, colNm As String
        For i = 0 To cnt - 1
            ReDim Preserve arr(1, i)     'Array를 증가시킨다

            colNm = Format(DateAdd(DateInterval.Month, i, frDt), "yyyy-MM")
            arr(0, i) = colNm            'FieldName
            arr(1, i) = colNm.Substring(0, 4) + "년 " + colNm.Substring(5, 2) + "월" 'Title

            MsgBox(ToStr(colNm))


        Next

        g10.InsertMultiColumns(arr)

    End Sub

  
End Class
