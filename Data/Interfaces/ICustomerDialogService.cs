namespace CustomersTable.Data.Interfaces
{
    public interface ICustomerDialogService
    {
        public Task<Customer> OpenCreateCustomerDialogAsync();
    }
}
