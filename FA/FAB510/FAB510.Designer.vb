﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAB510
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
        Me.div_cd = New Frame7.eCombo()
        Me.btn_jump = New DevExpress.XtraEditors.SimpleButton()
        Me.fr_dt = New Frame7.eDate()
        Me.mng_no = New Frame7.eCombo()
        Me.to_dt = New Frame7.eDate()
        Me.mng_val = New Frame7.eText()
        Me.g10 = New Frame7.eGrid()
        Me.acc_cd = New Frame7.eCheckCombo()
        Me.to2_dt = New Frame7.eDate()
        Me.fr2_dt = New Frame7.eDate()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.g10)
        Me.SplitContainer1.Size = New System.Drawing.Size(1020, 360)
        Me.SplitContainer1.SplitterDistance = 129
        Me.SplitContainer1.TabIndex = 0
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.co_cd)
        Me.EPanel1.Controls.Add(Me.div_cd)
        Me.EPanel1.Controls.Add(Me.fr_dt)
        Me.EPanel1.Controls.Add(Me.btn_jump)
        Me.EPanel1.Controls.Add(Me.acc_cd)
        Me.EPanel1.Controls.Add(Me.to2_dt)
        Me.EPanel1.Controls.Add(Me.to_dt)
        Me.EPanel1.Controls.Add(Me.mng_val)
        Me.EPanel1.Controls.Add(Me.mng_no)
        Me.EPanel1.Controls.Add(Me.fr2_dt)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(1020, 129)
        Me.EPanel1.TabIndex = 0
        Me.EPanel1.Text = "     검색"
        '
        'co_cd
        '
        Me.co_cd.Location = New System.Drawing.Point(12, 28)
        Me.co_cd.Name = "co_cd"
        Me.co_cd.Size = New System.Drawing.Size(240, 21)
        Me.co_cd.TabIndex = 2
        Me.co_cd.Title = "co_cd"
        '
        'div_cd
        '
        Me.div_cd.Location = New System.Drawing.Point(12, 52)
        Me.div_cd.Name = "div_cd"
        Me.div_cd.Size = New System.Drawing.Size(240, 21)
        Me.div_cd.TabIndex = 2
        Me.div_cd.Title = "div_cd"
        '
        'btn_jump
        '
        Me.btn_jump.Location = New System.Drawing.Point(560, 100)
        Me.btn_jump.Name = "btn_jump"
        Me.btn_jump.Size = New System.Drawing.Size(120, 24)
        Me.btn_jump.TabIndex = 12
        Me.btn_jump.Text = "반제처리"
        '
        'fr_dt
        '
        Me.fr_dt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.fr_dt.Location = New System.Drawing.Point(12, 76)
        Me.fr_dt.Name = "fr_dt"
        Me.fr_dt.Size = New System.Drawing.Size(240, 21)
        Me.fr_dt.TabIndex = 11
        Me.fr_dt.Title = "fr_dt"
        '
        'mng_no
        '
        Me.mng_no.Location = New System.Drawing.Point(404, 52)
        Me.mng_no.Name = "mng_no"
        Me.mng_no.Size = New System.Drawing.Size(276, 21)
        Me.mng_no.TabIndex = 2
        Me.mng_no.Title = "mng_no"
        '
        'to_dt
        '
        Me.to_dt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.to_dt.Location = New System.Drawing.Point(256, 76)
        Me.to_dt.Name = "to_dt"
        Me.to_dt.Size = New System.Drawing.Size(120, 21)
        Me.to_dt.TabIndex = 11
        Me.to_dt.TitleWidth = 0
        '
        'mng_val
        '
        Me.mng_val.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.mng_val.Location = New System.Drawing.Point(404, 76)
        Me.mng_val.Name = "mng_val"
        Me.mng_val.Size = New System.Drawing.Size(276, 21)
        Me.mng_val.TabIndex = 5
        Me.mng_val.Title = "mng_val"
        Me.mng_val.Visible = False
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(0, 0)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RecordNavigator = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(1020, 227)
        Me.g10.TabIndex = 3
        '
        'acc_cd
        '
        Me.acc_cd.Location = New System.Drawing.Point(276, 28)
        Me.acc_cd.Name = "acc_cd"
        Me.acc_cd.Size = New System.Drawing.Size(404, 21)
        Me.acc_cd.TabIndex = 13
        '
        'to2_dt
        '
        Me.to2_dt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.to2_dt.Location = New System.Drawing.Point(256, 100)
        Me.to2_dt.Name = "to2_dt"
        Me.to2_dt.Size = New System.Drawing.Size(120, 21)
        Me.to2_dt.TabIndex = 11
        Me.to2_dt.TitleWidth = 0
        '
        'fr2_dt
        '
        Me.fr2_dt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.fr2_dt.Location = New System.Drawing.Point(12, 100)
        Me.fr2_dt.Name = "fr2_dt"
        Me.fr2_dt.Size = New System.Drawing.Size(240, 21)
        Me.fr2_dt.TabIndex = 11
        Me.fr2_dt.Title = "fr_dt"
        '
        'FAB510
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FAB510"
        Me.Size = New System.Drawing.Size(1034, 382)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel1 As Frame7.ePanel
    Friend WithEvents co_cd As Frame7.eCombo
    Friend WithEvents fr_dt As Frame7.eDate
    Friend WithEvents to_dt As Frame7.eDate
    Friend WithEvents div_cd As Frame7.eCombo
    Friend WithEvents mng_no As Frame7.eCombo
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents mng_val As Frame7.eText
    Friend WithEvents btn_jump As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents acc_cd As Frame7.eCheckCombo
    Friend WithEvents to2_dt As Frame7.eDate
    Friend WithEvents fr2_dt As Frame7.eDate

End Class
