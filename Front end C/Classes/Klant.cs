using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

namespace Front_end_C
{
    static class Klant
    {
        public static int Klant_ID{ get; set; }
        public static string Voornaam { get; set; }
        public static string Achternaam { get; set; }
        public static string Adres { get; set; }
        public static int Postcode { get; set; }
        public static string Emailadres { get; set; }
        public static string Rijksregisternummer { get; set; }
        public static string Telefoonnummer { get; set; }
        public static string GSMNummer { get; set; }
        public static DateTime Geboortedatum { get; set; }
        public static string Wachtwoord { get; set; }

        private static WebService.WebService ws = new WebService.WebService();
        private static DataSet ds;
        private static IDataReader dr;
        private static Regex r = new Regex(@"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", RegexOptions.IgnoreCase); //reguliere expressie om e-mailadressen te controleren.

        /// <summary>
        /// Methode om klanten in te loggen.
        /// Inputcontrole is voorzien, exceptions worden opgeworpen indien hier niet aan voldaan word.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="wachtwoord"></param>
        /// <returns>boolean</returns>

        public static Boolean Login(string email, string wachtwoord)
        {

            try
            {
                if (!(r.IsMatch(email)))
                {
                    throw new Classes.InputException();
                }

                if ((wachtwoord.Length < 4) || (wachtwoord.ToString() == string.Empty))
                {
                    throw new Classes.InputException();
                }

                ds = ws.klant_Login(email, wachtwoord);
                dr = ds.CreateDataReader();
                if (dr.Read())
                {
                    Klant_ID = dr.GetInt32(0);
                    Voornaam = dr.GetString(1);
                    Achternaam = dr.GetString(2);
                    Adres = dr.GetString(3);
                    Postcode = dr.GetInt32(4);
                    Rijksregisternummer = dr.GetString(5);
                    Telefoonnummer = dr.GetString(6);
                    GSMNummer = dr.GetString(7);
                    Geboortedatum = dr.GetDateTime(8);
                    Emailadres = dr.GetString(9);
                    Wachtwoord = dr.GetString(10);

                    return true; //User logged in.
                }
                else
                {
                    return false; //User not found.
                }
            }
            catch (Exception)
            {           
                throw;
            }
        }

        /// <summary>
        /// Methode om een nieuwe klant te registreren.
        /// Inputcontrole is voorzien, InputExceptions worden opgeworpen indien hier niet aan voldaan word.
        /// </summary>
        /// <param name="Voornaam"></param>
        /// <param name="Achternaam"></param>
        /// <param name="Adres"></param>
        /// <param name="Postcode"></param>
        /// <param name="Emailadres"></param>
        /// <param name="Rijksregisternummer"></param>
        /// <param name="Telefoonnummer"></param>
        /// <param name="GSMnummer"></param>
        /// <param name="Geboortedatum"></param>
        /// <param name="Wachtwoord"></param>
        /// <returns>boolean</returns>

        public static Boolean Create(string Voornaam,string Achternaam,string Adres,int Postcode,string Emailadres,string Rijksregisternummer,string Telefoonnummer,string GSMnummer,DateTime Geboortedatum,string Wachtwoord)
        {
            try
            {
                string result;
                ArrayList al = new ArrayList();

                if (Voornaam == "" || Achternaam == "" || Adres == "" || Rijksregisternummer == "" || Telefoonnummer == "" || Wachtwoord == "")
                {
                    throw new Classes.InputException("Vul alle velden correct in.");
                }

                if (!(r.IsMatch(Emailadres)))
                {
                    throw new Classes.InputException("Geeft een correct emailadres in.");
                }

                al.Add(Voornaam);
                al.Add(Achternaam);
                al.Add(Adres);
                al.Add(Postcode);
                al.Add(Rijksregisternummer);
                al.Add(Telefoonnummer);
                al.Add(GSMnummer);
                al.Add(Geboortedatum.Date);
                al.Add(Emailadres);
                al.Add(Wachtwoord);

                result = ws.klant_insert(al.ToArray());

                if (result == "Klant succesvol toegevoegd.")
                {
                    return true; //Klant toegevoegd
                }
                else
                {
                    return false; //Klant niet toegevoegd
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Methode om de gegevens van klanten te updaten.
        /// </summary>
        /// <param name="Voornaam"></param>
        /// <param name="Achternaam"></param>
        /// <param name="Adres"></param>
        /// <param name="Postcode"></param>
        /// <param name="Rijksregisternummer"></param>
        /// <param name="Telefoonnummer"></param>
        /// <param name="GSMnummer"></param>
        /// <param name="Geboortedatum"></param>
        /// <param name="Wachtwoord"></param>
        /// <returns>boolean</returns>

        public static Boolean Update(string Voornaam, string Achternaam, string Adres, int Postcode,string Rijksregisternummer, string Telefoonnummer, string GSMnummer, DateTime Geboortedatum, string Wachtwoord)
        {
            try
            {
                string result;
                ArrayList al = new ArrayList();

                if (Voornaam == "" || Achternaam == "" || Adres == "" || Rijksregisternummer == "" || Telefoonnummer == "" || Wachtwoord == "")
                {
                    throw new Classes.InputException("Vul alle velden correct in.");
                }

                al.Add(Klant_ID);
                al.Add(Voornaam);
                al.Add(Achternaam);
                al.Add(Adres);
                al.Add(Postcode);
                al.Add(Rijksregisternummer);
                al.Add(Telefoonnummer);
                al.Add(GSMnummer);
                al.Add(Geboortedatum.Date);
                al.Add(Wachtwoord);

                result = ws.klant_update(al.ToArray());

                if (result == "Klant succesvol bewerkt.")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {                   
                throw;
            }
        }

        /// <summary>
        /// Methode om de account van een klant te deleten.
        /// </summary>
        /// <returns>boolean</returns>

        public static Boolean Delete()
        {
            try
            {
                if (ws.klant_remove(Klant_ID) == "Klant succesvol verwijderd.")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {               
                throw;
            }
        }

    }
}
