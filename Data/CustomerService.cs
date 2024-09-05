using Microsoft.EntityFrameworkCore;

namespace CustomersTable.Data
{
    public class CustomerService
    {
        private readonly List<Customer> _customers;
        private readonly CustomersDbContext _context;

        public CustomerService(CustomersDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

    }
}
