using FrontendAPI.Db;
using FrontendAPI.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendAPI.Services
{
    public class CustomerService: ICustomerService
    {
        private LiteDatabase _liteDb;
        private ILiteCollection<Customer> _liteColl;

        public CustomerService(ILiteDbContext liteDbContext)
        {
            _liteDb = liteDbContext.Database;
            _liteColl = _liteDb.GetCollection<Customer>("Customer");
        }

        public IEnumerable<Customer> FindAll()
        {
            return _liteColl.FindAll();
        }

        public Customer FindOne(int id)
        {
            return _liteColl.Find(c => c.Id == id).FirstOrDefault();
        }

        public int Insert(Customer customer)
        {
            return _liteColl.Insert(customer);
        }

        public bool Delete(int id)
        {
            return _liteColl.Delete(id);
        }
    }
}
