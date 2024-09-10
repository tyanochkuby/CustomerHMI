using CustomersTable.Data;
using CustomersTable.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using static MudBlazor.Icons;

namespace CustomersTable.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new();
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task DeleteCustomersAsync(IEnumerable<int> customerIds)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers/delete", customerIds);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customers = await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers/get");
            foreach(var customer in customers)
            {
                customer.Age = Customer.CalculateAge(customer.BirthDate);
            }
            return customers;
        }

        public async Task UpdateCustomersAsync(List<Customer> customers)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers/update", customers);
        }
    }
}
