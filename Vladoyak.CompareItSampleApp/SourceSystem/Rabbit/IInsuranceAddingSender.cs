using SourceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SourceSystem.Rabbit
{
    public interface IInsuranceAddingSender
    {
        void SendInsurance(Insurance insurance);
    }
}
