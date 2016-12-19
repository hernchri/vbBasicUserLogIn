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
End Class