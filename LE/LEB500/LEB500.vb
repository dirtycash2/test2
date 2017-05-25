﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports System.Data

Public Class LEB500
    Private Sub ME_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        SplitContainer3.Panel1Collapsed = Not chk_show.Checked

        'Me.Open()

        ''매입세금계산서번호 채번
        'doc_no.CodeNo = "FAC100"        'Function dbo.[fnCodeNo]안에 LEB100에 대한 코딩을 해야 한다
        'doc_no.CodeDateField = set_dt

        'Me.New_Form()

    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open

                New_Form()
                'MyBase.Open()   '기본Open()기능을 호출한다 만약 기본이 아닌기능을 
                '사용하려면 재정의 가능하다
            Case MenuType.Save
                Me.Save()
                'If MyBase.Save() Then

                'MyBase.Open()
                ' End If

            Case MenuType.Delete
                'Me.WorkSets("sca100_f10").DeleteRow()   '특정Workset을 삭제

            Case MenuType.New
                ' Me.WorkSets("lea200_g10").AddNew()  '특정Workset 신규처리
                New_Form()
            Case MenuType.Print
                ' Me.Print()

            Case Else
                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

        End Select

    End Sub

    Private Sub New_Form()
        doc_no.Text = ""
        set_dt.Text = ""

        Me._Open()
    End Sub

    Private Sub _Open()
        Me.Open()

        Me.Sum_All()
        chk_all.Checked = False
    End Sub

    Private Sub btn_doc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_doc.Click
        Dim Sal_bs As String = "", sumCust As String = "", taxTy As String = ""

        'Dim iCnt As Integer = CheckedGridRow(epfs102f_g1, "chk1")
        'Dim itm As String = "", cnt As Decimal = 0, qty As Decimal = 0, up As Decimal = Nothing

        If doc_no.Text <> "" Then
            MessageInfo("이미 전표가 발행되었습니다")
            Exit Sub
        End If

        If Not CheckRequired(set_dt) Then
            Exit Sub
        End If

        '작업전 체크
        With g20
            Dim custCd As String = ""
            For i As Integer = 0 To .RowCount - 1
                If .ToBool("chk", i) Then

                    If .Text("cust_cd", i) = "" Then
                        MessageInfo("매입처는 필수입니다")
                        Exit Sub
                    End If

                    If .Text("tax_bc", i) = "" Then
                        MessageInfo("부가세구분은 필수입니다")
                        Exit Sub
                    End If

                    ' 동일 거래처  체크
                    If custCd = "" Then
                        custCd = .Text("cust_cd", i)
                    End If

                    If custCd <> .Text("cust_cd", i) Then
                        MessageInfo("동일한 매입처만 전표처리 가능 합니다")
                        Exit Sub
                    End If

                    If .Text("doc_no", i) <> "" Then
                        MessageInfo("이미 전표가 발행된 건이 있습니다.")
                        Exit Sub
                    End If

                End If
            Next
        End With

        '작업시작

        Me._Work()

    End Sub

    Private Function _Work() As Boolean

        If MessageYesNo("전표를 생성하시겠습니까?") = MsgBoxResult.No Then
            Exit Function
        End If

        Dim dTbl As DataTable, dRow As DataRow
        Dim dSet As DataSet = Me.OpenDataSet("leb500_save_data")

        dTbl = dSet.Tables(0)
        With g20
            .UpdateRow()

            dTbl.BeginLoadData()
            For i As Integer = 0 To .RowCount - 1
                If .ToBool("chk", i) Then
                    dRow = dTbl.NewRow()

                    dRow("out_no") = .Text("out_no", i)
                    dRow("out_sq") = .Text("out_sq", i)

                    dTbl.Rows.Add(dRow)
                End If
            Next
            dTbl.EndLoadData()
        End With

        If Me.Save Then
            Dim dSet2 As DataSet = Me.OpenDataSet("leb500_work")
            If Not IsEmpty(dSet2) Then
                doc_no.Text = DataValue(dSet2)
                Me.Open()
                g10.Find("doc_no=" + doc_no.Text)
                g20.Find("doc_no=" + doc_no.Text)
            End If
        End If

    End Function

    Private Sub g10_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles g10.DoubleClick
        doc_no.Text = g10.Text("doc_no")
        cust_cd.Text = g10.Text("cust_cd")

        Me._Open()
    End Sub

    Private Sub btn_taxdel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
        If doc_no.Text <> "" Then
            'Dim p As New OpenParameters

            ' p = New OpenParameters
            ' p.Add("@tax_no", tax_no.Text)

            If MessageYesNo("전표를 삭제하시겠습니까?") = MsgBoxResult.No Then
                Exit Sub
            End If

            MyBase.Open("leb500_delete")

            Me.New_Form()
        Else
            MessageInfo("전표번호를 먼저 선택하세요")
            Exit Sub
        End If
    End Sub

    Private Sub Sum_All()
        Dim iRow As Integer, amt As Double, vat As Double, cnt As Integer, qty As Decimal

        With g20
            For iRow = 0 To .RowCount - 1
                'If .IsDataRow(iRow) Then
                If .ToBool("chk", iRow) Then
                    cnt += 1
                    qty += .ToDec("out_qty", iRow)
                    amt += .ToDec("set_amt", iRow)
                    vat += .ToDec("set_vat", iRow)
                End If
                'End If
            Next
            tot_cnt.Text = cnt
            tot_qty.Text = qty
            itm_amt.Text = amt
            vat_amt.Text = vat
            tot_amt.Text = ToDec(amt) + ToDec(vat)

        End With
    End Sub

    Private Sub g20_CellValueChanged(ByVal sender As Object, ByVal ColumnName As String, ByVal RowIndex As Integer, ByRef Value As Object) Handles g20.CellValueChanged
        If ColumnName = "chk" Or ColumnName = "set_amt" Or ColumnName = "set_vat" Then
            'g20.UpdateRow()
            Me.Sum_All()
        End If
    End Sub

    Private Sub g20_CellValueChanging(ByVal sender As Object, ByVal ColumnName As String, ByVal RowIndex As Integer, ByRef Value As Object) Handles g20.CellValueChanging
        With g20
            If .Text("doc_no") <> "" Then
                MessageInfo("이미 전표가 발행되었습니다.")
                .UpdateRow()
                Exit Sub
            End If

            If ColumnName = "chk" Then

                Dim custCd As String
                custCd = .Text("cust_cd")

                '  동일 거래처  체크
                For iRow = 0 To .RowCount - 1
                    If .ToBool("chk", iRow) And custCd <> .Text("cust_cd", iRow) Then
                        MessageInfo("동일한 매입처만 전표처리 가능 합니다")
                        .UpdateRow()
                        '.Text("chk") = ""
                        Exit Sub
                    End If
                Next

                'If Cust_Cnt > 0 Then
                '    MsgBox("동일한 거래처만 전표처리 가능 합니다")
                '    g20.UpdateRow()
                '    g20.Text("chk") = ""
                '    Exit Sub
                'End If

                If ToBool(Value) = True And g20.Text("doc_no") <> "" Then
                    MessageInfo("이미 전표가 발행되었습니다.")
                    .UpdateRow()
                    '.Text("chk") = ""
                    Exit Sub
                End If

                'Me.Sum_All()
            End If
            'If ColumnName = "set_amt" Or ColumnName = "set_vat" Then
            '    Me.Sum_All()
            'End If
        End With


    End Sub

    Private Sub chk_show_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_show.CheckedChanged
        SplitContainer3.Panel1Collapsed = Not chk_show.Checked
    End Sub

    Private Sub btn_up_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_up.Click
        Dim p As New OpenParameters
        Dim R As Integer

        With g20
            .UpdateRow()

            Try
                Cursor.Current = Cursors.WaitCursor

                For R = 0 To .RowCount - 1

                    If (.ToBool("chk", R) Or .ToBool("ok_yn", R)) And .Text("doc_no", R) = "" Then
                        p.Add("@itm_id", .Text("itm_id", R))
                        p.Add("@cust_cd", .Text("cust_cd", R))
                        p.Add("@cury_bc", .Text("cury_cd", R))
                        p.Add("@fac_cd", .Text("fac_cd", R))
                        p.Add("@dt", .Text("out_dt", R))

                        Dim Dset As DataSet = OpenDataSet("leb500_cost", p)

                        If IsEmpty(Dset) Then
                            .RowIndex = R
                            .Text("set_up") = 0
                        Else
                            .RowIndex = R
                            .Text("set_up") = DataValue(Dset, "up")
                        End If
                        Dset = Nothing
                    End If

                Next
            Catch ex As Exception
                MessageInfo(ex)
            Finally
                Me.Sum_All()
                Cursor.Current = Cursors.Default
            End Try
        End With

    End Sub

    Private Sub chk_all_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chk_all.CheckedChanged

        If cust_cd.Text = "" Then
            MessageInfo("거래처를 먼저 지정하세요")
            Exit Sub
        End If

        g20.CheckRows("chk", False)

        If chk_all.Checked Then
            '  동일 거래처  체크
            With g20
                For iRow = 0 To .RowCount - 1
                    If cust_cd.Text = .Text("cust_cd", iRow) Then

                        If .Text("doc_no", iRow) <> "" Then
                            MessageInfo("이미 전표가 발행된 건이 있습니다.")
                            g20.CheckRows("chk", False)
                            Exit Sub
                        End If

                        .Text("chk", iRow) = "1"
                    End If
                Next
            End With
        End If

    End Sub

    Private Sub g20_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles g20.DoubleClick
        If g20.FieldName(g20.ColumnIndex) = "cust_nm" Then

            cust_cd.Text = g20.Text("cust_cd")
            Me.New_Form()

        End If
    End Sub


    Private Sub btn_jump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_jump.Click
        If doc_no.Text = "" Then
            Exit Sub
        End If

        Dim menuName As String
        menuName = "FAB100"

        '화면을 띄운다
        Dim ctr As Object = Parameter.MainFrame.Frame.CallMenuForm(menuName)
        If ctr IsNot Nothing Then
            ctr.Open2(doc_no.Text)
        End If

    End Sub

End Class
