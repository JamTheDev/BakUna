using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BakUna.Utilities
{
    public class DeclareVacStatus
    {
        public UserData vaccinated { get; set; }
        public UserData non_vaccinated { get; set; }
    }
    public class UserVaccinationDetails
    {
        public List<UserData> vaccinated { get; set; }
        public List<UserData> non_vaccinated { get; set; }
    }
    public class UserData
    {
        public string _id { get; set; }
        public string name { get; set; }
        public int doses { get; set; }
        public string vaccine_brand { get; set; }
        public string first_dose_date { get; set; }
        public string second_dose_date { get; set; }
        public bool is_vaccinated { get; set; }
        public string vaccinator { get; set; }
        public string vaccination_site { get; set; }
        public UserDataBooster booster_shot_info { get; set; }
    }

    public class UserDataBooster
    {
        public string booster_brand { get; set; }
        public string vaccinator { get; set; }
        public string vaccination_site { get; set; }
    }
}
