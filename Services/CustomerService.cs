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
        private readonly IUserService _userService;
        private readonly HttpClient _httpClient;
        public CustomerService(HttpClient httpClient, IUserService userService)
        {
            _userService = userService;
            _httpClient = httpClient;
        }

        public async Task DeleteCustomersAsync(IEnumerable<int> customerIds)
        {
            var queryString = string.Join("&", customerIds.Select(id => $"customerIds={id}"));
            var response = await _httpClient.DeleteAsync($"api/customer/delete?{queryString}");
            if (response.IsSuccessStatusCode)
            {
                // Handle success
            }
            else
            {
                // Handle failure
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Update failed: {errorMessage}");
            }
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var customers = await _httpClient.GetFromJsonAsync<List<Customer>>("api/customer/get");
            foreach(var customer in customers)
            {
                customer.Age = Customer.CalculateAge(customer.BirthDate);
            }
            return customers;
        }

        public async Task UpdateCustomersAsync(List<Customer> customers)
        {
            var userId = await _userService.GetLoggedInUserIdAsync();
            foreach (var customer in customers)
            {
                customer.UserId = userId;
            }
            var response = await _httpClient.PutAsJsonAsync("api/customer/update", customers);
            if (response.IsSuccessStatusCode)
            {
                // Handle success
            }
            else
            {
                // Handle failure
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Update failed: {errorMessage}");
            }
        }
    }
}
