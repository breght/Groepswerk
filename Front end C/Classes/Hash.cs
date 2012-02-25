using System;
using System.Text;
using System.Security.Cryptography;

namespace Front_end_C.Classes
{
    static class Hash
    {
        public static bool CheckHash(string original, string hashString)
        {
            string originalHash = GetMD5(original);
            return (originalHash == hashString);
        }

        public static string GetMD5(string text)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            byte[] message = UE.GetBytes(text);

            MD5 hashString = new MD5CryptoServiceProvider();
            string hex = "";

            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}
