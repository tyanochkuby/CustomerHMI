﻿using CustomersTable.Data.Interfaces;
using CustomersTable.Data;

namespace CustomersTable.Services
{
    public class CustomerManagementService : ICustomerManagementService
    {
        private readonly ICustomerService _customerService;

        public CustomerManagementService(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return (await _customerService.GetCustomersAsync()).ToList();
        }

        public async Task SaveChangesAsync(List<Customer> customers, List<int> customersToDelete, List<Customer> newCustomers)
        {
            // Update existing customers
            if (customers.Any())
            {
                await _customerService.UpdateCustomersAsync(customers);
            }

            // Delete customers
            if (customersToDelete.Any())
            {
                await _customerService.DeleteCustomersAsync(customersToDelete);
            }

        }
    }
}
