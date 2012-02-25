Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Database_Layer
Imports System.Data
Imports System.Data.SqlClient

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WebService
    Inherits System.Web.Services.WebService

    Dim dl As New Database_Layer

#Region "Auto"

    'Commentaar
    <WebMethod()> _
    Public Function auto_verhuur(ByVal gegevensArray As ArrayList) As String
        Try
            Dim output As String
            output = dl.auto_verhuur(gegevensArray)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze een auto wilt toevoegen.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <param name="gegevensArray">Array met gegevens van een auto.</param>
    ''' <returns>Het resultaat van de bewerking wordt teruggeven als een string.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function auto_add(ByVal gegevensArray As ArrayList) As String
        Try
            Dim output As String
            output = dl.auto_add(gegevensArray)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze een auto wilt bewerken.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <param name="gegevensArray">Array met gegevens van een auto.</param>
    ''' <returns>Het resultaat van de bewerking wordt teruggeven als een string.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function auto_update(ByVal gegevensArray As ArrayList) As String
        Try
            Dim output As String
            output = dl.auto_update(gegevensArray)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze een auto wilt verwijderen.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <param name="autoID">autoID van de te verwijderen auto.</param>
    ''' <returns>Het resultaat van de bewerking wordt teruggeven als een string.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function auto_remove(ByVal autoID As Integer) As String
        Try
            Dim output As String
            output = dl.auto_remove(autoID)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze alle gegevens van alle auto's wilt.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <returns>Een dataset met de gegevens van alle auto's wordt teruggegeven.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function auto_getDataSetAuto() As DataSet
        Try
            Return dl.auto_getDataSetAuto()
        Catch ex As SqlException
            Throw
        End Try

    End Function

#End Region

#Region "Klant"

    'Commentaar
    <WebMethod()> _
    Public Function klant_Login(Emailadres As String, Wachtwoord As String) As DataSet
        Try
            Return dl.klant_login(Emailadres, Wachtwoord)
        Catch ex As Exception
            Throw
        End Try
    End Function

    'Commentaar
    Public Function klant_Wachtwoord(ByVal gegevensArray As ArrayList) As String
        Try
            Dim output As String
            output = dl.klant_wachtwoord(gegevensArray)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    'Commentaar
    Public Function klant_id(ByVal gegevensArray As ArrayList) As String
        Try
            Dim output As String
            output = dl.klant_id(gegevensArray)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    'Commentaar
    <WebMethod()> _
    Public Function klant_insert(ByVal gegevensArray As ArrayList) As String
        Try
            Dim output As String
            output = dl.klant_insert(gegevensArray)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze een klant wilt bewerken.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <param name="gegevensArray">Array met gegevens van een klant.</param>
    ''' <returns>Het resultaat van de bewerking wordt teruggeven als een string.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function klant_update(ByVal gegevensArray As ArrayList) As String
        Try
            Dim output As String
            output = dl.klant_update(gegevensArray)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze een klant wilt verwijderen.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <param name="klantID">klantID van de te verwijderen klant.</param>
    ''' <returns>Het resultaat van de bewerking wordt teruggeven als een string.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function klant_remove(ByVal klantID As Integer) As String
        Try
            Dim output As String
            output = dl.klant_remove(klantID)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze alle gegevens van alle klant wilt.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <returns>Een dataset met de gegevens van alle klanten wordt teruggegeven.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function klant_getDataSetKlant() As DataSet
        Try
            Return dl.klant_getDataSetKlant()
        Catch ex As SqlException
            Throw
        End Try

    End Function

#End Region

#Region "Verhuur"

    'Commentaar
    <WebMethod()> _
    Public Function verhuur_add(gegevensArray As ArrayList) As Boolean
        Try
            Return dl.verhuur_add(gegevensArray)
        Catch ex As Exception
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze een verhuur wilt bewerken.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <param name="gegevensArray">Array met gegevens van een verhuur.</param>
    ''' <returns>Het resultaat van de bewerking wordt teruggeven als een string.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function verhuur_update(ByVal gegevensArray As ArrayList) As String
        Try
            Dim output As String
            output = dl.verhuur_update(gegevensArray)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze een verhuur wilt verwijderen.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <param name="verhuurID">verhuurID van de te verwijderen verhuur.</param>
    ''' <returns>Het resultaat van de bewerking wordt teruggeven als een string.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function verhuur_remove(ByVal verhuurID As Integer) As String
        Try
            Dim output As String
            output = dl.verhuur_remove(verhuurID)

            Return output
        Catch ex As SqlException
            Throw
        End Try
    End Function

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze alle gegevens van alle verhuren wilt.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <returns>Een dataset met de gegevens van alle verhuren wordt teruggegeven.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen en opnieuw opgegooid.</exception>
    <WebMethod()> _
    Public Function verhuur_getDataSetVerhuur() As DataSet
        Try
            Return dl.verhuur_getDataSetVerhuur()
        Catch ex As SqlException
            Throw
        End Try

    End Function

#End Region

    ''' <summary>
    ''' Deze functie wordt aangeroepen door een client wanneer deze de connectie met de database wilt testen.
    ''' De functie zelf roept de bijhorende functie op in de Database_Layer.
    ''' </summary>
    ''' <returns>Het resultaat van de aangeroepen functie.</returns>
    <WebMethod()> _
    Public Function connectionTest() As Boolean
        Return dl.connectionTest()
    End Function

    'Commentaar
    <WebMethod()> _
    Public Function admin_Login(Emailadres As String, Wachtwoord As String) As DataSet
        Try
            Return dl.Admin_Login(Emailadres, Wachtwoord)
        Catch ex As Exception
            Throw
        End Try
    End Function

    'Commentaar
    <WebMethod()> _
    Public Function admin_GetDataSetAdmin() As DataSet
        Return dl.Admin_getDataSetAdmin()
    End Function

End Class