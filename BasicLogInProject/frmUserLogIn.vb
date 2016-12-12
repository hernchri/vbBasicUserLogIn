Public Class frmUserLogIn

    Public _starter As clsStarter = Nothing

    Public Sub New(ByRef starter As clsStarter)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblMessage.Text = "Please Log In User Info"

    End Sub

    Private Sub frmUserLogIn_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        tbUserName.Focus()


    End Sub

    Private Sub btnRegister_Click(sender As System.Object, e As System.EventArgs) Handles btnRegister.Click
        Me.Close()
    End Sub
End Class