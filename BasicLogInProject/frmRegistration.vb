Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class frmRegistration

    Private _strUserName As String = ""
    Private Const ALLOWED_SPEC_CHARS As String = "!@#$%^&*():?><;/.,"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmRegistration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblMessage.Text = ""
    End Sub


    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click
        If tbFirstName.Text.Trim = "" And tbLastName.Text.Trim = "" And tbPassword.Text.Trim = "" Then
            lblMessage.Text = "Please fill all fields"
            Exit Sub
        End If

        MDI._conn.mdbConn()



        Dim strSQL As String = "INSERT INTO UsrInfo ( UserName, FirstName, LastName, CrtBadge, UserID) " & _
                "VALUES(?,?,?,?,?)"
        Dim cmd As New OleDbCommand(strSQL, MDI._conn.DBConn)
        cmd.Parameters.Add(_strUserName)
        cmd.Parameters.Add(tbFirstName.Text)
        cmd.Parameters.Add(tbLastName.Text)
        cmd.Parameters.Add(DateAndTime.Now)
        cmd.Parameters.Add("0000000")


        MDI._conn.mdbClose()


    End Sub

    Private Sub generateUserName()
        _strUserName = tbFirstName.Text.Substring(0, 1).ToUpper

        If tbLastName.Text.Trim.Length <= 4 Then
            _strUserName &= tbLastName.Text.Substring(0, tbLastName.Text.Trim.Length).ToUpper
        Else
            _strUserName &= tbLastName.Text.Substring(0, 4).ToUpper
        End If
    End Sub

    Private Sub tbFirstName_TextChanged(sender As Object, e As System.EventArgs) Handles tbFirstName.TextChanged
        generateUserName()
    End Sub

    Private Sub tbLastName_TextChanged(sender As Object, e As System.EventArgs) Handles tbLastName.TextChanged
        generateUserName()
    End Sub


    Private Sub tbPassword_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles tbPassword.KeyPress
        If e.KeyChar = " " Then
            e.Handled = True
        End If
    End Sub
End Class