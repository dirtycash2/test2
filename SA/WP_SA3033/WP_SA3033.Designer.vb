﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WP_SA3033
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
        Me.g_multi = New Frame7.eGrid()
        Me.EPanel2 = New Frame7.ePanel()
        Me.EText3 = New Frame7.eText()
        Me.EText4 = New Frame7.eText()
        Me.ECombo2 = New Frame7.eCombo()
        Me.cs_nm = New Frame7.eText()
        Me.cs_cd = New Frame7.eText()
        Me.pl_cd = New Frame7.eText()
        Me.pl_nm = New Frame7.eText()
        Me.fr_dt = New Frame7.eDate()
        Me.to_dt = New Frame7.eDate()
        Me.ps_cd = New Frame7.eText()
        Me.ps_nm = New Frame7.eText()
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
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.EPanel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.g_multi)
        Me.SplitContainer1.Panel2.Controls.Add(Me.EPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1182, 611)
        Me.SplitContainer1.SplitterDistance = 91
        Me.SplitContainer1.TabIndex = 6
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.cs_cd)
        Me.EPanel1.Controls.Add(Me.pl_cd)
        Me.EPanel1.Controls.Add(Me.pl_nm)
        Me.EPanel1.Controls.Add(Me.fr_dt)
        Me.EPanel1.Controls.Add(Me.to_dt)
        Me.EPanel1.Controls.Add(Me.ps_cd)
        Me.EPanel1.Controls.Add(Me.ps_nm)
        Me.EPanel1.Controls.Add(Me.cs_nm)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(1182, 91)
        Me.EPanel1.TabIndex = 1
        Me.EPanel1.Text = "     영업담당자등록"
        '
        'g_multi
        '
        Me.g_multi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g_multi.Location = New System.Drawing.Point(0, 0)
        Me.g_multi.Name = "g_multi"
        Me.g_multi.ReadOnly = False
        Me.g_multi.RowHeight = -1
        Me.g_multi.Size = New System.Drawing.Size(1182, 516)
        Me.g_multi.TabIndex = 2
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.EText3)
        Me.EPanel2.Controls.Add(Me.EText4)
        Me.EPanel2.Controls.Add(Me.ECombo2)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(1182, 516)
        Me.EPanel2.TabIndex = 1
        Me.EPanel2.Text = "     Price Term 등록"
        '
        'EText3
        '
        Me.EText3.ColumnName = "find_paymenterm_cd"
        Me.EText3.Location = New System.Drawing.Point(19, 41)
        Me.EText3.Name = "EText3"
        Me.EText3.Size = New System.Drawing.Size(210, 21)
        Me.EText3.TabIndex = 5
        Me.EText3.TableName = "find_paymenterm_cd"
        Me.EText3.Title = "코 드"
        Me.EText3.TitleWidth = 98
        '
        'EText4
        '
        Me.EText4.ColumnName = "find_paymentterm_nm"
        Me.EText4.Location = New System.Drawing.Point(19, 68)
        Me.EText4.Name = "EText4"
        Me.EText4.Size = New System.Drawing.Size(240, 21)
        Me.EText4.TabIndex = 6
        Me.EText4.TableName = "find_paymentterm_nm"
        Me.EText4.Title = "Price Term 명"
        Me.EText4.TitleWidth = 98
        '
        'ECombo2
        '
        Me.ECombo2.Location = New System.Drawing.Point(364, 41)
        Me.ECombo2.Name = "ECombo2"
        Me.ECombo2.Size = New System.Drawing.Size(240, 21)
        Me.ECombo2.TabIndex = 7
        Me.ECombo2.Title = "사용여부"
        '
        'cs_nm
        '
        Me.cs_nm.Location = New System.Drawing.Point(558, 26)
        Me.cs_nm.Name = "cs_nm"
        Me.cs_nm.Size = New System.Drawing.Size(259, 21)
        Me.cs_nm.TabIndex = 17
        '
        'cs_cd
        '
        Me.cs_cd.Location = New System.Drawing.Point(462, 26)
        Me.cs_cd.Name = "cs_cd"
        Me.cs_cd.Size = New System.Drawing.Size(210, 21)
        Me.cs_cd.TabIndex = 16
        Me.cs_cd.Title = "거래처"
        Me.cs_cd.TitleWidth = 90
        '
        'pl_cd
        '
        Me.pl_cd.Location = New System.Drawing.Point(462, 55)
        Me.pl_cd.Name = "pl_cd"
        Me.pl_cd.Size = New System.Drawing.Size(210, 21)
        Me.pl_cd.TabIndex = 14
        Me.pl_cd.Title = "영업부서"
        Me.pl_cd.TitleWidth = 90
        '
        'pl_nm
        '
        Me.pl_nm.Location = New System.Drawing.Point(559, 55)
        Me.pl_nm.Name = "pl_nm"
        Me.pl_nm.Size = New System.Drawing.Size(259, 21)
        Me.pl_nm.TabIndex = 15
        '
        'fr_dt
        '
        Me.fr_dt.Location = New System.Drawing.Point(19, 26)
        Me.fr_dt.Name = "fr_dt"
        Me.fr_dt.Size = New System.Drawing.Size(210, 21)
        Me.fr_dt.TabIndex = 10
        Me.fr_dt.Title = "기간"
        Me.fr_dt.TitleWidth = 90
        '
        'to_dt
        '
        Me.to_dt.Location = New System.Drawing.Point(235, 26)
        Me.to_dt.Name = "to_dt"
        Me.to_dt.Size = New System.Drawing.Size(139, 21)
        Me.to_dt.TabIndex = 11
        Me.to_dt.Title = "~"
        Me.to_dt.TitleWidth = 20
        '
        'ps_cd
        '
        Me.ps_cd.Location = New System.Drawing.Point(19, 55)
        Me.ps_cd.Name = "ps_cd"
        Me.ps_cd.Size = New System.Drawing.Size(210, 21)
        Me.ps_cd.TabIndex = 12
        Me.ps_cd.Title = "영업담당자"
        Me.ps_cd.TitleWidth = 90
        '
        'ps_nm
        '
        Me.ps_nm.Location = New System.Drawing.Point(115, 55)
        Me.ps_nm.Name = "ps_nm"
        Me.ps_nm.Size = New System.Drawing.Size(259, 21)
        Me.ps_nm.TabIndex = 13
        '
        'WP_SA3033
        '
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "WP_SA3033"
        Me.Size = New System.Drawing.Size(1182, 611)
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
    Friend WithEvents g_multi As Frame7.eGrid
    Friend WithEvents EPanel2 As Frame7.ePanel
    Friend WithEvents EText3 As Frame7.eText
    Friend WithEvents EText4 As Frame7.eText
    Friend WithEvents ECombo2 As Frame7.eCombo
    Friend WithEvents cs_cd As Frame7.eText
    Friend WithEvents pl_cd As Frame7.eText
    Friend WithEvents pl_nm As Frame7.eText
    Friend WithEvents fr_dt As Frame7.eDate
    Friend WithEvents to_dt As Frame7.eDate
    Friend WithEvents ps_cd As Frame7.eText
    Friend WithEvents ps_nm As Frame7.eText
    Friend WithEvents cs_nm As Frame7.eText

End Class
