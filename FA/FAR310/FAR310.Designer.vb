﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAR310
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
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.EPanel1 = New Frame7.ePanel()
        Me.doc_ty = New Frame7.eCombo()
        Me.dept_cd = New Frame7.eText()
        Me.co_cd = New Frame7.eCombo()
        Me.div_cd = New Frame7.eCombo()
        Me.fr_dt = New Frame7.eDate()
        Me.dept_nm = New Frame7.eText()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.EPanel2 = New Frame7.ePanel()
        Me.btn_doc = New DevExpress.XtraEditors.SimpleButton()
        Me.doc_no = New Frame7.eText()
        Me.btn_open = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_delete = New DevExpress.XtraEditors.SimpleButton()
        Me.base_dt = New Frame7.eDate()
        Me.EPanel8 = New Frame7.ePanel()
        Me.btn_doc1 = New DevExpress.XtraEditors.SimpleButton()
        Me.y_doc_no = New Frame7.eText()
        Me.btn_open1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btn_delete1 = New DevExpress.XtraEditors.SimpleButton()
        Me.y_base_dt = New Frame7.eDate()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.EPanel3 = New Frame7.ePanel()
        Me.g10 = New Frame7.eGrid()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.EPanel4 = New Frame7.ePanel()
        Me.g20 = New Frame7.eGrid()
        Me.EPanel5 = New Frame7.ePanel()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.EPanel6 = New Frame7.ePanel()
        Me.g30 = New Frame7.eGrid()
        Me.EPanel7 = New Frame7.ePanel()
        Me.g40 = New Frame7.eGrid()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel2.SuspendLayout()
        CType(Me.EPanel8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel8.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.EPanel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel3.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.EPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel4.SuspendLayout()
        CType(Me.EPanel5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        CType(Me.EPanel6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel6.SuspendLayout()
        CType(Me.EPanel7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel7.SuspendLayout()
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
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Size = New System.Drawing.Size(1150, 690)
        Me.SplitContainer1.SplitterDistance = 105
        Me.SplitContainer1.TabIndex = 2
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.EPanel1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer6)
        Me.SplitContainer2.Size = New System.Drawing.Size(1150, 105)
        Me.SplitContainer2.SplitterDistance = 417
        Me.SplitContainer2.TabIndex = 0
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.doc_ty)
        Me.EPanel1.Controls.Add(Me.dept_cd)
        Me.EPanel1.Controls.Add(Me.co_cd)
        Me.EPanel1.Controls.Add(Me.div_cd)
        Me.EPanel1.Controls.Add(Me.fr_dt)
        Me.EPanel1.Controls.Add(Me.dept_nm)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(417, 105)
        Me.EPanel1.TabIndex = 2
        Me.EPanel1.Text = "     검색"
        '
        'doc_ty
        '
        Me.doc_ty.Location = New System.Drawing.Point(212, 27)
        Me.doc_ty.Name = "doc_ty"
        Me.doc_ty.Size = New System.Drawing.Size(181, 21)
        Me.doc_ty.TabIndex = 7
        Me.doc_ty.Title = "구분"
        Me.doc_ty.TitleWidth = 60
        '
        'dept_cd
        '
        Me.dept_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dept_cd.Location = New System.Drawing.Point(212, 50)
        Me.dept_cd.Name = "dept_cd"
        Me.dept_cd.Size = New System.Drawing.Size(183, 21)
        Me.dept_cd.TabIndex = 6
        Me.dept_cd.Title = "부서코드"
        Me.dept_cd.TitleWidth = 60
        '
        'co_cd
        '
        Me.co_cd.Location = New System.Drawing.Point(14, 27)
        Me.co_cd.Name = "co_cd"
        Me.co_cd.Size = New System.Drawing.Size(181, 21)
        Me.co_cd.TabIndex = 3
        Me.co_cd.Title = "법인"
        Me.co_cd.TitleWidth = 60
        '
        'div_cd
        '
        Me.div_cd.Location = New System.Drawing.Point(14, 50)
        Me.div_cd.Name = "div_cd"
        Me.div_cd.Size = New System.Drawing.Size(181, 21)
        Me.div_cd.TabIndex = 3
        Me.div_cd.Title = "회계단위"
        Me.div_cd.TitleWidth = 60
        '
        'fr_dt
        '
        Me.fr_dt.Format = "yyyy-MM"
        Me.fr_dt.Location = New System.Drawing.Point(14, 74)
        Me.fr_dt.Name = "fr_dt"
        Me.fr_dt.Size = New System.Drawing.Size(181, 21)
        Me.fr_dt.TabIndex = 4
        Me.fr_dt.Title = "기준년월"
        Me.fr_dt.TitleWidth = 60
        '
        'dept_nm
        '
        Me.dept_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dept_nm.Location = New System.Drawing.Point(212, 74)
        Me.dept_nm.Name = "dept_nm"
        Me.dept_nm.Size = New System.Drawing.Size(183, 21)
        Me.dept_nm.TabIndex = 6
        Me.dept_nm.Title = "부서명"
        Me.dept_nm.TitleWidth = 60
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.EPanel2)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.EPanel8)
        Me.SplitContainer6.Size = New System.Drawing.Size(729, 105)
        Me.SplitContainer6.SplitterDistance = 362
        Me.SplitContainer6.TabIndex = 0
        '
        'EPanel2
        '
        Me.EPanel2.Controls.Add(Me.btn_doc)
        Me.EPanel2.Controls.Add(Me.doc_no)
        Me.EPanel2.Controls.Add(Me.btn_open)
        Me.EPanel2.Controls.Add(Me.btn_delete)
        Me.EPanel2.Controls.Add(Me.base_dt)
        Me.EPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel2.Location = New System.Drawing.Point(0, 0)
        Me.EPanel2.Name = "EPanel2"
        Me.EPanel2.Size = New System.Drawing.Size(362, 105)
        Me.EPanel2.TabIndex = 1
        Me.EPanel2.Text = "     제조 계정 대채"
        '
        'btn_doc
        '
        Me.btn_doc.Location = New System.Drawing.Point(251, 26)
        Me.btn_doc.Name = "btn_doc"
        Me.btn_doc.Size = New System.Drawing.Size(84, 24)
        Me.btn_doc.TabIndex = 38
        Me.btn_doc.Text = "전표생성"
        '
        'doc_no
        '
        Me.doc_no.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.doc_no.Location = New System.Drawing.Point(8, 51)
        Me.doc_no.Name = "doc_no"
        Me.doc_no.Size = New System.Drawing.Size(240, 21)
        Me.doc_no.TabIndex = 7
        Me.doc_no.Title = "전표번호"
        '
        'btn_open
        '
        Me.btn_open.Location = New System.Drawing.Point(251, 51)
        Me.btn_open.Name = "btn_open"
        Me.btn_open.Size = New System.Drawing.Size(84, 24)
        Me.btn_open.TabIndex = 36
        Me.btn_open.Text = "전표보기"
        '
        'btn_delete
        '
        Me.btn_delete.Location = New System.Drawing.Point(251, 76)
        Me.btn_delete.Name = "btn_delete"
        Me.btn_delete.Size = New System.Drawing.Size(84, 24)
        Me.btn_delete.TabIndex = 37
        Me.btn_delete.Text = "전표삭제"
        '
        'base_dt
        '
        Me.base_dt.Location = New System.Drawing.Point(8, 27)
        Me.base_dt.Name = "base_dt"
        Me.base_dt.Size = New System.Drawing.Size(240, 21)
        Me.base_dt.TabIndex = 5
        Me.base_dt.Title = "기준일자"
        '
        'EPanel8
        '
        Me.EPanel8.Controls.Add(Me.btn_doc1)
        Me.EPanel8.Controls.Add(Me.y_doc_no)
        Me.EPanel8.Controls.Add(Me.btn_open1)
        Me.EPanel8.Controls.Add(Me.btn_delete1)
        Me.EPanel8.Controls.Add(Me.y_base_dt)
        Me.EPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel8.Location = New System.Drawing.Point(0, 0)
        Me.EPanel8.Name = "EPanel8"
        Me.EPanel8.Size = New System.Drawing.Size(363, 105)
        Me.EPanel8.TabIndex = 2
        Me.EPanel8.Text = "     년계정 대체"
        '
        'btn_doc1
        '
        Me.btn_doc1.Location = New System.Drawing.Point(251, 26)
        Me.btn_doc1.Name = "btn_doc1"
        Me.btn_doc1.Size = New System.Drawing.Size(84, 24)
        Me.btn_doc1.TabIndex = 38
        Me.btn_doc1.Text = "전표생성"
        '
        'y_doc_no
        '
        Me.y_doc_no.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.y_doc_no.Location = New System.Drawing.Point(8, 51)
        Me.y_doc_no.Name = "y_doc_no"
        Me.y_doc_no.Size = New System.Drawing.Size(240, 21)
        Me.y_doc_no.TabIndex = 7
        Me.y_doc_no.Title = "전표번호"
        '
        'btn_open1
        '
        Me.btn_open1.Location = New System.Drawing.Point(251, 51)
        Me.btn_open1.Name = "btn_open1"
        Me.btn_open1.Size = New System.Drawing.Size(84, 24)
        Me.btn_open1.TabIndex = 36
        Me.btn_open1.Text = "전표보기"
        '
        'btn_delete1
        '
        Me.btn_delete1.Location = New System.Drawing.Point(251, 76)
        Me.btn_delete1.Name = "btn_delete1"
        Me.btn_delete1.Size = New System.Drawing.Size(84, 24)
        Me.btn_delete1.TabIndex = 37
        Me.btn_delete1.Text = "전표삭제"
        '
        'y_base_dt
        '
        Me.y_base_dt.Location = New System.Drawing.Point(8, 27)
        Me.y_base_dt.Name = "y_base_dt"
        Me.y_base_dt.Size = New System.Drawing.Size(240, 21)
        Me.y_base_dt.TabIndex = 5
        Me.y_base_dt.Title = "기준일자"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.EPanel3)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer3.Size = New System.Drawing.Size(1150, 581)
        Me.SplitContainer3.SplitterDistance = 417
        Me.SplitContainer3.TabIndex = 0
        '
        'EPanel3
        '
        Me.EPanel3.Controls.Add(Me.g10)
        Me.EPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel3.Location = New System.Drawing.Point(0, 0)
        Me.EPanel3.Name = "EPanel3"
        Me.EPanel3.Size = New System.Drawing.Size(417, 581)
        Me.EPanel3.TabIndex = 0
        Me.EPanel3.Text = "     대상선택"
        '
        'g10
        '
        Me.g10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g10.Location = New System.Drawing.Point(2, 23)
        Me.g10.Name = "g10"
        Me.g10.ReadOnly = False
        Me.g10.RowHeight = -1
        Me.g10.Size = New System.Drawing.Size(413, 556)
        Me.g10.TabIndex = 2
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.EPanel4)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer5)
        Me.SplitContainer4.Size = New System.Drawing.Size(729, 581)
        Me.SplitContainer4.SplitterDistance = 107
        Me.SplitContainer4.TabIndex = 0
        '
        'EPanel4
        '
        Me.EPanel4.Controls.Add(Me.g20)
        Me.EPanel4.Controls.Add(Me.EPanel5)
        Me.EPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel4.Location = New System.Drawing.Point(0, 0)
        Me.EPanel4.Name = "EPanel4"
        Me.EPanel4.Size = New System.Drawing.Size(729, 107)
        Me.EPanel4.TabIndex = 0
        Me.EPanel4.Text = "     업체별 전표현황"
        '
        'g20
        '
        Me.g20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g20.Location = New System.Drawing.Point(2, 23)
        Me.g20.Name = "g20"
        Me.g20.ReadOnly = False
        Me.g20.RowHeight = -1
        Me.g20.Size = New System.Drawing.Size(725, 82)
        Me.g20.TabIndex = 2
        '
        'EPanel5
        '
        Me.EPanel5.Location = New System.Drawing.Point(56, 146)
        Me.EPanel5.Name = "EPanel5"
        Me.EPanel5.Size = New System.Drawing.Size(274, 185)
        Me.EPanel5.TabIndex = 0
        Me.EPanel5.Text = "     EPanel5"
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.EPanel6)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.EPanel7)
        Me.SplitContainer5.Size = New System.Drawing.Size(729, 470)
        Me.SplitContainer5.SplitterDistance = 306
        Me.SplitContainer5.TabIndex = 0
        '
        'EPanel6
        '
        Me.EPanel6.Controls.Add(Me.g30)
        Me.EPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel6.Location = New System.Drawing.Point(0, 0)
        Me.EPanel6.Name = "EPanel6"
        Me.EPanel6.Size = New System.Drawing.Size(729, 306)
        Me.EPanel6.TabIndex = 0
        Me.EPanel6.Text = "     전표현황"
        '
        'g30
        '
        Me.g30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g30.Location = New System.Drawing.Point(2, 23)
        Me.g30.Name = "g30"
        Me.g30.ReadOnly = False
        Me.g30.RowHeight = -1
        Me.g30.Size = New System.Drawing.Size(725, 281)
        Me.g30.TabIndex = 2
        '
        'EPanel7
        '
        Me.EPanel7.Controls.Add(Me.g40)
        Me.EPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel7.Location = New System.Drawing.Point(0, 0)
        Me.EPanel7.Name = "EPanel7"
        Me.EPanel7.Size = New System.Drawing.Size(729, 160)
        Me.EPanel7.TabIndex = 0
        Me.EPanel7.Text = "     관리항목"
        '
        'g40
        '
        Me.g40.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g40.Location = New System.Drawing.Point(2, 23)
        Me.g40.Name = "g40"
        Me.g40.ReadOnly = False
        Me.g40.RowHeight = -1
        Me.g40.Size = New System.Drawing.Size(725, 135)
        Me.g40.TabIndex = 2
        '
        'FAR310
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FAR310"
        Me.Size = New System.Drawing.Size(1150, 690)
        Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.ResumeLayout(False)
        CType(Me.EPanel2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel2.ResumeLayout(False)
        CType(Me.EPanel8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel8.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.EPanel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel3.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.EPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel4.ResumeLayout(False)
        CType(Me.EPanel5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.ResumeLayout(False)
        CType(Me.EPanel6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel6.ResumeLayout(False)
        CType(Me.EPanel7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EPanel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel1 As Frame7.ePanel
    Friend WithEvents dept_nm As Frame7.eText
    Friend WithEvents dept_cd As Frame7.eText
    Friend WithEvents fr_dt As Frame7.eDate
    Friend WithEvents co_cd As Frame7.eCombo
    Friend WithEvents div_cd As Frame7.eCombo
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel3 As Frame7.ePanel
    Friend WithEvents g10 As Frame7.eGrid
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel4 As Frame7.ePanel
    Friend WithEvents g20 As Frame7.eGrid
    Friend WithEvents EPanel5 As Frame7.ePanel
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel6 As Frame7.ePanel
    Friend WithEvents g30 As Frame7.eGrid
    Friend WithEvents EPanel7 As Frame7.ePanel
    Friend WithEvents g40 As Frame7.eGrid
    Friend WithEvents doc_ty As Frame7.eCombo
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents EPanel2 As Frame7.ePanel
    Friend WithEvents btn_doc As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents doc_no As Frame7.eText
    Friend WithEvents btn_open As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_delete As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents base_dt As Frame7.eDate
    Friend WithEvents EPanel8 As Frame7.ePanel
    Friend WithEvents btn_doc1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents y_doc_no As Frame7.eText
    Friend WithEvents btn_open1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btn_delete1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents y_base_dt As Frame7.eDate

End Class
