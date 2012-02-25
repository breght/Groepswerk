using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Front_end_C.Classes
{
    static class Gehuurde_Auto
    {
        public static String Merk { get; set; }
        public static String Model { get; set; }
        public static int AutoID { get; set; }
        public static double Prijs { get; set; }

        /// <summary>
        /// Methode om een auto te huren.
        /// </summary>
        /// <param name="Klant_ID"></param>
        /// <param name="Auto_ID"></param>
        /// <param name="Van"></param>
        /// <param name="Tot"></param>
        /// <returns>boolean</returns>

        public static Boolean Huur(int Klant_ID,int Auto_ID,DateTime Van, DateTime Tot)
        {
            try
            {
                WebService.WebService ws = new WebService.WebService();
                ArrayList al = new ArrayList();

                if (Van > Tot)
                {
                    throw new InputException("Gelieve twee correcte data te kiezen.");
                }

                al.Add(Klant_ID);
                al.Add(Auto_ID);
                al.Add(Van);
                al.Add(Tot);

                //Toevoegen bij tblAuto dat deze auto niet meer beschikbaar is !
                //Tweede Test !

                if (ws.verhuur_add(al.ToArray()))
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
