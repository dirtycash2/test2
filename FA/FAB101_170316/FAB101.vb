﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class FAB101

    Private Sub FAB101_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.IsManager Then
            dept_cd.ReadOnly = False
        End If

        g30.RecordNavigator = True

    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
                chk_all.Text = ""
                MyBase.Open()

                'Case MenuType.Save
                '    MyBase.Save()
                '    MyBase.Open()

                'Case MenuType.Delete
                '    Me.WorkSets("sca100_f10").DeleteRow()   '특정Workset을 삭제


            Case MenuType.Print
                Me.Print()

            Case Else
                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

        End Select

    End Sub

    Private Sub chk_all_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_all.CheckedChanged

        g10.CheckRows("chk", chk_all.Checked)

    End Sub

#Region " Jump "

    Private Sub g10_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles g10.DoubleClick
        Dim menuName As String
        'If Parameter.System.Code = "CSI" Then
        '    menuName = "FAB100_CSI"
        'Else
        menuName = "FAB100"
        'End If
        '화면을 띄운다
        Dim ctr As Object = Parameter.MainFrame.Frame.CallMenuForm(menuName) 'New FormAttribute(menuName, menuText))
        If ctr IsNot Nothing Then
            ctr.Open2(g10.Text("doc_no"))
        End If
    End Sub

    Private Sub g30_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles g30.DoubleClick
        Dim menuName As String
        'If Parameter.System.Code = "CSI" Then
        '    menuName = "FAB100_CSI"
        'Else
        menuName = "FAB100"
        'End If
        Dim ctr As Object = Parameter.MainFrame.Frame.CallMenuForm(menuName) 'New FormAttribute(menuName, menuText))
        If ctr IsNot Nothing Then
            ctr.Open2(g30.Text("doc_no"))
        End If
    End Sub


#End Region

    Private Sub Print()

        Dim cnt As Integer = g10.CheckedRows("chk")     'Check된 행의 갯수
        If cnt = 0 Then
            Exit Sub
        End If

        Dim preview As Boolean
        If cnt = 1 Then             'Check된 행이 하나이면 리포트 미리보기를 하고 아니면 바로 출력한다
            preview = True
        End If

        For i As Integer = 0 To g10.RowCount - 1
            If g10.ToBool("chk", i) Then
                Dim p As OpenParameters = New OpenParameters

                p.Add("@co_cd", g10.Text("co_cd", i))
                p.Add("@div_cd", g10.Text("div_cd", i))
                p.Add("@doc_no", g10.Text("doc_no", i))

                System7.ReportView.LoadView("FAB101", "", "fab100_print", p, , preview)     '전표출력
            End If
        Next

    End Sub

#Region " 계정검색조건 제어"

    Private m_fr_acc_cd As String
    Private m_to_acc_cd As String
    Private m_stop_event As Boolean

    Private Sub acc_nm_TextChanged(ByVal sender As System.Object, ByVal oldValue As System.String) Handles acc_nm.TextChanged
        If m_stop_event Then Exit Sub
        m_stop_event = True

        If acc_nm.Text <> "" Then
            m_fr_acc_cd = fr_acc_cd.Text
            m_to_acc_cd = to_acc_cd.Text
            If fr_acc_cd.Text <> "" Then fr_acc_cd.Text = ""
            If to_acc_cd.Text <> "" Then to_acc_cd.Text = ""
        Else
            fr_acc_cd.Text = m_fr_acc_cd
            to_acc_cd.Text = m_to_acc_cd
        End If

        m_stop_event = False
    End Sub

    Private Sub fr_acc_cd_TextChanged(ByVal sender As Object, ByVal oldValue As String) Handles fr_acc_cd.TextChanged, to_acc_cd.TextChanged, to_amt2.TextChanged, to_amt1.TextChanged, fr_amt2.TextChanged, fr_amt1.TextChanged
        If m_stop_event Then Exit Sub
        m_stop_event = True
        acc_cd.Text = ""
        m_stop_event = False
    End Sub

#End Region

    Public Sub Open2(ByVal acccd As String, ByVal frdt As String, ByVal todt As String)

        fr_dt.Text = frdt
        to_dt.Text = todt
        dept_cd.Text = ""
        acc_cd.Text = acccd

        MyBase.Open()
    End Sub






End Class
