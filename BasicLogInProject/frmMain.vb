Public Class frmMain

    Public _starter As clsStarter = Nothing

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _starter = New clsStarter

        'TEST MDB CONNECTION
        _starter.mdbConn()
        _starter.mdbClose()
    End Sub


    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim logIn As New frmUserLogIn(_starter)

        logIn.Show()


    End Sub
End Class
