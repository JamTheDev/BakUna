using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BakUna.Utilities
{
    class Authentication
    {
        public int response { get; set; }

        public bool authenticated
        {
            get { return response == 1; }
        }

    }
}
