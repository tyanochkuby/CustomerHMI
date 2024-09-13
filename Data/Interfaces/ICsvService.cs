using Microsoft.AspNetCore.Components.Forms;

namespace CustomersTable.Data.Interfaces
{
    public interface ICsvService
    {
        public Task<List<Customer>> GetCustomersFromCsv(InputFileChangeEventArgs e);
        public Task<string> GetCsvFromCustomerList(List<Customer> customerList);

    }
}
