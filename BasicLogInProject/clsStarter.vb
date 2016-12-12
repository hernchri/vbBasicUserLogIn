Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class clsStarter
    Public Const LOCALFILE As String = "LocalDB.mdb"
    Public DBFileName As String = Application.StartupPath & "\" & LOCALFILE
    Public DBConn As OleDbConnection

    Public Sub New()
        Dim f As FileInfo = New FileInfo(DBFileName)
        If Not f.Exists Then
            'Probably create MDB File if not exist
        End If

    End Sub

    Public Sub mdbConn()
        Try


            DBConn = New OleDbConnection
            DBConn.ConnectionString = "provider=microsoft.jet.oledb.4.0;data source=" & DBFileName & ";password=;user id="
            DBConn.Open()

            If Not DBConn.State = ConnectionState.Open Then

                'ERROR MESSAGE
                MessageBox.Show("Error loading local database " & DBFileName)
                Application.Exit()


            End If

        Catch ex As Exception

            MessageBox.Show("Error loading local database " & DBFileName)
            MessageBox.Show(ex.ToString)
            Application.Exit()

        End Try
    End Sub

    Public Sub mdbClose()

        If DBConn.State = ConnectionState.Open Then
            DBConn.Close()
        End If

    End Sub
End Class
