using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BakUna.Utilities
{
    [DataContract]
    class Authentication
    {
        [DataMember] public int response;

        public bool LoginUser()
        {
            return response == 1;
        }

    }
}
