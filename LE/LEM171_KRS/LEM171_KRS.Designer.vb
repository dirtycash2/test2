﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LEM171_KRS
    Inherits Base7.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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
        Me.EPanel3 = New Frame7.ePanel()
        Me.cust_nm = New Frame7.eText()
        Me.cust_cd = New Frame7.eText()
        Me.btn_price = New DevExpress.XtraEditors.SimpleButton()
        Me.in_id = New Frame7.eText()
        Me.btn_stock = New DevExpress.XtraEditors.SimpleButton()
        Me.in_dept = New Frame7.eText()
        Me.in_dept_nm = New Frame7.eText()
        Me.in_nm = New Frame7.eText()
        Me.fac_cd = New Frame7.eCombo()
        Me.chk_stock = New Frame7.eCheck()
        Me.in_rid = New Frame7.eText()
        Me.mov_no = New Frame7.eText()
        Me.ent_bc = New Frame7.eCombo()
        Me.out_dt = New Frame7.eDate()
        Me.lot_chk = New Frame7.eCheck()
        Me.itm_chk = New Frame7.eCheck()
        Me.wh_cd = New Frame7.eCombo()
        Me.out_rid = New Frame7.eText()
        Me.out_nm = New Frame7.eText()
        Me.out_dept = New Frame7.eText()
        Me.out_dept_nm = New Frame7.eText()
        Me.rmks = New Frame7.eText()
        Me.mov_bc = New Frame7.eCombo()
        Me.EPanel2 = New Frame7.ePanel()
        Me.g10 = New Frame7.eGrid()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.EPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel3.SuspendLayout()
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.EPanel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.EPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1024, 516)
        Me.SplitContainer1.SplitterDistance = 127
        Me.SplitContainer1.TabIndex = 1
        '
        'EPanel3
        '
        Me.EPanel3.Controls.Add(Me.cust_nm)
        Me.EPanel3.Controls.Add(Me.cust_cd)
        Me.EPanel3.Controls.Add(Me.btn_price)
        Me.EPanel3.Controls.Add(Me.in_id)
        Me.EPanel3.Controls.Add(Me.btn_stock)
        Me.EPanel3.Controls.Add(Me.in_dept)
        Me.EPanel3.Controls.Add(Me.in_dept_nm)
        Me.EPanel3.Controls.Add(Me.in_nm)
        Me.EPanel3.Controls.Add(Me.fac_cd)
        Me.EPanel3.Controls.Add(Me.chk_stock)
        Me.EPanel3.Controls.Add(Me.in_rid)
        Me.EPanel3.Controls.Add(Me.mov_no)
        Me.EPanel3.Controls.Add(Me.ent_bc)
        Me.EPanel3.Controls.Add(Me.out_dt)
        Me.EPanel3.Controls.Add(Me.lot_chk)
        Me.EPanel3.Controls.Add(Me.itm_chk)
        Me.EPanel3.Controls.Add(Me.wh_cd)
        Me.EPanel3.Controls.Add(Me.out_rid)
        Me.EPanel3.Controls.Add(Me.out_nm)
        Me.EPanel3.Controls.Add(Me.out_dept)
        Me.EPanel3.Controls.Add(Me.out_dept_nm)
        Me.EPanel3.Controls.Add(Me.rmks)
        Me.EPanel3.Controls.Add(Me.mov_bc)
        Me.EPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel3.Location = New System.Drawing.Point(0, 0)
        Me.EPanel3.Name = "EPanel3"
        Me.EPanel3.Size = New System.Drawing.Size(1024, 127)
        Me.EPanel3.TabIndex = 2
        Me.EPanel3.Text = "     검색"
        '
        'cust_nm
        '
        Me.cust_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cust_nm.Location = New System.Drawing.Point(255, 76)
        Me.cust_nm.Name = "cust_nm"
        Me.cust_nm.Size = New System.Drawing.Size(249, 21)
        Me.cust_nm.TabIndex = 83
        Me.cust_nm.Title = "출고거래처명"
        Me.cust_nm.TitleWidth = 0
        '
        'cust_cd
        '
        Me.cust_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cust_cd.Location = New System.Drawing.Point(11, 76)
        Me.cust_cd.Name = "cust_cd"
        Me.cust_cd.Size = New System.Drawing.Size(240, 21)
        Me.cust_cd.TabIndex = 82
        Me.cust_cd.Title = "납품처"
        '
        'btn_price
        '
        Me.btn_price.Location = New System.Drawing.Point(772, 98)
        Me.btn_price.Name = "btn_price"
        Me.btn_price.Size = New System.Drawing.Size(120, 24)
        Me.btn_price.TabIndex = 84
        Me.btn_price.Text = "최신단가 적용"
        '
        'in_id
        '
        Me.in_id.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.in_id.Location = New System.Drawing.Point(424, 212)
        Me.in_id.Name = "in_id"
        Me.in_id.Size = New System.Drawing.Size(240, 21)
        Me.in_id.TabIndex = 79
        Me.in_id.Title = "입고담당"
        '
        'btn_stock
        '
        Me.btn_stock.Location = New System.Drawing.Point(772, 73)
        Me.btn_stock.Name = "btn_stock"
        Me.btn_stock.Size = New System.Drawing.Size(120, 24)
        Me.btn_stock.TabIndex = 84
        Me.btn_stock.Text = "창고재고 조회"
        '
        'in_dept
        '
        Me.in_dept.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.in_dept.Location = New System.Drawing.Point(424, 236)
        Me.in_dept.Name = "in_dept"
        Me.in_dept.Size = New System.Drawing.Size(240, 21)
        Me.in_dept.TabIndex = 78
        Me.in_dept.Title = "입고부서"
        '
        'in_dept_nm
        '
        Me.in_dept_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.in_dept_nm.Location = New System.Drawing.Point(668, 236)
        Me.in_dept_nm.Name = "in_dept_nm"
        Me.in_dept_nm.Size = New System.Drawing.Size(120, 21)
        Me.in_dept_nm.TabIndex = 77
        Me.in_dept_nm.Title = "출고번호"
        Me.in_dept_nm.TitleWidth = 0
        '
        'in_nm
        '
        Me.in_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.in_nm.Location = New System.Drawing.Point(668, 212)
        Me.in_nm.Name = "in_nm"
        Me.in_nm.Size = New System.Drawing.Size(120, 21)
        Me.in_nm.TabIndex = 75
        Me.in_nm.Title = "출고번호"
        Me.in_nm.TitleWidth = 0
        '
        'fac_cd
        '
        Me.fac_cd.Location = New System.Drawing.Point(264, 28)
        Me.fac_cd.Name = "fac_cd"
        Me.fac_cd.Size = New System.Drawing.Size(240, 21)
        Me.fac_cd.TabIndex = 57
        Me.fac_cd.Title = "기준공장"
        '
        'chk_stock
        '
        Me.chk_stock.Caption = ""
        Me.chk_stock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.chk_stock.Location = New System.Drawing.Point(772, 76)
        Me.chk_stock.Name = "chk_stock"
        Me.chk_stock.Size = New System.Drawing.Size(120, 21)
        Me.chk_stock.TabIndex = 85
        Me.chk_stock.Title = "재고조회"
        Me.chk_stock.TitleWidth = 40
        '
        'in_rid
        '
        Me.in_rid.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.in_rid.Location = New System.Drawing.Point(793, 212)
        Me.in_rid.Name = "in_rid"
        Me.in_rid.Size = New System.Drawing.Size(20, 21)
        Me.in_rid.TabIndex = 76
        Me.in_rid.Title = "출고번호"
        Me.in_rid.TitleWidth = 0
        '
        'mov_no
        '
        Me.mov_no.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.mov_no.Location = New System.Drawing.Point(11, 28)
        Me.mov_no.Name = "mov_no"
        Me.mov_no.Size = New System.Drawing.Size(240, 21)
        Me.mov_no.TabIndex = 59
        Me.mov_no.Title = "이동번호"
        '
        'ent_bc
        '
        Me.ent_bc.Location = New System.Drawing.Point(520, 76)
        Me.ent_bc.Name = "ent_bc"
        Me.ent_bc.Size = New System.Drawing.Size(240, 21)
        Me.ent_bc.TabIndex = 61
        Me.ent_bc.Title = "ent_bc"
        '
        'out_dt
        '
        Me.out_dt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.out_dt.Location = New System.Drawing.Point(11, 52)
        Me.out_dt.Name = "out_dt"
        Me.out_dt.Size = New System.Drawing.Size(240, 21)
        Me.out_dt.TabIndex = 58
        Me.out_dt.Title = "이동일자"
        '
        'lot_chk
        '
        Me.lot_chk.Caption = ""
        Me.lot_chk.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lot_chk.Location = New System.Drawing.Point(240, 236)
        Me.lot_chk.Name = "lot_chk"
        Me.lot_chk.Size = New System.Drawing.Size(172, 21)
        Me.lot_chk.TabIndex = 65
        Me.lot_chk.Title = "LOT전환 여부"
        '
        'itm_chk
        '
        Me.itm_chk.Caption = ""
        Me.itm_chk.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.itm_chk.Location = New System.Drawing.Point(240, 212)
        Me.itm_chk.Name = "itm_chk"
        Me.itm_chk.Size = New System.Drawing.Size(172, 21)
        Me.itm_chk.TabIndex = 64
        Me.itm_chk.Title = "품목전환 여부"
        '
        'wh_cd
        '
        Me.wh_cd.Location = New System.Drawing.Point(264, 52)
        Me.wh_cd.Name = "wh_cd"
        Me.wh_cd.Size = New System.Drawing.Size(240, 21)
        Me.wh_cd.TabIndex = 56
        Me.wh_cd.Title = "기준창고"
        '
        'out_rid
        '
        Me.out_rid.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.out_rid.Location = New System.Drawing.Point(692, 80)
        Me.out_rid.Name = "out_rid"
        Me.out_rid.Size = New System.Drawing.Size(52, 21)
        Me.out_rid.TabIndex = 74
        Me.out_rid.Title = "out_rid"
        '
        'out_nm
        '
        Me.out_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.out_nm.Location = New System.Drawing.Point(520, 52)
        Me.out_nm.Name = "out_nm"
        Me.out_nm.Size = New System.Drawing.Size(240, 21)
        Me.out_nm.TabIndex = 70
        Me.out_nm.Title = "out_nm"
        '
        'out_dept
        '
        Me.out_dept.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.out_dept.Location = New System.Drawing.Point(588, 84)
        Me.out_dept.Name = "out_dept"
        Me.out_dept.Size = New System.Drawing.Size(56, 21)
        Me.out_dept.TabIndex = 73
        Me.out_dept.Title = "out_dept"
        '
        'out_dept_nm
        '
        Me.out_dept_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.out_dept_nm.Location = New System.Drawing.Point(520, 28)
        Me.out_dept_nm.Name = "out_dept_nm"
        Me.out_dept_nm.Size = New System.Drawing.Size(240, 21)
        Me.out_dept_nm.TabIndex = 72
        Me.out_dept_nm.Title = "out_dept_nm"
        '
        'rmks
        '
        Me.rmks.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rmks.Location = New System.Drawing.Point(11, 100)
        Me.rmks.Name = "rmks"
        Me.rmks.Size = New System.Drawing.Size(749, 21)
        Me.rmks.TabIndex = 69
        Me.rmks.Title = "비고"
        '
        'mov_bc
        '
        Me.mov_bc.Location = New System.Drawing.Point(519, 76)
        Me.mov_bc.Name = "mov_bc"
        Me.mov_bc.Size = New System.Drawing.Size(241, 21)
        Me.mov_bc.TabIndex = 68
        Me.mov_bc.Title = "이동구분"
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.g10)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(1024, 385)
        Me.EPanel2.TabIndex = 1
        Me.EPanel2.Text = "     품목전환"
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(1020, 360)
        Me.g10.TabIndex = 2
        '
        'LEM171_KRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "LEM171_KRS"
        Me.Size = New System.Drawing.Size(1184, 690)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.EPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel3.ResumeLayout(False)
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel3 As Frame7.ePanel
    Friend WithEvents in_id As Frame7.eText
    Friend WithEvents in_dept As Frame7.eText
    Friend WithEvents in_dept_nm As Frame7.eText
    Friend WithEvents in_nm As Frame7.eText
    Friend WithEvents fac_cd As Frame7.eCombo
    Friend WithEvents ent_bc As Frame7.eCombo
    Friend WithEvents in_rid As Frame7.eText
    Friend WithEvents mov_no As Frame7.eText
    Friend WithEvents out_dt As Frame7.eDate
    Friend WithEvents lot_chk As Frame7.eCheck
    Friend WithEvents itm_chk As Frame7.eCheck
    Friend WithEvents out_nm As Frame7.eText
    Friend WithEvents wh_cd As Frame7.eCombo
    Friend WithEvents out_dept_nm As Frame7.eText
    Friend WithEvents out_rid As Frame7.eText
    Friend WithEvents out_dept As Frame7.eText
    Friend WithEvents rmks As Frame7.eText
    Friend WithEvents mov_bc As Frame7.eCombo
    Friend WithEvents EPanel2 As Frame7.ePanel
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents cust_nm As Frame7.eText
    Friend WithEvents cust_cd As Frame7.eText
    Friend WithEvents btn_price As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents chk_stock As Frame7.eCheck
    Friend WithEvents btn_stock As DevExpress.XtraEditors.SimpleButton

End Class
