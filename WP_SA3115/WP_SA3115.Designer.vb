﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WP_SA3115
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
        Me.OD_DT2 = New Frame7.ePanel()
        Me.ps_cd = New Frame7.eText()
        Me.ps_nm = New Frame7.eText()
        Me.From_dt = New Frame7.eDate()
        Me.to_dt = New Frame7.eDate()
        Me.nm_cd = New Frame7.eText()
        Me.nm_nm = New Frame7.eText()
        Me.EPanel2 = New Frame7.ePanel()
        Me.g10 = New Frame7.eGrid()
        Me.type = New Frame7.eCheck()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.OD_DT2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OD_DT2.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.OD_DT2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.EPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1163, 588)
        Me.SplitContainer1.SplitterDistance = 116
        Me.SplitContainer1.TabIndex = 0
        '
        'OD_DT2
        '
        Me.OD_DT2.Controls.Add(Me.type)
        Me.OD_DT2.Controls.Add(Me.ps_cd)
        Me.OD_DT2.Controls.Add(Me.ps_nm)
        Me.OD_DT2.Controls.Add(Me.From_dt)
        Me.OD_DT2.Controls.Add(Me.to_dt)
        Me.OD_DT2.Controls.Add(Me.nm_cd)
        Me.OD_DT2.Controls.Add(Me.nm_nm)
        Me.OD_DT2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.OD_DT2.Location = New System.Drawing.Point(0, 0)
        Me.OD_DT2.Name = "OD_DT2"
        Me.OD_DT2.Size = New System.Drawing.Size(1163, 116)
        Me.OD_DT2.TabIndex = 0
        Me.OD_DT2.Text = "     검색"
        '
        'ps_cd
        '
        Me.ps_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ps_cd.Location = New System.Drawing.Point(743, 40)
        Me.ps_cd.Name = "ps_cd"
        Me.ps_cd.Size = New System.Drawing.Size(160, 21)
        Me.ps_cd.TabIndex = 63
        Me.ps_cd.Title = "제품명코드"
        Me.ps_cd.TitleWidth = 70
        '
        'ps_nm
        '
        Me.ps_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.ps_nm.Location = New System.Drawing.Point(840, 40)
        Me.ps_nm.Name = "ps_nm"
        Me.ps_nm.Size = New System.Drawing.Size(223, 21)
        Me.ps_nm.TabIndex = 64
        Me.ps_nm.Title = "제품명코드"
        Me.ps_nm.TitleWidth = 70
        '
        'From_dt
        '
        Me.From_dt.Location = New System.Drawing.Point(17, 40)
        Me.From_dt.Name = "From_dt"
        Me.From_dt.Size = New System.Drawing.Size(180, 21)
        Me.From_dt.TabIndex = 2
        Me.From_dt.Title = "작성일자"
        Me.From_dt.TitleWidth = 70
        '
        'to_dt
        '
        Me.to_dt.Location = New System.Drawing.Point(165, 40)
        Me.to_dt.Name = "to_dt"
        Me.to_dt.Size = New System.Drawing.Size(180, 21)
        Me.to_dt.TabIndex = 3
        Me.to_dt.Title = "           ~ "
        Me.to_dt.TitleWidth = 70
        '
        'nm_cd
        '
        Me.nm_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.nm_cd.Location = New System.Drawing.Point(359, 40)
        Me.nm_cd.Name = "nm_cd"
        Me.nm_cd.Size = New System.Drawing.Size(187, 21)
        Me.nm_cd.TabIndex = 4
        Me.nm_cd.Title = "제품명코드"
        Me.nm_cd.TitleWidth = 70
        '
        'nm_nm
        '
        Me.nm_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.nm_nm.Location = New System.Drawing.Point(483, 40)
        Me.nm_nm.Name = "nm_nm"
        Me.nm_nm.Size = New System.Drawing.Size(223, 21)
        Me.nm_nm.TabIndex = 62
        Me.nm_nm.Title = "제품명코드"
        Me.nm_nm.TitleWidth = 70
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.g10)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(1163, 468)
        Me.EPanel2.TabIndex = 0
        Me.EPanel2.Text = "     기초 데이터 현황"
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RecordNavigator = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(1159, 443)
        Me.g10.TabIndex = 2
        '
        'type
        '
        Me.type.Caption = ""
        Me.type.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.type.Location = New System.Drawing.Point(17, 80)
        Me.type.Name = "type"
        Me.type.Size = New System.Drawing.Size(110, 21)
        Me.type.TabIndex = 70
        Me.type.Title = "금액 초회 "
        Me.type.TitleWidth = 70
        '
        'WP_SA3115
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "WP_SA3115"
        Me.Size = New System.Drawing.Size(1163, 588)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.OD_DT2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OD_DT2.ResumeLayout(False)
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents OD_DT2 As Frame7.ePanel
    Friend WithEvents EPanel2 As Frame7.ePanel
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents to_dt As Frame7.eDate
    Friend WithEvents From_dt As Frame7.eDate
    Friend WithEvents nm_cd As Frame7.eText
    Friend WithEvents ps_cd As Frame7.eText
    Friend WithEvents ps_nm As Frame7.eText
    Friend WithEvents nm_nm As Frame7.eText
    Friend WithEvents type As Frame7.eCheck

End Class