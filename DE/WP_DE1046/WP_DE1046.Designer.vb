﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WP_DE1046
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
        Me.gd_nm = New Frame7.eText()
        Me.gd_cd = New Frame7.eText()
        Me.g_retrieve = New Frame7.eGrid()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.EPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.g_retrieve)
        Me.SplitContainer1.Size = New System.Drawing.Size(1182, 611)
        Me.SplitContainer1.SplitterDistance = 76
        Me.SplitContainer1.TabIndex = 2
        '
        'EPanel1
        '
        Me.EPanel1.Controls.Add(Me.gd_nm)
        Me.EPanel1.Controls.Add(Me.gd_cd)
        Me.EPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EPanel1.Location = New System.Drawing.Point(0, 0)
        Me.EPanel1.Name = "EPanel1"
        Me.EPanel1.Size = New System.Drawing.Size(1182, 76)
        Me.EPanel1.TabIndex = 0
        Me.EPanel1.Text = "     BOM 역전개"
        '
        'gd_nm
        '
        Me.gd_nm.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.gd_nm.Location = New System.Drawing.Point(229, 37)
        Me.gd_nm.Name = "gd_nm"
        Me.gd_nm.Size = New System.Drawing.Size(312, 21)
        Me.gd_nm.TabIndex = 130
        Me.gd_nm.Title = "품명"
        Me.gd_nm.TitleWidth = 80
        '
        'gd_cd
        '
        Me.gd_cd.ColumnName = "find_paymenterm_cd"
        Me.gd_cd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.gd_cd.Location = New System.Drawing.Point(15, 37)
        Me.gd_cd.Name = "gd_cd"
        Me.gd_cd.Size = New System.Drawing.Size(204, 21)
        Me.gd_cd.TabIndex = 129
        Me.gd_cd.TableName = "find_paymenterm_cd"
        Me.gd_cd.Title = "품목코드"
        Me.gd_cd.TitleWidth = 98
        '
        'g_retrieve
        '
        Me.g_retrieve.Dock = System.Windows.Forms.DockStyle.Fill
        Me.g_retrieve.Location = New System.Drawing.Point(0, 0)
        Me.g_retrieve.Name = "g_retrieve"
        Me.g_retrieve.ReadOnly = False
        Me.g_retrieve.RowHeight = -1
        Me.g_retrieve.Size = New System.Drawing.Size(1182, 531)
        Me.g_retrieve.TabIndex = 1
        '
        'WP_DE1046
        '
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "WP_DE1046"
        Me.Size = New System.Drawing.Size(1182, 611)
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
    Friend WithEvents g_retrieve As Frame7.eGrid
    Friend WithEvents gd_cd As Frame7.eText
    Friend WithEvents gd_nm As Frame7.eText

End Class
