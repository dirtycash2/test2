﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAC800
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
        Me.iss2_bc = New Frame7.eCheckCombo()
        Me.cmdproc = New DevExpress.XtraEditors.SimpleButton()
        Me.cmdchk_fasle = New DevExpress.XtraEditors.SimpleButton()
        Me.cust_nm = New Frame7.eText()
        Me.cust_cd = New Frame7.eText()
        Me.cmdchk_true = New DevExpress.XtraEditors.SimpleButton()
        Me.optiss_bc = New DevExpress.XtraEditors.RadioGroup()
        Me.tax_kd = New Frame7.eCombo()
        Me.tax_dtt = New Frame7.eDate()
        Me.bs_cd = New Frame7.eCombo()
        Me.tax_dtf = New Frame7.eDate()
        Me.tax_bc = New Frame7.eCheckCombo()
        Me.g10 = New Frame7.eGrid()
        Me.iss_bc = New Frame7.eText()
        Me.iss_ok = New Frame7.eCheck()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
        CType(Me.optiss_bc.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.g10)
        Me.SplitContainer1.Size = New System.Drawing.Size(1224, 523)
        Me.SplitContainer1.SplitterDistance = 101
        Me.SplitContainer1.TabIndex = 1
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.iss2_bc)
        Me.EPanel1.Controls.Add(Me.cmdproc)
        Me.EPanel1.Controls.Add(Me.iss_ok)
        Me.EPanel1.Controls.Add(Me.cmdchk_fasle)
        Me.EPanel1.Controls.Add(Me.cust_nm)
        Me.EPanel1.Controls.Add(Me.iss_bc)
        Me.EPanel1.Controls.Add(Me.cust_cd)
        Me.EPanel1.Controls.Add(Me.cmdchk_true)
        Me.EPanel1.Controls.Add(Me.optiss_bc)
        Me.EPanel1.Controls.Add(Me.tax_kd)
        Me.EPanel1.Controls.Add(Me.tax_dtt)
        Me.EPanel1.Controls.Add(Me.bs_cd)
        Me.EPanel1.Controls.Add(Me.tax_dtf)
        Me.EPanel1.Controls.Add(Me.tax_bc)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(1224, 101)
        Me.EPanel1.TabIndex = 0
        Me.EPanel1.Text = "     검색조건"
        '
        'iss2_bc
        '
        Me.iss2_bc.Location = New System.Drawing.Point(648, 72)
        Me.iss2_bc.Name = "iss2_bc"
        Me.iss2_bc.Size = New System.Drawing.Size(240, 21)
        Me.iss2_bc.TabIndex = 15
        '
        'cmdproc
        '
        Me.cmdproc.Location = New System.Drawing.Point(152, 72)
        Me.cmdproc.Name = "cmdproc"
        Me.cmdproc.Size = New System.Drawing.Size(224, 23)
        Me.cmdproc.TabIndex = 12
        Me.cmdproc.Text = "Smart Bill 전자세금계산서 처리"
        '
        'cmdchk_fasle
        '
        Me.cmdchk_fasle.Location = New System.Drawing.Point(76, 72)
        Me.cmdchk_fasle.Name = "cmdchk_fasle"
        Me.cmdchk_fasle.Size = New System.Drawing.Size(75, 23)
        Me.cmdchk_fasle.TabIndex = 11
        Me.cmdchk_fasle.Text = "전체취소"
        '
        'cust_nm
        '
        Me.cust_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cust_nm.Location = New System.Drawing.Point(632, 48)
        Me.cust_nm.Name = "cust_nm"
        Me.cust_nm.Size = New System.Drawing.Size(256, 21)
        Me.cust_nm.TabIndex = 7
        Me.cust_nm.TitleWidth = 0
        '
        'cust_cd
        '
        Me.cust_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cust_cd.Location = New System.Drawing.Point(392, 48)
        Me.cust_cd.Name = "cust_cd"
        Me.cust_cd.Size = New System.Drawing.Size(240, 21)
        Me.cust_cd.TabIndex = 6
        '
        'cmdchk_true
        '
        Me.cmdchk_true.Location = New System.Drawing.Point(0, 72)
        Me.cmdchk_true.Name = "cmdchk_true"
        Me.cmdchk_true.Size = New System.Drawing.Size(75, 23)
        Me.cmdchk_true.TabIndex = 10
        Me.cmdchk_true.Text = "전체선택"
        '
        'optiss_bc
        '
        Me.optiss_bc.EditValue = "%"
        Me.optiss_bc.Location = New System.Drawing.Point(388, 72)
        Me.optiss_bc.Name = "optiss_bc"
        Me.optiss_bc.Properties.AccessibleDescription = ""
        Me.optiss_bc.Properties.Columns = 3
        Me.optiss_bc.Properties.Items.AddRange(New DevExpress.XtraEditors.Controls.RadioGroupItem() {New DevExpress.XtraEditors.Controls.RadioGroupItem("FA620300", "수기"), New DevExpress.XtraEditors.Controls.RadioGroupItem("FA620100", "전자"), New DevExpress.XtraEditors.Controls.RadioGroupItem("%", "전체")})
        Me.optiss_bc.Size = New System.Drawing.Size(244, 24)
        Me.optiss_bc.TabIndex = 9
        '
        'tax_kd
        '
        Me.tax_kd.Location = New System.Drawing.Point(392, 24)
        Me.tax_kd.Name = "tax_kd"
        Me.tax_kd.Size = New System.Drawing.Size(240, 21)
        Me.tax_kd.TabIndex = 5
        '
        'tax_dtt
        '
        Me.tax_dtt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tax_dtt.Location = New System.Drawing.Point(236, 48)
        Me.tax_dtt.Name = "tax_dtt"
        Me.tax_dtt.Size = New System.Drawing.Size(140, 21)
        Me.tax_dtt.TabIndex = 4
        Me.tax_dtt.Title = "   ~"
        Me.tax_dtt.TitleWidth = 30
        '
        'bs_cd
        '
        Me.bs_cd.Location = New System.Drawing.Point(4, 24)
        Me.bs_cd.Name = "bs_cd"
        Me.bs_cd.Size = New System.Drawing.Size(372, 21)
        Me.bs_cd.TabIndex = 2
        '
        'tax_dtf
        '
        Me.tax_dtf.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tax_dtf.Location = New System.Drawing.Point(4, 48)
        Me.tax_dtf.Name = "tax_dtf"
        Me.tax_dtf.Size = New System.Drawing.Size(228, 21)
        Me.tax_dtf.TabIndex = 3
        '
        'tax_bc
        '
        Me.tax_bc.Location = New System.Drawing.Point(648, 24)
        Me.tax_bc.Name = "tax_bc"
        Me.tax_bc.Size = New System.Drawing.Size(240, 21)
        Me.tax_bc.TabIndex = 14
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(0, 0)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(1224, 418)
        Me.g10.TabIndex = 0
        '
        'iss_bc
        '
        Me.iss_bc.Location = New System.Drawing.Point(392, 128)
        Me.iss_bc.Name = "iss_bc"
        Me.iss_bc.Size = New System.Drawing.Size(240, 21)
        Me.iss_bc.TabIndex = 16
        '
        'iss_ok
        '
        Me.iss_ok.Caption = ""
        Me.iss_ok.Location = New System.Drawing.Point(904, 28)
        Me.iss_ok.Name = "iss_ok"
        Me.iss_ok.Size = New System.Drawing.Size(240, 21)
        Me.iss_ok.TabIndex = 17
        Me.iss_ok.Title = "승인여부"
        '
        'FAC800
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FAC800"
        Me.Size = New System.Drawing.Size(1224, 523)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel1.ResumeLayout(False)
        CType(Me.optiss_bc.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel1 As Frame7.ePanel
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents optiss_bc As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents cust_nm As Frame7.eText
    Friend WithEvents cust_cd As Frame7.eText
    Friend WithEvents tax_kd As Frame7.eCombo
    Friend WithEvents tax_dtt As Frame7.eDate
    Friend WithEvents bs_cd As Frame7.eCombo
    Friend WithEvents tax_dtf As Frame7.eDate
    Friend WithEvents cmdproc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdchk_fasle As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdchk_true As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents tax_bc As Frame7.eCheckCombo
    Friend WithEvents iss2_bc As Frame7.eCheckCombo
    Friend WithEvents iss_ok As Frame7.eCheck
    Friend WithEvents iss_bc As Frame7.eText

End Class
