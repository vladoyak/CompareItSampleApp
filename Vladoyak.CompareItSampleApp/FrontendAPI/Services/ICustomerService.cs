using FrontendAPI.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontendAPI.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> FindAll();
        Customer FindOne(int id);
        int Insert(Customer customer);
        bool Delete(int id);
    }
}
