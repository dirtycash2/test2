﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Imports System.Data
Imports DevExpress.XtraCharts
Imports DevExpress.XtraTab
Imports DevExpress.XtraGrid

Public Class WP_YHS0001

    '######################################################################################
    '##             Form Event                                                           ##
    '######################################################################################

    'Dim chartDataRows As Data.DataRowCollection
    Dim isLoad As Boolean = False
    Dim isHap As Boolean = False
    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.FormOpen()
        isLoad = True
        isHap = False
    End Sub

    Public Sub Init_Form()

    End Sub



    '######################################################################################
    '##             ToolBar Function                                                     ##
    '######################################################################################

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)

        Select Case mty

            Case MenuType.Open
                Me.FormOpen()
            Case Else
                MyBase.MenuButton_Click(mty)

        End Select

    End Sub


    '######################################################################################
    '##            Chart                                                                  ##
    '######################################################################################

    Private Sub FormOpen()

        
        If CheckRequired(std_dt) Then

            'SetColumnVisible(g20, True)

            Me.OpenGrid()
            Me.OpenChart()

            'SetColumnVisible(g20, False)

        End If


        isLoad = True
        isHap = False

    End Sub

    Public Sub sbchart(ByVal Series As Series, ByVal WorkSetCode As String, ByVal P As OpenParameters, ByVal series_Name As String)
        Dim dSet As DataSet, dRows As DataRowCollection, dRow As DataRow, dcolum As DataColumn, dco As DataColumnCollection

        dSet = Me.OpenDataSet(WorkSetCode, P)
        dRows = dSet.Tables(0).Rows
        Series.Points.Clear()
        Series.Name = series_Name
        dco = dSet.Tables(0).Columns
        Me.Open("wp_yhs0001_g20")
        For i = 0 To g20.RowCount - 1
            If ToStr(g20.Text("code", i)) = "응" Then
                For col = 3 To g20.ColumnCount - 2
                    Dim val As Double = 0
                    If ToStr(g20.Text(col, i)) = "" Then
                        val = 0
                    Else
                        val = g20.Text(col, i)
                    End If
                    Dim point As New SeriesPoint(ToStr(g20.ColumnTitle(col)), val)
                    Series.Points.Add(point)
                Next
            End If
        Next
    End Sub
    Private Sub OpenGrid()
        Dim param As OpenParameters = New OpenParameters
        param.Add("@std_dt", std_dt.Text)
        param.Add("@de_gu", kijong_cd.Text)

        'Me.Open("WP_EIS2020_tab1_g10", param)
        Me.Open("wp_yhs0001_g20", param)


    End Sub


    Private Sub OpenChart()
        Try
            'Dim param As OpenParameters = New OpenParameters
            'param.Add("@std_dt", std_dt.Text)


            'Dim dSet1 As DataSet = Me.OpenDataSet("WP_EIS2020_tab1_chart1", param)
            'Dim dSet2 As DataSet = Me.OpenDataSet("WP_EIS2020_tab2_chart1", param)

            'Me.Chart1(chart1_1, dSet1.Tables(0))
            'Me.Chart1(chart2_1, dSet2.Tables(0))

            'LoadedGridDataDrawChart2(g10, chart1_2, "일")
            LoadedGridDataDrawChart2(g20, chart2_2, "월")
            isHap = True


        Catch
            'ChartControl1.Series.Clear()
        End Try
    End Sub


    Private Sub Chart1(ByVal ChartControls As DevExpress.XtraCharts.ChartControl, dTable As DataTable)

        Dim cnt_srs As Integer

        If ChartControls.Name = "chart1_1" Or ChartControls.Name = "chart2_1" Then
            cnt_srs = 2
        Else
            cnt_srs = 1
        End If

        If dTable.Rows.Count = 0 Then
        Else

            For s = 0 To cnt_srs - 1
                Dim table As New DataTable

                table.Columns.Add("y_plan_qty", GetType(String))
                table.Columns.Add("Value", GetType(Decimal))

                For i = 0 To dTable.Rows.Count - 1
                    If dTable.Rows(i)("seq") = s + 1 Then

                        Dim row As DataRow = table.NewRow()
                        If dTable.Rows(i)("bc") = "Y" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "년"
                        ElseIf dTable.Rows(i)("bc") = "Q" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + " 분기"
                        ElseIf dTable.Rows(i)("bc") = "M" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "월"
                        ElseIf dTable.Rows(i)("bc") = "40" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "Hard"
                        ElseIf dTable.Rows(i)("bc") = "50" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "1-Day Circle"
                        ElseIf dTable.Rows(i)("bc") = "B0" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "약품"
                        End If

                        If IsDBNull(dTable.Rows(i)("y_plan_qty")) Then
                            row(1) = 0
                        Else
                            row(1) = dTable.Rows(i)("y_plan_qty")
                        End If

                        table.Rows.Add(row)

                    End If
                Next

                ChartControls.Series(s).DataSource = table
                ChartControls.Series(s).ArgumentDataMember = "y_plan_qty"
                ChartControls.Series(s).ValueDataMembers.AddRange(New String() {"Value"})

            Next

        End If
    End Sub


    Private Function CreateChartSeries(ByVal dTable As DataTable, ByVal RowIndex As Integer, ByVal Title As String, ByVal barType As DevExpress.XtraCharts.ViewType, ByVal Day_Month_Unit As String, ByVal MouseEvent As Boolean) As DevExpress.XtraCharts.Series

        Dim PointOptions1 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim LineSeriesView2 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim PointSeriesLabel1 As DevExpress.XtraCharts.PointSeriesLabel = New DevExpress.XtraCharts.PointSeriesLabel()

        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PointSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()

        LineSeriesView2.LineMarkerOptions.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        LineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        LineSeriesView2.LineMarkerOptions.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid
        LineSeriesView2.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Hexagon
        LineSeriesView2.LineMarkerOptions.Size = 13

        PointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number
        PointOptions1.ValueNumericOptions.Precision = 0

        PointSeriesLabel1.Visible = True
        PointSeriesLabel1.Border.Visible = False
        PointSeriesLabel1.BackColor = Color.Transparent

        Dim Series1 As New DevExpress.XtraCharts.Series(Title, barType)
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()

        Series1.DataSource = CreateChartData(dTable, RowIndex, Day_Month_Unit, MouseEvent)
        Series1.ArgumentDataMember = "col_day"
        Series1.ValueDataMembers.AddRange(New String() {"Value"})
        Series1.Label = PointSeriesLabel1

        Series1.PointOptions = PointOptions1
        If Title = "인터로조" Then
            Series1.View = LineSeriesView2
        End If

        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PointSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()

        Return (Series1)
    End Function

    Private Function CreateChartData(ByVal dTable As DataTable, ByVal RowIndex As Integer, Day_Month_Unit As String, MouseEvent As Boolean) As DataTable

        Dim table As New DataTable

        table.Columns.Add("col_day", GetType(String))
        table.Columns.Add("Value", GetType(Decimal))

        Dim col_cnt = dTable.Columns.Count

        For i = 1 To col_cnt - 1
            Dim row As DataRow = table.NewRow()
            row(0) = ToDec(dTable.Columns(i).Caption).ToString + Day_Month_Unit

            If IsDBNull(dTable.Rows(RowIndex)(i)) Then
                row(1) = 0
            Else
                row(1) = dTable.Rows(RowIndex)(i)
            End If

            table.Rows.Add(row)
        Next

        Return table
    End Function


    'Private Sub o_cust_cd_TextChanged(sender As System.Object, e As System.EventArgs) Handles o_grp1_cd.TextChanged
    '    If isLoad = True Then
    '        FormOpen()
    '    End If
    'End Sub


    Private Sub SetColumnVisible(grid As Frame7.eGrid, Visible As Boolean)
        Dim to_dt = Convert.ToInt32(std_dt.Text.Substring(8, 2))

        If Visible = True Then
            For i = 0 To grid.ColumnCount - 1
                For j = 1 To 31
                    If grid.ColumnTitle(i).EndsWith(j.ToString + "일") Then
                        grid.ColumnVisible(i) = Visible
                    End If
                Next
            Next

        Else
            For i = 0 To grid.ColumnCount - 1
                For j = to_dt + 1 To 31
                    If grid.ColumnTitle(i).EndsWith(j.ToString + "일") Then
                        grid.ColumnVisible(i) = Visible
                    End If
                Next
            Next
        End If

    End Sub



    Private Sub g20_Click(sender As System.Object, e As System.EventArgs) Handles g20.Click
        ClickCreateChart2(g20, chart2_2, "월")
    End Sub


#Region " 2. char "
    Public Sub sbchart2()
        chart2_2.Series.Clear()
        Dim Col As Integer
        Dim Series As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series("Dosimeter", DevExpress.XtraCharts.ViewType.Bar)
        Series.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number
        Series.PointOptions.ValueNumericOptions.Precision = 0
        Series.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        Series.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        Series.PointOptions.PointView = DevExpress.XtraCharts.PointView.Values
        Series.Label.ResolveOverlappingMinIndent = 5
        Series.Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default
        Series.Name = "월간목표"
        chart2_2.Titles(0).Text = "월간 매출 현황"
        chart2_2.Series.Add(Series)
        chart2_2.SeriesTemplate.Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default
        For Row = 0 To g20.RowCount - 1
            If ToStr(g20.Text("kijong_nm", Row)) = "월간목표" Then
                For Col = 3 To g20.ColumnCount - 2
                    Dim value As Double = 0
                    If ToStr(g20.Text(Col, Row)) = "" Then
                        value = 0
                    Else
                        value = g20.Text(Col, Row)
                    End If
                    Dim point As New SeriesPoint(ToStr(g20.ColumnTitle(Col)), value)
                    Series.Points.Add(point)
                Next
            End If
        Next

        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series("Dosimeter", DevExpress.XtraCharts.ViewType.Bar)
        Series1.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number
        Series1.PointOptions.ValueNumericOptions.Precision = 0
        Series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        Series1.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        Series1.PointOptions.PointView = DevExpress.XtraCharts.PointView.Values
        Series1.Label.ResolveOverlappingMinIndent = 5
        Series1.Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default
        Series1.Name = "월간합계"
        chart2_2.Series.Add(Series1)
        chart2_2.SeriesTemplate.Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default
        For Row = 0 To g20.RowCount - 1
            If ToStr(g20.Text("kijong_nm", Row)) = "월간합계" Then
                For Col = 3 To g20.ColumnCount - 2
                    Dim value As Double = 0
                    If ToStr(g20.Text(Col, Row)) = "" Then
                        value = 0
                    Else
                        value = g20.Text(Col, Row)
                    End If
                    Dim point As New SeriesPoint(ToStr(g20.ColumnTitle(Col)), value)
                    Series1.Points.Add(point)
                Next
            End If
        Next

        Dim Series2 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series("Dosimeter", DevExpress.XtraCharts.ViewType.Line)
        Series2.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number
        Series2.PointOptions.ValueNumericOptions.Precision = 0
        Series2.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        Series2.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        Series2.PointOptions.PointView = DevExpress.XtraCharts.PointView.Values
        Series2.Label.ResolveOverlappingMinIndent = 5
        Series2.Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default
        Series2.Name = "목표누적"
        chart2_2.Series.Add(Series2)
        chart2_2.SeriesTemplate.Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default
        For Row = 0 To g20.RowCount - 1
            If ToStr(g20.Text("kijong_nm", Row)) = "목표누적" Then
                For Col = 3 To g20.ColumnCount - 2
                    Dim value As Double = 0
                    If ToStr(g20.Text(Col, Row)) = "" Then
                        value = 0
                    Else
                        value = g20.Text(Col, Row)
                    End If
                    Dim point As New SeriesPoint(ToStr(g20.ColumnTitle(Col)), value)
                    Series2.Points.Add(point)
                Next
            End If
        Next

        Dim Series3 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series("Dosimeter", DevExpress.XtraCharts.ViewType.Line)
        Series3.PointOptions.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number
        Series3.PointOptions.ValueNumericOptions.Precision = 0
        Series3.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        Series3.ValueScaleType = DevExpress.XtraCharts.ScaleType.Numerical
        Series3.PointOptions.PointView = DevExpress.XtraCharts.PointView.Values
        Series3.Label.ResolveOverlappingMinIndent = 5
        Series3.Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default
        Series3.Name = "실적누적"
        chart2_2.Series.Add(Series3)
        chart2_2.SeriesTemplate.Label.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default
        For Row = 0 To g20.RowCount - 1
            If ToStr(g20.Text("kijong_nm", Row)) = "실적누적" Then
                For Col = 3 To g20.ColumnCount - 2
                    Dim value As Double = 0
                    If ToStr(g20.Text(Col, Row)) = "" Then
                        value = 0
                    Else
                        value = g20.Text(Col, Row)
                    End If
                    Dim point As New SeriesPoint(ToStr(g20.ColumnTitle(Col)), value)
                    Series3.Points.Add(point)
                Next
            End If
        Next

    End Sub
#End Region


#Region "챠트2"

    Private Sub LoadedGridDataDrawChart2(grid As eGrid, ChartControl As DevExpress.XtraCharts.ChartControl, Day_Month_Unit As String, Optional MouseEvent As Boolean = False)

        ChartControl.Series.Clear()
        If isHap = False Then
            For RowCount = 0 To grid.RowCount - 1
                Dim row As DataRow = grid.DataSet.Tables(0).Rows(RowCount)
                If MouseEvent = False Then
                    If row(0) = "합계" Then
                        Return
                    End If
                End If
                ChartControl.Series.Add(CreateChart2Series(MakeDataTable(row, Day_Month_Unit), row, Day_Month_Unit))
            Next
        Else
            For RowCount = grid.RowCount - 1 To grid.RowCount - 1
                Dim row As DataRow = grid.DataSet.Tables(0).Rows(RowCount)

                ChartControl.Series.Add(CreateChart2Series(MakeDataTable(row, Day_Month_Unit), row, Day_Month_Unit))
            Next
        End If
    End Sub


    Private Function CreateChart2Series(table As DataTable, row As DataRow, Day_Month_Unit As String) As DevExpress.XtraCharts.Series
        Dim PointOptions1 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim LineSeriesView2 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim PointSeriesLabel1 As DevExpress.XtraCharts.PointSeriesLabel = New DevExpress.XtraCharts.PointSeriesLabel()

        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PointSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()

        LineSeriesView2.LineMarkerOptions.BorderColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        LineSeriesView2.LineMarkerOptions.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        LineSeriesView2.LineMarkerOptions.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Solid
        LineSeriesView2.LineMarkerOptions.Kind = DevExpress.XtraCharts.MarkerKind.Hexagon
        LineSeriesView2.LineMarkerOptions.Size = 13

        PointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.Number '숫자시 사용
        PointOptions1.ValueNumericOptions.Precision = 0

        PointSeriesLabel1.Visible = True
        PointSeriesLabel1.Border.Visible = False
        PointSeriesLabel1.BackColor = Color.Transparent

        Dim Series1 As New DevExpress.XtraCharts.Series(row(0), ViewType.Line)
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()

        Series1.DataSource = MakeDataTable(row, Day_Month_Unit) ' table
        Series1.ArgumentDataMember = "col_day"
        Series1.ValueDataMembers.AddRange(New String() {"Value"})
        Series1.Label = PointSeriesLabel1

        Series1.PointOptions = PointOptions1
        If row(0) = "인터로조" Then
            Series1.View = LineSeriesView2
        End If

        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PointSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()

        Return Series1
    End Function


    Private Sub ClickCreateChart2(grid As eGrid, ChartControl As DevExpress.XtraCharts.ChartControl, Day_Month_Unit As String)

        ChartControl.Series.Clear()
        Dim row As DataRow = grid.DataSet.Tables(0).Rows(grid.RowIndex)

        ChartControl.Series.Add(CreateChart2Series(MakeDataTable(row, Day_Month_Unit), row, Day_Month_Unit))

    End Sub


    Private Function MakeDataTable(row As DataRow, Day_Month_Unit As String) As DataTable
        Dim table As New DataTable

        table.Columns.Add("col_day", GetType(String))
        table.Columns.Add("Value", GetType(Decimal))

        Dim to_dt = Convert.ToInt32(std_dt.Text.Substring(8, 2))
        Dim to_mon = Convert.ToInt32(std_dt.Text.Substring(5, 2))

        If Day_Month_Unit = "일" Then
            For i = 1 To to_dt
                Dim dr As DataRow = table.NewRow()
                dr(0) = i.ToString + Day_Month_Unit
                dr(1) = ToDec(row(ColNm(i))) ' / 100 --백분율 표시때 사용
                table.Rows.Add(dr)
            Next
        Else
            For i = 1 To 12
                Dim dr As DataRow = table.NewRow()
                dr(0) = i.ToString + Day_Month_Unit
                dr(1) = ToDec(row(ColNm(i))) ' / 100 --백분율 표시때 사용
                table.Rows.Add(dr)
            Next
        End If

        Return table
    End Function

    Private Function ColNm(ByVal num As Integer) As String
        If num.ToString.Length = 1 Then
            Return "m0" + num.ToString
        Else
            Return "m" + num.ToString()
        End If
    End Function

#End Region


End Class
