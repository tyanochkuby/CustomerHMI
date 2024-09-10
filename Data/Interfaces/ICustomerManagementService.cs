namespace CustomersTable.Data.Interfaces
{
    public interface ICustomerManagementService
    {
        public Task<List<Customer>> GetCustomersAsync();
        public Task SaveChangesAsync(List<Customer> customers, List<int> customersToDelete, List<Customer> newCustomers);
    }
}
