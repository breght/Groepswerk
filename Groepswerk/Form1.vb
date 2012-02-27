Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Web.Services.Protocols
'loooooooool
'test
Public Class Form1

    Dim client As New wsAuto_DB.WebService
    Dim objDataSet As New DataSet
    Dim objDataTable As New DataTable
    Dim rowPosition As Integer
    Dim statusConnectie As String

#Region "Auto"

    ''' <summary>
    ''' De dataset en datatable wordt gevuld met gegevens van alle auto's.
    ''' Alle velden worden ingevuld met gegevens van de eerste rij in de tabel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub pnlAuto_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles pnlAuto.VisibleChanged

        If pnlAuto.Visible = True Then
            objDataSet = client.auto_getDataSetAuto()
            objDataTable = objDataSet.Tables("tblAuto")
            rowPosition = 0
            auto_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De eerste positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAutoFirst_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoFirst.Click

        rowPosition = 0
        auto_fillFields()

    End Sub

    ''' <summary>
    ''' De vorige positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAutoPrevious_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoPrevious.Click

        If Not rowPosition = 0 Then
            rowPosition -= 1
            auto_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De volgende positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAutoNext_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoNext.Click

        If Not rowPosition = objDataTable.Rows.Count - 1 Then
            rowPosition += 1
            auto_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De laatse positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAutoLast_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoLast.Click

        rowPosition = objDataTable.Rows.Count - 1
        auto_fillFields()

    End Sub

    ''' <summary>
    ''' Toevoegen van een auto.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <exception cref="SoapException">Een Soap Exception wordt opgevangen wanneer de communicatie met de webservice misgaat.</exception>
    Private Sub btnAutoToevoegen_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoToevoegen.Click

        Dim gegevens As New ArrayList
        Dim foutieveInvoer As Boolean = False

        If isString(txtMerk.Text) Then gegevens.Add(txtMerk.Text) Else foutieveInvoer = True
        If isString(txtModel.Text) Then gegevens.Add(txtModel.Text) Else foutieveInvoer = True
        If isString(cbBrandstof.Text) Then gegevens.Add(cbBrandstof.Text) Else foutieveInvoer = True
        If isString(cbTransmissie.Text) Then gegevens.Add(cbTransmissie.Text) Else foutieveInvoer = True
        If isString(txtVermogen.Text) Then gegevens.Add(txtVermogen.Text) Else foutieveInvoer = True
        If isString(txtZitplaatsen.Text) Then gegevens.Add(txtZitplaatsen.Text) Else foutieveInvoer = True
        If isString(txtCarrosserietype.Text) Then gegevens.Add(txtCarrosserietype.Text) Else foutieveInvoer = True
        If isString(txtKilometerstand.Text) Then gegevens.Add(txtKilometerstand.Text) Else foutieveInvoer = True
        If isString(txtBouwjaar.Text) Then gegevens.Add(txtBouwjaar.Text) Else foutieveInvoer = True
        If isString(txtKleur.Text) Then gegevens.Add(txtKleur.Text) Else foutieveInvoer = True
        If isString(txtPrijs.Text) Then gegevens.Add(txtPrijs.Text) Else foutieveInvoer = True

        If foutieveInvoer = False Then
            Try
                Dim result As String
                result = client.auto_add(gegevens.ToArray)
                MessageBox.Show(result, "Toevoegen van een auto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                objDataSet = client.auto_getDataSetAuto()
                objDataTable = objDataSet.Tables("tblAuto")
                rowPosition = objDataTable.Rows.Count - 1
                auto_fillFields()

            Catch ex As SoapException
                MessageBox.Show("Fout tijdens het aanspreken van de database." + ControlChars.NewLine _
                                + "Mogelijk werd een foutieve bewerking uitgevoerd.", "Actie geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            MessageBox.Show("Vul alle velden in met correcte waarden.", "Foutieve invoer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    ''' <summary>
    ''' Aanpassen van een auto.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <exception cref="SoapException">Een Soap Exception wordt opgevangen wanneer de communicatie met de webservice misgaat.</exception>
    Private Sub btnAutoAanpassen_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoAanpassen.Click

        Dim gegevens As New ArrayList
        Dim foutieveInvoer As Boolean = False

        gegevens.Add(objDataTable.Rows.Item(rowPosition).Item(0))
        If isString(txtMerk.Text) Then gegevens.Add(txtMerk.Text) Else foutieveInvoer = True
        If isString(txtModel.Text) Then gegevens.Add(txtModel.Text) Else foutieveInvoer = True
        If isString(cbBrandstof.Text) Then gegevens.Add(cbBrandstof.Text) Else foutieveInvoer = True
        If isString(cbTransmissie.Text) Then gegevens.Add(cbTransmissie.Text) Else foutieveInvoer = True
        If isString(txtVermogen.Text) Then gegevens.Add(txtVermogen.Text) Else foutieveInvoer = True
        If isString(txtZitplaatsen.Text) Then gegevens.Add(txtZitplaatsen.Text) Else foutieveInvoer = True
        If isString(txtCarrosserietype.Text) Then gegevens.Add(txtCarrosserietype.Text) Else foutieveInvoer = True
        If isString(txtKilometerstand.Text) Then gegevens.Add(txtKilometerstand.Text) Else foutieveInvoer = True
        If isString(txtBouwjaar.Text) Then gegevens.Add(txtBouwjaar.Text) Else foutieveInvoer = True
        If isString(txtKleur.Text) Then gegevens.Add(txtKleur.Text) Else foutieveInvoer = True
        If isString(txtPrijs.Text) Then gegevens.Add(txtPrijs.Text) Else foutieveInvoer = True

        If foutieveInvoer = False Then
            Try
                Dim result As String
                result = client.auto_update(gegevens.ToArray)
                MessageBox.Show(result, "Aanpassen van een auto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                objDataSet = client.auto_getDataSetAuto()
                objDataTable = objDataSet.Tables("tblAuto")
                auto_fillFields()

            Catch ex As SoapException
                MessageBox.Show("Fout tijdens het aanspreken van de database." + ControlChars.NewLine _
                                + "Mogelijk werd een foutieve bewerking uitgevoerd.", "Actie geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            MessageBox.Show("Vul alle velden in met correcte waarden.", "Foutieve invoer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    ''' <summary>
    ''' Verwijderen van een auto.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <exception cref="SoapException">Een Soap Exception wordt opgevangen wanneer de communicatie met de webservice misgaat.</exception>
    ''' <exception cref="IndexOutOfRangeException">Een Index Out Of Range Exception wordt opgevangen wanneer de positie naar een onbestaand record verwijst.</exception>
    Private Sub btnAutoVerwijderen_Click(sender As System.Object, e As System.EventArgs) Handles btnAutoVerwijderen.Click

        If (askPermission("Bent u zeker dat u deze record wilt verwijderen?" + ControlChars.CrLf + "Deze actie is onomkeerbaar.")) Then

            Try
                Dim autoID As Integer
                autoID = objDataTable.Rows.Item(rowPosition).Item(0)

                Dim result As String
                result = client.auto_remove(autoID)
                MessageBox.Show(result, "Verwijderen van een auto", MessageBoxButtons.OK, MessageBoxIcon.Information)

                objDataSet = client.auto_getDataSetAuto()
                objDataTable = objDataSet.Tables("tblAuto")
                If Not rowPosition = 0 Then rowPosition -= 1
                auto_fillFields()

            Catch ex As SoapException
                MessageBox.Show("Fout tijdens het aanspreken van de database." + ControlChars.NewLine _
                                + "Mogelijk werd een foutieve bewerking uitgevoerd.", "Actie geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As IndexOutOfRangeException
                MessageBox.Show("Geen record om te bewerken.", "Geen record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If

    End Sub

    ''' <summary>
    ''' Het vullen van de velden op het formulier.
    ''' </summary>
    ''' <exception cref="IndexOutOfRangeException">Een Index Out Of Range Exception wordt opgevangen wanneer de positie naar een onbestaand record verwijst.</exception>
    ''' <exception cref="NullReferenceException">Een Null Reference Exception wordt opgevangen wanneer er uit iets onbestaand data wordt uitgehaald.</exception>
    Private Sub auto_fillFields()

        Try
            statusModus.Text = "Modus: Data bewerken"
            statusTabel.Text = "Tabel: tblAuto"

            Dim row As DataRow = objDataTable.Rows.Item(rowPosition)
            txtMerk.Text = row.Item(1)
            txtModel.Text = row.Item(2)
            cbBrandstof.SelectedItem = row.Item(3)
            cbTransmissie.SelectedItem = row.Item(4)
            txtVermogen.Text = row.Item(5)
            txtZitplaatsen.Text = row.Item(6)
            txtCarrosserietype.Text = row.Item(7)
            txtKilometerstand.Text = row.Item(8)
            txtBouwjaar.Text = row.Item(9)
            txtKleur.Text = row.Item(10)
            txtPrijs.Text = row.Item(11)

            statusRecord.Text = "Record: " + (rowPosition + 1).ToString + "/" + objDataTable.Rows.Count.ToString

        Catch ex As IndexOutOfRangeException
            clearDataAuto()
        Catch ex As NullReferenceException
            clearDataAuto()
        End Try

    End Sub

    ''' <summary>
    ''' Alle velden leegmaken.
    ''' </summary>
    Public Sub clearDataAuto()

        statusRecord.Text = "Record: 0/0"
        txtMerk.Text = ""
        txtModel.Text = ""
        cbBrandstof.SelectedItem = ""
        cbTransmissie.SelectedItem = ""
        txtVermogen.Text = ""
        txtZitplaatsen.Text = ""
        txtCarrosserietype.Text = ""
        txtKilometerstand.Text = ""
        txtBouwjaar.Text = ""
        txtKleur.Text = ""
        txtPrijs.Text = ""

    End Sub

#End Region

#Region "Klant"

    ''' <summary>
    ''' De dataset en datatable wordt gevuld met gegevens van alle klanten.
    ''' Alle velden worden ingevuld met gegevens van de eerste rij in de tabel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub pnlKlant_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles pnlKlant.VisibleChanged

        If pnlKlant.Visible = True Then
            objDataSet = client.klant_getDataSetKlant()
            objDataTable = objDataSet.Tables("tblKlant")
            rowPosition = 0
            klant_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De eerste positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnKlantFirst_Click(sender As System.Object, e As System.EventArgs) Handles btnKlantFirst.Click

        rowPosition = 0
        klant_fillFields()

    End Sub

    ''' <summary>
    ''' De vorige positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnKlantPrevious_Click(sender As System.Object, e As System.EventArgs) Handles btnKlantPrevious.Click

        If Not rowPosition = 0 Then
            rowPosition -= 1
            klant_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De volgende positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnKlantNext_Click(sender As System.Object, e As System.EventArgs) Handles btnKlantNext.Click

        If Not rowPosition = objDataTable.Rows.Count - 1 Then
            rowPosition += 1
            klant_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De laatse positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnKlantLast_Click(sender As System.Object, e As System.EventArgs) Handles btnKlantLast.Click

        rowPosition = objDataTable.Rows.Count - 1
        klant_fillFields()

    End Sub

    ''' <summary>
    ''' Aanpassen van een klant.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <exception cref="SoapException">Een Soap Exception wordt opgevangen wanneer de communicatie met de webservice misgaat.</exception>
    Private Sub btnKlantAanpassen_Click(sender As System.Object, e As System.EventArgs) Handles btnKlantAanpassen.Click

        Dim gegevens As New ArrayList
        Dim foutieveInvoer As Boolean = False

        gegevens.Add(objDataTable.Rows.Item(rowPosition).Item(0))
        If isString(txtVoornaam.Text) Then gegevens.Add(txtVoornaam.Text) Else foutieveInvoer = True
        If isString(txtAchternaam.Text) Then gegevens.Add(txtAchternaam.Text) Else foutieveInvoer = True
        If isString(txtAdres.Text) Then gegevens.Add(txtAdres.Text) Else foutieveInvoer = True
        If isNumber(txtPostcode.Text) And isPostcode(txtPostcode.Text) Then gegevens.Add(txtPostcode.Text) Else foutieveInvoer = True
        If isString(txtRijksregisternummer.Text) Then gegevens.Add(txtRijksregisternummer.Text) Else foutieveInvoer = True
        If isString(txtTelefoonnummer.Text) Then gegevens.Add(txtTelefoonnummer.Text) Else foutieveInvoer = True
        If isString(txtGSMnummer.Text) Then gegevens.Add(txtGSMnummer.Text) Else foutieveInvoer = True
        If IsDate(txtGeboortedatum.Text) Then gegevens.Add(txtGeboortedatum.Text) Else foutieveInvoer = True

        If foutieveInvoer = False Then
            Try
                Dim result As String
                result = client.klant_update(gegevens.ToArray)
                MessageBox.Show(result, "Aanpassen van een klant", MessageBoxButtons.OK, MessageBoxIcon.Information)

                objDataSet = client.klant_getDataSetKlant()
                objDataTable = objDataSet.Tables("tblKlant")
                klant_fillFields()
            Catch ex As SoapException
                MessageBox.Show("Fout tijdens het aanspreken van de database." + ControlChars.NewLine _
                                + "Mogelijk werd een foutieve bewerking uitgevoerd.", "Actie geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            MessageBox.Show("Vul alle velden in met correcte waarden.", "Foutieve invoer", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    ''' <summary>
    ''' Verwijderen van een klant.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <exception cref="SoapException">Een Soap Exception wordt opgevangen wanneer de communicatie met de webservice misgaat.</exception>
    ''' <exception cref="IndexOutOfRangeException">Een Index Out Of Range Exception wordt opgevangen wanneer de positie naar een onbestaand record verwijst.</exception>
    Private Sub btnKlantVerwijderen_Click(sender As System.Object, e As System.EventArgs) Handles btnKlantVerwijderen.Click

        If (askPermission("Bent u zeker dat u deze record wilt verwijderen?" + ControlChars.NewLine + "Deze actie is onomkeerbaar.")) Then
            Try
                Dim klantID As Integer
                klantID = objDataTable.Rows.Item(rowPosition).Item(0)

                Dim result As String
                result = client.klant_remove(klantID)
                MessageBox.Show(result, "Verwijderen van een klant", MessageBoxButtons.OK, MessageBoxIcon.Information)

                objDataSet = client.klant_getDataSetKlant()
                objDataTable = objDataSet.Tables("tblKlant")
                If Not rowPosition = 0 Then rowPosition -= 1
                klant_fillFields()

            Catch ex As SoapException
                MessageBox.Show("Fout tijdens het aanspreken van de database." + ControlChars.NewLine _
                                + "Mogelijk werd een foutieve bewerking uitgevoerd.", "Actie geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As IndexOutOfRangeException
                MessageBox.Show("Geen record om te bewerken.", "Geen record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

        End If
    End Sub

    ''' <summary>
    ''' Het vullen van de velden op het formulier.
    ''' </summary>
    ''' <exception cref="IndexOutOfRangeException">Een Index Out Of Range Exception wordt opgevangen wanneer de positie naar een onbestaand record verwijst.</exception>
    ''' <exception cref="NullReferenceException">Een Null Reference Exception wordt opgevangen wanneer er uit iets onbestaand data wordt uitgehaald.</exception>
    Private Sub klant_fillFields()

        Try

            statusModus.Text = "Modus: Data bewerken"
            statusTabel.Text = "Tabel: tblKlant"

            Dim row As DataRow = objDataTable.Rows.Item(rowPosition)
            txtVoornaam.Text = row.Item(1)
            txtAchternaam.Text = row.Item(2)
            txtAdres.Text = row.Item(3)
            txtPostcode.Text = row.Item(4)
            txtRijksregisternummer.Text = row.Item(5)
            txtTelefoonnummer.Text = row.Item(6)
            txtGSMnummer.Text = row.Item(7)
            txtGeboortedatum.Text = row.Item(8)

            statusRecord.Text = "Record: " + (rowPosition + 1).ToString + "/" + objDataTable.Rows.Count.ToString

        Catch ex As IndexOutOfRangeException
            clearDataKlant()
        Catch ex As NullReferenceException
            clearDataKlant()
        End Try

    End Sub

    ''' <summary>
    ''' Alle velden leegmaken.
    ''' </summary>
    Public Sub clearDataKlant()
        statusRecord.Text = "Record: 0/0"
        txtVoornaam.Text = ""
        txtAchternaam.Text = ""
        txtAdres.Text = ""
        txtPostcode.Text = ""
        txtRijksregisternummer.Text = ""
        txtTelefoonnummer.Text = ""
        txtGSMnummer.Text = ""
        txtGeboortedatum.Text = ""
    End Sub

#End Region

#Region "Verhuur"

    ''' <summary>
    ''' De dataset en datatable wordt gevuld met gegevens van alle verhuren.
    ''' Alle velden worden ingevuld met gegevens van de eerste rij in de tabel.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub pnlVerhuurdeAuto_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles pnlVerhuurdeAuto.VisibleChanged

        If pnlVerhuurdeAuto.Visible = True Then
            objDataSet = client.verhuur_getDataSetVerhuur()
            objDataTable = objDataSet.Tables("tblVerhuurdeWagens")
            rowPosition = 0
            verhuur_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De eerste positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnVerhuurFirst_Click(sender As System.Object, e As System.EventArgs) Handles btnVerhuurFirst.Click

        rowPosition = 0
        verhuur_fillFields()

    End Sub

    ''' <summary>
    ''' De vorige positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnVerhuurPrevious_Click(sender As System.Object, e As System.EventArgs) Handles btnVerhuurPrevious.Click

        If Not rowPosition = 0 Then
            rowPosition -= 1
            verhuur_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De volgende positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnVerhuurNext_Click(sender As System.Object, e As System.EventArgs) Handles btnVerhuurNext.Click

        If Not rowPosition = objDataTable.Rows.Count - 1 Then
            rowPosition += 1
            verhuur_fillFields()
        End If

    End Sub

    ''' <summary>
    ''' De laatse positie wordt geselecteerd.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnVerhuurLast_Click(sender As System.Object, e As System.EventArgs) Handles btnVerhuurLast.Click

        rowPosition = objDataTable.Rows.Count - 1
        verhuur_fillFields()

    End Sub

    ''' <summary>
    ''' Aanpassen van een verhuur.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <exception cref="SoapException">Een Soap Exception wordt opgevangen wanneer de communicatie met de webservice misgaat.</exception>
    Private Sub btnVerhuurAanpassen_Click(sender As System.Object, e As System.EventArgs) Handles btnVerhuurAanpassen.Click

        Dim gegevens As New ArrayList
        Dim foutieveInvoer As Boolean = False

        Try
            gegevens.Add(objDataTable.Rows.Item(rowPosition).Item(0))
            If IsDate(txtVerhuurd.Text) Then gegevens.Add(txtVerhuurd.Text) Else foutieveInvoer = True
            If IsDate(txtTeruggave.Text) Then gegevens.Add(txtTeruggave.Text) Else foutieveInvoer = True

            If foutieveInvoer = False Then
                Dim result As String
                result = client.verhuur_update(gegevens.ToArray)
                MessageBox.Show(result, "Aanpassen van de verhuur datum.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                objDataSet = client.verhuur_getDataSetVerhuur()
                objDataTable = objDataSet.Tables("tblVerhuurdeWagens")
                verhuur_fillFields()
            Else
                MessageBox.Show("Vul alle velden in met correcte waarden.", "Foutieve invoer", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As SoapException
            MessageBox.Show("Fout tijdens het aanspreken van de database." + ControlChars.NewLine _
                            + "Mogelijk werd een foutieve bewerking uitgevoerd.", "Actie geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As IndexOutOfRangeException
            MessageBox.Show("Geen record om te bewerken.", "Geen record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    ''' <summary>
    ''' Verwijderen van een verhuur.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <exception cref="SoapException">Een Soap Exception wordt opgevangen wanneer de communicatie met de webservice misgaat.</exception>
    ''' <exception cref="IndexOutOfRangeException">Een Index Out Of Range Exception wordt opgevangen wanneer de positie naar een onbestaand record verwijst.</exception>
    Private Sub txtVerhuurVerwijderen_Click(sender As System.Object, e As System.EventArgs) Handles txtVerhuurVerwijderen.Click

        If (askPermission("Bent u zeker dat u deze record wilt verwijderen?" + ControlChars.CrLf + "Deze actie is onomkeerbaar.")) Then
            Try
                Dim verhuurID As Integer
                verhuurID = objDataTable.Rows.Item(rowPosition).Item(0)

                Dim result As String
                result = client.verhuur_remove(verhuurID)
                MessageBox.Show(result, "Verwijderen van een verhuurde auto.", MessageBoxButtons.OK, MessageBoxIcon.Information)

                objDataSet = client.verhuur_getDataSetVerhuur()
                objDataTable = objDataSet.Tables("tblVerhuurdeWagens")

                If Not rowPosition = 0 Then rowPosition -= 1
                verhuur_fillFields()

            Catch ex As SoapException
                MessageBox.Show("Fout tijdens het aanspreken van de database." + ControlChars.NewLine _
                                + "Mogelijk werd een foutieve bewerking uitgevoerd.", "Actie geannuleerd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As IndexOutOfRangeException
                MessageBox.Show("Geen record om te bewerken.", "Geen record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try

        End If

    End Sub

    ''' <summary>
    ''' Het vullen van de velden op het formulier.
    ''' </summary>
    ''' <exception cref="IndexOutOfRangeException">Een Index Out Of Range Exception wordt opgevangen wanneer de positie naar een onbestaand record verwijst.</exception>
    ''' <exception cref="NullReferenceException">Een Null Reference Exception wordt opgevangen wanneer er uit iets onbestaand data wordt uitgehaald.</exception>
    Private Sub verhuur_fillFields()

        Try
            statusModus.Text = "Modus: Data bewerken"
            statusTabel.Text = "Tabel: tblVerhuurdeWagens"

            Dim rowVerhuur As DataRow = objDataTable.Rows.Item(rowPosition)
            Dim objDataTableAuto As DataTable = objDataSet.Tables("tblAuto")
            Dim objDataTableKlant As DataTable = objDataSet.Tables("tblKlant")

            txtVerhuurID.Text = rowVerhuur.Item(0)
            txtVerhuurd.Text = rowVerhuur.Item(3)
            txtTeruggave.Text = rowVerhuur.Item(4)

            lblAantalDagen.Text = "Nog " + DateDiff(DateInterval.Day, rowVerhuur.Item(3), rowVerhuur.Item(4)).ToString + " dagen verhuurd."

            For Each rowAuto As DataRow In objDataTableAuto.Rows
                If rowAuto.Item(0) = rowVerhuur.Item(1) Then
                    lblWagennummer.Text = "Wagennummer " + rowAuto.Item(0).ToString
                    lblMerk.Text = "Automerk " + rowAuto.Item(1)
                    lblModel.Text = "Model " + rowAuto.Item(2)
                    lblCarroserietype.Text = "Carroserietype " + rowAuto.Item(7)
                End If
            Next

            For Each rowKlant As DataRow In objDataTableKlant.Rows
                If rowKlant.Item(0) = rowVerhuur.Item(2) Then
                    lblKlantnummer.Text = "Klantnummer " + rowKlant.Item(0).ToString
                    lblVoornaamNaam.Text = "Verhuurd aan " + rowKlant.Item(1) + " " + rowKlant.Item(2)
                End If
            Next

            statusRecord.Text = "Record: " + (rowPosition + 1).ToString + "/" + objDataTable.Rows.Count.ToString
        Catch ex As IndexOutOfRangeException
            clearDataVerhuur()
        Catch ex As NullReferenceException
            clearDataVerhuur()
        End Try
    End Sub

    ''' <summary>
    ''' Alle velden leegmaken.
    ''' </summary>
    Public Sub clearDataVerhuur()
        statusRecord.Text = "Record: 0/0"
        txtVerhuurID.Text = "Geen data"
        txtVerhuurd.Text = ""
        txtTeruggave.Text = ""
        lblKlantnummer.Text = "Geen data"
        lblVoornaamNaam.Text = ""
        lblMerk.Text = ""
        lblWagennummer.Text = "Geen data"
        lblAantalDagen.Text = ""
        lblModel.Text = ""
        lblCarroserietype.Text = ""
    End Sub

#End Region

#Region "MenuItems"

    ''' <summary>
    ''' Het Auto panel wordt zichtbaar gemaakt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub miAuto_Click(sender As System.Object, e As System.EventArgs) Handles miAuto.Click

        pnlAuto.Visible = True
        pnlAuto.Location = New Point(0, 24)
        pnlKlant.Visible = False
        pnlDataGridView.Visible = False
        pnlVerhuurdeAuto.Visible = False
        pnlStart.Visible = False

    End Sub

    ''' <summary>
    ''' Het Klant panel wordt zichtbaar gemaakt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub miKlant_Click(sender As System.Object, e As System.EventArgs) Handles miKlant.Click

        pnlAuto.Visible = False
        pnlKlant.Visible = True
        pnlKlant.Location = New Point(0, 24)
        pnlDataGridView.Visible = False
        pnlVerhuurdeAuto.Visible = False
        pnlStart.Visible = False

    End Sub

    ''' <summary>
    ''' Het VerhuurdeWagen panel wordt zichtbaar gemaakt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub miVerhuurdeWagen_Click(sender As System.Object, e As System.EventArgs) Handles miVerhuurdeWagen.Click

        pnlAuto.Visible = False
        pnlKlant.Visible = False
        pnlDataGridView.Visible = False
        pnlVerhuurdeAuto.Visible = True
        pnlVerhuurdeAuto.Location = New Point(0, 24)
        pnlStart.Visible = False

    End Sub

    ''' <summary>
    ''' Het AutoTonen panel wordt zichtbaar gemaakt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub miAutoTonen_Click(sender As System.Object, e As System.EventArgs) Handles miAutoTonen.Click

        pnlAuto.Visible = False
        pnlKlant.Visible = False
        pnlDataGridView.Visible = True
        pnlDataGridView.Location = New Point(0, 24)
        pnlVerhuurdeAuto.Visible = False
        pnlStart.Visible = False

        If cbTabel.SelectedItem = "tblAuto" Then
            datatableVullen(cbTabel.SelectedItem)
        Else
            cbTabel.SelectedItem = "tblAuto"
        End If

    End Sub

    ''' <summary>
    ''' Het KlantenTonen panel wordt zichtbaar gemaakt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub miKlantenTonen_Click(sender As System.Object, e As System.EventArgs) Handles miKlantenTonen.Click

        pnlAuto.Visible = False
        pnlKlant.Visible = False
        pnlDataGridView.Visible = True
        pnlDataGridView.Location = New Point(0, 24)
        pnlVerhuurdeAuto.Visible = False
        pnlStart.Visible = False

        If cbTabel.SelectedItem = "tblKlant" Then
            datatableVullen(cbTabel.SelectedItem)
        Else
            cbTabel.SelectedItem = "tblKlant"
        End If

    End Sub

    ''' <summary>
    ''' Het VerhuurdeAutosTonen panel wordt zichtbaar gemaakt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub miVerhuurdeAutosTonen_Click(sender As System.Object, e As System.EventArgs) Handles miVerhuurdeAutosTonen.Click

        pnlAuto.Visible = False
        pnlKlant.Visible = False
        pnlDataGridView.Visible = True
        pnlDataGridView.Location = New Point(0, 24)
        pnlVerhuurdeAuto.Visible = False
        pnlStart.Visible = False

        If cbTabel.SelectedItem = "tblVerhuurdeWagens" Then
            datatableVullen(cbTabel.SelectedItem)
        Else
            cbTabel.SelectedItem = "tblVerhuurdeWagens"
        End If

    End Sub

    ''' <summary>
    ''' Het Startscherm wordt zichtbaar gemaakt.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub StartToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles StartToolStripMenuItem1.Click

        pnlAuto.Visible = False
        pnlKlant.Visible = False
        pnlDataGridView.Visible = False
        pnlVerhuurdeAuto.Visible = False
        pnlStart.Visible = True
        statusModus.Text = "Modus: " + statusConnectie
        statusTabel.Text = "Tabel: Geen"
        statusRecord.Text = "Record: Geen"

    End Sub

    ''' <summary>
    ''' De verbinding met de database wordt getest.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TestConnectieToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TestConnectieToolStripMenuItem.Click

        connectionTest()
        If statusConnectie = "Verbonden" Then
            MessageBox.Show("De applicatie heeft verbinding met de database.", "Verbinding geslaagd", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("De applicatie heeft geen verbinding tot stand kunnen brengen.", "Geen verbinding met de database", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    ''' <summary>
    ''' Het programma wordt afgesloten.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub AfsluitenToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles AfsluitenToolStripMenuItem.Click

        Dispose()
        Me.Close()

    End Sub

#End Region

#Region "LijstTonen"

    ''' <summary>
    ''' Afhankelijk van de tabel naam wordt de combobox gevuld met de kolomnamen en de datagrid gevuld met de rijen.
    ''' </summary>
    ''' <param name="table"></param>
    Private Sub datatableVullen(table As String)

        dgvGegevens.Rows.Clear()
        dgvGegevens.Columns.Clear()

        Select Case table
            Case "tblAuto"
                objDataSet = client.auto_getDataSetAuto()
            Case "tblKlant"
                objDataSet = client.klant_getDataSetKlant()
            Case "tblVerhuurdeWagens"
                objDataSet = client.verhuur_getDataSetVerhuur()
            Case Else
                MessageBox.Show("Ongeldige tabel.", "Fout", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
        End Select

        objDataTable = objDataSet.Tables(table)
        cbFilter.Items.Clear()
        cbFilter.Items.Add("Geen enkel veld")

        For Each column As DataColumn In objDataTable.Columns
            dgvGegevens.Columns.Add("cn" + column.ColumnName, column.ColumnName)
            cbFilter.Items.Add(column.ColumnName)
        Next

        cbFilter.SelectedItem = "Geen enkel veld"

        For Each row As DataRow In objDataTable.Rows
            dgvGegevens.Rows.Add(row.ItemArray)
        Next

        statusRecord.Text = "Record: " + objDataTable.Rows.Count.ToString + " records"
        statusModus.Text = "Modus: Data weergeven"

    End Sub

    ''' <summary>
    ''' Wanneer een andere tabel wordt geselecteerd vernieuwd de combobox met de kolomnamen en de datagrid.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub cbTabel_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbTabel.SelectedIndexChanged

        datatableVullen(cbTabel.SelectedItem)
        statusTabel.Text = "Tabel: " + cbTabel.SelectedItem

    End Sub

    ''' <summary>
    ''' De filter wordt toegepast op de geselecteerde kolom met de waarde in de textbox.
    ''' De datagrid wordt opnieuw gevuld, rekening houdend met de filter.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnFilter.Click

        Dim value As String = txtWaarde.Text
        Dim column As Integer = cbFilter.SelectedIndex - 1

        dgvGegevens.Rows.Clear()

        If Not column = -1 Then
            For Each row As DataRow In objDataTable.Rows
                If row.Item(column).ToString = value Then
                    dgvGegevens.Rows.Add(row.ItemArray)
                End If
            Next
        Else
            For Each row As DataRow In objDataTable.Rows
                dgvGegevens.Rows.Add(row.ItemArray)
            Next
        End If

    End Sub

#End Region

    ''' <summary>
    ''' Algemene instellingen worden geladen bij de Form_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.Size = New Size(460, 342)
        pnlStart.Size = New Size(455, 270)
        pnlAuto.Visible = False
        pnlKlant.Visible = False
        pnlDataGridView.Visible = False
        statusTabel.Text = "Tabel: Geen"
        statusRecord.Text = "Record: Geen"

        connectionTest()

    End Sub

    ''' <summary>
    ''' Testen van de verbinding met de database.
    ''' </summary>
    Public Sub connectionTest()

        Dim conn As Boolean = client.connectionTest()
        If conn = True Then
            statusConnectie = "Verbonden"
            BeheerDatabaseToolStripMenuItem.Enabled = True
            OphalenGegevensToolStripMenuItem.Enabled = True
        Else
            statusConnectie = "Niet verbonden"
            BeheerDatabaseToolStripMenuItem.Enabled = False
            OphalenGegevensToolStripMenuItem.Enabled = False
        End If
        statusModus.Text = "Modus: " + statusConnectie

    End Sub

End Class
