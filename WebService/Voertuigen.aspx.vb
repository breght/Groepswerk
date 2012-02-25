Imports System.Data
Imports System.Data.SqlClient

Partial Class Voertuigen
    Inherits System.Web.UI.Page

    Dim client As New WebService
    Dim objDataSet As New DataSet
    Dim objDataTable As New DataTable
    Dim rowPosition As Integer
    Dim statusConnectie As String
  
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

        Dim id As String

        id = Session("login")

        If id = "true" Then

            Session("carid") = GridView1.SelectedValue.ToString
            Response.Redirect("Verhuur.aspx")

        Else
            Response.Redirect("login.aspx")
        End If

    End Sub
End Class
