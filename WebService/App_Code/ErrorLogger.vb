Imports Microsoft.VisualBasic
Imports System.IO
Imports System.Web.UI

Public Class ErrorLogger

    ''' <summary>
    ''' Er wordt een stored procedure met de nodige parameters opgemaakt met behulp van de gegevensArray.
    ''' De stored procedure voegt een auto toe aan de tabel tblAuto in de database.
    ''' </summary>
    ''' <param name="err">Een waarde van het type Exception.</param>
    ''' <exception cref="Exception">Elke exception wordt opgevangen en gelogged.</exception>
    Public Shared Sub Log_Error(err As Exception)

        Dim strErrLog As String = HttpContext.Current.Server.MapPath("~/App_Data/Err_log.txt")
        If Not File.Exists(strErrLog) Then
            File.Create(strErrLog).Close()
        End If

        Try
            Using s As StreamWriter = File.AppendText(strErrLog)
                s.WriteLine("Message : " & err.ToString)
                s.WriteLine("Date : " & Date.Now.Date)
                s.WriteLine("Time : " & TimeOfDay)
                s.WriteLine("====================================================================")
                s.Flush()
                s.Close()
            End Using
        Catch ex As Exception
            Log_Error(ex)
        End Try

    End Sub

End Class
