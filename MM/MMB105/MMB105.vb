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


Public Class MMB105

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ProgressBar1.Visible = False
        all_chk.Checked = False
    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)

        Select Case mty

            'Case MenuType.Open
            '    Me.Open_Form()
            Case Else
                MyBase.MenuButton_Click(mty)
        End Select

    End Sub

    Private Sub all_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles all_chk.CheckedChanged

        g10.CheckRows("chk", all_chk.Checked)

    End Sub


#Region "메일보내기"
    Property ServicePoint As ServicePoint
    Property SmtpSection As New System.Net.Configuration.SmtpSection
    Property SmtpAccess As SmtpAccess

    Private Sub btn_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_send.Click
        ProgressBar1.Visible = True
        Dim cnt As Integer = 0
        Try
            With g10
                ProgressBar1.Maximum = .RowCount - 1
                ProgressBar1.Step = 1
                For i = 0 To .RowCount - 1



                    ProgressBar1.PerformStep()


                    If .Text("chk", i) = "1" And .Text("email", i) <> "" Then

                        Dim Message As MailMessage = New MailMessage()
                        Dim smtp As New SmtpClient("mail.interojo.com", 25)

                        Dim userid As Byte()
                        Dim userpw As Byte()
                        Dim domain As Byte()

                        userid = System.Text.Encoding.UTF8.GetBytes("interojo2@interojo.com")
                        userpw = System.Text.Encoding.UTF8.GetBytes("inter07")
                        domain = System.Text.Encoding.UTF8.GetBytes("interojo.com")


                        Dim smtpUser As New System.Net.NetworkCredential()

                        smtpUser.UserName = Convert.ToBase64String(userid)
                        smtpUser.Password = Convert.ToBase64String(userpw)
                        smtpUser.Domain = "interojo.com"

                        'smtpUser.GetCredential("192.168.2.5", 25, "Windows")

                        Message.From = New MailAddress("interojo2@interojo.com")

                        'Message.To.Add(New MailAddress("urong12@nate.com")) 'test mail

                        Message.To.Add(New MailAddress(.Text("email", i)))

                        Message.IsBodyHtml = True
                        Message.Priority = MailPriority.High
                        Message.Subject = to_dt.Text + " 발주서 메일"
                        Message.SubjectEncoding = System.Text.Encoding.UTF8
                        Message.Body = to_dt.Text + " 발주서 입니다. 첨부파일을 참고 하세요."

                        Dim body As New ReportDocument

                        Dim p As OpenParameters = New OpenParameters
                        p.Add("@po_no", .Text("po_no", i))
                        'p.Add("@to_dt", to_dt.Text)
                        p.Add("@cust_cd", .Text("cust_cd", i))
                        p.Add("@po_fac", .Text("po_fac", i))
                        p.Add("@in_fac", .Text("in_fac", i))
                        p.Add("@in_wh", .Text("in_wh", i))
  

                        Dim formCd As String = ""
                        Dim document As ReportDocument = Nothing
                        Dim dSet As DataSet = Link.ReadDataSet("mmb100_print", p)

                        If (document Is Nothing) Then
                            formCd = MMB105._GetFileName("MMB100")
                            If (formCd = "") Then
                                Exit Sub
                            End If
                            Dim expression As ReportDocument = DirectCast(MMB105._LoadAssembly(formCd, "System7"), ReportDocument)
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


                        Dim CrExportOptions As ExportOptions
                        Dim CrDiskFileDestinationOptions As New  _
                        DiskFileDestinationOptions()
                        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                        CrDiskFileDestinationOptions.DiskFileName = _
                                                    "c:\" & g10.Text("po_no", i) & i & ".pdf"
                        CrExportOptions = document.ExportOptions
                        With CrExportOptions
                            .ExportDestinationType = ExportDestinationType.DiskFile
                            .ExportFormatType = ExportFormatType.PortableDocFormat
                            .DestinationOptions = CrDiskFileDestinationOptions
                            .FormatOptions = CrFormatTypeOptions
                        End With
                        document.Export()

                        Message.Attachments.Add(New Net.Mail.Attachment("c:\" & g10.Text("po_no", i) & i & ".pdf"))

                        Message.BodyEncoding = System.Text.Encoding.UTF8

                        smtp.Host = "mail.interojo.com"
                        smtp.Port = 25
                        smtp.UseDefaultCredentials = False
                        smtp.Credentials = smtpUser
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network

                        If SmtpAccess.Connect = 1 Then

                            smtp.Send(Message)

                            cnt = cnt + 1
                            'Declaration
                        End If

                        Message.Dispose()
                        document.Dispose()

                        document.Close()

                        File.Delete("c:\" & g10.Text("po_no", i) & i & ".pdf")
                    End If
                Next
            End With
            ProgressBar1.Value = 0
            ProgressBar1.Visible = False

            MessageInfo("메일(" & cnt & ")을 발송하였습니다.")

        Catch ex As Exception
            MessageInfo(ex)
            ProgressBar1.Value = 0
            ProgressBar1.Visible = False
        End Try
    End Sub

    'Private Function html_body1(ByVal i As Integer) As ReportDocument
    '    Dim body As New ReportDocument

    '    Dim p As OpenParameters = New OpenParameters
    '    p.Add("@pay_mon", g10.Text("pay_mon", i))
    '    p.Add("@pay_bc", g10.Text("pay_bc", i))
    '    p.Add("@pay_sq", "1")
    '    p.Add("@bs_cd", co_cd.Text)
    '    p.Add("@dept_cd", g10.Text("dept_cd", i))
    '    p.Add("@duty1_bc", g10.Text("duty_bc", i))
    '    p.Add("@duty2_bc", "")
    '    p.Add("@emp_no", g10.Text("emp_no", i))
    '    p.Add("@kind_bc", g10.Text("kind_bc", i))
    '    p.Add("@prt_order", "1")
    '    p.Add("@prt_group", "2")

    '    CrystalReportViewer.Visible = False
    '    body = MMB105.ReportView.LoadView("PAB103_Detail", "", "pab103_print_Sum", p, CrystalReportViewer, False)
    '    CrystalReportViewer.ReportSource = MMB105.ReportView.LoadView("PAB103_Detail", "", "pab103_print_Sum", p, CrystalReportViewer, False)
    '    CrystalReportViewer.RefreshReport()
    '    CrystalReportViewer.ExportReport()
    '    'body.Load(MMB105.ReportView.LoadView("PAB103_Detail", "", "pab103_print_Sum", p, CrystalReportViewer, False))
    '    'body.Load(CrystalReportViewer)
    '    'MMB105.ReportView.LoadView("PAB103_Detail", "", "pab103_print_Sum", p, CrystalReportViewer, false)

    '    Return (CrystalReportViewer.ReportSource)
    'End Function

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

    Private Shared Function _LoadAssembly(ByVal formCd As String, Optional ByVal rootNameSpace As String = "MMB105") As Object
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

    'Public Sub Open_Form()
    '    Me.Init_Title()
    '    Me.Disp_Data()

    'End Sub

    '#Region " 1. Grid 컬럼 초기화 "

    '    'Case 1. DataSet을 이용한 Title 배열
    '    Private Sub Init_Title()

    '        '1. 컬럼배열을 만든다
    '        Dim dSet As DataSet = Me.OpenDataSet("PAB120_title")
    '        If IsEmpty(dSet) Then
    '            MessageInfo("조회 할 Data가 없습니다")
    '            'g10.Init()
    '            Exit Sub
    '        End If

    '        Dim arr(1, 0) As String, inx As Integer = 0
    '        For Each dRow In dSet.Tables(0).Rows
    '            ReDim Preserve arr(1, inx)      'Array를 증가시킨다

    '            arr(0, inx) = dRow(0)           'FieldName 으로 사용된다
    '            arr(1, inx) = dRow(1)           'Title로 사용된다

    '            inx += 1
    '        Next

    '        '2. 화면에 Array Column을 Unbound로 Insert 또는 Add 한다
    '        ' Ex) g10.InsertColumn("A", arr, "B")
    '        '     "A" 컬럼이후에 삽입된다
    '        '     "A" 자리에 Nothing을 쓰면 Arry Column들이 마지막에 추가된다
    '        '     "B" 컬럼에 설정된 특성으로 Array의 수 만큼 새로운 컬럼을 만든다

    '        g10.InsertArrayColumns(Nothing, arr, "pay_amt")

    '    End Sub
    '#End Region
    '#Region " 2. Display "

    '    '첫번째 Display 방법: 기본기능을 이용
    '    Private Sub Disp_Data()
    '        Try
    '            'Master 부분

    '            g10.GridColumn("pay_mon").IsMasterKey = True
    '            g10.GridColumn("pay_bc").IsMasterKey = True
    '            g10.GridColumn("pay_kd").IsMasterData = True
    '            g10.GridColumn("emp_no").IsMasterKey = True
    '            g10.GridColumn("emp_nm").IsMasterData = True
    '            g10.GridColumn("bs_cd").IsMasterData = True
    '            g10.GridColumn("dept_nm").IsMasterData = True
    '            g10.GridColumn("nat_cd").IsMasterData = True
    '            g10.GridColumn("gen_ty").IsMasterData = True
    '            g10.GridColumn("duty_bc").IsMasterData = True
    '            g10.GridColumn("rank_bc").IsMasterData = True
    '            g10.GridColumn("step_bc").IsMasterData = True

    '            g10.GridColumn("std_amt").IsMasterData = True
    '            g10.GridColumn("tot_pay_amt").IsMasterData = True
    '            g10.GridColumn("tot_de").IsMasterData = True
    '            g10.GridColumn("tot_pay").IsMasterData = True
    '            g10.GridColumn("ot_amt").IsMasterData = True
    '            g10.GridColumn("eat_amt").IsMasterData = True
    '            g10.GridColumn("drv_amt").IsMasterData = True
    '            g10.GridColumn("tax_amt").IsMasterData = True
    '            g10.GridColumn("tot_tax_amt").IsMasterData = True
    '            g10.GridColumn("email").IsMasterData = True
    '            g10.GridColumn("chk").IsMasterData = True

    '            'b.gen_ty, b.duty_bc, b.rank_bc, b.step_bc,  
    '            'ot_amt, eat_amt, drv_amt, tax_amt,tot_tax_amt,
    '            'Detail 부분
    '            g10.GridColumn("pay_cd").IsDetailKey = True
    '            g10.GridColumn("pay_amt").IsDetailData = True

    '            MyBase.Open("PAB120_g10")

    '            '화면에서 Grid가 아닌 필드를 Grid 값으로 연결시키기 위해 Default값을 이용한다
    '            'g10.GridColumn("work_mon").DefaultText = work_mon.Text

    '        Catch ex As Exception

    '            MessageInfo(ex, "Disp_Data()")

    '        End Try
    '    End Sub

    '#End Region

End Class
