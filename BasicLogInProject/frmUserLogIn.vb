Imports System.Data.OleDb

Public Class frmUserLogIn


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblMessage.Text = "Please Log In User Info"

    End Sub

    Private Sub frmUserLogIn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tbUserName.Focus()


    End Sub

    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click
        Dim registration As New frmRegistration
        registration.Show()

    End Sub

    Private Sub btnLogIn_Click(sender As System.Object, e As System.EventArgs) Handles btnLogIn.Click
        If tbUserName.Text.Trim = "" Then
            MessageBox.Show("Please provide Username")
            tbUserName.Focus()
            Exit Sub
        End If

        If tbPassword.Text.Trim = "" Then
            MessageBox.Show("Please provide Password")
            tbPassword.Focus()
            Exit Sub
        End If


        Try
            MDI._conn.mdbConn()

            Dim strSQL As String = "SELECT * FROM tblUSERINFO WHERE USRNAME ='" & tbUserName.Text & "' OR BADGE ='" & tbUserName.Text & "' AND PASSW ='" & tbPassword.Text & "' "

            Dim cmd As New OleDbCommand(strSQL, MDI._conn.DBConn)
            cmd.Parameters.Clear()


            Dim reader As OleDbDataReader = cmd.ExecuteReader

            If reader.HasRows Then
                reader.Read()
                MDI.LogIn(reader)
                MessageBox.Show("Log In Successful")
            Else
                MessageBox.Show("Incorrect username / password")
            End If
        Catch ex As Exception

            MessageBox.Show(ex.ToString)

        Finally
            MDI._conn.mdbClose()
        End Try
    End Sub
End Class