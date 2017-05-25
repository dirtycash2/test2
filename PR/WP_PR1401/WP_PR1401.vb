﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class WP_PR1401

    Private Sub Me_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'Me.Init_Title()
        'Me.disp()

    End Sub

    Public Overrides Sub Open()

        Me.Init_Title()
        Me.disp()
        'MyBase.Open()

    End Sub

#Region " 1. Grid 컬럼 초기화 "

    'Case 1. DataSet을 이용한 Title 배열
    Private Sub Init_Title()


        Dim dSet As DataSet = Me.OpenDataSet("wp_pr1401_title")
        If IsEmpty(dSet) Then
            MessageInfo("조회 할 Data가 없습니다")
            Exit Sub
        End If

        Dim arr(1, 0) As String, inx As Integer = 0
        For Each dRow In dSet.Tables(0).Rows
            ReDim Preserve arr(1, inx)      'Array를 증가시킨다

            arr(0, inx) = dRow(0)           'FieldName 으로 사용된다
            arr(1, inx) = dRow(1)           'Title로 사용된다

            inx += 1
        Next

        g_result.InsertArrayColumns(Nothing, arr, "spec90")
        '  g10.InsertMultiColumns(arr)


    End Sub

    Private Sub disp()
        With g_result
            'Master 부분
            .GridColumn("gd_nm").IsMasterKey = True
            .GridColumn("spec10").IsMasterKey = True
            .GridColumn("spec20").IsMasterKey = True
            .GridColumn("spec30").IsMasterKey = True
            .GridColumn("spec40").IsMasterKey = True
            .GridColumn("spec50").IsMasterKey = True
            .GridColumn("spec60").IsMasterKey = True
            .GridColumn("spec70").IsMasterKey = True
            .GridColumn("spec80").IsMasterKey = True
            .GridColumn("spec90").IsMasterKey = True

            '20130307 제품군 추가 양홍석
            ' .GridColumn("stock_qry").IsMasterKey = True
            ''''''''''''''''''
            ' .GridColumn("spec").IsMasterKey = True
            ''Me.Open()
            ''Detail 부분
            .GridColumn("wh_cd").IsDetailKey = True

            ''Multi Column 으로 정의 시 2개이상의 컬럼이 DetailData 로 정의되어야 한다
            .GridColumn("stock_qty").IsDetailData = True
            '  .GridColumn("pr_sum").IsDetailData = True
            Me.Open("wp_pr1401_g10")

        End With
    End Sub
#End Region

End Class
