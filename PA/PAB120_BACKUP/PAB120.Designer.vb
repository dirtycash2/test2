﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PAB120
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.EPanel2 = New Frame7.ePanel()
        Me.pay_sq = New Frame7.eCombo()
        Me.emp_no = New Frame7.eText()
        Me.dept_cd = New Frame7.eText()
        Me.nat_chk = New Frame7.eCheck()
        Me.btn_send = New DevExpress.XtraEditors.SimpleButton()
        Me.emp_nm = New Frame7.eText()
        Me.dept_nm = New Frame7.eText()
        Me.all_chk = New Frame7.eCheck()
        Me.co_cd = New Frame7.eCombo()
        Me.pay_mon = New Frame7.eDate()
        Me.EPanel1 = New Frame7.ePanel()
        Me.g10 = New Frame7.eGrid()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel2.SuspendLayout()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.EPanel2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.EPanel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1329, 411)
        Me.SplitContainer1.SplitterDistance = 78
        Me.SplitContainer1.TabIndex = 1
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.pay_sq)
        Me.EPanel2.Controls.Add(Me.emp_no)
        Me.EPanel2.Controls.Add(Me.ProgressBar1)
        Me.EPanel2.Controls.Add(Me.nat_chk)
        Me.EPanel2.Controls.Add(Me.btn_send)
        Me.EPanel2.Controls.Add(Me.dept_cd)
        Me.EPanel2.Controls.Add(Me.emp_nm)
        Me.EPanel2.Controls.Add(Me.dept_nm)
        Me.EPanel2.Controls.Add(Me.all_chk)
        Me.EPanel2.Controls.Add(Me.co_cd)
        Me.EPanel2.Controls.Add(Me.pay_mon)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(1329, 78)
        Me.EPanel2.TabIndex = 9
        Me.EPanel2.Text = "     급여정보"
        '
        'pay_sq
        '
        Me.pay_sq.Location = New System.Drawing.Point(520, 28)
        Me.pay_sq.Name = "pay_sq"
        Me.pay_sq.Size = New System.Drawing.Size(240, 21)
        Me.pay_sq.TabIndex = 72
        Me.pay_sq.Title = "pay_sq"
        '
        'emp_no
        '
        Me.emp_no.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.emp_no.Location = New System.Drawing.Point(1088, 28)
        Me.emp_no.Name = "emp_no"
        Me.emp_no.Size = New System.Drawing.Size(240, 21)
        Me.emp_no.TabIndex = 71
        Me.emp_no.Title = "emp_no"
        '
        'dept_cd
        '
        Me.dept_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dept_cd.Location = New System.Drawing.Point(1292, 52)
        Me.dept_cd.Name = "dept_cd"
        Me.dept_cd.Size = New System.Drawing.Size(32, 21)
        Me.dept_cd.TabIndex = 70
        Me.dept_cd.Title = "부서"
        '
        'nat_chk
        '
        Me.nat_chk.Caption = ""
        Me.nat_chk.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.nat_chk.Location = New System.Drawing.Point(520, 52)
        Me.nat_chk.Name = "nat_chk"
        Me.nat_chk.Size = New System.Drawing.Size(240, 21)
        Me.nat_chk.TabIndex = 69
        Me.nat_chk.Title = "외국인"
        '
        'btn_send
        '
        Me.btn_send.Location = New System.Drawing.Point(932, 26)
        Me.btn_send.Name = "btn_send"
        Me.btn_send.Size = New System.Drawing.Size(152, 48)
        Me.btn_send.TabIndex = 8
        Me.btn_send.Text = "E-mail 보내기"
        '
        'emp_nm
        '
        Me.emp_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.emp_nm.Location = New System.Drawing.Point(268, 52)
        Me.emp_nm.Name = "emp_nm"
        Me.emp_nm.Size = New System.Drawing.Size(240, 21)
        Me.emp_nm.TabIndex = 7
        Me.emp_nm.Title = "사원명(%)"
        '
        'dept_nm
        '
        Me.dept_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dept_nm.Location = New System.Drawing.Point(16, 52)
        Me.dept_nm.Name = "dept_nm"
        Me.dept_nm.Size = New System.Drawing.Size(240, 21)
        Me.dept_nm.TabIndex = 5
        Me.dept_nm.Title = "부서"
        '
        'all_chk
        '
        Me.all_chk.Caption = ""
        Me.all_chk.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.all_chk.Location = New System.Drawing.Point(776, 28)
        Me.all_chk.Name = "all_chk"
        Me.all_chk.Size = New System.Drawing.Size(152, 21)
        Me.all_chk.TabIndex = 9
        Me.all_chk.Title = "전체선택"
        Me.all_chk.TitleWidth = 80
        '
        'co_cd
        '
        Me.co_cd.Location = New System.Drawing.Point(16, 28)
        Me.co_cd.Name = "co_cd"
        Me.co_cd.Size = New System.Drawing.Size(240, 21)
        Me.co_cd.TabIndex = 2
        Me.co_cd.Title = "법인"
        '
        'pay_mon
        '
        Me.pay_mon.Location = New System.Drawing.Point(268, 28)
        Me.pay_mon.Name = "pay_mon"
        Me.pay_mon.Size = New System.Drawing.Size(240, 21)
        Me.pay_mon.TabIndex = 3
        Me.pay_mon.Title = "기준월"
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.g10)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(1329, 329)
        Me.EPanel1.TabIndex = 8
        Me.EPanel1.Text = "     사원선택"
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(1325, 304)
        Me.g10.TabIndex = 4
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(1092, 52)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 5
        '
        'PAB120
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "PAB120"
        Me.Size = New System.Drawing.Size(1329, 411)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel2.ResumeLayout(False)
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel2 As Frame7.ePanel
    Friend WithEvents dept_cd As Frame7.eText
    Friend WithEvents nat_chk As Frame7.eCheck
    Friend WithEvents btn_send As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents all_chk As Frame7.eCheck
    Friend WithEvents emp_nm As Frame7.eText
    Friend WithEvents dept_nm As Frame7.eText
    Friend WithEvents co_cd As Frame7.eCombo
    Friend WithEvents pay_mon As Frame7.eDate
    Friend WithEvents EPanel1 As Frame7.ePanel
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents emp_no As Frame7.eText
    Friend WithEvents pay_sq As Frame7.eCombo
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
