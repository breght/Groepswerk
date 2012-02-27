
Partial Class Login
    Inherits System.Web.UI.Page
    'test
    Protected Sub btnInloggen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInloggen.Click

        Dim client As New WebService
        Dim gegevens As New ArrayList
        Dim wachtwoord1 As String
        Dim wachtwoord2 As String


        wachtwoord1 = txtwachtwoord.Text.ToString
        gegevens.Add(txtGebruikersnaam.Text.ToString)

        Try
            wachtwoord2 = client.klant_Wachtwoord(gegevens)
            If wachtwoord1.Equals(wachtwoord2) Then
                Session("klantid") = client.klant_id(gegevens)
                Session("login") = "true"
                Response.Redirect("Default.aspx")
            Else
                txtGebruikersnaam.Text = ""
                txtwachtwoord.Text = ""
                lblMessage.Visible = True
                wachtwoord1 = ""
                wachtwoord2 = ""
            End If
        Catch ex As Exception
            Throw
        End Try



    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblMessage.Visible = False
    End Sub

    Protected Sub btnAccount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAccount.Click
        Response.Redirect("Registratie.aspx")
    End Sub
End Class
