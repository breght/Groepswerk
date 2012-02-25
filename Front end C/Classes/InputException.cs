using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Front_end_C.Classes
{
    class InputException : Exception
    {
        public InputException() : base("Vul alle velden correct in") { }

        public InputException(string message) : base(message) { }
    }
}
