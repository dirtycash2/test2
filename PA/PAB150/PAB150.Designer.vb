﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PAB150
    Inherits Base7.Form

    'UserControl1은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.g10 = New Frame7.eGrid()
        Me.EPanel1 = New Frame7.ePanel()
        Me.emp_no = New Frame7.eText()
        Me.btn_copy = New DevExpress.XtraEditors.SimpleButton()
        Me.pnlCopy = New Frame7.ePanel()
        Me.work_kd = New Frame7.eCombo()
        Me.emp_nm = New Frame7.eText()
        Me.dept_cd = New Frame7.eText()
        Me.pay_mon = New Frame7.eDate()
        Me.pay_kd = New Frame7.eCombo()
        Me.dept_nm = New Frame7.eText()
        Me.pay_sq = New Frame7.eCombo()
        Me.co_cd = New Frame7.eCombo()
        Me.bs_cd = New Frame7.eCombo()
        Me.chk = New Frame7.eCheck()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.EPanel3 = New Frame7.ePanel()
        Me.f_emp_no = New Frame7.eText()
        Me.f_emp_nm = New Frame7.eText()
        Me.but_save = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_work = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.EPanel2 = New Frame7.ePanel()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.g20 = New Frame7.eGrid()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.g30 = New Frame7.eGrid()
        Me.XtraTabPage3 = New DevExpress.XtraTab.XtraTabPage()
        Me.g40 = New Frame7.eGrid()
        Me.to_pay_amt = New Frame7.eText()
        Me.fr_pay_amt = New Frame7.eText()
        Me.dif_pay_amt = New Frame7.eText()
        Me.to_dif_tot = New Frame7.eText()
        Me.fr_dif_tot = New Frame7.eText()
        Me.dif_dif_tot = New Frame7.eText()
        Me.to_pay_tot = New Frame7.eText()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fr_pay_tot = New Frame7.eText()
        Me.dif_pay_tot = New Frame7.eText()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
        CType(Me.pnlCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCopy.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.EPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel3.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel2.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        Me.XtraTabPage2.SuspendLayout()
        Me.XtraTabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(795, 510)
        Me.g10.TabIndex = 2
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.emp_no)
        Me.EPanel1.Controls.Add(Me.btn_copy)
        Me.EPanel1.Controls.Add(Me.pnlCopy)
        Me.EPanel1.Controls.Add(Me.emp_nm)
        Me.EPanel1.Controls.Add(Me.dept_cd)
        Me.EPanel1.Controls.Add(Me.pay_mon)
        Me.EPanel1.Controls.Add(Me.pay_kd)
        Me.EPanel1.Controls.Add(Me.dept_nm)
        Me.EPanel1.Controls.Add(Me.pay_sq)
        Me.EPanel1.Controls.Add(Me.co_cd)
        Me.EPanel1.Controls.Add(Me.bs_cd)
        Me.EPanel1.Controls.Add(Me.chk)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(799, 128)
        Me.EPanel1.TabIndex = 0
        Me.EPanel1.Text = "     검색조건"
        '
        'emp_no
        '
        Me.emp_no.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.emp_no.Location = New System.Drawing.Point(264, 76)
        Me.emp_no.Name = "emp_no"
        Me.emp_no.Size = New System.Drawing.Size(240, 21)
        Me.emp_no.TabIndex = 40
        Me.emp_no.Title = "사원코드(%)"
        '
        'btn_copy
        '
        Me.btn_copy.Location = New System.Drawing.Point(508, 52)
        Me.btn_copy.Name = "btn_copy"
        Me.btn_copy.Size = New System.Drawing.Size(38, 21)
        Me.btn_copy.TabIndex = 84
        Me.btn_copy.Text = "유형"
        '
        'pnlCopy
        '
        Me.pnlCopy.Controls.Add(Me.work_kd)
        Me.pnlCopy.Location = New System.Drawing.Point(510, 76)
        Me.pnlCopy.Name = "pnlCopy"
        Me.pnlCopy.Size = New System.Drawing.Size(162, 45)
        Me.pnlCopy.TabIndex = 85
        Me.pnlCopy.Text = "     근무직"
        Me.pnlCopy.Visible = False
        '
        'work_kd
        '
        Me.work_kd.Location = New System.Drawing.Point(68, 2)
        Me.work_kd.Name = "work_kd"
        Me.work_kd.Size = New System.Drawing.Size(94, 21)
        Me.work_kd.TabIndex = 60
        Me.work_kd.Title = ""
        Me.work_kd.TitleWidth = 1
        '
        'emp_nm
        '
        Me.emp_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.emp_nm.Location = New System.Drawing.Point(264, 100)
        Me.emp_nm.Name = "emp_nm"
        Me.emp_nm.Size = New System.Drawing.Size(240, 21)
        Me.emp_nm.TabIndex = 42
        Me.emp_nm.Title = "사원명(%)"
        '
        'dept_cd
        '
        Me.dept_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dept_cd.Location = New System.Drawing.Point(264, 28)
        Me.dept_cd.Name = "dept_cd"
        Me.dept_cd.Size = New System.Drawing.Size(240, 21)
        Me.dept_cd.TabIndex = 39
        Me.dept_cd.Title = "부서"
        '
        'pay_mon
        '
        Me.pay_mon.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.pay_mon.Location = New System.Drawing.Point(8, 76)
        Me.pay_mon.Name = "pay_mon"
        Me.pay_mon.Size = New System.Drawing.Size(240, 21)
        Me.pay_mon.TabIndex = 20
        Me.pay_mon.Title = "귀속년월"
        '
        'pay_kd
        '
        Me.pay_kd.Location = New System.Drawing.Point(264, 52)
        Me.pay_kd.Name = "pay_kd"
        Me.pay_kd.Size = New System.Drawing.Size(240, 21)
        Me.pay_kd.TabIndex = 43
        Me.pay_kd.Title = "급여형태"
        '
        'dept_nm
        '
        Me.dept_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dept_nm.Location = New System.Drawing.Point(508, 28)
        Me.dept_nm.Name = "dept_nm"
        Me.dept_nm.Size = New System.Drawing.Size(164, 21)
        Me.dept_nm.TabIndex = 41
        Me.dept_nm.Title = "부서명"
        Me.dept_nm.TitleWidth = 0
        '
        'pay_sq
        '
        Me.pay_sq.Location = New System.Drawing.Point(8, 100)
        Me.pay_sq.Name = "pay_sq"
        Me.pay_sq.Size = New System.Drawing.Size(240, 21)
        Me.pay_sq.TabIndex = 19
        Me.pay_sq.Title = "지급차수"
        '
        'co_cd
        '
        Me.co_cd.Location = New System.Drawing.Point(8, 28)
        Me.co_cd.Name = "co_cd"
        Me.co_cd.Size = New System.Drawing.Size(240, 21)
        Me.co_cd.TabIndex = 18
        Me.co_cd.Title = "법인"
        '
        'bs_cd
        '
        Me.bs_cd.Location = New System.Drawing.Point(8, 52)
        Me.bs_cd.Name = "bs_cd"
        Me.bs_cd.Size = New System.Drawing.Size(240, 21)
        Me.bs_cd.TabIndex = 12
        Me.bs_cd.Title = "사업장"
        '
        'chk
        '
        Me.chk.Caption = ""
        Me.chk.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.chk.Location = New System.Drawing.Point(577, 52)
        Me.chk.Name = "chk"
        Me.chk.Size = New System.Drawing.Size(100, 21)
        Me.chk.TabIndex = 45
        Me.chk.Title = "근무정보보기"
        Me.chk.TitleWidth = 80
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1271, 667)
        Me.SplitContainer1.SplitterDistance = 128
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.EPanel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.EPanel3)
        Me.SplitContainer2.Size = New System.Drawing.Size(1271, 128)
        Me.SplitContainer2.SplitterDistance = 799
        Me.SplitContainer2.TabIndex = 0
        '
        'EPanel3
        '
        Me.EPanel3.Controls.Add(Me.f_emp_no)
        Me.EPanel3.Controls.Add(Me.f_emp_nm)
        Me.EPanel3.Controls.Add(Me.but_save)
        Me.EPanel3.Controls.Add(Me.btn_work)
        Me.EPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel3.Location = New System.Drawing.Point(0, 0)
        Me.EPanel3.Name = "EPanel3"
        Me.EPanel3.Size = New System.Drawing.Size(468, 128)
        Me.EPanel3.TabIndex = 0
        Me.EPanel3.Text = "     대상자"
        '
        'f_emp_no
        '
        Me.f_emp_no.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.f_emp_no.Location = New System.Drawing.Point(8, 28)
        Me.f_emp_no.Name = "f_emp_no"
        Me.f_emp_no.Size = New System.Drawing.Size(120, 21)
        Me.f_emp_no.TabIndex = 43
        Me.f_emp_no.Title = "대상자"
        Me.f_emp_no.TitleWidth = 0
        '
        'f_emp_nm
        '
        Me.f_emp_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.f_emp_nm.Location = New System.Drawing.Point(8, 52)
        Me.f_emp_nm.Name = "f_emp_nm"
        Me.f_emp_nm.Size = New System.Drawing.Size(120, 21)
        Me.f_emp_nm.TabIndex = 44
        Me.f_emp_nm.Title = ""
        Me.f_emp_nm.TitleWidth = 0
        '
        'but_save
        '
        Me.but_save.Location = New System.Drawing.Point(8, 80)
        Me.but_save.Name = "but_save"
        Me.but_save.Size = New System.Drawing.Size(52, 24)
        Me.but_save.TabIndex = 46
        Me.but_save.Text = "저장"
        '
        'btn_work
        '
        Me.btn_work.Location = New System.Drawing.Point(68, 80)
        Me.btn_work.Name = "btn_work"
        Me.btn_work.Size = New System.Drawing.Size(60, 24)
        Me.btn_work.TabIndex = 46
        Me.btn_work.Text = "재계산"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.EPanel2)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer3.Size = New System.Drawing.Size(1271, 535)
        Me.SplitContainer3.SplitterDistance = 799
        Me.SplitContainer3.TabIndex = 0
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.g10)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(799, 535)
        Me.EPanel2.TabIndex = 0
        Me.EPanel2.Text = "     급여조정현황"
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.AutoScroll = True
        Me.SplitContainer4.Panel1.Controls.Add(Me.XtraTabControl1)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplitContainer4.Panel2.Controls.Add(Me.to_pay_amt)
        Me.SplitContainer4.Panel2.Controls.Add(Me.fr_pay_amt)
        Me.SplitContainer4.Panel2.Controls.Add(Me.dif_pay_amt)
        Me.SplitContainer4.Panel2.Controls.Add(Me.to_dif_tot)
        Me.SplitContainer4.Panel2.Controls.Add(Me.fr_dif_tot)
        Me.SplitContainer4.Panel2.Controls.Add(Me.dif_dif_tot)
        Me.SplitContainer4.Panel2.Controls.Add(Me.to_pay_tot)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer4.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer4.Panel2.Controls.Add(Me.fr_pay_tot)
        Me.SplitContainer4.Panel2.Controls.Add(Me.dif_pay_tot)
        Me.SplitContainer4.Size = New System.Drawing.Size(468, 535)
        Me.SplitContainer4.SplitterDistance = 408
        Me.SplitContainer4.TabIndex = 0
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 0)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(468, 408)
        Me.XtraTabControl1.TabIndex = 0
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2, Me.XtraTabPage3})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.g20)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(461, 378)
        Me.XtraTabPage1.Text = "지급"
        '
        'g20
        '
        Me.g20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g20.Location = New System.Drawing.Point(0, 0)
        Me.g20.Name = "g20"
        Me.g20.ReadOnly = False
        Me.g20.RowHeight = -1
        Me.g20.Size = New System.Drawing.Size(461, 378)
        Me.g20.TabIndex = 3
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.g30)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(461, 378)
        Me.XtraTabPage2.Text = "공제"
        '
        'g30
        '
        Me.g30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g30.Location = New System.Drawing.Point(0, 0)
        Me.g30.Name = "g30"
        Me.g30.ReadOnly = False
        Me.g30.RecordNavigator = False
        Me.g30.RowHeight = -1
        Me.g30.Size = New System.Drawing.Size(461, 378)
        Me.g30.TabIndex = 3
        '
        'XtraTabPage3
        '
        Me.XtraTabPage3.Controls.Add(Me.g40)
        Me.XtraTabPage3.Name = "XtraTabPage3"
        Me.XtraTabPage3.Size = New System.Drawing.Size(461, 378)
        Me.XtraTabPage3.Text = "계산"
        '
        'g40
        '
        Me.g40.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g40.Location = New System.Drawing.Point(0, 0)
        Me.g40.Name = "g40"
        Me.g40.ReadOnly = False
        Me.g40.RecordNavigator = False
        Me.g40.RowHeight = -1
        Me.g40.Size = New System.Drawing.Size(461, 378)
        Me.g40.TabIndex = 3
        '
        'to_pay_amt
        '
        Me.to_pay_amt.ForeColor = System.Drawing.Color.Blue
        Me.to_pay_amt.Location = New System.Drawing.Point(8, 90)
        Me.to_pay_amt.Name = "to_pay_amt"
        Me.to_pay_amt.Size = New System.Drawing.Size(180, 21)
        Me.to_pay_amt.TabIndex = 53
        Me.to_pay_amt.Title = "실지급액"
        Me.to_pay_amt.TitleAlign = Frame7.Alignment.Center
        Me.to_pay_amt.TitleWidth = 80
        '
        'fr_pay_amt
        '
        Me.fr_pay_amt.Location = New System.Drawing.Point(108, 90)
        Me.fr_pay_amt.Name = "fr_pay_amt"
        Me.fr_pay_amt.Size = New System.Drawing.Size(180, 21)
        Me.fr_pay_amt.TabIndex = 54
        Me.fr_pay_amt.Title = "지급_조정전"
        Me.fr_pay_amt.TitleWidth = 80
        '
        'dif_pay_amt
        '
        Me.dif_pay_amt.Location = New System.Drawing.Point(208, 90)
        Me.dif_pay_amt.Name = "dif_pay_amt"
        Me.dif_pay_amt.Size = New System.Drawing.Size(180, 21)
        Me.dif_pay_amt.TabIndex = 55
        Me.dif_pay_amt.Title = "지급_차이"
        Me.dif_pay_amt.TitleWidth = 80
        '
        'to_dif_tot
        '
        Me.to_dif_tot.ForeColor = System.Drawing.Color.Blue
        Me.to_dif_tot.Location = New System.Drawing.Point(8, 66)
        Me.to_dif_tot.Name = "to_dif_tot"
        Me.to_dif_tot.Size = New System.Drawing.Size(180, 21)
        Me.to_dif_tot.TabIndex = 50
        Me.to_dif_tot.Title = "공제계"
        Me.to_dif_tot.TitleAlign = Frame7.Alignment.Center
        Me.to_dif_tot.TitleWidth = 80
        '
        'fr_dif_tot
        '
        Me.fr_dif_tot.Location = New System.Drawing.Point(108, 66)
        Me.fr_dif_tot.Name = "fr_dif_tot"
        Me.fr_dif_tot.Size = New System.Drawing.Size(180, 21)
        Me.fr_dif_tot.TabIndex = 51
        Me.fr_dif_tot.Title = "지급_조정전"
        Me.fr_dif_tot.TitleWidth = 80
        '
        'dif_dif_tot
        '
        Me.dif_dif_tot.Location = New System.Drawing.Point(208, 66)
        Me.dif_dif_tot.Name = "dif_dif_tot"
        Me.dif_dif_tot.Size = New System.Drawing.Size(180, 21)
        Me.dif_dif_tot.TabIndex = 52
        Me.dif_dif_tot.Title = "지급_차이"
        Me.dif_dif_tot.TitleWidth = 80
        '
        'to_pay_tot
        '
        Me.to_pay_tot.ForeColor = System.Drawing.Color.Blue
        Me.to_pay_tot.Location = New System.Drawing.Point(8, 42)
        Me.to_pay_tot.Name = "to_pay_tot"
        Me.to_pay_tot.Size = New System.Drawing.Size(180, 21)
        Me.to_pay_tot.TabIndex = 47
        Me.to_pay_tot.Title = "지급계"
        Me.to_pay_tot.TitleAlign = Frame7.Alignment.Center
        Me.to_pay_tot.TitleWidth = 80
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(6, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(380, 7)
        Me.Panel1.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(320, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "차이"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(212, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "조정전"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(112, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "조정후"
        '
        'fr_pay_tot
        '
        Me.fr_pay_tot.Location = New System.Drawing.Point(108, 42)
        Me.fr_pay_tot.Name = "fr_pay_tot"
        Me.fr_pay_tot.Size = New System.Drawing.Size(180, 21)
        Me.fr_pay_tot.TabIndex = 48
        Me.fr_pay_tot.Title = "지급_조정전"
        Me.fr_pay_tot.TitleWidth = 80
        '
        'dif_pay_tot
        '
        Me.dif_pay_tot.Location = New System.Drawing.Point(208, 42)
        Me.dif_pay_tot.Name = "dif_pay_tot"
        Me.dif_pay_tot.Size = New System.Drawing.Size(180, 21)
        Me.dif_pay_tot.TabIndex = 49
        Me.dif_pay_tot.Title = "지급_차이"
        Me.dif_pay_tot.TitleWidth = 80
        '
        'PAB150
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "PAB150"
        Me.Size = New System.Drawing.Size(1271, 667)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel1.ResumeLayout(False)
        CType(Me.pnlCopy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCopy.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.EPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel3.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel2.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.Panel2.PerformLayout()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        Me.XtraTabPage2.ResumeLayout(False)
        Me.XtraTabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents EPanel1 As Frame7.ePanel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel2 As Frame7.ePanel
    Friend WithEvents bs_cd As Frame7.eCombo
    Friend WithEvents co_cd As Frame7.eCombo
    Friend WithEvents pay_mon As Frame7.eDate
    Friend WithEvents pay_sq As Frame7.eCombo
    Friend WithEvents emp_no As Frame7.eText
    Friend WithEvents emp_nm As Frame7.eText
    Friend WithEvents dept_cd As Frame7.eText
    Friend WithEvents dept_nm As Frame7.eText
    Friend WithEvents pay_kd As Frame7.eCombo
    Friend WithEvents chk As Frame7.eCheck
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel3 As Frame7.ePanel
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents f_emp_no As Frame7.eText
    Friend WithEvents f_emp_nm As Frame7.eText
    Friend WithEvents but_save As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents g20 As Frame7.eGrid
    Friend WithEvents g30 As Frame7.eGrid
    Friend WithEvents XtraTabPage3 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents g40 As Frame7.eGrid
    Friend WithEvents to_pay_amt As Frame7.eText
    Friend WithEvents fr_pay_amt As Frame7.eText
    Friend WithEvents dif_pay_amt As Frame7.eText
    Friend WithEvents to_dif_tot As Frame7.eText
    Friend WithEvents fr_dif_tot As Frame7.eText
    Friend WithEvents dif_dif_tot As Frame7.eText
    Friend WithEvents to_pay_tot As Frame7.eText
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fr_pay_tot As Frame7.eText
    Friend WithEvents dif_pay_tot As Frame7.eText
    Friend WithEvents btn_work As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_copy As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents pnlCopy As Frame7.ePanel
    Friend WithEvents work_kd As Frame7.eCombo

End Class
