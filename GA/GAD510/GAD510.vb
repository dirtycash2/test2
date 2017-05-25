﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class GAD510

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pnlCopy.Visible = False

    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)

        Select Case mty
            Case MenuType.Open
                Me.Init_Title3()
                Open()
            Case MenuType.Print

            Case Else
                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

        End Select

    End Sub

    Public Overrides Sub Open()

        '화면 컬럼의 생성

        Me.Disp_Data()


        '  Data(Display)
        '  Me.Disp_Data()

    End Sub

    Public Overrides Function Save() As Boolean

        '  Return MyBase.Save()

    End Function

#Region " 1. Grid 컬럼 초기화 "

    'Case 1. DataSet을 이용한 Title 배열
    Private Sub Init_Title()

        '1. 컬럼배열을 만든다
        Dim dSet As DataSet = Me.OpenDataSet("gad510_title")
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
            'arr(2, inx) = "근태항목"

            inx += 1
        Next

        '2. 화면에 Array Column을 Unbound로 Insert 또는 Add 한다
        ' Ex) g10.InsertColumn("A", arr, "B")
        '     "A" 컬럼이후에 삽입된다
        '     "A" 자리에 Nothing을 쓰면 Arry Column들이 마지막에 추가된다
        '     "B" 컬럼에 설정된 특성으로 Array의 수 만큼 새로운 컬럼을 만든다

        g10.InsertArrayColumns(Nothing, arr, "qty")

    End Sub
    Private Sub Init_Title3()

        '1. 컬럼배열을 만든다
        Dim frDt As Date = fr_dt.Text
        Dim toDt As Date = to_dt.Text

        Dim cnt As Integer = DateDiff(DateInterval.Day, frDt, toDt)
        Dim arr(1, 0) As String, colNm As String, colFNm As String
        For i = 0 To cnt
            ReDim Preserve arr(1, i)     'Array를 증가시킨다


            colNm = Format(DateAdd(DateInterval.Day, i, frDt), "MM-dd")
            colFNm = Format(DateAdd(DateInterval.Day, i, frDt), "yyyy-MM-dd")

            arr(0, i) = colFNm            'FieldName
            arr(1, i) = colNm            'Title
        Next

        'g10.InsertArrayColumns(arr)
        g10.InsertArrayColumns(Nothing, arr, "tm")

    End Sub


#End Region

#Region " 2. Display "

    '첫번째 Display 방법: 기본기능을 이용
    Private Sub Disp_Data()
        Try
            'Master 부분

            g10.GridColumn("ty").IsMasterKey = True
            g10.GridColumn("emp_no").IsMasterKey = True
            g10.GridColumn("emp_nm").IsMasterData = True
            g10.GridColumn("dept_cd").IsMasterData = True
            g10.GridColumn("dept_nm").IsMasterData = True

            'Detail 부분

            g10.GridColumn("work_dt").IsDetailKey = True
            g10.GridColumn("tm").IsDetailData = True

            MyBase.Open()

            '화면에서 Grid가 아닌 필드를 Grid 값으로 연결시키기 위해 Default값을 이용한다
            ' g10.GridColumn("work_mon").DefaultText = work_mon.Text

        Catch ex As Exception

            MessageInfo(ex, "Disp_Data()")

        End Try
    End Sub

#End Region

    Private Sub btn_copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_copy.Click
        pnlCopy.Visible = Not pnlCopy.Visible
    End Sub

   
End Class
