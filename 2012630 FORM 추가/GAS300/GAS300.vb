﻿Imports Frame7
Imports Base7
Imports Base7.Shared
Imports Base7.Functions

Public Class GAS300

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)
        Select Case mty
            Case MenuType.Open
                Me.Open()

            Case MenuType.Save

                If Me.Save() Then
                    Me.Open()
                End If


            Case Else
                MyBase.MenuButton_Click(mty)
        End Select

    End Sub




End Class
