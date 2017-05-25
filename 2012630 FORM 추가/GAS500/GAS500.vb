﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class GAS500

    Private Sub Me_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Open()
    End Sub

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
                MyBase.Open()

            Case MenuType.Save

                If MyBase.Save() Then
                    Dim saveID As String = g10.Text("bs_cd")
                    MyBase.Open()
                    g10.Find("bs_cd=" + saveID)
                End If


            Case Else
                MyBase.MenuButton_Click(mty)        '나머지는 기본기능에 맡긴다

        End Select
    End Sub


End Class
