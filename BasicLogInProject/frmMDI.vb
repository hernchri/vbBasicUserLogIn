Imports System.Windows.Forms

Public Class frmMDI

    Public _conn As clsConnection = Nothing


#Region "CONSTRUCTORS"

#End Region
    Private Sub frmMDI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _conn = New clsConnection

        Dim logIn As New frmUserLogIn()
        logIn.TopMost = True
        logIn.Show()
    End Sub
End Class
