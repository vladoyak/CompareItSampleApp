using FrontendAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FrontendConsoleApp.Client
{
    class CustomerService
    {
        HttpClient _client;

        public CustomerService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:53879");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Customer>> Get()
        {
            try
            {             
                HttpResponseMessage response = await _client.GetAsync("http://localhost:53879/customer");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<List<Customer>>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
