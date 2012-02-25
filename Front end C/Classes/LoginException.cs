using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Front_end_C.Classes
{
    class LoginException : Exception
    {
        public LoginException() : base("Login niet gelukt.") {}

        public LoginException(string message) : base(message) {}
    }
}
