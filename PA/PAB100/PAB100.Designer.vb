﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PAB100
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
        Me.duty_bc = New Frame7.eCombo()
        Me.pay_kd = New Frame7.eCombo()
        Me.nat_chk = New Frame7.eCheck()
        Me.emp_no = New Frame7.eText()
        Me.pnlCopy = New Frame7.ePanel()
        Me.work_kd = New Frame7.eCombo()
        Me.emp_nm = New Frame7.eText()
        Me.dept_cd = New Frame7.eText()
        Me.btn_copy = New DevExpress.XtraEditors.SimpleButton()
        Me.dept_nm = New Frame7.eText()
        Me.pay_mon = New Frame7.eDate()
        Me.pay_sq = New Frame7.eCombo()
        Me.co_cd = New Frame7.eCombo()
        Me.bs_cd = New Frame7.eCombo()
        Me.chk_start = New DevExpress.XtraEditors.SimpleButton()
        Me.chk_del = New DevExpress.XtraEditors.SimpleButton()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.EPanel2 = New Frame7.ePanel()
        Me.chk_all = New DevExpress.XtraEditors.CheckEdit()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
        CType(Me.pnlCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCopy.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel2.SuspendLayout()
        CType(Me.chk_all.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(1012, 478)
        Me.g10.TabIndex = 2
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.duty_bc)
        Me.EPanel1.Controls.Add(Me.pay_kd)
        Me.EPanel1.Controls.Add(Me.emp_no)
        Me.EPanel1.Controls.Add(Me.emp_nm)
        Me.EPanel1.Controls.Add(Me.nat_chk)
        Me.EPanel1.Controls.Add(Me.dept_cd)
        Me.EPanel1.Controls.Add(Me.dept_nm)
        Me.EPanel1.Controls.Add(Me.pay_mon)
        Me.EPanel1.Controls.Add(Me.pay_sq)
        Me.EPanel1.Controls.Add(Me.co_cd)
        Me.EPanel1.Controls.Add(Me.btn_copy)
        Me.EPanel1.Controls.Add(Me.bs_cd)
        Me.EPanel1.Controls.Add(Me.chk_start)
        Me.EPanel1.Controls.Add(Me.chk_del)
        Me.EPanel1.Controls.Add(Me.pnlCopy)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(1016, 129)
        Me.EPanel1.TabIndex = 0
        Me.EPanel1.Text = "     검색조건"
        '
        'duty_bc
        '
        Me.duty_bc.Location = New System.Drawing.Point(520, 52)
        Me.duty_bc.Name = "duty_bc"
        Me.duty_bc.Size = New System.Drawing.Size(240, 21)
        Me.duty_bc.TabIndex = 44
        Me.duty_bc.Title = "직책"
        '
        'pay_kd
        '
        Me.pay_kd.Location = New System.Drawing.Point(520, 28)
        Me.pay_kd.Name = "pay_kd"
        Me.pay_kd.Size = New System.Drawing.Size(240, 21)
        Me.pay_kd.TabIndex = 43
        Me.pay_kd.Title = "급여형태"
        '
        'nat_chk
        '
        Me.nat_chk.Caption = ""
        Me.nat_chk.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.nat_chk.Location = New System.Drawing.Point(902, 28)
        Me.nat_chk.Name = "nat_chk"
        Me.nat_chk.Size = New System.Drawing.Size(109, 21)
        Me.nat_chk.TabIndex = 45
        Me.nat_chk.Title = "외국인여부"
        Me.nat_chk.TitleWidth = 80
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
        'pnlCopy
        '
        Me.pnlCopy.Controls.Add(Me.work_kd)
        Me.pnlCopy.Location = New System.Drawing.Point(564, 76)
        Me.pnlCopy.Name = "pnlCopy"
        Me.pnlCopy.Size = New System.Drawing.Size(196, 45)
        Me.pnlCopy.TabIndex = 83
        Me.pnlCopy.Text = "     근무직"
        Me.pnlCopy.Visible = False
        '
        'work_kd
        '
        Me.work_kd.Location = New System.Drawing.Point(73, 2)
        Me.work_kd.Name = "work_kd"
        Me.work_kd.Size = New System.Drawing.Size(123, 21)
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
        'btn_copy
        '
        Me.btn_copy.Location = New System.Drawing.Point(520, 76)
        Me.btn_copy.Name = "btn_copy"
        Me.btn_copy.Size = New System.Drawing.Size(38, 21)
        Me.btn_copy.TabIndex = 82
        Me.btn_copy.Text = "유형"
        '
        'dept_nm
        '
        Me.dept_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dept_nm.Location = New System.Drawing.Point(264, 52)
        Me.dept_nm.Name = "dept_nm"
        Me.dept_nm.Size = New System.Drawing.Size(240, 21)
        Me.dept_nm.TabIndex = 41
        Me.dept_nm.Title = "부서명"
        '
        'pay_mon
        '
        Me.pay_mon.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.pay_mon.Location = New System.Drawing.Point(8, 28)
        Me.pay_mon.Name = "pay_mon"
        Me.pay_mon.Size = New System.Drawing.Size(240, 21)
        Me.pay_mon.TabIndex = 20
        Me.pay_mon.Title = "귀속년월"
        '
        'pay_sq
        '
        Me.pay_sq.Location = New System.Drawing.Point(8, 52)
        Me.pay_sq.Name = "pay_sq"
        Me.pay_sq.Size = New System.Drawing.Size(240, 21)
        Me.pay_sq.TabIndex = 19
        Me.pay_sq.Title = "지급차수"
        '
        'co_cd
        '
        Me.co_cd.Location = New System.Drawing.Point(8, 76)
        Me.co_cd.Name = "co_cd"
        Me.co_cd.Size = New System.Drawing.Size(240, 21)
        Me.co_cd.TabIndex = 18
        Me.co_cd.Title = "법인"
        '
        'bs_cd
        '
        Me.bs_cd.Location = New System.Drawing.Point(8, 100)
        Me.bs_cd.Name = "bs_cd"
        Me.bs_cd.Size = New System.Drawing.Size(240, 21)
        Me.bs_cd.TabIndex = 12
        Me.bs_cd.Title = "사업장"
        '
        'chk_start
        '
        Me.chk_start.Location = New System.Drawing.Point(776, 28)
        Me.chk_start.Name = "chk_start"
        Me.chk_start.Size = New System.Drawing.Size(120, 24)
        Me.chk_start.TabIndex = 46
        Me.chk_start.Text = "급여계산"
        '
        'chk_del
        '
        Me.chk_del.Location = New System.Drawing.Point(776, 60)
        Me.chk_del.Name = "chk_del"
        Me.chk_del.Size = New System.Drawing.Size(120, 24)
        Me.chk_del.TabIndex = 46
        Me.chk_del.Text = "급여삭제"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.EPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.EPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1016, 636)
        Me.SplitContainer1.SplitterDistance = 129
        Me.SplitContainer1.TabIndex = 1
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.chk_all)
        Me.EPanel2.Controls.Add(Me.g10)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(1016, 503)
        Me.EPanel2.TabIndex = 0
        Me.EPanel2.Text = "     급여대상자등록"
        '
        'chk_all
        '
        Me.chk_all.Location = New System.Drawing.Point(30, 26)
        Me.chk_all.Name = "chk_all"
        Me.chk_all.Properties.Caption = "CheckEdit1"
        Me.chk_all.Size = New System.Drawing.Size(20, 19)
        Me.chk_all.TabIndex = 47
        '
        'PAB100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "PAB100"
        Me.Size = New System.Drawing.Size(1034, 636)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel1.ResumeLayout(False)
        CType(Me.pnlCopy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCopy.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel2.ResumeLayout(False)
        CType(Me.chk_all.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents nat_chk As Frame7.eCheck
    Friend WithEvents duty_bc As Frame7.eCombo
    Friend WithEvents chk_start As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chk_del As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chk_all As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents pnlCopy As Frame7.ePanel
    Friend WithEvents work_kd As Frame7.eCombo
    Friend WithEvents btn_copy As DevExpress.XtraEditors.SimpleButton

End Class
