using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Front_end_C
{
    class Admin
    {
        public static int Admin_ID { get; set; }
        public static string Voornaam { get; set; }
        public static string Achternaam { get; set; }
        public static string Emailadres { get; set; }
        public static string wachtwoord { get; set; }

        public static bool LoggedIn { get; set; }

        /// <summary>
        /// Login methode voor Admins.
        /// </summary>
        /// <param name="emailadres"></param>
        /// <param name="wachtwoord"></param>
        /// <returns>boolean</returns>

        public static Boolean Login(string emailadres, string wachtwoord)
        {
            WebService.WebService ws = new WebService.WebService();
            DataSet ds;
            IDataReader dr;

            ds = ws.admin_Login(emailadres, wachtwoord);
            dr = ds.CreateDataReader();

            if (dr.Read()) //Admin gevonden
            {
                Admin_ID = dr.GetInt32(0);
                Voornaam = dr.GetString(1);
                Achternaam = dr.GetString(2);
                Emailadres = dr.GetString(3);
                wachtwoord = dr.GetString(4);

                LoggedIn = true;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
