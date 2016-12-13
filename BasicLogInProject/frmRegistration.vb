Public Class frmRegistration

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


    End Sub


End Class