Public Module Methods
    ''' <summary>
    ''' Nagaan of de ingegeven waarde een geldige string is.
    ''' </summary>
    ''' <param name="something">Een waarde van het type string</param>
    ''' <returns>Een True value als de waarde geldig is, anders een False value.</returns>
    Public Function isString(something As String) As Boolean

        If Not something.Equals("") And something <> Nothing Then
            Return True
        End If

        Return False

    End Function
    ''' <summary>
    ''' Nagaan of de ingegeven waarde een geldig nummer is.
    ''' </summary>
    ''' <param name="something">Een waarde van het type string</param>
    ''' <returns>Een True value als de waarde geldig is, anders een False value.</returns>
    Public Function isNumber(something As String) As Boolean

        If Not something.Equals("") And something <> Nothing And IsNumeric(something) Then
            Return True
        End If

        Return False

    End Function
    ''' <summary>
    ''' Nagaan of de ingegeven waarde een geldige postcode is.
    ''' </summary>
    ''' <param name="something">Een waarde van het type string</param>
    ''' <returns>Een True value als de waarde geldig is, anders een False value.</returns>
    Public Function isPostcode(something As String) As Boolean

        If Not something.Equals("") And something <> Nothing And IsNumeric(something) Then
            If something.Length = 4 Then
                Return True
            End If
        End If

        Return False

    End Function
    ''' <summary>
    ''' Toont een YES/NO messagebox met als inhoud de ingegeven waarden. De keuze wordt doorgegeven als een True/False waarden.
    ''' </summary>
    ''' <param name="text">Een waarde van het type string</param>
    ''' <returns>Het resultaat van de messagebox als een True/False waarde.</returns>
    Public Function askPermission(text As String) As Boolean

        Dim answer As DialogResult

        answer = MessageBox.Show(text, "Waarschuwing!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)

        If answer = DialogResult.Yes Then
            Return True
        End If

        Return False

    End Function

End Module
