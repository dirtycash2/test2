﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PPC102
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
        Me.EPanel1 = New Frame7.ePanel()
        Me.grp1_cd = New Frame7.eCombo()
        Me.grp2_cd = New Frame7.eCombo()
        Me.itm_bc = New Frame7.eCombo()
        Me.grp3_cd = New Frame7.eCombo()
        Me.itm_cd = New Frame7.eText()
        Me.fac_f_cd = New Frame7.eCombo()
        Me.work_f_ym = New Frame7.eDate()
        Me.itm_nm = New Frame7.eText()
        Me.work_t_ym = New Frame7.eDate()
        Me.EPanel7 = New Frame7.ePanel()
        Me.g10 = New Frame7.eGrid()
        Me.wc_cd = New Frame7.eCombo()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
        CType(Me.EPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(4, 4)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.EPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.EPanel7)
        Me.SplitContainer1.Size = New System.Drawing.Size(951, 556)
        Me.SplitContainer1.SplitterDistance = 104
        Me.SplitContainer1.TabIndex = 0
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.grp1_cd)
        Me.EPanel1.Controls.Add(Me.grp2_cd)
        Me.EPanel1.Controls.Add(Me.wc_cd)
        Me.EPanel1.Controls.Add(Me.itm_bc)
        Me.EPanel1.Controls.Add(Me.itm_cd)
        Me.EPanel1.Controls.Add(Me.fac_f_cd)
        Me.EPanel1.Controls.Add(Me.work_f_ym)
        Me.EPanel1.Controls.Add(Me.itm_nm)
        Me.EPanel1.Controls.Add(Me.work_t_ym)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(951, 104)
        Me.EPanel1.TabIndex = 0
        Me.EPanel1.Text = "     검색"
        '
        'grp1_cd
        '
        Me.grp1_cd.Location = New System.Drawing.Point(541, 28)
        Me.grp1_cd.Name = "grp1_cd"
        Me.grp1_cd.Size = New System.Drawing.Size(240, 21)
        Me.grp1_cd.TabIndex = 18
        Me.grp1_cd.Title = "대분류"
        '
        'grp2_cd
        '
        Me.grp2_cd.Location = New System.Drawing.Point(541, 52)
        Me.grp2_cd.Name = "grp2_cd"
        Me.grp2_cd.Size = New System.Drawing.Size(240, 21)
        Me.grp2_cd.TabIndex = 19
        Me.grp2_cd.Title = "중분류"
        '
        'itm_bc
        '
        Me.itm_bc.Location = New System.Drawing.Point(277, 28)
        Me.itm_bc.Name = "itm_bc"
        Me.itm_bc.Size = New System.Drawing.Size(240, 21)
        Me.itm_bc.TabIndex = 17
        Me.itm_bc.Title = "품목구분"
        Me.itm_bc.TitleWidth = 120
        '
        'grp3_cd
        '
        Me.grp3_cd.Location = New System.Drawing.Point(440, 120)
        Me.grp3_cd.Name = "grp3_cd"
        Me.grp3_cd.Size = New System.Drawing.Size(240, 21)
        Me.grp3_cd.TabIndex = 20
        Me.grp3_cd.Title = "소분류"
        '
        'itm_cd
        '
        Me.itm_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.itm_cd.Location = New System.Drawing.Point(277, 52)
        Me.itm_cd.Name = "itm_cd"
        Me.itm_cd.Size = New System.Drawing.Size(240, 21)
        Me.itm_cd.TabIndex = 9
        Me.itm_cd.Title = "품목코드%"
        Me.itm_cd.TitleWidth = 120
        '
        'fac_f_cd
        '
        Me.fac_f_cd.Location = New System.Drawing.Point(12, 76)
        Me.fac_f_cd.Name = "fac_f_cd"
        Me.fac_f_cd.Size = New System.Drawing.Size(240, 21)
        Me.fac_f_cd.TabIndex = 3
        Me.fac_f_cd.Title = "생산공장"
        '
        'work_f_ym
        '
        Me.work_f_ym.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.work_f_ym.Format = "yyyy-MM"
        Me.work_f_ym.Location = New System.Drawing.Point(12, 28)
        Me.work_f_ym.Name = "work_f_ym"
        Me.work_f_ym.Size = New System.Drawing.Size(240, 21)
        Me.work_f_ym.TabIndex = 7
        Me.work_f_ym.Title = "기준년월"
        '
        'itm_nm
        '
        Me.itm_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.itm_nm.Location = New System.Drawing.Point(277, 76)
        Me.itm_nm.Name = "itm_nm"
        Me.itm_nm.Size = New System.Drawing.Size(240, 21)
        Me.itm_nm.TabIndex = 10
        Me.itm_nm.Title = "품목명%"
        Me.itm_nm.TitleWidth = 120
        '
        'work_t_ym
        '
        Me.work_t_ym.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.work_t_ym.Format = "yyyy-MM"
        Me.work_t_ym.Location = New System.Drawing.Point(132, 52)
        Me.work_t_ym.Name = "work_t_ym"
        Me.work_t_ym.Size = New System.Drawing.Size(120, 21)
        Me.work_t_ym.TabIndex = 6
        Me.work_t_ym.TitleWidth = 0
        '
        'EPanel7
        '
        Me.EPanel7.Controls.Add(Me.g10)
        Me.EPanel7.Controls.Add(Me.grp3_cd)
        Me.EPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel7.Location = New System.Drawing.Point(0, 0)
        Me.EPanel7.Name = "EPanel7"
        Me.EPanel7.Size = New System.Drawing.Size(951, 448)
        Me.EPanel7.TabIndex = 2
        Me.EPanel7.Text = "     생산 현황"
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(947, 423)
        Me.g10.TabIndex = 2
        '
        'wc_cd
        '
        Me.wc_cd.Location = New System.Drawing.Point(541, 76)
        Me.wc_cd.Name = "wc_cd"
        Me.wc_cd.Size = New System.Drawing.Size(240, 21)
        Me.wc_cd.TabIndex = 20
        '
        'PPC102
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "PPC102"
        Me.Size = New System.Drawing.Size(977, 563)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel1.ResumeLayout(False)
        CType(Me.EPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel1 As Frame7.ePanel
    Friend WithEvents fac_f_cd As Frame7.eCombo
    Friend WithEvents work_f_ym As Frame7.eDate
    Friend WithEvents work_t_ym As Frame7.eDate
    Friend WithEvents itm_nm As Frame7.eText
    Friend WithEvents itm_cd As Frame7.eText
    Friend WithEvents EPanel7 As Frame7.ePanel
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents grp3_cd As Frame7.eCombo
    Friend WithEvents grp2_cd As Frame7.eCombo
    Friend WithEvents grp1_cd As Frame7.eCombo
    Friend WithEvents itm_bc As Frame7.eCombo
    Friend WithEvents wc_cd As Frame7.eCombo

End Class
