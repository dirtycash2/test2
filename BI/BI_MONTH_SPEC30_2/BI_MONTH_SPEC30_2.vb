﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class BI_MONTH_SPEC30_2

    ''    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
    ''        Select Case mty
    ''            'Case MenuType.Open
    ''            '   MyBase.Open()   '기본Open()기능을 호출한다 만약 기본이 아닌기능을 
    ''            '    '사용하려면 재정의 가능하다
    ''            Case MenuType.Save

    ''                If Me.Save() Then
    ''                    Me.Open()
    ''                End If
    ''                'Case MenuType.New
    ''                '    cust_cd.Text = ""
    ''                '    itm_cd.Text = ""
    ''                '    itm_nm.Text = ""
    ''                '    emp_id.Text = ""
    ''                '    emp_nm.Text = ""

    ''                '    Me.New_Form()

    ''            Case Else
    ''                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

    ''        End Select

    ''    End Sub

    'Public Overrides Sub Open()

    '    Me.Init_Title()
    '    Me.Disp_Data()

    'End Sub


    'Private Sub Init_Title()

    '    '1. 컬럼배열을 만든다
    '    Dim dSet As DataSet = Me.OpenDataSet("bi_spec30_title2")
    '    If IsEmpty(dSet) Then
    '        MessageInfo("조회 할 Data가 없습니다")
    '        'g10.Init()
    '        Exit Sub
    '    End If

    '    Dim arr(1, 0) As String, inx As Integer = 0
    '    For Each dRow In dSet.Tables(0).Rows
    '        ReDim Preserve arr(1, inx)      'Array를 증가시킨다

    '        arr(0, inx) = dRow(0)           'FieldName 으로 사용된다
    '        arr(1, inx) = dRow(1)           'Title로 사용된다
    '        'arr(2, inx) = "근태항목"

    '        inx += 1
    '    Next

    '    '2. 화면에 Array Column을 Unbound로 Insert 또는 Add 한다
    '    ' Ex) g10.InsertColumn("A", arr, "B")
    '    '     "A" 컬럼이후에 삽입된다
    '    '     "A" 자리에 Nothing을 쓰면 Arry Column들이 마지막에 추가된다
    '    '     "B" 컬럼에 설정된 특성으로 Array의 수 만큼 새로운 컬럼을 만든다

    '    'g10.InsertArrayColumns(arr)
    '    g10.InsertArrayColumns("GU", arr, "PR_QTY")

    'End Sub


    'Private Sub Disp_Data()
    '    Try
    '        g10.GridColumn("YY").IsMasterKey = True
    '        g10.GridColumn("MM").IsMasterKey = True
    '        g10.GridColumn("GU").IsMasterKey = True
    '        'g10.GridColumn("SPEC30").IsMasterKey = True
    '        'g10.GridColumn("PR_QTY").IsMasterData = True

    '        'Detail 부분
    '        g10.GridColumn("DT_CD").IsDetailKey = True
    '        g10.GridColumn("PR_QTY").IsDetailData = True

    '        MyBase.Open()

    '        '화면에서 Grid가 아닌 필드를 Grid 값으로 연결시키기 위해 Default값을 이용한다
    '        ' g10.GridColumn("YY").DefaultText = fr_dt.Text

    '    Catch ex As Exception

    '        MessageInfo(ex, "Disp_Data()")

    '    End Try

    'End Sub

End Class
