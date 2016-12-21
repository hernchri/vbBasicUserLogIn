﻿Imports System.Data.OleDb
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Text

Public Class frmRegistration

    Private _strUserName As String = ""
    Private _strBadge As String = ""
    'Private Const ALLOWED_SPEC_CHARS As String = "!@#$%^&*():?><;/.,qwertyuiopasdfghjklzxcvbnm"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frmRegistration_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        lblMessage.Text = ""
        lblUserName.Hide()
    End Sub


    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click
        If tbFirstName.Text.Trim = "" And tbLastName.Text.Trim = "" And tbPassword.Text.Trim = "" Then
            lblMessage.Text = "Please fill all fields"
            Exit Sub
        End If

        MDI._conn.mdbConn()
        Try
            Dim strSQL As String = "INSERT INTO tblUSERINFO ( USRNAME, FNAME, LNAME, BADGE, PASSW, EMPDATE ) VALUES(?,?,?,?,?,?)"
            'UserName, FirstName, LastName, CrtBadge, UserID, Password

            Dim cmd As New OleDbCommand(strSQL, MDI._conn.DBConn)
            cmd.Parameters.Clear()
            cmd.Parameters.Add("@USRNAME", OleDbType.VarChar, 100).Value() = _strUserName
            cmd.Parameters.Add("@FNAME", OleDbType.VarChar, 100).Value() = tbFirstName.Text
            cmd.Parameters.Add("@LNAME", OleDbType.VarChar, 100).Value() = tbLastName.Text
            cmd.Parameters.Add("@BADGE", OleDbType.VarChar, 100).Value() = "000000"
            cmd.Parameters.Add("@PASSW", OleDbType.VarChar, 100).Value() = tbPassword.Text
            cmd.Parameters.Add("@EMPDATE", OleDbType.VarChar, 100).Value() = Date.Today

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.ToString)
            MDI._conn.mdbClose()
            Exit Sub
        End Try

        MDI._conn.mdbClose()

        MsgBox("USER ACCOUNT CREATED: " & _strUserName)

        Me.Close()


    End Sub

    Private Sub generateUserName()
        lblUserName.Show()

        If tbFirstName.Text = "" Or tbLastName.Text = "" Then
            _strUserName = ""
            Exit Sub
        End If

        _strUserName = tbFirstName.Text.Substring(0, 1).ToUpper

        If tbLastName.Text.Trim.Length <= 4 Then
            _strUserName &= tbLastName.Text.Substring(0, tbLastName.Text.Trim.Length).ToUpper
        Else
            _strUserName &= tbLastName.Text.Substring(0, 4).ToUpper
        End If

        lblUserNameDisplay.Text = _strUserName
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

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub generateIDNumber()

    End Sub
End Class