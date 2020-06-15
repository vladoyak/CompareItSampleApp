using SourceSystem.Db;
using SourceSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SourceSystem.Services
{
    public class InsuranceService: IInsuranceService
    {
        public SqliteDbContext _context;

        public InsuranceService(SqliteDbContext context)
        {
            _context = context;
        }

        public List<Insurance> Get()
        {
            return _context.Insurances.ToList();
        }

        public Insurance Get(int id)
        {
            return _context.Insurances.Where(i => i.Id == id).SingleOrDefault();
        }

        public int Add(Insurance insurance)
        {
            _context.Insurances.Add(insurance);
            _context.SaveChanges();
            return insurance.Id;
        }

        public void Delete(int id)
        {
            var toDelete = _context.Insurances.Where(c => c.Id == id).FirstOrDefault();
            _context.Remove(toDelete);
            _context.SaveChanges();
        }
    }
}
