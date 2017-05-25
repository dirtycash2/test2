﻿'Imports System.Windows.Forms.LinkLabel
Imports Frame7
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
Imports System.IO.FileLoadException


Public Class WP_SA1285

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)

        Select Case mty
            Case MenuType.Print
                Me.Print()

                'Case MenuType.Save
                'Me.save_Form()
                'Case MenuType.New

            Case MenuType.Open
                Retrieve()
            Case Else
                MyBase.MenuButton_Click(mty)
        End Select

    End Sub
    Private Sub WP_SA1285_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ProgressBar1.Visible = False
        chk.Checked = False
        grp_chk.Checked = False
        all_chk.Checked = False
        save_ing.Visible = False
        save_end.Visible = False
    End Sub

    Private Sub Print()
        Dim p As OpenParameters = New OpenParameters
        Dim p2 As OpenParameters = New OpenParameters

        p.Add("@fr_dt", fr_dt.Text)
        p.Add("@to_dt", to_dt.Text)
        p.Add("@cs_cd", cs_cd.Text)
        p.Add("@ps_cd", ps_cd.Text)
        p.Add("@sal_cust", sal_cust.Text)     '20141117 매출정산거래처
        p.Add("@grp2_cd", grp2_cd.Text)
        p.Add("@grp22_cd", grp22_cd.Text)

        p2.Add("@fr_dt", fr_dt.Text)
        p2.Add("@to_dt", to_dt.Text)
        ''p2.Add("@cs_cd", cs_cd.Text)  '원래 막혀있음.

        ''System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p) '원래 막혀있음.
        'System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, True, 1, "sub", "wp_sa1285_print2", p2)    '2014-09-29 

        'If chk.Checked = True Then           '체크,  DIS_AMT = 0 
        '    p.Add("@CHK", "1")
        '    If grp_chk.Checked = True Then      '체크, 폐업,거래종료 뺀것 
        '        p.Add("@GRP_CHK", "1")
        '    Else
        '        p.Add("@GRP_CHK", "2")
        '    End If
        '    System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, True, 1, "sub", "wp_sa1285_print2", p2)
        'Else                              '체크 안되면,
        '    p.Add("@CHK", "2")
        '    If grp_chk.Checked = True Then
        '        p.Add("@GRP_CHK", "1")
        '    Else
        '        p.Add("@GRP_CHK", "2")
        '    End If
        '    System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, True, 1, "sub", "wp_sa1285_print2", p2)
        'End If

        If chk.Checked = True Then              '청구금액 0원 체크시, 
            p.Add("@CHK", "1")
            If grp_chk.Checked = True Then      '폐업인 것만 
                p.Add("@GRP_CHK", "1")
                '거래종료
                If g_end.Checked = True Then
                    p.Add("@G_END", "1")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If

                Else
                    p.Add("@G_END", "2")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If

                End If
            Else
                p.Add("@GRP_CHK", "2")
                '거래종료
                If g_end.Checked = True Then
                    p.Add("@G_END", "1")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                Else
                    p.Add("@G_END", "2")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                End If

            End If
            System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, True, 1, "sub", "wp_sa1285_print2", p2)
        Else                                '체크 안되면,
            p.Add("@CHK", "2")              ' DIS_AMT <=0 인 것. or ""로 하면, 전체조회.
            If grp_chk.Checked = True Then
                p.Add("@GRP_CHK", "1")
                '거래종료
                If g_end.Checked = True Then
                    p.Add("@G_END", "1")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                Else
                    p.Add("@G_END", "2")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                End If

            Else
                p.Add("@GRP_CHK", "2")
                '거래종료
                If g_end.Checked = True Then
                    p.Add("@G_END", "1")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                Else
                    p.Add("@G_END", "2")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                End If

            End If
            System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, True, 1, "sub", "wp_sa1285_print2", p2)
        End If

    End Sub

    Private Sub Retrieve()          '2014-10-02 
        Dim p As OpenParameters = New OpenParameters
        Dim p2 As OpenParameters = New OpenParameters

        p.Add("@fr_dt", fr_dt.Text)
        p.Add("@to_dt", to_dt.Text)
        p.Add("@cs_cd", cs_cd.Text)
        p.Add("@ps_cd", ps_cd.Text)
        p2.Add("@fr_dt", fr_dt.Text)
        p2.Add("@to_dt", to_dt.Text)
        p.Add("@sal_cust", sal_cust.Text)       '20141117 매출정산거래처

        p.Add("@grp2_cd", grp2_cd.Text)
        p.Add("@grp22_cd", grp22_cd.Text)

        If chk.Checked = True Then              '청구금액 0원 체크시, 
            p.Add("@CHK", "1")
            If grp_chk.Checked = True Then      '폐업인 것만 
                p.Add("@GRP_CHK", "1")
                '거래종료
                If g_end.Checked = True Then
                    p.Add("@G_END", "1")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If

                Else
                    p.Add("@G_END", "2")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If

                End If
            Else
                p.Add("@GRP_CHK", "2")
                '거래종료
                If g_end.Checked = True Then
                    p.Add("@G_END", "1")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                Else
                    p.Add("@G_END", "2")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                End If

            End If
            Me.Open("wp_sa1285_g10", p)
        Else                                '체크 안되면,
            p.Add("@CHK", "2")              ' DIS_AMT <=0 인 것. or ""로 하면, 전체조회.
            If grp_chk.Checked = True Then
                p.Add("@GRP_CHK", "1")
                '거래종료
                If g_end.Checked = True Then
                    p.Add("@G_END", "1")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                Else
                    p.Add("@G_END", "2")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                End If

            Else
                p.Add("@GRP_CHK", "2")
                '거래종료
                If g_end.Checked = True Then
                    p.Add("@G_END", "1")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                Else
                    p.Add("@G_END", "2")
                    '미출력
                    If print_ck.Checked = True Then
                        p.Add("@PRINT_CK", "1")
                    Else
                        p.Add("@PRINT_CK", "2")
                    End If
                End If

            End If
            Me.Open("wp_sa1285_g10", p)
        End If

    End Sub
    Private Sub all_chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles all_chk.CheckedChanged

        g10.CheckRows("g10_chk", all_chk.Checked)

    End Sub

#Region "메일보내기"


    Private Sub btn_send_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_send.Click
        Dim p As OpenParameters = New OpenParameters
        Dim p2 As OpenParameters = New OpenParameters

        ProgressBar1.Visible = True

        Dim cnt As Integer = 0
        Try
            With g10
                ProgressBar1.Maximum = .RowCount - 1
                ProgressBar1.Step = 1
                For i = 0 To g10.RowCount - 1
                    ProgressBar1.PerformStep()

                    If .Text("g10_chk", i) = "1" And .Text("email", i) <> "" Then           '체크가 된 것만 메일 보내기. 

                        Dim Message As MailMessage = New MailMessage()
                        'Dim smtp As New SmtpClient("192.168.2.5", 25)  '원래 주석처리 'Dim smtp As New SmtpClient("mail.interojo.com", 25)
                        Dim smtp As New SmtpClient("smtp.interojo.com", 25)

                        'Dim smtp As New SmtpClient()
                        'Dim userid As Byte()
                        'Dim userpw As Byte()
                        'Dim domain As Byte()
                        'userid = System.Text.Encoding.UTF8.GetBytes("interMail") '원래 주석처리
                        'userpw = System.Text.Encoding.UTF8.GetBytes("inter07@")  '원래 주석처리
                        'domain = System.Text.Encoding.UTF8.GetBytes("interojo.co.kr")  '원래 주석처리
                        'userid = System.Text.Encoding.UTF8.GetBytes("interojo2@interojo.com")
                        'userpw = System.Text.Encoding.UTF8.GetBytes("inter07")


                        Dim smtpUser As New System.Net.NetworkCredential()

                        smtpUser.UserName = "interojo2@interojo.com"   '기존꺼20160707
                        smtpUser.Password = "inter07"

                        'smtpUser.UserName = "mkseo@interojo.com"
                        'smtpUser.Password = "tkfkd123@"

                        smtp.Host = "25"


                        '서민경
                        'smtp.EnableSsl = True
                        'smtp.Credentials = New System.Net.NetworkCredential("cs@interojo.com", "inter1025")

                        'smtpUser.UserName = Convert.ToBase64String(userid)
                        'smtpUser.Password = Convert.ToBase64String(userpw)
                        ''smtpUser.Domain = "interojo.co.kr"  '원래 주석처리
                        'smtpUser.Domain = "interojo.com"

                        'smtpUser.GetCredential("192.168.2.5", 25, "Windows")  '원래 주석처리

                        Message.From = New MailAddress("interojo2@interojo.com")       ' 원래는 interojo2@interojo.com 

                        Message.To.Add(New MailAddress(.Text("email", i)))   'g10의text중에서 "email"이라는 컬럼에 있는 i번째꺼로 보내기."

                        Message.IsBodyHtml = True
                        Message.Priority = MailPriority.High
                        ' 인터로조 2014-09월 대금청구서
                        Message.Subject = "인터로조 " + fr_dt.Text + "월 대금청구서"                                     '+ " / " + pay_sq.EditText + "명세서 메일"
                        Message.SubjectEncoding = System.Text.Encoding.UTF8
                        Message.Body = " 안녕하세요. 인터로조 입니다. " + "<br>" + "귀 원의 발전을 기원합니다." + "<br>" + "항상 저희 ㈜인터로조 제품에 많은 성원과 관심을 보여주셔서 깊은 감사의 말씀을 드립니다. " + "<br>" + "<br>"

                        Message.Body = Message.Body + fr_dt.Text + " 월분 대금청구서를 보내드립니다." + "<br>" + "<br>" + "*첨부파일은 PDF 형식으로 되어있습니다. " + "<br>" + "첨부파일이 열리지 않는 경우 아래 링크에서 아크로벳 리더를 설치해주시기 바랍니다." + "<br>" + "http://get.adobe.com/kr/reader/" + "<br>" + "<br>" + "감사합니다."


                        Dim body As New ReportDocument

                        '메인리포트 파라미터
                        'Dim p As OpenParameters = New OpenParameters
                        p.Add("@fr_dt", fr_dt.Text)
                        p.Add("@to_dt", to_dt.Text)
                        p.Add("@cs_cd", .Text("cs_cd", i))           'p.Add("@cs_cd", cs_cd.Text)
                        p.Add("@ps_cd", ps_cd.Text)
                        p.Add("@sal_cust", sal_cust.Text)     '20141119 매출정산거래처

                        p.Add("@grp2_cd", grp2_cd.Text)
                        p.Add("@grp22_cd", grp22_cd.Text)

                        '서브리포트 파라미터추가
                        ' Dim p2 As OpenParameters = New OpenParameters
                        p2.Add("@fr_dt", fr_dt.Text)
                        p2.Add("@to_dt", to_dt.Text)

                        Dim formCd As String = ""
                        Dim document As ReportDocument = Nothing     '크리스탈 리포트 뷰를 불러오기. 
                        'Dim dSet As DataSet = Link.ReadDataSet("mmb100_print", p)
                        'Dim dSet As DataSet = Link.ReadDataSet("", p)   'Link.ReadDataSet("워크셋이름", 파라미터)
                        Dim dSet As DataSet = New DataSet

                        'If chk.Checked = True Then           '체크,  DIS_AMT > 0 
                        '    p.Add("@CHK", "1")
                        '    If grp_chk.Checked = True Then      '체크, 폐업,거래종료 뺀것 
                        '        p.Add("@GRP_CHK", "1")
                        '    Else
                        '        p.Add("@GRP_CHK", "2")
                        '    End If

                        'Else                              '체크 안되면,
                        '    p.Add("@CHK", "2")
                        '    If grp_chk.Checked = True Then
                        '        p.Add("@GRP_CHK", "1")
                        '    Else
                        '        p.Add("@GRP_CHK", "2")
                        '    End If

                        'End If
                        '아래 잠깐막음


                        If chk.Checked = True Then              '청구금액 0원 체크시, 
                            p.Add("@CHK", "1")
                            If grp_chk.Checked = True Then      '폐업인 것만 
                                p.Add("@GRP_CHK", "1")
                                '거래종료
                                If g_end.Checked = True Then
                                    p.Add("@G_END", "1")
                                    '미출력
                                    If print_ck.Checked = True Then
                                        p.Add("@PRINT_CK", "1")
                                    Else
                                        p.Add("@PRINT_CK", "2")
                                    End If

                                Else
                                    p.Add("@G_END", "2")
                                    '미출력
                                    If print_ck.Checked = True Then
                                        p.Add("@PRINT_CK", "1")
                                    Else
                                        p.Add("@PRINT_CK", "2")
                                    End If

                                End If
                            Else
                                p.Add("@GRP_CHK", "2")
                                '거래종료
                                If g_end.Checked = True Then
                                    p.Add("@G_END", "1")
                                    '미출력
                                    If print_ck.Checked = True Then
                                        p.Add("@PRINT_CK", "1")
                                    Else
                                        p.Add("@PRINT_CK", "2")
                                    End If
                                Else
                                    p.Add("@G_END", "2")
                                    '미출력
                                    If print_ck.Checked = True Then
                                        p.Add("@PRINT_CK", "1")
                                    Else
                                        p.Add("@PRINT_CK", "2")
                                    End If
                                End If

                            End If
                            'Me.Open("wp_sa1285_g10", p)

                        Else                                '체크 안되면,
                            p.Add("@CHK", "2")              ' DIS_AMT <=0 인 것. or ""로 하면, 전체조회.
                            If grp_chk.Checked = True Then
                                p.Add("@GRP_CHK", "1")
                                '거래종료
                                If g_end.Checked = True Then
                                    p.Add("@G_END", "1")
                                    '미출력
                                    If print_ck.Checked = True Then
                                        p.Add("@PRINT_CK", "1")
                                    Else
                                        p.Add("@PRINT_CK", "2")
                                    End If
                                Else
                                    p.Add("@G_END", "2")
                                    '미출력
                                    If print_ck.Checked = True Then
                                        p.Add("@PRINT_CK", "1")
                                    Else
                                        p.Add("@PRINT_CK", "2")
                                    End If
                                End If

                            Else
                                p.Add("@GRP_CHK", "2")
                                '거래종료
                                If g_end.Checked = True Then
                                    p.Add("@G_END", "1")
                                    '미출력
                                    If print_ck.Checked = True Then
                                        p.Add("@PRINT_CK", "1")
                                    Else
                                        p.Add("@PRINT_CK", "2")
                                    End If
                                Else
                                    p.Add("@G_END", "2")
                                    '미출력
                                    If print_ck.Checked = True Then
                                        p.Add("@PRINT_CK", "1")
                                    Else
                                        p.Add("@PRINT_CK", "2")
                                    End If
                                End If

                            End If
                            'Me.Open("wp_sa1285_g10", p)

                        End If


                        dSet = Link.ReadDataSet("wp_sa1285_print", p)


                        If (document Is Nothing) Then
                            formCd = WP_SA1285._GetFileName("WP_SA1285")    'MMB100 'formCd = 자기자신._GetFileName(레포트엔트리이름)
                            'MsgBox("formcd: " + ToStr(formCd))
                            If (formCd = "") Then
                                Exit Sub
                            End If

                            Dim expression As ReportDocument = DirectCast(WP_SA1285._LoadAssembly(formCd, "System7"), ReportDocument)    'CrystalReport에서 가져오기.(자기자신._LoadAssembly(formCd, "System7"), ReportDocument)
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
                        ' document.SetDataSource(dSet.Tables.Item(0))

                        '서브리포트 
                        Dim dtSet As DataSet = Link.ReadDataSet("wp_sa1285_print2", p2)
                        If Not IsEmpty(dtSet) Then
                            'document.OpenSubreport("sub").SetDataSource(dtSet.Tables.Item(0))
                        End If

                        ' 변수를 선언하고 내보내기 옵션을 가져옵니다.
                        Dim CrExportOptions As ExportOptions
                        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                        '파일 이름 설정 
                        CrDiskFileDestinationOptions.DiskFileName = "c:\" & g10.Text("cs_cd", i) & i & ".pdf"                             '"c:\" & g10.Text("cs_cd", i) & i & ".pdf"      'po_no  fr_dt ps_cd ToDec(EPanel1.Text("ps_cd")) 
                        CrExportOptions = document.ExportOptions
                        With CrExportOptions
                            .ExportDestinationType = ExportDestinationType.DiskFile
                            .ExportFormatType = ExportFormatType.PortableDocFormat
                            .DestinationOptions = CrDiskFileDestinationOptions
                            .FormatOptions = CrFormatTypeOptions
                        End With


                        document.Export()    '여기에서 에러남 (매개 변수 값이 없습니다.) -> 서브리포트 쪽에 document.OpenSubreport("sub").SetDataSource(dtSet.Tables.Item(0)) 로 해결함.
                        Message.Attachments.Add(New Net.Mail.Attachment("c:\" & g10.Text("cs_cd", i) & i & ".pdf"))   '~'파일을 찾을 수 없습니다.   'Attachment("c:\" & g10.Text("cs_cd", i) & i & ".pdf"))
                        document.Dispose()

                        document.Close()

                        Message.BodyEncoding = System.Text.Encoding.UTF8

                        'smtp.Host = "mail.interojo.com"
                        'smtp.Port = 25
                        'smtp.UseDefaultCredentials = False
                        'smtp.Credentials = smtpUser
                        'smtp.DeliveryMethod = SmtpDeliveryMethod.Network

                        'smtp.Send(Message)

                        cnt = cnt + 1

                        Dim client = New SmtpClient("mail.interojo.com", "25")
                        client.UseDefaultCredentials = True

                        'If co_mail_yn.Text = "1" Then
                        '    client.UseDefaultCredentials = False
                        'Else
                        '    client.UseDefaultCredentials = True
                        'End If

                        client.DeliveryMethod = SmtpDeliveryMethod.Network
                        client.Credentials = smtpUser
                        client.Send(Message)

                        Message.Dispose()

                        'File.Delete("c:\11.pdf")

                        'File.Delete("c:\" & g10.Text("cs_cd", i) & i & ".pdf")

                    End If       'If .Text("chk", i) = "1" And .Text("email", i) <> "" Then   '체크가 된 것만 메일 보내기. 
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



#Region "월별폴더 저장"
    Private Sub file_save_Click(sender As System.Object, e As System.EventArgs) Handles file_save.Click

        Dim cnt As Integer = 0
        'ProgressBar1.Visible = True
        save_ing.Visible = True
        save_end.Visible = False
        Try
            With g10
                'ProgressBar1.Maximum = 10
                'ProgressBar1.Step = 1
                'ProgressBar1.PerformStep()

                'For i = 0 To .RowCount - 1
                'If .Text("g10_chk", i) = "1" Then           '체크가 된 것만 메일 보내기. 
                Dim body As New ReportDocument
                '메인리포트 파라미터
                Dim p As OpenParameters = New OpenParameters
                p.Add("@fr_dt", fr_dt.Text)
                p.Add("@to_dt", to_dt.Text)
                p.Add("@cs_cd", "")                   '월별 저장을 위해 '수정'/SMK/20141120  p.Add("@cs_cd", .Text("cs_cd", i)) 또는 'p.Add("@cs_cd", cs_cd.Text)
                p.Add("@ps_cd", ps_cd.Text)             'p.Add("@ps_cd", ps_cd.Text)  -> TEST : 100801 로 해봄 
                p.Add("@sal_cust", sal_cust.Text)     '20141119 매출정산거래처

                p.Add("@grp2_cd", grp2_cd.Text)
                p.Add("@grp22_cd", grp22_cd.Text)

                '서브리포트 파라미터추가
                Dim p2 As OpenParameters = New OpenParameters
                p2.Add("@fr_dt", fr_dt.Text)
                p2.Add("@to_dt", to_dt.Text)

                Dim formCd As String = ""
                Dim document As ReportDocument = Nothing     '크리스탈 리포트 뷰를 불러오기. 
                'Dim dSet As DataSet = Link.ReadDataSet("mmb100_print", p)
                'Dim dSet As DataSet = Link.ReadDataSet("", p)   'Link.ReadDataSet("워크셋이름", 파라미터)
                Dim dSet As DataSet = New DataSet

                'If chk.Checked = True Then           '체크,  DIS_AMT = 0 
                '    p.Add("@CHK", "1")
                '    If grp_chk.Checked = True Then      '체크, 폐업,거래종료 뺀것 
                '        p.Add("@GRP_CHK", "1")
                '    Else
                '        p.Add("@GRP_CHK", "2")
                '    End If

                'Else                              '체크 안되면,
                '    p.Add("@CHK", "2")
                '    If grp_chk.Checked = True Then
                '        p.Add("@GRP_CHK", "1")
                '    Else
                '        p.Add("@GRP_CHK", "2")
                '    End If

                'End If
                If chk.Checked = True Then              '청구금액 0원 체크시, 
                    p.Add("@CHK", "1")
                    If grp_chk.Checked = True Then      '폐업인 것만 
                        p.Add("@GRP_CHK", "1")
                        '거래종료
                        If g_end.Checked = True Then
                            p.Add("@G_END", "1")
                            '미출력
                            If print_ck.Checked = True Then
                                p.Add("@PRINT_CK", "1")
                            Else
                                p.Add("@PRINT_CK", "2")
                            End If

                        Else
                            p.Add("@G_END", "2")
                            '미출력
                            If print_ck.Checked = True Then
                                p.Add("@PRINT_CK", "1")
                            Else
                                p.Add("@PRINT_CK", "2")
                            End If

                        End If
                    Else
                        p.Add("@GRP_CHK", "2")
                        '거래종료
                        If g_end.Checked = True Then
                            p.Add("@G_END", "1")
                            '미출력
                            If print_ck.Checked = True Then
                                p.Add("@PRINT_CK", "1")
                            Else
                                p.Add("@PRINT_CK", "2")
                            End If
                        Else
                            p.Add("@G_END", "2")
                            '미출력
                            If print_ck.Checked = True Then
                                p.Add("@PRINT_CK", "1")
                            Else
                                p.Add("@PRINT_CK", "2")
                            End If
                        End If

                    End If
                    'Me.Open("wp_sa1285_g10", p)
                Else                                '체크 안되면,
                    p.Add("@CHK", "2")              ' DIS_AMT <=0 인 것. or ""로 하면, 전체조회.
                    If grp_chk.Checked = True Then
                        p.Add("@GRP_CHK", "1")
                        '거래종료
                        If g_end.Checked = True Then
                            p.Add("@G_END", "1")
                            '미출력
                            If print_ck.Checked = True Then
                                p.Add("@PRINT_CK", "1")
                            Else
                                p.Add("@PRINT_CK", "2")
                            End If
                        Else
                            p.Add("@G_END", "2")
                            '미출력
                            If print_ck.Checked = True Then
                                p.Add("@PRINT_CK", "1")
                            Else
                                p.Add("@PRINT_CK", "2")
                            End If
                        End If

                    Else
                        p.Add("@GRP_CHK", "2")
                        '거래종료
                        If g_end.Checked = True Then
                            p.Add("@G_END", "1")
                            '미출력
                            If print_ck.Checked = True Then
                                p.Add("@PRINT_CK", "1")
                            Else
                                p.Add("@PRINT_CK", "2")
                            End If
                        Else
                            p.Add("@G_END", "2")
                            '미출력
                            If print_ck.Checked = True Then
                                p.Add("@PRINT_CK", "1")
                            Else
                                p.Add("@PRINT_CK", "2")
                            End If
                        End If

                    End If
                    'Me.Open("wp_sa1285_g10", p)
                End If

                dSet = Link.ReadDataSet("wp_sa1285_print", p)

                Dim dRow As DataRow, dRows As DataRowCollection
                dRows = dSet.Tables(0).Rows

                For Each dRow In dRows

                    '20141121 SMK 추가.
                    Dim sale_emp As String
                    sale_emp = dRow("sale_emp")
                    p.Add("@cs_cd", dRow("cs_cd"))      '거래처별로 다시 조회하기 위함
                    dSet = Link.ReadDataSet("wp_sa1285_print", p)

                    If (document Is Nothing) Then
                        formCd = WP_SA1285._GetFileName("WP_SA1285")    'MMB100 'formCd = 자기자신._GetFileName(레포트엔트리이름)
                        If (formCd = "") Then
                            Exit Sub
                        End If

                        Dim expression As ReportDocument = DirectCast(WP_SA1285._LoadAssembly(formCd, "System7"), ReportDocument)    'CrystalReport에서 가져오기.(자기자신._LoadAssembly(formCd, "System7"), ReportDocument)
                        If Information.IsNothing(expression) Then
                            MessageInfo((formCd & ".dll Instance " & ChrW(47484) & " " & ChrW(49373) & ChrW(49457) & ChrW(54624) & " " & ChrW(49688) & " " & ChrW(50630) & ChrW(49845) & ChrW(45768) & ChrW(45796) & "."), Nothing, Nothing)
                            'MsgBox("1")
                            Exit Sub
                        End If
                        document = expression
                    End If

                    If IsEmpty(dSet) Then
                        MessageInfo(ChrW(52636) & ChrW(47141) & ChrW(54624) & " " & ChrW(51088) & ChrW(47308) & ChrW(44032) & " " & ChrW(50630) & ChrW(49845) & ChrW(45768) & ChrW(45796), Nothing, Nothing)
                        'MsgBox("2")
                        Exit Sub
                    End If
                    'document.SetDataSource(dSet.Tables.Item(0))

                    '서브리포트 
                    Dim dtSet As DataSet = Link.ReadDataSet("wp_sa1285_print2", p2)
                    If Not IsEmpty(dtSet) Then
                        ' document.OpenSubreport("sub").SetDataSource(dtSet.Tables.Item(0))
                    End If

                    ' 변수를 선언하고 내보내기 옵션을 가져옵니다.
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions()
                    '파일 이름 설정 
                    'CrDiskFileDestinationOptions.DiskFileName = "c:\" & g10.Text("cs_cd", i) & i & ".pdf"                             '"c:\" & g10.Text("cs_cd", i) & i & ".pdf"      'po_no  fr_dt ps_cd ToDec(EPanel1.Text("ps_cd")) 

                    '20141121 SMK 추가.
                    IO.Directory.CreateDirectory("c:\" & "대금청구서\" & fr_dt.Text & "\" & sale_emp)    '폴더 생성 SMK
                    Dim dRow2 As DataRow, dRows2 As DataRowCollection

                    dRows2 = dSet.Tables(0).Rows

                    For Each dRow2 In dRows2

                        CrDiskFileDestinationOptions.DiskFileName = "c:\" & "대금청구서\" & fr_dt.Text & "\" & sale_emp & "\" & dRow2("cs_cd") & ".pdf"

                        CrExportOptions = document.ExportOptions            '파일 내보내기 옵션
                        With CrExportOptions
                            .ExportDestinationType = ExportDestinationType.DiskFile
                            .ExportFormatType = ExportFormatType.PortableDocFormat
                            .DestinationOptions = CrDiskFileDestinationOptions
                            .FormatOptions = CrFormatTypeOptions
                        End With
                    Next

                    document.Export()    '여기에서 에러남 (매개 변수 값이 없습니다.) -> 서브리포트 쪽에 document.OpenSubreport("sub").SetDataSource(dtSet.Tables.Item(0)) 로 해결함.
                    document.Dispose()
                    document.Close()
                    'If SmtpAccess.Connect = 1 Then

                Next
                cnt = cnt + 1

            End With
            'ProgressBar1.Value = 0
            'ProgressBar1.Visible = False
            save_ing.Visible = False
            save_end.Visible = True
            MessageInfo("[C:\대금청구서\" & fr_dt.Text & "] 파일 저장을 완료하였습니다.")

        Catch ex As Exception
            MessageInfo(ex)
            'ProgressBar1.Value = 0
            'ProgressBar1.Visible = False
        End Try
    End Sub
#End Region


    '출력 버튼 
    Private Sub SimpleButton1_Click(sender As System.Object, e As System.EventArgs) Handles SimpleButton1.Click
        Dim p As OpenParameters = New OpenParameters
        Dim p2 As OpenParameters = New OpenParameters

        p.Add("@fr_dt", fr_dt.Text)
        p.Add("@to_dt", to_dt.Text)
        p.Add("@cs_cd", cs_cd.Text)
        p.Add("@ps_cd", ps_cd.Text)
        p.Add("@sal_cust", sal_cust.Text)     '20141117 매출정산거래처

        p.Add("@grp2_cd", grp2_cd.Text)
        p.Add("@grp22_cd", grp22_cd.Text)

        p2.Add("@fr_dt", fr_dt.Text)
        p2.Add("@to_dt", to_dt.Text)
        ''p2.Add("@cs_cd", cs_cd.Text)  '원래 막혀있음.

        ''System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p) '원래 막혀있음.
        'System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, True, 1, "sub", "wp_sa1285_print2", p2)    '2014-09-29 
        With g10
            For Row As Integer = 0 To g10.RowCount - 1
                p.Add("@cs_cd", g10.Text("cs_cd", Row))
                If g10.Text("g10_chk", Row) = "1" Then

                    'If chk.Checked = True Then           '체크,  DIS_AMT > 0 
                    '    p.Add("@CHK", "1")
                    '    If grp_chk.Checked = True Then      '체크, 폐업,거래종료 뺀것 
                    '        p.Add("@GRP_CHK", "1")
                    '    Else
                    '        p.Add("@GRP_CHK", "2")
                    '    End If
                    '    System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, False, 1, "sub", "wp_sa1285_print2", p2)
                    'Else                              '체크 안되면,
                    '    p.Add("@CHK", "2")
                    '    If grp_chk.Checked = True Then
                    '        p.Add("@GRP_CHK", "1")
                    '    Else
                    '        p.Add("@GRP_CHK", "2")
                    '    End If
                    '    System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, False, 1, "sub", "wp_sa1285_print2", p2)
                    'End If

                    If chk.Checked = True Then              '청구금액 0원 체크시, 
                        p.Add("@CHK", "1")
                        If grp_chk.Checked = True Then      '폐업인 것만 
                            p.Add("@GRP_CHK", "1")
                            '거래종료
                            If g_end.Checked = True Then
                                p.Add("@G_END", "1")
                                '미출력
                                If print_ck.Checked = True Then
                                    p.Add("@PRINT_CK", "1")
                                Else
                                    p.Add("@PRINT_CK", "2")
                                End If

                            Else
                                p.Add("@G_END", "2")
                                '미출력
                                If print_ck.Checked = True Then
                                    p.Add("@PRINT_CK", "1")
                                Else
                                    p.Add("@PRINT_CK", "2")
                                End If

                            End If
                        Else
                            p.Add("@GRP_CHK", "2")
                            '거래종료
                            If g_end.Checked = True Then
                                p.Add("@G_END", "1")
                                '미출력
                                If print_ck.Checked = True Then
                                    p.Add("@PRINT_CK", "1")
                                Else
                                    p.Add("@PRINT_CK", "2")
                                End If
                            Else
                                p.Add("@G_END", "2")
                                '미출력
                                If print_ck.Checked = True Then
                                    p.Add("@PRINT_CK", "1")
                                Else
                                    p.Add("@PRINT_CK", "2")
                                End If
                            End If

                        End If
                        System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, True, 1, "sub", "wp_sa1285_print2", p2)
                    Else                                '체크 안되면,
                        p.Add("@CHK", "2")              ' DIS_AMT <=0 인 것. or ""로 하면, 전체조회.
                        If grp_chk.Checked = True Then
                            p.Add("@GRP_CHK", "1")
                            '거래종료
                            If g_end.Checked = True Then
                                p.Add("@G_END", "1")
                                '미출력
                                If print_ck.Checked = True Then
                                    p.Add("@PRINT_CK", "1")
                                Else
                                    p.Add("@PRINT_CK", "2")
                                End If
                            Else
                                p.Add("@G_END", "2")
                                '미출력
                                If print_ck.Checked = True Then
                                    p.Add("@PRINT_CK", "1")
                                Else
                                    p.Add("@PRINT_CK", "2")
                                End If
                            End If

                        Else
                            p.Add("@GRP_CHK", "2")
                            '거래종료
                            If g_end.Checked = True Then
                                p.Add("@G_END", "1")
                                '미출력
                                If print_ck.Checked = True Then
                                    p.Add("@PRINT_CK", "1")
                                Else
                                    p.Add("@PRINT_CK", "2")
                                End If
                            Else
                                p.Add("@G_END", "2")
                                '미출력
                                If print_ck.Checked = True Then
                                    p.Add("@PRINT_CK", "1")
                                Else
                                    p.Add("@PRINT_CK", "2")
                                End If
                            End If

                        End If
                        System7.ReportView.LoadView("WP_SA1285", "", "wp_sa1285_print", p, Nothing, False, 1, "sub", "wp_sa1285_print2", p2)
                    End If
                End If
            Next
        End With
    End Sub


End Class

