﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class FAB700

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _open()
        make_tot.ReadOnly = True
        make_costprice.ReadOnly = True
        make_manage.ReadOnly = True
        make_profit.ReadOnly = True
        make_cost.ReadOnly = True
        make_sprofit.ReadOnly = True
        make_sloss.ReadOnly = True
        make_tax.ReadOnly = True
        make_tprofit.ReadOnly = True

    End Sub


    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
                _open()

            Case Else
                MyBase.MenuButton_Click(mty)
        End Select

    End Sub

    Private Sub _open()
        Try
            'make_amt17.Text = "0"
            'make_amt29.Text = "0"
            'make_amt34.Text = "0"
            'pl_amt17.Text = "0"

            Me.Open()
            amt_cal()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub amt_cal()
        Try
            make_amt18.Text = make_amt13.ToDec + make_amt14.ToDec + make_amt15.ToDec - make_amt16.ToDec - make_amt17.ToDec - make_amt7.ToDec
            make_amt30.Text = make_amt25.ToDec + make_amt26.ToDec + make_amt27.ToDec - make_amt28.ToDec - make_amt29.ToDec - make_amt9.ToDec
            make_amt7.Text = make_amt7.ToDec
            make_amt7_1.Text = make_amt18.ToDec + make_amt30.ToDec
            make_amt8.Text = make_amt8.ToDec
            make_amt9.Text = make_amt9.ToDec
            make_amt17.Text = make_amt17.ToDec
            make_amt29.Text = make_amt29.ToDec
            make_amt32.Text = make_amt7_1.ToDec + make_amt24.ToDec
            make_amt33_1.Text = make_amt33_1.ToDec
            make_amt33_2.Text = make_amt33_1.ToDec + make_amt7_1.ToDec
            make_amt38.Text = make_amt33.ToDec + make_amt33_2.ToDec - make_amt34.ToDec
            pl_amt14.Text = make_amt38.ToDec
            pl_amt18.Text = pl_amt13.ToDec + pl_amt14.ToDec + pl_amt15.ToDec - pl_amt16.ToDec - pl_amt17.ToDec
            pl_amt6.Text = pl_amt1.ToDec + pl_amt2.ToDec + pl_amt3.ToDec - pl_amt5.ToDec
            make_costprice.Text = pl_amt18.ToDec + pl_amt6.ToDec
            make_tot.Text = make_tot.ToDec

        Catch ex As Exception

        End Try
    End Sub

    Private Sub make_amt17_TextChanged(sender As System.Object, oldValue As System.String)
        amt_cal()
    End Sub

    Private Sub make_amt29_TextChanged(sender As System.Object, oldValue As System.String) Handles make_amt29.TextChanged, make_amt17.TextChanged
        amt_cal()
    End Sub

    Private Sub make_amt34_TextChanged(sender As System.Object, oldValue As System.String) Handles make_amt34.TextChanged
        amt_cal()
    End Sub


    Private Sub pl_amt17_TextChanged(sender As System.Object, oldValue As System.String) Handles pl_amt17.TextChanged
        amt_cal()
    End Sub


    Private Sub pl_amt5_TextChanged(sender As System.Object, oldValue As System.String) Handles pl_amt5.TextChanged
        amt_cal()
    End Sub

    'Private Sub chk_doc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_doc.Click
    '    If doc_no.Text <> "" Then
    '        MessageInfo("먼저 전표를 삭제 하세요")
    '        Exit Sub
    '    End If

    '    If MessageYesNo("전표를 생성하시겠습니까?") = MsgBoxResult.No Then
    '        Exit Sub
    '    End If

    '    Me.Open("fab700_Work")
    '    Me.Open("fab700_g10")

    'End Sub

    'Private Sub btn_jump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_jump.Click
    '    If doc_no.Text = "" Then
    '        Exit Sub
    '    End If

    '    Dim menuName As String
    '    menuName = "FAB100"

    '    '화면을 띄운다
    '    Dim ctr As Object = Parameter.MainFrame.Frame.CallMenuForm(menuName)
    '    If ctr IsNot Nothing Then
    '        ctr.Open2(doc_no.Text)
    '    End If
    'End Sub

    Private Sub chk_del_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_del.Click
        If doc_no.Text = "" Then
            MessageInfo("먼저 전표를 선택하세요")
            Exit Sub
        End If

        If MessageYesNo("전표를 삭제하시겠습니까?") = MsgBoxResult.No Then
            Exit Sub
        End If

        Me.Open("fab700_delete")
        Me.Open("fab700_g10")

    End Sub

    Private Sub chk_doc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_doc.Click ', chk_del.Click, btn_jump.Click
        Try

            '전표화면 찾기
            Dim menuName As String = "FAB100"
            Dim ctr As Object = Parameter.MainFrame.Frame.CallMenuForm(menuName)
            Dim getdate As Date = fr_mon.Text + "-01"

            getdate = getdate.AddMonths(1).AddDays(-1)

            Dim all_amt(15) As Decimal

            all_amt(0) = make_amt18.ToDec                               '원재료
            all_amt(1) = make_amt30.ToDec                               '부재료
            all_amt(2) = make_amt7_1.ToDec                                '재료비계
            all_amt(3) = make_amt24.ToDec                               '경비
            all_amt(4) = make_amt32.ToDec                               '당기총제조
            all_amt(5) = make_amt33.ToDec                               '기초재공
            all_amt(13) = make_amt33_1.ToDec                               '재공대체
            all_amt(6) = make_amt34.ToDec                               '기말재공
            all_amt(7) = make_amt32.ToDec - make_amt34.ToDec            '당기총제조-기말재공(당기제품제조원가)
            all_amt(8) = pl_amt2.ToDec                                  '당기상품원가
            all_amt(9) = pl_amt14.ToDec                                 '당기제품제조원가
            all_amt(10) = pl_amt18.ToDec                                '당기제품원가
            all_amt(11) = pl_amt18.ToDec + pl_amt2.ToDec                '매출원가
            all_amt(12) = make_amt8.ToDec                               '노무비

            'ctr.Set_Origin_Rows4(all_amt, getdate)

            ctr.Set_Origin_Rows4(g10)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub add_g10()
        Dim all_amt(15) As Decimal

        all_amt(0) = make_amt18.ToDec                               '원재료
        all_amt(1) = make_amt30.ToDec                               '부재료
        all_amt(2) = make_amt7_1.ToDec                                '재료비계
        all_amt(3) = make_amt24.ToDec                               '경비
        all_amt(4) = make_amt32.ToDec                               '당기총제조
        all_amt(5) = make_amt33.ToDec                               '기초재공
        all_amt(6) = make_amt34.ToDec                               '기말재공
        all_amt(7) = make_amt32.ToDec - make_amt34.ToDec            '당기총제조-기말재공(당기제품제조원가)
        all_amt(8) = pl_amt2.ToDec                                  '당기상품원가
        all_amt(9) = pl_amt14.ToDec                                 '당기제품제조원가
        all_amt(10) = pl_amt18.ToDec                                '당기제품원가
        all_amt(11) = pl_amt18.ToDec + pl_amt2.ToDec                '매출원가
        all_amt(12) = make_amt8.ToDec                               '노무비
        g10.Open()
        With g10

            '1.원재료의 원재료비 대체
            .AddNewRow()
            '원재료
            .Text("acc_cd") = "1120500"
            .Text("amt1") = "0"
            .Text("amt2") = all_amt(0)
            '.Text("dsc2") = "원재료"

            '원재료비
            .AddNewRow()
            .Text("acc_cd") = "4101000"
            .Text("amt1") = all_amt(0)
            .Text("amt2") = "0"
            '.Text("dsc2") = "[원재료비]"

            '2. 부재료의 부재료비 대체
            .AddNewRow()
            '부재료
            .Text("acc_cd") = "1120700"
            .Text("amt1") = "0"
            .Text("amt2") = all_amt(1)
            '.Text("dsc2") = "원재료"

            '부재료비
            .AddNewRow()
            .Text("acc_cd") = "4102000"
            .Text("amt1") = all_amt(1)
            .Text("amt2") = "0"
            '.Text("dsc2") = "[부재료비]"

            '3. 원재료비 + 부재료비의 반제품(재공) 대체
            '원재료비
            .AddNewRow()
            .Text("acc_cd") = "4101000"
            .Text("amt1") = "0"
            .Text("amt2") = all_amt(0)
            '.Text("dsc2") = "[원재료비]"

            '부재료비
            .AddNewRow()
            .Text("acc_cd") = "4102000"
            .Text("amt1") = "0"
            .Text("amt2") = all_amt(1)
            '.Text("dsc2") = "[부재료비]"

            '반제품(재공) 
            .AddNewRow()
            .Text("acc_cd") = "1120400"
            .Text("amt1") = all_amt(2)
            .Text("amt2") = "0"
            '.Text("dsc2") = "[반제품(재공)]"


            '4. 반제품(재공)의 제품 대체
            '반제품(재공)
            .AddNewRow()
            .Text("acc_cd") = "1120400"
            .Text("amt1") = "0"
            .Text("amt2") = all_amt(9)
            '.Text("dsc2") = "[재공품)]"
            '제품
            .AddNewRow()
            .Text("acc_cd") = "1120200"
            .Text("amt1") = all_amt(9)
            .Text("amt2") = "0"
            '.Text("dsc2") = "제품"

            '5.제품의 매출원가 대체
            '제품
            .AddNewRow()
            .Text("acc_cd") = "1120200"
            .Text("amt1") = "0"
            .Text("amt2") = all_amt(10)
            '.Text("dsc2") = "[제품]"

            '제품매출원가
            .AddNewRow()
            .Text("acc_cd") = "5112100"
            .Text("amt1") = all_amt(10)
            .Text("amt2") = "0"
            '.Text("dsc2") = "[제품매출원가]"

            '6.상품의 매출원가 대체
            '상품
            .AddNewRow()
            .Text("acc_cd") = "1120100"
            .Text("amt1") = "0"
            .Text("amt2") = all_amt(8)
            '.Text("dsc2") = "상품"

            '상품매출원가
            .AddNewRow()
            .Text("acc_cd") = "5112220"
            .Text("amt1") = all_amt(8)
            .Text("amt2") = "0"
            '.Text("dsc2") = "[상품매출원가]"


            '차 재공품  / 재료비
            '차 재공품/노무비 --별도구성
            '차 재공품 /제조경비 --별도구성
            '차 제품 / 재공품
            '차 제품매출원가/ 제품
            '차 상품매출원가/상품


            ''경비
            '.AddNewRow()
            '.Text("acc_cd") = "4104001"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(3)
            '.Text("dsc2") = "[경비]"

            ''당기총제조
            '.AddNewRow()
            '.Text("acc_cd") = "4105001"
            '.Text("amt1") = all_amt(4)
            '.Text("amt2") = "0"
            ''.Text("dsc2") = "[당기총제조비용]"

            ''재공품-기초재공
            '.AddNewRow()
            '.Text("acc_cd") = "1120400"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(5)
            ''.Text("dsc2") = "재공품"

            ''당기제품제조원가
            '.AddNewRow()
            '.Text("acc_cd") = "5102110"
            '.Text("amt1") = all_amt(5)
            '.Text("amt2") = "0"
            ''.Text("dsc2") = "[당기제품제조원가]"

            ''당기총제조비용
            '.AddNewRow()
            '.Text("acc_cd") = "4105001"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(6)
            ''.Text("dsc2") = "[당기총제조비용]"

            ''재공품-기말재고
            '.AddNewRow()
            '.Text("acc_cd") = "1120400"
            '.Text("amt1") = all_amt(6)
            '.Text("amt2") = "0"
            ''.Text("dsc2") = "재공품-기말재고"

            ''당기제품제조원가
            '.AddNewRow()
            '.Text("acc_cd") = "5102110"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(7)
            ''.Text("dsc2") = "[당기제품제조원가]"

            ''당기총제조비용
            '.AddNewRow()
            '.Text("acc_cd") = "4105001"
            '.Text("amt1") = all_amt(7)
            '.Text("amt2") = "0"
            ''.Text("dsc2") = "당기총제조비용"

            ''상품
            '.AddNewRow()
            '.Text("acc_cd") = "1120100"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(8)
            ''.Text("dsc2") = "상품"

            ''상품매출원가
            '.AddNewRow()
            '.Text("acc_cd") = "5102240"
            '.Text("amt1") = all_amt(8)
            '.Text("amt2") = "0"
            ''.Text("dsc2") = "[상품매출원가]"

            ''제품
            '.AddNewRow()
            '.Text("acc_cd") = "1120200"
            '.Text("amt1") = all_amt(9)
            '.Text("amt2") = "0"
            ''.Text("dsc2") = "제품"

            ''당기제품제조원가
            '.AddNewRow()
            '.Text("acc_cd") = "5102110"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(9)
            ''.Text("dsc2") = "[당기제품제조원가]"

            ''제품매출원가
            '.AddNewRow()
            '.Text("acc_cd") = "5102230"
            '.Text("amt1") = all_amt(10)
            '.Text("amt2") = "0"
            ''.Text("dsc2") = "[제품매출원가]"

            ''제품
            '.AddNewRow()
            '.Text("acc_cd") = "1120200"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(10)
            ''.Text("dsc2") = "[제품]"

            ''매출원가
            '.AddNewRow()
            '.Text("acc_cd") = "5102900"
            '.Text("amt1") = all_amt(11)
            '.Text("amt2") = "0"
            ''.Text("dsc2") = "[매출원가]"

            ''상품매출원가
            '.AddNewRow()
            '.Text("acc_cd") = "5102240"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(8)
            ''.Text("dsc2") = "[상품매출원가]"

            ''제품매출원가
            '.AddNewRow()
            '.Text("acc_cd") = "5102230"
            '.Text("amt1") = "0"
            '.Text("amt2") = all_amt(10)
            ''.Text("dsc2") = "[제품매출원가]"


        End With
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If e.Page.Name = "XtraTabPage3" And doc_no.Text = "" Then
            add_g10()
        End If

    End Sub


End Class
