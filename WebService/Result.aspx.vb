
Partial Class Result
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim client As New WebService
        Dim gegevens As New ArrayList
        Dim carid As String
        Dim klantid As String
        Dim van As Date
        Dim tot As Date

        If Not IsPostBack Then

            Try
                Dim result As String

                klantid = Session("Klant_id")
                carid = Session("carid")
                van = Session("Datum_Verhuur")
                tot = Session("Datum_Terug")

                gegevens.Add(carid)
                gegevens.Add(klantid)
                gegevens.Add(van)
                gegevens.Add(tot)

                result = client.auto_verhuur(gegevens)

                If result = "1" Then
                    lblresult.Text = "Succesvol verwerkt u wordt doorverwezen naar de homepage"

                Else
                    lblresult.Text = "Er is iets fout gelopen, probeer opnieuw"
                End If

            Catch ex As Exception
                Throw
            End Try
        End If

    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("Default.aspx")
    End Sub
End Class
