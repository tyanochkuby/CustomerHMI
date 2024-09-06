using Microsoft.AspNetCore.Mvc;

namespace CustomersTable.Data.Interfaces
{
    public interface ICustomerService
    {
        public Task<List<Customer>> GetCustomersAsync();

        public Task UpdateCustomersAsync(List<Customer> customers);

        public Task CreateCustomersAsync(List<Customer> customers);

        public Task DeleteCustomersAsync(IEnumerable<Guid> customerIds);
    }
}
