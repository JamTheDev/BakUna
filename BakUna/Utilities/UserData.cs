using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BakUna.Utilities
{
    [DataContract]
    public class UserData
    {
        [DataMember] public string name;
        [DataMember] public string doses;
        [DataMember] public string vaccine_brand;
        [DataMember] public string first_dose_date;
        [DataMember] public string second_dose_date;
        [DataMember] public string is_vaccinated;
        [DataMember] public string vaccinator;
        [DataMember] public string vaccination_site;
        [DataMember] public UserDataBooster booster_shot_info;
    }

    public class UserDataBooster
    {
        [DataMember] public string booster_brand;
        [DataMember] public string vaccinator;
        [DataMember] public string vaccination_site;
    }
}
