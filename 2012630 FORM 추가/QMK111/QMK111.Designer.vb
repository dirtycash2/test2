﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QMK111
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
        Me.f_dept_cd = New Frame7.eText()
        Me.f_mc_nm = New Frame7.eText()
        Me.std_year = New Frame7.eDate()
        Me.f_fac_cd = New Frame7.eCombo()
        Me.f_dept_nm = New Frame7.eText()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.EPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1234, 581)
        Me.SplitContainer1.SplitterDistance = 82
        Me.SplitContainer1.TabIndex = 0
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.f_dept_cd)
        Me.EPanel1.Controls.Add(Me.f_mc_nm)
        Me.EPanel1.Controls.Add(Me.std_year)
        Me.EPanel1.Controls.Add(Me.f_fac_cd)
        Me.EPanel1.Controls.Add(Me.f_dept_nm)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(1234, 82)
        Me.EPanel1.TabIndex = 0
        Me.EPanel1.Text = "     검색"
        '
        'f_dept_cd
        '
        Me.f_dept_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.f_dept_cd.Location = New System.Drawing.Point(260, 28)
        Me.f_dept_cd.Name = "f_dept_cd"
        Me.f_dept_cd.Size = New System.Drawing.Size(240, 21)
        Me.f_dept_cd.TabIndex = 2
        '
        'f_mc_nm
        '
        Me.f_mc_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.f_mc_nm.Location = New System.Drawing.Point(260, 52)
        Me.f_mc_nm.Name = "f_mc_nm"
        Me.f_mc_nm.Size = New System.Drawing.Size(240, 21)
        Me.f_mc_nm.TabIndex = 4
        '
        'std_year
        '
        Me.std_year.Location = New System.Drawing.Point(8, 28)
        Me.std_year.Name = "std_year"
        Me.std_year.Size = New System.Drawing.Size(240, 21)
        Me.std_year.TabIndex = 5
        '
        'f_fac_cd
        '
        Me.f_fac_cd.Location = New System.Drawing.Point(8, 52)
        Me.f_fac_cd.Name = "f_fac_cd"
        Me.f_fac_cd.Size = New System.Drawing.Size(240, 21)
        Me.f_fac_cd.TabIndex = 1
        '
        'f_dept_nm
        '
        Me.f_dept_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.f_dept_nm.Location = New System.Drawing.Point(384, 28)
        Me.f_dept_nm.Name = "f_dept_nm"
        Me.f_dept_nm.Size = New System.Drawing.Size(240, 21)
        Me.f_dept_nm.TabIndex = 3
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.g10)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(1234, 495)
        Me.EPanel2.TabIndex = 0
        Me.EPanel2.Text = "     계측기등록현황"
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RecordNavigator = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(1230, 470)
        Me.g10.TabIndex = 2
        '
        'QMK111
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "QMK111"
        Me.Size = New System.Drawing.Size(1234, 581)
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
    Friend WithEvents f_mc_nm As Frame7.eText
    Friend WithEvents f_fac_cd As Frame7.eCombo
    Friend WithEvents f_dept_cd As Frame7.eText
    Friend WithEvents f_dept_nm As Frame7.eText
    Friend WithEvents std_year As Frame7.eDate

End Class
