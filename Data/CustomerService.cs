using CustomersTable.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MudBlazor.Icons;

namespace CustomersTable.Data
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new();
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCustomersAsync(List<Customer> customers)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers/create", customers);
        }

        public async Task DeleteCustomersAsync(IEnumerable<Guid> customerIds)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers/delete", customerIds);
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers/get");
        }

        public async Task UpdateCustomersAsync(List<Customer> customers)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers/update", customers);
        }
    }
}
