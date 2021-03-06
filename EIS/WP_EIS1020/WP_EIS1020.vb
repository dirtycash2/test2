﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Imports System.Data
Imports DevExpress.XtraCharts
Imports DevExpress.XtraTab
Imports DevExpress.XtraGrid

Public Class WP_EIS1020

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

            'Dim to_dt = Convert.ToInt32(std_dt.Text.Substring(8, 2))

            'For i = 2 To g10.ColumnCount - 1
            '    g10.ColumnVisible(i) = True
            'Next

            'SetColumnVisible(g20, True)


            'Me.OpenGrid()
            'Me.OpenChart()

            'For i = to_dt + 2 To g10.ColumnCount - 1
            '    g10.ColumnVisible(i) = False

            'Next

            'SetColumnVisible(g20, False)

         
            SetColumnVisible(g10, True)
            SetColumnVisible(g20, True)


            Me.OpenGrid()
            Me.OpenChart()

            
            SetColumnVisible(g10, False)
            SetColumnVisible(g20, False)

        
     

        End If

        isLoad = True
        isHap = False


    End Sub


    Private Sub OpenGrid()
        Dim param As OpenParameters = New OpenParameters
        param.Add("@std_dt", std_dt.Text)
  
        Me.Open("wp_eis1020_tab1_g10", param)
        Me.Open("wp_eis1020_tab2_g20", param)


    End Sub


    Private Sub OpenChart()
        Try
            Dim param As OpenParameters = New OpenParameters
            param.Add("@std_dt", std_dt.Text)


            Dim dSet1 As DataSet = Me.OpenDataSet("wp_eis1020_tab1_chart1", param)
            Dim dSet2 As DataSet = Me.OpenDataSet("wp_eis1020_tab2_chart1", param)

            Me.Chart1(chart1_1, dSet1.Tables(0))
            Me.Chart1(chart2_1, dSet2.Tables(0))

            LoadedGridDataDrawChart2(g10, chart1_2, "일")
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
                        If dTable.Rows(i)("bc") = "00" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "배합"
                        ElseIf dTable.Rows(i)("bc") = "10" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "사출"
                        ElseIf dTable.Rows(i)("bc") = "20" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "분리"
                        ElseIf dTable.Rows(i)("bc") = "25" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "Dry 전면"
                        ElseIf dTable.Rows(i)("bc") = "27" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "함푸리(?)"
                        ElseIf dTable.Rows(i)("bc") = "30" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "외주"
                        ElseIf dTable.Rows(i)("bc") = "40" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "하드레이션"
                        ElseIf dTable.Rows(i)("bc") = "50" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "전면검사"
                        ElseIf dTable.Rows(i)("bc") = "55" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "포장/멸균"
                        ElseIf dTable.Rows(i)("bc") = "60" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "멸균소독"
                        ElseIf dTable.Rows(i)("bc") = "70" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "누수검사"
                        ElseIf dTable.Rows(i)("bc") = "80" Then
                            row(0) = dTable.Rows(i)("day_name").ToString + "규격검사"
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

    Private Sub g10_Click(sender As System.Object, e As System.EventArgs) Handles g10.Click
        ClickCreateChart2(g10, chart1_2, "일")
    End Sub

    Private Sub g20_Click(sender As System.Object, e As System.EventArgs) Handles g20.Click
        ClickCreateChart2(g20, chart2_2, "월")
    End Sub

    


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
