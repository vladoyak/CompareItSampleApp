using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SourceSystem.Models
{
    public class Insurance
    {
        public int Id { get; set; }

        public string CustomerEmail { get; set; }

        public InsuranceType InsuranceType { get; set; }
    }
}
