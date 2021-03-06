﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports System.Data



Public Class FAR280

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        use_chk.Checked = True
        Me.Open()
        Me.Open_Form()
    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
                MyBase.Open()
                Me.Open_Form()
            Case MenuType.Save

            Case Else
                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

        End Select

    End Sub

    Public Sub Open_Form()
        '화면 컬럼의 생성
        Me.Init_Title()
        'Data Display
        Me.Disp_Data()
    End Sub

    Private Sub Init_Title()
        Dim p As New OpenParameters
        p.Add("@div_cd", div_cd.Text)

        '1. 컬럼배열을 만든다
        Dim dSet As DataSet = Me.OpenDataSet("far280_title", p)
        If IsEmpty(dSet) Then
            MessageInfo("조회 할 Data가 없습니다")
            'g10.Init()
            Exit Sub
        End If

        Dim arr(1, 0) As String, inx As Integer = 0
        For Each dRow In dSet.Tables(0).Rows
            ReDim Preserve arr(1, inx)      'Array를 증가시킨다

            arr(0, inx) = dRow(0)           'FieldName 으로 사용된다
            arr(1, inx) = dRow(1)           'Title로 사용된다

            inx += 1
        Next
        g10.InsertArrayColumns(Nothing, arr, "app_amt")

    End Sub

    Private Sub Disp_Data()
        Try
            'Master 부분
            g10.GridColumn("acc_cd").IsMasterKey = True
            g10.GridColumn("acc_nm").IsMasterData = True
            g10.GridColumn("act_amt").IsMasterData = True
            'g10.GridColumn("use_amt").IsMasterData = True
            g10.GridColumn("app_amt").IsMasterData = True

            'Detail 부분
            g10.GridColumn("dept_cd").IsDetailKey = True
            g10.GridColumn("dept_amt").IsDetailData = True

            MyBase.Open()

        Catch ex As Exception
            MessageInfo(ex, "Disp_Data()")
        End Try
    End Sub


End Class
