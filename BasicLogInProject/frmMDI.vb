Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class frmMDI

    Public _conn As clsConnection = Nothing
    Public _userLoggedIn As UserVo = Nothing


#Region "CONSTRUCTORS"

#End Region
    Private Sub frmMDI_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        _conn = New clsConnection

        Dim logIn As New frmUserLogIn()
        logIn.MdiParent = Me

        logIn.Show()
    End Sub

    Public Sub LogIn(ByRef read As OleDbDataReader)
        'USRNAME, FNAME, LNAME, BADGE, PASSW, EMPDATE
        _userLoggedIn = New UserVo()

        Dim i As Integer = 0

        _userLoggedIn.strUserName = read(0).ToString()
        _userLoggedIn.strFirstName = read(1).ToString()
        _userLoggedIn.strLastName = read(2).ToString()
        _userLoggedIn.strBadge = read(3).ToString()

    End Sub

    Public Sub LogOut()
        _userLoggedIn = Nothing
    End Sub
End Class
