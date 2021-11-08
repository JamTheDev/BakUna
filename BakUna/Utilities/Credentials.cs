using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BakUna.Utilities
{
    [DataContract]
    class Credentials
    {
        [DataMember] public string user_id;
        [DataMember] public string password;
        public Credentials()
        {

        }
    }
}
