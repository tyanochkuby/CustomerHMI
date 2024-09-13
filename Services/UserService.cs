namespace CustomersTable.Services
{
    using System.Net.Http;
    using System.Net.Http.Json;
    using System.Threading.Tasks;
    using CustomersTable.Data.Interfaces;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;
        private readonly IJSRuntime _jsRuntime;
        public event EventHandler? OnIsLoggenInChanged;

        private bool _isLoggenIn;

        public bool IsLoggenIn
        {
            get => _isLoggenIn;
            set
            {
                _isLoggenIn = value;
                OnIsLoggenInChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public UserService(HttpClient httpClient, NavigationManager navigationManager, IJSRuntime jsRuntime)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _jsRuntime = jsRuntime;
        }

        public async Task<bool> RegisterAsync(string email, string password)
        {
            var registerResult = await _httpClient.PostAsJsonAsync("register", new
            {
                Email = email,
                Password = password
            });

            if (registerResult.IsSuccessStatusCode)
            {
                // Optionally, after successful registration, you can auto-login the user
                _navigationManager.NavigateTo("/login");
                return true;
            }

            return false;
        }


        public async Task<bool> LoginAsync(string email, string password)
        {
            var requestUri = $"login?useCookies=true&";

            var loginModel = new
            {
                email = email,
                password = password
            };

            var loginResult = await _httpClient.PostAsJsonAsync(requestUri, loginModel);

            if (loginResult.IsSuccessStatusCode)
            {
                _navigationManager.NavigateTo("/");
                return true;
            }

            return false;
        }

        public async Task<string> GetLoggedInUserIdAsync()
        {
            var userId = await _httpClient.GetStringAsync("users/me?useCookies=true");
            return userId;
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            try
            {
                var userId = await GetLoggedInUserIdAsync();
                IsLoggenIn = !string.IsNullOrEmpty(userId);
                return IsLoggenIn;
            }
            catch
            {
                return false;
            }
        }
    }

}
