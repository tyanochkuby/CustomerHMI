namespace CustomersTable.Data.Interfaces
{
    public interface IUserService
    {
        public bool isLightMode { get; }
        public bool IsLoggenIn { get; set; }
        public event EventHandler? OnIsLoggenInChanged;
        public Task<bool> RegisterAsync(string email, string password);
        public Task<bool> LoginAsync(string username, string password);
        public Task<bool> SetLightModeAsync(bool isLightMode);
        public Task<string> GetLoggedInUserIdAsync();
        public Task<bool> IsAuthenticatedAsync();
    }
}
