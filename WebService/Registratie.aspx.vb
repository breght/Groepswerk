
Partial Class Registratie
    Inherits System.Web.UI.Page

    Protected Sub btnAanmaken_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAanmaken.Click

        Dim client As New WebService
        Dim gegevens As New ArrayList

        If txtWachtwoord1.Text = txtwachtwoord2.Text Then
            gegevens.Add(txtVoornaam.Text)
            gegevens.Add(txtAchternaam.Text)
            gegevens.Add(txtAdres.Text)
            gegevens.Add(txtPostcode.Text)
            gegevens.Add(txtRijksregisternummer.Text)
            gegevens.Add(txtTelefoonnummer.Text)
            gegevens.Add(txtGSMNummer.Text)
            gegevens.Add(txtGeboortedatum.Text)
            gegevens.Add(txtEmailadres.Text)
            gegevens.Add(txtWachtwoord1.Text)

            Session("klantinsert") = client.klant_insert(gegevens)

            Response.Redirect("Registratie_voltooid.aspx")
        Else
            txtWachtwoord1.Text = ""
            txtwachtwoord2.Text = ""
        End If

    End Sub
End Class
