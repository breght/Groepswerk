
Partial Class verhuur
    Inherits System.Web.UI.Page

    Protected Sub btnBevestig_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBevestig.Click
        Dim id As String

        id = Session("klantid")

        Session("Datum_verhuur") = Cvan.SelectedDate.Date
        Session("Datum_Terug") = Ctot.SelectedDate.Date
        Session("Klant_id") = id

        Response.Redirect("Result.aspx")
        
    End Sub



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Cvan.SelectedDate = Now.Date
            Ctot.SelectedDate = Now.Date
        End If

    End Sub
End Class
