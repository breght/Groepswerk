
Partial Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        logincheck()
       

    End Sub

    Protected Sub Btnlogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnlogin.Click

        Response.Redirect("Login.aspx")

    End Sub

    Protected Sub btnUitloggen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUitloggen.Click
        Session("login") = "false"
        Response.Redirect("Default.aspx")
     

    End Sub

    Protected Sub logincheck()
        Dim id As String

        id = Session("login")

        If id = "true" Then
            Btnlogin.Visible = False
            lbllogin.Visible = True
            btnUitloggen.Visible = True
        Else

            Btnlogin.Visible = True
            lbllogin.Visible = False
            btnUitloggen.Visible = False

           
        End If


    End Sub

End Class

