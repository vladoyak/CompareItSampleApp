using FrontendConsoleApp.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FrontendConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var customerService = new CustomerService();
            var customers = Task.Run(() => customerService.Get()).Result;

            foreach(var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
