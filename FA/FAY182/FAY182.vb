﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports System.Data

Public Class FAY182

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)

        Select Case mty

            Case MenuType.Open

                Me._Open()

            Case Else
                MyBase.MenuButton_Click(mty)
        End Select

    End Sub

    Public Sub _Open()

        'MsgBox(Calculator("  (22,000*3  /3*(4+ 55.0 *6+(2/1+2)) / 2 -  2   )  "))   '3717998

        '화면 컬럼의 생성
        Me.Init_Title()

        'Data Display
        Me.Disp_Data()

    End Sub

    'Case 2. 년월 기간의 Title 배열
    Private Sub Init_Title()

        '1. 컬럼배열을 만든다
        Dim dSet As DataSet = Me.OpenDataSet("fay182_title")
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

        '2. 화면에 Array Column을 Unbound로 Insert 또는 Add 한다
        ' Ex) g10.InsertColumn("A", arr, "B")
        '     "A" 컬럼이후에 삽입된다
        '     "A" 자리에 Nothing을 쓰면 Arry Column들이 마지막에 추가된다
        '     "B" 컬럼에 설정된 특성으로 Array의 수 만큼 새로운 컬럼을 만든다

        g10.InsertArrayColumns("tot", arr, "amt")

    End Sub

    '첫번째 Display 방법: 기본기능을 이용
    Private Sub Disp_Data()
        Try
            'Master 부분
            g10.GridColumn("acc_cd").IsMasterKey = True
            g10.GridColumn("acc_nm").IsMasterData = True
            g10.GridColumn("tot").IsMasterData = True

            'Detail 부분
            g10.GridColumn("dept_cd").IsDetailKey = True
            g10.GridColumn("amt").IsDetailData = True

            MyBase.Open()

        Catch ex As Exception

            MessageInfo(ex, "Disp_Data()")

        End Try
    End Sub

    Private Sub g10_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles g10.DoubleClick
        Dim menuName As String = "FAB101"
        '화면을 띄운다
        Dim ctr As Object = Parameter.MainFrame.Frame.CallMenuForm(menuName) 'New FormAttribute(menuName, menuText))
        If ctr IsNot Nothing Then
            'ctr.Open2(g10.Text("acc_cd"), fr_mon.Text, to_mon.Text)
            ctr.Open3(g10.Text("acc_cd"), g10.FocusedFieldName, fr_mon.Text, to_mon.Text)

        End If
    End Sub


End Class
