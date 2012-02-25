
Partial Class Registratie_voltooid
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim id As String

        id = Session("klantinsert")

        If id = "Klant succesvol toegevoegd." Then
            lblresult.Text = "Registratie succesvol voltooid."
        Else
            lblresult.Text = "Er is iets fout gelopen, gelieve opnieuw te proberen."
        End If

    End Sub
End Class
