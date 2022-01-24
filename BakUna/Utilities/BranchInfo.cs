using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BakUna.Utilities
{

    public class BranchInfo
    {
        public Dictionary<string, VaccinationCount> branches { get; set; }
    }

    public class VaccinationCount
    {
        public int vaccinated_count { get; set; }
        public int non_vaccinated { get; set; }
    }
}
