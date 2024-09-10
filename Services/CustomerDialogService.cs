using CustomersTable.Components;
using CustomersTable.Data;
using CustomersTable.Data.Interfaces;
using MudBlazor;

namespace CustomersTable.Services
{
    public class CustomerDialogService : ICustomerDialogService
    {
        private readonly IDialogService _dialogService;

        public CustomerDialogService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task<Customer> OpenCreateCustomerDialogAsync()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Medium };
            var dialog = _dialogService.Show<NewCustomerDialog>("Create New Customer", options);
            var result = await dialog.Result;

            if (!result.Canceled)
            {
                return (Customer)result.Data;
            }
            return null;
        }
    }
}
