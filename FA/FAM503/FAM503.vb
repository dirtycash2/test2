﻿Imports Frame7
Imports Base7
Imports Base7.Shared

Public Class FAM503

    Public Overrides Sub MenuButton_Click(ByVal mty As MenuType)

        Select Case mty

            Case MenuType.Open

                Me.Open()

            Case MenuType.Save

                'Case MenuType.New

            Case Else
                MyBase.MenuButton_Click(mty)
        End Select

    End Sub
End Class
