using SourceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SourceSystem.Services
{
    public interface IInsuranceService
    {
        List<Insurance> Get();
        Insurance Get(int id);
        int Add(Insurance insurance);
        void Delete(int id);
    }
}
