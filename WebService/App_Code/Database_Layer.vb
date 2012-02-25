Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class Database_Layer

    Dim objDataSet As New DataSet
    Dim objDataView As New DataView
    Dim objDataAdapter As New SqlDataAdapter()
    Dim objConnection As New SqlConnection _
    ("Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True")

#Region "Auto"

    'Commentaar
    Public Function auto_verhuur(ByVal gegevensArray As ArrayList) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("insertVerhuur", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Auto_ID", gegevensArray.Item(0))
            objCommand.Parameters.AddWithValue("@Klant_ID", gegevensArray.Item(1))
            objCommand.Parameters.AddWithValue("@Datum_Verhuur", gegevensArray.Item(2))
            objCommand.Parameters.AddWithValue("@Datum_Terug", gegevensArray.Item(3))

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "1"
            Else
                Return "0"
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try
    End Function

    ''' <summary>
    ''' Er wordt een stored procedure met de nodige parameters opgemaakt met behulp van de gegevensArray.
    ''' De stored procedure voegt een auto toe aan de tabel tblAuto in de database.
    ''' </summary>
    ''' <param name="gegevensArray">Array met gegevens die naar de database worden weggeschreven.</param>
    ''' <returns>Een string wordt teruggegeven met de melding of de actie al dan niet geslaagd is.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function auto_add(ByVal gegevensArray As ArrayList) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("insertAuto", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Merk", gegevensArray.Item(0))
            objCommand.Parameters.AddWithValue("@Model", gegevensArray.Item(1))
            objCommand.Parameters.AddWithValue("@Brandstof", gegevensArray.Item(2))
            objCommand.Parameters.AddWithValue("@Transmissie", gegevensArray.Item(3))
            objCommand.Parameters.AddWithValue("@Vermogen", gegevensArray.Item(4))
            objCommand.Parameters.AddWithValue("@Zitplaatsen", Integer.Parse(gegevensArray.Item(5)))
            objCommand.Parameters.AddWithValue("@Carrosserietype", gegevensArray.Item(6))
            objCommand.Parameters.AddWithValue("@Kilometerstand", Integer.Parse(gegevensArray.Item(7)))
            objCommand.Parameters.AddWithValue("@Bouwjaar", Integer.Parse(gegevensArray.Item(8)))
            objCommand.Parameters.AddWithValue("@Kleur", gegevensArray.Item(9))
            objCommand.Parameters.AddWithValue("@Prijs", Double.Parse(gegevensArray.Item(10)))

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "Auto succesvol toegevoegd."
            Else
                Return "Fout tijdens het toevoegen van de auto."
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try

    End Function

    ''' <summary>
    ''' Er wordt een stored procedure met de nodige parameters opgemaakt met behulp van de gegevensArray.
    ''' De stored procedure voert een update-commando uit op de rij met het bijhorende Auto_ID nummer.
    ''' </summary>
    ''' <param name="gegevensArray">Array met gegevens die naar de database worden weggeschreven.</param>
    ''' <returns>Een string wordt teruggegeven met de melding of de actie al dan niet geslaagd is.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function auto_update(ByVal gegevensArray As ArrayList) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("updateAuto", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Auto_ID", Integer.Parse(gegevensArray.Item(0)))
            objCommand.Parameters.AddWithValue("@Merk", gegevensArray.Item(1))
            objCommand.Parameters.AddWithValue("@Model", gegevensArray.Item(2))
            objCommand.Parameters.AddWithValue("@Brandstof", gegevensArray.Item(3))
            objCommand.Parameters.AddWithValue("@Transmissie", gegevensArray.Item(4))
            objCommand.Parameters.AddWithValue("@Vermogen", gegevensArray.Item(5))
            objCommand.Parameters.AddWithValue("@Zitplaatsen", Integer.Parse(gegevensArray.Item(6)))
            objCommand.Parameters.AddWithValue("@Carrosserietype", gegevensArray.Item(7))
            objCommand.Parameters.AddWithValue("@Kilometerstand", Integer.Parse(gegevensArray.Item(8)))
            objCommand.Parameters.AddWithValue("@Bouwjaar", Integer.Parse(gegevensArray.Item(9)))
            objCommand.Parameters.AddWithValue("@Kleur", gegevensArray.Item(10))
            objCommand.Parameters.AddWithValue("@Prijs", Double.Parse(gegevensArray.Item(11)))

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "Auto succesvol bewerkt."
            Else
                Return "Fout tijdens het bewerken van de auto."
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try

    End Function

    ''' <summary>
    ''' Er wordt een stored procedure opgemaakt met het autoID als parameter.
    ''' De stored procedure voert een delete-commando uit voor de rij met het bijhorende autoID nummer.
    ''' </summary>
    ''' <param name="autoID">Het ID van de te verwijderen auto.</param>
    ''' <returns>Een string wordt teruggegeven met de melding of de actie al dan niet geslaagd is.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function auto_remove(ByVal autoID As Integer) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("removeAuto", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Auto_ID", autoID)

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "Auto succesvol verwijderd."
            Else
                Return "Fout tijdens het verwijderen van de auto."
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try

    End Function

    ''' <summary>
    ''' Er wordt een SQL commando uitgevoerd die alle gegevens uit de tabel tblAuto haalt.
    ''' Deze gegevens worden aan een dataset toegevoegd onder de tabelnaam tblAuto.
    ''' </summary>
    ''' <returns>Er wordt een dataset teruggegeven met de gegevens van alle auto's.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function auto_getDataSetAuto() As DataSet

        Try
            objDataAdapter.SelectCommand = New SqlCommand("SELECT * FROM tblAuto", objConnection)
            objDataAdapter.Fill(objDataSet, "tblAuto")

            Return objDataSet

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        End Try

    End Function

#End Region

#Region "Klant"

    'Commentaar
    Public Function klant_login(ByVal Emailadres As String, ByVal Wachtwoord As String) As DataSet
        Try
            Dim objCommand = New SqlCommand("loginKlant", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Emailadres", Emailadres)
            objCommand.Parameters.AddWithValue("@Wachtwoord", Wachtwoord)


            objDataAdapter = New SqlDataAdapter(objCommand)

            objConnection.Open()

            objDataAdapter.Fill(objDataSet)

            Return objDataSet

        Catch ex As Exception
            ErrorLogger.Log_Error(ex)
            Throw ex
        Finally
            objConnection.Close()
        End Try

    End Function

    'Commentaar
    Public Function klant_wachtwoord(ByVal gegevensArray As ArrayList) As String

        Try
            Dim rdr As SqlDataReader
            Dim wachtwoord As String = ""
            Dim objCommand As SqlCommand = New SqlCommand("selectWachtwoord", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@mail", (gegevensArray.Item(0)))

            objConnection.Open()

            rdr = objCommand.ExecuteReader

            While rdr.Read()
                wachtwoord = rdr.GetString(rdr.GetOrdinal("Wachtwoord"))

            End While
            Return wachtwoord
            rdr.Close()

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()

        End Try

    End Function

    'Commentaar
    Public Function klant_id(ByVal gegevensArray As ArrayList) As String

        Try
            Dim rdr As SqlDataReader
            Dim id As String = ""
            Dim objCommand As SqlCommand = New SqlCommand("selectKlantID", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@mail", (gegevensArray.Item(0)))

            objConnection.Open()

            rdr = objCommand.ExecuteReader

            While rdr.Read()
                id = rdr.GetInt32(rdr.GetOrdinal("Klant_ID"))

            End While
            Return id
            rdr.Close()

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()

        End Try

    End Function

    'Commentaar
    Public Function klant_insert(ByVal gegevensArray As ArrayList) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("insertKlant", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Voornaam", gegevensArray.Item(0))
            objCommand.Parameters.AddWithValue("@Achternaam", gegevensArray.Item(1))
            objCommand.Parameters.AddWithValue("@Adres", gegevensArray.Item(2))
            objCommand.Parameters.AddWithValue("@Postcode", Integer.Parse(gegevensArray.Item(3)))
            objCommand.Parameters.AddWithValue("@Rijksregisternummer", gegevensArray.Item(4))
            objCommand.Parameters.AddWithValue("@Telefoonnummer", gegevensArray.Item(5))
            objCommand.Parameters.AddWithValue("@GSMNummer", gegevensArray.Item(6))
            objCommand.Parameters.AddWithValue("@Geboortedatum", Date.Parse((gegevensArray.Item(7))))
            objCommand.Parameters.AddWithValue("@Emailadres", gegevensArray.Item(8))
            objCommand.Parameters.AddWithValue("@Wachtwoord", gegevensArray.Item(9))

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "Klant succesvol toegevoegd."
            Else
                Return "Fout tijdens het toevoegen van de klant."
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try

    End Function

    ''' <summary>
    ''' Er wordt een stored procedure met de nodige parameters opgemaakt met behulp van de gegevensArray.
    ''' De stored procedure voert een update-commando uit op de rij met het bijhorende Klant_ID nummer.
    ''' </summary>
    ''' <param name="gegevensArray">Array met gegevens die naar de database worden weggeschreven.</param>
    ''' <returns>Een string wordt teruggegeven met de melding of de actie al dan niet geslaagd is.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function klant_update(ByVal gegevensArray As ArrayList) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("updateKlant", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Klant_ID", Integer.Parse(gegevensArray.Item(0)))
            objCommand.Parameters.AddWithValue("@Voornaam", gegevensArray.Item(1))
            objCommand.Parameters.AddWithValue("@Achternaam", gegevensArray.Item(2))
            objCommand.Parameters.AddWithValue("@Adres", gegevensArray.Item(3))
            objCommand.Parameters.AddWithValue("@Postcode", Integer.Parse(gegevensArray.Item(4)))
            objCommand.Parameters.AddWithValue("@Rijksregisternummer", gegevensArray.Item(5))
            objCommand.Parameters.AddWithValue("@Telefoonnummer", gegevensArray.Item(6))
            objCommand.Parameters.AddWithValue("@GSMNummer", gegevensArray.Item(7))
            objCommand.Parameters.AddWithValue("@Geboortedatum", Date.Parse((gegevensArray.Item(8))))

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "Klant succesvol bewerkt."
            Else
                Return "Fout tijdens het bewerken van de klant."
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try

    End Function
    ''' <summary>
    ''' Er wordt een stored procedure opgemaakt met het klantID als parameter.
    ''' De stored procedure voert een delete-commando uit voor de rij met het bijhorende klantID nummer.
    ''' </summary>
    ''' <param name="klantID">Het ID van de te verwijderen klant.</param>
    ''' <returns>Een string wordt teruggegeven met de melding of de actie al dan niet geslaagd is.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function klant_remove(ByVal klantID As Integer) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("removeKlant", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Klant_ID", klantID)

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "Klant succesvol verwijderd."
            Else
                Return "Fout tijdens het verwijderen van de klant."
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try

    End Function
    ''' <summary>
    ''' Er wordt een SQL commando uitgevoerd die alle gegevens uit de tabel tblKlant haalt.
    ''' Deze gegevens worden aan een dataset toegevoegd onder de tabelnaam tblKlant.
    ''' </summary>
    ''' <returns>Er wordt een dataset teruggegeven met de gegevens van alle klanten.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function klant_getDataSetKlant() As DataSet

        Try
            objDataAdapter.SelectCommand = New SqlCommand("SELECT * FROM tblKlant", objConnection)
            objDataAdapter.Fill(objDataSet, "tblKlant")

            Return objDataSet
        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        End Try

    End Function

#End Region

#Region "Verhuur"

    'Commentaar
    Public Function verhuur_add(gegevensArray As ArrayList) As Boolean
        Try
            Dim objCommand As SqlCommand = New SqlCommand("insertVerhuur", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Auto_ID", Integer.Parse(gegevensArray.Item(0)))
            objCommand.Parameters.AddWithValue("@Klant_ID", Integer.Parse(gegevensArray.Item(1)))
            objCommand.Parameters.AddWithValue("@Datum_Verhuur", Date.Parse(gegevensArray.Item(2)))
            objCommand.Parameters.AddWithValue("@Datum_Terug", Date.Parse(gegevensArray.Item(3)))

            objConnection.Open()

            If objCommand.ExecuteNonQuery = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try
    End Function

    ''' <summary>
    ''' Er wordt een stored procedure met de nodige parameters opgemaakt met behulp van de gegevensArray.
    ''' De stored procedure voert een update-commando uit op de rij met het bijhorende Verhuur_ID nummer.
    ''' </summary>
    ''' <param name="gegevensArray">Array met gegevens die naar de database worden weggeschreven.</param>
    ''' <returns>Een string wordt teruggegeven met de melding of de actie al dan niet geslaagd is.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function verhuur_update(ByVal gegevensArray As ArrayList) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("updateVerhuur", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Verhuur_ID", Integer.Parse(gegevensArray.Item(0)))
            objCommand.Parameters.AddWithValue("@Datum_Verhuur", Date.Parse(gegevensArray.Item(1)))
            objCommand.Parameters.AddWithValue("@Datum_Terug", Date.Parse(gegevensArray.Item(2)))

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "Verhuur succesvol bewerkt."
            Else
                Return "Fout tijdens het bewerken van de verhuur."
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try

    End Function

    ''' <summary>
    ''' Er wordt een stored procedure opgemaakt met het verhuurID als parameter.
    ''' De stored procedure voert een delete-commando uit voor de rij met het bijhorende verhuurID nummer.
    ''' </summary>
    ''' <param name="verhuurID">Het ID van de te verwijderen verhuur.</param>
    ''' <returns>Een string wordt teruggegeven met de melding of de actie al dan niet geslaagd is.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function verhuur_remove(ByVal verhuurID As Integer) As String

        Try
            Dim objCommand As SqlCommand = New SqlCommand("removeVerhuur", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Verhuur_ID", verhuurID)

            objConnection.Open()

            If objCommand.ExecuteNonQuery().ToString = "1" Then
                Return "Verhuurde wagen succesvol verwijderd."
            Else
                Return "Fout tijdens het verwijderen van de verhuurde wagen."
            End If

        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        Finally
            objConnection.Close()
        End Try

    End Function

    ''' <summary>
    ''' Er wordt een SQL commando uitgevoerd die alle gegevens uit de tabel tblVerhuurdeWagens, tblKlant en tblAuto haalt.
    ''' Deze gegevens worden aan een dataset toegevoegd onder dezelfde tabelnaam.
    ''' </summary>
    ''' <returns>Er wordt een dataset teruggegeven met de gegevens van alle verhuurde wagens, klanten en auto's.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function verhuur_getDataSetVerhuur() As DataSet

        Try
            objDataAdapter.SelectCommand = New SqlCommand("SELECT * FROM tblVerhuurdeWagens", objConnection)
            objDataAdapter.Fill(objDataSet, "tblVerhuurdeWagens")

            objDataAdapter.SelectCommand = New SqlCommand("SELECT * FROM tblAuto", objConnection)
            objDataAdapter.Fill(objDataSet, "tblAuto")

            objDataAdapter.SelectCommand = New SqlCommand("SELECT * FROM tblKlant", objConnection)
            objDataAdapter.Fill(objDataSet, "tblKlant")

            Return objDataSet
        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Throw
        End Try

    End Function

#End Region

    ''' <summary>
    ''' Er wordt een poging gedaan om een connectie met de database tot stand te brengen.
    ''' Het resultaat van deze actie wordt als boolean waarde teruggegeven.
    ''' </summary>
    ''' <returns>Een True/False waarde wordt teruggegeven.</returns>
    ''' <exception cref="SqlException">Elke fout in verband met de database wordt opgevangen, gelogged en opnieuw opgegooid.</exception>
    Public Function connectionTest() As Boolean

        Try
            objConnection.Open()
            objConnection.Close()
            Return True
        Catch ex As SqlException
            ErrorLogger.Log_Error(ex)
            Return False
        End Try

    End Function

    'Commentaar
    Public Function Admin_Login(ByVal Emailadres As String, ByVal Wachtwoord As String) As DataSet
        Try
            Dim objCommand = New SqlCommand("loginAdmin", objConnection)
            objCommand.CommandType = CommandType.StoredProcedure

            objCommand.Parameters.AddWithValue("@Emailadres", Emailadres)
            objCommand.Parameters.AddWithValue("@Wachtwoord", Wachtwoord)

            objDataAdapter = New SqlDataAdapter(objCommand)

            objConnection.Open()

            objDataAdapter.Fill(objDataSet)

            Return objDataSet
        Catch ex As Exception
            ErrorLogger.Log_Error(ex)
            Throw ex
        Finally
            objConnection.Close()
        End Try
    End Function

    'Commentaar
    Public Function Admin_getDataSetAdmin() As DataSet
        objDataAdapter.SelectCommand = New SqlCommand("SELECT * FROM tblAdmins", objConnection)
        objDataAdapter.Fill(objDataSet, "tblAdmins")

        Return objDataSet
    End Function

End Class
