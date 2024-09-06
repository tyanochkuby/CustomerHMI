using CustomersTable.Data.Interfaces;
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

        public async Task<HttpResponseMessage> AddCustomerAsync(Customer customer)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers/add", customer);
            return response;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Customer>>("api/customers/getall");
        }

        public async Task<HttpResponseMessage> SetCustomersAsync(List<Customer> customers)
        {
            var response = await _httpClient.PostAsJsonAsync("api/customers/setall", customers);
            return response;
        }

    }
}
