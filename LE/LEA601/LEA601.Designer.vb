﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LEA601
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
        Me.co_cd = New Frame7.eCombo()
        Me.fac_cd = New Frame7.eCombo()
        Me.in_dtf = New Frame7.eDate()
        Me.itm_bc = New Frame7.eCombo()
        Me.grp1_cd = New Frame7.eCombo()
        Me.itm_cd = New Frame7.eText()
        Me.in_dtt = New Frame7.eDate()
        Me.itm_nm = New Frame7.eText()
        Me.EPanel2 = New Frame7.ePanel()
        Me.g10 = New Frame7.eGrid()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel2.SuspendLayout()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.EPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(880, 360)
        Me.SplitContainer1.SplitterDistance = 103
        Me.SplitContainer1.TabIndex = 0
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.co_cd)
        Me.EPanel1.Controls.Add(Me.fac_cd)
        Me.EPanel1.Controls.Add(Me.in_dtf)
        Me.EPanel1.Controls.Add(Me.itm_bc)
        Me.EPanel1.Controls.Add(Me.itm_cd)
        Me.EPanel1.Controls.Add(Me.in_dtt)
        Me.EPanel1.Controls.Add(Me.itm_nm)
        Me.EPanel1.Controls.Add(Me.grp1_cd)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(880, 103)
        Me.EPanel1.TabIndex = 0
        Me.EPanel1.Text = "     검색"
        '
        'co_cd
        '
        Me.co_cd.Location = New System.Drawing.Point(8, 28)
        Me.co_cd.Name = "co_cd"
        Me.co_cd.Size = New System.Drawing.Size(240, 21)
        Me.co_cd.TabIndex = 2
        '
        'fac_cd
        '
        Me.fac_cd.Location = New System.Drawing.Point(8, 52)
        Me.fac_cd.Name = "fac_cd"
        Me.fac_cd.Size = New System.Drawing.Size(240, 21)
        Me.fac_cd.TabIndex = 2
        '
        'in_dtf
        '
        Me.in_dtf.Location = New System.Drawing.Point(268, 28)
        Me.in_dtf.Name = "in_dtf"
        Me.in_dtf.Size = New System.Drawing.Size(240, 21)
        Me.in_dtf.TabIndex = 4
        '
        'itm_bc
        '
        Me.itm_bc.Location = New System.Drawing.Point(8, 76)
        Me.itm_bc.Name = "itm_bc"
        Me.itm_bc.Size = New System.Drawing.Size(240, 21)
        Me.itm_bc.TabIndex = 2
        '
        'grp1_cd
        '
        Me.grp1_cd.Location = New System.Drawing.Point(268, 76)
        Me.grp1_cd.Name = "grp1_cd"
        Me.grp1_cd.Size = New System.Drawing.Size(240, 21)
        Me.grp1_cd.TabIndex = 2
        '
        'itm_cd
        '
        Me.itm_cd.Location = New System.Drawing.Point(268, 52)
        Me.itm_cd.Name = "itm_cd"
        Me.itm_cd.Size = New System.Drawing.Size(240, 21)
        Me.itm_cd.TabIndex = 3
        '
        'in_dtt
        '
        Me.in_dtt.Location = New System.Drawing.Point(515, 28)
        Me.in_dtt.Name = "in_dtt"
        Me.in_dtt.Size = New System.Drawing.Size(168, 21)
        Me.in_dtt.TabIndex = 4
        Me.in_dtt.TitleWidth = 20
        '
        'itm_nm
        '
        Me.itm_nm.Location = New System.Drawing.Point(512, 52)
        Me.itm_nm.Name = "itm_nm"
        Me.itm_nm.Size = New System.Drawing.Size(170, 21)
        Me.itm_nm.TabIndex = 3
        Me.itm_nm.TitleWidth = 0
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.g10)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(880, 253)
        Me.EPanel2.TabIndex = 0
        Me.EPanel2.Text = "     기간별 계정별 매입집계 현황"
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RecordNavigator = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(876, 228)
        Me.g10.TabIndex = 2
        '
        'LEA601
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "LEA601"
        Me.Size = New System.Drawing.Size(888, 373)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel1.ResumeLayout(False)
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel1 As Frame7.ePanel
    Friend WithEvents EPanel2 As Frame7.ePanel
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents co_cd As Frame7.eCombo
    Friend WithEvents fac_cd As Frame7.eCombo
    Friend WithEvents in_dtf As Frame7.eDate
    Friend WithEvents itm_bc As Frame7.eCombo
    Friend WithEvents grp1_cd As Frame7.eCombo
    Friend WithEvents itm_cd As Frame7.eText
    Friend WithEvents in_dtt As Frame7.eDate
    Friend WithEvents itm_nm As Frame7.eText

End Class
