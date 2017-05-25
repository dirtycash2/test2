﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports System7.ReportView
Imports System7.Reports
Imports System.Net.Mail
Imports System.Data
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports System.Runtime.CompilerServices
Imports System.Net
Imports System.Net.Configuration

Public Class GAD110_IN
    '근무시간, 공제시간정보 dSet
    Private dSetBaseTime As DataSet
    '기준단위 시간정보
    Private UnitTm As Double = 0 '시간 계산단위(기본시단위:0.5시단위)
    Private UnitMin As Double = 0 '시간 계산단위(기본시단위:30분단위)
    Private GapInMin As Double = 0 '출근 봐주는 시간
    Private GapOutMin As Double = 0 '퇴근 봐주는 시간

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dept_cd.ReadOnly = Not Me.IsManager
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

        Me.ColVisible()
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

            Me.GetStdTime()
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

        g10.ColumnVisible("work_dt") = (show_ty.Text = "0" Or show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("weekday") = (show_ty.Text = "0" Or show_ty.Text = "3")
        g10.ColumnVisible("dt_bc") = (show_ty.Text = "0" Or show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("emp_no") = (show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("emp_nm") = (show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("dept_nm") = (show_ty.Text = "0" Or show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("work_bc") = (show_ty.Text = "0" Or show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("work_bc2") = (show_ty.Text = "0" Or show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("work_kd") = (show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("chk_frtm") = (show_ty.Text = "1" Or show_ty.Text = "3")
        g10.ColumnVisible("chk_totm") = (show_ty.Text = "1" Or show_ty.Text = "3")

    End Sub

    Private Sub Form_Disposing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Disposing
        Me.SetColsingSave()
    End Sub

    '######################################################################################
    '##             Procedure                                                            ##
    '######################################################################################

    Private Function ExistData() As Boolean
        Dim p As New OpenParameters
        p.Add("@co_cd", co_cd.Text)
        p.Add("@bs_cd", bs_cd.Text)
        p.Add("@fr_dt", fr_dt.Text)
        p.Add("@to_dt", to_dt.Text)
        p.Add("@dept_cd", dept_cd.Text)
        p.Add("@emp_no", emp_no.Text)
        p.Add("@work_bc", work_bc.Text)
        p.Add("@work_kd", work_kd.Text)
        p.Add("@chk_frtm", chk_frtm.Text)
        p.Add("@chk_totm", chk_totm.Text)


        Dim dSet As DataSet = OpenDataSet("gad110_in_datacheck", p)
        If Not IsEmpty(dSet) Then
            Return True
        End If

        Return False
    End Function

    Private Function GetAttFile() As Boolean
        Try
            If Not CheckRequired(co_cd, bs_cd, fr_dt, to_dt) Then Exit Function
            If Me.ExistData() Then
                '작업 하시겠습니까 ?
                If MessageYesNo("근태 Data가 존재합니다. 수정 및 승인된 기존자료는 삭제되지 않습니다.  수정된 자료 삭제시: 행삭제 -> 저장 -> 일근태생성") <> MsgBoxResult.Yes Then
                    Return False
                End If
            End If

            Dim p As New OpenParameters
            p.Add("@co_cd", co_cd.Text)
            p.Add("@bs_cd", bs_cd.Text)
            p.Add("@fr_dt", fr_dt.Text)
            p.Add("@to_dt", to_dt.Text)
            p.Add("@dept_cd", dept_cd.Text)
            p.Add("@emp_no", emp_no.Text)
            p.Add("@work_bc", work_bc.Text)
            p.Add("@work_kd", work_kd.Text)
            p.Add("@sub_yn", sub_yn.Text)
            p.Add("@chk_frtm", chk_frtm.Text)
            p.Add("@chk_totm", chk_totm.Text)

            Open("gad110_in_getdata", p)

            Me.Open()

            Return True


        Catch ex As Exception
            MessageError(ex)
        End Try

        Return False
    End Function

    Private Sub btn_work_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_work.Click
        If MessageYesNo("작업 하시겠습니까 ?") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        Me.GetAttFile()
    End Sub

    Private Sub WorkTime()
        Try
            If Not GetStdTime() Then
                'MsgError("Open Error 기준근무시간", , "Open_Standard_Time()")
                PutError("BB200_2", vbLf, "Open_Standard_Time()")
                Exit Sub
            End If

            m_StopEvent = True
            'Parameter.MainFrame.ProgBar.Visible = True
            'Parameter.MainFrame.ProgBar.Minimum = 1
            'Parameter.MainFrame.ProgBar.Maximum = g10.RowCount
            'Parameter.MainFrame.ProgBar.Value = 1
            'Parameter.MainFrame.ProgBar.Step = 1

            With g10

                Dim iRow As Integer
                For iRow = 0 To .RowCount - 1
                    'Parameter.MainFrame.ProgBar.Value = iRow + 1

                    Me.CallWorkTime(iRow)
                Next

                '커서를 위로 올린다
                If 0 < .RowCount Then .RowIndex = 0

            End With
            m_StopEvent = False

        Catch ex As Exception
            m_StopEvent = False
            'Me.Cursor = Cursors.Default
            'MsgError(ex, "자동계산")
            MessageError(ex)
        Finally
            'Parameter.MainFrame.ProgBar.Visible = False
        End Try
    End Sub

    Private Sub btn_calcu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_calcu.Click
        'If g20.RowCount <= 0 Then Exit Sub
        If Not CheckRequired(co_cd, bs_cd, fr_dt, to_dt) Then Exit Sub
        '물어 본다
        '작업 하시겠습니까 ?
        If MessageYesNo("작업 하시겠습니까 ?") <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        Me.WorkTime()
    End Sub

    'Private Sub sub_yn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sub_yn.CheckedChanged
    '    If but.Properties.Items(but.SelectedIndex).Value = "0" Then Open_Form()
    'End Sub

    Private Sub g20_AfterMoveRow(ByVal sender As Object, ByVal PrevRowIndex As Integer, ByVal RowIndex As Integer) Handles g20.AfterMoveRow

        Dim p As OpenParameters = New OpenParameters

        p.Add("@co_cd", co_cd.Text)
        p.Add("@bs_cd", bs_cd.Text)
        p.Add("@work_bc", work_bc.Text)
        p.Add("@work_kd", work_kd.Text)
        p.Add("@fr_dt", fr_dt.Text)
        p.Add("@to_dt", to_dt.Text)
        p.Add("@chk_frtm", chk_frtm.Text)
        p.Add("@chk_totm", chk_totm.Text)



        If g20.Text("emp_no") = "" Then
            p.Add("@emp_no", emp_no.Text)
        Else
            p.Add("@emp_no", g20.Text("emp_no"))
        End If

        If g20.Text("dept_cd") = "" Then
            p.Add("@dept_cd", dept_cd.Text)
        Else
            p.Add("@dept_cd", g20.Text("dept_cd"))
        End If

        p.Add("@emp_nm", emp_nm.Text)
        p.Add("@sub_yn", sub_yn.Text)

        Me.Open("gad110_in_g10", p)

    End Sub

    Private Sub g30_AfterMoveRow(ByVal sender As Object, ByVal PrevRowIndex As Integer, ByVal RowIndex As Integer) Handles g30.AfterMoveRow

        Dim p As OpenParameters = New OpenParameters

        p.Add("@co_cd", co_cd.Text)
        p.Add("@bs_cd", bs_cd.Text)
        p.Add("@work_bc", work_bc.Text)
        p.Add("@work_kd", work_kd.Text)
        p.Add("@fr_dt", g30.Text("dt"))
        p.Add("@to_dt", g30.Text("dt"))
        p.Add("@dept_cd", dept_cd.Text)
        p.Add("@emp_no", emp_no.Text)
        p.Add("@emp_nm", emp_nm.Text)
        p.Add("@sub_yn", sub_yn.Text)
        p.Add("@chk_frtm", chk_frtm.Text)
        p.Add("@chk_totm", chk_totm.Text)


        Me.Open("gad110_in_g10", p)

    End Sub

    Private m_StopEvent As Boolean

    Private Sub g10_CellValueChanged(ByVal sender As Object, ByVal ColumnName As String, ByVal RowIndex As Integer, ByRef Value As Object) Handles g10.CellValueChanged
        If m_StopEvent Then Exit Sub
        With g10

            Try
                '시작, 종료시간 변경
                If ColumnName = "fr_tm" Or ColumnName = "to_tm" Then
                    m_StopEvent = True
                    'Dim Val As String = .Text(ColumnName)
                    .Text(ColumnName) = TimeFormat(.Text(ColumnName))

                    'Dim InTm As String = .Text("fr_tm")
                    'Dim OutTm As String = .Text("to_tm")
                    'If InTm <> "" And OutTm <> "" Then
                    '    If InTm > OutTm Then
                    '        OutTm = 24 + Mid(OutTm, 1, 2) & ":" & Mid(OutTm, 4, 2)
                    '    End If
                    'End If
                End If

                If ColumnName = "fr_tm" Or ColumnName = "to_tm" Or ColumnName = "atn_cd" Then
                    .Text("work_yn") = Me.GetWorkChk(.Text("fr_tm"), .Text("to_tm"), .Text("atn_cd"))
                End If

                If ColumnName = "fr_tm" Or ColumnName = "to_tm" Or _
                   ColumnName = "dt_bc" Or ColumnName = "dn_bc" Then
                    'ColumnName = "next_yn" Or ColumnName = "work_yn" Then
                    m_StopEvent = True
                    Me.CallWorkTime(RowIndex)
                End If

            Catch ex As Exception

            Finally
                m_StopEvent = False
            End Try

        End With
    End Sub

    Private Function GetWorkChk(ByVal frTm As String, ByVal toTm As String, ByVal atnCd As String) As String
        GetWorkChk = ""
        If frTm = "" Or toTm = "" Then Return "0"
        Try
            Dim p As New OpenParameters
            p.Add("@bs_cd", bs_cd.Text)
            p.Add("@fr_tm", frTm)
            p.Add("@to_tm", toTm)
            p.Add("@atn_cd", atnCd)

            Dim dSet As DataSet = OpenDataSet("gad110_in_work_yn", p)
            If IsEmpty(dSet) Then
                Return "0"
            End If

            Return DataValue(dSet)

        Catch ex As Exception
            MessageError(ex)
        End Try
    End Function

    '기본근무시간과 공제시간, 기준 단위시간을 가져온다
    Private Function GetStdTime() As Boolean
        Try
            If Not CheckRequired(bs_cd) Then Return False
            Dim p As New OpenParameters
            p.Add("@bs_cd", bs_cd.Text)
            dSetBaseTime = OpenDataSet("gad110_in_unit_time", p)

            If Not IsEmpty(dSetBaseTime.Tables(1)) Then
                '기준단위 시간정보
                Dim Unit As Double = ToDec(dSetBaseTime.Tables(1).Rows(0)("unit_tm"))
                If Unit = 0 Then Unit = 30.0
                UnitMin = Unit          '시간 계산단위(기본시단위:30분단위)
                UnitTm = Unit / 60.0    '시간 계산단위(기본시단위:0.5시단위)
                GapInMin = ToDec(dSetBaseTime.Tables(1).Rows(0)("con_in_tm")) '출근 봐주는 시간
                GapOutMin = ToDec(dSetBaseTime.Tables(1).Rows(0)("con_out_tm")) '퇴근 봐주는 시간
            End If

            If UnitMin = 0 Then
                UnitMin = 30.0
                UnitTm = 30.0 / 60.0
            End If

            Return True
        Catch ex As Exception
            MessageError(ex)
        End Try
    End Function

    Private Function GetDateBc(ByVal GetDt As String) As String
        GetDateBc = ""
        If GetDt = "" Then Return ""
        Try
            If Not CheckRequired(bs_cd) Then Return False
            Dim p As New OpenParameters
            p.Add("@bs_cd", bs_cd.Text)
            p.Add("@dt", GetDt)
            Dim dSet As DataSet = OpenDataSet("gad110_in_dt_bc", p)
            If Not IsEmpty(dSet) Then
                Return CStr(DataValue(dSet))
            End If
        Catch ex As Exception
            MessageError(ex)
        End Try
    End Function

    Private 평일 As String = "GA120100"
    Private 토요 As String = "GA120200"
    Private 주휴 As String = "GA120300"
    Private 유휴 As String = "GA120400"
    Private 무휴 As String = "GA120500"


    Private 주야구분_주간 As String = "PP160100"
    'Private 주야구분_야간 As String = "PP160150"
    'Private 주야구분_A As String = "PP160310"
    'Private 주야구분_B As String = "PP160320"
    'Private 주야구분_C As String = "PP160330"
    'Private 주야구분_야간조출 As String = "PP160800"




    Private 근무시간_조출 As String = "GA170600"              '조기출근
    Private 근무시간_정상 As String = "GA170700"              '평일 정상
    Private 근무시간_연장1 As String = "GA170710"             '평일연장
    Private 근무시간_연장2 As String = "GA170720"             '평일심야

    Private 근무시간_연장3 As String = "GA170740"             '휴일정상
    Private 근무시간_연장4 As String = "GA170750"             '휴일연장
    Private 근무시간_연장5 As String = "GA170760"             '휴일심야

    Private 근무시간_연장6 As String = "GA170780"             '평일야간정상
    Private 근무시간_연장7 As String = "GA170800"             '평일야간연장
    Private 근무시간_연장8 As String = "GA170790"             '평일야간심야

    Private 근무시간_연장9 As String = "GA170820"             '휴일야간정상
    Private 근무시간_연장10 As String = "GA170830"            '휴일야간연장
    Private 근무시간_연장11 As String = "GA170840"            '휴일야간심야
    'Private 근무시간_연장12 As String = "GA170312"

    'Private 근무시간_휴일정상 As String = "GA170500"
    'Private 근무시간_휴일연장 As String = "GA170550"

    Private 조출 As String = "C3301"

    Private Sub CallWorkTime(ByVal iRow As Integer)

        If Not g10.IsDataRow(iRow) Then Exit Sub
        If IsEmpty(dSetBaseTime.Tables(1)) Then Exit Sub
        With g10
            Try

                Dim BsCd As String, DnBc As String, WorkTy As String, WorkBc As String, PartBc As String, DtBc As String, _
                    gRow As Integer, chkLate As String = ""                  '지각조퇴관리여부

                Dim frTm As String, toTm As String                      '근태출퇴근시간
                Dim set_frTm As String = "", set_toTm As String = ""    '연장항목에 대한 설정 시작/종료시간(조출 ~ 심야)
                Dim std_frTm As String = "", std_toTm As String = ""    '정상출퇴근시간 대한 설정
                Dim org_frTm As String = "", org_toTm As String = ""

                Dim work_hr As Double, std_hr As Double, _
                    before_hr As Double = 0, late_hr As Double, off_hr As Double, out_hr As Double, _
                    t1Hr As Double, t2Hr As Double, t3Hr As Double, t4Hr As Double, t5Hr As Double, _
                    t6Hr As Double, t7Hr As Double, t8Hr As Double, t9Hr As Double, t10Hr As Double, _
                    t11Hr As Double, t12Hr As Double, _
                    extn2_hr As Double = 0, extn3_hr As Double = 0, _
                    extn4_hr As Double = 0,
                    eat_cnt As Integer, AtnCd As String, WorkYn As String = ""
                Dim ErrBc As String ', reqTm As Double, actTm As Double

                If .Text("work_yn", iRow) = "" Then Return

                If .Text("ok_yn", iRow) = "1" Then Exit Sub '승인된 것은 계산에서 제외

                ''작업일 <= 마감일자 이면 계산안함
                'If Not ChkClose(iRow) Then Return

                If .Text("dt_bc", iRow) = "" Then
                    Dim GetStr As String = Me.GetDateBc(.Text("work_dt"))
                    If GetStr = "" Then
                        MessageWarning("[근무일자 :" & .Text("work_dt") & "]해당하는 구분을 찾을 수 없습니다.")
                        Exit Sub
                    Else
                        .Text("dt_bc", iRow) = GetStr
                    End If
                End If

                '-------------------------------------------------------------
                '출퇴근 예외자이고 평일이면 9시부터 18시까지 자동으로 
                '-------------------------------------------------------------
                If .Text("excp_chk", iRow) = "1" And .Text("dt_bc", iRow) = 평일 Then
                    If .Text("fr_tm", iRow) = "" Then
                        .Text("fr_tm", iRow) = "09:00"
                    End If
                    If .Text("to_tm", iRow) = "" Then
                        .Text("to_tm", iRow) = "18:00"
                    End If
                End If

                '-------------------------------------------------------------
                '기본변수 설정
                '-------------------------------------------------------------

                BsCd = .Text("bs_cd", iRow)
                DnBc = .Text("dn_bc", iRow) '주야구분
                DtBc = .Text("dt_bc", iRow) '일자구분
                WorkBc = .Text("work_bc2", iRow) '근무직구분
                PartBc = .Text("part_bc", iRow) '근무조구분
                WorkTy = .Text("work_bc", iRow) '근무타임구분
                AtnCd = .Text("atn_cd", iRow)
                WorkYn = .Text("work_yn", iRow)

                frTm = TimeFormat(.Text("fr_tm", iRow))
                toTm = TimeFormat(.Text("to_tm", iRow))


                'chkLate = .Text("late_chk", iRow)

                '-------------------------------------------------------------
                '근무안함 또는 출퇴근시간이 존재하지 않으면 모두 clear 한다.
                '-------------------------------------------------------------
                If DtBc = 평일 Then
                    chkLate = "Y" '지각조퇴관리
                End If

                'If frTm <> "" And toTm <> "" Then
                'If DtBc = 평일 And AtnCd = "M7000" Then '평일->무계결근->정상
                '    WorkYn = "1"
                '    AtnCd = "Y1000"
                '    .Text("work_yn", iRow) = WorkYn
                '    .Text("atn_cd", iRow) = AtnCd
                'End If
                'If DtBc = 주휴 And AtnCd = "M3000" Then '주휴->주휴->휴일특근
                '    .Text("work_yn", iRow) = "1"
                '    .Text("atn_cd", iRow) = "Z1200"
                'End If
                'If DtBc = 공휴 And AtnCd = "M3100" Then '공휴->공휴->휴일특근
                '    .Text("work_yn", iRow) = "1"
                '    .Text("atn_cd", iRow) = "Z1200"
                'End If
                'If DtBc = 무휴 And AtnCd = "M6600" Then '무휴->휴무(무급)->연장근무
                '    .Text("work_yn", iRow) = "1"
                '    .Text("atn_cd", iRow) = "Z1100"
                'End If
                'Else
                'If DtBc = 평일 And AtnCd = "Y1000" Then '평일->정상->무계
                '    WorkYn = "0"
                '    AtnCd = "M7000"
                '    .Text("work_yn", iRow) = WorkYn
                '    .Text("atn_cd", iRow) = AtnCd
                'End If
                'If DtBc = 주휴 And AtnCd = "Z1200" Then '주휴->휴일특근->주휴
                '    .Text("work_yn", iRow) = "0"
                '    .Text("atn_cd", iRow) = "M3000"
                'End If
                'If DtBc = 공휴 And AtnCd = "Z1200" Then '공휴->휴일특근->공휴
                '    .Text("work_yn", iRow) = "0"
                '    .Text("atn_cd", iRow) = "M3100"
                'End If
                'If DtBc = 무휴 And AtnCd = "Z1100" Then '무휴->연장근무->휴무(무급)
                '    .Text("work_yn", iRow) = "0"
                '    .Text("atn_cd", iRow) = "M6600"
                'End If
                'End If


                If WorkYn = "0" Or (frTm = "" Or toTm = "") Then
                    '둘 중 하나라도 없으면 모든 시간 컬럼 0 으로
                    Dim iCol As Integer, colNm As String
                    For iCol = 0 To .ColumnCount - 1
                        colNm = .GridColumns(iCol + 1).ColumnName
                        If colNm.EndsWith("_hr") Then
                            PutTime(colNm, iRow, 0)     '총근무
                        End If
                    Next
                    '.Text("eat_cnt", iRow) = 0'식권
                End If

                ''If WorkYn ="0" Or frTm = "" Or toTm = "" Then
                ''    If .Bool("work_yn", iRow) Then
                ''        If frTm = "" Or toTm = "" Then    '800 : 출퇴근시간이 없습니다
                ''            ErrBc = "B720800"
                ''        End If
                ''    Else
                ''        If frTm <> "" Or toTm <> "" Then   '810 : 결무일에 출근 또는 퇴근시간이 존재합니다'
                ''            ErrBc = "B720810"
                ''        End If
                ''    End If
                ''    .Text("err_bc", iRow) = ErrBc
                ''    Exit Sub
                ''End If

                ErrBc = ""

                If frTm <> "" And frTm = toTm Then
                    '820 : 24시간초과
                    ErrBc = "B720820"
                End If

                If WorkYn = "1" And (frTm = "" Or toTm = "") Then
                    '800 : 출퇴근시간이 없습니다
                    ErrBc = "B720800"
                End If

                '평일이고 무계결근 이고 출근 또는 퇴근시간이 없으면 
                If DtBc = 평일 And (frTm = "" Or toTm = "") And AtnCd = "M7000" Then
                    '800 : 출퇴근시간이 없습니다
                    ErrBc = "B720800"
                End If

                If WorkYn = "0" And (frTm <> "" Or toTm <> "") Then
                    '810 : 결무일에 출근 또는 퇴근시간이 존재합니다'
                    ErrBc = "B720810"
                End If

                '초기 기본 에러시 끝낸다
                If ErrBc <> "" Then
                    '.Text("err_bc", iRow) = ErrBc
                    Exit Sub
                End If

                '시간이 없으면 어떤 경우라도 끝낸다
                If frTm = "" Or toTm = "" Then
                    Exit Sub
                End If

                '근무타임 (야간 이나 3교대야간오후)이고 출근이 다음날 (09시이전) 이면 출근시간을 25시간 체계로 간다
                If (WorkTy = "GA121500" Or WorkTy = "GA121300" Or WorkTy = "GA121400") And "00:00" <= frTm And frTm <= "09:00" Then
                    frTm = 24 + Mid(frTm, 1, 2) & ":" & Mid(frTm, 4, 2)
                End If

                '퇴근시간이 적으면 24시간 이상체제로 간다 (다음날아침8시: 32시)
                If toTm <> "" And frTm <> "" And toTm < frTm Then
                    toTm = 24 + Mid(toTm, 1, 2) & ":" & Mid(toTm, 4, 2)

                    .Text("next_yn", iRow) = "1"    '익일
                Else
                    If .Text("next_yn", iRow) = "1" Then
                        If toTm < "24:00" Then
                            '24시간 이상체제로 간다 (다음날아침8시: 32시)
                            toTm = 24 + Mid(toTm, 1, 2) & ":" & Mid(toTm, 4, 2)
                        End If
                    End If
                End If

                '----------------------------------
                '총근무시간
                '----------------------------------
                work_hr = HourDiff(frTm, toTm)

                '2012-05-24 30분 단위로 설정
                work_hr = DFix((work_hr) / UnitTm) * UnitTm


                std_frTm = frTm
                std_toTm = toTm

                org_frTm = frTm
                org_toTm = toTm
                std_hr = 0




                '---------------------------------------------
                '정상근무시간으로 체크하여
                '  근태입출고시간을 재계산하여 설정한다
                '---------------------------------------------
                '[행마다 주야구분과 요일구분이 다르기때문에 filter 사용]
                Dim stdTmRows As DataRow() = _
                            dSetBaseTime.Tables(0).Select( _
                                    "   work_ty   = '" & WorkTy & "'" & _
                                    " AND dt_bc    = '" & DtBc & "'" & _
                                    " AND dn_bc     = '" & DnBc & "'" & _
                                     " AND (tm_bc     ='" & 근무시간_정상 & "' or tm_bc ='" & 근무시간_연장3 & "' )")
                '" AND (tm_bc     ='" & 근무시간_정상 & "')") ' or tm_bc     ='" & 근무시간_연장6 & "' )")

                If stdTmRows.GetLength(0) > 0 Then

                    '[정상근무시간을 가지고 온다]
                    std_frTm = stdTmRows(0)("fr_tm")
                    std_toTm = stdTmRows(0)("to_tm")

                    ''----------------------------------
                    ''정상설정시간
                    ''----------------------------------
                    'set_hr = HourDiff(std_frTm, std_toTm) - 1

                    '퇴근시간이 적으면 24시간 이상체제로 간다 (다음날아침8시: 32시)
                    If std_toTm <> "" And std_frTm <> "" And std_toTm < std_frTm Then
                        std_toTm = 24 + Mid(std_toTm, 1, 2) & ":" & Mid(std_toTm, 4, 2)
                    End If

                    '--------------------------------------------------------------------------------------
                    '정상출퇴근시간과 근태시간을 비교해서 지정시간 이내이면 정상시간과 동일하게 처리한다.
                    '--------------------------------------------------------------------------------------
                    If std_frTm < frTm Then
                        If MinuteDiff(std_frTm, frTm) <= GapInMin Then
                            frTm = std_frTm
                        End If
                    End If
                    If toTm < std_toTm Then
                        If MinuteDiff(toTm, std_toTm) <= GapOutMin Then
                            toTm = std_toTm
                        End If
                    End If

                    org_frTm = frTm
                    org_toTm = toTm

                    '---------------------------------------------------------
                    '출근 근태시간 단위 재계산
                    '---------------------------------------------------------
                    '30분 단위              15분 단위
                    '08:01 ~ 30 -> 08:30    08:01 ~ 15 -> 08:15
                    '08:31 ~ 59 -> 09:00    08:16 ~ 30 -> 08:30
                    '                       08:31 ~ 45 -> 08:45
                    '                       08:46 ~ 59 -> 09:30
                    Dim mm As Integer = Int(Mid(frTm, 4, 2)), mfrTm As Integer
                    If 0 < mm Then
                        '( (분 -1 ) / 단위 + 1 ) * 단위
                        mfrTm = Fix((mm - 1) / UnitMin + 1) * UnitMin
                        If mfrTm = 60 Then
                            frTm = Format(1 + Int(Mid(frTm, 1, 2)), "0#") & ":00"
                        Else
                            frTm = Mid(frTm, 1, 2) & ":" & Format(mfrTm, "0#")
                        End If
                    End If

                    '---------------------------------------------------------
                    '퇴근 근태시간 단위 재계산
                    '---------------------------------------------------------
                    '30분 단위              15분 단위
                    '17:01 ~ 30 -> 17:00    17:01 ~ 15 -> 17:00
                    '17:31 ~ 59 -> 17:30    17:16 ~ 30 -> 17:15
                    '                       17:31 ~ 45 -> 17:30
                    '                       17:46 ~ 59 -> 17:45

                    mm = Int(Mid(toTm, 4, 2))
                    If 0 < mm Then
                        '( (분 -1 ) / 단위 ) * 단위
                        mfrTm = Fix((mm) / UnitMin) * UnitMin
                        If mfrTm = 60 Then
                            toTm = Format(1 + Int(Mid(toTm, 1, 2)), "0#") & ":00"
                        Else
                            toTm = Mid(toTm, 1, 2) & ":" & Format(mfrTm, "0#")
                        End If
                    End If

                    mm = Int(Mid(toTm, 4, 2))
                    If 0 < mm Then
                        '( (분 -1 ) / 단위 ) * 단위
                        mfrTm = Fix((mm) / UnitMin) * UnitMin
                        If mfrTm = 60 Then
                            toTm = Format(1 + Int(Mid(toTm, 1, 2)), "0#") & ":00"
                        Else
                            toTm = Mid(toTm, 1, 2) & ":" & Format(mfrTm, "0#")
                        End If



                        ''MsgBox(frTm + vbLf + toTm)

                    End If

                    'MsgBox(frTm + vbLf + toTm)

                    'Exit Sub

                    '---------------------------------------------------------
                    '지각/조퇴 계산, 조기출근시간 계산(조출 추가 park 2012-05-18)
                    '---------------------------------------------------------
                    If frTm <> "" And toTm <> "" And chkLate = "Y" Then

                        ''[지각: 기준근무시간보다 늦게 출근한경우]
                        If std_frTm < frTm Then
                            late_hr = HourDiff(std_frTm, frTm)
                            late_hr = late_hr - CalLossTm(std_frTm, frTm, DnBc, DtBc, WorkTy) / 60.0
                        End If

                        ''[조퇴: 기준근무시간보다 일찍 퇴근한경우]
                        If std_toTm > toTm And AtnCd <> 근무시간_조출 Then
                            off_hr = HourDiff(toTm, std_toTm)
                            off_hr = off_hr - CalLossTm(toTm, std_toTm, DnBc, DtBc, WorkTy) / 60.0
                            'off_hr = DFix((off_hr) / UnitTm) * UnitTm
                        End If
                    End If

                    If frTm <> "" And toTm <> "" Then
                        '[조출시간계산: 출근기준시간 - 출근시간]
                        If std_frTm > frTm And PartBc <> "GA122900" Then   'And PartBc <> "GA122400"  (2교대)조출시간 계산되게끔 해야한다. 
                            before_hr = HourDiff(frTm, std_frTm)
                            before_hr = before_hr - CalLossTm(frTm, std_frTm, DnBc, DtBc, WorkTy) / 60.0
                            'before_hr = before_hr / 60.0
                        End If
                    End If
                    End If




                    '[행마다 주야구분과 요일구분이 다르기때문에 filter 사용]
                    Dim baseTmRows As DataRow() = _
                                dSetBaseTime.Tables(0).Select( _
                                        "     work_ty     = '" & WorkTy & "'" & _
                                        " AND dt_bc    = '" & DtBc & "'" & _
                                        " AND dn_bc    = '" & DnBc & "'")

                    If baseTmRows.GetLength(0) > 0 Then
                        Dim TmBc As String, tHr As Double

                        For gRow = 0 To baseTmRows.GetLength(0) - 1

                            '[해당구분의 시간을 가지고 온다 (조출 시작, 종료시간)]
                            set_frTm = baseTmRows(gRow)("fr_tm")
                            set_toTm = baseTmRows(gRow)("to_tm")
                            WorkYn = baseTmRows(gRow)("work_yn")

                            If set_toTm <> "" And set_frTm <> "" And set_toTm < set_frTm Then
                                set_toTm = 24 + Mid(set_toTm, 1, 2) & ":" & Mid(set_toTm, 4, 2)
                            End If

                            TmBc = baseTmRows(gRow)("tm_bc")

                            std_hr = 0



                            '[조출: 출근시간만 비교해야하며 그외는 퇴근시간을 비교하므로 구분을 주었음]
                            If AtnCd = 조출 Then
                                ' Dim std_base As Decimal '조출후 기본 8시간 
                                'Dim Std_before As Decimal '조출후 야간 연장 시간(기본시간 이후 ~32:30분 )


                                '[조출계산 - 공제시간]
                                before_hr = CacuTm(frTm, toTm, set_frTm, set_toTm, 0, DnBc, DtBc, WorkTy, WorkYn)

                                before_hr = DFix((before_hr) / 0.5) * 0.5   '30분단위의 시간

                                If before_hr < 0.5 Then    '30분미만의 시간은 인정하지 않음
                                    before_hr = 0
                                End If

                                'If AtnCd = 조출 Then
                                '    '[조출계산 - 공제시간]
                                '    before_hr = CacuTm(frTm, toTm, frTm, set_frTm, 0, DnBc, DtBc, WorkBc, WorkYn)

                                '    before_hr = DFix((before_hr) / UnitTm) * UnitTm   '30분단위의 시간

                                '    If before_hr < UnitTm Then    '단위시간(ex:30분) 미만의 시간은 인정하지 않음
                                '        before_hr = 0
                                '    End If
                                '    'std_hr = before_hr + std_hr
                                'End If
                            End If



                            'ElseIf TmBc = 근무시간_정상 Then
                            If TmBc = 근무시간_정상 Then   '평일정상시간(야간조인 경우에도)
                                If toTm < set_frTm Then   '퇴근시간이 정상시작시간 이전 이면 정상근무 아님
                                    std_hr = 0
                                Else
                                    Dim frTm2 As String, toTm2 As String
                                    frTm2 = frTm
                                    toTm2 = toTm
                                    If frTm < set_frTm Then
                                        frTm2 = set_frTm
                                    End If
                                    If set_toTm < toTm Then
                                        toTm2 = set_toTm
                                    End If
                                    std_hr = CacuTm(frTm2, toTm2, set_frTm, set_toTm, 2, DnBc, DtBc, WorkTy, WorkYn)
                                    std_hr = DFix((std_hr) / UnitTm) * UnitTm       '30분단위의 시간
                                    PutTime("std_hr", iRow, std_hr) '평일정상
                                End If


                            ElseIf TmBc = 근무시간_연장3 Then '휴일정상근로
                                If toTm < set_frTm Then   '퇴근시간이 정상시작시간 이전 이면 정상근무 아님 '연장이기 때문에 정상연장시간으로 해야하는 데..?
                                    t3Hr = 0
                                Else
                                    Dim frTm2 As String, toTm2 As String
                                    frTm2 = frTm
                                    toTm2 = toTm
                                    If frTm < set_frTm Then
                                        frTm2 = set_frTm
                                    End If
                                    If set_toTm < toTm Then
                                        toTm2 = set_toTm
                                    End If
                                    t3Hr = CacuTm(frTm2, toTm2, set_frTm, set_toTm, 2, DnBc, DtBc, WorkTy, WorkYn)
                                    t3Hr = DFix((t3Hr) / UnitTm) * UnitTm       '30분단위의 시간
                                    ' t3Hr = std_hr


                                    'If AtnCd = 조출 Then
                                    '    t12Hr = before_hr
                                    'Else
                                    '    t12Hr = std_hr
                                    '                            End If

                                    PutTime("t3_hr", iRow, t3Hr) '휴일정상
                                End If
                            ElseIf TmBc = 근무시간_연장6 Then '야간정상
                                If toTm < set_frTm Then   '퇴근시간이 정상시작시간 이전 이면 정상근무 아님
                                    t6Hr = 0
                                Else
                                    Dim frTm2 As String, toTm2 As String
                                    frTm2 = frTm
                                    toTm2 = toTm
                                    If frTm < set_frTm Then
                                        frTm2 = set_frTm
                                    End If
                                    If set_toTm < toTm Then
                                        toTm2 = set_toTm
                                    End If
                                    t6Hr = CacuTm(frTm2, toTm2, set_frTm, set_toTm, 2, DnBc, DtBc, WorkTy, WorkYn)
                                    t6Hr = DFix((t6Hr) / UnitTm) * UnitTm       '30분단위의 시간
                                    ' t6Hr = std_hr
                                    'If AtnCd = 조출 Then
                                    '    t6Hr = before_hr
                                    'Else
                                    '    t6Hr = std_hr
                                    'End If
                                    PutTime("t6_hr", iRow, t6Hr) '평일야간정상
                                End If
                            ElseIf TmBc = 근무시간_연장9 Then '휴일야간정상
                                If toTm < set_frTm Then   '퇴근시간이 정상시작시간 이전 이면 정상근무 아님
                                    t9Hr = 0
                                Else
                                    Dim frTm2 As String, toTm2 As String
                                    frTm2 = frTm
                                    toTm2 = toTm
                                    If frTm < set_frTm Then
                                        frTm2 = set_frTm
                                    End If
                                    If set_toTm < toTm Then
                                        toTm2 = set_toTm
                                    End If
                                    t9Hr = CacuTm(frTm2, toTm2, set_frTm, set_toTm, 2, DnBc, DtBc, WorkTy, WorkYn)
                                    t9Hr = DFix((t9Hr) / UnitTm) * UnitTm       '30분단위의 시간
                                    't9Hr = std_hr
                                    'If AtnCd = 조출 Then
                                    '    t9Hr = before_hr
                                    'Else
                                    '    t9Hr = std_hr
                                    'End If
                                    PutTime("t9_hr", iRow, t9Hr) '휴일야간정상
                                End If
                            Else


                                ' tHr = CacuTm(org_frTm, org_toTm, set_frTm, set_toTm, 0, DnBc, DtBc, WorkBc, WorkYn)
                                tHr = CacuTm(frTm, toTm, set_frTm, set_toTm, 1, DnBc, DtBc, WorkTy, WorkYn)
                                'tHr = CacuTm(frTm, toTm, set_frTm, set_toTm, 1, BsCd, DnBc, DtBc, WorkBc, WorkYn)
                                tHr = DFix((tHr) / UnitTm) * UnitTm       '30분단위의 시간

                                If tHr < UnitTm Then      '단위시간(ex:30분) 미만의 시간은 인정하지 않음
                                    tHr = 0
                                End If

                                'Private 근무시간_정상 As String = "GA170100"
                                'Private 근무시간_연장 As String = "GA170150"
                                'Private 근무시간_심야 As String = "GA170200"
                                'Private 근무시간_휴일정상 As String = "GA170500"
                                'Private 근무시간_휴일연장 As String = "GA170550"

                                Select Case TmBc
                                    Case 근무시간_연장1
                                        t1Hr = tHr
                                    Case 근무시간_연장2
                                        t2Hr = tHr
                                    Case 근무시간_연장3
                                        t3Hr = std_hr
                                    Case 근무시간_연장4

                                        t4Hr = tHr
                                    Case 근무시간_연장5
                                        t5Hr = tHr
                                    Case 근무시간_연장6
                                        t6Hr = std_hr
                                    Case 근무시간_연장7
                                        t7Hr = tHr
                                    Case 근무시간_연장8
                                        t8Hr = tHr
                                    Case 근무시간_연장9
                                        t9Hr = std_hr
                                    Case 근무시간_연장10
                                        t10Hr = tHr
                                    Case 근무시간_연장11
                                        t11Hr = tHr
                                        ' Case 근무시간_연장12
                                        '    t12Hr = tHr

                                        'Case 근무시간_심야
                                        '    t2Hr = tHr
                                        'Case 근무시간_휴일정상
                                        '    t3Hr = tHr
                                        'Case 근무시간_휴일연장
                                        '    t4Hr = tHr
                                        'Case 근무시간_연장2
                                        '    extn2_hr = tHr
                                        'Case 근무시간_연장3
                                        '    extn3_hr = tHr
                                        'Case 근무시간_연장4
                                        '    extn4_hr = tHr
                                        'Case 근무시간_야간
                                        '    NightHr = tHr
                                        'Case bc_근무시간구분_대체
                                        '    trans_hr = tHr

                                End Select

                            End If
                        Next
                    End If

                    eat_cnt = 0

                    ''--------------------------------------------------------------
                    ''주야구분별 정상시간 범위와 출근시간이 벗어 날때
                    ''--------------------------------------------------------------
                    'If std_toTm < frTm Then
                    '    ErrBc = "B720830"       '주야구분과 출근시간 불일치
                    'End If

                    ''--------------------------------------------------------------
                    ''총근무 시간 미달체크
                    ''--------------------------------------------------------------
                    'If work_hr < 2 Then
                    '    ErrBc = "B720600"       '근무시간 미달
                    'End If

                    '--------------------------------------------------------------
                    '사무직일때
                    '--------------------------------------------------------------

                    '--------------------------------------------------------------
                    '기능직일때
                    '--------------------------------------------------------------

                    '--------------------------------------------------------------
                    '연수생 일때
                    '--------------------------------------------------------------            

                    '--------------------------------------------------------------
                    '연장신청 불일치 -- 사무직만
                    '--------------------------------------------------------------


                    'If 0 < std_hr Then
                    '    std_hr = set_hr     '평일정상에는 기본시간을 갖다 놓음
                    'End If

                    '.Text("err_bc", iRow) = ErrBc '근태불일치내역
                    'PutTime("req_tm", iRow, reqTm)
                    'PutTime("act_tm", iRow, actTm)

                    PutTime("work_hr", iRow, work_hr) '총근무시간
                    'PutTime("set_hr", iRow, set_hr)'정상기준
                    '


                If DtBc = "GA120100" Then
                    PutTime("before_hr1", iRow, before_hr) '조출시간 park  -> 평일조출
                Else
                    PutTime("before_hr2", iRow, before_hr)  '휴일조출
                End If

                    PutTime("late_hr", iRow, late_hr) '지각시간
                    PutTime("off_hr", iRow, off_hr) '조퇴
                    PutTime("out_hr", iRow, out_hr) '외출

                    PutTime("t1_hr", iRow, t1Hr)    '연장시간
                    PutTime("t2_hr", iRow, t2Hr)    '
                    PutTime("t3_hr", iRow, t3Hr)    '
                    PutTime("t4_hr", iRow, t4Hr)    '
                    PutTime("t5_hr", iRow, t5Hr)    '
                    PutTime("t6_hr", iRow, t6Hr)   '
                    PutTime("t7_hr", iRow, t7Hr)   '
                    PutTime("t8_hr", iRow, t8Hr)   '
                    PutTime("t9_hr", iRow, t9Hr)   '
                    PutTime("t10_hr", iRow, t10Hr)   '
                    PutTime("t11_hr", iRow, t11Hr)   '
                    PutTime("t12_hr", iRow, t12Hr)   '
                    'PutTime("eat_cnt", iRow, eat_cnt)

            Catch ex As Exception

            End Try
        End With
    End Sub

    Private Sub PutTime(ByVal colNm As String, ByVal rowNo As Integer, ByVal valTm As Double)
        With g10
            If .ToDec(colNm, rowNo) <> valTm Then
                'If valTm = 0 Then
                If valTm = 0 And .Text(colNm, rowNo) <> "" Then
                    .Text(colNm, rowNo) = ""    '0.00 이 찍히면 보기 싫다
                Else
                    .Text(colNm, rowNo) = valTm
                End If
            Else
                If valTm = 0 And .Text(colNm, rowNo) <> "" Then
                    .Text(colNm, rowNo) = ""    '0.00 이 찍히면 보기 싫다
                End If
            End If
        End With
    End Sub

    '기준시간과 비교하여 조출 ~ 심야까지 자동 계산해 준다
    'INPUT ☞   sFtm :기준시작시간, sTtm : 기준종료시간
    '           sFrTm :입력시간, sToTm : 입력시간
    '           ty : 1 - 종료시간비교, 0 - 시작시간비교
    'OUTPUT ☞  항목별실근무시간(공제시간제외)

    Private Function CacuTm(ByVal inTm As String, ByVal outTm As String, _
                            ByVal sFrTm As String, ByVal sToTm As String, ByVal Ty As String, _
                            ByVal DnBc As String, ByVal DtBc As String, ByVal WorkBc As String, _
                            ByVal WorkYn As String) As Double

        '시간계산 ==> 24 기준
        '시간비교 ==> 12 기준

        If inTm = "" Or outTm = "" Or sFrTm = "" Or sToTm = "" Then Exit Function

        Dim wkTm As Double, lossTm As Double

        If sToTm <= sFrTm Then   '계산될 해당 시간
            sToTm = 24 + Mid(sToTm, 1, 2) & ":" & Mid(sToTm, 4, 2)
        End If

        'If outTm <= inTm Then   '출퇴근시간
        '    outTm = 24 + Microsoft.VisualBasic.Left(outTm, 2) & ":" & Microsoft.VisualBasic.Right(outTm, 2)
        'End If

        Dim AppFm As String = "", AppTm As String = ""
        Dim AppinFm As String, AppoutTm As String

        '[시간기준]==비교
        AppinFm = sFrTm
        AppoutTm = sToTm
        If outTm < sToTm Then
            AppoutTm = outTm
        End If
        '''출근20:30 / 퇴근31:30  공제시간 12:30인 경우 
        'If Microsoft.VisualBasic.Left(outTm, 2) > 24 Then
        '    If outTm < sToTm Then
        '        AppoutTm = outTm
        '    End If
        'Else
        '    If outTm < sToTm Then
        '        AppoutTm = outTm
        '    End If
        'End If

        If Ty = 2 Then
            AppinFm = inTm
            AppoutTm = outTm
            AppFm = inTm
            AppTm = outTm
        End If

        '[조출이 아니고 비교 대상 시간이 intm(출근시간) 보다 작다면 익일로 보고 24시간을 더한다]
        '정상시간은 출.퇴근시간만 이용하므로

        If Ty <> 0 Then
            If sFrTm < inTm And sToTm < inTm Then
                sFrTm = 24 + Mid(sFrTm, 1, 2) & ":" & Mid(sFrTm, 4, 2)
                sToTm = 24 + Mid(sToTm, 1, 2) & ":" & Mid(sToTm, 4, 2)
            End If
        End If

        '조출이면 조출기준 to < 출근 시간이면 계산 안한다
        If Ty = 0 Then
            If inTm < sToTm Then
                If sFrTm < inTm Then  '조출시작기준 보다 출근이늦으면 출근시간 적용
                    AppFm = inTm
                Else
                    AppFm = sFrTm    '조출시작기준 보다 먼져와도 조출시작기준 적용
                End If
                AppTm = sToTm
            End If
        End If

        If Ty = 1 Then
            If (inTm <= sFrTm And sToTm <= inTm) Or _
              (outTm <= sToTm And sFrTm >= outTm) Then       'rl
                Return 0
            Else
                AppFm = sFrTm
                AppTm = sToTm

                If inTm > sFrTm Then
                    AppFm = inTm
                End If
                If outTm < sToTm Then
                    AppTm = outTm
                End If
            End If
        End If

        '09:01 ~ 09:29 -> 09:30
        '09:31 ~ 09:59 -> 10:00
        'Dim MM As String = Mid(AppFm, 4, 2)
        'If "01" <= MM And MM <= "29" Then
        '    AppFm = Mid(AppFm, 1, 2) & ":30"
        'ElseIf "31" <= MM And MM <= "59" Then
        '    AppFm = 1 + Mid(AppFm, 1, 2) & ":00"
        '    If Len(AppFm) = 4 Then AppFm = "0" + AppFm
        '    'Else
        '    '    AppFm = Mid(AppFm, 1, 2) & ":00"
        'End If

        '17:01 ~ 17:29 -> 17:00
        '17:31 ~ 17:59 -> 17:30
        'MM = Mid(AppTm, 4, 2)
        'If "01" <= MM And MM <= "29" Then
        '    AppTm = Mid(AppTm, 1, 2) & ":00"
        'ElseIf "31" <= MM And MM <= "59" Then
        '    AppTm = Mid(AppTm, 1, 2) & ":30"
        '    If Len(AppTm) = 4 Then AppTm = "0" + AppTm
        'End If

        wkTm = MinuteDiff(AppFm, AppTm)

        'IF AppoutTm
        '24 + Microsoft.VisualBasic.Left(sToTm, 2) & ":" & Microsoft.VisualBasic.Right(sToTm, 2)

        'If Microsoft.VisualBasic.Left(AppoutTm, 2) < 24 And Microsoft.VisualBasic.Left(outTm, 2) > 12 Then
        '    outTm = Microsoft.VisualBasic.Right("00" & Microsoft.VisualBasic.Left(outTm, 2) - 24, 2) & ":" & Microsoft.VisualBasic.Right(outTm, 2)
        'End If

        If outTm < AppoutTm Then
            AppoutTm = outTm
        End If

        If WorkYn = "1" Then lossTm = CalLossTm(AppinFm, AppoutTm, DnBc, DtBc, WorkBc)

        If wkTm < lossTm Then lossTm = 0


        Dim convTm As Double = (wkTm - lossTm) / 60.0

        'Return DFix((convTm) / 0.5) * 0.5


        Return convTm
    End Function

    '[공제시간을 계산한다]
    'INPUT   ☞ InFtm : 출근시간, OutTtm : 퇴근시간, LoTmty : 조근무구분, LoDayTy : 휴일구분
    'OUTPUT  ☞ 공제시간합
    Private Function CalLossTm(ByVal InFtm As String, ByVal OutTtm As String, _
                               ByVal DnBc As String, ByVal DtBc As String, ByVal WorkBc As String) As Double
        Try

            Dim TotLossTm As Double
            TotLossTm = 0

            If Not IsEmpty(dSetBaseTime) Then

                Dim lossTyRows As DataRow() = _
                                dSetBaseTime.Tables(0).Select( _
                                "     work_ty     = '" & WorkBc & "'" & _
                                " AND dt_bc     = '" & DtBc & "'" & _
                                " AND dn_bc    = '" & DnBc & "'" & _
                                " AND work_yn    = '0'") '공제시간

                '"     work_bc     = '" & WorkBc & "'" & _
                '" AND dt_bc     = '" & DtBc & "'" & _
                '" AND dn_bc    = '" & DnBc & "'" & _
                '" AND work_yn    = '0'") '공제시간

                ' Dim BaseTbl As DataTable = lossTyRows(0).Table
                Dim gRow As Integer, Lossftm As String, Lossttm As String

                If InFtm >= OutTtm Then
                    'OutTtm = 24 + Microsoft.VisualBasic.Left(OutTtm, 2)
                    OutTtm = 24 + Microsoft.VisualBasic.Left(OutTtm, 2) & ":" & Microsoft.VisualBasic.Right(OutTtm, 2)
                End If

                If lossTyRows.GetLength(0) > 0 Then

                    For gRow = 0 To lossTyRows.GetLength(0) - 1
                        Lossftm = lossTyRows(gRow)((lossTyRows(gRow).Table.Columns("fr_tm")))
                        Lossttm = lossTyRows(gRow)((lossTyRows(gRow).Table.Columns("to_tm")))
                        '공제기준시간을 24시간 기준으로 변경
                        'If InFtm >= OutTtm Then
                        '    'OutTtm = 24 + Microsoft.VisualBasic.Left(OutTtm, 2)
                        '    OutTtm = 24 + Microsoft.VisualBasic.Left(OutTtm, 2) & ":" & Microsoft.VisualBasic.Right(OutTtm, 2)
                        '    Lossftm = 24 + Microsoft.VisualBasic.Left(Lossftm, 2) & ":" & Microsoft.VisualBasic.Right(Lossftm, 2)
                        '    Lossttm = 24 + Microsoft.VisualBasic.Left(Lossttm, 2) & ":" & Microsoft.VisualBasic.Right(Lossttm, 2)

                        'End If

                        'Lossftm = lossTyRows(gRow)((lossTyRows(gRow).Table.Columns("fr_tm")))
                        'Lossttm = lossTyRows(gRow)((lossTyRows(gRow).Table.Columns("to_tm")))

                        '[종료시간이 작으면 익일로 처리하므로 24시간을 더해준다]
                        If Lossftm >= Lossttm Then
                            Lossttm = 24 + Microsoft.VisualBasic.Left(Lossttm, 2) & ":" & Microsoft.VisualBasic.Right(Lossttm, 2)
                        End If

                        Dim AppFm As String       '종료시간(기본 공제종료시간으로 처리하고 퇴근시간이 더빠른경우
                        Dim AppTm As String       '종료시간(기본 공제종료시간으로 처리하고 퇴근시간이 더빠른경우

                        'If (Lossttm <= InFtm And Lossftm <= InFtm) Or _
                        '(Lossftm >= OutTtm And Lossttm >= OutTtm) Then       '공제종료시간이 근무시작시간보다작으면 공제시간 없음
                        If (Lossftm >= OutTtm) Or _
                            (Lossttm <= InFtm) Then        '공제종료시간이 근무시작시간보다작으면 공제시간 없음

                            AppFm = 0
                            AppTm = 0
                        Else
                            AppFm = Lossftm
                            AppTm = Lossttm
                            If Lossftm < InFtm Then
                                AppFm = InFtm
                            End If
                            If Lossttm > OutTtm Then
                                'AppFm = OutTtm
                                AppTm = OutTtm
                            End If
                        End If

                        '[공제시간계산 - 공제항목이 여러개가 있을수 있으므로 누적 처리 한다]
                        TotLossTm = TotLossTm + MinuteDiff(AppFm, AppTm)

                    Next gRow
                End If
            End If

            Return TotLossTm

        Catch ex As Exception

            Return 0
        End Try
    End Function

    Private Function HourDiff(ByVal frTm As String, ByVal toTm As String) As Double
        Dim ValFrTm As String = TimeFormat(frTm)
        Dim ValToTm As String = TimeFormat(toTm)
        Return (ValHour(ValFrTm, ValToTm))
    End Function

    '******************************************************************************
    'Description: 시간을 분으로 계산처리
    '작성일: 2003-07-26
    '작성자: 이소영
    '******************************************************************************
    Private Function MinuteDiff(ByVal frTm As String, ByVal toTm As String) As Integer

        Dim valFrtm As String = TimeFormat(frTm)
        Dim valTotm As String = TimeFormat(toTm)

        'Return ValMinute(valFrtm, valTotm)
        Return ValHour(valFrtm, valTotm, 1)
    End Function

    '분으로 처리하려면 hmty = 1이라고 하면 된다
    Private Function ValHour(ByVal frTm As String, ByVal toTm As String, Optional ByVal hmTy As Integer = 60) As Double
        Try
            Dim fMaxLen As Integer
            Dim fPoint As Integer
            Dim fHour As String
            Dim fMinute As String

            If frTm = "" Or toTm = "" Then Return 0

            '입력시간이 숫자로만 구성되어 있다면 시간만 입력한것으로 인식하도록
            If IsNumeric(frTm) Then
                If Len(frTm) <> 4 Then Return 0

                '****시와분으로 나눈다
                '****시간은 * 60분
                fHour = Microsoft.VisualBasic.Left(frTm, 2)
                fMinute = Microsoft.VisualBasic.Right(frTm, 2)
            Else

                fMaxLen = Len(frTm)
                fPoint = InStr(frTm, ":")

                If fPoint = 0 Then
                    fPoint = InStr(frTm, ".")
                End If

                '****형식중 (:00)  이런 형식인 경우 오류
                If fPoint <= 1 Then Return 0

                '****시와분으로 나눈다
                '****시간은 * 60분
                fHour = Microsoft.VisualBasic.Left(frTm, fPoint - 1)
                fMinute = Microsoft.VisualBasic.Right(frTm, fMaxLen - fPoint)
            End If

            Dim tMaxLen As Integer
            Dim tPoint As Integer
            Dim tHour As String
            Dim tMinute As String


            '입력시간이 숫자로만 구성되어 있다면 시간만 입력한것으로 인식하도록
            If IsNumeric(toTm) Then
                If Len(toTm) <> 4 Then Return 0

                '****시와분으로 나눈다
                '****시간은 * 60분
                tHour = Microsoft.VisualBasic.Left(toTm, 2)
                tMinute = Microsoft.VisualBasic.Right(toTm, 2)
            Else

                tMaxLen = Len(toTm)
                tPoint = InStr(toTm, ":")

                If tPoint = 0 Then
                    tPoint = InStr(toTm, ".")
                End If

                '****형식중 (:00)  이런 형식인 경우 오류
                If tPoint <= 1 Then Return 0

                '****시와분으로 나눈다
                '****시간은 * 60분
                tHour = Microsoft.VisualBasic.Left(toTm, fPoint - 1)
                tMinute = Microsoft.VisualBasic.Right(toTm, tMaxLen - tPoint)
            End If

            Dim Hour As Integer, Minu As Integer
            Dim BaseHr As Integer
            BaseHr = 24

            If fHour > tHour Then
                Hour = (BaseHr - fHour + tHour) * 60
            Else
                Hour = (tHour - fHour) * 60
            End If

            If fMinute > tMinute Then
                Hour = Hour - 60
                tMinute = tMinute + 60
            End If

            Minu = (tMinute - fMinute)
            'If fMinute > tMinute Then
            '    Minu = (tMinute - fMinute)
            'Else
            '    Minu = (fMinute - tMinute)
            'End If


            '분으로 산출
            If hmTy = 1 Then
                Return ToDec(Hour) + ToDec(Minu)
            Else
                '시간으로 산출시 (소수점 2자리버림)
                Return DRound((ToDec(Hour) + ToDec(Minu)) / 60, 2)
            End If

            ' Return DRound((Dec(Hour) + Dec(Minu)) / Dev, 2)

        Catch ex As Exception
            MessageError(ex)
            Return 0
        End Try
    End Function

    '******************************************************************************
    'Description: Round함수의 문제점 보완한 함수
    '    - Round함수를 사용할 경우 다음의 문제가 있다.
    '            Round(10.35,  1) -> 10.4
    '            Round(10.45,  1) -> 10.4         <---- 10.5가 맞다
    '            Round(10.451, 1) -> 10.5
    '            Round(10.46,  1) -> 10.5         
    '    - 0.5인 경우 가까운 짝수로 무조건 정해짐
    '******************************************************************************

    Private Function DRound(ByVal number As Decimal, Optional ByVal digits As Integer = 0) As Decimal
        If digits < 0 Then
            MessageError("digit가 0 이상이어야 합니다", "반올림", "Round(" & number & "," & digits & ")")
            Exit Function
        End If

        Dim strTmp As String = CStr(number)

        Dim iPos = InStr(strTmp, ".")

        If strTmp.IndexOf(".") < 0 Then
            '소수점이 없다
            Return number
        End If

        Dim scale As Integer = Len(strTmp) - iPos
        If scale < (digits + 1) Then
            '만약 (소수점아래수 < 반올림요청자리수) 이면 반올림할 필요없다.
            Return number
        ElseIf scale = (digits + 1) Then
            'Round함수의 문제점 보완
            strTmp += "1"
            number = CDbl(strTmp)
        End If

        Try
            Return Math.Round(number, digits)
        Catch ex As Exception
            MessageError("digit가 0이상이어야 합니다", "반올림", "Round(" & number & "," & digits & ")")
        End Try

    End Function

    Private Function DFix(ByVal number As Double) As Decimal
        Try
            Return CLng(Fix(number))
        Catch ex As Exception
            MessageError(ex.Message, "절사", "DFix(" & number & ")")
            'MsgError("digit가 0이상이어야 합니다", "절사", "Fix(" & number & ")")
        End Try
    End Function



    Private Sub bef_yn_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles bef_yn.CheckedChanged
        Me.ColVisible()
    End Sub

    Private Sub ColVisible()
        g10.ColumnVisible("fr_tm2") = bef_yn.Checked
        g10.ColumnVisible("to_tm2") = bef_yn.Checked
        g10.ColumnVisible("atn_cd2") = bef_yn.Checked
        g10.ColumnVisible("dn_bc2") = bef_yn.Checked
    End Sub


    Private Sub btn_show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_show.Click
        pnlshow.Visible = Not pnlshow.Visible
    End Sub

    Public Sub Open3(ByVal empno As String, ByVal workdt As String, ByVal deptcd As String) ' ByVal workbc As String,

        emp_no.Text = empno
        fr_dt.Text = workdt

        'work_bc.Text = workbc
        dept_cd.Text = deptcd

        Me.Open()

    End Sub


    Private Sub btn_print_Click(sender As System.Object, e As System.EventArgs) Handles btn_print.Click
        Dim p As OpenParameters = New OpenParameters

        p.Add("@co_cd", co_cd.Text)
        p.Add("@bs_cd", bs_cd.Text)
        p.Add("@work_bc", work_bc.Text)
        p.Add("@fr_dt", fr_dt.Text)
        p.Add("@to_dt", to_dt.Text)
        p.Add("@work_kd", work_kd.Text)
        p.Add("@chk_frtm", chk_frtm.Text)
        p.Add("@chk_totm", chk_totm.Text)

        If g20.Text("dept_cd") = "" Then
            p.Add("@dept_cd", dept_cd.Text)
        Else
            p.Add("@dept_cd", g20.Text("dept_cd"))
        End If

        For Row As Integer = 0 To g20.RowCount - 1
            If g20.Text("chk_p", Row) = "1" Then
                p.Add("@emp_no", g20.Text("emp_no", Row))
                p.Add("@chk_p", g20.Text("chk_p", Row))
                OpenDataSet("gad110_in_print", p)
            End If
        Next

        System7.ReportView.LoadView("GAD110_IN", "", "gad110_in_print", p)
        OpenDataSet("gad110_in_print_update", p)

    End Sub


    'SMK   20150508 
#Region "일근태 PDF파일 저장"
    Private Sub file_save_Click(sender As System.Object, e As System.EventArgs) Handles file_save.Click
        Dim cnt As Integer = 0
        save_ing.Visible = True
        save_end.Visible = False

        Try
            With g10

                Dim body As New ReportDocument
                Dim p As OpenParameters = New OpenParameters

                p.Add("@co_cd", co_cd.Text)
                p.Add("@bs_cd", bs_cd.Text)
                p.Add("@work_bc", work_bc.Text)
                p.Add("@fr_dt", fr_dt.Text)
                p.Add("@to_dt", to_dt.Text)
                p.Add("@work_kd", work_kd.Text)
                p.Add("@chk_frtm", chk_frtm.Text)
                p.Add("@chk_totm", chk_totm.Text)

                If g20.Text("dept_cd") = "" Then
                    p.Add("@dept_cd", dept_cd.Text)
                Else
                    p.Add("@dept_cd", g20.Text("dept_cd"))
                End If

                For Row As Integer = 0 To g20.RowCount - 1
                    If g20.Text("chk_p", Row) = "1" Then
                        p.Add("@emp_no", g20.Text("emp_no", Row))
                        p.Add("@chk_p", g20.Text("chk_p", Row))
                        'OpenDataSet("gad110_in_print", p)
                        '    End If
                        'Next

                        Dim formCd As String = ""
                        Dim document As ReportDocument = Nothing     '크리스탈 리포트 뷰를 불러오기. 
                        'Dim dSet As DataSet = Link.ReadDataSet("mmb100_print", p)
                        'Dim dSet As DataSet = Link.ReadDataSet("", p)   'Link.ReadDataSet("워크셋이름", 파라미터)
                        Dim dSet As DataSet = New DataSet

                        dSet = Link.ReadDataSet("gad110_in_print", p)

                        Dim dRow As DataRow, dRows As DataRowCollection
                        dRows = dSet.Tables(0).Rows

                        For Each dRow In dRows

                            If (document Is Nothing) Then
                                formCd = GAD110_IN._GetFileName("GAD110_IN")    'MMB100 'formCd = 자기자신._GetFileName(레포트엔트리이름)
                                If (formCd = "") Then
                                    Exit Sub
                                End If

                                Dim expression As ReportDocument = DirectCast(GAD110_IN._LoadAssembly(formCd, "System7"), ReportDocument)    'CrystalReport에서 가져오기.(자기자신._LoadAssembly(formCd, "System7"), ReportDocument)
                                If Information.IsNothing(expression) Then
                                    MessageInfo((formCd & ".dll Instance " & ChrW(47484) & " " & ChrW(49373) & ChrW(49457) & ChrW(54624) & " " & ChrW(49688) & " " & ChrW(50630) & ChrW(49845) & ChrW(45768) & ChrW(45796) & "."), Nothing, Nothing)
                                    Exit Sub
                                End If
                                document = expression
                            End If

                            If IsEmpty(dSet) Then
                                MessageInfo(ChrW(52636) & ChrW(47141) & ChrW(54624) & " " & ChrW(51088) & ChrW(47308) & ChrW(44032) & " " & ChrW(50630) & ChrW(49845) & ChrW(45768) & ChrW(45796), Nothing, Nothing)
                                Exit Sub
                            End If
                            document.SetDataSource(dSet.Tables.Item(0))

                            ' 변수를 선언하고 내보내기 옵션을 가져옵니다.
                            Dim CrExportOptions As ExportOptions
                            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                            Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()

                            '파일 이름 설정 'CrDiskFileDestinationOptions.DiskFileName = "c:\" & g10.Text("cs_cd", i) & i & ".pdf"                            
                            '20141121 SMK 추가.
                            IO.Directory.CreateDirectory("c:\" & "일근태등록\" & Mid(fr_dt.Text, 1, 7))   '폴더 생성 SMK

                            CrDiskFileDestinationOptions.DiskFileName = "c:\" & "일근태등록\" & Mid(fr_dt.Text, 1, 7) & "\" & dRow("emp_no") & "_" & dRow("emp_nm") & ".pdf"

                            CrExportOptions = document.ExportOptions            '파일 내보내기 옵션
                            With CrExportOptions
                                .ExportDestinationType = ExportDestinationType.DiskFile
                                .ExportFormatType = ExportFormatType.PortableDocFormat
                                .DestinationOptions = CrDiskFileDestinationOptions
                                .FormatOptions = CrFormatTypeOptions
                            End With
                            'Next

                            document.Export()    '여기에서 에러남 (매개 변수 값이 없습니다.) -> 서브리포트 쪽에 document.OpenSubreport("sub").SetDataSource(dtSet.Tables.Item(0)) 로 해결함.
                            document.Dispose()
                            document.Close()
                            'If SmtpAccess.Connect = 1 Then

                        Next
                        cnt = cnt + 1
                        OpenDataSet("gad110_in_print_update", p)
                    End If
                Next
            End With

            save_ing.Visible = False
            save_end.Visible = True
            MessageInfo("[C:\일근태등록\" & Mid(fr_dt.Text, 1, 7) & "] 파일 저장을 완료하였습니다.")

        Catch ex As Exception
            MessageInfo(ex)

        End Try
    End Sub


    Private Shared Function _GetFileName(ByVal reportCode As String) As String
        Dim str As String
        Dim str2 As String = ""
        Try
            Dim openParams As New OpenParameters
            openParams.Add("@rpt_cd", reportCode, QueryParameterType.Text, QueryParameterKind.Parameter)
            Dim dtSet As DataSet = Link.ReadDataSet("common_get_report_file", openParams)
            If Not IsEmpty(dtSet) Then
                str2 = DataValue(dtSet, "file_nm", 0, False)
            End If
            If (str2 = "") Then
                MessageInfo("Report " & ChrW(51221) & ChrW(48372) & ChrW(44032) & " " & ChrW(46321) & ChrW(47197) & ChrW(46104) & ChrW(50612) & " " & ChrW(51080) & ChrW(51648) & " " & ChrW(50506) & ChrW(49845) & ChrW(45768) & ChrW(45796) & ".", Nothing, Nothing)
                Return ""
            End If
            str = str2
        Catch exception1 As Exception
            Dim excp As Exception = exception1
            MessageError(excp, Nothing, "Main.Report.GetReportFile()")
            str = ""
            Return str
        End Try
        Return str
    End Function

    Private Shared Function _LoadAssembly(ByVal formCd As String, Optional ByVal rootNameSpace As String = "WP_SA1285") As Object
        Dim obj2 As Object
        Dim assembly As Reflection.Assembly
        Try
            [assembly] = Reflection.Assembly.Load(formCd)
            If ([assembly] Is Nothing) Then
                Return Nothing
            End If
        Catch exception1 As FileNotFoundException
            Dim exception As FileNotFoundException = exception1
            MessageInfo((ChrW(54532) & ChrW(47196) & ChrW(44536) & ChrW(47016) & ChrW(51012) & " " & ChrW(52286) & ChrW(51012) & " " & ChrW(49688) & " " & ChrW(50630) & ChrW(49845) & ChrW(45768) & ChrW(45796) & ": " & formCd), Nothing, Nothing)
            obj2 = Nothing
            Return obj2
        Catch exception4 As Exception
            Dim excp As Exception = exception4
            MessageError(excp, Nothing, Nothing)
            obj2 = Nothing
            Return obj2
        End Try
        Dim type As Type = Nothing
        Dim objectValue As Object = Nothing
        Try
            Dim name As String = formCd
            If Not name.StartsWith(rootNameSpace) Then
                name = (rootNameSpace & "." & formCd)
            End If
            type = [assembly].GetType(name)
            If (type Is Nothing) Then
                Return Nothing
            End If
            objectValue = RuntimeHelpers.GetObjectValue(Activator.CreateInstance(type))
        Catch exception5 As Exception
            Dim exception3 As Exception = exception5
            MessageError(exception3, Nothing, Nothing)
        End Try
        Return objectValue
    End Function

#End Region

End Class

