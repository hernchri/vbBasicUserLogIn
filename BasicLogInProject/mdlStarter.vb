Module mdlStarter
    Public MDI As frmMDI

    Sub Main()
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        AddHandler currentDomain.UnhandledException, AddressOf MyHandler

        MDI = New frmMDI

        MDI.Show()


    End Sub

    Private Sub MyHandler(sender As Object, args As UnhandledExceptionEventArgs)
        'Creates Error message for unhandled exception
        Dim ex As Exception = DirectCast(args.ExceptionObject, Exception)

        MessageBox.Show(ex.ToString)
        Application.Exit()
    End Sub
End Module
